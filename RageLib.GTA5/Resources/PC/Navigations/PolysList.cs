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
    // aiSplitArray<TNavMeshPoly,341>
    public class PolysList : ResourceSystemBlock
    {
        public override long Length => 0x30;

        // structure data
        public uint VFT;
        public uint Unknown_4h; // 0x00000001
        public uint Unknown_8h;
        public uint Unknown_Ch; // 0x00000000
        public ulong ListPartsPointer;
        public ulong ListOffsetsPointer;
        public uint ListPartsCount;
        public uint Unknown_24h; // 0x00000000
        public uint Unknown_28h; // 0x00000000
        public uint Unknown_2Ch; // 0x00000000

        // reference data
        public ResourceSimpleArray<PolysListPart> ListParts;
        public ResourceSimpleArray<uint_r> ListOffsets;

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
            this.ListPartsPointer = reader.ReadUInt64();
            this.ListOffsetsPointer = reader.ReadUInt64();
            this.ListPartsCount = reader.ReadUInt32();
            this.Unknown_24h = reader.ReadUInt32();
            this.Unknown_28h = reader.ReadUInt32();
            this.Unknown_2Ch = reader.ReadUInt32();

            // read reference data
            this.ListParts = reader.ReadBlockAt<ResourceSimpleArray<PolysListPart>>(
                this.ListPartsPointer, // offset
                this.ListPartsCount
            );
            this.ListOffsets = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(
                this.ListOffsetsPointer, // offset
                this.ListPartsCount
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.ListPartsPointer = (ulong)(this.ListParts != null ? this.ListParts.Position : 0);
            this.ListOffsetsPointer = (ulong)(this.ListOffsets != null ? this.ListOffsets.Position : 0);
            this.ListPartsCount = (uint)(this.ListParts != null ? this.ListParts.Count : 0);

            // write structure data
            writer.Write(this.VFT);
            writer.Write(this.Unknown_4h);
            writer.Write(this.Unknown_8h);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.ListPartsPointer);
            writer.Write(this.ListOffsetsPointer);
            writer.Write(this.ListPartsCount);
            writer.Write(this.Unknown_24h);
            writer.Write(this.Unknown_28h);
            writer.Write(this.Unknown_2Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (ListParts != null) list.Add(ListParts);
            if (ListOffsets != null) list.Add(ListOffsets);
            return list.ToArray();
        }
    }
}
