#include "pch.h"
#include "common.h"

 
extern LogCallBack1 logCallBack1;
extern LogCallBack2 logCallBack2;



void Logger::Log1(Severity severity, std::string message)
{
	if (logCallBack1 == NULL) 
		throw "��־ָ��δ����ʼ��";

	logCallBack1((int)severity, const_cast<char*>(message.c_str()));
}

void Logger::Log1(Severity severity, LPCSTR pstrFormat, ...)
{
	if (logCallBack1 == NULL)
		throw "��־ָ��δ����ʼ��";

	va_list arg;
	va_start(arg, pstrFormat);
	std::string temp;
	const char* start = const_cast<char*>(pstrFormat);
	while (*start != '\0')
	{
		if (*start == '%') {
			start++;
			switch (*start){
			case 'd':
				temp += std::to_string(va_arg(arg, int));
				break;
			case 'c':
				temp += std::to_string(va_arg(arg, int));//char��������,��int���͡� 
				break;
			case 's': {
				char* ch = va_arg(arg, char*);
				while (*ch){
					temp += *ch;
					ch++;
				}
				delete ch;
			}
			break;
			case 'f': 	
				temp += std::to_string((float)va_arg(arg, double));		
				break;
			default:
				break;
			}
		}
		else {
			temp += *start;
		}
		start++;
	}
	va_end(arg);   //��������һ��������ջ����

	logCallBack1((int)severity, (char*)temp.c_str());
}


void Logger::Log2(Severity severity, LPCTSTR pstrFormat, ...)
{
	if (logCallBack2 == NULL)
		throw "��־ָ��δ����ʼ��";

	va_list arg;
	va_start(arg, pstrFormat);
	std::string temp;
	std::string pstr = ws2s(pstrFormat);
	const char* start = pstr.c_str();
	while (*start != '\0')
	{
		if (*start == '%') {
			start++;
			switch (*start)
			{
			case 'd':
				temp += std::to_string(va_arg(arg, int));
				break;
			case 'c':
				temp += std::to_string(va_arg(arg, int));//char��������,��int���͡� 
				break;
			case 's':
			{ /*puts(va_arg(arg, char*));*/   //�ַ�������ֱ����puts()�������  
				char* ch = va_arg(arg, char*);//����һ��ָ��������ջ�ȡ���ַ�����putchar����һ��һ�����  
				while (*ch)
				{
					temp += *ch;
					ch++;
				}
			}
			break;
			case 'f': {
				temp += std::to_string((float)va_arg(arg, double));
				//float a = (float)va_arg(arg, double);  //float����������������double ��С���壩
				//printf("%f", a);  //BUG  Ҫģ�⸡���ͱȽϸ��ӣ�����ˣ��С����~ 
			}
					break;
			default:
				break;
			}
		}
		else {
			temp += *start;
			//putchar(*start);
		}
		start++;
	}
	va_end(arg);   //��������һ��������ջ����



	logCallBack2((int)severity, (char*)temp.c_str());
}


