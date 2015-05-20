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

namespace RageLib.Resources
{
    public class PagesInfo_GTA5_pc : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 20; }
        }

        // structure data
        public uint Unknown_0h;
        public uint Unknown_4h;
        public byte SystemPagesCount;
        public byte GraphicsPagesCount;
        public ushort Unknown_Ah;
        public uint Unknown_Ch;
        public uint Unknown_10h;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.Unknown_0h = reader.ReadUInt32();
            this.Unknown_4h = reader.ReadUInt32();
            this.SystemPagesCount = reader.ReadByte();
            this.GraphicsPagesCount = reader.ReadByte();
            this.Unknown_Ah = reader.ReadUInt16();
            this.Unknown_Ch = reader.ReadUInt32();
            this.Unknown_10h = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // write structure data
            writer.Write(this.Unknown_0h);
            writer.Write(this.Unknown_4h);
            writer.Write(this.SystemPagesCount);
            writer.Write(this.GraphicsPagesCount);
            writer.Write(this.Unknown_Ah);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.Unknown_10h);
        }
    }
}