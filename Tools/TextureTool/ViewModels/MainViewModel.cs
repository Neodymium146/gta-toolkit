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

using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Input;
using TextureTool.Commands;
using TextureTool.Models;

namespace TextureTool.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private MainModel model;

        public ICommand NewCommand { get; private set; }
        public ICommand LoadCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand SaveAsCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }
        public ICommand ImportCommand { get; private set; }
        public ICommand ExportCommand { get; private set; }
        public ICommand ExportAllCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        private ObservableCollection<TextureViewModel> textures;
        public ObservableCollection<TextureViewModel> Textures
        {
            get
            {
                return textures;
            }
        }

        private TextureViewModel selectedTexture;
        public TextureViewModel SelectedTexture
        {
            get
            {
                return selectedTexture;
            }
            set
            {
                selectedTexture = value;
                NotifyPropertyChanged("SelectedTexture");
            }
        }



        public MainViewModel()
        {
            model = new MainModel();
            model.New();
            
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

        public void BuildTextureList()
        {
            textures = new ObservableCollection<TextureViewModel>();
            for (int index = 0; index < model.TextureList.Count; index++)
            {
                var texture = model.TextureList[index];
                var textureVM = new TextureViewModel(texture);
                textures.Add(textureVM);
            }

            NotifyPropertyChanged("Textures");
        }



        public void New_Execute(object parameter)
        {
            model.New();

            BuildTextureList();
        }

        public void Load_Execute(object parameter)
        {
            var openDialog = new OpenFileDialog();
            openDialog.FileName = "*.ytd";
            openDialog.Filter = "Texture dictionaries (.ytd)|*.ytd";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                model.Load(openDialog.FileName);
            }

            BuildTextureList();            
        }
        
        public bool Save_CanExecute(object parameter)
        {
            if (model.TextureList != null && !string.IsNullOrEmpty(model.FileName))
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
            if (model.TextureList != null)
                return true;
            else
                return false;
        }
        
        public void SaveAs_Execute(object parameter)
        {
            var saveDialog = new SaveFileDialog();
            saveDialog.FileName = model.FileName;
            saveDialog.Filter = "Texture dictionaries (.ytd)|*.ytd";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                model.Save(saveDialog.FileName);
            }
        }

        public void Exit_Execute(object parameter)
        {
            System.Windows.Application.Current.Shutdown();
        }
        
        public bool Import_CanExecute(object parameter)
        {
            if (model.TextureList != null)
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
                    model.Import(fileName);
            }

            BuildTextureList();
        }

        public bool Export_CanExecute(object parameter)
        {
            if (model.TextureList != null && selectedTexture != null)
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
                model.Export(SelectedTexture.GetModel(), exportDialog.FileName);
            }
        }
        
        public bool ExportAll_CanExecute(object parameter)
        {
            if (model.TextureList != null)
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
                    model.Export(texture.GetModel(), exportDialog.SelectedPath + "\\" + texture.Name + ".dds");
            }
        }
        
        public bool Delete_CanExecute(object parameter)
        {
            if (model.TextureList != null && selectedTexture != null)
                return true;
            else
                return false;
        }

        public void Delete_Execute(object parameter)
        {
            model.Delete(SelectedTexture.GetModel());

            BuildTextureList();
        }
    }
}