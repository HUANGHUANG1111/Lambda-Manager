
#ifndef DSHOW_HEADER_H_INC_
#define DSHOW_HEADER_H_INC_

#pragma once

#ifdef _USE_DSHOW_

#if !defined __DSHOW_INCLUDED__
// If the following header file cannot be found, you have to add the include directory
// of your DirectX SDK installation to the include path of this project.
// In order to add a directory to the include path, you have to open the C++ Settings dialog
// and select the Page "Preprocessor". In the edit field "Additional include directories"
// the Path has to be added.
// 
// The DirectX / DirectShow SDK is avaialble at http://www.microsoft.com.
// If .NET 2005 is in use, then the DirectShow SDK belongs to the "Windows Server 2003 R2 Platform SDK".
// Also the DirectX SDK for .NET 2005 is needed.
//
#include <DShow.h>

#pragma comment ( lib, "strmiids.lib" )

#else
#pragma comment ( lib, "strmiids.lib" )
#endif

#else

// When you get errors in the following lines, your options are :
// 1) not include "dshow.h"
// 2) change the include order to include dshow.h before including this header
// 3) #define _USE_DSHOW_ to force this header to include DirectShow directly when it is needed.


// The following definitions are used to emulate the DirectShow headers
// These are the only parts needed by the library from DirectShow.


#ifndef MEDIASUBTYPE_NULL
	#define MEDIASUBTYPE_NULL    GUID_NULL

	static const GUID MEDIASUBTYPE_RGB8 = {	0xe436eb7a, 0x524f, 0x11ce, 0x9f, 0x53, 0x00, 0x20, 0xaf, 0x0b, 0xa7, 0x70 };
	static const GUID MEDIASUBTYPE_RGB565 = { 0xe436eb7b, 0x524f, 0x11ce, 0x9f, 0x53, 0x00, 0x20, 0xaf, 0x0b, 0xa7, 0x70 };
	static const GUID MEDIASUBTYPE_RGB555 = { 0xe436eb7c, 0x524f, 0x11ce, 0x9f, 0x53, 0x00, 0x20, 0xaf, 0x0b, 0xa7, 0x70 };
	static const GUID MEDIASUBTYPE_RGB24 = { 0xe436eb7d, 0x524f, 0x11ce, 0x9f, 0x53, 0x00, 0x20, 0xaf, 0x0b, 0xa7, 0x70 };
	static const GUID MEDIASUBTYPE_RGB32 = { 0xe436eb7e, 0x524f, 0x11ce, 0x9f, 0x53, 0x00, 0x20, 0xaf, 0x0b, 0xa7, 0x70 };

	static const GUID MEDIASUBTYPE_YUYV = { 0x56595559, 0x0000, 0x0010, { 0x80, 0x00, 0x00, 0xAA, 0x00, 0x38, 0x9B, 0x71 } };
	static const GUID MEDIASUBTYPE_IYUV = { 0x56555949, 0x0000, 0x0010, { 0x80, 0x00, 0x00, 0xAA, 0x00, 0x38, 0x9B, 0x71 } };
	static const GUID MEDIASUBTYPE_YVU9 = { 0x39555659, 0x0000, 0x0010, { 0x80, 0x00, 0x00, 0xAA, 0x00, 0x38, 0x9B, 0x71 } };
	static const GUID MEDIASUBTYPE_Y411 = { 0x31313459, 0x0000, 0x0010, { 0x80, 0x00, 0x00, 0xAA, 0x00, 0x38, 0x9B, 0x71 } };
	static const GUID MEDIASUBTYPE_Y41P = { 0x50313459, 0x0000, 0x0010, { 0x80, 0x00, 0x00, 0xAA, 0x00, 0x38, 0x9B, 0x71 } };
	static const GUID MEDIASUBTYPE_YUY2 = { 0x32595559, 0x0000, 0x0010, { 0x80, 0x00, 0x00, 0xAA, 0x00, 0x38, 0x9B, 0x71 } };
	static const GUID MEDIASUBTYPE_YVYU = { 0x55595659, 0x0000, 0x0010, { 0x80, 0x00, 0x00, 0xAA, 0x00, 0x38, 0x9B, 0x71 } };
	static const GUID MEDIASUBTYPE_UYVY = { 0x59565955, 0x0000, 0x0010, { 0x80, 0x00, 0x00, 0xAA, 0x00, 0x38, 0x9B, 0x71 } };
	static const GUID MEDIASUBTYPE_Y211 = { 0x31313259, 0x0000, 0x0010, { 0x80, 0x00, 0x00, 0xAA, 0x00, 0x38, 0x9B, 0x71 } };
#endif


#if !defined __IAMAnalogVideoDecoder_INTERFACE_DEFINED__

