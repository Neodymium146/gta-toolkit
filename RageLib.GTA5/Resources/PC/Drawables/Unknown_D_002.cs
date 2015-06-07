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

namespace RageLib.Resources.GTA5.PC.Drawables
{
    public class Unknown_D_002 : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 64; }
        }

        // structure data
        public uint VFT;
        public uint Unknown_4h; // 0x00000001
        public uint Unknown_8h; // 0x00000000
        public uint Unknown_Ch; // 0x00000000
        public ulong Unknown_10h_Pointer;
        public ulong Unknown_18h_Pointer;
        public uint Unknown_20h; // 0x00000000
        public uint Unknown_24h; // 0x00000000
        public uint Unknown_28h; // 0x00000000
        public uint Unknown_2Ch; // 0x00000000
        public ushort Count0;
        public ushort Count1;
        public uint Unknown_34h; // 0x00010000
        public uint Unknown_38h; // 0x00000000
        public uint Unknown_3Ch; // 0x00000000

        // reference data
        public ResourceSimpleArray<Unknown_D_004> Unknown_10h_Data;
        public ResourceSimpleArray<Unknown_D_003> Unknown_18h_Data;

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
            this.Unknown_10h_Pointer = reader.ReadUInt64();
            this.Unknown_18h_Pointer = reader.ReadUInt64();
            this.Unknown_20h = reader.ReadUInt32();
            this.Unknown_24h = reader.ReadUInt32();
            this.Unknown_28h = reader.ReadUInt32();
            this.Unknown_2Ch = reader.ReadUInt32();
            this.Count0 = reader.ReadUInt16();
            this.Count1 = reader.ReadUInt16();
            this.Unknown_34h = reader.ReadUInt32();
            this.Unknown_38h = reader.ReadUInt32();
            this.Unknown_3Ch = reader.ReadUInt32();

            // read reference data
            this.Unknown_10h_Data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_D_004>>(
                this.Unknown_10h_Pointer, // offset
                this.Count0
            );
            this.Unknown_18h_Data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_D_003>>(
                this.Unknown_18h_Pointer, // offset
                this.Count1
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.Unknown_10h_Pointer = (ulong)(this.Unknown_10h_Data != null ? this.Unknown_10h_Data.Position : 0);
            this.Unknown_18h_Pointer = (ulong)(this.Unknown_18h_Data != null ? this.Unknown_18h_Data.Position : 0);
            //this.Count0 = (ushort)(this.Unknown_10h_Data != null ? this.Unknown_10h_Data.Count : 0);
            //this.Count1 = (ushort)(this.Unknown_18h_Data != null ? this.Unknown_18h_Data.Count : 0);

            // write structure data
            writer.Write(this.VFT);
            writer.Write(this.Unknown_4h);
            writer.Write(this.Unknown_8h);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.Unknown_10h_Pointer);
            writer.Write(this.Unknown_18h_Pointer);
            writer.Write(this.Unknown_20h);
            writer.Write(this.Unknown_24h);
            writer.Write(this.Unknown_28h);
            writer.Write(this.Unknown_2Ch);
            writer.Write(this.Count0);
            writer.Write(this.Count1);
            writer.Write(this.Unknown_34h);
            writer.Write(this.Unknown_38h);
            writer.Write(this.Unknown_3Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (Unknown_10h_Data != null) list.Add(Unknown_10h_Data);
            if (Unknown_18h_Data != null) list.Add(Unknown_18h_Data);
            return list.ToArray();
        }
    }
}