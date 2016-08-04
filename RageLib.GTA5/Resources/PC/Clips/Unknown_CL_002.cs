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

using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Clips
{
    public class Unknown_CL_002 : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 32; }
        }

        // structure data
        public uint Unknown_0h;
        public uint Unknown_4h; // 0x00000000
        public ulong DataPointer;
        public ulong NextPointer;
        public uint Unknown_18h; // 0x00000000
        public uint Unknown_1Ch; // 0x00000000

        // reference data
        public Unknown_CL_003 Data;
        public Unknown_CL_002 Next;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.Unknown_0h = reader.ReadUInt32();
            this.Unknown_4h = reader.ReadUInt32();
            this.DataPointer = reader.ReadUInt64();
            this.NextPointer = reader.ReadUInt64();
            this.Unknown_18h = reader.ReadUInt32();
            this.Unknown_1Ch = reader.ReadUInt32();

            // read reference data
            this.Data = reader.ReadBlockAt<Unknown_CL_003>(
                this.DataPointer // offset
            );
            this.Next = reader.ReadBlockAt<Unknown_CL_002>(
                this.NextPointer // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.DataPointer = (ulong)(this.Data != null ? this.Data.Position : 0);
            this.NextPointer = (ulong)(this.Next != null ? this.Next.Position : 0);

            // write structure data
            writer.Write(this.Unknown_0h);
            writer.Write(this.Unknown_4h);
            writer.Write(this.DataPointer);
            writer.Write(this.NextPointer);
            writer.Write(this.Unknown_18h);
            writer.Write(this.Unknown_1Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (Data != null) list.Add(Data);
            if (Next != null) list.Add(Next);
            return list.ToArray();
        }
    }
}
