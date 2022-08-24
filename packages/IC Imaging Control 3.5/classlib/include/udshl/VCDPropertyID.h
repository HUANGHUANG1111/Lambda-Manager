
#ifndef VCDPROPERTYID_H_INC_
#define VCDPROPERTYID_H_INC_

#include "libbasedefs.h"

#pragma once

namespace _DSHOWLIB_NAMESPACE
{
    static const GUID VCDElement_Value = { 0xB57D3000, 0x0AC6, 0x4819, { 0xA6, 0x09, 0x27, 0x2A, 0x33, 0x14, 0x0A, 0xCA } };
    static const GUID VCDElement_Auto = { 0xB57D3001, 0x0AC6, 0x4819, { 0xA6, 0x09, 0x27, 0x2A, 0x33, 0x14, 0x0A, 0xCA } };
    static const GUID VCDElement_OnePush = { 0xB57D3002, 0x0AC6, 0x4819, { 0xA6, 0x09, 0x27, 0x2A, 0x33, 0x14, 0x0A, 0xCA } };

    static const GUID VCDElement_AutoMaxValueAuto = { 0x65190390, 0x1AD8, 0x4E91, { 0x90, 0x21, 0x66, 0xD6, 0x40, 0x90, 0xCC, 0x85 } };
    static const GUID VCDElement_AutoMaxValue = { 0x6519038F, 0x1AD8, 0x4E91, { 0x90, 0x21, 0x66, 0xD6, 0x40, 0x90, 0xCC, 0x85 } };
    static const GUID VCDElement_AutoMinValue = { 0x65190391, 0x1AD8, 0x4E91, { 0x90, 0x21, 0x66, 0xD6, 0x40, 0x90, 0xCC, 0x85 } };
    static const GUID VCDElement_AutoReference = { 0x6519038C, 0x1AD8, 0x4E91, { 0x90, 0x21, 0x66, 0xD6, 0x40, 0x90, 0xCC, 0x85 } };

    static const GUID VCDElement_OnePushRunning = { 0x7d2dd39, 0x3f10, 0x4e0f, { 0x8e, 0xe5, 0x3e, 0xed, 0x6, 0x7a, 0x53, 0xc6 } };     // {07D2DD39-3F10-4E0F-8EE5-3EED067A53C6}

    static const GUID VCDID_Brightness = { 0x284C0E06, 0x010B, 0x45BF, { 0x82, 0x91, 0x09, 0xD9, 0x0A, 0x45, 0x9B, 0x28 } };
    static const GUID VCDID_Contrast = { 0x284C0E07, 0x010B, 0x45BF, { 0x82, 0x91, 0x09, 0xD9, 0x0A, 0x45, 0x9B, 0x28 } };
    static const GUID VCDID_Hue = { 0x284C0E08, 0x010B, 0x45BF, { 0x82, 0x91, 0x09, 0xD9, 0x0A, 0x45, 0x9B, 0x28 } };
    static const GUID VCDID_Saturation = { 0x284C0E09, 0x010B, 0x45BF, { 0x82, 0x91, 0x09, 0xD9, 0x0A, 0x45, 0x9B, 0x28 } };
    static const GUID VCDID_Sharpness = { 0x284C0E0A, 0x010B, 0x45BF, { 0x82, 0x91, 0x09, 0xD9, 0x0A, 0x45, 0x9B, 0x28 } };
    static const GUID VCDID_Gamma = { 0x284C0E0B, 0x010B, 0x45BF, { 0x82, 0x91, 0x09, 0xD9, 0x0A, 0x45, 0x9B, 0x28 } };
    static const GUID VCDID_ColorEnable = { 0x284C0E0C, 0x010B, 0x45BF, { 0x82, 0x91, 0x09, 0xD9, 0x0A, 0x45, 0x9B, 0x28 } };
    static const GUID VCDID_WhiteBalance = { 0x284C0E0D, 0x010B, 0x45BF, { 0x82, 0x91, 0x09, 0xD9, 0x0A, 0x45, 0x9B, 0x28 } };
    static const GUID VCDID_BacklightCompensation = { 0x284C0E0E, 0x010B, 0x45BF, { 0x82, 0x91, 0x09, 0xD9, 0x0A, 0x45, 0x9B, 0x28 } };
    static const GUID VCDID_Gain = { 0x284C0E0F, 0x010B, 0x45BF, { 0x82, 0x91, 0x09, 0xD9, 0x0A, 0x45, 0x9B, 0x28 } };

