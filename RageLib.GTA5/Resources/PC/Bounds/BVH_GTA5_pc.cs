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
using System;

namespace RageLib.Resources.GTA5.PC.Bounds
{
    public class BVH_GTA5_pc : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 128; }
        }

        // structure data
        public ulong Unknown_0h_Pointer;
        public uint Count1;
        public uint Count2;
        public uint Unknown_10h; // 0x00000000
        public uint Unknown_14h; // 0x00000000
        public uint Unknown_18h; // 0x00000000
        public uint Unknown_1Ch; // 0x00000000
        public RAGE_Vector4 Unknown_20h;
        public RAGE_Vector4 Unknown_30h;
        public RAGE_Vector4 Unknown_40h;
        public RAGE_Vector4 Unknown_50h;
        public RAGE_Vector4 Unknown_60h;
        public ulong Unknown_70h_Pointer;
        public ushort Count3;
        public ushort Count4;
        public uint Unknown_7Ch; // 0x00000000

        // reference data
        public ResourceSimpleArray<Unknown_B_004> Unknown_0h_Data;
        public ResourceSimpleArray<Unknown_B_005> Unknown_70h_Data;

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
            this.Unknown_20h = reader.ReadBlock<RAGE_Vector4>();
            this.Unknown_30h = reader.ReadBlock<RAGE_Vector4>();
            this.Unknown_40h = reader.ReadBlock<RAGE_Vector4>();
            this.Unknown_50h = reader.ReadBlock<RAGE_Vector4>();
            this.Unknown_60h = reader.ReadBlock<RAGE_Vector4>();
            this.Unknown_70h_Pointer = reader.ReadUInt64();
            this.Count3 = reader.ReadUInt16();
            this.Count4 = reader.ReadUInt16();
            this.Unknown_7Ch = reader.ReadUInt32();

            // read reference data
            this.Unknown_0h_Data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_B_004>>(
                this.Unknown_0h_Pointer, // offset
                this.Count1
            );
            this.Unknown_70h_Data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_B_005>>(
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
            this.Count1 = (uint)(this.Unknown_0h_Data != null ? this.Unknown_0h_Data.Count : 0);
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
            writer.WriteBlock(this.Unknown_20h);
            writer.WriteBlock(this.Unknown_30h);
            writer.WriteBlock(this.Unknown_40h);
            writer.WriteBlock(this.Unknown_50h);
            writer.WriteBlock(this.Unknown_60h);
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

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(0x20,Unknown_20h ),
                new Tuple<long, IResourceBlock>(0x30,Unknown_30h ),
                new Tuple<long, IResourceBlock>(0x40,Unknown_40h ),
                new Tuple<long, IResourceBlock>(0x50,Unknown_50h ),
                new Tuple<long, IResourceBlock>(0x60,Unknown_60h )
            };
                 
        }
    }
}