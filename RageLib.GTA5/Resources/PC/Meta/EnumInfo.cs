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

namespace RageLib.Resources.GTA5.PC.Meta
{
    public class EnumInfo : ResourceSystemBlock
    {
        public override long Length => 24;

        // structure data
        public int EnumNameHash { get; set; }
        public int EnumKey { get; set; }
        public long EntriesPointer { get; private set; }
        public int EntriesCount { get; private set; }
        public int Unknown_14h { get; set; } = 0x00000000;

        // reference data
        public ResourceSimpleArray<EnumEntryInfo> Entries;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.EnumNameHash = reader.ReadInt32();
            this.EnumKey = reader.ReadInt32();
            this.EntriesPointer = reader.ReadInt64();
            this.EntriesCount = reader.ReadInt32();
            this.Unknown_14h = reader.ReadInt32();

            // read reference data
            this.Entries = reader.ReadBlockAt<ResourceSimpleArray<EnumEntryInfo>>(
                (ulong)this.EntriesPointer, // offset
                this.EntriesCount
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.EntriesPointer = this.Entries?.Position ?? 0;
            this.EntriesCount = this.Entries?.Count ?? 0;

            // write structure data
            writer.Write(this.EnumNameHash);
            writer.Write(this.EnumKey);
            writer.Write(this.EntriesPointer);
            writer.Write(this.EntriesCount);
            writer.Write(this.Unknown_14h);
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
