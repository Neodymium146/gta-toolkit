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

using RageLib.Hash;
using RageLib.Resources;
using RageLib.Resources.Common;
using RageLib.Resources.GTA5.PC.Textures;
using System;
using System.Collections.Generic;

namespace RageLib.ResourceWrappers.GTA5.PC.Textures
{
    /// <summary>
    /// Represents a wrapper for a GTA5 PC texture dictionary.
    /// </summary>
    public class TextureDictionaryWrapper_GTA5_pc : ITextureDictionary
    {
        private TextureDictionary_GTA5_pc textureDictionary;

        public ITextureList Textures
        {
            get
            {
                if (textureDictionary.Textures != null)
                    return new TextureListWrapper_GTA5_pc(textureDictionary.Textures);
                else
                    return null;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public TextureDictionaryWrapper_GTA5_pc()
        { }

        public TextureDictionaryWrapper_GTA5_pc(TextureDictionary_GTA5_pc baseClass)
        {
            this.textureDictionary = baseClass;
        }

        public void UpdateClass()
        {

            // structure

            textureDictionary.VFT = 0x40570fd0;
            textureDictionary.Unknown_4h = 0x00000001;
            textureDictionary.Unknown_10h = 0x00000000;
            textureDictionary.Unknown_14h = 0x00000000;
            textureDictionary.Unknown_18h = 0x00000001;
            textureDictionary.Unknown_1Ch = 0x00000000;

            // references

            textureDictionary.PagesInfo = null;

            if (textureDictionary.Textures != null)
            {

                var theHashList = new List<uint>();
                foreach (var texture in textureDictionary.Textures)
                {
                    uint hash = Jenkins.Hash((string)texture.Name);
                    theHashList.Add(hash);
                }
                theHashList.Sort();

                var bak = textureDictionary.Textures;
                textureDictionary.TextureNameHashes.Entries = new ResourceSimpleArray<uint_r>();
                textureDictionary.Textures.Entries = new ResourcePointerArray64<Texture_GTA5_pc>();
                foreach (uint x in theHashList)
                {
                    textureDictionary.TextureNameHashes.Entries.Add((uint_r)x);
                    foreach (var g in bak)
                    {
                        uint tx = Jenkins.Hash((string)g.Name);
                        if (tx == x)
                            textureDictionary.Textures.Add(g);
                    }
                }

                //textureDictionary.Hashes = new ResourceSimpleArray<uint_r>();            
                //foreach (var texture in textureDictionary.Textures)
                //{
                //    uint hash = Jenkins.Hash((string)texture.Name);
                //    textureDictionary.Hashes.Add((uint_r)hash);
                //}


                //var bak = textureDictionary.Textures;
                //textureDictionary.Textures = new ResourcePointerArray64<Texture_GTA5_pc>();


                foreach (var texture in textureDictionary.Textures)
                {
                    (new TextureWrapper_GTA5_pc(texture)).UpdateClass();
                }

            }
            else
            {



            }

          

        }

        public TextureDictionary_GTA5_pc GetObject()
        {
            return textureDictionary;
        }

    }
}