    static const GUID VCDID_Pan = { 0x90D5702A, 0xE43B, 0x4366, { 0xAA, 0xEB, 0x7A, 0x7A, 0x10, 0xB4, 0x48, 0xB4 } };
    static const GUID VCDID_Tilt = { 0x90D5702B, 0xE43B, 0x4366, { 0xAA, 0xEB, 0x7A, 0x7A, 0x10, 0xB4, 0x48, 0xB4 } };
    static const GUID VCDID_Roll = { 0x90D5702C, 0xE43B, 0x4366, { 0xAA, 0xEB, 0x7A, 0x7A, 0x10, 0xB4, 0x48, 0xB4 } };
    static const GUID VCDID_Zoom = { 0x90D5702D, 0xE43B, 0x4366, { 0xAA, 0xEB, 0x7A, 0x7A, 0x10, 0xB4, 0x48, 0xB4 } };
    static const GUID VCDID_Exposure = { 0x90D5702E, 0xE43B, 0x4366, { 0xAA, 0xEB, 0x7A, 0x7A, 0x10, 0xB4, 0x48, 0xB4 } };
    static const GUID VCDID_Iris = { 0x90D5702F, 0xE43B, 0x4366, { 0xAA, 0xEB, 0x7A, 0x7A, 0x10, 0xB4, 0x48, 0xB4 } };
    static const GUID VCDID_Focus = { 0x90D57030, 0xE43B, 0x4366, { 0xAA, 0xEB, 0x7A, 0x7A, 0x10, 0xB4, 0x48, 0xB4 } };

    static const GUID VCDID_Trigger = { 0x90D57031, 0xE43B, 0x4366, { 0xAA, 0xEB, 0x7A, 0x7A, 0x10, 0xB4, 0x48, 0xB4 } };
    static const GUID VCDID_TriggerMode = VCDID_Trigger;

    static const GUID VCDID_VCRCompatibilityMode = { 0x90D57032, 0xE43B, 0x4366, { 0xAA, 0xEB, 0x7A, 0x7A, 0x10, 0xB4, 0x48, 0xB4 } };
    static const GUID VCDID_SignalDetected = { 0x90D57033, 0xE43B, 0x4366, { 0xAA, 0xEB, 0x7A, 0x7A, 0x10, 0xB4, 0x48, 0xB4 } };
    static const GUID VCDID_TestPattern = { 0xF7EAA79E, 0x90FA, 0x4969, { 0xB0, 0x5F, 0x9B, 0xDA, 0xF1, 0xA4, 0x32, 0x8F } };
    static const GUID VCDID_Binning = { 0x4f95a06d, 0x9c15, 0x407b, { 0x96, 0xab, 0xcf, 0x3f, 0xed, 0x4, 0x7b, 0xa4 } };
    static const GUID VCDID_Denoise = { 0xC3C9944A, 0xE6F6, 0x4E25, { 0xA0, 0xBE, 0x53, 0xC0, 0x66, 0xAB, 0x65, 0xD8 } };
    static const GUID VCDID_Highlightreduction = { 0x546541AD, 0xC815, 0x4D82, { 0xAF, 0xA9, 0x9D, 0x59, 0xAF, 0x9F, 0x39, 0x9E } };
    static const GUID VCDID_IRCutFilter = { 0x7608DD7D, 0xA1F8, 0x4BB4, { 0x8A, 0x73, 0x88, 0x84, 0x20, 0x9E, 0x90, 0x19 } };
    static const GUID VCDID_ColorEnhancement = { 0x3a3a8f77, 0x6440, 0x46cc, { 0x94, 0xa, 0x87, 0x52, 0xb0, 0x2e, 0x6c, 0x29 } };           // {3A3A8F77-6440-46cc-940A-8752B02E6C29}
    static const GUID VCDID_FlipHorizontal = { 0xE33B9C58, 0x0BF8, 0x442D, { 0x80, 0x35, 0xB4, 0xAB, 0xD7, 0xAF, 0x44, 0xAA } };                            // {E33B9C58-0BF8-442D-8035-B4ABD7AF44AA}
    static const GUID VCDID_FlipVertical = { 0xE33B9C58, 0x0BF8, 0x442D, { 0x80, 0x35, 0xB4, 0xAB, 0xD7, 0xAF, 0x44, 0xAB } };                              // {E33B9C58-0BF8-442D-8035-B4ABD7AF44AB}
    static const GUID VCDID_IMX236WDRMode = { 0xAA5A18E6, 0xB052, 0x4DCD, { 0xBB, 0xF0, 0x4A, 0x16, 0xF4, 0x35, 0xEA, 0x9A } };                   // {AA5A18E6-B052-4DCD-BBF0-4A16F435EA9A}
    static const GUID VCDID_PolarizationVisualizationMode = { 0x15dd5a42, 0x673c, 0x468d, { 0xb1, 0xb8, 0x5, 0x9c, 0x11, 0x41, 0x91, 0xdb } };          // {15DD5A42-673C-468D-B1B8-059C114191DB}

