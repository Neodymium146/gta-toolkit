/*
    Copyright(c) 2015 Neodymium

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
*/

using RageLib.Archives;
using System;
using System.Collections.Generic;

namespace ArchiveTool.ViewModels
{
    /// <summary>
    /// Represents a view-model of a directory.
    /// </summary>
    public interface IDirectoryViewModel
    {
        /// <summary>
        /// Gets the name of the directory.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the directory is selected.
        /// </summary>
        bool IsSelected { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the directory is expanded.
        /// </summary>
        bool IsExpanded { get; set; }

        /// <summary>
        /// Gets the list of directories in the current directory.
        /// </summary>
        ICollection<DirectoryViewModel> Children { get; }
    }

    public class DirectoryViewModel : BaseViewModel, IDirectoryViewModel
    {
        public IArchiveDirectory directory;

        private DirectoryViewModel parentDirectory;
        private List<DirectoryViewModel> childDirectories;
        private bool isSelected;
        private bool isExpanded;
       
        public Action<DirectoryViewModel> OnSelectionChanged;
        
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                if (value != isSelected)
                {
                    isSelected = value;
                    NotifyPropertyChanged("IsSelected");

                    if (OnSelectionChanged != null)
                        OnSelectionChanged(this);
                }
            }
        }

        public bool IsExpanded
        {
            get
            {
                return isExpanded;
            }
            set
            {
                if (value != isExpanded)
                {
                    isExpanded = value;
                    NotifyPropertyChanged("IsExpanded");
                }

                if (isExpanded && parentDirectory != null)
                    parentDirectory.IsExpanded = true;
            }
        }

        public ICollection<DirectoryViewModel> Children
        {
            get
            {
                return childDirectories;
            }
        }

        public string Name
        {
            get
            {
                if (parentDirectory == null)
                    return "/";
                else
                    return directory.Name;
            }
        }

        public DirectoryViewModel(IArchiveDirectory directory, DirectoryViewModel parent)
        {
            this.directory = directory;
            this.parentDirectory = parent;

            childDirectories = new List<DirectoryViewModel>();
            foreach (var f in directory.GetDirectories())
            {
                var dd = new DirectoryViewModel(f, this);
                childDirectories.Add(dd);
            }

        }
    }
}