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

namespace RageLib.Archives
{
    /// <summary>
    /// Represents a file in an archive.
    /// </summary>
    public interface IArchiveFile
    {
        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets the size of the file.
        /// </summary>
        long Size { get; }

        /////////////////////////////////////////////////////////////////////////////
        // import and export
        /////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Imports a file.
        /// </summary>
        void Import(string fileName);

        /// <summary>
        /// Imports a file.
        /// </summary>
        void Import(Stream stream);

        /// <summary>
        /// Exports a file.
        /// </summary>
        void Export(string fileName);

        /// <summary>
        /// Exports a file.
        /// </summary>
        void Export(Stream stream);
    }

    /// <summary>
    /// Represents a binary file in an archive.
    /// </summary>
    public interface IArchiveBinaryFile : IArchiveFile
    {
        /////////////////////////////////////////////////////////////////////////////
        // encryption...
        /////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets or sets a value indicating whether the file is encrypted.
        /// </summary>
        bool IsEncrypted { get; set; }

        /////////////////////////////////////////////////////////////////////////////
        // compression...
        /////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets or sets a value indicating whether the file is compressed.
        /// </summary>
        bool IsCompressed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the uncompressed size of the file. This 
        /// property can only be set if the file is compressed.
        /// </summary>
        long UncompressedSize { get; set; }

        /// <summary>
        /// Gets the compressed size of the file.
        /// </summary>
        long CompressedSize { get; }

        /////////////////////////////////////////////////////////////////////////////
        // file access
        /////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets the stream that respresents the possibly compressed and encrypted content of the file.
        /// </summary>
        Stream GetStream();
    }

    /// <summary>
    /// Represents a resource file in an archive.
    /// </summary>
    public interface IArchiveResourceFile : IArchiveFile
    { }
}