    static const GUID VCDElement_WhiteBalanceMode = { 0xAB98F78D, 0x18A6, 0x4EB2, { 0xA5, 0x56, 0xC1, 0x10, 0x10, 0xEC, 0x9D, 0xF7 } };
    static const GUID VCDElement_Auto_Preset = { 0xE5F037C5, 0xA466, 0x4F80, { 0xA7, 0x17, 0x3E, 0x50, 0x60, 0x53, 0x27, 0x4A } };
    static const GUID VCDElement_Auto_TemperaturePreset = { 0x88143B6D, 0xA1C5, 0x45D6, { 0xBF, 0x7F, 0x95, 0xF6, 0x44, 0x7A, 0xB1, 0xBE } };
    static const GUID VCDElement_Temperature = { 0xB8D65671, 0x94E0, 0x4DBB, { 0x92, 0x75, 0x0C, 0x29, 0xD4, 0xF6, 0xBA, 0x87 } };
    static const GUID VCDElement_WhiteBalanceRed = { 0x6519038B, 0x1AD8, 0x4E91, { 0x90, 0x21, 0x66, 0xD6, 0x40, 0x90, 0xCC, 0x85 } };
    static const GUID VCDElement_WhiteBalanceGreen = { 0x8407e480, 0x175a, 0x498c, { 0x81, 0x71, 0x8, 0xbd, 0x98, 0x7c, 0xc1, 0xac } };     // {8407E480-175A-498c-8171-08BD987CC1AC}
    static const GUID VCDElement_WhiteBalanceBlue = { 0x6519038A, 0x1AD8, 0x4E91, { 0x90, 0x21, 0x66, 0xD6, 0x40, 0x90, 0xCC, 0x85 } };
    static const GUID VCDElement_WhiteBalanceCY = { 0x8c3430e8, 0xe35, 0x4535, { 0x80, 0x15, 0xeb, 0x17, 0xa7, 0x40, 0xd4, 0x4f } };    // {8C3430E8-0E35-4535-8015-EB17A740D44F}
    static const GUID VCDElement_WhiteBalanceMG = { 0x7747c873, 0x614c, 0x4492, { 0xbc, 0x93, 0xcc, 0x95, 0x47, 0x69, 0x88, 0x54 } };   // {7747C873-614C-4492-BC93-CC9547698854}

    static const GUID VCDID_PartialScanOffset = { 0x2CED6FD6, 0xAB4D, 0x4C74, { 0x90, 0x4C, 0xD6, 0x82, 0xE5, 0x3B, 0x9C, 0xC5 } };             // 2CED6FD6-AB4D-4C74-904C-D682E53B9CC5
    static const GUID VCDElement_PartialScanOffsetX = { 0x5E59F654, 0x7B47, 0x4458, { 0xB4, 0xC6, 0x5D, 0x4F, 0x0D, 0x17, 0x5F, 0xC1 } };       // 5E59F654-7B47-4458-B4C6-5D4F0D175FC1
    static const GUID VCDElement_PartialScanOffsetY = { 0x87FB6C02, 0x98A8, 0x46B0, { 0xB1, 0x8D, 0x64, 0x42, 0xD9, 0x77, 0x5C, 0xD3 } };       // 87FB6C02-98A8-46B0-B18D-6442D9775CD3
    static const GUID VCDElement_PartialScanAutoCenter = { 0x36eaa683, 0x3321, 0x44be, { 0x9d, 0x73, 0xe1, 0xfd, 0x4c, 0x3f, 0xdb, 0x87 } };

    static const GUID VCDID_GPIO = { 0x86D89D69, 0x9880, 0x4618, { 0x9B, 0xF6, 0xDE, 0xD5, 0xE8, 0x38, 0x34, 0x49 } };
    static const GUID VCDElement_GPIOIn = { 0x7D006621, 0x761D, 0x4B88, { 0x9C, 0x5F, 0x8B, 0x90, 0x68, 0x57, 0xA5, 0x00 } };
    static const GUID VCDElement_GPIOOut = { 0x7D006621, 0x761D, 0x4B88, { 0x9C, 0x5F, 0x8B, 0x90, 0x68, 0x57, 0xA5, 0x01 } };
    static const GUID VCDElement_GPIOWrite = { 0x7D006621, 0x761D, 0x4B88, { 0x9C, 0x5F, 0x8B, 0x90, 0x68, 0x57, 0xA5, 0x02 } };
    static const GUID VCDElement_GPIORead = { 0x7D006621, 0x761D, 0x4B88, { 0x9C, 0x5F, 0x8B, 0x90, 0x68, 0x57, 0xA5, 0x03 } };

