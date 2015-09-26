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

using RageLib.Resources.Common;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Expressions
{
    public class Expression_GTA5_pc : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 144; }
        }

        // structure data
        public uint VFT;
        public uint Unknown_4h;
        public uint Unknown_8h;
        public uint Unknown_Ch;
        public uint Unknown_10h;
        public uint Unknown_14h;
        public uint Unknown_18h;
        public uint Unknown_1Ch;
        public ulong ptr1;
        public ushort cnt1;
        public ushort cnt2;
        public uint Unknown_2Ch;
        public ulong ptr2;
        public ushort cnt3;
        public ushort cnt4;
        public uint Unknown_3Ch;
        public ulong ptr3;
        public ushort cnt5;
        public ushort cnt6;
        public uint Unknown_4Ch;
        public ulong ptr4;
        public ushort cnt7;
        public ushort cnt8;
        public uint Unknown_5Ch;
        public ulong NamePointer;
        public uint Unknown_68h;
        public uint Unknown_6Ch;
        public uint Unknown_70h;
        public uint Unknown_74h;
        public ushort len;
        public ushort Unknown_7Ah;
        public uint Unknown_7Ch;
        public uint Unknown_80h;
        public uint Unknown_84h;
        public uint Unknown_88h;
        public uint Unknown_8Ch;

        // reference data
        public ResourcePointerArray64<Expression_Unk1_GTA5_pc> ptr1data;
        public ResourceSimpleArray<uint_r> ptr2data;
        public ResourceSimpleArray<Expression_Unk2_GTA5_pc> ptr3data;
        public ResourceSimpleArray<uint_r> ptr4data;
        public string_r Name;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.VFT = reader.ReadUInt32();
            this.Unknown_4h = reader.ReadUInt32();
            this.Unknown_8h = reader.ReadUInt32();
            this.Unknown_Ch = reader.ReadUInt32();
            this.Unknown_10h = reader.ReadUInt32();
            this.Unknown_14h = reader.ReadUInt32();
            this.Unknown_18h = reader.ReadUInt32();
            this.Unknown_1Ch = reader.ReadUInt32();
            this.ptr1 = reader.ReadUInt64();
            this.cnt1 = reader.ReadUInt16();
            this.cnt2 = reader.ReadUInt16();
            this.Unknown_2Ch = reader.ReadUInt32();
            this.ptr2 = reader.ReadUInt64();
            this.cnt3 = reader.ReadUInt16();
            this.cnt4 = reader.ReadUInt16();
            this.Unknown_3Ch = reader.ReadUInt32();
            this.ptr3 = reader.ReadUInt64();
            this.cnt5 = reader.ReadUInt16();
            this.cnt6 = reader.ReadUInt16();
            this.Unknown_4Ch = reader.ReadUInt32();
            this.ptr4 = reader.ReadUInt64();
            this.cnt7 = reader.ReadUInt16();
            this.cnt8 = reader.ReadUInt16();
            this.Unknown_5Ch = reader.ReadUInt32();
            this.NamePointer = reader.ReadUInt64();
            this.Unknown_68h = reader.ReadUInt32();
            this.Unknown_6Ch = reader.ReadUInt32();
            this.Unknown_70h = reader.ReadUInt32();
            this.Unknown_74h = reader.ReadUInt32();
            this.len = reader.ReadUInt16();
            this.Unknown_7Ah = reader.ReadUInt16();
            this.Unknown_7Ch = reader.ReadUInt32();
            this.Unknown_80h = reader.ReadUInt32();
            this.Unknown_84h = reader.ReadUInt32();
            this.Unknown_88h = reader.ReadUInt32();
            this.Unknown_8Ch = reader.ReadUInt32();

            // read reference data
            this.ptr1data = reader.ReadBlockAt<ResourcePointerArray64<Expression_Unk1_GTA5_pc>>(
                this.ptr1, // offset
                this.cnt1
            );
            this.ptr2data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(
                this.ptr2, // offset
                this.cnt3
            );
            this.ptr3data = reader.ReadBlockAt<ResourceSimpleArray<Expression_Unk2_GTA5_pc>>(
                this.ptr3, // offset
                this.cnt5
            );
            this.ptr4data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(
                this.ptr4, // offset
                this.cnt7
            );
            this.Name = reader.ReadBlockAt<string_r>(
                this.NamePointer // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.ptr1 = (ulong)(this.ptr1data != null ? this.ptr1data.Position : 0);
            this.cnt1 = (ushort)(this.ptr1data != null ? this.ptr1data.Count : 0);
            this.ptr2 = (ulong)(this.ptr2data != null ? this.ptr2data.Position : 0);
            this.cnt3 = (ushort)(this.ptr2data != null ? this.ptr2data.Count : 0);
            this.ptr3 = (ulong)(this.ptr3data != null ? this.ptr3data.Position : 0);
            this.cnt5 = (ushort)(this.ptr3data != null ? this.ptr3data.Count : 0);
            this.ptr4 = (ulong)(this.ptr4data != null ? this.ptr4data.Position : 0);
            this.cnt7 = (ushort)(this.ptr4data != null ? this.ptr4data.Count : 0);
            this.NamePointer = (ulong)(this.Name != null ? this.Name.Position : 0);

            // write structure data
            writer.Write(this.VFT);
            writer.Write(this.Unknown_4h);
            writer.Write(this.Unknown_8h);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.Write(this.Unknown_18h);
            writer.Write(this.Unknown_1Ch);
            writer.Write(this.ptr1);
            writer.Write(this.cnt1);
            writer.Write(this.cnt2);
            writer.Write(this.Unknown_2Ch);
            writer.Write(this.ptr2);
            writer.Write(this.cnt3);
            writer.Write(this.cnt4);
            writer.Write(this.Unknown_3Ch);
            writer.Write(this.ptr3);
            writer.Write(this.cnt5);
            writer.Write(this.cnt6);
            writer.Write(this.Unknown_4Ch);
            writer.Write(this.ptr4);
            writer.Write(this.cnt7);
            writer.Write(this.cnt8);
            writer.Write(this.Unknown_5Ch);
            writer.Write(this.NamePointer);
            writer.Write(this.Unknown_68h);
            writer.Write(this.Unknown_6Ch);
            writer.Write(this.Unknown_70h);
            writer.Write(this.Unknown_74h);
            writer.Write(this.len);
            writer.Write(this.Unknown_7Ah);
            writer.Write(this.Unknown_7Ch);
            writer.Write(this.Unknown_80h);
            writer.Write(this.Unknown_84h);
            writer.Write(this.Unknown_88h);
            writer.Write(this.Unknown_8Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (ptr1data != null) list.Add(ptr1data);
            if (ptr2data != null) list.Add(ptr2data);
            if (ptr3data != null) list.Add(ptr3data);
            if (ptr4data != null) list.Add(ptr4data);
            if (Name != null) list.Add(Name);
            return list.ToArray();
        }

    }
}