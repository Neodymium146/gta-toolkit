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

using ArchiveTool.Commands;
using ArchiveTool.Models;
using Microsoft.Win32;
using RageLib.Archives;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace ArchiveTool.ViewModels
{
    /// <summary>
    /// Represents a view-model of the main window.
    /// </summary>
    public interface IMainViewModel
    {
        ICommand OpenCommand { get; }
        ICommand CloseCommand { get; }
        ICommand ExitCommand { get; }
        ICommand ImportCommand { get; }
        ICommand ExportCommand { get; }
        ICommand ConfigureCommand { get; }

        ICollection<IDirectoryViewModel> Directories { get; }
        DirectoryViewModel SelectedDirectory { get; set; }
        
        ICollection<FileViewModel> Files { get; }
        FileViewModel SelectedFile { get; set; }
    }

    class MainViewModel : BaseViewModel
    {
        private MainModel model;
        private FileViewModel selectedFile;

        public ICollection<IDirectoryViewModel> directories_;



        public ICollection<IDirectoryViewModel> Directories
        {
            get
            {
                return directories_;
            }
        }

        public DirectoryViewModel SelectedDirectory
        {
            get
            {
                return null;
            }
            set
            {
                var files = new List<FileViewModel>();

                foreach (var file in value.directory.GetFiles())
                {
                    if (file is IArchiveBinaryFile)
                    {
                        files.Add(new BinaryFileViewModel(file));
                    }
                    else
                    {
                        files.Add(new ResourceFileViewModel(file));
                    }
                }

                Files = files;
                NotifyPropertyChanged("Files");
            }
        }

        public ICollection<FileViewModel> Files { get; set; }

        public FileViewModel SelectedFile
        {
            get
            {
                return selectedFile;
            }
            set
            {
                selectedFile = (FileViewModel)value;
                NotifyPropertyChanged();
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public ICommand OpenCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }
        public ICommand ImportCommand { get; private set; }
        public ICommand ExportCommand { get; private set; }
        public ICommand ConfigureCommand { get; private set; }
        
        public MainViewModel()
        {
            this.model = new MainModel();

            this.OpenCommand = new ActionCommand(Open_Clicked, Open_CanClick);
            this.CloseCommand = new ActionCommand(Close_Clicked, Close_CanClick);
            this.ExitCommand = new ActionCommand(Exit_Clicked);
            this.ImportCommand = new ActionCommand(Import_Clicked, Import_CanClick);
            this.ExportCommand = new ActionCommand(Export_Clicked, Export_CanClick);
            this.ConfigureCommand = new ActionCommand(Configure_Clicked);
        }

        public bool Open_CanClick(object parameter)
        {
            if (model.HasKeys)
                return true;
            else
                return false;
        }

        public void Open_Clicked(object parameter)
        {
            var dlg = new OpenFileDialog();
            dlg.Title = "Select archive";
            if (dlg.ShowDialog() == true)
            {
                // open archive
                this.model.Load(dlg.FileName);

                var vm = new DirectoryViewModel(model.Archive.Root, null);

                directories_ = new List<IDirectoryViewModel>();
                directories_.Add(vm);

                NotifyPropertyChanged("Directories");

                var dirstack = new Stack<DirectoryViewModel>();
                dirstack.Push(vm);
                while (dirstack.Count > 0)
                {
                    var qq = dirstack.Pop();
                    qq.OnSelectionChanged = DirectoryChanged;

                    foreach (var xx in qq.Children)
                        dirstack.Push(xx);
                }

                vm.IsSelected = true;
                CommandManager.InvalidateRequerySuggested();
            }                       
        }

        public bool Close_CanClick(object parameter)
        {
            if (model.Archive != null)
                return true;
            else
                return false;
        }

        public void Close_Clicked(object parameter)
        {
            // close archive
            model.Close();

            directories_ = null;
            NotifyPropertyChanged("Directories");

            Files = null;
            NotifyPropertyChanged("Files");
            CommandManager.InvalidateRequerySuggested();
        }

        public void Exit_Clicked(object parameter)
        {
            Application.Current.Shutdown();
        }

        public bool Import_CanClick(object parameter)
        {
            if (model.Archive != null)
                return true;
            else
                return false;
        }

        public void Import_Clicked(object parameter)
        {
            var dlg = new OpenFileDialog();
            dlg.Title = "Import file";
            if (dlg.ShowDialog() == true)
            {
                model.Import(SelectedDirectory.directory, dlg.FileName);
            }
        }

        public bool Export_CanClick(object parameter)
        {
            if (model.Archive != null && SelectedFile != null)
                return true;
            else
                return false;
        }

        public void Export_Clicked(object parameter)
        {
            var dlg = new SaveFileDialog();
            dlg.Title = "Export file";
            dlg.FileName = SelectedFile.GetFile().Name;
            if (dlg.ShowDialog() == true)
            {
                model.Export(SelectedFile.GetFile(), dlg.FileName);
            }
        }

        public void Configure_Clicked(object parameter)
        {        }

        


        public void DirectoryChanged(DirectoryViewModel parameter)
        {
            if (parameter.IsSelected)
            {
                SelectedDirectory = parameter;
            }
        }
    }
}