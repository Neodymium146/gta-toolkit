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

namespace RageLib.Resources.GTA5.PC.Drawables
{
    public class VertexBuffer_GTA5_pc : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 128; }
        }

        // structure data
        public uint VFT;
        public uint Unknown_4h;
        public ushort VertexStride;
        public ushort Unknown_Ah;
        public uint Unknown_Ch;
        public ulong DataPointer1;
        public uint VertexCount;
        public uint Unknown_1Ch;
        public ulong DataPointer2;
        public uint Unknown_28h;
        public uint Unknown_2Ch;
        public ulong InfoPointer;
        public uint Unknown_38h;
        public uint Unknown_3Ch;
        public uint Unknown_40h;
        public uint Unknown_44h;
        public uint Unknown_48h;
        public uint Unknown_4Ch;
        public uint Unknown_50h;
        public uint Unknown_54h;
        public uint Unknown_58h;
        public uint Unknown_5Ch;
        public uint Unknown_60h;
        public uint Unknown_64h;
        public uint Unknown_68h;
        public uint Unknown_6Ch;
        public uint Unknown_70h;
        public uint Unknown_74h;
        public uint Unknown_78h;
        public uint Unknown_7Ch;

        // reference data
        public VertexData_GTA5_pc Data1;
        public VertexData_GTA5_pc Data2;
        public VertexBufferInfo_GTA5_pc Info;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.VFT = reader.ReadUInt32();
            this.Unknown_4h = reader.ReadUInt32();
            this.VertexStride = reader.ReadUInt16();
            this.Unknown_Ah = reader.ReadUInt16();
            this.Unknown_Ch = reader.ReadUInt32();
            this.DataPointer1 = reader.ReadUInt64();
            this.VertexCount = reader.ReadUInt32();
            this.Unknown_1Ch = reader.ReadUInt32();
            this.DataPointer2 = reader.ReadUInt64();
            this.Unknown_28h = reader.ReadUInt32();
            this.Unknown_2Ch = reader.ReadUInt32();
            this.InfoPointer = reader.ReadUInt64();
            this.Unknown_38h = reader.ReadUInt32();
            this.Unknown_3Ch = reader.ReadUInt32();
            this.Unknown_40h = reader.ReadUInt32();
            this.Unknown_44h = reader.ReadUInt32();
            this.Unknown_48h = reader.ReadUInt32();
            this.Unknown_4Ch = reader.ReadUInt32();
            this.Unknown_50h = reader.ReadUInt32();
            this.Unknown_54h = reader.ReadUInt32();
            this.Unknown_58h = reader.ReadUInt32();
            this.Unknown_5Ch = reader.ReadUInt32();
            this.Unknown_60h = reader.ReadUInt32();
            this.Unknown_64h = reader.ReadUInt32();
            this.Unknown_68h = reader.ReadUInt32();
            this.Unknown_6Ch = reader.ReadUInt32();
            this.Unknown_70h = reader.ReadUInt32();
            this.Unknown_74h = reader.ReadUInt32();
            this.Unknown_78h = reader.ReadUInt32();
            this.Unknown_7Ch = reader.ReadUInt32();

            // read reference data
            this.Data1 = reader.ReadBlockAt<VertexData_GTA5_pc>(
                this.DataPointer1, // offset
                this.VertexStride,
                this.VertexCount
            );
            this.Data2 = reader.ReadBlockAt<VertexData_GTA5_pc>(
                this.DataPointer2, // offset
                this.VertexStride,
                this.VertexCount
            );
            this.Info = reader.ReadBlockAt<VertexBufferInfo_GTA5_pc>(
                this.InfoPointer // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            //this.VertexStride = (uint)(this.Data1 != null ? this.Data1.Count : 0);
            this.DataPointer1 = (ulong)(this.Data1 != null ? this.Data1.Position : 0);
            this.DataPointer2 = (ulong)(this.Data2 != null ? this.Data2.Position : 0);
            this.InfoPointer = (ulong)(this.Info != null ? this.Info.Position : 0);

            // write structure data
            writer.Write(this.VFT);
            writer.Write(this.Unknown_4h);
            writer.Write(this.VertexStride);
            writer.Write(this.Unknown_Ah);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.DataPointer1);
            writer.Write(this.VertexCount);
            writer.Write(this.Unknown_1Ch);
            writer.Write(this.DataPointer2);
            writer.Write(this.Unknown_28h);
            writer.Write(this.Unknown_2Ch);
            writer.Write(this.InfoPointer);
            writer.Write(this.Unknown_38h);
            writer.Write(this.Unknown_3Ch);
            writer.Write(this.Unknown_40h);
            writer.Write(this.Unknown_44h);
            writer.Write(this.Unknown_48h);
            writer.Write(this.Unknown_4Ch);
            writer.Write(this.Unknown_50h);
            writer.Write(this.Unknown_54h);
            writer.Write(this.Unknown_58h);
            writer.Write(this.Unknown_5Ch);
            writer.Write(this.Unknown_60h);
            writer.Write(this.Unknown_64h);
            writer.Write(this.Unknown_68h);
            writer.Write(this.Unknown_6Ch);
            writer.Write(this.Unknown_70h);
            writer.Write(this.Unknown_74h);
            writer.Write(this.Unknown_78h);
            writer.Write(this.Unknown_7Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (Data1 != null) list.Add(Data1);
            if (Data2 != null) list.Add(Data2);
            if (Info != null) list.Add(Info);
            return list.ToArray();
        }

    }

    public class VertexData_GTA5_pc : ResourceSystemBlock
    {

        public override long Length
        {
            get
            {
                return Data.Length;
            }
        }



        public byte[] Data;



        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            int i1 = Convert.ToInt32(parameters[0]);
            int i2 = Convert.ToInt32(parameters[1]);

            try
            {
                Data = reader.ReadBytes(i1 * i2);
            }
            catch
            {


            }

        }

        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            writer.Write(Data);
        }

    }
}