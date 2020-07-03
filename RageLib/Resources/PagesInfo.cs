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
    // datResourceMap ?
    public class PagesInfo : ResourceSystemBlock
    {
        public override long BlockLength
        {
            get { return 16 + (8 * (VirtualPagesCount + PhysicalPagesCount)); }
        }

        // structure data
        public uint Unknown_0h;
        public uint Unknown_4h;
        public byte VirtualPagesCount;
        public byte PhysicalPagesCount;
        public ushort Unknown_Ah;
        public uint Unknown_Ch;
        public ulong[] VirtualPagesPointers;
        public ulong[] PhysicalPagesPointers;

        public PagesInfo() : this(64, 64) { }

        public PagesInfo(byte virtualPagesCount, byte physicalPagesCount)
        {
            VirtualPagesCount = virtualPagesCount;
            PhysicalPagesCount = physicalPagesCount;
        }

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.Unknown_0h = reader.ReadUInt32();
            this.Unknown_4h = reader.ReadUInt32();
            this.VirtualPagesCount = reader.ReadByte();
            this.PhysicalPagesCount = reader.ReadByte();
            this.Unknown_Ah = reader.ReadUInt16();
            this.Unknown_Ch = reader.ReadUInt32();

            if (VirtualPagesCount > 0)
            {
                this.VirtualPagesPointers = new ulong[VirtualPagesCount];
                for (int i = 0; i < VirtualPagesCount; i++)
                    this.VirtualPagesPointers[i] = reader.ReadUInt64();
            }

            if (PhysicalPagesCount > 0)
            {
                this.PhysicalPagesPointers = new ulong[PhysicalPagesCount];
                for (int i = 0; i < PhysicalPagesCount; i++)
                    this.PhysicalPagesPointers[i] = reader.ReadUInt64();
            }
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // write structure data
            writer.Write(this.Unknown_0h);
            writer.Write(this.Unknown_4h);
            writer.Write(this.VirtualPagesCount);
            writer.Write(this.PhysicalPagesCount);
            writer.Write(this.Unknown_Ah);
            writer.Write(this.Unknown_Ch);

            if (VirtualPagesCount > 0)
            {
                //if (VirtualPagesPointers != null && VirtualPagesPointers.Length == VirtualPagesCount)
                //    writer.WriteUlongs(VirtualPagesPointers);
                //else
                //{
                var pad = 8 * VirtualPagesCount;
                writer.Write(new byte[pad]);
                //}
            }

            if (PhysicalPagesCount > 0)
            {
                //if (PhysicalPagesPointers != null && PhysicalPagesPointers.Length == PhysicalPagesCount)
                //    writer.WriteUlongs(PhysicalPagesPointers);
                //else
                //{
                var pad = 8 * PhysicalPagesCount;
                writer.Write(new byte[pad]);
                //}
            }
        }
    }
}