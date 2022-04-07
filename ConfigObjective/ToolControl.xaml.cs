﻿using Global;
using GLobal.Mode.Config;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Lambda;
using System.Windows.Input;

namespace ConfigObjective
{

    public partial class ToolControl : UserControl
    {
        public ToolControl()
        {
            InitializeComponent();
        }

        private readonly System.Windows.Threading.DispatcherTimer _timer = new() { Interval = TimeSpan.FromSeconds(0.2) };
        List<ObjectiveSetting> ObjectiveSettingList = new List<ObjectiveSetting>()
        {
            new ObjectiveSetting (){ID =0, Name ="奥林巴斯",Magnitude="4X", NA=0.1,IsEnabled =false},
            new ObjectiveSetting (){ID =1, Name ="奥林巴斯",Magnitude="10X", NA=0.25,IsChecked=true},
            new ObjectiveSetting (){ID =2, Name ="奥林巴斯",Magnitude="20X", NA=0.4,IsEnabled =false},
            new ObjectiveSetting (){ID =3, Name ="奥林巴斯",Magnitude="40X", NA=0.65,IsEnabled =false},
            new ObjectiveSetting (){ID =4, Name ="奥林巴斯",Magnitude="100X", NA=0.65,IsEnabled =false},
        };
        List<double> expose = new List<double> { 40000, 35714, 31250, 27778, 25000, 21739, 19608, 17241, 15385, 13514, 12048, 10753, 10000, 8403, 7463, 6623, 5882, 5208, 4630, 4000, 3636, 3226, 2865, 2545, 2252, 2000, 1773, 1575, 1397, 1239, 1099, 1000, 864, 767, 680, 604, 535, 500, 421, 374, 331, 294, 250, 231, 205, 182, 161, 143, 120, 113, 100, 89, 79, 70, 60, 55, 49, 43, 38, 34, 30, 27, 24, 21, 19, 17, 15, 13, 12, 10, 9, 8, 7, 6, 5, 4 };
        List<double> expose1 = new List<double> { 0.287, 0.323, 0.364, 0.410, 0.463, 0.500, 0.588, 0.663, 0.747, 0.842, 1, 1.071, 1.207, 1.360, 1.534, 1.729, 2.000, 2.197, 2.477, 2.792, 3.148, 3.548, 4.000 };