    static const GUID VCDID_Strobe = { 0xDC320EDE, 0xDF2E, 0x4A90, { 0xB9, 0x26, 0x71, 0x41, 0x7C, 0x71, 0xC5, 0x7C } };                    // DC320EDE-DF2E-4A90-B926-71417C71C57C
    static const GUID VCDElement_StrobePolarity = { 0xB41DB628, 0x0975, 0x43F8, { 0xA9, 0xD9, 0x7E, 0x03, 0x80, 0x58, 0x0A, 0xCA } };       // B41DB628-0975-43F8-A9D9-7E0380580ACA
    static const GUID VCDElement_StrobeDuration = { 0xB41DB628, 0x0975, 0x43F8, { 0xA9, 0xD9, 0x7E, 0x03, 0x80, 0x58, 0x0A, 0xCB } };
    static const GUID VCDElement_StrobeDelay = { 0xB41DB628, 0x0975, 0x43F8, { 0xA9, 0xD9, 0x7E, 0x03, 0x80, 0x58, 0x0A, 0xCC } };
    static const GUID VCDElement_StrobeMode = { 0xB41DB628, 0x0975, 0x43F8, { 0xA9, 0xD9, 0x7E, 0x03, 0x80, 0x58, 0x0A, 0xCD } };

    static const GUID VCDElement_TriggerPolarity = { 0x6519038D, 0x1AD8, 0x4E91, { 0x90, 0x21, 0x66, 0xD6, 0x40, 0x90, 0xCC, 0x85 } };
    static const GUID VCDElement_TriggerMode = { 0x6519038E, 0x1AD8, 0x4E91, { 0x90, 0x21, 0x66, 0xD6, 0x40, 0x90, 0xCC, 0x85 } };
    static const GUID VCDElement_SoftwareTrigger = { 0xfdb4003c, 0x552c, 0x4faa, { 0xb8, 0x7b, 0x42, 0xe8, 0x88, 0xd5, 0x41, 0x47 } };      // {FDB4003C-552C-4faa-B87B-42E888D54147}
    static const GUID VCDElement_TriggerDelay = { 0xc337cfb8, 0xea08, 0x4e69, { 0xa6, 0x55, 0x58, 0x69, 0x37, 0xb6, 0xaf, 0xec } };         // {C337CFB8-EA08-4E69-A655-586937B6AFEC}
    static const GUID VCDElement_TriggerOperation = { 0x859a76b9, 0xe289, 0x472b, { 0xab, 0x5, 0xc9, 0xb3, 0xf2, 0x6d, 0xca, 0xa0 } };      // {859A76B9-E289-472B-AB05-C9B3F26DCAA0}
    static const GUID VCDElement_TriggerMaskTime = { 0x9CF42696, 0x7C51, 0x4BFE, { 0x8D, 0x83, 0x29, 0x6D, 0x72, 0x9C, 0x42, 0xA2 } };                      // {9CF42696-7C51-4BFE-8D83-296D729C42A2}
    static const GUID VCDElement_TriggerDebounceTime = { 0x6A9D1F4E, 0xB0AB, 0x4472, { 0x9B, 0xB3, 0xC6, 0x44, 0x8A, 0x1D, 0x49, 0xDA } };                  // {6A9D1F4E-B0AB-4472-9BB3-C6448A1D49DA}
    static const GUID VCDElement_TriggerNoiseSuppressionTime = { 0xB89A9D2C, 0x51FD, 0x4C2D, { 0x80, 0xDF, 0x89, 0xB6, 0x42, 0x78, 0x1B, 0x7E } };          // {B89A9D2C-51FD-4C2D-80DF-89B642781B7E}

    static const GUID VCDElement_Trigger_BurstCount = { 0xB4109964, 0x77E4, 0x4AF3, { 0xAC, 0xA8, 0x45, 0xBB, 0xAA, 0x86, 0x1B, 0x5C } };
    static const GUID VCDElement_Trigger_ExposureMode = { 0xB6E013CA, 0x76C7, 0x4DDD, { 0x9A, 0xC8, 0xA1, 0x7E, 0x07, 0xC5, 0xE3, 0xF1 } };
    static const GUID VCDElement_Trigger_Overlap = { 0x7685BF04, 0xC9C9, 0x4AE2, { 0xBA, 0x69, 0x12, 0x78, 0xB7, 0x7F, 0x97, 0xF6 } };

