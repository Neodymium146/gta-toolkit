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

using System.IO;

namespace RageLib.ResourceWrappers
{
    /// <summary>
    /// Represents a resource file.
    /// </summary>
    public interface IResourceFile
    {
        /// <summary>
        /// Loads the resource from a file.
        /// </summary>
        void Load(string fileName);

        /// <summary>
        /// Loads the resource from a stream.
        /// </summary>
        void Load(Stream stream);

        /// <summary>
        /// Saves the resource to a file.
        /// </summary>
        void Save(string fileName);

        /// <summary>
        /// Saves the resource to a stream.
        /// </summary>
        void Save(Stream stream);
    }
}
