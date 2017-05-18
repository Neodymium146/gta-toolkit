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
using RageLib.Resources.GTA5.PC.Fragments;
using RageLib.ResourceWrappers.Fragments;
using System;
using System.IO;

namespace RageLib.GTA5.ResourceWrappers.PC.Fragments
{
    /// <summary>
    /// Represents a wrapper for a GTA5 PC fragment file.
    /// </summary>
    public class FragmentFileWrapper_GTA5_pc : IFragmentFile
    {
        private FragType fragType;

        /// <summary>
        /// Gets the fragtype.
        /// </summary>
        public IFragType FragType
        {
            get { return new FragTypeWrapper_GTA5_pc(fragType); }
        }

        public FragmentFileWrapper_GTA5_pc()
        {
            fragType = new FragType();
        }

        public void Load(string fileName)
        {
            var resource = new ResourceFile_GTA5_pc<FragType>();
            resource.Load(fileName);

            fragType = resource.ResourceData;
        }

        public void Save(string fileName)
        {
            var w = new FragTypeWrapper_GTA5_pc(fragType);
            w.UpdateClass();

            var resource = new ResourceFile_GTA5_pc<FragType>();
            resource.ResourceData = fragType;
            resource.Version = 162;
            resource.Save(fileName);
        }

        public void Load(Stream stream)
        {
            var resource = new ResourceFile_GTA5_pc<FragType>();
            resource.Load(stream);

            if (resource.Version != 162)
                throw new Exception("version error");

            fragType = resource.ResourceData;
        }

        public void Save(Stream stream)
        {
            var w = new FragTypeWrapper_GTA5_pc(fragType);
            w.UpdateClass();

            var resource = new ResourceFile_GTA5_pc<FragType>();
            resource.ResourceData = fragType;
            resource.Version = 162;
            resource.Save(stream);
        }
    }
}
