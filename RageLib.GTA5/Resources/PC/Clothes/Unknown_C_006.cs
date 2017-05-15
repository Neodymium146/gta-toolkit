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

using RageLib.Resources.Common;
using System;

namespace RageLib.Resources.GTA5.PC.Clothes
{
    public class Unknown_C_006 : ResourceSystemBlock
    {
        public override long Length => 0x190;

        // structure data
        public uint Unknown_0h; // 0x00000000
        public uint Unknown_4h; // 0x00000000
        public uint Unknown_8h; // 0x00000000
        public uint Unknown_Ch; // 0x00000000
        public uint Unknown_10h; // 0x00000000
        public uint Unknown_14h; // 0x00000000
        public uint Unknown_18h; // 0x00000000
        public uint Unknown_1Ch; // 0x00000000
        public uint Unknown_20h; // 0x00000000
        public uint Unknown_24h; // 0x00000000
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
        public ResourceSimpleList64<RAGE_Vector4> Unknown_50h;
        public ResourceSimpleList64<ushort_r> Unknown_60h;
        public ResourceSimpleList64<ushort_r> Unknown_70h;
        public ResourceSimpleList64<ushort_r> Unknown_80h;
        public ResourceSimpleList64<ushort_r> Unknown_90h;
        public ResourceSimpleList64<RAGE_Vector4> Unknown_A0h;
        public ResourceSimpleList64<ushort_r> Unknown_B0h;
        public ResourceSimpleList64<ushort_r> Unknown_C0h;
        public ResourceSimpleList64<ushort_r> Unknown_D0h;
        public ResourceSimpleList64<ushort_r> Unknown_E0h;
        public uint Unknown_F0h; // 0x00000000
        public uint Unknown_F4h; // 0x00000000
        public uint Unknown_F8h; // 0x00000000
        public uint Unknown_FCh; // 0x00000000
        public uint Unknown_100h; // 0x00000000
        public uint Unknown_104h; // 0x00000000
        public uint Unknown_108h; // 0x00000000
        public uint Unknown_10Ch; // 0x00000000
        public uint Unknown_110h; // 0x00000000
        public uint Unknown_114h; // 0x00000000
        public uint Unknown_118h; // 0x00000000
        public uint Unknown_11Ch; // 0x00000000
        public uint Unknown_120h; // 0x00000000
        public uint Unknown_124h; // 0x00000000
        public uint Unknown_128h; // 0x00000000
        public uint Unknown_12Ch; // 0x00000000
        public uint Unknown_130h; // 0x00000000
        public uint Unknown_134h; // 0x00000000
        public uint Unknown_138h; // 0x00000000
        public uint Unknown_13Ch; // 0x00000000
        public uint Unknown_140h; // 0x00000000
        public uint Unknown_144h; // 0x00000000
        public uint Unknown_148h; // 0x00000000
        public uint Unknown_14Ch; // 0x00000000
        public ResourceSimpleList64<ushort_r> Unknown_150h;
        public ResourceSimpleList64<ushort_r> Unknown_160h;
        public uint Unknown_170h; // 0x00000000
        public uint Unknown_174h; // 0x00000000
        public uint Unknown_178h; // 0x00000000
        public uint Unknown_17Ch; // 0x00000000
        public uint Unknown_180h;
        public uint Unknown_184h; // 0x00000000
        public uint Unknown_188h; // 0x00000000
        public uint Unknown_18Ch; // 0x00000000

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.Unknown_0h = reader.ReadUInt32();
            this.Unknown_4h = reader.ReadUInt32();
            this.Unknown_8h = reader.ReadUInt32();
            this.Unknown_Ch = reader.ReadUInt32();
            this.Unknown_10h = reader.ReadUInt32();
            this.Unknown_14h = reader.ReadUInt32();
            this.Unknown_18h = reader.ReadUInt32();
            this.Unknown_1Ch = reader.ReadUInt32();
            this.Unknown_20h = reader.ReadUInt32();
            this.Unknown_24h = reader.ReadUInt32();
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
            this.Unknown_50h = reader.ReadBlock<ResourceSimpleList64<RAGE_Vector4>>();
            this.Unknown_60h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>();
            this.Unknown_70h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>();
            this.Unknown_80h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>();
            this.Unknown_90h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>();
            this.Unknown_A0h = reader.ReadBlock<ResourceSimpleList64<RAGE_Vector4>>();
            this.Unknown_B0h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>();
            this.Unknown_C0h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>();
            this.Unknown_D0h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>();
            this.Unknown_E0h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>();
            this.Unknown_F0h = reader.ReadUInt32();
            this.Unknown_F4h = reader.ReadUInt32();
            this.Unknown_F8h = reader.ReadUInt32();
            this.Unknown_FCh = reader.ReadUInt32();
            this.Unknown_100h = reader.ReadUInt32();
            this.Unknown_104h = reader.ReadUInt32();
            this.Unknown_108h = reader.ReadUInt32();
            this.Unknown_10Ch = reader.ReadUInt32();
            this.Unknown_110h = reader.ReadUInt32();
            this.Unknown_114h = reader.ReadUInt32();
            this.Unknown_118h = reader.ReadUInt32();
            this.Unknown_11Ch = reader.ReadUInt32();
            this.Unknown_120h = reader.ReadUInt32();
            this.Unknown_124h = reader.ReadUInt32();
            this.Unknown_128h = reader.ReadUInt32();
            this.Unknown_12Ch = reader.ReadUInt32();
            this.Unknown_130h = reader.ReadUInt32();
            this.Unknown_134h = reader.ReadUInt32();
            this.Unknown_138h = reader.ReadUInt32();
            this.Unknown_13Ch = reader.ReadUInt32();
            this.Unknown_140h = reader.ReadUInt32();
            this.Unknown_144h = reader.ReadUInt32();
            this.Unknown_148h = reader.ReadUInt32();
            this.Unknown_14Ch = reader.ReadUInt32();
            this.Unknown_150h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>();
            this.Unknown_160h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>();
            this.Unknown_170h = reader.ReadUInt32();
            this.Unknown_174h = reader.ReadUInt32();
            this.Unknown_178h = reader.ReadUInt32();
            this.Unknown_17Ch = reader.ReadUInt32();
            this.Unknown_180h = reader.ReadUInt32();
            this.Unknown_184h = reader.ReadUInt32();
            this.Unknown_188h = reader.ReadUInt32();
            this.Unknown_18Ch = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // write structure data
            writer.Write(this.Unknown_0h);
            writer.Write(this.Unknown_4h);
            writer.Write(this.Unknown_8h);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.Write(this.Unknown_18h);
            writer.Write(this.Unknown_1Ch);
            writer.Write(this.Unknown_20h);
            writer.Write(this.Unknown_24h);
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
            writer.WriteBlock(this.Unknown_50h);
            writer.WriteBlock(this.Unknown_60h);
            writer.WriteBlock(this.Unknown_70h);
            writer.WriteBlock(this.Unknown_80h);
            writer.WriteBlock(this.Unknown_90h);
            writer.WriteBlock(this.Unknown_A0h);
            writer.WriteBlock(this.Unknown_B0h);
            writer.WriteBlock(this.Unknown_C0h);
            writer.WriteBlock(this.Unknown_D0h);
            writer.WriteBlock(this.Unknown_E0h);
            writer.Write(this.Unknown_F0h);
            writer.Write(this.Unknown_F4h);
            writer.Write(this.Unknown_F8h);
            writer.Write(this.Unknown_FCh);
            writer.Write(this.Unknown_100h);
            writer.Write(this.Unknown_104h);
            writer.Write(this.Unknown_108h);
            writer.Write(this.Unknown_10Ch);
            writer.Write(this.Unknown_110h);
            writer.Write(this.Unknown_114h);
            writer.Write(this.Unknown_118h);
            writer.Write(this.Unknown_11Ch);
            writer.Write(this.Unknown_120h);
            writer.Write(this.Unknown_124h);
            writer.Write(this.Unknown_128h);
            writer.Write(this.Unknown_12Ch);
            writer.Write(this.Unknown_130h);
            writer.Write(this.Unknown_134h);
            writer.Write(this.Unknown_138h);
            writer.Write(this.Unknown_13Ch);
            writer.Write(this.Unknown_140h);
            writer.Write(this.Unknown_144h);
            writer.Write(this.Unknown_148h);
            writer.Write(this.Unknown_14Ch);
            writer.WriteBlock(this.Unknown_150h);
            writer.WriteBlock(this.Unknown_160h);
            writer.Write(this.Unknown_170h);
            writer.Write(this.Unknown_174h);
            writer.Write(this.Unknown_178h);
            writer.Write(this.Unknown_17Ch);
            writer.Write(this.Unknown_180h);
            writer.Write(this.Unknown_184h);
            writer.Write(this.Unknown_188h);
            writer.Write(this.Unknown_18Ch);
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(0x50, Unknown_50h),
                new Tuple<long, IResourceBlock>(0x60, Unknown_60h),
                new Tuple<long, IResourceBlock>(0x70, Unknown_70h),
                new Tuple<long, IResourceBlock>(0x80, Unknown_80h),
                new Tuple<long, IResourceBlock>(0x90, Unknown_90h),
                new Tuple<long, IResourceBlock>(0xA0, Unknown_A0h),
                new Tuple<long, IResourceBlock>(0xB0, Unknown_B0h),
                new Tuple<long, IResourceBlock>(0xC0, Unknown_C0h),
                new Tuple<long, IResourceBlock>(0xD0, Unknown_D0h),
                new Tuple<long, IResourceBlock>(0xE0, Unknown_E0h),
                new Tuple<long, IResourceBlock>(0x150, Unknown_150h),
                new Tuple<long, IResourceBlock>(0x160, Unknown_160h)
            };
        }
    }
}
