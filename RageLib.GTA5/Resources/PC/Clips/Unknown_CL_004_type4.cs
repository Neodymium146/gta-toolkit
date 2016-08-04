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

namespace RageLib.Resources.GTA5.PC.Clips
{
    public class Unknown_CL_004_type4 : Unknown_CL_004
    {
        public override long Length
        {
            get { return 48; }
        }

        // structure data
        public uint Unknown_10h; // 0x00000000
        public uint Unknown_14h; // 0x00000000
        public uint Unknown_18h;
        public uint Unknown_1Ch; // 0x00000000
        public ulong p1;
        public ushort c1;
        public ushort c2;
        public uint Unknown_2Ch; // 0x00000000

        // reference data
        public ResourceSimpleArray<byte_r> p1data; // string (byte array...)

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.Unknown_10h = reader.ReadUInt32();
            this.Unknown_14h = reader.ReadUInt32();
            this.Unknown_18h = reader.ReadUInt32();
            this.Unknown_1Ch = reader.ReadUInt32();
            this.p1 = reader.ReadUInt64();
            this.c1 = reader.ReadUInt16();
            this.c2 = reader.ReadUInt16();
            this.Unknown_2Ch = reader.ReadUInt32();

            // read reference data
            this.p1data = reader.ReadBlockAt<ResourceSimpleArray<byte_r>>(
                this.p1, // offset
                this.c2
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.p1 = (ulong)(this.p1data != null ? this.p1data.Position : 0);
            //this.c2 = (ushort)(this.p1data != null ? this.p1data.Count : 0);

            // write structure data
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.Write(this.Unknown_18h);
            writer.Write(this.Unknown_1Ch);
            writer.Write(this.p1);
            writer.Write(this.c1);
            writer.Write(this.c2);
            writer.Write(this.Unknown_2Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>(base.GetReferences());
            if (p1data != null) list.Add(p1data);
            return list.ToArray();
        }
    }
}