    static const GUID VCDElement_Trigger_IMXLowLatencyMode = { 0xBE0B5BDC, 0x0B1D, 0x4F75, { 0xB5, 0x12, 0x4F, 0x17, 0xA0, 0x47, 0x67, 0x1E } };

    static const GUID VCDElement_AutoRoiEnable = { 0x8ca6642e, 0xd3e5, 0x4ed8, { 0x95, 0xa1, 0xb1, 0x3d, 0x71, 0x31, 0xb4, 0x65 } };            // {8CA6642E-D3E5-4ED8-95A1-B13D7131B465}
    static const GUID VCDElement_AutoRoiLeft = { 0x8ca6642f, 0xd3e5, 0x4ed8, { 0x95, 0xa1, 0xb1, 0x3d, 0x71, 0x31, 0xb4, 0x65 } };              // {8CA6642F-D3E5-4ED8-95A1-B13D7131B465}
    static const GUID VCDElement_AutoRoiTop = { 0x8ca66430, 0xd3e5, 0x4ed8, { 0x95, 0xa1, 0xb1, 0x3d, 0x71, 0x31, 0xb4, 0x65 } };               // {8CA66430-D3E5-4ED8-95A1-B13D7131B465}
    static const GUID VCDElement_AutoRoiRight = { 0x8ca66431, 0xd3e5, 0x4ed8, { 0x95, 0xa1, 0xb1, 0x3d, 0x71, 0x31, 0xb4, 0x65 } };             // {8CA66431-D3E5-4ED8-95A1-B13D7131B465}
    static const GUID VCDElement_AutoRoiBottom = { 0x8ca66432, 0xd3e5, 0x4ed8, { 0x95, 0xa1, 0xb1, 0x3d, 0x71, 0x31, 0xb4, 0x65 } };            // {8CA66432-D3E5-4ED8-95A1-B13D7131B465}
    static const GUID VCDElement_AutoRoiLeftRelative = { 0x49E806F3, 0x7CDA, 0x48BA, { 0xA6, 0x7B, 0xCD, 0xED, 0xE8, 0x72, 0x8C, 0x99 } };      // {49E806F3-7CDA-48BA-A67B-CDEDE8728C99}
    static const GUID VCDElement_AutoRoiTopRelative = { 0x9333F45C, 0x1AFC, 0x42B0, { 0x80, 0xF7, 0x6D, 0xFF, 0x08, 0x3C, 0x86, 0xFD } };       // {9333F45C-1AFC-42B0-80F7-6DFF083C86FD}
    static const GUID VCDElement_AutoRoiWidthRelative = { 0x67E6E9BC, 0x8544, 0x4CC8, { 0xA9, 0xC3, 0xE4, 0x63, 0xBE, 0x69, 0x9B, 0x1E } };     // {67E6E9BC-8544-4CC8-A9C3-E463BE699B1E}
    static const GUID VCDElement_AutoRoiHeightRelative = { 0x8EC2ED61, 0xB33A, 0x4590, { 0x9E, 0x62, 0xC4, 0x32, 0x28, 0x95, 0x3B, 0x59 } };    // {8EC2ED61-B33A-4590-9E62-C43228953B59}


    static const GUID VCDID_PropertySets = { 0xA24E5340, 0xBC75, 0x4B5B, { 0xB1, 0x42, 0x09, 0x17, 0xC2, 0xCC, 0xFB, 0x3D } };
    static const GUID VCDElement_PropertySetSelector = { 0x54F4C7E5, 0xB045, 0x4D63, { 0xA2, 0x77, 0x9B, 0x23, 0x9E, 0x8D, 0x31, 0x29 } };
    static const GUID VCDElement_PropertySetActivate = { 0x5EB42E01, 0xC231, 0x458D, { 0x97, 0x24, 0x43, 0x00, 0x95, 0x08, 0x8D, 0x18 } };

    static const GUID VCDID_ToneMapping = { 0x3d505ac4, 0x1a28, 0x428b,{ 0x83, 0xe5, 0x85, 0xaa, 0x8e, 0xb4, 0x41, 0xc1 } };                                // {3d505ac4-1a28-428b-83e5-85aa8eb441c1}
    static const GUID VCDElement_ToneMapping_Intensity = { 0xbd2f432a, 0x02c1, 0x4f32,{ 0x9a, 0xeb, 0x68, 0x7c, 0xa1, 0x17, 0xd2, 0xe7 } };                 // {bd2f432a-02c1-4f32-9aeb-687ca117d2e7}
    static const GUID VCDElement_ToneMapping_GlobalBrightnessFactor = { 0xd1451fed, 0xc2d8, 0x42ce,{ 0x91, 0x0b, 0x2c, 0xb5, 0x66, 0x83, 0x6a, 0x77 } };    // {d1451fed-c2d8-42ce-910b-2cb566836a77} 

