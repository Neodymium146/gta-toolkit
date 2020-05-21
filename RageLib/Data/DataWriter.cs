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
using System.IO;

namespace RageLib.Data
{
    /// <summary>
    /// Represents a data writer.
    /// </summary>
    public class DataWriter
    {
        private Stream baseStream;
        
        /// <summary>
        /// Gets or sets the endianess of the underlying stream.
        /// </summary>
        public Endianess Endianess
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the length of the underlying stream.
        /// </summary>
        public virtual long Length
        {
            get
            {
                return baseStream.Length;
            }
        }

        /// <summary>
        /// Gets or sets the position within the underlying stream.
        /// </summary>
        public virtual long Position
        {
            get
            {
                return baseStream.Position;
            }
            set
            {
                baseStream.Position = value;
            }
        }
                
        /// <summary>
        /// Initializes a new data writer for the specified stream.
        /// </summary>
        public DataWriter(Stream stream, Endianess endianess = Endianess.LittleEndian)
        {
            this.baseStream = stream;
            this.Endianess = endianess;
        }

        /// <summary>
        /// Writes data to the underlying stream. This is the only method that directly accesses
        /// the data in the underlying stream.
        /// </summary>
        protected virtual void WriteToStream(byte[] value, bool ignoreEndianess = false)
        {
            if (!ignoreEndianess && (!DataUtilities.EndianessMatchesCurrentArchitecture(Endianess)))
            {
                var buffer = (byte[])value.Clone();
                Array.Reverse(buffer);
                baseStream.Write(buffer, 0, buffer.Length);
            }
            else
            {
                baseStream.Write(value, 0, value.Length);
            }
        }
        
        /// <summary>
        /// Writes a byte.
        /// </summary>
        public void Write(byte value)
        {
            WriteToStream(new byte[] { value });
        }

        /// <summary>
        /// Writes a sequence of bytes.
        /// </summary>
        public void Write(byte[] value)
        {
            WriteToStream(value, true);
        }

        /// <summary>
        /// Writes a signed 16-bit value.
        /// </summary>
        public void Write(short value)
        {
            WriteToStream(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Writes a signed 32-bit value.
        /// </summary>
        public void Write(int value)
        {
            WriteToStream(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Writes a signed 64-bit value.
        /// </summary>
        public void Write(long value)
        {
            WriteToStream(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Writes an unsigned 16-bit value.
        /// </summary>
        public void Write(ushort value)
        {
            WriteToStream(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Writes an unsigned 32-bit value.
        /// </summary>
        public void Write(uint value)
        {
            WriteToStream(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Writes an unsigned 64-bit value.
        /// </summary>
        public void Write(ulong value)
        {
            WriteToStream(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Writes a single precision floating point value.
        /// </summary>
        public void Write(float value)
        {
            WriteToStream(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Writes a double precision floating point value.
        /// </summary>
        public void Write(double value)
        {
            WriteToStream(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Writes a string.
        /// </summary>
        public void Write(string value)
        {
            foreach (var c in value)
                Write((byte)c);
            Write((byte)0);
        }
    }
}