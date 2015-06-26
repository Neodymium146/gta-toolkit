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
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Maps
{
    public class MapsFile_GTA5_pc : FileBase64_GTA5_pc
    {
        public override long Length
        {
            get { return 112; }
        }

        // structure data
        public uint Unknown_10h; // 0x50524430
        public uint Unknown_14h; // 0x00010079
        public uint Unknown_18h; // 0x00000000
        public uint Unknown_1Ch;
        public ulong ptr2;
        public ulong ptr3;
        public ulong ptr4;
        public uint Unknown_38h; // 0x00000000
        public uint Unknown_3Ch; // 0x00000000
        public ulong ptr5;
        public ushort c1;
        public ushort c2;
        public uint c3;
        public uint Unknown_50h;
        public uint Unknown_54h;
        public uint Unknown_58h;
        public uint Unknown_5Ch;
        public uint Unknown_60h;
        public uint Unknown_64h;
        public uint Unknown_68h;
        public uint Unknown_6Ch;

        // reference data
        public ResourceSimpleArray<Unknown_M_001> ptr2data;
        public ResourceSimpleArray<Unknown_M_002> ptr3data;
        public ResourceSimpleArray<Unknown_M_003> ptr4data;
        public Unknown_M_004 ptr5data;

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
            this.ptr2 = reader.ReadUInt64();
            this.ptr3 = reader.ReadUInt64();
            this.ptr4 = reader.ReadUInt64();
            this.Unknown_38h = reader.ReadUInt32();
            this.Unknown_3Ch = reader.ReadUInt32();
            this.ptr5 = reader.ReadUInt64();
            this.c1 = reader.ReadUInt16();
            this.c2 = reader.ReadUInt16();
            this.c3 = reader.ReadUInt32();
            this.Unknown_50h = reader.ReadUInt32();
            this.Unknown_54h = reader.ReadUInt32();
            this.Unknown_58h = reader.ReadUInt32();
            this.Unknown_5Ch = reader.ReadUInt32();
            this.Unknown_60h = reader.ReadUInt32();
            this.Unknown_64h = reader.ReadUInt32();
            this.Unknown_68h = reader.ReadUInt32();
            this.Unknown_6Ch = reader.ReadUInt32();

            // read reference data
            this.ptr2data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_M_001>>(
                this.ptr2, // offset
                this.c1
            );
            this.ptr3data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_M_002>>(
                this.ptr3, // offset
                this.c2
            );
            this.ptr4data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_M_003>>(
                this.ptr4, // offset
                this.c3
            );
            this.ptr5data = reader.ReadBlockAt<Unknown_M_004>(
                this.ptr5 // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.ptr2 = (ulong)(this.ptr2data != null ? this.ptr2data.Position : 0);
            this.ptr3 = (ulong)(this.ptr3data != null ? this.ptr3data.Position : 0);
            this.ptr4 = (ulong)(this.ptr4data != null ? this.ptr4data.Position : 0);
            this.ptr5 = (ulong)(this.ptr5data != null ? this.ptr5data.Position : 0);
            //this.c1 = (ushort)(this.ptr2data != null ? this.ptr2data.Count : 0);
            //this.c2 = (ushort)(this.ptr3data != null ? this.ptr3data.Count : 0);
            //this.c3 = (uint)(this.ptr4data != null ? this.ptr4data.Count : 0);

            // write structure data
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.Write(this.Unknown_18h);
            writer.Write(this.Unknown_1Ch);
            writer.Write(this.ptr2);
            writer.Write(this.ptr3);
            writer.Write(this.ptr4);
            writer.Write(this.Unknown_38h);
            writer.Write(this.Unknown_3Ch);
            writer.Write(this.ptr5);
            writer.Write(this.c1);
            writer.Write(this.c2);
            writer.Write(this.c3);
            writer.Write(this.Unknown_50h);
            writer.Write(this.Unknown_54h);
            writer.Write(this.Unknown_58h);
            writer.Write(this.Unknown_5Ch);
            writer.Write(this.Unknown_60h);
            writer.Write(this.Unknown_64h);
            writer.Write(this.Unknown_68h);
            writer.Write(this.Unknown_6Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            list.AddRange(base.GetReferences());
            if (ptr2data != null) list.Add(ptr2data);
            if (ptr3data != null) list.Add(ptr3data);
            if (ptr4data != null) list.Add(ptr4data);
            if (ptr5data != null) list.Add(ptr5data);
            return list.ToArray();
        }

    }
}