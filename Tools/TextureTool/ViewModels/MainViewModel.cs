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

using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Input;
using TextureTool.Commands;
using TextureTool.Models;

namespace TextureTool.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private MainModel model;
        private string title;
        private bool textureFilesVisibility;
        private List<TextureDictionaryViewModel> textureDictionaries;
        private TextureDictionaryViewModel selectedTextureDictionary;
        private List<TextureViewModel> textures;
        private TextureViewModel selectedTexture;

        public ICommand NewCommand { get; private set; }
        public ICommand LoadCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand SaveAsCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }
        public ICommand ImportCommand { get; private set; }
        public ICommand ExportCommand { get; private set; }
        public ICommand ExportAllCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
               
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                NotifyPropertyChanged();
            }
        }

        public bool TextureFilesVisibility
        {
            get
            {
                return textureFilesVisibility;
            }
            set
            {
                textureFilesVisibility = value;
                NotifyPropertyChanged();
            }
        }

        public List<TextureDictionaryViewModel> TextureDictionaries
        {
            get
            {
                return textureDictionaries;
            }
            set
            {
                textureDictionaries = value;
                NotifyPropertyChanged();
            }
        }

        public TextureDictionaryViewModel SelectedTextureDictionary
        {
            get
            {
                return selectedTextureDictionary;
            }
            set
            {
                selectedTextureDictionary = value;
                NotifyPropertyChanged();

                // update textures...
                BuildTextureList();
            }
        }

        public List<TextureViewModel> Textures
        {
            get
            {
                return textures;
            }
            set
            {
                textures = value;
                NotifyPropertyChanged();
            }
        }
               
        public TextureViewModel SelectedTexture
        {
            get
            {
                return selectedTexture;
            }
            set
            {
                selectedTexture = value;
                NotifyPropertyChanged();
            }
        }

        public MainViewModel()
        {
            model = new MainModel();
            //model.New();

            Title = "Texture Toolkit";
            
            NewCommand = new ActionCommand(New_Execute);
            LoadCommand = new ActionCommand(Load_Execute);
            SaveCommand = new ActionCommand(Save_Execute, Save_CanExecute);
            SaveAsCommand = new ActionCommand(SaveAs_Execute, SaveAs_CanExecute);
            ExitCommand = new ActionCommand(Exit_Execute);
            ImportCommand = new ActionCommand(Import_Execute, Import_CanExecute);
            ExportCommand = new ActionCommand(Export_Execute, Export_CanExecute);
            ExportAllCommand = new ActionCommand(ExportAll_Execute, ExportAll_CanExecute);
            DeleteCommand = new ActionCommand(Delete_Execute, Delete_CanExecute);
        }

        public void BuildTextureDictionaryList()
        {
            var list = new List<TextureDictionaryViewModel>();
            for (int index = 0; index < model.TextureDictionaries.Count; index++)
            {
                var vm = new TextureDictionaryViewModel(model.TextureDictionaries[index]);
                list.Add(vm);
            }

            TextureDictionaries = list;

            // select first texture dictionary
            if (TextureDictionaries.Count > 0)
                SelectedTextureDictionary = TextureDictionaries[0];
            else
                SelectedTextureDictionary = null;
        }

        public void BuildTextureList()
        {
            if (SelectedTextureDictionary != null)
            {
                var list = new List<TextureViewModel>();
                for (int index = 0; index < SelectedTextureDictionary.GetModel().Textures.Count; index++)
                {
                    var texture = SelectedTextureDictionary.GetModel().Textures[index];
                    var textureVM = new TextureViewModel(texture);
                    list.Add(textureVM);
                }
                
                Textures = list;
                if (Textures.Count > 0)
                    SelectedTexture = Textures[0];
            }
            else
            {
                Textures = null;
                SelectedTexture = null;
            }           
        }



        public void New_Execute(object parameter)
        {
            model.New();
            Title = "Texture Toolkit";
            TextureFilesVisibility = false;

            BuildTextureDictionaryList();
        }

        public void Load_Execute(object parameter)
        {
            var openDialog = new OpenFileDialog();
            openDialog.FileName = "*.*";
            openDialog.Filter = "All files|*.*|Texture dictionaries (.ytd)|*.ytd|Drawable (.ydr)|*.ydr|Drawable dictionaries (.ydd)|*.ydd";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                model.Load(openDialog.FileName);
                Title = openDialog.FileName + " - Texture Toolkit";
                TextureFilesVisibility = model.FileType == FileType.DrawableDictionaryFile;
                BuildTextureDictionaryList();
            }
        }
        
        public bool Save_CanExecute(object parameter)
        {
            if (model.FileType != FileType.None && !string.IsNullOrEmpty(model.FileName))
                return true;
            else
                return false;
        }
        
        public void Save_Execute(object parameter)
        {
            model.Save(model.FileName);
        }

        public bool SaveAs_CanExecute(object parameter)
        {
            if (model.FileType != FileType.None)
                return true;
            else
                return false;
        }
        
        public void SaveAs_Execute(object parameter)
        {
            var saveDialog = new SaveFileDialog();
            saveDialog.FileName = model.FileName;
            saveDialog.Filter = "All files|*.*|Texture dictionaries (.ytd)|*.ytd|Drawable (.ydr)|*.ydr|Drawable dictionaries (.ydd)|*.ydd";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                model.Save(saveDialog.FileName);
                Title = saveDialog.FileName + " - Texture Toolkit";
            }
        }

        public void Exit_Execute(object parameter)
        {
            System.Windows.Application.Current.Shutdown();
        }
        
        public bool Import_CanExecute(object parameter)
        {
            if (SelectedTextureDictionary != null)
                return true;
            else
                return false;
        }

        public void Import_Execute(object parameter)
        {
            var importDialog = new OpenFileDialog();
            importDialog.FileName = "*.dds";
            importDialog.Filter = "DDS files (.dds)|*.dds";
            importDialog.Multiselect = true;
            if (importDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var fileName in importDialog.FileNames)
                    SelectedTextureDictionary.GetModel().Import(fileName, model.FileType != FileType.TextureDictionaryFile);
            }

            BuildTextureList();
        }

        public bool Export_CanExecute(object parameter)
        {
            if (SelectedTexture != null)
                return true;
            else
                return false;
        }

        public void Export_Execute(object parameter)
        {
            var exportDialog = new SaveFileDialog();
            exportDialog.FileName = SelectedTexture.Name + ".dds";
            exportDialog.Filter = "DDS files (.dds)|*.dds";
            if (exportDialog.ShowDialog() == DialogResult.OK)
            {
                SelectedTexture.GetModel().Export(exportDialog.FileName);
            }
        }
        
        public bool ExportAll_CanExecute(object parameter)
        {
            if (SelectedTextureDictionary != null)
                return true;
            else
                return false;
        }

        public void ExportAll_Execute(object parameter)
        {
            var exportDialog = new FolderBrowserDialog();
            if (exportDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var texture in Textures)
                    texture.GetModel().Export(exportDialog.SelectedPath + "\\" + texture.Name + ".dds");
            }
        }
        
        public bool Delete_CanExecute(object parameter)
        {
            if (model.FileType == FileType.TextureDictionaryFile && SelectedTexture != null)
                return true;
            else
                return false;
        }

        public void Delete_Execute(object parameter)
        {
            SelectedTextureDictionary.GetModel().Delete(SelectedTexture.GetModel());

            BuildTextureList();
        }
    }
}