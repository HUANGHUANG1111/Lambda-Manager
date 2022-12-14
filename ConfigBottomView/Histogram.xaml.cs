using Lambda;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Ink;
using System.Windows.Resources;

namespace ConfigBottomView
{
    /// <summary>
    /// Histogram.xaml 的交互逻辑
    /// </summary>
    public partial class Histogram : UserControl
    {
        public Histogram()
        {
            InitializeComponent();
            drawingAttributes = new DrawingAttributes
            {
                Color = Colors.White,
                Width = 1,
                Height = 1,
                StylusTip = StylusTip.Rectangle,
                FitToCurve = false,
                IsHighlighter = true,
                IgnorePressure = true,
            };
           // MessageBox.Show("1111");
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            LambdaControl.RegisterImageView(HistogramImage).ToString();
        }
        /// <summary>
        /// R4 G2 B1
        /// </summary>
        private int RGBMode(bool m, bool n, bool k)
        {
            return (m ? 4 : 0) + (n ? 2 : 0) + (k ? 1 : 0);
        }

        bool auto = false; bool log = false;


        private void RGBGrid_Checked(object sender, RoutedEventArgs e)
        {
            int mode = RGBMode((bool)R.IsChecked, (bool)G.IsChecked, (bool)B.IsChecked);
            LambdaControl.Trigger("HISTOGRAM_MODE", this, new Dictionary<string, object> { { "mode", mode } });
            // MessageBox.Show(mode.ToString());
        }

        private void RGBGrid_UnChecked(object sender, RoutedEventArgs e)
        {
            int mode = RGBMode((bool)R.IsChecked, (bool)G.IsChecked, (bool)B.IsChecked);
            LambdaControl.Trigger("HISTOGRAM_MODE", this, new Dictionary<string, object> { { "mode", mode } });
            // MessageBox.Show(mode.ToString());
        }

        private void Auto_Click(object sender, RoutedEventArgs e)
        {
            if (!auto)
            {
                LambdaControl.Trigger("HISTOGRAM_AUTOMODE", this, new Dictionary<string, object> { { "autoMode", true } });
                auto = true;
                RangeSlider.SlidThumbVis = Visibility.Hidden;
                if (inkCanvas.Strokes.Contains(lStroke))
                    inkCanvas.Strokes.Remove(lStroke);
                if (inkCanvas.Strokes.Contains(hStroke))
                    inkCanvas.Strokes.Remove(hStroke);


            }
            else
            {
                LambdaControl.Trigger("HISTOGRAM_AUTOMODE", this, new Dictionary<string, object> { { "autoMode", false } });
                auto = false;
                RangeSlider.SlidThumbVis = Visibility.Visible;
               
               
            }


        }

        private void Log_Click(object sender, RoutedEventArgs e)

        {
            if (!log)
            {
                LambdaControl.Trigger("HISTOGRAM_LOGMODE", this, new Dictionary<string, object> { { "logMode", true } });
                log = true;
            }
            else
            {
                LambdaControl.Trigger("HISTOGRAM_LOGMODE", this, new Dictionary<string, object> { { "logMode", false } });
                log = false;
            }

        }

        public Stroke lStroke;
        public Stroke hStroke;


        private void RangeSlider_LowerValueChanged(object sender, RoutedEventArgs e)
        {

            if (!auto)
            {
                int min = (int)RangeSlider.LowerValue;
                int max = (int)RangeSlider.HigherValue;
                LambdaControl.Trigger("BRIGHTNESS_RANGE", this, new Dictionary<string, object>() { { "Min", min }, { "Max", max } });
             
            }

            double length = RangeSlider.LowerValue / 255 * HistogramImage.ActualWidth + 15;
            InkCanvas.SetLeft(leftCanvas, length);

        }

