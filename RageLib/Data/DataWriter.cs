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
using System.Numerics;

namespace RageLib.Data
{
    /// <summary>
    /// Represents a data writer.
    /// </summary>
    public class DataWriter
    {
        private Stream baseStream;

        public bool EndianessMatchesArchitecture { get; protected set; }

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
            this.EndianessMatchesArchitecture = DataHelpers.EndianessMatchesCurrentArchitecture(endianess);
        }

        /// <summary>
        /// Writes data to the underlying stream. This is the only method that directly accesses
        /// the data in the underlying stream.
        /// </summary>
        protected virtual void WriteToStream(byte[] value, bool ignoreEndianess = false)
        {
            if (!ignoreEndianess && !EndianessMatchesArchitecture)
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

        /// <summary>
        /// Writes a vector with two single precision floating point values
        /// </summary>
        /// <param name="value"></param>
        public void Write(Vector2 value)
        {
            Write(value.X);
            Write(value.Y);
        }

        /// <summary>
        /// Writes a vector with three single precision floating point values
        /// </summary>
        /// <param name="value"></param>
        public void Write(Vector3 value)
        {
            Write(value.X);
            Write(value.Y);
            Write(value.Z);
        }

        /// <summary>
        /// Writes a vector with four single precision floating point values
        /// </summary>
        /// <param name="value"></param>
        public void Write(Vector4 value)
        {
            Write(value.X);
            Write(value.Y);
            Write(value.Z);
            Write(value.W);
        }

        /// <summary>
        /// Writes a matrix with sixteen single precision floating point values
        /// </summary>
        /// <param name="value"></param>
        public void Write(Matrix4x4 value)
        {
            Write(value.M11);
            Write(value.M21);
            Write(value.M31);
            Write(value.M41);
            Write(value.M12);
            Write(value.M22);
            Write(value.M32);
            Write(value.M42);
            Write(value.M13);
            Write(value.M23);
            Write(value.M33);
            Write(value.M43);
            Write(value.M14);
            Write(value.M24);
            Write(value.M34);
            Write(value.M44);
        }
    }
}