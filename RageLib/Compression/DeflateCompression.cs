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
using System.IO.Compression;

namespace RageLib.Compression
{
    /// <summary>
    /// Represents a deflate compression algorithm.
    /// </summary>
    public class DeflateCompression : ICompressionAlgorithm
    {
        /// <summary>
        /// Compresses data.
        /// </summary>
        public byte[] Compress(byte[] data)
        {
            return CompressData(data);
        }

        /// <summary>
        /// Decompresses data.
        /// </summary>
        public byte[] Decompress(byte[] data, int decompressedLength)
        {
            return DecompressData(data, decompressedLength);
        }

        /// <summary>
        /// Compresses data.
        /// </summary>
        public static byte[] CompressData(byte[] data)
        {
            var dataStream = new MemoryStream(data);
            var deflateStream = new DeflateStream(dataStream, CompressionMode.Compress);

            deflateStream.Write(data, 0, data.Length);

            var buffer = new byte[dataStream.Length];
            dataStream.Position = 0;
            dataStream.Read(buffer, 0, (int)dataStream.Length);

            deflateStream.Close();

            return buffer;
        }

        /// <summary>
        /// Decompresses data.
        /// </summary>
        public static byte[] DecompressData(byte[] data, int decompressedLength)
        {
            var dataStream = new MemoryStream(data);
            var deflateStream = new DeflateStream(dataStream, CompressionMode.Decompress);

            var buffer = new byte[decompressedLength];
            deflateStream.Read(buffer, 0, decompressedLength);
            deflateStream.Close();

            return buffer;
        }
    }
}