        private void UserControl_Initialized(object sender, System.EventArgs e)
        {
            Border5.DataContext = WindowStatus.GetInstance().mulDimensional;

            WindowStatus windowStatus = WindowStatus.GetInstance();
            Window MainWindow = Window.GetWindow(this);
            for (int i = 0; i < expose.Count; i++)
                expose[i] = 1 / expose[i];
            expose.AddRange(expose1);
            Button301.Click += delegate
            {
                LambdaControl.Trigger("IMAGE_MODE_RESET", this, new Dictionary<string, object>() { });
            };
            Button302.Click += delegate
            {
                LambdaControl.Trigger("IMAGE_MODE_CLOSE", this, new Dictionary<string, object>() { });
            };

            List<RadioButton> ViewModeradioButtons = new List<RadioButton>();
            ViewModeradioButtons.Add(Button31);
            ViewModeradioButtons.Add(Button32);
            ViewModeradioButtons.Add(Button33);
            ViewModeradioButtons.Add(Button34);
            ViewModeradioButtons.Add(Button35);
            ViewModeradioButtons.Add(Button36);
            foreach (var item in ViewModeradioButtons)
            {
                item.Click += delegate
                {
                    string s = item.Tag.ToString();
                    if (s != null)
                    {
                        Dictionary<string, object> data = new() { { "mode", int.Parse(s) } };
                        LambdaControl.Trigger("IMAGING_MODE_SETTING", item, data);
                    }
                };
            }

            Button201.Click += delegate
            {
                Dictionary<string, object> data = new() { };
                LambdaControl.Trigger("CAMERA_SETTING_WHITE_BALANCE", this, data);
            };
            Button211.Click += delegate
            {
                Dictionary<string, object> data = new() { };
                LambdaControl.Trigger("CAMERA_SETTING_WHITE_BALANCE",this, data);
            };

            //增益
            SliderAbbreviation1(Slider211, "CAMERA_SETTING_GAIN", "gain");

            Slider212.ValueChanged += delegate (object sender, RoutedPropertyChangedEventArgs<double> e)
            {
                if (!WindowStatus.GetInstance().ACQUIRE)
                {
                    if (Slider212.Value < expose.Count)
                    {
                        Dictionary<string, object> data = new() { { "exposure", expose[(int)Slider212.Value] } };
                        LambdaControl.Trigger("CAMERA_SETTING_EXPOSURE",this, data);
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
            };

            //锐度
            SliderAbbreviation(Slider213, "CAMERA_SETTING_SHARPNESS", "sharpness");
            //伽马
            SliderAbbreviation1(Slider214, "CAMERA_SETTING_GAMMA", "gamma");
            //降噪
            SliderAbbreviation(Slider215, "CAMERA_SETTING_DENOISE", "denoise");



            #region slider
            //照明孔径
            SliderAbbreviation(Slider311, "BRIGHT_FIELD_DIAMETER", "diameter");

            Slider312.ValueChanged += delegate (object sender, RoutedPropertyChangedEventArgs<double> e)
            {
                if (!WindowStatus.GetInstance().ACQUIRE)
                {
                    int bright = (int)Slider312.Value;

                    string hexString = ColorPciker1.SelectColor.ToString();
                    hexString = hexString.Substring(1, hexString.Length - 1);
                    byte[] returnBytes = new byte[hexString.Length / 2];
                    for (int i = 0; i < returnBytes.Length; i++)
                        returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2).Trim(), 16);

                    int a1 = (returnBytes[1] >> 4) * bright / 15;
                    int a2 = (returnBytes[2] >> 4) * bright / 15;
                    int a3 = (returnBytes[3] >> 4) * bright / 15;

                    int result = a1 * 256 + a2 * 16 + a3;
                    //int r = result / 256;
                    //int g = (result % 256)/16;
                    //int b = (result % 256)%16;
                    Dictionary<string, object> data = new() { { "brightness", result } };
                    LambdaControl.Trigger("BRIGHT_FIELD_BRIGHTNESS",this, data);
                }
                else
                {
                    if (sliderfirst)
                    {
                        var result = MessageBox.Show("是否修改当前多维采集设置", "显微镜", MessageBoxButton.YesNo);
                        if (result == MessageBoxResult.No)
                        {
                            sliderfirst = false;
                            Slider312.Value = e.OldValue;
                        }
                    }
                    else
                    {
                        sliderfirst = true;
                    }
                }
            };

            //照明亮度
            //SliderAbbreviation("Slider312", "BRIGHT_FIELD_BRIGHTNESS", "brightness");


            ColorPciker1.BrushValueChanged += delegate
            {
                int bright = (int)Slider312.Value;
                string hexString = ColorPciker1.SelectColor.ToString();
                hexString = hexString.Substring(1, hexString.Length - 1);
                byte[] returnBytes = new byte[hexString.Length / 2];
                for (int i = 0; i < returnBytes.Length; i++)
                    returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2).Trim(), 16);

                int a1 = (returnBytes[1] >> 4) * bright / 15;
                int a2 = (returnBytes[2] >> 4) * bright / 15;
                int a3 = (returnBytes[3] >> 4) * bright / 15;

                int result = a1 * 256 + a2 * 16 + a3;

