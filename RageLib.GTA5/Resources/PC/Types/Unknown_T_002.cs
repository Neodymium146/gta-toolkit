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

namespace RageLib.Resources.GTA5.PC.Types
{
    public class Unknown_T_002 : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 24; }
        }

        // structure data
        public uint Unknown_0h;
        public uint Unknown_4h;
        public ulong UnkPtr_8h;
        public uint length;
        public uint Unknown_14h; // 0x00000000

        // reference data
        public ResourceSimpleArray<Unknown_T_002_entry> UnkData_8h;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.Unknown_0h = reader.ReadUInt32();
            this.Unknown_4h = reader.ReadUInt32();
            this.UnkPtr_8h = reader.ReadUInt64();
            this.length = reader.ReadUInt32();
            this.Unknown_14h = reader.ReadUInt32();

            // read reference data
            this.UnkData_8h = reader.ReadBlockAt<ResourceSimpleArray<Unknown_T_002_entry>>(
                this.UnkPtr_8h, // offset
                this.length
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.UnkPtr_8h = (ulong)(this.UnkData_8h != null ? this.UnkData_8h.Position : 0);
            this.length = (uint)(this.UnkData_8h != null ? this.UnkData_8h.Count : 0);

            // write structure data
            writer.Write(this.Unknown_0h);
            writer.Write(this.Unknown_4h);
            writer.Write(this.UnkPtr_8h);
            writer.Write(this.length);
            writer.Write(this.Unknown_14h);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (UnkData_8h != null) list.Add(UnkData_8h);
            return list.ToArray();
        }

    }
}