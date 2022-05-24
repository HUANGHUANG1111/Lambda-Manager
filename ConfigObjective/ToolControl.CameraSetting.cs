﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Global.Hardware;
using Lambda;

namespace ConfigObjective
{

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct Cam
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string ip;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string login;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string pass;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string name;
        public double a;
    }


    public partial class ToolControl
    {
        public void CameraSetting_Initialize()
        {
            if (Border2.DataContext is Global.Mode.Config.Camera cameraSetting)
            {
                LambdaControl.Trigger("CAMERA_SETTING_GAMMA", this, new Dictionary<string, object>() { { "mode", cameraSetting.SelectViewMode }, { "gamma", cameraSetting.Gamma } });
            }


        }
        public void CameraSetting_Update()
        {

        }

        public void CameraMode_Changed()
        {
            if (Border2.DataContext is Global.Mode.Config.Camera cameraSetting)
            {
                LambdaControl.Trigger("CAMERA_SETTING_GAMMA", this, new Dictionary<string, object>() { { "mode", cameraSetting.SelectViewMode }, { "gamma", cameraSetting.Gamma } });
            }
        }

        private void Button201_Click(object sender, RoutedEventArgs e)
        {
            if (Border2.DataContext is Global.Mode.Config.Camera cameraSetting)
                LambdaControl.Trigger("CAMERA_SETTING_RESET", this, new Dictionary<string, object>() { { "mode", cameraSetting.SelectViewMode} });
        }

        private void Button211_Click(object sender, RoutedEventArgs e)
        {
            if (Border2.DataContext is Global.Mode.Config.Camera cameraSetting)
                LambdaControl.Trigger("CAMERA_SETTING_WHITE_BALANCE", this, new Dictionary<string, object> { { "mode", cameraSetting.SelectViewMode } });
        }

        private void ToggleButton210_Click(object sender, RoutedEventArgs e)
        {
            if (Border2.DataContext is Global.Mode.Config.Camera cameraSetting)
            {
                LambdaControl.Trigger("CAMERA_SETTING_EXPOSURE_AUTO", this, new Dictionary<string, object>() { { "mode", cameraSetting.SelectViewMode }, { "auto", ToggleButton210.IsChecked } });
            }
        }

        [DllImport(@"lib\ISCamera.dll", EntryPoint = "CameraSettingExposure")]
        public static extern void CameraSettingExposure(double a);

        [DllImport(@"lib\ISCamera.dll", EntryPoint = "CameraSettingExposureIni", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int CameraSettingExposureIni();

        [DllImport(@"lib\ISCamera.dll", EntryPoint = "CameraSettingCam", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int CameraSettingCam(ref Cam cam);
        private void ToggleButton211_Click(object sender, RoutedEventArgs e)
        {
            //double a = 22222;
            //CameraSettingExposure(a);
            //Type type = typeof(IntPtr);
            //List<string> retList = new List<string>();
            //for (int i = 0; i < 10; i++)
            //{
            //    //获取指针指向的地址
            //    IntPtr address = (IntPtr)Marshal.PtrToStructure(result, type);
            //    //获取此地址上的字符串
            //    string str = Marshal.PtrToStringAnsi(address);
            //    //结果列表中添加此字符串
            //    retList.Add(str);
            //    //将此result向后移8位，得到指向下一个字符串的指针（32位系统后移4位）
            //    result = (IntPtr)((Int64)result + 8);
            //}

            //byte[] destination = new byte[100];
            //Marshal.Copy(result, destination, 0, 100);
            //MessageBox.Show(System.Text.Encoding.ASCII.GetString(destination));


             Cam cam = new Cam
            {
                ip = "192.168.0.232",
                login = "admin",
                pass = "admin",
                name = "kekekeke",
                a=1
            };
            CameraSettingCam(ref cam);


            if (Border2.DataContext is Global.Mode.Config.Camera cameraSetting)
            {
                LambdaControl.Trigger("CAMERA_SETTING_GAIN_AUTO", this, new Dictionary<string, object>() { { "mode", cameraSetting.SelectViewMode }, { "auto", ToggleButton211.IsChecked } });
            }
        }

        //List<string> data1 = new() { "RGB64 (256x4)", "RGB64 (320x240)", "RGB64 (320x480)", "RGB64 (352x240)", "RGB64 (352x288)", "RGB64 (384x288)", "RGB64 (640x240)", "RGB64 (640x288)", "RGB64 (640x480)", "RGB64 (704x576)", "RGB64 (720x240)", "RGB64 (720x288)", "RGB64 (720x480)", "RGB64 (720x576)", "RGB64 (768x576)", "RGB64 (1024x768)", "RGB64 (1280x960)", "RGB64 (1280x1024)", "RGB64 (1600x1200)", "RGB64 (1920x1080)", "RGB64 (2048x1536)", "RGB64 (2048x2048)", "RGB64 (2448x2048)", "Y16 (256x4)", "Y16 (320x240)", "Y16 (320x480)", "Y16 (352x240)", "Y16 (352x288)", "Y16 (384x288)", "Y16 (640x240)", "Y16 (640x288)", "Y16 (640x480)", "Y16 (704x576)", "Y16 (720x240)", "Y16 (720x288)", "Y16 (720x480)", "Y16 (720x576)", "Y16 (768x576)", "Y16 (1024x768)", "Y16 (1280x960)", "Y16 (1280x1024)", "Y16 (1600x1200)", "Y16 (1920x1080)", "Y16 (2048x1536)", "Y16 (2048x2048)", "Y16 (2448x2048)", "Y411 (256x4)", "Y411 (320x240)", "Y411 (320x480)", "Y411 (352x240)", "Y411 (352x288)", "Y411 (384x288)", "Y411 (640x240)", "Y411 (640x288)", "Y411 (640x480)", "Y411 (704x576)", "Y411 (720x240)", "Y411 (720x288)", "Y411 (720x480)", "Y411 (720x576)", "Y411 (768x576)", "Y411 (1024x768)", "Y411 (1280x960)", "Y411 (1280x1024)", "Y411 (1600x1200)", "Y411 (1920x1080)", "Y411 (2048x1536)", "Y411 (2048x2048)", "Y411 (2448x2048)", "Y800 (256x4)", "Y800 (320x240)", "Y800 (320x480)", "Y800 (352x240)", "Y800 (352x288)", "Y800 (384x288)", "Y800 (640x240)", "Y800 (640x288)", "Y800 (640x480)", "Y800 (704x576)", "Y800 (720x240)", "Y800 (720x288)", "Y800 (720x480)", "Y800 (720x576)", "Y800 (768x576)", "Y800 (1024x768)", "Y800 (1280x960)", "Y800 (1280x1024)", "Y800 (1600x1200)", "Y800 (1920x1080)", "Y800 (2048x1536)", "Y800 (2048x2048)", "Y800 (2448x2048)", "YUY2 (256x4)", "YUY2 (320x240)", "YUY2 (320x480)", "YUY2 (352x240)", "YUY2 (352x288)", "YUY2 (384x288)", "YUY2 (640x240)", "YUY2 (640x288)", "YUY2 (640x480)", "YUY2 (704x576)", "YUY2 (720x240)", "YUY2 (720x288)", "YUY2 (720x480)", "YUY2 (720x576)", "YUY2 (768x576)", "YUY2 (1024x768)", "YUY2 (1280x960)", "YUY2 (1280x1024)", "YUY2 (1600x1200)", "YUY2 (1920x1080)", "YUY2 (2048x1536)", "YUY2 (2048x2048)", "YUY2 (2448x2048)", "RGB24 (256x4)", "RGB24 (320x240)", "RGB24 (320x480)", "RGB24 (352x240)", "RGB24 (352x288)", "RGB24 (384x288)", "RGB24 (640x240)", "RGB24 (640x288)", "RGB24 (640x480)", "RGB24 (704x576)", "RGB24 (720x240)", "RGB24 (720x288)", "RGB24 (720x480)", "RGB24 (720x576)", "RGB24 (768x576)", "RGB24 (1024x768)", "RGB24 (1280x960)", "RGB24 (1280x1024)", "RGB24 (1600x1200)", "RGB24 (1920x1080)", "RGB24 (2048x1536)", "RGB24 (2048x2048)", "RGB24 (2448x2048)", "RGB32 (256x4)", "RGB32 (320x240)", "RGB32 (320x480)", "RGB32 (352x240)", "RGB32 (352x288)", "RGB32 (384x288)", "RGB32 (640x240)", "RGB32 (640x288)", "RGB32 (640x480)", "RGB32 (704x576)", "RGB32 (720x240)", "RGB32 (720x288)", "RGB32 (720x480)", "RGB32 (720x576)", "RGB32 (768x576)", "RGB32 (1024x768)", "RGB32 (1280x960)", "RGB32 (1280x1024)", "RGB32 (1600x1200)", "RGB32 (1920x1080)", "RGB32 (2048x1536)", "RGB32 (2048x2048)", "RGB32 (2448x2048)" };


        private void UpDownControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpDownControl upDownButton1 = sender as UpDownControl;
            upDownButton1.SetList(WindowData.deviceInformation.CameraExposeShow);

        }

        private void Slider212_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = sender as Slider;
            if (UpDownControl1 != null)
            {
                UpDownControl1.SelectedIndex = (int)slider.Value;
                ToggleButton210.IsChecked = false;
            }

            if (!WindowData.ACQUIRE)
            {
                if (Slider212.Value < WindowData.deviceInformation.CameraExpose.Count)
                {
                    if (Border2.DataContext is Global.Mode.Config.Camera cameraSetting)
                    {
                        Dictionary<string, object> data = new() { { "mode", cameraSetting.SelectViewMode }, { "exposure", WindowData.deviceInformation.CameraExpose[(int)Slider212.Value] } };
                        LambdaControl.Trigger("CAMERA_SETTING_EXPOSURE", this, data);
                    }

                }
            }
            else
            {
                if (sliderfirst)
                {
                    var result = MessageBox.Show("是否修改当前多维采集设置", "显微镜", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.No)
                    {
                        sliderfirst = false;
                        Slider212.Value = e.OldValue;
                    }
                }
                else
                {
                    sliderfirst = true;
                }
            }
        }

        private void UpDownControl1_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Slider212.Value = UpDownControl1.SelectedIndex;
        }

        List<string> data1 = new() { "RGB32 (640x480)", "RGB32 (1280x960)", "RGB64 (2448x2048)" };

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Border2.DataContext is Global.Mode.Config.Camera cameraSetting)
            {
                LambdaControl.Trigger("CAMERA_SETTING_VIDEO_FORMAT", this, new Dictionary<string, object>() { { "mode", cameraSetting.SelectViewMode }, { "format", ComboBox1.SelectedItem } });
            }
        }


        private void Slider211_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Border2.DataContext is Global.Mode.Config.Camera cameraSetting)
            {
                Slider slider = sender as Slider;
                Dictionary<string, object> data = new() { { "mode", cameraSetting.SelectViewMode }, { "gain", slider.Value } };
                SliderAbbreviation(slider, e, "CAMERA_SETTING_GAIN", data);
            }


        }

        private void Slider213_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Border2.DataContext is Global.Mode.Config.Camera cameraSetting)
            {
                Slider slider = sender as Slider;
                Dictionary<string, object> data = new() { { "mode", cameraSetting.SelectViewMode }, { "sharpness", (int)slider.Value } };
                SliderAbbreviation(slider, e, "CAMERA_SETTING_SHARPNESS", data);
            }
            

        }

        private void Slider214_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Border2.DataContext is Global.Mode.Config.Camera cameraSetting)
            {
                Slider slider = sender as Slider;
                Dictionary<string, object> data = new() { { "mode", cameraSetting.SelectViewMode }, { "gamma", slider.Value } };
                SliderAbbreviation(slider, e, "CAMERA_SETTING_GAMMA", data);
            }

        }

        private void Slider215_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Border2.DataContext is Global.Mode.Config.Camera cameraSetting)
            {
                Slider slider = sender as Slider;
                Dictionary<string, object> data = new() { { "mode", cameraSetting.SelectViewMode }, { "denoise", (int)slider.Value } };
                SliderAbbreviation(slider, e, "CAMERA_SETTING_DENOISE", data);
            }

        }


    }
}