        private void RangeSlider_HigherValueChanged(object sender, RoutedEventArgs e)
        {
            if (!auto)
            {
                int min = (int)RangeSlider.LowerValue;
                int max = (int)RangeSlider.HigherValue;
                LambdaControl.Trigger("BRIGHTNESS_RANGE", this, new Dictionary<string, object>() { { "Min", min }, { "Max", max } });

                
            }
           
            double length = RangeSlider.HigherValue / 255 * HistogramImage.ActualWidth + 15;
            InkCanvas.SetLeft(rightCanvas, length);



        }


        private void DoubleUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double gamma = double.Parse(NumUpdown.Value.ToString("0.00"));
            LambdaControl.Trigger("HISTOGRAM_GAMMA", this, new Dictionary<string, object>() { { "Gamma", gamma }});
           // MessageBox.Show(gamma.ToString());

        }

        public DrawingAttributes drawingAttributes;
        public Stroke GenerateLineStroke(System.Windows.Point st, System.Windows.Point ed)
        {
            List<System.Windows.Point> pointList = new List<System.Windows.Point>();
            StylusPointCollection point;
            Stroke stroke;
            pointList = new List<System.Windows.Point>{
                new System.Windows.Point(st.X, st.Y),
                new System.Windows.Point(ed.X, ed.Y)
            };
            point = new StylusPointCollection(pointList);
            stroke = new Stroke(point)
            {
                DrawingAttributes = drawingAttributes.Clone()
            };
            return stroke;
        }
        List<Point> YpointsSt = new List<Point>();
        List<Point> YpointsEd = new List<Point>();
        List<Point> XPointsSt = new List<Point>();
        List<Point> XPointsEd = new List<Point>();
        private void YScale(double h, int k)
        {
            YpointsSt.Clear();
            YpointsEd.Clear();
            if (h <= 0)
                return;
            double step = h / k;
            double margin = 0;
            List<double> list = new List<double>();
            for (int i = 0; i < k + 1; i++)
            {
                double y = i * step + margin;
                list.Add(y);
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (i % 5 == 0)
                {
                    YpointsSt.Add(new Point(13, list[i] + 1));
                }
                else
                {
                    YpointsSt.Add(new Point(17, list[i] + 1));
                }

            }
            for (int i = 0; i < list.Count; i++)
            {
                YpointsEd.Add(new Point(20, list[i] + 1));
            }
        }

        private void XScale(double w, double h, int m)
        {
            XPointsSt.Clear();
            XPointsEd.Clear();
            if (w <= 0)
                return;
            double step = w / m;
            double margin = 20;
            List<double> list = new List<double>();
            for (int i = 0; i < m + 1; i++)
            {
                double x = i * step + margin;
                list.Add(x);
            }

            for (int i = 0; i < list.Count; i++)
            {

                XPointsSt.Add(new Point(list[i] + 1, h + 4));
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (i % 5 == 0)
                {
                    XPointsEd.Add(new Point(list[i] + 1, h + 11));
                }
                else
                {
                    XPointsEd.Add(new Point(list[i] + 1, h + 7));
                }
            }
        }

        private void drawYAxis(double height, int k)
        {
            if (height <=0)
                return;
           // lstEditingMode.SelectedIndex = 0;
            List<System.Windows.Point> pointList;
            StylusPointCollection point;
            Stroke stroke;
            StrokeCollection strokes = new StrokeCollection();
            YScale(height, k);

            for (int i = 0; i < k + 1; i++)
            {
                stroke = GenerateLineStroke(YpointsSt[i], YpointsEd[i]);
                inkCanvas.Strokes.Add(stroke);
            }

        }



        private void drawXAxis(double width, double height, int m)
        {
            if (height <= 0)
                return;
            List<System.Windows.Point> pointList;
            StylusPointCollection point;
            Stroke stroke;
            StrokeCollection strokes = new StrokeCollection();
            XScale(width, height, m);

            for (int i = 0; i < m + 1; i++)
            {
                stroke = GenerateLineStroke(XPointsSt[i], XPointsEd[i]); 
                inkCanvas.Strokes.Add(stroke);
            }

        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            drawYAxis(HistogramImage.ActualHeight, 10);
            drawXAxis(HistogramImage.ActualWidth, HistogramImage.ActualHeight, 20);
            
        }

