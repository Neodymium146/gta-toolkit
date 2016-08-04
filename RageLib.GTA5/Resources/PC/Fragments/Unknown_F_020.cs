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
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Fragments
{
    public class Unknown_F_020 : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 176; }
        }

        // structure data
        public uint VFT;
        public uint Unknown_4h; // 0x00000001
        public uint Unknown_8h; // 0x00000000
        public uint Unknown_Ch; // 0x00000000
        public uint Unknown_10h; // 0x0000000A
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
        public uint Unknown_3Ch; // 0x00000001
        public uint Unknown_40h; // 0x00000000
        public uint Unknown_44h; // 0x00000000
        public uint Unknown_48h; // 0x00000000
        public uint Unknown_4Ch; // 0x00000000
        public uint Unknown_50h; // 0x00000000
        public uint Unknown_54h; // 0x00000000
        public uint Unknown_58h; // 0x00000000
        public uint Unknown_5Ch; // 0x00000000
        public uint Unknown_60h; // 0x3F800000
        public uint Unknown_64h; // 0x3F800000
        public uint Unknown_68h; // 0x3F800000
        public uint Unknown_6Ch; // 0x3F800000
        public ulong Unknown_70h_Pointer;
        public ulong Unknown_78h_Pointer;
        public ulong Unknown_80h_Pointer;
        public ulong Unknown_88h_Pointer;
        public uint Unknown_90h; // 0x00000000
        public uint Unknown_94h; // 0x00000000
        public uint Unknown_98h; // 0x00000000
        public uint Unknown_9Ch; // 0x00000000
        public ushort cnt2a;
        public ushort cnt2b;
        public uint Unknown_A4h; // 0x00000000
        public uint Unknown_A8h; // 0x00000000
        public uint Unknown_ACh; // 0x00000000

        // reference data
        public ResourcePointerArray64<Unknown_F_021> Unknown_70h_Data;
        public ResourceSimpleArray<RAGE_Matrix4> Unknown_78h_Data;
        public ResourceSimpleArray<RAGE_Matrix4> Unknown_80h_Data;
        public ResourceSimpleArray<Unknown_F_022> Unknown_88h_Data;

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
            this.Unknown_70h_Pointer = reader.ReadUInt64();
            this.Unknown_78h_Pointer = reader.ReadUInt64();
            this.Unknown_80h_Pointer = reader.ReadUInt64();
            this.Unknown_88h_Pointer = reader.ReadUInt64();
            this.Unknown_90h = reader.ReadUInt32();
            this.Unknown_94h = reader.ReadUInt32();
            this.Unknown_98h = reader.ReadUInt32();
            this.Unknown_9Ch = reader.ReadUInt32();
            this.cnt2a = reader.ReadUInt16();
            this.cnt2b = reader.ReadUInt16();
            this.Unknown_A4h = reader.ReadUInt32();
            this.Unknown_A8h = reader.ReadUInt32();
            this.Unknown_ACh = reader.ReadUInt32();

            // read reference data
            this.Unknown_70h_Data = reader.ReadBlockAt<ResourcePointerArray64<Unknown_F_021>>(
                this.Unknown_70h_Pointer, // offset
                this.cnt2a
            );
            this.Unknown_78h_Data = reader.ReadBlockAt<ResourceSimpleArray<RAGE_Matrix4>>(
                this.Unknown_78h_Pointer, // offset
                this.cnt2a
            );
            this.Unknown_80h_Data = reader.ReadBlockAt<ResourceSimpleArray<RAGE_Matrix4>>(
                this.Unknown_80h_Pointer, // offset
                this.cnt2a
            );
            this.Unknown_88h_Data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_F_022>>(
                this.Unknown_88h_Pointer, // offset
                this.cnt2a
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.Unknown_70h_Pointer = (ulong)(this.Unknown_70h_Data != null ? this.Unknown_70h_Data.Position : 0);
            this.Unknown_78h_Pointer = (ulong)(this.Unknown_78h_Data != null ? this.Unknown_78h_Data.Position : 0);
            this.Unknown_80h_Pointer = (ulong)(this.Unknown_80h_Data != null ? this.Unknown_80h_Data.Position : 0);
            this.Unknown_88h_Pointer = (ulong)(this.Unknown_88h_Data != null ? this.Unknown_88h_Data.Position : 0);
            //this.cnt2a = (ushort)(this.pxxxxx_1data != null ? this.pxxxxx_1data.Count : 0);

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
            writer.Write(this.Unknown_70h_Pointer);
            writer.Write(this.Unknown_78h_Pointer);
            writer.Write(this.Unknown_80h_Pointer);
            writer.Write(this.Unknown_88h_Pointer);
            writer.Write(this.Unknown_90h);
            writer.Write(this.Unknown_94h);
            writer.Write(this.Unknown_98h);
            writer.Write(this.Unknown_9Ch);
            writer.Write(this.cnt2a);
            writer.Write(this.cnt2b);
            writer.Write(this.Unknown_A4h);
            writer.Write(this.Unknown_A8h);
            writer.Write(this.Unknown_ACh);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (Unknown_70h_Data != null) list.Add(Unknown_70h_Data);
            if (Unknown_78h_Data != null) list.Add(Unknown_78h_Data);
            if (Unknown_80h_Data != null) list.Add(Unknown_80h_Data);
            if (Unknown_88h_Data != null) list.Add(Unknown_88h_Data);
            return list.ToArray();
        }
    }
}
