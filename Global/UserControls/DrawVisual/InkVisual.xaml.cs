﻿using Global.Mode.Config;
using Lambda;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Resources;

namespace Global.UserControls.DrawVisual
{
    /// <summary>
    /// InkVisual.xaml 的交互逻辑
    /// </summary>
    public partial class InkVisual : UserControl
    {
        public InkVisual(ImageViewState.ToolTop ToolTop, DrawInkMethod inkMethod, double ratio)
        {
            InitializeComponent();
            this.ToolTop = ToolTop;
            this.inkMethod = inkMethod;
            this.ratio = ratio;
            topToolbar =(WrapPanel)mainwin.FindName("topToolbar");
        }
        Window mainwin = Application.Current.MainWindow;
        WrapPanel topToolbar;
        private double width;
        private double height;
        public ImageViewState.ToolTop ToolTop;
        public double ratio = 1;
        DrawInkMethod inkMethod;
        bool isMouseDown = false;
        Point iniP = new Point(0, 0);
        public  Stroke lastTempStroke = null;
        public  Stroke lastTempStroke0 = null;
        public int ZoomInOut = 0;
       
        public  StrokeCollection tempStroke = new StrokeCollection();
        public StrokeCollection RegisterStroke = new StrokeCollection();
        public bool saveTempStroke = true;


        private void inkCanvas_MouseMove(object sender, MouseEventArgs e)
        {

            Point endP = e.GetPosition(inkCanvas);
            List<System.Windows.Point> pointList;
            StylusPointCollection point;
            Stroke stroke;
            Stroke stroke0;
            StrokeCollection strokes = new StrokeCollection();
            if (isMouseDown && ToolTop.ArrowChecked)
            {
                double dist = GetDistance(endP, iniP);
                if (dist < 5)
                    return;
                stroke = inkMethod.GenerateArrowLineStroke(iniP, endP);
                try
                {
                    inkCanvas.Strokes.Remove(lastTempStroke);
                }
                catch { }
                lastTempStroke = stroke;
                inkCanvas.Strokes.Add(stroke);
              
            }
            if (isMouseDown && ToolTop.LineChecked)
            {
                double dist = GetDistance(endP, iniP);
                if (dist < 5)
                    return;
                stroke = inkMethod.GenerateLineStroke(iniP, endP);
                try
                {
                    inkCanvas.Strokes.Remove(lastTempStroke);
                }
                catch { }
                lastTempStroke = stroke;
                inkCanvas.Strokes.Add(stroke);
               
            }
            if (isMouseDown && ToolTop.DimensionChecked)
            {

                switch (DrawInkMethod.dimenViewModel.DimSelectedIndex)
                {

                    case 0:

                        stroke = inkMethod.GenerateDimensionStroke1(iniP, endP);
                        break;
                    case 1:
                        stroke = inkMethod.GenerateDimensionStroke2(iniP, endP);
                        break;
                    case 2:
                        stroke = inkMethod.GenerateDimensionStroke3(iniP, endP);
                        break;

                    case 3:
                        stroke = inkMethod.GenerateDimensionStroke4(iniP, endP);
                        break;
                    case 4:
                        stroke = inkMethod.GenerateDimensionStroke5(iniP, endP);
                        break;
                   default:
                        stroke = inkMethod.GenerateDimensionStroke1(iniP, endP);
                        break;

                }
                try
                {
                    inkCanvas.Strokes.Remove(lastTempStroke);
                }
                catch { }
                lastTempStroke = stroke;
                inkCanvas.Strokes.Add(stroke);
              

                double theta = Math.Atan2(endP.Y-iniP.Y  , endP.X-iniP.X);
                double dist = GetDistance(iniP, endP);
                DrawInkMethod.dimenViewModel.Length = (double)dist / inkCanvas.ActualWidth * 1689.12 / ratio;

                if (theta/ Math.PI * 180 == 0)
                {
                    DrawInkMethod.dimenViewModel.Angle = 0;
                }
                else
                {
                    DrawInkMethod.dimenViewModel.Angle = theta / Math.PI * 180;

                }
                Point endP1;
                endP1.X = iniP.X+ DrawInkMethod.dimenViewModel.Length*Math.Cos(theta);
                endP1.Y = iniP.Y + DrawInkMethod.dimenViewModel.Length * Math.Sin(theta);
                stroke0 = DrawInkMethod.InkCanvasMethod.CreateText(iniP, endP,endP1);
                try
                {
                    inkCanvas.Strokes.Remove(lastTempStroke0);
                }
                catch { }
                lastTempStroke0 = stroke0;
                inkCanvas.Strokes.Add(stroke0);
               

            }
           
           
            else if (isMouseDown && ToolTop.MoveChecked)
            {

                if (inkCanvas.Cursor == Cursors.Hand)
                {
                    StreamResourceInfo sri = Application.GetResourceStream(new Uri("/Global;component/usercontrols/image/hold.cur", UriKind.Relative));
                    inkCanvas.Cursor = new Cursor(sri.Stream);
                }
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                              {
                            { "event",(int)0},
                            {"x",(int)endP.X },
                            {"y",(int)endP.Y },
                            {"flag",(int)1 }

                                 };
                LambdaControl.Trigger("MOUSE_EVENT", null, parameters);
            }

            if (isMouseDown && ToolTop.CircleChecked)
            {
                var isShiftDown = Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift);
                double delta = (iniP.X - endP.X) * (iniP.Y - endP.Y);
                if (isShiftDown && delta != 0)
                {
                    stroke = inkMethod.GenerateCircleStroke(iniP, endP);
                    try
                    {
                        inkCanvas.Strokes.Remove(lastTempStroke);
                    }
                    catch { }
                    lastTempStroke = stroke;
                    inkCanvas.Strokes.Add(stroke);
                  
                }
                else
                {
                    stroke = inkMethod.GenerateEllipseStroke(iniP, endP);
                    try
                    {
                        inkCanvas.Strokes.Remove(lastTempStroke);
                    }
                    catch { }
                    lastTempStroke = stroke;
                    inkCanvas.Strokes.Add(stroke);
                
                }



            }
            if (isMouseDown && ToolTop.RectangleChecked)
            {
                var isShiftDown = Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift);

