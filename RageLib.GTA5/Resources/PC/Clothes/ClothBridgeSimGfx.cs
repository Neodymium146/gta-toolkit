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
    // pgBase
    // clothBridgeSimGfx
    public class ClothBridgeSimGfx : ResourceSystemBlock
    {
        public override long Length => 0x140;

        // structure data
        public uint VFT;
        public uint Unknown_4h; // 0x00000001
        public uint Unknown_8h; // 0x00000000
        public uint Unknown_Ch; // 0x00000000
        public uint Unknown_10h;
        public uint Unknown_14h;
        public uint Unknown_18h;
        public uint Unknown_1Ch; // 0x00000000
        public ResourceSimpleList64<float_r> Unknown_20h;
        public ResourceSimpleList64<float_r> Unknown_30h;
        public ResourceSimpleList64<float_r> Unknown_40h;
        public uint Unknown_50h; // 0x00000000
        public uint Unknown_54h; // 0x00000000
        public uint Unknown_58h; // 0x00000000
        public uint Unknown_5Ch; // 0x00000000
        public ResourceSimpleList64<float_r> Unknown_60h;
        public ResourceSimpleList64<uint_r> Unknown_70h;
        public ResourceSimpleList64<uint_r> Unknown_80h;
        public uint Unknown_90h; // 0x00000000
        public uint Unknown_94h; // 0x00000000
        public uint Unknown_98h; // 0x00000000
        public uint Unknown_9Ch; // 0x00000000
        public ResourceSimpleList64<float_r> Unknown_A0h;
        public ResourceSimpleList64<uint_r> Unknown_B0h;
        public ResourceSimpleList64<uint_r> Unknown_C0h;
        public uint Unknown_D0h; // 0x00000000
        public uint Unknown_D4h; // 0x00000000
        public uint Unknown_D8h; // 0x00000000
        public uint Unknown_DCh; // 0x00000000
        public ResourceSimpleList64<ushort_r> Unknown_E0h;
        public ResourceSimpleList64<ushort_r> Unknown_F0h;
        public ResourceSimpleList64<ushort_r> Unknown_100h;
        public uint Unknown_110h; // 0x00000000
        public uint Unknown_114h; // 0x00000000
        public uint Unknown_118h; // 0x00000000
        public uint Unknown_11Ch; // 0x00000000
        public uint Unknown_120h; // 0x00000000
        public uint Unknown_124h; // 0x00000000
        public ResourceSimpleList64<uint_r> Unknown_128h;
        public uint Unknown_138h; // 0x00000000
        public uint Unknown_13Ch; // 0x00000000

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
            this.Unknown_20h = reader.ReadBlock<ResourceSimpleList64<float_r>>();
            this.Unknown_30h = reader.ReadBlock<ResourceSimpleList64<float_r>>();
            this.Unknown_40h = reader.ReadBlock<ResourceSimpleList64<float_r>>();
            this.Unknown_50h = reader.ReadUInt32();
            this.Unknown_54h = reader.ReadUInt32();
            this.Unknown_58h = reader.ReadUInt32();
            this.Unknown_5Ch = reader.ReadUInt32();
            this.Unknown_60h = reader.ReadBlock<ResourceSimpleList64<float_r>>();
            this.Unknown_70h = reader.ReadBlock<ResourceSimpleList64<uint_r>>();
            this.Unknown_80h = reader.ReadBlock<ResourceSimpleList64<uint_r>>();
            this.Unknown_90h = reader.ReadUInt32();
            this.Unknown_94h = reader.ReadUInt32();
            this.Unknown_98h = reader.ReadUInt32();
            this.Unknown_9Ch = reader.ReadUInt32();
            this.Unknown_A0h = reader.ReadBlock<ResourceSimpleList64<float_r>>();
            this.Unknown_B0h = reader.ReadBlock<ResourceSimpleList64<uint_r>>();
            this.Unknown_C0h = reader.ReadBlock<ResourceSimpleList64<uint_r>>();
            this.Unknown_D0h = reader.ReadUInt32();
            this.Unknown_D4h = reader.ReadUInt32();
            this.Unknown_D8h = reader.ReadUInt32();
            this.Unknown_DCh = reader.ReadUInt32();
            this.Unknown_E0h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>();
            this.Unknown_F0h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>();
            this.Unknown_100h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>();
            this.Unknown_110h = reader.ReadUInt32();
            this.Unknown_114h = reader.ReadUInt32();
            this.Unknown_118h = reader.ReadUInt32();
            this.Unknown_11Ch = reader.ReadUInt32();
            this.Unknown_120h = reader.ReadUInt32();
            this.Unknown_124h = reader.ReadUInt32();
            this.Unknown_128h = reader.ReadBlock<ResourceSimpleList64<uint_r>>();
            this.Unknown_138h = reader.ReadUInt32();
            this.Unknown_13Ch = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // write structure data
            writer.Write(this.VFT);
            writer.Write(this.Unknown_4h);
            writer.Write(this.Unknown_8h);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.Write(this.Unknown_18h);
            writer.Write(this.Unknown_1Ch);
            writer.WriteBlock(this.Unknown_20h);
            writer.WriteBlock(this.Unknown_30h);
            writer.WriteBlock(this.Unknown_40h);
            writer.Write(this.Unknown_50h);
            writer.Write(this.Unknown_54h);
            writer.Write(this.Unknown_58h);
            writer.Write(this.Unknown_5Ch);
            writer.WriteBlock(this.Unknown_60h);
            writer.WriteBlock(this.Unknown_70h);
            writer.WriteBlock(this.Unknown_80h);
            writer.Write(this.Unknown_90h);
            writer.Write(this.Unknown_94h);
            writer.Write(this.Unknown_98h);
            writer.Write(this.Unknown_9Ch);
            writer.WriteBlock(this.Unknown_A0h);
            writer.WriteBlock(this.Unknown_B0h);
            writer.WriteBlock(this.Unknown_C0h);
            writer.Write(this.Unknown_D0h);
            writer.Write(this.Unknown_D4h);
            writer.Write(this.Unknown_D8h);
            writer.Write(this.Unknown_DCh);
            writer.WriteBlock(this.Unknown_E0h);
            writer.WriteBlock(this.Unknown_F0h);
            writer.WriteBlock(this.Unknown_100h);
            writer.Write(this.Unknown_110h);
            writer.Write(this.Unknown_114h);
            writer.Write(this.Unknown_118h);
            writer.Write(this.Unknown_11Ch);
            writer.Write(this.Unknown_120h);
            writer.Write(this.Unknown_124h);
            writer.WriteBlock(this.Unknown_128h);
            writer.Write(this.Unknown_138h);
            writer.Write(this.Unknown_13Ch);
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(0x20, Unknown_20h),
                new Tuple<long, IResourceBlock>(0x30, Unknown_30h),
                new Tuple<long, IResourceBlock>(0x40, Unknown_40h),
                new Tuple<long, IResourceBlock>(0x60, Unknown_60h),
                new Tuple<long, IResourceBlock>(0x70, Unknown_70h),
                new Tuple<long, IResourceBlock>(0x80, Unknown_80h),
                new Tuple<long, IResourceBlock>(0xA0, Unknown_A0h),
                new Tuple<long, IResourceBlock>(0xB0, Unknown_B0h),
                new Tuple<long, IResourceBlock>(0xC0, Unknown_C0h),
                new Tuple<long, IResourceBlock>(0xE0, Unknown_E0h),
                new Tuple<long, IResourceBlock>(0xF0, Unknown_F0h),
                new Tuple<long, IResourceBlock>(0x100, Unknown_100h),
                new Tuple<long, IResourceBlock>(0x128, Unknown_128h)
            };
        }
    }
}
