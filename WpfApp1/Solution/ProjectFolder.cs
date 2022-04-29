﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace NLGSolution
{
    public class ProjectFolder : BaseObject
    {

        public FileSystemWatcher watcher;
        public ObservableCollection<BaseObject> Children { get; set; }

        public ProjectFolder(string FolderPath) :base(FolderPath, Type.Directory)
        {
            Children = new ObservableCollection<BaseObject>();

            watcher = new FileSystemWatcher(FolderPath)
            {
                IncludeSubdirectories = false
            };
            watcher.Deleted += Watcher_Deleted;
            watcher.Created += Watcher_Created;
            watcher.Renamed += Watcher_Renamed;
            watcher.EnableRaisingEvents = true;
        }

        public void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            if (File.Exists(e.FullPath) || Directory.Exists(e.FullPath))
            {
                var baseObject = Children.ToList().Find(t => t.FullPath == e.OldFullPath);
                if (baseObject != null)
                {
                    baseObject.FullPath = e.FullPath;
                }
            }
        }

        public void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            if (!(File.Exists(e.FullPath) || Directory.Exists(e.FullPath)))
            {
                var projectFile = Children.ToList().Find(t => t.FullPath == e.FullPath);
                if (projectFile != null)
                {
                    Application.Current.Dispatcher.Invoke((Action)(() =>
                    {
                        RemoveChild(projectFile);
                    }));
                }
            }

        }

        public void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            if (File.Exists(e.FullPath))
            {
                Application.Current.Dispatcher.Invoke((Action)(() =>
                {
                    AddChild(new ProjectFile(e.FullPath));
                }));
            }
            else if (Directory.Exists(e.FullPath))
            {
                Application.Current.Dispatcher.Invoke((Action)(() =>
                {
                    AddChild(new ProjectFolder(e.FullPath));
                }));
            }
        }
        

        public string Description { get; set; }


        public override void AddChild(BaseObject baseObject)
        {
            baseObject.Parent = this;
            Children.SortedAdd(baseObject);
        }

        public override void RemoveChild(BaseObject baseObject)
        {
            if (baseObject == null)
                return;

            if (baseObject.Parent== this)
            {
                baseObject.Parent = null;
                Children.Remove(baseObject);
                baseObject.Delete();
            }
        }

    }
}
