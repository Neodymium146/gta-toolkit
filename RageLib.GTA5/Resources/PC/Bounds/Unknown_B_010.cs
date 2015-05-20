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

namespace RageLib.Resources.GTA5.PC.Bounds
{
    public class Unknown_B_010 : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 128; }
        }

        // structure data
        public ulong Unknown_0h_Pointer;
        public uint Count1;
        public uint Count2;
        public uint Unknown_10h;
        public uint Unknown_14h;
        public uint Unknown_18h;
        public uint Unknown_1Ch;
        public uint Unknown_20h;
        public uint Unknown_24h;
        public uint Unknown_28h;
        public uint Unknown_2Ch;
        public uint Unknown_30h;
        public uint Unknown_34h;
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
        public ulong Unknown_70h_Pointer;
        public ushort Count3;
        public ushort Count4;
        public uint Unknown_7Ch;

        // reference data
        public ResourceSimpleArray<Unknown_B_008> Unknown_0h_Data;
        public ResourceSimpleArray<Unknown_B_009> Unknown_70h_Data;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.Unknown_0h_Pointer = reader.ReadUInt64();
            this.Count1 = reader.ReadUInt32();
            this.Count2 = reader.ReadUInt32();
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
            this.Count3 = reader.ReadUInt16();
            this.Count4 = reader.ReadUInt16();
            this.Unknown_7Ch = reader.ReadUInt32();

            // read reference data
            this.Unknown_0h_Data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_B_008>>(
                this.Unknown_0h_Pointer, // offset
                this.Count2
            );
            this.Unknown_70h_Data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_B_009>>(
                this.Unknown_70h_Pointer, // offset
                this.Count3
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.Unknown_0h_Pointer = (ulong)(this.Unknown_0h_Data != null ? this.Unknown_0h_Data.Position : 0);
            this.Count2 = (uint)(this.Unknown_0h_Data != null ? this.Unknown_0h_Data.Count : 0);
            this.Unknown_70h_Pointer = (ulong)(this.Unknown_70h_Data != null ? this.Unknown_70h_Data.Position : 0);
            this.Count3 = (ushort)(this.Unknown_70h_Data != null ? this.Unknown_70h_Data.Count : 0);

            // write structure data
            writer.Write(this.Unknown_0h_Pointer);
            writer.Write(this.Count1);
            writer.Write(this.Count2);
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
            writer.Write(this.Count3);
            writer.Write(this.Count4);
            writer.Write(this.Unknown_7Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (Unknown_0h_Data != null) list.Add(Unknown_0h_Data);
            if (Unknown_70h_Data != null) list.Add(Unknown_70h_Data);
            return list.ToArray();
        }
    }
}