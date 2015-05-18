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

namespace RageLib.Archives
{
    /// <summary>
    /// Represents a directory in an archive.
    /// </summary>
    public interface IArchiveDirectory
    {
        /// <summary>
        /// Gets or sets the name of the directory.
        /// </summary>
        string Name { get; set; }

        /////////////////////////////////////////////////////////////////////////////
        // directory management
        /////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Returns a directory list from the current directory. 
        /// </summary>
        IArchiveDirectory[] GetDirectories();

        /// <summary>
        /// Returns a directory from the current directory. 
        /// </summary>
        IArchiveDirectory GetDirectory(string name);

        /// <summary>
        /// Creates a new directory inside this directory.
        /// </summary>
        IArchiveDirectory CreateDirectory();

        /// <summary>
        /// Deletes an existing directory inside this directory.
        /// </summary>
        void DeleteDirectory(IArchiveDirectory directory);

        /////////////////////////////////////////////////////////////////////////////
        // file management
        /////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Returns a file list from the current directory. 
        /// </summary>
        IArchiveFile[] GetFiles();

        /// <summary>
        /// Returns a file from the current directory. 
        /// </summary>
        IArchiveFile GetFile(string name);

        /// <summary>
        /// Creates a new binary file inside this directory.
        /// </summary>
        IArchiveBinaryFile CreateBinaryFile();

        /// <summary>
        /// Creates a new resource file inside this directory.
        /// </summary>
        IArchiveResourceFile CreateResourceFile();

        /// <summary>
        /// Deletes an existing file inside this directory.
        /// </summary>
        void DeleteFile(IArchiveFile file);
    }
}