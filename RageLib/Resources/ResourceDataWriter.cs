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

using RageLib.Data;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace RageLib.Resources
{
    /// <summary>
    /// Represents a resource data writer.
    /// </summary>
    public class ResourceDataWriter : DataWriter
    {
        private const long VIRTUAL_BASE = 0x50000000;
        private const long PHYSICAL_BASE = 0x60000000;

        private readonly Stream virtualStream;
        private readonly Stream physicalStream;

        /// <summary>
        /// Gets the length of the underlying stream.
        /// </summary>
        public override long Length => -1;

        /// <summary>
        /// Gets or sets the position within the underlying stream.
        /// </summary>
        public override long Position { get; set; }

        /// <summary>
        /// Initializes a new resource data reader for the specified system- and graphics-stream.
        /// </summary>
        public ResourceDataWriter(Stream virtualStream, Stream physicalStream, Endianess endianess = Endianess.LittleEndian)
            : base((Stream)null, endianess)
        {
            this.virtualStream = virtualStream;
            this.physicalStream = physicalStream;
        }

        /// <summary>
        /// Writes data to the underlying stream. This is the only method that directly accesses
        /// the data in the underlying stream.
        /// </summary>
        protected override void WriteToStreamRaw(Span<byte> value)
        {
            Stream stream;
            long basePosition;

            if ((Position & VIRTUAL_BASE) == VIRTUAL_BASE)
            {
                // write to virtual stream...
                stream = virtualStream;
                basePosition = VIRTUAL_BASE;
            }
            else if ((Position & PHYSICAL_BASE) == PHYSICAL_BASE)
            {
                // write to physical stream...
                stream = physicalStream;
                basePosition = PHYSICAL_BASE;
            }
            else
                throw new Exception("illegal position!");

            stream.Position = Position & ~basePosition;

            stream.Write(value);

            Position = stream.Position | basePosition;
            return;
        }

        /// <summary>
        /// Writes data to the underlying stream. This is the only method that directly accesses
        /// the data in the underlying stream.
        /// </summary>
        protected override void WriteToStreamRaw(byte value)
        {
            Stream stream;
            long basePosition;

            if ((Position & VIRTUAL_BASE) == VIRTUAL_BASE)
            {
                // write to virtual stream...
                stream = virtualStream;
                basePosition = VIRTUAL_BASE;
            }
            else if ((Position & PHYSICAL_BASE) == PHYSICAL_BASE)
            {
                // write to physical stream...
                stream = physicalStream;
                basePosition = PHYSICAL_BASE;
            }
            else
                throw new Exception("illegal position!");

            stream.Position = Position & ~basePosition;

            stream.WriteByte(value);

            Position = stream.Position | basePosition;
            return;
        }

        /// <summary>
        /// Writes a block.
        /// </summary>
        public void WriteBlock(IResourceBlock value)
        {
            value.Write(this);
        }
    }
}