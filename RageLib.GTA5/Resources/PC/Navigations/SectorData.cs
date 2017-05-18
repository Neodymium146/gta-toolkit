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
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Navigations
{
    public class SectorData : ResourceSystemBlock
    {
        public override long Length => 0x20;

        // structure data
        public uint c1;
        public uint Unknown_4h; // 0x00000000
        public ulong p1;
        public ulong p2;
        public ushort c2;
        public ushort c3;
        public uint Unknown_1Ch; // 0x00000000

        // reference data
        public ResourceSimpleArray<ushort_r> p1data;
        public ResourceSimpleArray<SectorDataUnk> p2data;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.c1 = reader.ReadUInt32();
            this.Unknown_4h = reader.ReadUInt32();
            this.p1 = reader.ReadUInt64();
            this.p2 = reader.ReadUInt64();
            this.c2 = reader.ReadUInt16();
            this.c3 = reader.ReadUInt16();
            this.Unknown_1Ch = reader.ReadUInt32();

            // read reference data
            this.p1data = reader.ReadBlockAt<ResourceSimpleArray<ushort_r>>(
                this.p1, // offset
                this.c2
            );
            this.p2data = reader.ReadBlockAt<ResourceSimpleArray<SectorDataUnk>>(
                this.p2, // offset
                this.c3
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.p1 = (ulong)(this.p1data != null ? this.p1data.Position : 0);
            this.p2 = (ulong)(this.p2data != null ? this.p2data.Position : 0);
            this.c2 = (ushort)(this.p1data != null ? this.p1data.Count : 0);
            this.c3 = (ushort)(this.p2data != null ? this.p2data.Count : 0);

            // write structure data
            writer.Write(this.c1);
            writer.Write(this.Unknown_4h);
            writer.Write(this.p1);
            writer.Write(this.p2);
            writer.Write(this.c2);
            writer.Write(this.c3);
            writer.Write(this.Unknown_1Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (p1data != null) list.Add(p1data);
            if (p2data != null) list.Add(p2data);
            return list.ToArray();
        }
    }
}
