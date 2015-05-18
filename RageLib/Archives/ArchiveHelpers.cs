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

using System;
using System.Collections.Generic;
using System.IO;

namespace RageLib.Archives
{
    public class DataBlock
    {
        public long Offset { get; set; }
        public long Length { get; set; }
        public object Tag { get; set; }

        public DataBlock(long offset, long length, object tag = null)
        {
            this.Offset = offset;
            this.Length = length;
            this.Tag = tag;
        }
    }

    public static class ArchiveHelpers
    {
        private const int BUFFER_SIZE = 16384;

        /// <summary>
        /// Given a list of data blocks, this method finds the maximum length of a specified data block.
        /// </summary>
        public static long FindSpace(List<DataBlock> blocks, DataBlock item)
        {
            // sort list...
            blocks.Sort(
                delegate (DataBlock a, DataBlock b)
                {
                    if (a.Offset != b.Offset)
                        return a.Offset.CompareTo(b.Offset);
                    else
                        return a.Offset.CompareTo(b.Offset);
                }
            );
            
            // find smallest follow element
            DataBlock next = null;
            foreach (var x in blocks)
            {
                if ((x != item) && (x.Offset >= item.Offset))
                {
                    if (next == null)
                    {
                        next = x;
                    }
                    else
                    {
                        if (x.Offset < next.Offset)
                            next = x;
                    }
                }

            }

            if (next == null)
                return long.MaxValue;
            
            return next.Offset - item.Offset;
        }

        /// <summary>
        /// Given a list of data blocks, this method finds an block of empty space of specified length.
        /// </summary>
        public static long FindOffset(List<DataBlock> blocks, long neededSpace, long blockSize = 1)
        {
            var lst = new List<DataBlock>();
            lst.AddRange(blocks);

            // sort list...
            lst.Sort(
                delegate (DataBlock a, DataBlock b)
                {
                    if (a.Offset != b.Offset)
                        return a.Offset.CompareTo(b.Offset);
                    else
                        return a.Offset.CompareTo(b.Offset);
                }
            );

            if (lst.Count == 0)
                return 0;

            // patch...
            for (int i = 0; i < lst.Count - 1; i++)
            {
                lst[i].Length = Math.Min(lst[i].Length, lst[i + 1].Offset - lst[i].Offset);
            }
            
            long offset = 0;
            for (int i = 0; i < lst.Count; i++)
            {
                long len = lst[i].Offset - offset;
                if (len >= neededSpace)
                    return offset;

                offset = lst[i].Offset + lst[i].Length;
                offset = (long)Math.Ceiling((double)offset / (double)blockSize) * blockSize;
            }

            return offset;
        }

        public static void MoveBytes(Stream stream, long sourceOffset, long destinationOffset, long length)
        {
            var buffer = new byte[BUFFER_SIZE];
            while (length > 0)
            {
                // read...
                stream.Position = sourceOffset;
                int i = stream.Read(buffer, 0, (int)Math.Min(length, BUFFER_SIZE));

                // write...
                stream.Position = destinationOffset;
                stream.Write(buffer, 0, i);

                sourceOffset += i;
                destinationOffset += i;
                length -= i;
            }
        }
    }
}
