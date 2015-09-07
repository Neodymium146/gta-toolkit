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

namespace RageLib.Resources.GTA5.PC.Meta
{
    public class Meta_GTA5_pc : FileBase64_GTA5_pc
    {
        public override long Length
        {
            get { return 112; }
        }

        // structure data
        public uint Unknown_10h; // 0x50524430
        public uint Unknown_14h;
        public uint Unknown_18h; // 0x00000000
        public uint Unknown_1Ch;
        public ulong ClassInfosPointer;
        public ulong p2;
        public ulong DataBlocksPointer;
        public ulong NamePointer;
        public ulong p5;
        public ushort ClassInfosCount;
        public ushort c2;
        public ushort DataBlocksCount;
        public ushort Unknown_4Eh; // 0x0000
        public uint Unknown_50h; // 0x00000000
        public uint Unknown_54h; // 0x00000000
        public uint Unknown_58h; // 0x00000000
        public uint Unknown_5Ch; // 0x00000000
        public uint Unknown_60h; // 0x00000000
        public uint Unknown_64h; // 0x00000000
        public uint Unknown_68h; // 0x00000000
        public uint Unknown_6Ch; // 0x00000000

        // reference data
        public ResourceSimpleArray<MetaClassInfo_GTA5_pc> ClassInfos;
        public ResourceSimpleArray<Unknown_META_002> p2data;
        public ResourceSimpleArray<MetaDataBlock_GTA5_pc> DataBlocks;
        public string_r Name;
        public Unknown_META_001 p5data;

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
            this.ClassInfosPointer = reader.ReadUInt64();
            this.p2 = reader.ReadUInt64();
            this.DataBlocksPointer = reader.ReadUInt64();
            this.NamePointer = reader.ReadUInt64();
            this.p5 = reader.ReadUInt64();
            this.ClassInfosCount = reader.ReadUInt16();
            this.c2 = reader.ReadUInt16();
            this.DataBlocksCount = reader.ReadUInt16();
            this.Unknown_4Eh = reader.ReadUInt16();
            this.Unknown_50h = reader.ReadUInt32();
            this.Unknown_54h = reader.ReadUInt32();
            this.Unknown_58h = reader.ReadUInt32();
            this.Unknown_5Ch = reader.ReadUInt32();
            this.Unknown_60h = reader.ReadUInt32();
            this.Unknown_64h = reader.ReadUInt32();
            this.Unknown_68h = reader.ReadUInt32();
            this.Unknown_6Ch = reader.ReadUInt32();

            // read reference data
            this.ClassInfos = reader.ReadBlockAt<ResourceSimpleArray<MetaClassInfo_GTA5_pc>>(
                this.ClassInfosPointer, // offset
                this.ClassInfosCount
            );
            this.p2data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_META_002>>(
                this.p2, // offset
                this.c2
            );
            this.DataBlocks = reader.ReadBlockAt<ResourceSimpleArray<MetaDataBlock_GTA5_pc>>(
                this.DataBlocksPointer, // offset
                this.DataBlocksCount
            );
            this.Name = reader.ReadBlockAt<string_r>(
                this.NamePointer // offset
            );
            this.p5data = reader.ReadBlockAt<Unknown_META_001>(
                this.p5 // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.ClassInfosPointer = (ulong)(this.ClassInfos != null ? this.ClassInfos.Position : 0);
            this.p2 = (ulong)(this.p2data != null ? this.p2data.Position : 0);
            this.DataBlocksPointer = (ulong)(this.DataBlocks != null ? this.DataBlocks.Position : 0);
            this.NamePointer = (ulong)(this.Name != null ? this.Name.Position : 0);
            this.p5 = (ulong)(this.p5data != null ? this.p5data.Position : 0);
            //this.ClassInfosCount = (ushort)(this.ClassInfos != null ? this.ClassInfos.Count : 0);
            //this.c2 = (ushort)(this.p2data != null ? this.p2data.Count : 0);
            //this.DataBlocksCount = (ushort)(this.DataBlocks != null ? this.DataBlocks.Count : 0);

            // write structure data
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.Write(this.Unknown_18h);
            writer.Write(this.Unknown_1Ch);
            writer.Write(this.ClassInfosPointer);
            writer.Write(this.p2);
            writer.Write(this.DataBlocksPointer);
            writer.Write(this.NamePointer);
            writer.Write(this.p5);
            writer.Write(this.ClassInfosCount);
            writer.Write(this.c2);
            writer.Write(this.DataBlocksCount);
            writer.Write(this.Unknown_4Eh);
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
            var list = new List<IResourceBlock>(base.GetReferences());
            if (ClassInfos != null) list.Add(ClassInfos);
            if (p2data != null) list.Add(p2data);
            if (DataBlocks != null) list.Add(DataBlocks);
            if (Name != null) list.Add(Name);
            if (p5data != null) list.Add(p5data);
            return list.ToArray();
        }

    }
}