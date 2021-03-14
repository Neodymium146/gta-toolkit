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
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace RageLib.Data
{
    /// <summary>
    /// Represents a data reader.
    /// </summary>
    public class DataReader
    {
        private readonly Stream baseStream;
        protected readonly bool endianessEqualsHostArchitecture;

        /// <summary>
        /// Gets or sets the endianess of the underlying stream.
        /// </summary>
        public Endianess Endianess { get; set; }

        /// <summary>
        /// Gets the length of the underlying stream.
        /// </summary>
        public virtual long Length => baseStream.Length;

        /// <summary>
        /// Gets or sets the position within the underlying stream.
        /// </summary>
        public virtual long Position
        {
            get => baseStream.Position;
            set => baseStream.Position = value;
        }

        /// <summary>
        /// Initializes a new data reader for the specified stream.
        /// </summary>
        public DataReader(Stream stream, Endianess endianess = Endianess.LittleEndian)
        {
            this.baseStream = stream;
            this.Endianess = endianess;
            this.endianessEqualsHostArchitecture = endianess.EqualsHostArchitecture();
        }

        
        protected Buffer<T> ReadFromStream<T>(int count) where T : unmanaged
        {
            Buffer<T> buffer = new Buffer<T>(count);
            ReadFromStreamRaw(buffer.BytesSpan);

            // handle endianess
            if (!endianessEqualsHostArchitecture)
                buffer.Reverse();

            return buffer;
        }

        /// <summary>
        /// Reads data from the underlying stream. This is the only method that directly accesses
        /// the data in the underlying stream.
        /// </summary>
        protected virtual void ReadFromStreamRaw(Span<byte> span)
        {
            baseStream.Read(span);
        }

        protected virtual byte ReadByteFromStreamRaw()
        {
            return (byte)baseStream.ReadByte();
        }

        /// <summary>
        /// Reads a byte.
        /// </summary>
        public byte ReadByte()
        {
            return ReadByteFromStreamRaw();
        }

        /// <summary>
        /// Reads a sequence of bytes.
        /// </summary>
        public byte[] ReadBytes(int count)
        {
            byte[] array = new byte[count];
            ReadFromStreamRaw(array.AsSpan());
            return array;
        }

        /// <summary>
        /// Reads a signed 16-bit value.
        /// </summary>
        public short ReadInt16()
        {
            using Buffer<short> buffer = ReadFromStream<short>(1);
            return buffer.Span[0];
        }

        /// <summary>
        /// Reads a signed 32-bit value.
        /// </summary>
        public int ReadInt32()
        {
            using Buffer<int> buffer = ReadFromStream<int>(1);
            return buffer.Span[0];
        }

        /// <summary>
        /// Reads a signed 64-bit value.
        /// </summary>
        public long ReadInt64()
        {
            using Buffer<long> buffer = ReadFromStream<long>(1);
            return buffer.Span[0];
        }

        /// <summary>
        /// Reads an unsigned 16-bit value.
        /// </summary>
        public ushort ReadUInt16()
        {
            using Buffer<ushort> buffer = ReadFromStream<ushort>(1);
            return buffer.Span[0];
        }

        /// <summary>
        /// Reads an unsigned 32-bit value.
        /// </summary>
        public uint ReadUInt32()
        {
            using Buffer<uint> buffer = ReadFromStream<uint>(1);
            return buffer.Span[0];
        }

        /// <summary>
        /// Reads an unsigned 64-bit value.
        /// </summary>
        public ulong ReadUInt64()
        {
            using Buffer<ulong> buffer = ReadFromStream<ulong>(1);
            return buffer.Span[0];
        }

        /// <summary>
        /// Reads a single precision floating point value.
        /// </summary>
        public float ReadSingle()
        {
            using Buffer<float> buffer = ReadFromStream<float>(1);
            return buffer.Span[0];
        }

        /// <summary>
        /// Reads a double precision floating point value.
        /// </summary>
        public double ReadDouble()
        {
            using Buffer<double> buffer = ReadFromStream<double>(1);
            return buffer.Span[0];
        }

        /// <summary>
        /// Reads a string.
        /// </summary>
        public string ReadString()
        {
            // TODO: is 256 a reasonable max length for a string?
            using Buffer<byte> buffer = new Buffer<byte>(256);
            {
                int i = 0;
                byte c;
                while ((c = ReadByteFromStreamRaw()) != 0)
                {
                    buffer.Bytes[i] = c;
                    i++;
                }
                return Encoding.ASCII.GetString(buffer.Span.Slice(0, i));
            }
        }

        /// <summary>
        /// Reads a string of known length.
        /// </summary>
        public string ReadString(int length)
        {
            using Buffer<byte> buffer = ReadFromStream<byte>(length);
            return Encoding.ASCII.GetString(buffer.Span);
        }

        /// <summary>
        /// Reads a vector with two single precision floating point values.
        /// </summary>
        /// <returns></returns>
        public Vector2 ReadVector2()
        {
            using Buffer<float> buffer = ReadFromStream<float>(2);
            return MemoryMarshal.Cast<float, Vector2>(buffer.Span)[0];
        }

        /// <summary>
        /// Reads a vector with three single precision floating point values.
        /// </summary>
        /// <returns></returns>
        public Vector3 ReadVector3()
        {
            using Buffer<float> buffer = ReadFromStream<float>(3);
            return MemoryMarshal.Cast<float, Vector3>(buffer.Span)[0];
        }

        /// <summary>
        /// Reads a vector with four single precision floating point values.
        /// </summary>
        /// <returns></returns>
        public Vector4 ReadVector4()
        {
            using Buffer<float> buffer = ReadFromStream<float>(4);
            return MemoryMarshal.Cast<float, Vector4>(buffer.Span)[0];
        }

        /// <summary>
        /// Reads a quaternion with four single precision floating point values.
        /// </summary>
        /// <returns></returns>
        public Quaternion ReadQuaternion()
        {
            using Buffer<float> buffer = ReadFromStream<float>(4);
            return MemoryMarshal.Cast<float, Quaternion>(buffer.Span)[0];
        }

        /// <summary>
        /// Reads a matrix with sixteen single precision floating point values.
        /// </summary>
        /// <returns></returns>
        public Matrix4x4 ReadMatrix4x4()
        {
            using Buffer<float> buffer = ReadFromStream<float>(16);
            return MemoryMarshal.Cast<float, Matrix4x4>(buffer.Span)[0];
        }

        public T[] ReadArray<T>(int count) where T : unmanaged
        {
            T[] array = new T[count];
            var bytes = MemoryMarshal.AsBytes(array.AsSpan());
            ReadFromStreamRaw(bytes);

            // handle endianess
            if (!endianessEqualsHostArchitecture)
            {
                if (Unsafe.SizeOf<T>() > 1)
                {
                    for (int i = 0; i < count; i++)
                        bytes.Slice(i * Unsafe.SizeOf<T>(), Unsafe.SizeOf<T>()).Reverse();
                }
            }

            return array;
        }
    }
}