                Dictionary<string, object> data = new() { { "brightness", result } };
                LambdaControl.Trigger("BRIGHT_FIELD_BRIGHTNESS",this, data);
            };
            ColorPciker11.BrushValueChanged += delegate
            {
                string hexString = ColorPciker11.SelectColor.ToString();
                hexString = hexString.Substring(1, hexString.Length - 1);
                byte[] returnBytes = new byte[hexString.Length / 2];
                for (int i = 0; i < returnBytes.Length; i++)
                    returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2).Trim(), 16);

                int a1 = returnBytes[1] >> 4;
                int a2 = returnBytes[2] >> 4;
                int a3 = returnBytes[3] >> 4;

                int result = a1 * 256 + a2 * 16 + a3;

                Dictionary<string, object> data = new() { { "brightness", result } };
                LambdaControl.Trigger("BRIGHT_FIELD_BRIGHTNESS", this,data);
            };

            foreach (var item in ObjectiveSettingList)
            {
                RadioButton radioButton = new RadioButton
                {
                    Style = FindResource("ToggleButtonStyle1") as Style,
                    Width = 55,
                    Margin = new Thickness(5, 0, 5, 0),
                    Content = item.Magnitude,
                    IsChecked = item.IsChecked,
                    IsEnabled = item.IsEnabled
                };
                radioButton.Click += delegate
                {
                    Dictionary<string, object> values = new Dictionary<string, object>()
                    {
                        {"magnitude",item.ID },
                        {"na",(double)(item.NA) },
                    };
                    LambdaControl.Trigger("OBJECTIVE_LENS_SETTING",this,values);
                };
                ObjectiveSettingStackPanel.Children.Add(radioButton);
            }
            if (ObjectiveSettingList.Count < 2)
            {
                ToggleButton1.IsChecked = false;
            }



            //照明内径
            SliderAbbreviation(Slider321, "DARK_FIELD_INNER", "inner");
            //照明外径
            SliderAbbreviation(Slider322, "DARK_FIELD_OUTER", "outer");
            //照明亮度
            SliderAbbreviation(Slider323, "DARK_FIELD_BRIGHTNESS", "brightness");
            //伽马
            SliderAbbreviation1(Slider324, "DARK_FIELD_GAMMA", "gamma");
            //自动模式
            ToggleButtonAbbreviation(Button321, "DARK_FIELD_AUTO", "auto");


            //照明内径
            SliderAbbreviation(Slider331, "RHEIN_BERG_INNER", "inner");
            //照明外径
            SliderAbbreviation(Slider332, "RHEIN_BERG_OUTER", "outer");
            //明场照明亮度
            SliderAbbreviation(Slider333, "RHEIN_BERG_BRIGHTNESS_BF", "brightness");
            //暗场照明亮度
            SliderAbbreviation(Slider334, "RHEIN_BERG_BRIGHTNESS_DF", "brightness");
            //伽马
            SliderAbbreviation(Slider335, "RHEIN_BERG_GAMMA", "gamma");

            //差分

            //对比度
            SliderAbbreviation1(Slider341, "RELIEF_CONTRAST_CONTRAST", "contrast");
            //增益
            SliderAbbreviation1(Slider342, "RELIEF_CONTRAST_GAIN", "gain");
            //明场权重
            SliderAbbreviation1(Slider343, "RELIEF_CONTRAST_BF_WEIGHT", "weight");
            //测试附加
            //外径
            SliderAbbreviation(Slider344, "RELIEF_CONTRAST_OUTER", "outer");
            //内径
            SliderAbbreviation(Slider345, "RELIEF_CONTRAST_INNER", "inner");
            //Gamma
            SliderAbbreviation1(Slider346, "RELIEF_CONTRAST_GAMMA", "gamma");
            //相衬权重
            SliderAbbreviation1(Slider347, "RELIEF_CONTRAST_DP_WEIGHT", "weight");

            //差分背景校正
            ToggleButtonAbbreviation(Button341, "RELIEF_CONTRAST_BG_COLLECTION", "collection");
            Button341.IsChecked = false;

            //相位

            //正则化参数
            SliderAbbreviation1(Slider351, "QUANTITATIVE_PHASE_REG", "regularization");

            //细节增强
            SliderAbbreviation(Slider352, "QUANTITATIVE_PHASE_DETAIL", "detail");
            //测试附加
            //Min
            SliderAbbreviation1(Slider353, "QUANTITATIVE_PHASE_MIN", "min");
            // Max
            SliderAbbreviation1(Slider354, "QUANTITATIVE_PHASE_MAX", "max");
            // Gamma
            SliderAbbreviation1(Slider355, "QUANTITATIVE_PHASE_GAMMA", "gamma");


            //相位背景校正
            ToggleButtonAbbreviation(Button351, "QUANTITATIVE_PHASE_BG_COLLECTION", "collection");
            Button351.IsChecked = false;

            //相差

            //相差滤波
            SliderAbbreviation1(Slider361, "PHASE_CONTRAST_FILTER", "filter");
            //对比度
            SliderAbbreviation1(Slider362, "PHASE_CONTRAST_CONTRAST", "contrast");
            //增益
            SliderAbbreviation1(Slider363, "PHASE_CONTRAST_GAIN", "gain");
            //明场权重
            SliderAbbreviation1(Slider364, "PHASE_CONTRAST_BF_WEIGHT", "weight");
            //测试附加
            //伽马
            SliderAbbreviation1(Slider365, "PHASE_CONTRAST_GAMMA", "gamma");
            //相差权重
            SliderAbbreviation1(Slider366, "PHASE_CONTRAST_PC_WEIGHT", "weight");

            //相差背景校正
            ToggleButtonAbbreviation(Button361, "PHASE_CONTRAST_BG_COLLECTION", "collection");
            Button361.IsChecked = false;

            #endregion



            Button401.Click += delegate
            {
                Dictionary<string, object> data = new() { };
                LambdaControl.Trigger("STAGE_SETTING_RESET", this,data);
            };

            int XYStep = 1000;
            int ZStep = 1000;

            ButtonFront.Click += delegate
            {
                Dictionary<string, object> data = new() { { "step", XYStep }, { "direction", 2 } };
                LambdaControl.Trigger("STAGE_MOVE_FRONT", ButtonFront, data);
            };

            ButtonRear.Click += delegate
            {
                Dictionary<string, object> data = new() { { "step", XYStep }, { "direction", 3 } };
                LambdaControl.Trigger("STAGE_MOVE_REAR", ButtonRear, data);
            };
            ButtonRight.Click += delegate
            {
                Dictionary<string, object> data = new() { { "step", XYStep }, { "direction", 1 } };
                LambdaControl.Trigger("STAGE_MOVE_RIGHT", ButtonRight, data);
            };

            ButtonLeft.Click += delegate
            {
                Dictionary<string, object> data = new() { { "step", XYStep }, { "direction", 0 } };
                LambdaControl.Trigger("STAGE_MOVE_LEFT", ButtonLeft, data);
            };

            ButtonUp.Click += delegate
            {
                Dictionary<string, object> data = new() { { "step", ZStep }, { "direction", 4 } };
                LambdaControl.Trigger("STAGE_MOVE_UP", ButtonUp, data);
            };

            ButtonDown.Click += delegate
            {
                Dictionary<string, object> data = new() { { "step", ZStep }, { "direction", 5 } };
                LambdaControl.Trigger("STAGE_MOVE_DOWN", ButtonDown, data);
            };

            ButtonRe.Click += delegate
            {
                Dictionary<string, object> data = new() { { "step", 0 }, { "direction", 6 } };
                LambdaControl.Trigger("STAGE_MOVE_CENTRE", ButtonRe, data);
            };
            ButtonAutoFocus.Click += delegate
            {
                if ((bool)ToggleButtonZF.IsChecked)
                {
                    Dictionary<string, object> data = new() { { "mode", 0 } };
                    LambdaControl.Trigger("STAGE_AUTO_FOCUS", this, data);
                }
                else
                {
                    Dictionary<string, object> data = new() { { "mode", 1 } };
                    LambdaControl.Trigger("STAGE_AUTO_FOCUS", this, data);
                }

            };

            ToggleButtonXYF.Checked += delegate
            {
                XYStep = 200;
            };
            ToggleButtonXYF.Unchecked += delegate
            {
                XYStep = 1000;
            };
            ToggleButtonZF.Checked += delegate
            {
                ZStep = 200;
            };
            ToggleButtonZF.Unchecked += delegate
            {
                ZStep = 1000;
            };


            ToggleButton503.Checked += delegate
            {
                Update.UpdateMulDimensional(WindowStatus.GetInstance().mulDimensional);
            };
            ToggleButton503.Unchecked += delegate
            {
                ToggleButton505.IsChecked = false;
            };

            ToggleButton505.Checked += delegate
            {
                ToggleButton503.IsChecked = true;
            };
            ToggleButton505.Unchecked += delegate
            {

            };

            Canvas1.MouseMove += MainCanvas_MouseMove;
            Canvas1.MouseLeftButtonUp += MainCanvas_MouseLeftButtonUp;
            Canvas1.MouseLeftButtonDown += MainCanvas_MouseLeftButtonDown;
            Canvas1.PreviewMouseRightButtonUp += Canvas1_PreviewMouseRightButtonUp;
            Canvas1.PreviewMouseRightButtonDown += Canvas1_PreviewMouseRightButtonDown;
            Canvas1.PreviewMouseDown += Canvas1_PreviewMouseDown;

        }





        bool sliderfirst = true;
        /// <summary>
        /// SliderAbbreviation(int)
        /// </summary>
        private Slider SliderAbbreviation(Slider slider, string TriggerName, string TriggerParameter)
        {
            slider.ValueChanged += delegate (object sender, RoutedPropertyChangedEventArgs<double> e)
            {

                if (!WindowStatus.GetInstance().ACQUIRE)
                {
                    Dictionary<string, object> data = new() { { TriggerParameter, (int)slider.Value } };
                    LambdaControl.Trigger(TriggerName, slider,data);
                }
                else
                {
                    if (sliderfirst)
                    {
                        var result = MessageBox.Show("是否修改当前多维采集设置", "显微镜", MessageBoxButton.YesNo);
                        if (result == MessageBoxResult.No)
                        {
                            sliderfirst = false;
                            slider.Value = e.OldValue;
                        }
                    }
                    else
                    {
                        sliderfirst = true;
                    }
                }

            };
            return slider;
        }

        /// <summary>
        /// SliderAbbreviation(double)
        /// </summary>
        private Slider SliderAbbreviation1(Slider slider, string TriggerName, string TriggerParameter)
        {
            slider.ValueChanged += delegate (object sender, RoutedPropertyChangedEventArgs<double> e)
            {
                if (!WindowStatus.GetInstance().ACQUIRE)
                {
                    Dictionary<string, object> data = new() { { TriggerParameter, (double)slider.Value } };
                    LambdaControl.Trigger(TriggerName, slider, data);
                }
                else
                {
                    if (sliderfirst)
                    {
                        var result = MessageBox.Show("是否修改当前多维采集设置", "显微镜", MessageBoxButton.YesNo);
                        if (result == MessageBoxResult.No)
                        {
                            sliderfirst = false;
                            slider.Value = e.OldValue;
                        }
                    }
                    else
                    {
                        sliderfirst = true;
                    }
                }

            };
            return slider;
        }

        /// <summary>
        /// ToggleButton缩写优化
        /// </summary>
        /// <param name="FindName"></param>
        /// <param name="TriggerName"></param>
        /// <param name="TriggerParameter"></param>
        private ToggleButton ToggleButtonAbbreviation(ToggleButton toggleButton, string TriggerName, string TriggerParameter)
        {
            toggleButton.Checked += delegate
            {
                Dictionary<string, object> data = new() { { TriggerParameter, toggleButton.IsChecked } };
                LambdaControl.Trigger(TriggerName, toggleButton, data);
            };
            toggleButton.Unchecked += delegate
            {
                Dictionary<string, object> data = new() { { TriggerParameter, toggleButton.IsChecked } };
                LambdaControl.Trigger(TriggerName, toggleButton, data);
            };
            return toggleButton;
        }


    }
}