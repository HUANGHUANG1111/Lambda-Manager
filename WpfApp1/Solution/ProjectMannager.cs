﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Solution
{
    public class ProjectMannager : BaseObject
    {

        public Guid ConfirmationID { get; set; }

        public ObservableCollection<ProjectFolder> ProjectFolders { get; set; } = new ObservableCollection<ProjectFolder>();
        public ObservableCollection<ProjectFile> ProjectFiles { get; set; } = new ObservableCollection<ProjectFile>();
        public virtual void DoubleClick(MouseButtonEventArgs e)
        {
            MessageBox.Show("22222222222222222");
        }


        private ObservableCollection<object> childNodes;
        public ObservableCollection<object> Children
        {
            get
            {
                childNodes = new ObservableCollection<object>();
                ProjectFolders = new ObservableCollection<ProjectFolder>(ProjectFolders.OrderBy(item => item.Name));
                ProjectFiles = new ObservableCollection<ProjectFile>(ProjectFiles.OrderBy(item => item.Name));
                foreach (var product in ProjectFolders)
                    childNodes.Add(product);
                foreach (var projectFile in ProjectFiles)
                    childNodes.Add(projectFile);
                return childNodes;
            }
            set
            {
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
}