    static const GUID VCDElement_ToneMapping_a_factor = { 0x48d2d5f5, 0x0bed, 0x4d5a,{ 0xaa, 0x7c, 0xb8, 0xa8, 0xc4, 0x1c, 0x11, 0x79 } };
    static const GUID VCDElement_ToneMapping_b_factor = { 0x8a1a5755, 0xa562, 0x470b,{ 0x98, 0x42, 0x97, 0xb0, 0x87, 0x91, 0x14, 0x4c } };
    static const GUID VCDElement_ToneMapping_c_factor = { 0xe6d1fed4, 0xc28a, 0x431d,{ 0xb9, 0xec, 0x0f, 0xce, 0x35, 0x66, 0x23, 0x5a } };
    static const GUID VCDElement_ToneMapping_LumAvg = { 0x0634aea5, 0x2a19, 0x4292,{ 0x97, 0xbc, 0x7d, 0x22, 0x8a, 0xe4, 0xc6, 0x0f } };                    // {0634aea5-2a19-4292-97bc-7d228ae4c60f} 

    static const GUID VCDID_Startup = { 0x8e972004, 0x3b94, 0x4aa4, { 0xa8, 0x99, 0x65, 0xf6, 0xa1, 0x43, 0x27, 0x13 } };                                   // {8E972004-3B94-4AA4-A899-65F6A1432713}
    static const GUID VCDElement_Startup_CurrentState = { 0x8abb2078, 0x34ba, 0x4b7c, { 0xb0, 0x33, 0xd0, 0x35, 0xe1, 0x2d, 0x9d, 0xa6 } };                 // {8ABB2078-34BA-4B7C-B033-D035E12D9DA6}
    static const GUID VCDElement_Startup_FactoryDefault = { 0xd6800b86, 0xe461, 0x45b7, { 0x88, 0xf8, 0x21, 0x15, 0x11, 0x3f, 0xe7, 0x28 } };               // {D6800B86-E461-45B7-88F8-2115113FE728}
    static const GUID VCDElement_Startup_Status = { 0xcfa63b66, 0x55af, 0x4abc, { 0xb1, 0x4c, 0x6f, 0x46, 0x0a, 0xb3, 0xc4, 0xf7 } };                       // {CFA63B66-55AF-4ABC-B14C-6F460AB3C4F7}


    // newer:
    static const GUID VCDID_Shutter = { 0x79E1B504, 0x056D, 0x4533, { 0xB2, 0x84, 0x00, 0xFA, 0xBC, 0x60, 0x29, 0x0F } };

    static const GUID VCDID_ImageStabilization = { 0x1D375095, 0x2698, 0x4A1F, { 0x8F, 0x2F, 0xD8, 0x2E, 0x5B, 0xBC, 0x8E, 0x56 } };
    static const GUID VCDID_NoiseReduction = { 0x1D375096, 0x2698, 0x4A1F, { 0x8F, 0x2F, 0xD8, 0x2E, 0x5B, 0xBC, 0x8E, 0x56 } };
    static const GUID VCDID_FaceDetection = { 0xD01C48E6, 0xC168, 0x45F9, { 0x91, 0x91, 0xAE, 0x23, 0x4C, 0x9D, 0xB8, 0x68 } };

