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

using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Bounds
{
    // phBoundBVH
    public class BoundBVH : BoundGeometry
    {
        public override long Length => 0x150;

        // structure data
        public ulong BvhPointer;
        public uint Unknown_138h; // 0x00000000
        public uint Unknown_13Ch; // 0x00000000
        public ushort Unknown_140h; // 0xFFFF
        public ushort Unknown_142h; // 0x0000
        public uint Unknown_144h; // 0x00000000
        public uint Unknown_148h; // 0x00000000
        public uint Unknown_14Ch; // 0x00000000

        // reference data
        public BVH BVH;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.BvhPointer = reader.ReadUInt64();
            this.Unknown_138h = reader.ReadUInt32();
            this.Unknown_13Ch = reader.ReadUInt32();
            this.Unknown_140h = reader.ReadUInt16();
            this.Unknown_142h = reader.ReadUInt16();
            this.Unknown_144h = reader.ReadUInt32();
            this.Unknown_148h = reader.ReadUInt32();
            this.Unknown_14Ch = reader.ReadUInt32();

            // read reference data
            this.BVH = reader.ReadBlockAt<BVH>(
                this.BvhPointer // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.BvhPointer = (ulong)(this.BVH != null ? this.BVH.Position : 0);

            // write structure data
            writer.Write(this.BvhPointer);
            writer.Write(this.Unknown_138h);
            writer.Write(this.Unknown_13Ch);
            writer.Write(this.Unknown_140h);
            writer.Write(this.Unknown_142h);
            writer.Write(this.Unknown_144h);
            writer.Write(this.Unknown_148h);
            writer.Write(this.Unknown_14Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>(base.GetReferences());
            if (BVH != null) list.Add(BVH);
            return list.ToArray();
        }
    }
}
