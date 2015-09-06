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
    public class Unknown_C_004 : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 384; }
        }

        // structure data
        public uint VFT;
        public uint Unknown_4h; // 0x00000001
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
        public uint Unknown_50h;
        public uint Unknown_54h; // 0x00000001
        public uint Unknown_58h; // 0x00000000
        public uint Unknown_5Ch; // 0x00000000
        public uint Unknown_60h; // 0x00000000
        public uint Unknown_64h; // 0x00000000
        public uint Unknown_68h; // 0x00000000
        public uint Unknown_6Ch; // 0x00000000
        public ulong p0;
        public ushort c0a;
        public ushort c0b;
        public uint Unknown_7Ch; // 0x00000000
        public ulong p1;
        public ushort c1a;
        public ushort c1b;
        public uint Unknown_8Ch; // 0x00000000
        public uint Unknown_90h; // 0x00000000
        public uint Unknown_94h; // 0x00000000
        public uint Unknown_98h; // 0x00000000
        public uint Unknown_9Ch; // 0x00000000
        public uint Unknown_A0h; // 0x00000000
        public uint Unknown_A4h; // 0x00000000
        public uint Unknown_A8h; // 0x461C3C00
        public uint Unknown_ACh; // 0x461C3C00
        public uint Unknown_B0h; // 0x00000000
        public uint Unknown_B4h; // 0x00000000
        public uint Unknown_B8h; // 0x00000000
        public uint Unknown_BCh; // 0x00000000
        public uint Unknown_C0h; // 0x00000000
        public uint Unknown_C4h; // 0x00000000
        public uint Unknown_C8h; // 0x00000000
        public uint Unknown_CCh; // 0x00000000
        public uint Unknown_D0h; // 0x00000000
        public uint Unknown_D4h; // 0x00000000
        public uint Unknown_D8h; // 0x00000000
        public uint Unknown_DCh; // 0x00000000
        public uint Unknown_E0h; // 0x00000000
        public uint Unknown_E4h; // 0x00000000
        public uint Unknown_E8h;
        public uint Unknown_ECh;
        public uint Unknown_F0h;
        public uint Unknown_F4h; // 0x00000000
        public uint Unknown_F8h; // 0x00000003
        public uint Unknown_FCh; // 0x00000000
        public ulong p444;
        public ushort c444a;
        public ushort c444b;
        public uint Unknown_10Ch; // 0x00000000
        public ulong p2;
        public ushort c2a;
        public ushort c2b;
        public uint Unknown_11Ch; // 0x00000000
        public uint Unknown_120h; // 0x00000000
        public uint Unknown_124h; // 0x00000000
        public uint Unknown_128h; // 0x00000000
        public uint Unknown_12Ch; // 0x00000000
        public ulong p3;
        public uint Unknown_138h; // 0x00100000
        public uint Unknown_13Ch; // 0x00000000
        public ulong p4;
        public ushort c4a;
        public ushort c4b;
        public uint Unknown_14Ch; // 0x00000000
        public uint Unknown_150h; // 0x00000000
        public uint Unknown_154h; // 0x00000000
        public uint Unknown_158h;
        public uint Unknown_15Ch; // 0x00000000
        public uint Unknown_160h; // 0x00000000
        public uint Unknown_164h; // 0x00000000
        public uint Unknown_168h; // 0x00000000
        public uint Unknown_16Ch; // 0x00000000
        public uint Unknown_170h; // 0x00000000
        public uint Unknown_174h; // 0x00000000
        public uint Unknown_178h; // 0x00000000
        public uint Unknown_17Ch; // 0x00000000

        // reference data
        public ResourceSimpleArray<Unknown_C_007> p0data;
        public ResourceSimpleArray<Unknown_C_008> p1data;
        public ResourceSimpleArray<Unknown_C_009> p444data;
        public ResourceSimpleArray<Unknown_C_010> p2data;
        public Unknown_C_011 p3data;
        public ResourceSimpleArray<uint_r> p4data;

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
            this.Unknown_50h = reader.ReadUInt32();
            this.Unknown_54h = reader.ReadUInt32();
            this.Unknown_58h = reader.ReadUInt32();
            this.Unknown_5Ch = reader.ReadUInt32();
            this.Unknown_60h = reader.ReadUInt32();
            this.Unknown_64h = reader.ReadUInt32();
            this.Unknown_68h = reader.ReadUInt32();
            this.Unknown_6Ch = reader.ReadUInt32();
            this.p0 = reader.ReadUInt64();
            this.c0a = reader.ReadUInt16();
            this.c0b = reader.ReadUInt16();
            this.Unknown_7Ch = reader.ReadUInt32();
            this.p1 = reader.ReadUInt64();
            this.c1a = reader.ReadUInt16();
            this.c1b = reader.ReadUInt16();
            this.Unknown_8Ch = reader.ReadUInt32();
            this.Unknown_90h = reader.ReadUInt32();
            this.Unknown_94h = reader.ReadUInt32();
            this.Unknown_98h = reader.ReadUInt32();
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
            this.Unknown_D0h = reader.ReadUInt32();
            this.Unknown_D4h = reader.ReadUInt32();
            this.Unknown_D8h = reader.ReadUInt32();
            this.Unknown_DCh = reader.ReadUInt32();
            this.Unknown_E0h = reader.ReadUInt32();
            this.Unknown_E4h = reader.ReadUInt32();
            this.Unknown_E8h = reader.ReadUInt32();
            this.Unknown_ECh = reader.ReadUInt32();
            this.Unknown_F0h = reader.ReadUInt32();
            this.Unknown_F4h = reader.ReadUInt32();
            this.Unknown_F8h = reader.ReadUInt32();
            this.Unknown_FCh = reader.ReadUInt32();
            this.p444 = reader.ReadUInt64();
            this.c444a = reader.ReadUInt16();
            this.c444b = reader.ReadUInt16();
            this.Unknown_10Ch = reader.ReadUInt32();
            this.p2 = reader.ReadUInt64();
            this.c2a = reader.ReadUInt16();
            this.c2b = reader.ReadUInt16();
            this.Unknown_11Ch = reader.ReadUInt32();
            this.Unknown_120h = reader.ReadUInt32();
            this.Unknown_124h = reader.ReadUInt32();
            this.Unknown_128h = reader.ReadUInt32();
            this.Unknown_12Ch = reader.ReadUInt32();
            this.p3 = reader.ReadUInt64();
            this.Unknown_138h = reader.ReadUInt32();
            this.Unknown_13Ch = reader.ReadUInt32();
            this.p4 = reader.ReadUInt64();
            this.c4a = reader.ReadUInt16();
            this.c4b = reader.ReadUInt16();
            this.Unknown_14Ch = reader.ReadUInt32();
            this.Unknown_150h = reader.ReadUInt32();
            this.Unknown_154h = reader.ReadUInt32();
            this.Unknown_158h = reader.ReadUInt32();
            this.Unknown_15Ch = reader.ReadUInt32();
            this.Unknown_160h = reader.ReadUInt32();
            this.Unknown_164h = reader.ReadUInt32();
            this.Unknown_168h = reader.ReadUInt32();
            this.Unknown_16Ch = reader.ReadUInt32();
            this.Unknown_170h = reader.ReadUInt32();
            this.Unknown_174h = reader.ReadUInt32();
            this.Unknown_178h = reader.ReadUInt32();
            this.Unknown_17Ch = reader.ReadUInt32();

            // read reference data
            this.p0data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_C_007>>(
                this.p0, // offset
                this.c0a
            );
            this.p1data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_C_008>>(
                this.p1, // offset
                this.c1a
            );
            this.p444data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_C_009>>(
                this.p444, // offset
                this.c444a
            );
            this.p2data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_C_010>>(
                this.p2, // offset
                this.c2a
            );
            this.p3data = reader.ReadBlockAt<Unknown_C_011>(
                this.p3 // offset
            );
            this.p4data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(
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
            this.p0 = (ulong)(this.p0data != null ? this.p0data.Position : 0);
            //this.c0a = (ushort)(this.p0data != null ? this.p0data.Count : 0);
            this.p1 = (ulong)(this.p1data != null ? this.p1data.Position : 0);
            //this.c1a = (ushort)(this.p1data != null ? this.p1data.Count : 0);
            this.p444 = (ulong)(this.p444data != null ? this.p444data.Position : 0);
            //this.c444a = (ushort)(this.p444data != null ? this.p444data.Count : 0);
            this.p2 = (ulong)(this.p2data != null ? this.p2data.Position : 0);
            //this.c2a = (ushort)(this.p2data != null ? this.p2data.Count : 0);
            this.p3 = (ulong)(this.p3data != null ? this.p3data.Position : 0);
            this.p4 = (ulong)(this.p4data != null ? this.p4data.Position : 0);
            //this.c4a = (ushort)(this.p4data != null ? this.p4data.Count : 0);

            // write structure data
            writer.Write(this.VFT);
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
            writer.Write(this.Unknown_50h);
            writer.Write(this.Unknown_54h);
            writer.Write(this.Unknown_58h);
            writer.Write(this.Unknown_5Ch);
            writer.Write(this.Unknown_60h);
            writer.Write(this.Unknown_64h);
            writer.Write(this.Unknown_68h);
            writer.Write(this.Unknown_6Ch);
            writer.Write(this.p0);
            writer.Write(this.c0a);
            writer.Write(this.c0b);
            writer.Write(this.Unknown_7Ch);
            writer.Write(this.p1);
            writer.Write(this.c1a);
            writer.Write(this.c1b);
            writer.Write(this.Unknown_8Ch);
            writer.Write(this.Unknown_90h);
            writer.Write(this.Unknown_94h);
            writer.Write(this.Unknown_98h);
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
            writer.Write(this.Unknown_D0h);
            writer.Write(this.Unknown_D4h);
            writer.Write(this.Unknown_D8h);
            writer.Write(this.Unknown_DCh);
            writer.Write(this.Unknown_E0h);
            writer.Write(this.Unknown_E4h);
            writer.Write(this.Unknown_E8h);
            writer.Write(this.Unknown_ECh);
            writer.Write(this.Unknown_F0h);
            writer.Write(this.Unknown_F4h);
            writer.Write(this.Unknown_F8h);
            writer.Write(this.Unknown_FCh);
            writer.Write(this.p444);
            writer.Write(this.c444a);
            writer.Write(this.c444b);
            writer.Write(this.Unknown_10Ch);
            writer.Write(this.p2);
            writer.Write(this.c2a);
            writer.Write(this.c2b);
            writer.Write(this.Unknown_11Ch);
            writer.Write(this.Unknown_120h);
            writer.Write(this.Unknown_124h);
            writer.Write(this.Unknown_128h);
            writer.Write(this.Unknown_12Ch);
            writer.Write(this.p3);
            writer.Write(this.Unknown_138h);
            writer.Write(this.Unknown_13Ch);
            writer.Write(this.p4);
            writer.Write(this.c4a);
            writer.Write(this.c4b);
            writer.Write(this.Unknown_14Ch);
            writer.Write(this.Unknown_150h);
            writer.Write(this.Unknown_154h);
            writer.Write(this.Unknown_158h);
            writer.Write(this.Unknown_15Ch);
            writer.Write(this.Unknown_160h);
            writer.Write(this.Unknown_164h);
            writer.Write(this.Unknown_168h);
            writer.Write(this.Unknown_16Ch);
            writer.Write(this.Unknown_170h);
            writer.Write(this.Unknown_174h);
            writer.Write(this.Unknown_178h);
            writer.Write(this.Unknown_17Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (p0data != null) list.Add(p0data);
            if (p1data != null) list.Add(p1data);
            if (p444data != null) list.Add(p444data);
            if (p2data != null) list.Add(p2data);
            if (p3data != null) list.Add(p3data);
            if (p4data != null) list.Add(p4data);
            return list.ToArray();
        }

    }
}