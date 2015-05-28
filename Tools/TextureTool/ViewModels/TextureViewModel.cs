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

using RageLib.Compression;
using RageLib.ResourceWrappers;
using System.Windows.Media;
using TextureTool.Models;

namespace TextureTool.ViewModels
{
    public class TextureViewModel : BaseViewModel
    {
        private TextureModel model;

        public string Name
        {
            get
            {
                return model.Name;
            }
        }

        public string Size
        {
            get
            {
                return model.Texture.Width + "x" + model.Texture.Height;
            }
        }

        public int Levels
        {
            get
            {
                return model.Texture.MipMapLevels;
            }
        }

        public string Format
        {
            get
            {
                switch (model.Texture.Format)
                {
                    case TextureFormat.D3DFMT_DXT1: return "DXT1";
                    case TextureFormat.D3DFMT_DXT3: return "DXT3";
                    case TextureFormat.D3DFMT_DXT5: return "DXT5";
                    case TextureFormat.D3DFMT_ATI1: return "ATI1";
                    case TextureFormat.D3DFMT_ATI2: return "ATI2";
                    case TextureFormat.D3DFMT_BC7: return "BC7";
                    case TextureFormat.D3DFMT_A1R5G5B5: return "A1R5G5B5";
                    case TextureFormat.D3DFMT_A8: return "A8";
                    case TextureFormat.D3DFMT_L8: return "L8";
                    case TextureFormat.D3DFMT_A8B8G8R8: return "A8B8G8R8";
                    case TextureFormat.D3DFMT_A8R8G8B8: return "A8R8G8B8";
                    default: return "Unknown";
                }
            }
        }

        public ImageSource Image
        {
            get
            {
                var y = TextureHelper.GetRgbaImage(model.Texture, 0);
                return new RgbaBitmapSource(y, model.Texture.Width, model.Texture.Height);
            }
        }

        public TextureViewModel(TextureModel model)
        {
            this.model = model;
        }

        public TextureModel GetModel()
        {
            return model;
        }
    }
}