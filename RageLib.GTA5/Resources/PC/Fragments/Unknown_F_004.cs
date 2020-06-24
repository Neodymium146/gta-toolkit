/*
    Copyright(c) 2017 Neodymium

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

using RageLib.Resources.GTA5.PC.Drawables;
using System;
using System.Numerics;

namespace RageLib.Resources.GTA5.PC.Fragments
{
    public class Unknown_F_004 : ResourceSystemBlock
    {
        public override long BlockLength => 0x70;

        // structure data
        public Vector3 Unknown_0h;
        public uint NaN_Ch; // 0x7F800001
        public Vector3 Unknown_10h;
        public uint NaN_1Ch; // 0x7F800001
        public Vector3 Unknown_20h;
        public uint NaN_2Ch; // 0x7F800001
        public float Unknown_30h;
        public float Unknown_34h;
        public float Unknown_38h;
        public float Unknown_3Ch;
        public VertexDeclaration VertexDeclaration;
        public float Unknown_50h;
        public ushort Unknown_54h;
        public ushort Unknown_56h;
        public float Unknown_58h;
        public float Unknown_5Ch;
        public Vector3 Unknown_60h;
        public uint NaN_6Ch; // 0x7F800001

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.Unknown_0h = reader.ReadVector3();
            this.NaN_Ch = reader.ReadUInt32();
            this.Unknown_10h = reader.ReadVector3();
            this.NaN_1Ch = reader.ReadUInt32();
            this.Unknown_20h = reader.ReadVector3();
            this.NaN_2Ch = reader.ReadUInt32();
            this.Unknown_30h = reader.ReadSingle();
            this.Unknown_34h = reader.ReadSingle();
            this.Unknown_38h = reader.ReadSingle();
            this.Unknown_3Ch = reader.ReadSingle();
            this.VertexDeclaration = reader.ReadBlock<VertexDeclaration>();
            this.Unknown_50h = reader.ReadSingle();
            this.Unknown_54h = reader.ReadUInt16();
            this.Unknown_56h = reader.ReadUInt16();
            this.Unknown_58h = reader.ReadSingle();
            this.Unknown_5Ch = reader.ReadSingle();
            this.Unknown_60h = reader.ReadVector3();
            this.NaN_6Ch = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // write structure data
            writer.Write(this.Unknown_0h);
            writer.Write(this.NaN_Ch);
            writer.Write(this.Unknown_10h);
            writer.Write(this.NaN_1Ch);
            writer.Write(this.Unknown_20h);
            writer.Write(this.NaN_2Ch);
            writer.Write(this.Unknown_30h);
            writer.Write(this.Unknown_34h);
            writer.Write(this.Unknown_38h);
            writer.Write(this.Unknown_3Ch);
            writer.WriteBlock(this.VertexDeclaration);
            writer.Write(this.Unknown_50h);
            writer.Write(this.Unknown_54h);
            writer.Write(this.Unknown_56h);
            writer.Write(this.Unknown_58h);
            writer.Write(this.Unknown_5Ch);
            writer.Write(this.Unknown_60h);
            writer.Write(this.NaN_6Ch);
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(0x40, VertexDeclaration)
            };
        }
    }
}
