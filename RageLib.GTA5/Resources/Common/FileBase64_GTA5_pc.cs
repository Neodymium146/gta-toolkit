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

using System.Collections.Generic;

namespace RageLib.Resources
{
    public class FileBase64_GTA5_pc : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 16; }
        }

        // structure data
        public uint VFT;
        public uint Unknown_4h;
        public ulong PagesInfoPointer;

        // reference data
        public PagesInfo_GTA5_pc PagesInfo;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.VFT = reader.ReadUInt32();
            this.Unknown_4h = reader.ReadUInt32();
            this.PagesInfoPointer = reader.ReadUInt64();

            // read reference data
            this.PagesInfo = reader.ReadBlockAt<PagesInfo_GTA5_pc>(
                this.PagesInfoPointer // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.PagesInfoPointer = (ulong)(this.PagesInfo != null ? this.PagesInfo.Position : 0);

            // write structure data
            writer.Write(this.VFT);
            writer.Write(this.Unknown_4h);
            writer.Write(this.PagesInfoPointer);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (PagesInfo != null) list.Add(PagesInfo);
            return list.ToArray();
        }
    }
}