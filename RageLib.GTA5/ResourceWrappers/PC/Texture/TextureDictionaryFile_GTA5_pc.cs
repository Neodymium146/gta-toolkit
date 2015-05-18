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

using RageLib.Resources.Common;
using RageLib.Resources.GTA5;
using RageLib.Resources.GTA5.PC.Texture;
using System;
using System.IO;

namespace RageLib.ResourceWrappers.GTA5.PC.Texture
{
    /// <summary>
    /// Represents a wrapper for a GTA5 PC texture dictionary file.
    /// </summary>
    public class TextureDictionaryFileWrapper_GTA5_pc : ITextureDictionaryFile
    {
        private TextureDictionary_GTA5_pc textureDictionary;

        /// <summary>
        /// Gets the texture dictionary.
        /// </summary>
        public ITextureDictionary TextureDictionary
        {
            get { return new TextureDictionaryWrapper_GTA5_pc(textureDictionary); }
        }

        public TextureDictionaryFileWrapper_GTA5_pc()
        {
            textureDictionary = new TextureDictionary_GTA5_pc();
            textureDictionary.Hashes = new ResourceSimpleArray<uint_r>();
            textureDictionary.Textures = new ResourcePointerArray64<Texture_GTA5_pc>();
        }

        /// <summary>
        /// Loads the texture dictionary from a file.
        /// </summary>
        public void Load(string fileName)
        {
            var resource = new ResourceFile_GTA5_pc<TextureDictionary_GTA5_pc>();
            resource.Load(fileName);

            textureDictionary = resource.ResourceData;
        }

        /// <summary>
        /// Saves the texture dictionary to a file.
        /// </summary>
        public void Save(string fileName)
        {
            var w = new TextureDictionaryWrapper_GTA5_pc(textureDictionary);
            w.UpdateClass();

            var resource = new ResourceFile_GTA5_pc<TextureDictionary_GTA5_pc>();
            resource.ResourceData = textureDictionary;
            resource.Version = 13;
            resource.Save(fileName);
        }

        public void Load(Stream stream)
        {
            var resource = new ResourceFile_GTA5_pc<TextureDictionary_GTA5_pc>();
            resource.Load(stream);

            if (resource.Version != 13)
                throw new Exception("version error");

            textureDictionary = resource.ResourceData;
        }

        public void Save(Stream stream)
        {
            var w = new TextureDictionaryWrapper_GTA5_pc(textureDictionary);
            w.UpdateClass();

            var resource = new ResourceFile_GTA5_pc<TextureDictionary_GTA5_pc>();
            resource.ResourceData = textureDictionary;
            resource.Version = 13;
            resource.Save(stream);
        }
    }
}