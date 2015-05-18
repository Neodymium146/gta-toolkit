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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace RageLib.Helpers
{
    public static class HashSearch
    {
        private const int BLOCK_LENGTH = 1048576;
        private const int ALIGN_LENGTH = 16;

        public static byte[] SearchHash(Stream stream, byte[] hash, int length = 32)
        {
            return SearchHashes(stream, new List<byte[]> { hash }, length)[0];
        }

        public static byte[][] SearchHashes(Stream stream, IList<byte[]> hashes, int length = 32)
        {
            var result = new byte[hashes.Count][];           

            Parallel.For(0, (int)(stream.Length / BLOCK_LENGTH), (int k) => {

                var hashProvider = new SHA1CryptoServiceProvider();
                var buffer = new byte[length];
                for (int i = 0; i < (BLOCK_LENGTH / ALIGN_LENGTH); i++)
                {
                    var position = k * BLOCK_LENGTH + i * ALIGN_LENGTH;
                    if (position >= stream.Length)
                        continue;

                    lock (stream)
                    {
                        stream.Position = position;
                        stream.Read(buffer, 0, length);
                    }

                    var hash = hashProvider.ComputeHash(buffer);
                    for (int j = 0; j < hashes.Count; j++)
                        if (hash.SequenceEqual(hashes[j]))
                            result[j] = (byte[])buffer.Clone();
                }
                

            });

            return result;
        }
    }
}