    static const GUID VCDID_ColorMatrix = { 0x7F7E24E3, 0x7162, 0x42EF, { 0xBF, 0x5D, 0x99, 0xA3, 0x59, 0xCB, 0x32, 0xF2 } };
    static const GUID VCDElement_ColorMatrix_RR = { 0x57480AA0, 0x2883, 0x4C7D, { 0xA0, 0x66, 0x35, 0x7D, 0x07, 0xC4, 0x52, 0x7D } };
    static const GUID VCDElement_ColorMatrix_RG = { 0x57480AA1, 0x2883, 0x4C7D, { 0xA0, 0x66, 0x35, 0x7D, 0x07, 0xC4, 0x52, 0x7D } };
    static const GUID VCDElement_ColorMatrix_RB = { 0x57480AA2, 0x2883, 0x4C7D, { 0xA0, 0x66, 0x35, 0x7D, 0x07, 0xC4, 0x52, 0x7D } };
    static const GUID VCDElement_ColorMatrix_GR = { 0x57480AA3, 0x2883, 0x4C7D, { 0xA0, 0x66, 0x35, 0x7D, 0x07, 0xC4, 0x52, 0x7D } };
    static const GUID VCDElement_ColorMatrix_GG = { 0x57480AA4, 0x2883, 0x4C7D, { 0xA0, 0x66, 0x35, 0x7D, 0x07, 0xC4, 0x52, 0x7D } };
    static const GUID VCDElement_ColorMatrix_GB = { 0x57480AA5, 0x2883, 0x4C7D, { 0xA0, 0x66, 0x35, 0x7D, 0x07, 0xC4, 0x52, 0x7D } };
    static const GUID VCDElement_ColorMatrix_BR = { 0x57480AA6, 0x2883, 0x4C7D, { 0xA0, 0x66, 0x35, 0x7D, 0x07, 0xC4, 0x52, 0x7D } };
    static const GUID VCDElement_ColorMatrix_BG = { 0x57480AA7, 0x2883, 0x4C7D, { 0xA0, 0x66, 0x35, 0x7D, 0x07, 0xC4, 0x52, 0x7D } };
    static const GUID VCDElement_ColorMatrix_BB = { 0x57480AA8, 0x2883, 0x4C7D, { 0xA0, 0x66, 0x35, 0x7D, 0x07, 0xC4, 0x52, 0x7D } };

    // VCDID_MultiFrameOutputMode
    static const GUID VCDID_MultiFrameOutputMode = { 0x49FC0326, 0x2042, 0x44A9, { 0x97, 0x12, 0xCB, 0x39, 0x0A, 0xEB, 0x2B, 0x50 } };
    static const GUID VCDElement_MultiFrameOutputMode_FrameCount = { 0x311CD3F1, 0x8DF8, 0x4566, { 0x95, 0xC9, 0xA6, 0xF3, 0xA4, 0x7C, 0x76, 0x78 } };
    static const GUID VCDElement_MultiFrameOutputMode_Exposure0 = { 0x519634B0, 0xE3E1, 0x4360, { 0xBA, 0x2D, 0x83, 0x31, 0xA9, 0x55, 0x75, 0x95 } };
    static const GUID VCDElement_MultiFrameOutputMode_Exposure1 = { 0x126322AB, 0x7152, 0x42AB, { 0x91, 0x6A, 0x28, 0xB2, 0xAB, 0x07, 0xF1, 0x37 } };
    static const GUID VCDElement_MultiFrameOutputMode_Exposure2 = { 0x1FBC5CCA, 0x0041, 0x4B58, { 0xB6, 0x79, 0x04, 0x09, 0x92, 0x91, 0x70, 0xFA } };
    static const GUID VCDElement_MultiFrameOutputMode_Exposure3 = { 0x17BAA678, 0xE158, 0x486B, { 0x9A, 0x4D, 0x1C, 0xC1, 0xDD, 0x8B, 0xF9, 0x50 } };
    static const GUID VCDElement_MultiFrameOutputMode_CustomizeGainValues = { 0xC16EDC91, 0xF590, 0x48AC, { 0x9D, 0x8C, 0x11, 0x61, 0x96, 0xDF, 0x33, 0x01 } };
    static const GUID VCDElement_MultiFrameOutputMode_Gain0 = { 0x6DD130C3, 0x2195, 0x4176, { 0x93, 0x09, 0xB7, 0x59, 0x5F, 0x60, 0xF2, 0xA9 } };
    static const GUID VCDElement_MultiFrameOutputMode_Gain1 = { 0x4E6E7BA9, 0xD378, 0x4790, { 0x93, 0x74, 0x9D, 0x38, 0xDC, 0x60, 0x13, 0xDB } };
    static const GUID VCDElement_MultiFrameOutputMode_Gain2 = { 0xC201436E, 0x7A99, 0x451D, { 0xAE, 0xF5, 0x79, 0x5F, 0x27, 0xF9, 0xAE, 0x8A } };
    static const GUID VCDElement_MultiFrameOutputMode_Gain3 = { 0xC2DA90D4, 0x3711, 0x40E2, { 0xBE, 0x21, 0xE6, 0x73, 0xD2, 0x6F, 0x44, 0xB4 } };

    static const GUID VCDID_AutoFunctionsROI = { 0x124922E5, 0x81C7, 0x4587, { 0x86, 0x7D, 0x7B, 0xA1, 0x6A, 0xF7, 0x90, 0x79 } };
    static const GUID VCDElement_AutoFunctionsROI_Preset = { 0x93D840ED, 0xB7B8, 0x45FE, { 0x91, 0xE2, 0x18, 0xE6, 0x8C, 0x41, 0xAF, 0xC3 } };

