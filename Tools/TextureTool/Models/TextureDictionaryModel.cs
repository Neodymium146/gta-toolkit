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

using RageLib.ResourceWrappers;
using RageLib.ResourceWrappers.GTA5.PC.Textures;
using System;
using System.Collections.Generic;
using System.IO;

namespace TextureTool.Models
{
    public class TextureDictionaryModel
    {
        private ITextureDictionary textureDictionary;
        private string name;

        public ITextureDictionary TextureDictionary
        {
            get
            {
                return textureDictionary;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public List<TextureModel> Textures
        {
            get
            {
                var list = new List<TextureModel>();
                if (textureDictionary != null && TextureDictionary.Textures != null)
                {
                    foreach (var texture in textureDictionary.Textures)
                        list.Add(new TextureModel(texture));
                }
                return list;
            }
        }

        public TextureDictionaryModel(ITextureDictionary textureDictionary, string name = "")
        {
            this.textureDictionary = textureDictionary;
            this.name = name;
        }

        public void Import(string fileName, bool replaceOnly = false)
        {
            var info = new FileInfo(fileName);
            var name = info.Name.Replace(".dds", "");

            var existingTexture = (TextureModel)null;
            foreach (var texture in textureDictionary.Textures)
                if (texture.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    existingTexture = new TextureModel(texture);

            if (existingTexture != null)
            {
                existingTexture.Import(fileName);
            }
            else if (!replaceOnly)
            {
                var texture = new TextureWrapper_GTA5_pc();
                var textureModel = new TextureModel(texture);
                textureModel.Name = name;
                textureModel.Import(fileName);

                textureDictionary.Textures.Add(texture);
            }
        }

        public void Export(TextureModel texture, string fileName)
        {
            texture.Export(fileName);
        }

        public void Delete(TextureModel texture)
        {
            textureDictionary.Textures.Remove(texture.Texture);
        }
    }
}