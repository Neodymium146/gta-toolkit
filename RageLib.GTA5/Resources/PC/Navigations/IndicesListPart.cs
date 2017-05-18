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
    public class IndicesListPart : ResourceSystemBlock
    {
        public override long Length => 0x10;

        // structure data
        public ulong IndicesPointer;
        public uint IndicesCount;
        public uint Unknown_Ch; // 0x00000000

        // reference data
        public ResourceSimpleArray<ushort_r> Indices;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.IndicesPointer = reader.ReadUInt64();
            this.IndicesCount = reader.ReadUInt32();
            this.Unknown_Ch = reader.ReadUInt32();

            // read reference data
            this.Indices = reader.ReadBlockAt<ResourceSimpleArray<ushort_r>>(
                this.IndicesPointer, // offset
                this.IndicesCount
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.IndicesPointer = (ulong)(this.Indices != null ? this.Indices.Position : 0);
            this.IndicesCount = (uint)(this.Indices != null ? this.Indices.Count : 0);

            // write structure data
            writer.Write(this.IndicesPointer);
            writer.Write(this.IndicesCount);
            writer.Write(this.Unknown_Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (Indices != null) list.Add(Indices);
            return list.ToArray();
        }
    }
}
