﻿using MenuISCameraSetting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            this.leftView.Children.Clear();
            List<UICofig> list = new List<UICofig>();

            list.Add(new UICofig() { path = "ConfigObjective.dll", name = "Magnification" });
            //list.Add(new UICofig() { path = "ConfigFocus.dll", name = "FocusMode" });
            list.Add(new UICofig() { path = "ConfigDPCMode.dll", name = "DPCMode" });
            list.Add(new UICofig() { path = "ConfigDeck.dll", name = "BaseDeck" });
            list.Add(new UICofig() { path = "ConfigSpot.dll", name = "SampleSpot" });
            list.Add(new UICofig() { path = "ConfigDOFMode.dll", name = "DOFMode" });
            list.Add(new UICofig() { path = "ConfigCollectInterval.dll", name = "CollectInterval" });

            foreach (var item in list)
            {
                Assembly assembly = Assembly.LoadFile(Environment.CurrentDirectory + "\\" + item.path);
                Control control = (Control)assembly.CreateInstance($"{item.path.Replace(".dll", "")}.{item.name}");
                leftView.Children.Add(control);
            }

            SolutionExplorers = new ObservableCollection<SolutionExplorer>()
                {
                    new SolutionExplorer()
                    {
                        SolutionGuid = Guid.NewGuid(),
                        SolutionName ="人体细胞工程",
                        SolutionConfig =  new SolutionConfig
                        {
                            FileName ="工程文件.gprj",
                            FilePath ="dddddddd"
                        },
                        SolutionLog = new SolutionLog
                        {
                            FileName ="工程文件.log",
                            FilePath =Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\LambdaManager\\lambda.log"
                        },
                        ProjectMannagers = new ObservableCollection<ProjectMannager>
                        {
                            new ProjectMannager()
                            {
                                ProjectName ="Image",
                                ProjectFiles = new ObservableCollection<ProjectFile>
                                {
                                    new ProjectFile()
                                    {
                                        FileName ="1.png",
                                        FilePath =@"C:\Users\Chen\Documents\NLG\",
                                    },
                                    new ProjectFile()
                                    {
                                        FileName ="2.png",
                                        FilePath ="22222",
                                    },
                                }

                            },

                            new ProjectMannager()
                            {
                                ProjectName ="Serial",

                                ProjectFiles = new ObservableCollection<ProjectFile>
                                {
                                    new ProjectFile()
                                    {
                                        FileName ="1.png",
                                        FilePath =@"C:\Users\Chen\Documents\NLG\",
                                    },
                                },
                                ProjectFolders = new ObservableCollection<ProjectFolder>
                                {
                                    new ProjectFolder()
                                    {
                                        FolderName ="测试1",
                                        ProjectFolders = new ObservableCollection<ProjectFolder>()
                                        {
                                            new ProjectFolder()
                                            {
                                              FolderName ="测试2",
                                              ProjectFiles = new ObservableCollection<ProjectFile>()
                                              {
                                                  new ProjectFile()
                                                  {
                                                      FileName ="2222ssdsadsad.png",
                                                      FilePath =@"C:\Users\Chen\Documents\NLG\",
                                                  },
                                              }
                                            }
                                        },
                                        ProjectFiles = new ObservableCollection<ProjectFile>
                                        {
                                            new ProjectFile()
                                            {
                                                FileName ="asdsadsadas.ssss",
                                                FilePath =@"C:\Users\Chen\Documents\NLG\",
                                            },
                                            new ProjectFile()
                                            {
                                                FileName ="sadasdasd.jpg",
                                                FilePath =@"C:\Users\Chen\Documents\NLG\",
                                            },
                                        },
                                    }
                                }


                            }


                        }
                    },
                };

            TreeView1.ItemsSource = SolutionExplorers;
        }
        public ObservableCollection<SolutionExplorer> SolutionExplorers =new ObservableCollection<SolutionExplorer>();

        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseDown(e);

            Point pos = e.GetPosition(TreeView1);
            HitTestResult result = VisualTreeHelper.HitTest(TreeView1, pos);
            TreeViewItem item = null;
            if (result != null)
                item = ViewHelper.FindVisualParent<TreeViewItem>(result.VisualHit);

            if (e.RightButton == MouseButtonState.Pressed)
            {
                if (item != null)
                    item.IsSelected = true;
            }

            if (e.ClickCount == 2)
            {
                if (item != null && item.DataContext is ProjectMannager)
                {
                    ProjectMannager node = item.DataContext as ProjectMannager;
                    node.DoubleClick(e);
                }

                return;
            }
        }



        private void TreeView1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeView treeView = sender as TreeView;
            //if (treeView.SelectedItem is SolutionConfig solutionConfig)
            //{
            //    MessageBox.Show(solutionConfig.FilePath);
            //}
            if (treeView.SelectedItem is SolutionLog solutionLog)
            {
                TextBox textBox = new TextBox();
                textBox.Text = File.ReadAllText(solutionLog.FilePath);
                ScrollViewer scrollViewer = new ScrollViewer();
                scrollViewer.Content = textBox;
                scrollViewer.ScrollToEnd();
                Grid grid = new Grid();
                grid.Children.Add(scrollViewer);
                Window window = new Window();
                window.Content = grid;
                window.ShowDialog();

            }
            //if (treeView.SelectedItem is ProjectFile projectFile)
            //{
            //    MessageBox.Show(projectFile.FilePath);
            //}
            //if (treeView.SelectedItem is ProjectFolder projectFolder)
            //{
            //    //MessageBox.Show(projectFolder.FolderName);
            //}

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ProjectMannager projectMannager = new ProjectMannager()
            {
                ProjectName ="新建工程"
            };

            SolutionExplorers[0].AddChild(projectMannager);
        }

        private void MenuItem1_Click(object sender, RoutedEventArgs e)
        {
            if (TreeView1.SelectedItem is ProjectMannager projectMannager)
            {
                ProjectFile projectFile = new ProjectFile()
                {
                    FileName = "新建文件"
                };
                projectMannager.AddChild(projectFile);
            }

        }

        private void MenuItem2_Click(object sender, RoutedEventArgs e)
        {
            if (TreeView1.SelectedItem is ProjectMannager projectMannager)
            {
                ProjectFolder projectFolder = new ProjectFolder()
                {
                    FolderName = "新建文件夹"
                };
                projectMannager.AddChild(projectFolder);
            }
        }

        private void MenuItem3_Click(object sender, RoutedEventArgs e)
        {
            if (TreeView1.SelectedItem is ProjectFolder projectFolder)
            {
                ProjectFile projectFile = new ProjectFile()
                {
                    FileName = "新建文件"
                };
                projectFolder.AddChild(projectFile);
            }
        }

        private void MenuItem4_Click(object sender, RoutedEventArgs e)
        {
            if (TreeView1.SelectedItem is ProjectFolder projectFolder)
            {
                ProjectFolder projectFolder1 = new ProjectFolder()
                {
                    FolderName = "新建文件夹"
                };
                projectFolder.AddChild(projectFolder1);
            }

        }
    }

    public class ViewHelper
    {
        /// <summary>
        /// 通过给定的依赖对象，在控件树中向上查找指定类型的控件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T FindVisualParent<T>(DependencyObject obj) where T : class
        {
            while (obj != null)
            {
                if (obj is T)
                    return obj as T;

                obj = VisualTreeHelper.GetParent(obj);
            }

            return null;
        }

        /// <summary>
        /// 在给定的空间中，查找给定坐标点的给定类型的控件
        /// </summary>
        public static T HitTestView<T>(Visual visual, Point pos) where T : class
        {
            HitTestResult result = VisualTreeHelper.HitTest(visual, pos);
            if (result == null)
                return null;
            DependencyObject obj = result.VisualHit;

            return FindVisualParent<T>(obj);
        }
    }


    public class SolutionExplorer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyyName)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Guid SolutionGuid { get; set; }
        public string SolutionName { get; set; }
        public string SolutionVersion { get; set; }
        public string SolutionPath { get; set; }

        public SolutionLog SolutionLog { get; set; }
        public SolutionConfig SolutionConfig { get; set; }

        public ObservableCollection<ProjectMannager> ProjectMannagers { get; set; } = new ObservableCollection<ProjectMannager>();

        public ObservableCollection<object> Children
        {
            get
            {
                ObservableCollection<object> childNodes = new ObservableCollection<object>();
                ProjectMannagers = new ObservableCollection<ProjectMannager>(ProjectMannagers.OrderBy(item => item.ProjectName));
                foreach (var project in this.ProjectMannagers)
                    childNodes.Add(project);
                if (SolutionLog != null)
                    childNodes.Add(SolutionLog);
                if (SolutionConfig != null)
                    childNodes.Add(SolutionConfig);
                return childNodes;
            }
            set { }
        }


        public void AddChild(ProjectMannager projectMannager)
        {
            ProjectMannagers.Add(projectMannager);
            NotifyPropertyChanged("Children");
        }


    }


    public class SolutionLog
    {
        
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
    public class SolutionConfig
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }



    public class ProjectMannager: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyyName)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Guid ConfirmationID { get; set; }
        public string ProjectName { get; set; }
         
        public ObservableCollection<ProjectFolder> ProjectFolders { get; set; } = new ObservableCollection<ProjectFolder>();
        public ObservableCollection<ProjectFile> ProjectFiles { get; set; } = new ObservableCollection<ProjectFile>();
        public virtual void DoubleClick(MouseButtonEventArgs e)
        {
            MessageBox.Show("22222222222222222");
        }


        private ObservableCollection<object> childNodes;
        public ObservableCollection<object> Children
        {
            get {
                childNodes = new ObservableCollection<object>();
                ProjectFolders = new ObservableCollection<ProjectFolder>(ProjectFolders.OrderBy(item => item.FolderName));
                ProjectFiles = new ObservableCollection<ProjectFile>(ProjectFiles.OrderBy(item => item.FileName));
                foreach (var product in this.ProjectFolders)
                    childNodes.Add(product);
                foreach (var projectFile in this.ProjectFiles)
                    childNodes.Add(projectFile);
                return childNodes;
            }
            set { 
            }
        }
        public void AddChild(ProjectFolder projectFolder)
        {
            ProjectFolders.Add(projectFolder);
            NotifyPropertyChanged("Children");
        }
        public void AddChild(ProjectFile projectFile)
        {
            ProjectFiles.Add(projectFile);
            NotifyPropertyChanged("Children");
        }
    }

    public class ProjectFile
    {
        public static RoutedUICommand Rename = new RoutedUICommand();

        public string FileName { get; set; }
        public string FilePath { get; set; }
        
        
    }

    public class ProjectFolder : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyyName)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string FolderName { get; set; }
        public string Description { get; set; }

        public ObservableCollection<ProjectFolder> ProjectFolders { get; set; } = new ObservableCollection<ProjectFolder>();

        public ObservableCollection<ProjectFile> ProjectFiles { get; set; } = new ObservableCollection<ProjectFile>();

        public ObservableCollection<object> Children
        {
            get
            {
                ObservableCollection<object> childNodes = new ObservableCollection<object>();
                ProjectFolders = new ObservableCollection<ProjectFolder>(ProjectFolders.OrderBy(item => item.FolderName));
                ProjectFiles = new ObservableCollection<ProjectFile>(ProjectFiles.OrderBy(item => item.FileName));
                foreach (var product in this.ProjectFolders)
                    childNodes.Add(product);
                foreach (var projectFile in this.ProjectFiles)
                    childNodes.Add(projectFile);
                return childNodes;
            }
        }
        public void AddChild(ProjectFolder projectFolder)
        {
            ProjectFolders.Add(projectFolder);
            NotifyPropertyChanged("Children");
        }
        public void AddChild(ProjectFile projectFile)
        {
            ProjectFiles.Add(projectFile);
            NotifyPropertyChanged("Children");
        }

    }

    public class UICofig
    {
        public string path = "";
        public string name = "";   
    }
}
