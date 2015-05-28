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

using RageLib.GTA5.ResourceWrappers.PC.Drawables;
using RageLib.ResourceWrappers;
using RageLib.ResourceWrappers.Drawables;
using RageLib.ResourceWrappers.GTA5.PC.Textures;
using System;

namespace TextureTool.Models
{
    public enum FileType
    {
        TextureDictionaryFile,
        DrawableFile,
        None
    }

    public class MainModel
    {
        private ITextureDictionaryFile textureDictionaryFile;
        private IDrawableFile drawableFile;
        private string fileName;

        public FileType FileType
        {
            get
            {
                if (textureDictionaryFile != null)
                {
                    return FileType.TextureDictionaryFile;
                }
                else if (drawableFile != null)
                {
                    return FileType.DrawableFile;
                }
                else
                {
                    return FileType.None;
                }
            }
        }

        public TextureDictionaryModel TextureDictionary
        {
            get
            {
                if (textureDictionaryFile != null)
                {
                    return new TextureDictionaryModel(textureDictionaryFile.TextureDictionary);
                }
                else if (drawableFile != null)
                {
                    if (drawableFile.Drawable.ShaderGroup != null &&
                        drawableFile.Drawable.ShaderGroup.TextureDictionary != null)
                    {
                        return new TextureDictionaryModel(drawableFile.Drawable.ShaderGroup.TextureDictionary);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
            }
        }

        public void New()
        {
            this.textureDictionaryFile = new TextureDictionaryFileWrapper_GTA5_pc();
            this.drawableFile = null;
            this.fileName = null;
        }

        public void Load(string fileName)
        {
            if (fileName.EndsWith(".ytd"))
            {
                this.textureDictionaryFile = new TextureDictionaryFileWrapper_GTA5_pc();
                this.textureDictionaryFile.Load(fileName);
                this.drawableFile = null;
                this.fileName = fileName;
            }
            else if (fileName.EndsWith(".ydr"))
            {
                this.textureDictionaryFile = null;
                this.drawableFile = new DrawableFileWrapper_GTA5_pc();
                this.drawableFile.Load(fileName);
                this.fileName = fileName;
            }
            else
            {
                throw new Exception("Unsupported file type.");
            }
        }

        public void Save(string fileName)
        {
            if (textureDictionaryFile != null)
            {
                this.textureDictionaryFile.Save(fileName);
                this.fileName = fileName;
            }
            else if (drawableFile != null)
            {
                this.drawableFile.Save(fileName);
                this.fileName = fileName;
            }          
        }
    }
}