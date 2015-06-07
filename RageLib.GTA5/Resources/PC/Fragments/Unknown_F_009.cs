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

namespace RageLib.Resources.GTA5.PC.Fragments
{
    public class Unknown_F_009 : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 320; }
        }

        // structure data
        public uint VFT;
        public uint Unknown_4h; // 0x00000001
        public uint Unknown_8h; // 0x00000000
        public uint Unknown_Ch; // 0x00000000
        public uint Unknown_10h;
        public uint Unknown_14h;
        public uint Unknown_18h;
        public uint Unknown_1Ch; // 0x00000000
        public ulong Unknown_20h_Pointer;
        public ushort Count1;
        public ushort Count2;
        public uint Unknown_2Ch; // 0x00000000
        public ulong Unknown_30h_Pointer;
        public ushort Count3;
        public ushort Count4;
        public uint Unknown_3Ch; // 0x00000000
        public ulong Unknown_40h_Pointer;
        public ushort Count5;
        public ushort Count6;
        public uint Unknown_4Ch; // 0x00000000
        public uint Unknown_50h; // 0x00000000
        public uint Unknown_54h; // 0x00000000
        public uint Unknown_58h; // 0x00000000
        public uint Unknown_5Ch; // 0x00000000
        public ulong Unknown_60h_Pointer;
        public ushort Count7;
        public ushort Count8;
        public uint Unknown_6Ch; // 0x00000000
        public ulong Unknown_70h_Pointer;
        public ushort Count9;
        public ushort Count10;
        public uint Unknown_7Ch; // 0x00000000
        public ulong Unknown_80h_Pointer;
        public ushort Count11;
        public ushort Count12;
        public uint Unknown_8Ch; // 0x00000000
        public uint Unknown_90h; // 0x00000000
        public uint Unknown_94h; // 0x00000000
        public uint Unknown_98h; // 0x00000000
        public uint Unknown_9Ch; // 0x00000000
        public ulong Unknown_A0h_Pointer;
        public ushort Count13;
        public ushort Count14;
        public uint Unknown_ACh; // 0x00000000
        public ulong Unknown_B0h_Pointer;
        public ushort Count15;
        public ushort Count16;
        public uint Unknown_BCh; // 0x00000000
        public ulong Unknown_C0h_Pointer;
        public ushort Count17;
        public ushort Count18;
        public uint Unknown_CCh; // 0x00000000
        public uint Unknown_D0h; // 0x00000000
        public uint Unknown_D4h; // 0x00000000
        public uint Unknown_D8h; // 0x00000000
        public uint Unknown_DCh; // 0x00000000
        public ulong Unknown_E0h_Pointer;
        public ushort Count19;
        public ushort Count20;
        public uint Unknown_ECh; // 0x00000000
        public ulong Unknown_F0h_Pointer;
        public ushort Count21;
        public ushort Count22;
        public uint Unknown_FCh; // 0x00000000
        public ulong Unknown_100h_Pointer;
        public ushort Count23;
        public ushort Count24;
        public uint Unknown_10Ch; // 0x00000000
        public uint Unknown_110h; // 0x00000000
        public uint Unknown_114h; // 0x00000000
        public uint Unknown_118h; // 0x00000000
        public uint Unknown_11Ch; // 0x00000000
        public uint Unknown_120h; // 0x00000000
        public uint Unknown_124h; // 0x00000000
        public ulong Unknown_128h_Pointer;
        public ushort Count25;
        public ushort Unknown_132h;
        public uint Unknown_134h; // 0x00000000
        public uint Unknown_138h; // 0x00000000
        public uint Unknown_13Ch; // 0x00000000

        // reference data
        public ResourceSimpleArray<uint_r> Unknown_20h_Data;
        public ResourceSimpleArray<uint_r> Unknown_30h_Data;
        public ResourceSimpleArray<uint_r> Unknown_40h_Data;
        public ResourceSimpleArray<uint_r> Unknown_60h_Data;
        public ResourceSimpleArray<uint_r> Unknown_70h_Data;
        public ResourceSimpleArray<uint_r> Unknown_80h_Data;
        public ResourceSimpleArray<uint_r> Unknown_A0h_Data;
        public ResourceSimpleArray<uint_r> Unknown_B0h_Data;
        public ResourceSimpleArray<uint_r> Unknown_C0h_Data;
        public ResourceSimpleArray<ushort_r> Unknown_E0h_Data;
        public ResourceSimpleArray<ushort_r> Unknown_F0h_Data;
        public ResourceSimpleArray<ushort_r> Unknown_100h_Data;
        public ResourceSimpleArray<uint_r> Unknown_128h_Data;

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
            this.Unknown_20h_Pointer = reader.ReadUInt64();
            this.Count1 = reader.ReadUInt16();
            this.Count2 = reader.ReadUInt16();
            this.Unknown_2Ch = reader.ReadUInt32();
            this.Unknown_30h_Pointer = reader.ReadUInt64();
            this.Count3 = reader.ReadUInt16();
            this.Count4 = reader.ReadUInt16();
            this.Unknown_3Ch = reader.ReadUInt32();
            this.Unknown_40h_Pointer = reader.ReadUInt64();
            this.Count5 = reader.ReadUInt16();
            this.Count6 = reader.ReadUInt16();
            this.Unknown_4Ch = reader.ReadUInt32();
            this.Unknown_50h = reader.ReadUInt32();
            this.Unknown_54h = reader.ReadUInt32();
            this.Unknown_58h = reader.ReadUInt32();
            this.Unknown_5Ch = reader.ReadUInt32();
            this.Unknown_60h_Pointer = reader.ReadUInt64();
            this.Count7 = reader.ReadUInt16();
            this.Count8 = reader.ReadUInt16();
            this.Unknown_6Ch = reader.ReadUInt32();
            this.Unknown_70h_Pointer = reader.ReadUInt64();
            this.Count9 = reader.ReadUInt16();
            this.Count10 = reader.ReadUInt16();
            this.Unknown_7Ch = reader.ReadUInt32();
            this.Unknown_80h_Pointer = reader.ReadUInt64();
            this.Count11 = reader.ReadUInt16();
            this.Count12 = reader.ReadUInt16();
            this.Unknown_8Ch = reader.ReadUInt32();
            this.Unknown_90h = reader.ReadUInt32();
            this.Unknown_94h = reader.ReadUInt32();
            this.Unknown_98h = reader.ReadUInt32();
            this.Unknown_9Ch = reader.ReadUInt32();
            this.Unknown_A0h_Pointer = reader.ReadUInt64();
            this.Count13 = reader.ReadUInt16();
            this.Count14 = reader.ReadUInt16();
            this.Unknown_ACh = reader.ReadUInt32();
            this.Unknown_B0h_Pointer = reader.ReadUInt64();
            this.Count15 = reader.ReadUInt16();
            this.Count16 = reader.ReadUInt16();
            this.Unknown_BCh = reader.ReadUInt32();
            this.Unknown_C0h_Pointer = reader.ReadUInt64();
            this.Count17 = reader.ReadUInt16();
            this.Count18 = reader.ReadUInt16();
            this.Unknown_CCh = reader.ReadUInt32();
            this.Unknown_D0h = reader.ReadUInt32();
            this.Unknown_D4h = reader.ReadUInt32();
            this.Unknown_D8h = reader.ReadUInt32();
            this.Unknown_DCh = reader.ReadUInt32();
            this.Unknown_E0h_Pointer = reader.ReadUInt64();
            this.Count19 = reader.ReadUInt16();
            this.Count20 = reader.ReadUInt16();
            this.Unknown_ECh = reader.ReadUInt32();
            this.Unknown_F0h_Pointer = reader.ReadUInt64();
            this.Count21 = reader.ReadUInt16();
            this.Count22 = reader.ReadUInt16();
            this.Unknown_FCh = reader.ReadUInt32();
            this.Unknown_100h_Pointer = reader.ReadUInt64();
            this.Count23 = reader.ReadUInt16();
            this.Count24 = reader.ReadUInt16();
            this.Unknown_10Ch = reader.ReadUInt32();
            this.Unknown_110h = reader.ReadUInt32();
            this.Unknown_114h = reader.ReadUInt32();
            this.Unknown_118h = reader.ReadUInt32();
            this.Unknown_11Ch = reader.ReadUInt32();
            this.Unknown_120h = reader.ReadUInt32();
            this.Unknown_124h = reader.ReadUInt32();
            this.Unknown_128h_Pointer = reader.ReadUInt64();
            this.Count25 = reader.ReadUInt16();
            this.Unknown_132h = reader.ReadUInt16();
            this.Unknown_134h = reader.ReadUInt32();
            this.Unknown_138h = reader.ReadUInt32();
            this.Unknown_13Ch = reader.ReadUInt32();

            // read reference data
            this.Unknown_20h_Data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(
                this.Unknown_20h_Pointer, // offset
                this.Count1
            );
            this.Unknown_30h_Data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(
                this.Unknown_30h_Pointer, // offset
                this.Count3
            );
            this.Unknown_40h_Data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(
                this.Unknown_40h_Pointer, // offset
                this.Count5
            );
            this.Unknown_60h_Data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(
                this.Unknown_60h_Pointer, // offset
                this.Count7
            );
            this.Unknown_70h_Data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(
                this.Unknown_70h_Pointer, // offset
                this.Count9
            );
            this.Unknown_80h_Data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(
                this.Unknown_80h_Pointer, // offset
                this.Count11
            );
            this.Unknown_A0h_Data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(
                this.Unknown_A0h_Pointer, // offset
                this.Count13
            );
            this.Unknown_B0h_Data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(
                this.Unknown_B0h_Pointer, // offset
                this.Count15
            );
            this.Unknown_C0h_Data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(
                this.Unknown_C0h_Pointer, // offset
                this.Count17
            );
            this.Unknown_E0h_Data = reader.ReadBlockAt<ResourceSimpleArray<ushort_r>>(
                this.Unknown_E0h_Pointer, // offset
                this.Count19
            );
            this.Unknown_F0h_Data = reader.ReadBlockAt<ResourceSimpleArray<ushort_r>>(
                this.Unknown_F0h_Pointer, // offset
                this.Count21
            );
            this.Unknown_100h_Data = reader.ReadBlockAt<ResourceSimpleArray<ushort_r>>(
                this.Unknown_100h_Pointer, // offset
                this.Count23
            );
            this.Unknown_128h_Data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(
                this.Unknown_128h_Pointer, // offset
                this.Count25
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.Unknown_20h_Pointer = (ulong)(this.Unknown_20h_Data != null ? this.Unknown_20h_Data.Position : 0);
            //this.qqnt0a = (ushort)(this.qq00data != null ? this.qq00data.Count : 0);
            this.Unknown_30h_Pointer = (ulong)(this.Unknown_30h_Data != null ? this.Unknown_30h_Data.Position : 0);
            //this.qqnt5a = (ushort)(this.qq55data != null ? this.qq55data.Count : 0);
            this.Unknown_40h_Pointer = (ulong)(this.Unknown_40h_Data != null ? this.Unknown_40h_Data.Position : 0);
            //this.qqnt6a = (ushort)(this.qq66data != null ? this.qq66data.Count : 0);
            this.Unknown_60h_Pointer = (ulong)(this.Unknown_60h_Data != null ? this.Unknown_60h_Data.Position : 0);
            //this.cnt0a = (ushort)(this.pxxxxx_0data != null ? this.pxxxxx_0data.Count : 0);
            this.Unknown_70h_Pointer = (ulong)(this.Unknown_70h_Data != null ? this.Unknown_70h_Data.Position : 0);
            //this.cnt1a = (ushort)(this.pxxxxx_1data != null ? this.pxxxxx_1data.Count : 0);
            this.Unknown_80h_Pointer = (ulong)(this.Unknown_80h_Data != null ? this.Unknown_80h_Data.Position : 0);
            //this.cnt2a = (ushort)(this.pxxxxx_2data != null ? this.pxxxxx_2data.Count : 0);
            this.Unknown_A0h_Pointer = (ulong)(this.Unknown_A0h_Data != null ? this.Unknown_A0h_Data.Position : 0);
            //this.cnt3a = (ushort)(this.pxxxxx_3data != null ? this.pxxxxx_3data.Count : 0);
            this.Unknown_B0h_Pointer = (ulong)(this.Unknown_B0h_Data != null ? this.Unknown_B0h_Data.Position : 0);
            //this.cnt4a = (ushort)(this.pxxxxx_4data != null ? this.pxxxxx_4data.Count : 0);
            this.Unknown_C0h_Pointer = (ulong)(this.Unknown_C0h_Data != null ? this.Unknown_C0h_Data.Position : 0);
            //this.cnt5a = (ushort)(this.pxxxxx_5data != null ? this.pxxxxx_5data.Count : 0);
            this.Unknown_E0h_Pointer = (ulong)(this.Unknown_E0h_Data != null ? this.Unknown_E0h_Data.Position : 0);
            //this.cnt6a = (ushort)(this.pxxxxx_6data != null ? this.pxxxxx_6data.Count : 0);
            this.Unknown_F0h_Pointer = (ulong)(this.Unknown_F0h_Data != null ? this.Unknown_F0h_Data.Position : 0);
            //this.cnt7a = (ushort)(this.pxxxxx_7data != null ? this.pxxxxx_7data.Count : 0);
            this.Unknown_100h_Pointer = (ulong)(this.Unknown_100h_Data != null ? this.Unknown_100h_Data.Position : 0);
            //this.cnt8a = (ushort)(this.pxxxxx_8data != null ? this.pxxxxx_8data.Count : 0);
            this.Unknown_128h_Pointer = (ulong)(this.Unknown_128h_Data != null ? this.Unknown_128h_Data.Position : 0);
            //this.qq11cntxx = (ushort)(this.qq11data != null ? this.qq11data.Count : 0);

            // write structure data
            writer.Write(this.VFT);
            writer.Write(this.Unknown_4h);
            writer.Write(this.Unknown_8h);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.Write(this.Unknown_18h);
            writer.Write(this.Unknown_1Ch);
            writer.Write(this.Unknown_20h_Pointer);
            writer.Write(this.Count1);
            writer.Write(this.Count2);
            writer.Write(this.Unknown_2Ch);
            writer.Write(this.Unknown_30h_Pointer);
            writer.Write(this.Count3);
            writer.Write(this.Count4);
            writer.Write(this.Unknown_3Ch);
            writer.Write(this.Unknown_40h_Pointer);
            writer.Write(this.Count5);
            writer.Write(this.Count6);
            writer.Write(this.Unknown_4Ch);
            writer.Write(this.Unknown_50h);
            writer.Write(this.Unknown_54h);
            writer.Write(this.Unknown_58h);
            writer.Write(this.Unknown_5Ch);
            writer.Write(this.Unknown_60h_Pointer);
            writer.Write(this.Count7);
            writer.Write(this.Count8);
            writer.Write(this.Unknown_6Ch);
            writer.Write(this.Unknown_70h_Pointer);
            writer.Write(this.Count9);
            writer.Write(this.Count10);
            writer.Write(this.Unknown_7Ch);
            writer.Write(this.Unknown_80h_Pointer);
            writer.Write(this.Count11);
            writer.Write(this.Count12);
            writer.Write(this.Unknown_8Ch);
            writer.Write(this.Unknown_90h);
            writer.Write(this.Unknown_94h);
            writer.Write(this.Unknown_98h);
            writer.Write(this.Unknown_9Ch);
            writer.Write(this.Unknown_A0h_Pointer);
            writer.Write(this.Count13);
            writer.Write(this.Count14);
            writer.Write(this.Unknown_ACh);
            writer.Write(this.Unknown_B0h_Pointer);
            writer.Write(this.Count15);
            writer.Write(this.Count16);
            writer.Write(this.Unknown_BCh);
            writer.Write(this.Unknown_C0h_Pointer);
            writer.Write(this.Count17);
            writer.Write(this.Count18);
            writer.Write(this.Unknown_CCh);
            writer.Write(this.Unknown_D0h);
            writer.Write(this.Unknown_D4h);
            writer.Write(this.Unknown_D8h);
            writer.Write(this.Unknown_DCh);
            writer.Write(this.Unknown_E0h_Pointer);
            writer.Write(this.Count19);
            writer.Write(this.Count20);
            writer.Write(this.Unknown_ECh);
            writer.Write(this.Unknown_F0h_Pointer);
            writer.Write(this.Count21);
            writer.Write(this.Count22);
            writer.Write(this.Unknown_FCh);
            writer.Write(this.Unknown_100h_Pointer);
            writer.Write(this.Count23);
            writer.Write(this.Count24);
            writer.Write(this.Unknown_10Ch);
            writer.Write(this.Unknown_110h);
            writer.Write(this.Unknown_114h);
            writer.Write(this.Unknown_118h);
            writer.Write(this.Unknown_11Ch);
            writer.Write(this.Unknown_120h);
            writer.Write(this.Unknown_124h);
            writer.Write(this.Unknown_128h_Pointer);
            writer.Write(this.Count25);
            writer.Write(this.Unknown_132h);
            writer.Write(this.Unknown_134h);
            writer.Write(this.Unknown_138h);
            writer.Write(this.Unknown_13Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (Unknown_20h_Data != null) list.Add(Unknown_20h_Data);
            if (Unknown_30h_Data != null) list.Add(Unknown_30h_Data);
            if (Unknown_40h_Data != null) list.Add(Unknown_40h_Data);
            if (Unknown_60h_Data != null) list.Add(Unknown_60h_Data);
            if (Unknown_70h_Data != null) list.Add(Unknown_70h_Data);
            if (Unknown_80h_Data != null) list.Add(Unknown_80h_Data);
            if (Unknown_A0h_Data != null) list.Add(Unknown_A0h_Data);
            if (Unknown_B0h_Data != null) list.Add(Unknown_B0h_Data);
            if (Unknown_C0h_Data != null) list.Add(Unknown_C0h_Data);
            if (Unknown_E0h_Data != null) list.Add(Unknown_E0h_Data);
            if (Unknown_F0h_Data != null) list.Add(Unknown_F0h_Data);
            if (Unknown_100h_Data != null) list.Add(Unknown_100h_Data);
            if (Unknown_128h_Data != null) list.Add(Unknown_128h_Data);
            return list.ToArray();
        }
    }
}