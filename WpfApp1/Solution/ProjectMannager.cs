﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace NLGSolution
{
    public class ProjectMannager : ProjectFolder
    {

        public ProjectMannager(string ProjectPath):base(ProjectPath)
        {

        }

        public Guid ConfirmationID { get; set; }

        public ObservableCollection<ProjectFolder> ProjectFolders
        { 
            get { 
                var projectFolders = new ObservableCollection<ProjectFolder>();
                foreach (var item in Children)
                {
                    if (item is ProjectFolder projectfolder)
                        projectFolders.Add(projectfolder);

                }
                return projectFolders;
            }
            private set { } 
        }

        public ObservableCollection<ProjectFile> ProjectFiles
        {
            get
            {
                var projectFiles = new ObservableCollection<ProjectFile>();
                foreach (var item in Children)
                {
                    if (item is ProjectFile projectFile)
                        projectFiles.Add(projectFile);

                }
                return projectFiles;
            }
            private set { }
        }




        //public override void AddChild(BaseObject baseObject)
        //{
        //    baseObject.Parent = this;
        //    Children.SortedAdd(baseObject);
        //}

        //public override void RemoveChild(BaseObject baseObject)
        //{
        //    if (baseObject == null)
        //        return;

        //    if (baseObject.Parent == this)
        //    {
        //        baseObject.Parent = null;
        //        Children.Remove(baseObject);

        //        baseObject.Delete();
        //        //NotifyPropertyChanged("Children");
        //    }
        //}
    }
}
