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

using RageLib.Helpers;
using RageLib.ResourceWrappers;

namespace TextureTool.Models
{
    public class TextureModel
    {
        private ITexture texture;

        public ITexture Texture
        {
            get
            {
                return texture;
            }
        }

        public string Name
        {
            get
            {
                return texture.Name;
            }
            set
            {
                texture.Name = value;
            }
        }
        
        public TextureModel(ITexture texture)
        {
            this.texture = texture;
        }

        public void Import(string fileName)
        {
            try
            {
                // only DDS supported
                DDSIO.LoadTextureData(texture, fileName);
            }
            catch
            { }
        }

        public void Export(string fileName)
        {
            try
            {
                // only DDS supported
                DDSIO.SaveTextureData(texture, fileName);
            }
            catch
            { }
        }
    }
}
