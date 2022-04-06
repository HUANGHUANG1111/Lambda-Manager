﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace NLGSolution
{
    public class ProjectFolder : BaseObject
    {

        public string Description { get; set; }

        public ObservableCollection<ProjectFolder> ProjectFolders { get; set; } = new ObservableCollection<ProjectFolder>();

        public ObservableCollection<ProjectFile> ProjectFiles { get; set; } = new ObservableCollection<ProjectFile>();

        public ObservableCollection<object> Children
        {
            get
            {
                ObservableCollection<object> childNodes = new ObservableCollection<object>();
                foreach (var product in ProjectFolders)
                    childNodes.Add(product);
                foreach (var projectFile in ProjectFiles)
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
}