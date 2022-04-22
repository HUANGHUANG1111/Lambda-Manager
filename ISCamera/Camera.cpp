#pragma warning(disable:26812 26495 26451 6294 6201)

#include "pch.h"
#include "Camera.h"
#include "time.h"
#include <opencv2/core.hpp>
#include <opencv2/videoio.hpp>
#include "thread"
#include "concurrent.h"
#include "threadpool.h"

using namespace std;

LambdaView* pView = NULL;
ConcurrentQueue<shared_future<cv::Mat*>> pipeline;
ThreadPool pool;

int OpenCamera()
{
	pView = LambdaView::GetIdleOrNew();
	if (pView->IsState(ViewState::RUNING)) {
		Logger::Log1(Severity::INFO, "ERROR! Camera is running");
		return -1;
	}

	auto f = async(Start);
	for (;;)
	{
		auto result = pipeline.wait_and_pop();
		shared_future<cv::Mat*> sf = *result;
		if (sf.valid()) {
			cv::Mat* image = sf.get();
			pView->Show(*image);
			if (pView->IsState(ViewState::CLOSED)) {
				pool.Stop();
				break;
			}
		}
		else
			break;
	}
	return f.get();
}

int Start() {
	cv::Mat frames[MAX_THREADPOOL_NUM];
	cv::VideoCapture cap;
	int deviceID = 0;             // 0 = open default camera
	int apiID = cv::CAP_ANY;      // 0 = autodetect default API
	cap.open(deviceID, apiID);

	if (!cap.isOpened()) {
		Logger::Log1(Severity::INFO, "ERROR! Unable to open camera");
		return -1;
	}

	int index = 0;
	for (;;) {
		cv::Mat& frame = frames[index];
		cap.read(frame);
		pipeline.push(pool.Commit(Filter, frame));
		++index;
		if (index == MAX_THREADPOOL_NUM)
			index = 0;
		if (pool.IsStopped())
			break;
	}
	return 0;
}

cv::Mat* Filter(cv::Mat& frame) {
	if (frame.empty()) {
		Logger::Log1(Severity::INFO, "Video is end");
		return nullptr;
	}
	Event::Trigger("FILTER_START", &frame);
	return &frame;
}

int OpenCinema() {
	Event::On("FILE_SELECTED", &PlayFilms, true);
	Event::Trigger("OPEN_FILE_DIALOG");
	return 0;
}

int PlayFilms(json* eventData) {
	json filenames = eventData->at("fileNames");
	if (filenames == NULL)
		return -1;
	for (auto& item : filenames.items()) {
		std::string fileName = item.value().get<std::string>();
		thread task(PlayFilm, fileName);
		task.detach(); //don't block calling thread
	}
	return 0;
}

int PlayFilm(std::string fileName) {
	cv::Mat frame;
	cv::VideoCapture cap = cv::VideoCapture(fileName);

	if (!cap.isOpened()) {
		Logger::Log1(Severity::INFO, "ERROR! Unable to open camera");
		return -1;
	}
	LambdaView* pView = LambdaView::GetIdleOrNew();
	std::wstring&& s = StringUtils::string2wstring(fileName);
	int count = 0;

	for (;;)
	{
		// wait for a new frame from camera and store it into 'frame'
		cap.read(frame);

		// check if we succeeded
		if (frame.empty()) {
			Logger::Log1(Severity::INFO, "Video is end");
			break;
		}
		pView->Show(frame);
		if (pView->IsState(ViewState::CLOSED))
			break;
	}
	// the camera will be deinitialized automatically in VideoCapture destructor
	return 0;
}

int CloseCamera()
{
	Logger::Log1(Severity::INFO, "Invoke 'CloseCamera()'");
	return  0;
}

