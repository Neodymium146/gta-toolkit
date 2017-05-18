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

namespace RageLib.Resources.GTA5.PC.WaypointRecords
{
    public class WaypointRecordEntry : ResourceSystemBlock
    {
        public override long Length => 20;

        // structure data
        public float PositionX;
        public float PositionY;
        public float PositionZ;
        public ushort Unknown_Ch;
        public ushort Unknown_Eh;
        public ushort Unknown_10h;
        public ushort Unknown_12h;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.PositionX = reader.ReadSingle();
            this.PositionY = reader.ReadSingle();
            this.PositionZ = reader.ReadSingle();
            this.Unknown_Ch = reader.ReadUInt16();
            this.Unknown_Eh = reader.ReadUInt16();
            this.Unknown_10h = reader.ReadUInt16();
            this.Unknown_12h = reader.ReadUInt16();
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // write structure data
            writer.Write(this.PositionX);
            writer.Write(this.PositionY);
            writer.Write(this.PositionZ);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.Unknown_Eh);
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_12h);
        }
    }
}
