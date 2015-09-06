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
using RageLib.Resources.GTA5.PC.Bounds;
using System.Collections.Generic;

namespace RageLib.Resources
{
    public class Cloth_GTA5_pc : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 208; }
        }

        // structure data
        public uint VFT;
        public uint Unknown_4h; // 0x00000001
        public uint Unknown_8h; // 0x00000000
        public uint Unknown_Ch; // 0x00000000
        public ulong p0;
        public ushort c0a;
        public ushort c0b;
        public uint Unknown_1Ch; // 0x00000000
        public ulong p1;
        public ulong p2;
        public ulong p3;
        public ushort c3a;
        public ushort c3b;
        public uint Unknown_3Ch; // 0x00000000
        public uint Unknown_40h; // 0x00000000
        public uint Unknown_44h; // 0x00000000
        public uint Unknown_48h; // 0x00000000
        public uint Unknown_4Ch; // 0x00000000
        public uint Unknown_50h; // 0x3F800000
        public uint Unknown_54h; // 0x00000000
        public uint Unknown_58h; // 0x00000000
        public uint Unknown_5Ch; // 0x00000000
        public uint Unknown_60h; // 0x00000000
        public uint Unknown_64h; // 0x3F800000
        public uint Unknown_68h; // 0x00000000
        public uint Unknown_6Ch; // 0x00000000
        public uint Unknown_70h; // 0x00000000
        public uint Unknown_74h; // 0x00000000
        public uint Unknown_78h; // 0x3F800000
        public uint Unknown_7Ch; // 0x00000000
        public uint Unknown_80h; // 0x00000000
        public uint Unknown_84h; // 0x00000000
        public uint Unknown_88h; // 0x00000000
        public uint Unknown_8Ch; // 0x00000000
        public ulong p4;
        public ushort c4a;
        public ushort c4b;
        public uint Unknown_9Ch; // 0x00000000
        public uint Unknown_A0h; // 0x00000000
        public uint Unknown_A4h; // 0x00000000
        public uint Unknown_A8h; // 0x00000000
        public uint Unknown_ACh; // 0x00000000
        public uint Unknown_B0h; // 0x00000000
        public uint Unknown_B4h; // 0x00000000
        public uint Unknown_B8h; // 0x00000000
        public uint Unknown_BCh; // 0x00000000
        public uint Unknown_C0h; // 0x00000001
        public uint Unknown_C4h; // 0x00000000
        public uint Unknown_C8h; // 0x00000000
        public uint Unknown_CCh; // 0x00000000

        // reference data
        public ResourceSimpleArray<Unknown_C_001> p0_data;
        public Unknown_C_002 p1_data;
        public Bound_GTA5_pc Bound;
        public ResourceSimpleArray<uint_r> p3_data;
        public ResourceSimpleArray<uint_r> p4_data;

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
            this.p0 = reader.ReadUInt64();
            this.c0a = reader.ReadUInt16();
            this.c0b = reader.ReadUInt16();
            this.Unknown_1Ch = reader.ReadUInt32();
            this.p1 = reader.ReadUInt64();
            this.p2 = reader.ReadUInt64();
            this.p3 = reader.ReadUInt64();
            this.c3a = reader.ReadUInt16();
            this.c3b = reader.ReadUInt16();
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
            this.Unknown_80h = reader.ReadUInt32();
            this.Unknown_84h = reader.ReadUInt32();
            this.Unknown_88h = reader.ReadUInt32();
            this.Unknown_8Ch = reader.ReadUInt32();
            this.p4 = reader.ReadUInt64();
            this.c4a = reader.ReadUInt16();
            this.c4b = reader.ReadUInt16();
            this.Unknown_9Ch = reader.ReadUInt32();
            this.Unknown_A0h = reader.ReadUInt32();
            this.Unknown_A4h = reader.ReadUInt32();
            this.Unknown_A8h = reader.ReadUInt32();
            this.Unknown_ACh = reader.ReadUInt32();
            this.Unknown_B0h = reader.ReadUInt32();
            this.Unknown_B4h = reader.ReadUInt32();
            this.Unknown_B8h = reader.ReadUInt32();
            this.Unknown_BCh = reader.ReadUInt32();
            this.Unknown_C0h = reader.ReadUInt32();
            this.Unknown_C4h = reader.ReadUInt32();
            this.Unknown_C8h = reader.ReadUInt32();
            this.Unknown_CCh = reader.ReadUInt32();

            // read reference data
            this.p0_data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_C_001>>(
                this.p0, // offset
                this.c0a
            );
            this.p1_data = reader.ReadBlockAt<Unknown_C_002>(
                this.p1 // offset
            );
            this.Bound = reader.ReadBlockAt<Bound_GTA5_pc>(
                this.p2 // offset
            );
            this.p3_data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(
                this.p3, // offset
                this.c3a
            );
            this.p4_data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(
                this.p4, // offset
                this.c4a
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.p0 = (ulong)(this.p0_data != null ? this.p0_data.Position : 0);
            //this.c0a = (ushort)(this.p0_data != null ? this.p0_data.Count : 0);
            this.p1 = (ulong)(this.p1_data != null ? this.p1_data.Position : 0);
            this.p2 = (ulong)(this.Bound != null ? this.Bound.Position : 0);
            this.p3 = (ulong)(this.p3_data != null ? this.p3_data.Position : 0);
            //this.c3a = (ushort)(this.p3_data != null ? this.p3_data.Count : 0);
            this.p4 = (ulong)(this.p4_data != null ? this.p4_data.Position : 0);
            //this.c4a = (ushort)(this.p4_data != null ? this.p4_data.Count : 0);

            // write structure data
            writer.Write(this.VFT);
            writer.Write(this.Unknown_4h);
            writer.Write(this.Unknown_8h);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.p0);
            writer.Write(this.c0a);
            writer.Write(this.c0b);
            writer.Write(this.Unknown_1Ch);
            writer.Write(this.p1);
            writer.Write(this.p2);
            writer.Write(this.p3);
            writer.Write(this.c3a);
            writer.Write(this.c3b);
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
            writer.Write(this.Unknown_80h);
            writer.Write(this.Unknown_84h);
            writer.Write(this.Unknown_88h);
            writer.Write(this.Unknown_8Ch);
            writer.Write(this.p4);
            writer.Write(this.c4a);
            writer.Write(this.c4b);
            writer.Write(this.Unknown_9Ch);
            writer.Write(this.Unknown_A0h);
            writer.Write(this.Unknown_A4h);
            writer.Write(this.Unknown_A8h);
            writer.Write(this.Unknown_ACh);
            writer.Write(this.Unknown_B0h);
            writer.Write(this.Unknown_B4h);
            writer.Write(this.Unknown_B8h);
            writer.Write(this.Unknown_BCh);
            writer.Write(this.Unknown_C0h);
            writer.Write(this.Unknown_C4h);
            writer.Write(this.Unknown_C8h);
            writer.Write(this.Unknown_CCh);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (p0_data != null) list.Add(p0_data);
            if (p1_data != null) list.Add(p1_data);
            if (Bound != null) list.Add(Bound);
            if (p3_data != null) list.Add(p3_data);
            if (p4_data != null) list.Add(p4_data);
            return list.ToArray();
        }

    }
}