int CaptureImage(int mode, void** image)
{
	Logger::Log2(Severity::INFO, L"Invoke 'CaptureImage(mode: %d, <out> image: %p)'", mode, image);
	char* buff = (char*)malloc(20);
	if (buff != NULL) {
		struct tm t;
		time_t now = time(NULL);
		localtime_s(&t, &now);
		sprintf_s(buff, 20, "Image: %d:%d:%d", t.tm_hour, t.tm_min, t.tm_sec);
		*image = buff;
	}

	return  0;
}

int SetProperty(std::string name, std::string value)
{
	
	Logger::Log2(Severity::INFO, L"Invoke 'SetProperty(mode: %s, image: %s)'", name, value);
	return  0;
}

int LoadProperty(std::string xml)
{
	Logger::Log2(Severity::INFO, L"Invoke 'LoadProperty(xml: %s)'", xml);
	return  0;
}

int SaveSettings()
{
	Logger::Log1(Severity::INFO, "Invoke 'SaveSettings()'");
	return  0;
}


string UtfToGbk(string strValue)
{
	int len = MultiByteToWideChar(CP_UTF8, 0, strValue.c_str(), -1, NULL, 0);
	wchar_t* wstr = new wchar_t[len + 1];
	memset(wstr, 0, len + 1);
	MultiByteToWideChar(CP_UTF8, 0, strValue.c_str(), -1, wstr, len);
	len = WideCharToMultiByte(CP_ACP, 0, wstr, -1, NULL, 0, NULL, NULL);
	char* str = new char[len + 1];
	memset(str, 0, len + 1);
	WideCharToMultiByte(CP_ACP, 0, wstr, -1, str, len, NULL, NULL);
	if (wstr) delete[] wstr;
	return string(str);
}


string UtfToString(string strValue)

{
	int nwLen = ::MultiByteToWideChar(CP_ACP, 0, strValue.c_str(), -1, NULL, 0);
	wchar_t* pwBuf = new wchar_t[nwLen + 1];//����ĩβ'\0'
	ZeroMemory(pwBuf, nwLen * 2 + 2);
	::MultiByteToWideChar(CP_ACP, 0, strValue.c_str(), strValue.length(), pwBuf, nwLen);
	int nLen = ::WideCharToMultiByte(CP_UTF8, 0, pwBuf, -1, NULL, NULL, NULL, NULL);
	char* pBuf = new char[nLen + 1];
	ZeroMemory(pBuf, nLen + 1);
	::WideCharToMultiByte(CP_UTF8, 0, pwBuf, nwLen, pBuf, nLen, NULL, NULL);
	std::string retStr(pBuf);
	delete[]pwBuf;
	delete[]pBuf;
	pwBuf = NULL;
	pBuf = NULL;
	return retStr;
}
string StringToUtf(string strValue)
{
	int nwLen = MultiByteToWideChar(CP_UTF8, 0, strValue.c_str(), -1, NULL, 0);
	wchar_t* pwBuf = new wchar_t[nwLen + 1];//����ĩβ'\0'
	memset(pwBuf, 0, nwLen * 2 + 2);
	MultiByteToWideChar(CP_UTF8, 0, strValue.c_str(), strValue.length(), pwBuf, nwLen);
	int nLen = WideCharToMultiByte(CP_UTF7, 0, pwBuf, -1, NULL, NULL, NULL, NULL);
	char* pBuf = new char[nLen + 1];
	memset(pBuf, 0, nLen + 1);
	WideCharToMultiByte(CP_ACP, 0, pwBuf, nwLen, pBuf, nLen, NULL, NULL);
	std::string retStr = pBuf;
	delete[]pBuf;
	delete[]pwBuf;
	return retStr;
}


int OpenSerial(std::string FullPath)
{
	Logger::Log2(Severity::INFO, L"����: Test14(s=\"%s\")", FullPath);
	return  0;
}

int CameraSettingExposure(double exposure)
{
	//name = json2string("����");

	std::string name = "a����";
	//name = StringToUtf(name);
	Logger::Log2(Severity::INFO, L"%s'", exposure);
	return  0;
}
