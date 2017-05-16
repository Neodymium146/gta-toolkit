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

using RageLib.Resources.GTA5;
using RageLib.Resources.GTA5.PC.Drawables;
using RageLib.ResourceWrappers.Drawables;
using System;
using System.IO;

namespace RageLib.GTA5.ResourceWrappers.PC.Drawables
{
    public class DrawableFileWrapper_GTA5_pc : IDrawableFile
    {
        private GtaDrawable drawable;

        public IDrawable Drawable
        {
            get
            {
                return new DrawableWrapper_GTA5_pc(drawable);
            }
        }

        public void Load(Stream stream)
        {
            var resource = new ResourceFile_GTA5_pc<GtaDrawable>();
            resource.Load(stream);

            drawable = resource.ResourceData;
        }


        /// <summary>
        /// Loads the texture dictionary from a file.
        /// </summary>
        public void Load(string fileName)
        {
            var resource = new ResourceFile_GTA5_pc<GtaDrawable>();
            resource.Load(fileName);

            drawable = resource.ResourceData;
        }

        public void Save(Stream stream)
        {
            var resource = new ResourceFile_GTA5_pc<GtaDrawable>();
            resource.ResourceData = drawable;
            resource.Version = 165;
            resource.Save(stream);
        }


        /// <summary>
        /// Saves the texture dictionary to a file.
        /// </summary>
        public void Save(string fileName)
        {
            var resource = new ResourceFile_GTA5_pc<GtaDrawable>();
            resource.ResourceData = drawable;
            resource.Version = 165;
            resource.Save(fileName);
        }
    }
}
