/*
    Copyright(c) 2016 Neodymium

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
using System;
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
        public ResourceSimpleList64<ushort_r> Unknown_80h;
        public ResourceSimpleList64<Unknown_C_005> Unknown_90h;
        public uint Unknown_A0h; // 0x3D23D70A
        public uint Unknown_A4h; // 0x00000000
        public uint Unknown_A8h; // 0x00000000
        public uint Unknown_ACh; // 0x00000000
        public ResourceSimpleList64<uint_r> Unknown_B0h;
        public ResourceSimpleList64<Unknown_C_006> Unknown_C0h;
        public uint Unknown_D0h; // 0x00000000
        public uint Unknown_D4h; // 0x00000000
        public uint Unknown_D8h; // 0x00000000
        public uint Unknown_DCh; // 0x3F800000
        public ResourceSimpleList64<uint_r> Unknown_E0h;

        // reference data
        public Unknown_C_003 p0data;
        public Unknown_C_004 p1data;

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
            this.Unknown_80h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>();
            this.Unknown_90h = reader.ReadBlock<ResourceSimpleList64<Unknown_C_005>>();
            this.Unknown_A0h = reader.ReadUInt32();
            this.Unknown_A4h = reader.ReadUInt32();
            this.Unknown_A8h = reader.ReadUInt32();
            this.Unknown_ACh = reader.ReadUInt32();
            this.Unknown_B0h = reader.ReadBlock<ResourceSimpleList64<uint_r>>();
            this.Unknown_C0h = reader.ReadBlock<ResourceSimpleList64<Unknown_C_006>>();
            this.Unknown_D0h = reader.ReadUInt32();
            this.Unknown_D4h = reader.ReadUInt32();
            this.Unknown_D8h = reader.ReadUInt32();
            this.Unknown_DCh = reader.ReadUInt32();
            this.Unknown_E0h = reader.ReadBlock<ResourceSimpleList64<uint_r>>();

            // read reference data
            this.p0data = reader.ReadBlockAt<Unknown_C_003>(
                this.p0 // offset
            );
            this.p1data = reader.ReadBlockAt<Unknown_C_004>(
                this.p1 // offset
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
            writer.WriteBlock(this.Unknown_80h);
            writer.WriteBlock(this.Unknown_90h);
            writer.Write(this.Unknown_A0h);
            writer.Write(this.Unknown_A4h);
            writer.Write(this.Unknown_A8h);
            writer.Write(this.Unknown_ACh);
            writer.WriteBlock(this.Unknown_B0h);
            writer.WriteBlock(this.Unknown_C0h);
            writer.Write(this.Unknown_D0h);
            writer.Write(this.Unknown_D4h);
            writer.Write(this.Unknown_D8h);
            writer.Write(this.Unknown_DCh);
            writer.WriteBlock(this.Unknown_E0h);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (p0data != null) list.Add(p0data);
            if (p1data != null) list.Add(p1data);
            return list.ToArray();
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(0x80, Unknown_80h),
                new Tuple<long, IResourceBlock>(0x90, Unknown_90h),
                new Tuple<long, IResourceBlock>(0xB0, Unknown_B0h),
                new Tuple<long, IResourceBlock>(0xC0, Unknown_C0h),
                new Tuple<long, IResourceBlock>(0xE0, Unknown_E0h)
            };
        }
    }
}
