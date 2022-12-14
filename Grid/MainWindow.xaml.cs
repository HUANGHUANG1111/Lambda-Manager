using Global.Common.Util;
using Microsoft.Win32;
using Solution.RecentFile;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;

namespace Grid
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


        RecentFileList recentFileList = new RecentFileList();

        readonly string StatusBarRegPath = "Software\\Grid";

        private void Window_Initialized(object sender, EventArgs e)
        {
            TextBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Grid\\config\\default.gcfg";
            string regiserkey = "Software\\" + "LambdaManager" + "\\" + "LambdaManager" + "\\" + "RecentFileList";
            recentFileList.Persister = new RegistryPersister(regiserkey);
            if (recentFileList.RecentFiles.Count ==0)
            {
                Uri uri = new Uri("/Grid;component/default.gprj", UriKind.Relative);
                //获取资源文件
                StreamResourceInfo info = Application.GetResourceStream(uri);

                string DirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Grid\\Default";
                if (!Directory.Exists(DirectoryPath))
                    Directory.CreateDirectory(DirectoryPath);
                else
                {
                    Directory.Delete(DirectoryPath, true);
                    Directory.CreateDirectory(DirectoryPath);
                }

                Directory.CreateDirectory(DirectoryPath + "\\" + "Video");
                Directory.CreateDirectory(DirectoryPath + "\\" + "Image");

                string FullPath = DirectoryPath +"\\default.gprj";
                using (var fileStream = File.Create(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+ "\\Grid\\Default\\default.gprj"))
                {
                    info.Stream.Seek(0, SeekOrigin.Begin);
                    info.Stream.CopyTo(fileStream);
                }
                recentFileList.InsertFile(FullPath);
                TextBox2.Text = recentFileList.RecentFiles[0];


            }
            else
            {
                TextBox2.Text = recentFileList.RecentFiles[0];
            }
            CheckBox1.IsChecked = Reg.ReadValue(StatusBarRegPath, "InitializeStage");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (File.Exists("LambdaCore.dll"))
            {
                try
                {
                    Process process = new Process();
                    process.StartInfo.FileName = @"LambdaManager.exe";
                    process.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.Close();
            }
            else
            {
                StartWindow startWindow = new StartWindow();
                startWindow.Show();
                startWindow.Closed += delegate
                {
                    this.Close();
                };
            }
        }



        private void Set_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new()
            {
                Multiselect = false,//该值确定是否可以选择多个文件
                Title = "请选择配置文件",
                RestoreDirectory = true,
                Filter = "显微镜配置 | *.* ",
            };
            if (dialog.ShowDialog() == true)
            {
                TextBox1.Text = dialog.FileName;
            }
        }

        private void Set_Click1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new()
            {
                Multiselect = false,//该值确定是否可以选择多个文件
                Title = "请选择工程",
                RestoreDirectory = true,
                Filter = "显微镜工程(*.gprj)|*.gprj",
            };
            if (dialog.ShowDialog() == true)
            {
                TextBox2.Text = dialog.FileName;
                recentFileList.InsertFile(dialog.FileName);
            }
        }

        private void CheckBox1_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox!=null)
                Reg.WriteValue(StatusBarRegPath, "InitializeStage", checkBox.IsChecked??false);
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
