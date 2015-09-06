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

namespace RageLib.Resources
{
    public class Unknown_C_002 : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 240; }
        }

        // structure data
        public uint VFT;
        public uint Unknown_4h; // 0x00000001
        public uint Unknown_8h; // 0x00000000
        public uint Unknown_Ch; // 0x00000000
        public ulong p0;
        public uint Unknown_18h; // 0x00000000
        public uint Unknown_1Ch; // 0x00000000
        public ulong p1;
        public uint Unknown_28h; // 0x00000000
        public uint Unknown_2Ch; // 0x00000000
        public uint Unknown_30h; // 0x00000000
        public uint Unknown_34h; // 0x00000000
        public uint Unknown_38h; // 0x00000000
        public uint Unknown_3Ch; // 0x00000000
        public uint Unknown_40h; // 0x00000000
        public uint Unknown_44h; // 0x00000000
        public uint Unknown_48h; // 0x00000000
        public uint Unknown_4Ch; // 0x00000000
        public uint Unknown_50h; // 0x00000002
        public uint Unknown_54h; // 0x00000000
        public uint Unknown_58h;
        public uint Unknown_5Ch;
        public uint Unknown_60h;
        public uint Unknown_64h;
        public uint Unknown_68h; // 0x00000000
        public uint Unknown_6Ch; // 0x00000000
        public uint Unknown_70h; // 0x00000000
        public uint Unknown_74h; // 0x00000000
        public uint Unknown_78h; // 0x3F800000
        public uint Unknown_7Ch; // 0x00000000
        public ulong p2;
        public ushort c2a;
        public ushort c2b;
        public uint Unknown_8Ch; // 0x00000000
        public ulong p3;
        public ushort c3a;
        public ushort c3b;
        public uint Unknown_9Ch; // 0x00000000
        public uint Unknown_A0h; // 0x3D23D70A
        public uint Unknown_A4h; // 0x00000000
        public uint Unknown_A8h; // 0x00000000
        public uint Unknown_ACh; // 0x00000000
        public ulong p4;
        public ushort c4a;
        public ushort c4b;
        public uint Unknown_BCh; // 0x00000000
        public ulong p5;
        public ushort c5a;
        public ushort c5b;
        public uint Unknown_CCh; // 0x00000000
        public uint Unknown_D0h; // 0x00000000
        public uint Unknown_D4h; // 0x00000000
        public uint Unknown_D8h; // 0x00000000
        public uint Unknown_DCh; // 0x3F800000
        public ulong p6;
        public ushort c6a;
        public ushort c6b;
        public uint Unknown_ECh; // 0x00000000

        // reference data
        public Unknown_C_003 p0data;
        public Unknown_C_004 p1data;
        public ResourceSimpleArray<ushort_r> p2data;
        public ResourceSimpleArray<Unknown_C_005> p3data;
        public ResourceSimpleArray<uint_r> p4data;
        public ResourceSimpleArray<Unknown_C_006> p5data;
        public ResourceSimpleArray<uint_r> p6data;

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
            this.Unknown_18h = reader.ReadUInt32();
            this.Unknown_1Ch = reader.ReadUInt32();
            this.p1 = reader.ReadUInt64();
            this.Unknown_28h = reader.ReadUInt32();
            this.Unknown_2Ch = reader.ReadUInt32();
            this.Unknown_30h = reader.ReadUInt32();
            this.Unknown_34h = reader.ReadUInt32();
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
            this.p2 = reader.ReadUInt64();
            this.c2a = reader.ReadUInt16();
            this.c2b = reader.ReadUInt16();
            this.Unknown_8Ch = reader.ReadUInt32();
            this.p3 = reader.ReadUInt64();
            this.c3a = reader.ReadUInt16();
            this.c3b = reader.ReadUInt16();
            this.Unknown_9Ch = reader.ReadUInt32();
            this.Unknown_A0h = reader.ReadUInt32();
            this.Unknown_A4h = reader.ReadUInt32();
            this.Unknown_A8h = reader.ReadUInt32();
            this.Unknown_ACh = reader.ReadUInt32();
            this.p4 = reader.ReadUInt64();
            this.c4a = reader.ReadUInt16();
            this.c4b = reader.ReadUInt16();
            this.Unknown_BCh = reader.ReadUInt32();
            this.p5 = reader.ReadUInt64();
            this.c5a = reader.ReadUInt16();
            this.c5b = reader.ReadUInt16();
            this.Unknown_CCh = reader.ReadUInt32();
            this.Unknown_D0h = reader.ReadUInt32();
            this.Unknown_D4h = reader.ReadUInt32();
            this.Unknown_D8h = reader.ReadUInt32();
            this.Unknown_DCh = reader.ReadUInt32();
            this.p6 = reader.ReadUInt64();
            this.c6a = reader.ReadUInt16();
            this.c6b = reader.ReadUInt16();
            this.Unknown_ECh = reader.ReadUInt32();

            // read reference data
            this.p0data = reader.ReadBlockAt<Unknown_C_003>(
                this.p0 // offset
            );
            this.p1data = reader.ReadBlockAt<Unknown_C_004>(
                this.p1 // offset
            );
            this.p2data = reader.ReadBlockAt<ResourceSimpleArray<ushort_r>>(
                this.p2, // offset
                this.c2a
            );
            this.p3data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_C_005>>(
                this.p3, // offset
                this.c3a
            );
            this.p4data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(
                this.p4, // offset
                this.c4a
            );
            this.p5data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_C_006>>(
                this.p5, // offset
                this.c5a
            );
            this.p6data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(
                this.p6, // offset
                this.c6a
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.p0 = (ulong)(this.p0data != null ? this.p0data.Position : 0);
            this.p1 = (ulong)(this.p1data != null ? this.p1data.Position : 0);
            this.p2 = (ulong)(this.p2data != null ? this.p2data.Position : 0);
            //this.c2a = (ushort)(this.p2data != null ? this.p2data.Count : 0);
            this.p3 = (ulong)(this.p3data != null ? this.p3data.Position : 0);
            //this.c3a = (ushort)(this.p3data != null ? this.p3data.Count : 0);
            this.p4 = (ulong)(this.p4data != null ? this.p4data.Position : 0);
            //this.c4a = (ushort)(this.p4data != null ? this.p4data.Count : 0);
            this.p5 = (ulong)(this.p5data != null ? this.p5data.Position : 0);
            //this.c5a = (ushort)(this.p5data != null ? this.p5data.Count : 0);
            this.p6 = (ulong)(this.p6data != null ? this.p6data.Position : 0);
            //this.c6a = (ushort)(this.p6data != null ? this.p6data.Count : 0);

            // write structure data
            writer.Write(this.VFT);
            writer.Write(this.Unknown_4h);
            writer.Write(this.Unknown_8h);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.p0);
            writer.Write(this.Unknown_18h);
            writer.Write(this.Unknown_1Ch);
            writer.Write(this.p1);
            writer.Write(this.Unknown_28h);
            writer.Write(this.Unknown_2Ch);
            writer.Write(this.Unknown_30h);
            writer.Write(this.Unknown_34h);
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
            writer.Write(this.p2);
            writer.Write(this.c2a);
            writer.Write(this.c2b);
            writer.Write(this.Unknown_8Ch);
            writer.Write(this.p3);
            writer.Write(this.c3a);
            writer.Write(this.c3b);
            writer.Write(this.Unknown_9Ch);
            writer.Write(this.Unknown_A0h);
            writer.Write(this.Unknown_A4h);
            writer.Write(this.Unknown_A8h);
            writer.Write(this.Unknown_ACh);
            writer.Write(this.p4);
            writer.Write(this.c4a);
            writer.Write(this.c4b);
            writer.Write(this.Unknown_BCh);
            writer.Write(this.p5);
            writer.Write(this.c5a);
            writer.Write(this.c5b);
            writer.Write(this.Unknown_CCh);
            writer.Write(this.Unknown_D0h);
            writer.Write(this.Unknown_D4h);
            writer.Write(this.Unknown_D8h);
            writer.Write(this.Unknown_DCh);
            writer.Write(this.p6);
            writer.Write(this.c6a);
            writer.Write(this.c6b);
            writer.Write(this.Unknown_ECh);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (p0data != null) list.Add(p0data);
            if (p1data != null) list.Add(p1data);
            if (p2data != null) list.Add(p2data);
            if (p3data != null) list.Add(p3data);
            if (p4data != null) list.Add(p4data);
            if (p5data != null) list.Add(p5data);
            if (p6data != null) list.Add(p6data);
            return list.ToArray();
        }

    }
}