    // Currently unused
    static const GUID VCDID_MultiSlope = { 0x630B1F3E, 0x4A0A, 0x4963, { 0x89, 0xB1, 0x86, 0xBA, 0x8F, 0xDA, 0x29, 0x90 } };
    static const GUID VCDElement_MultiSlope_SlopeValue0 = { 0x630B1F3E, 0x4A0A, 0x4963, { 0x89, 0xB1, 0x86, 0xBA, 0x8F, 0xDA, 0x30, 0x90 } };
    static const GUID VCDElement_MultiSlope_ResetValue0 = { 0x630B1F3E, 0x4A0A, 0x4963, { 0x89, 0xB1, 0x86, 0xBA, 0x8F, 0xDA, 0x30, 0x91 } };
    static const GUID VCDElement_MultiSlope_SlopeValue1 = { 0x630B1F3E, 0x4A0A, 0x4963, { 0x89, 0xB1, 0x86, 0xBA, 0x8F, 0xDA, 0x31, 0x90 } };
    static const GUID VCDElement_MultiSlope_ResetValue1 = { 0x630B1F3E, 0x4A0A, 0x4963, { 0x89, 0xB1, 0x86, 0xBA, 0x8F, 0xDA, 0x31, 0x91 } };
    static const GUID VCDElement_MultiSlope_SlopeValue2 = { 0x630B1F3E, 0x4A0A, 0x4963, { 0x89, 0xB1, 0x86, 0xBA, 0x8F, 0xDA, 0x32, 0x90 } };
    static const GUID VCDElement_MultiSlope_ResetValue2 = { 0x630B1F3E, 0x4A0A, 0x4963, { 0x89, 0xB1, 0x86, 0xBA, 0x8F, 0xDA, 0x32, 0x91 } };
    static const GUID VCDElement_MultiSlope_SlopeValue3 = { 0x630B1F3E, 0x4A0A, 0x4963, { 0x89, 0xB1, 0x86, 0xBA, 0x8F, 0xDA, 0x33, 0x90 } };
    static const GUID VCDElement_MultiSlope_ResetValue3 = { 0x630B1F3E, 0x4A0A, 0x4963, { 0x89, 0xB1, 0x86, 0xBA, 0x8F, 0xDA, 0x33, 0x91 } };
    static const GUID VCDElement_MultiSlope_SlopeValue4 = { 0x630B1F3E, 0x4A0A, 0x4963, { 0x89, 0xB1, 0x86, 0xBA, 0x8F, 0xDA, 0x34, 0x90 } };
    static const GUID VCDElement_MultiSlope_ResetValue4 = { 0x630B1F3E, 0x4A0A, 0x4963, { 0x89, 0xB1, 0x86, 0xBA, 0x8F, 0xDA, 0x34, 0x91 } };
    static const GUID VCDElement_MultiSlope_SlopeValue5 = { 0x630B1F3E, 0x4A0A, 0x4963, { 0x89, 0xB1, 0x86, 0xBA, 0x8F, 0xDA, 0x35, 0x90 } };
    static const GUID VCDElement_MultiSlope_ResetValue5 = { 0x630B1F3E, 0x4A0A, 0x4963, { 0x89, 0xB1, 0x86, 0xBA, 0x8F, 0xDA, 0x35, 0x91 } };
    static const GUID VCDElement_MultiSlope_SlopeValue6 = { 0x630B1F3E, 0x4A0A, 0x4963, { 0x89, 0xB1, 0x86, 0xBA, 0x8F, 0xDA, 0x36, 0x90 } };
    static const GUID VCDElement_MultiSlope_ResetValue6 = { 0x630B1F3E, 0x4A0A, 0x4963, { 0x89, 0xB1, 0x86, 0xBA, 0x8F, 0xDA, 0x36, 0x91 } };
    static const GUID VCDElement_MultiSlope_SlopeValue7 = { 0x630B1F3E, 0x4A0A, 0x4963, { 0x89, 0xB1, 0x86, 0xBA, 0x8F, 0xDA, 0x37, 0x90 } };
    static const GUID VCDElement_MultiSlope_ResetValue7 = { 0x630B1F3E, 0x4A0A, 0x4963, { 0x89, 0xB1, 0x86, 0xBA, 0x8F, 0xDA, 0x37, 0x91 } };
}

#endif // VCDPROPERTYID_H_INC_