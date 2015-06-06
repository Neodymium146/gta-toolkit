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
using RageLib.Resources.GTA5.PC.Drawables;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Particles
{
    public class Unknown_P_022 : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 48; }
        }

        // structure data
        public uint Unknown_0h;
        public uint Unknown_4h;
        public uint Unknown_8h;
        public uint Unknown_Ch;
        public ulong p1;
        public ulong p2;
        public uint Unknown_20h;
        public uint Unknown_24h;
        public uint Unknown_28h;
        public uint Unknown_2Ch;

        // reference data
        public string_r p1data;
        public DrawableBase_GTA5_pc p2data;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.Unknown_0h = reader.ReadUInt32();
            this.Unknown_4h = reader.ReadUInt32();
            this.Unknown_8h = reader.ReadUInt32();
            this.Unknown_Ch = reader.ReadUInt32();
            this.p1 = reader.ReadUInt64();
            this.p2 = reader.ReadUInt64();
            this.Unknown_20h = reader.ReadUInt32();
            this.Unknown_24h = reader.ReadUInt32();
            this.Unknown_28h = reader.ReadUInt32();
            this.Unknown_2Ch = reader.ReadUInt32();

            // read reference data
            this.p1data = reader.ReadBlockAt<string_r>(
                this.p1 // offset
            );
            this.p2data = reader.ReadBlockAt<DrawableBase_GTA5_pc>(
                this.p2 // offset
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

            // write structure data
            writer.Write(this.Unknown_0h);
            writer.Write(this.Unknown_4h);
            writer.Write(this.Unknown_8h);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.p1);
            writer.Write(this.p2);
            writer.Write(this.Unknown_20h);
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
            if (p1data != null) list.Add(p1data);
            if (p2data != null) list.Add(p2data);
            return list.ToArray();
        }

    }
}