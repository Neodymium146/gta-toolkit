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

namespace RageLib.Resources.GTA5.PC.Navigations
{
    public class Sector_GTA5_pc : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 96; }
        }

        // structure data
        public uint Unknown_0h;
        public uint Unknown_4h;
        public uint Unknown_8h;
        public uint Unknown_Ch; // 0x7F800001
        public uint Unknown_10h;
        public uint Unknown_14h;
        public uint Unknown_18h;
        public uint Unknown_1Ch; // 0x7F800001
        public uint Unknown_20h;
        public uint Unknown_24h;
        public uint Unknown_28h;
        public ulong p0;
        public ulong p1;
        public ulong p2;
        public ulong p3;
        public ulong p4;
        public uint Unknown_54h; // 0x00000000
        public uint Unknown_58h; // 0x00000000
        public uint Unknown_5Ch; // 0x00000000

        // reference data
        public SectorData_GTA5_pc Data;
        public Sector_GTA5_pc SubTree1;
        public Sector_GTA5_pc SubTree2;
        public Sector_GTA5_pc SubTree3;
        public Sector_GTA5_pc SubTree4;

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
            this.Unknown_10h = reader.ReadUInt32();
            this.Unknown_14h = reader.ReadUInt32();
            this.Unknown_18h = reader.ReadUInt32();
            this.Unknown_1Ch = reader.ReadUInt32();
            this.Unknown_20h = reader.ReadUInt32();
            this.Unknown_24h = reader.ReadUInt32();
            this.Unknown_28h = reader.ReadUInt32();
            this.p0 = reader.ReadUInt64();
            this.p1 = reader.ReadUInt64();
            this.p2 = reader.ReadUInt64();
            this.p3 = reader.ReadUInt64();
            this.p4 = reader.ReadUInt64();
            this.Unknown_54h = reader.ReadUInt32();
            this.Unknown_58h = reader.ReadUInt32();
            this.Unknown_5Ch = reader.ReadUInt32();

            // read reference data
            this.Data = reader.ReadBlockAt<SectorData_GTA5_pc>(
                this.p0 // offset
            );
            this.SubTree1 = reader.ReadBlockAt<Sector_GTA5_pc>(
                this.p1 // offset
            );
            this.SubTree2 = reader.ReadBlockAt<Sector_GTA5_pc>(
                this.p2 // offset
            );
            this.SubTree3 = reader.ReadBlockAt<Sector_GTA5_pc>(
                this.p3 // offset
            );
            this.SubTree4 = reader.ReadBlockAt<Sector_GTA5_pc>(
                this.p4 // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.p0 = (ulong)(this.Data != null ? this.Data.Position : 0);
            this.p1 = (ulong)(this.SubTree1 != null ? this.SubTree1.Position : 0);
            this.p2 = (ulong)(this.SubTree2 != null ? this.SubTree2.Position : 0);
            this.p3 = (ulong)(this.SubTree3 != null ? this.SubTree3.Position : 0);
            this.p4 = (ulong)(this.SubTree4 != null ? this.SubTree4.Position : 0);

            // write structure data
            writer.Write(this.Unknown_0h);
            writer.Write(this.Unknown_4h);
            writer.Write(this.Unknown_8h);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.Write(this.Unknown_18h);
            writer.Write(this.Unknown_1Ch);
            writer.Write(this.Unknown_20h);
            writer.Write(this.Unknown_24h);
            writer.Write(this.Unknown_28h);
            writer.Write(this.p0);
            writer.Write(this.p1);
            writer.Write(this.p2);
            writer.Write(this.p3);
            writer.Write(this.p4);
            writer.Write(this.Unknown_54h);
            writer.Write(this.Unknown_58h);
            writer.Write(this.Unknown_5Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (Data != null) list.Add(Data);
            if (SubTree1 != null) list.Add(SubTree1);
            if (SubTree2 != null) list.Add(SubTree2);
            if (SubTree3 != null) list.Add(SubTree3);
            if (SubTree4 != null) list.Add(SubTree4);
            return list.ToArray();
        }

    }
}