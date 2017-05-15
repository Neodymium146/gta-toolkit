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

namespace RageLib.Resources.GTA5.PC.Bounds
{
    public class BVHTreeInfo : ResourceSystemBlock
    {
        public override long Length => 0x10;

        // structure data
        public ushort MinX;
        public ushort MinY;
        public ushort MinZ;
        public ushort MaxX;
        public ushort MaxY;
        public ushort MaxZ;
        public ushort NodeIndex1;
        public ushort NodeIndex2;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.MinX = reader.ReadUInt16();
            this.MinY = reader.ReadUInt16();
            this.MinZ = reader.ReadUInt16();
            this.MaxX = reader.ReadUInt16();
            this.MaxY = reader.ReadUInt16();
            this.MaxZ = reader.ReadUInt16();
            this.NodeIndex1 = reader.ReadUInt16();
            this.NodeIndex2 = reader.ReadUInt16();
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // write structure data
            writer.Write(this.MinX);
            writer.Write(this.MinY);
            writer.Write(this.MinZ);
            writer.Write(this.MaxX);
            writer.Write(this.MaxY);
            writer.Write(this.MaxZ);
            writer.Write(this.NodeIndex1);
            writer.Write(this.NodeIndex2);
        }
    }
}