        private void HistogramImage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            inkCanvas.Strokes.Clear();   
            drawYAxis(HistogramImage.ActualHeight, 10);
            drawXAxis(HistogramImage.ActualWidth, HistogramImage.ActualHeight, 20);
            double length = RangeSlider.LowerValue / 255 * HistogramImage.ActualWidth + 15;
            InkCanvas.SetLeft(leftCanvas, length);
            double length1 = RangeSlider.HigherValue / 255 * HistogramImage.ActualWidth + 15;
            InkCanvas.SetLeft(rightCanvas, length1);
        }

       




        private Point moveOri;
        private bool isMOuseDown = false;
        private void leftCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            moveOri = e.GetPosition(inkCanvas);
            isMOuseDown = true;
            InkCanvas.SetLeft(leftCanvas, moveOri.X);
            leftCanvas.CaptureMouse();
            leftEllipse.Visibility = Visibility.Visible;
            Point point = e.GetPosition(leftCanvas);
          //  Canvas.SetLeft(leftEllipse, point.X-4);
            Canvas.SetTop(leftEllipse,point.Y-4);

            //StreamResourceInfo hold = Application.GetResourceStream(new Uri("/ConfigBottomView;component/Resources/hold.cur", UriKind.Relative));
            //leftCanvas.Cursor = new Cursor(hold.Stream);
        }

        private void leftCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isMOuseDown = false;
            leftEllipse.Visibility = Visibility.Collapsed;
            leftCanvas.ReleaseMouseCapture();
           
        }

        private void leftCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = e.GetPosition(inkCanvas);
           
            if (isMOuseDown)
            {   if (point.X>20&& point.X< inkCanvas.ActualWidth - 10)
                {


                    //InkCanvas.SetLeft(leftCanvas, point.X-6);
                    Point point1 = e.GetPosition(leftCanvas);
                  //  Canvas.SetLeft(leftEllipse, point1.X-4);
                    Canvas.SetTop(leftEllipse, point1.Y-4);
                    Point point2 = e.GetPosition(HistogramImage);
                    if (point2.X>=0&& point2.X<= HistogramImage.ActualWidth)
                    RangeSlider.LowerValue = point2.X / HistogramImage.ActualWidth * 255;



                }

              
            }
        }

        private Point moveOri1;
        private bool isMOuseDown1 = false;

        private void rightCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            moveOri1 = e.GetPosition(inkCanvas);
            isMOuseDown1 = true;
            InkCanvas.SetLeft(rightCanvas, moveOri1.X);
            rightCanvas.CaptureMouse();
            rightEllipse.Visibility = Visibility.Visible;
            Point point = e.GetPosition(rightCanvas);
           // Canvas.SetLeft(rightEllipse, point.X-4);
            Canvas.SetTop(rightEllipse, point.Y-4);

        }

        private void rightCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isMOuseDown1 = false;
            rightEllipse.Visibility = Visibility.Collapsed;
            rightCanvas.ReleaseMouseCapture();

        }

        private void rightCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = e.GetPosition(inkCanvas);
           
           if (isMOuseDown1)
            {
                if (point.X > 20 && point.X < inkCanvas.ActualWidth - 10)
                {
                    //InkCanvas.SetLeft(leftCanvas, point.X-6);
                    Point point1 = e.GetPosition(rightCanvas);
                  //  Canvas.SetLeft(rightEllipse, point1.X-4);
                    Canvas.SetTop(rightEllipse, point1.Y-4);
                    Point point2 = e.GetPosition(HistogramImage);
                    if (point2.X >= 0 && point2.X <= HistogramImage.ActualWidth)
                    RangeSlider.HigherValue = point2.X / HistogramImage.ActualWidth * 255;

                }

            }
        }

       
    }
}
