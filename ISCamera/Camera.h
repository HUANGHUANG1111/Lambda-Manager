#pragma once
#include <string>
#include "common.h"

#ifdef ISCAMERA_EXPORTS
#define CAMERA_API __declspec(dllexport)
#else
#define CAMERA_API __declspec(dllimport)
#endif

extern "C" CAMERA_API int OpenCamera();

extern "C" CAMERA_API int OpenCinema();

extern "C" CAMERA_API int CloseCamera();

extern "C" CAMERA_API int CaptureImage(int mode, void** image);

extern "C" CAMERA_API int SetProperty(std::string name, std::string value);

extern "C" CAMERA_API int LoadProperty(std::string xmlProperties);

extern "C" CAMERA_API int SaveSettings();

int PlayFilms(json* eventData);

int PlayFilm(std::string fileName);