                double delta = (iniP.X - endP.X) * (iniP.Y - endP.Y);
                if (isShiftDown && delta != 0)
                {
                    stroke = inkMethod.GenerateSquareStroke(iniP, endP);
                    try
                    {
                        inkCanvas.Strokes.Remove(lastTempStroke);
                    }
                    catch { }
                    lastTempStroke = stroke;
                    inkCanvas.Strokes.Add(stroke);
                  
                }
                else
                {
                    stroke = inkMethod.GenerateRectangleStroke(iniP, endP);

                    try
                    {
                        inkCanvas.Strokes.Remove(lastTempStroke);
                      
                    }
                    catch { }
                    lastTempStroke = stroke;
                    inkCanvas.Strokes.Add(stroke);
                 
                }
             


            }
            if (ToolTop.EraserChecked)
            {
                if (inkCanvas.Cursor == Cursors.Arrow)
                {
                    inkCanvas.UseCustomCursor = true;
                    StreamResourceInfo sri = Application.GetResourceStream(new Uri("/Global;component/usercontrols/image/eraser.cur", UriKind.Relative));
                    inkCanvas.Cursor = new Cursor(sri.Stream);
                }
            }
            if (ToolTop.ArrowChecked || ToolTop.DimensionChecked || ToolTop.LineChecked || ToolTop.PolygonChecked || ToolTop.RectangleChecked || ToolTop.TextChecked)
            {
                if(inkCanvas.Cursor == Cursors.Arrow)
                {
                    inkCanvas.Cursor = Cursors.Cross;
                }
            }
        }

        List<System.Windows.Point> pointList1 = new List<Point>();
        StylusPointCollection point1;
        Stroke stroke1;
        Point PointSt;

        StrokeCollection strokes1 = new StrokeCollection();
        private void inkCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            iniP = e.GetPosition(inkCanvas);
            isMouseDown = true;
            inkCanvas.CaptureMouse();


            if (ToolTop.PolygonChecked == true)
            {

                pointList1.Add(iniP);
                point1 = new StylusPointCollection(pointList1);

                if (pointList1.Count > 1)
                {
                    stroke1 = new Stroke(point1)
                    {
                        DrawingAttributes = inkMethod.drawingAttributes.Clone()
                    };
                    try
                    {
                        inkCanvas.Strokes.Remove(lastTempStroke);
                    }
                    catch { }
                    lastTempStroke = stroke1;
                    inkCanvas.Strokes.Add(stroke1);
                  

                }
                if (pointList1.Count == 1)
                {
                    PointSt = iniP;
                }

            }
            else if (ToolTop.MoveChecked == true)
            {
                StreamResourceInfo hold = Application.GetResourceStream(new Uri("/Global;component/usercontrols/image/hold.cur", UriKind.Relative));
                inkCanvas.Cursor = new Cursor(hold.Stream);

                // CanMove = true;
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                            {
                            {"event",(int)1},
                            {"x",(int)iniP.X },
                            {"y",(int)iniP.Y },
                            {"flag",(int)1 }

                            };
                LambdaControl.Trigger("MOUSE_EVENT", null, parameters);
            }


        }

        private void inkCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(ToolTop.PolygonChecked == true)
            {

            }
            else
            {
                lastTempStroke = null;
                lastTempStroke0 = null;
            };
           
            isMouseDown = false;
            inkCanvas.ReleaseMouseCapture();
            if (ToolTop.MoveChecked == true)
            {
                inkCanvas.Cursor = Cursors.Hand;
            }
        }



        private void inkCanvas_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Escape)
            {
                if (pointList1.Count > 1)
                {

                    pointList1.Add(PointSt);
                    point1 = new StylusPointCollection(pointList1);
                    stroke1 = new Stroke(point1)
                    {
                        DrawingAttributes = inkMethod.drawingAttributes.Clone()
                    };
                    try
                    {
                        inkCanvas.Strokes.Remove(lastTempStroke);
                    }
                    catch { }
                    lastTempStroke = null;
                    inkCanvas.Strokes.Add(stroke1);
                   
                    pointList1.Clear();

                }


            }

        }

        public double GetDistance(Point point1, Point point2)
        {
            return Math.Sqrt((point1.X - point2.X) * (point1.X - point2.X) + (point1.Y - point2.Y) * (point1.Y - point2.Y));
        }

        private void inkCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (saveTempStroke&& inkCanvas.Strokes.Count>0 )
            {
                if (inkCanvas.Strokes.Contains(inkMethod.Dimstroke))
                {
                    inkCanvas.Strokes.Remove(inkMethod.Dimstroke);
                    inkCanvas.Strokes.Remove(inkMethod.Textstroke);

                }

                tempStroke = inkCanvas.Strokes.Clone();
                inkCanvas.Strokes.Add(inkMethod.Dimstroke);
                inkCanvas.Strokes.Add(inkMethod.Textstroke);
                saveTempStroke = false;
            }
            Point curPoint = e.GetPosition(e.Device.Target);
            Matrix matrix = new Matrix();
            if (e.Delta > 0 && ZoomInOut<5)
            {
                matrix.ScaleAt(1.2, 1.2, curPoint.X, curPoint.Y);
                ZoomInOut++;
                ratio = ratio * 1.2;
                inkCanvas.Strokes.Transform(matrix, false);
                RepaintDim();
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                            {
                            { "event",(int)10},
                            {"x",(int)curPoint.X },
                            {"y",(int)curPoint.Y },
                            {"flag",(int)1024 }

                            };
                LambdaControl.Trigger("MOUSE_EVENT", null, parameters);
               

            }
            else if(e.Delta < 0 && ZoomInOut>0)
            {
                matrix.ScaleAt(1/1.2, 1/1.2, curPoint.X, curPoint.Y);
                ZoomInOut--;
                ratio = ratio / 1.2;
                inkCanvas.Strokes.Transform(matrix, false);
                RepaintDim();
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                            {
                            { "event",(int)10},
                            {"x",(int)curPoint.X },
                            {"y",(int)curPoint.Y },
                            {"flag",(int)-1024 }
                            };
                LambdaControl.Trigger("MOUSE_EVENT", null, parameters);
                
            }
            




        }
        private void RepaintDim()
        {
            if (inkCanvas.Strokes.Contains(inkMethod.Dimstroke))
            {
                inkCanvas.Strokes.Remove(inkMethod.Dimstroke);
                inkCanvas.Strokes.Remove(inkMethod.Textstroke);
                double w = inkCanvas.ActualWidth;
                double h = inkCanvas.ActualHeight;
                Point iniP = new Point(w * 19 / 20, h * 19 / 20);
                Point endP = new Point(w * 19 / 20 - w * 100 * ratio / 1689.12, h * 19 / 20);
                inkMethod.Dimstroke = inkMethod.GenerateDimensionStroke0(iniP, endP);
                try
                {
                    inkCanvas.Strokes.Remove(lastTempStroke);
                }
                catch { }
                //inkVisual.lastTempStroke = inkMethod.Dimstroke;
                inkCanvas.Strokes.Add(inkMethod.Dimstroke);
                //inkVisual.lastTempStroke = null;
                inkMethod.Textstroke = DrawInkMethod.InkCanvasMethod.CreateText1(iniP, endP);
                inkCanvas.Strokes.Add(inkMethod.Textstroke);

            }
        }

        private Vector clickOffset;
        private int i = 0;
        private double toptoolHeight;
        private double inkWidthLim = 0;
        private void inkCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (toptoolHeight > 0 && topToolbar.ActualHeight - toptoolHeight > 10)
            {
               // MessageBox.Show(inkCanvas.ActualWidth.ToString());
                inkWidthLim = inkCanvas.ActualWidth;
                toptoolHeight = topToolbar.ActualHeight;

            };

            if ( ActualWidth <= inkWidthLim) 
                return;

            Point beforePoint = new Point(width, height);
            Point point = new Point(ActualWidth, ActualHeight);
            clickOffset = point - beforePoint;
            Matrix matrixMove = new Matrix();
            matrixMove.Translate(clickOffset.X, clickOffset.Y / 2);
            inkCanvas.Strokes.Transform(matrixMove, false);


            double wRatio = inkCanvas.ActualWidth / width;
            double hRatio = inkCanvas.ActualHeight / height;

            //Point curPoint = new Point(ActualWidth / 2, ActualHeight / 2);
            Matrix matrix = new Matrix();
            matrix.ScaleAt(wRatio, hRatio, beforePoint.X / 2 + clickOffset.X, beforePoint.Y / 2 + clickOffset.Y/2);
            inkCanvas.Strokes.Transform(matrix, false);


            Matrix matrixMove1 = new Matrix();
            matrixMove1.Translate(-clickOffset.X / 2, 0);
            inkCanvas.Strokes.Transform(matrixMove1, false);


            width = inkCanvas.ActualWidth;
            height = inkCanvas.ActualHeight;

            toptoolHeight = topToolbar.ActualHeight;

        }

       
    }
}

