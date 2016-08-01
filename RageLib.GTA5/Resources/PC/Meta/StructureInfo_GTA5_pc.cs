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

namespace RageLib.Resources.GTA5.PC.Meta
{
    public class StructureInfo_GTA5_pc : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 32; }
        }

        // structure data
        public uint StructureKey;
        public uint StructureNameHash;
        public uint Unknown_8h;
        public uint Unknown_Ch; // 0x00000000
        public ulong EntriesPointer;
        public uint StructureLength;
        public ushort Unknown_1Ch; // 0x0000
        public ushort EntriesCount;

        // reference data
        public ResourceSimpleArray<StructureEntryInfo_GTA5_pc> Entries;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.StructureKey = reader.ReadUInt32();
            this.StructureNameHash = reader.ReadUInt32();
            this.Unknown_8h = reader.ReadUInt32();
            this.Unknown_Ch = reader.ReadUInt32();
            this.EntriesPointer = reader.ReadUInt64();
            this.StructureLength = reader.ReadUInt32();
            this.Unknown_1Ch = reader.ReadUInt16();
            this.EntriesCount = reader.ReadUInt16();

            // read reference data
            this.Entries = reader.ReadBlockAt<ResourceSimpleArray<StructureEntryInfo_GTA5_pc>>(
                this.EntriesPointer, // offset
                this.EntriesCount
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.EntriesPointer = (ulong)(this.Entries != null ? this.Entries.Position : 0);
            this.EntriesCount = (ushort)(this.Entries != null ? this.Entries.Count : 0);

            // write structure data
            writer.Write(this.StructureKey);
            writer.Write(this.StructureNameHash);
            writer.Write(this.Unknown_8h);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.EntriesPointer);
            writer.Write(this.StructureLength);
            writer.Write(this.Unknown_1Ch);
            writer.Write(this.EntriesCount);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (Entries != null) list.Add(Entries);
            return list.ToArray();
        }
    }
}