typedef enum tagAnalogVideoStandard
{
	AnalogVideo_None	= 0,
	AnalogVideo_NTSC_M	= 0x1,
	AnalogVideo_NTSC_M_J	= 0x2,
	AnalogVideo_NTSC_433	= 0x4,
	AnalogVideo_PAL_B	= 0x10,
	AnalogVideo_PAL_D	= 0x20,
	AnalogVideo_PAL_G	= 0x40,
	AnalogVideo_PAL_H	= 0x80,
	AnalogVideo_PAL_I	= 0x100,
	AnalogVideo_PAL_M	= 0x200,
	AnalogVideo_PAL_N	= 0x400,
	AnalogVideo_PAL_60	= 0x800,
	AnalogVideo_SECAM_B	= 0x1000,
	AnalogVideo_SECAM_D	= 0x2000,
	AnalogVideo_SECAM_G	= 0x4000,
	AnalogVideo_SECAM_H	= 0x8000,
	AnalogVideo_SECAM_K	= 0x10000,
	AnalogVideo_SECAM_K1	= 0x20000,
	AnalogVideo_SECAM_L	= 0x40000,
	AnalogVideo_SECAM_L1	= 0x80000,
	AnalogVideo_PAL_N_COMBO	= 0x100000,
	AnalogVideoMask_MCE_NTSC	= ( ( ( ( ( ( AnalogVideo_NTSC_M | AnalogVideo_NTSC_M_J )  | AnalogVideo_NTSC_433 )  | AnalogVideo_PAL_M )  | AnalogVideo_PAL_N )  | AnalogVideo_PAL_60 )  | AnalogVideo_PAL_N_COMBO ) ,
	AnalogVideoMask_MCE_PAL	= ( ( ( ( AnalogVideo_PAL_B | AnalogVideo_PAL_D )  | AnalogVideo_PAL_G )  | AnalogVideo_PAL_H )  | AnalogVideo_PAL_I ) ,
	AnalogVideoMask_MCE_SECAM	= ( ( ( ( ( ( ( AnalogVideo_SECAM_B | AnalogVideo_SECAM_D )  | AnalogVideo_SECAM_G )  | AnalogVideo_SECAM_H )  | AnalogVideo_SECAM_K )  | AnalogVideo_SECAM_K1 )  | AnalogVideo_SECAM_L )  | AnalogVideo_SECAM_L1 ) 
} AnalogVideoStandard;

typedef 
enum tagPhysicalConnectorType
{	PhysConn_Video_Tuner	= 1,
	PhysConn_Video_Composite	= ( PhysConn_Video_Tuner + 1 ) ,
	PhysConn_Video_SVideo	= ( PhysConn_Video_Composite + 1 ) ,
	PhysConn_Video_RGB	= ( PhysConn_Video_SVideo + 1 ) ,
	PhysConn_Video_YRYBY	= ( PhysConn_Video_RGB + 1 ) ,
	PhysConn_Video_SerialDigital	= ( PhysConn_Video_YRYBY + 1 ) ,
	PhysConn_Video_ParallelDigital	= ( PhysConn_Video_SerialDigital + 1 ) ,
	PhysConn_Video_SCSI	= ( PhysConn_Video_ParallelDigital + 1 ) ,
	PhysConn_Video_AUX	= ( PhysConn_Video_SCSI + 1 ) ,
	PhysConn_Video_1394	= ( PhysConn_Video_AUX + 1 ) ,
	PhysConn_Video_USB	= ( PhysConn_Video_1394 + 1 ) ,
	PhysConn_Video_VideoDecoder	= ( PhysConn_Video_USB + 1 ) ,
	PhysConn_Video_VideoEncoder	= ( PhysConn_Video_VideoDecoder + 1 ) ,
	PhysConn_Video_SCART	= ( PhysConn_Video_VideoEncoder + 1 ) ,
	PhysConn_Video_Black	= ( PhysConn_Video_SCART + 1 ) ,
	PhysConn_Audio_Tuner	= 0x1000,
	PhysConn_Audio_Line	= ( PhysConn_Audio_Tuner + 1 ) ,
	PhysConn_Audio_Mic	= ( PhysConn_Audio_Line + 1 ) ,
	PhysConn_Audio_AESDigital	= ( PhysConn_Audio_Mic + 1 ) ,
	PhysConn_Audio_SPDIFDigital	= ( PhysConn_Audio_AESDigital + 1 ) ,
	PhysConn_Audio_SCSI	= ( PhysConn_Audio_SPDIFDigital + 1 ) ,
	PhysConn_Audio_AUX	= ( PhysConn_Audio_SCSI + 1 ) ,
	PhysConn_Audio_1394	= ( PhysConn_Audio_AUX + 1 ) ,
	PhysConn_Audio_USB	= ( PhysConn_Audio_1394 + 1 ) ,
	PhysConn_Audio_AudioDecoder	= ( PhysConn_Audio_USB + 1 ) 
} 	PhysicalConnectorType;

#endif // __IAMAnalogVideoDecoder_INTERFACE_DEFINED__

#endif

#endif // DSHOW_HEADER_H_INC_
