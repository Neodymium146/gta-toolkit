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
        public ulong StructureInfosPointer;
        public ulong EnumInfosPointer;
        public ulong DataBlocksPointer;
        public ulong NamePointer;
        public ulong UselessPointer;
        public ushort StructureInfosCount;
        public ushort EnumInfosCount;
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
        public ResourceSimpleArray<StructureInfo_GTA5_pc> StructureInfos;
        public ResourceSimpleArray<EnumInfo_GTA5_pc> EnumInfos;
        public ResourceSimpleArray<DataBlock_GTA5_pc> DataBlocks;
        public string_r Name;

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
            this.StructureInfosPointer = reader.ReadUInt64();
            this.EnumInfosPointer = reader.ReadUInt64();
            this.DataBlocksPointer = reader.ReadUInt64();
            this.NamePointer = reader.ReadUInt64();
            this.UselessPointer = reader.ReadUInt64();
            this.StructureInfosCount = reader.ReadUInt16();
            this.EnumInfosCount = reader.ReadUInt16();
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
            this.StructureInfos = reader.ReadBlockAt<ResourceSimpleArray<StructureInfo_GTA5_pc>>(
                this.StructureInfosPointer, // offset
                this.StructureInfosCount
            );
            this.EnumInfos = reader.ReadBlockAt<ResourceSimpleArray<EnumInfo_GTA5_pc>>(
                this.EnumInfosPointer, // offset
                this.EnumInfosCount
            );
            this.DataBlocks = reader.ReadBlockAt<ResourceSimpleArray<DataBlock_GTA5_pc>>(
                this.DataBlocksPointer, // offset
                this.DataBlocksCount
            );
            this.Name = reader.ReadBlockAt<string_r>(
                this.NamePointer // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.StructureInfosPointer = (ulong)(this.StructureInfos != null ? this.StructureInfos.Position : 0);
            this.EnumInfosPointer = (ulong)(this.EnumInfos != null ? this.EnumInfos.Position : 0);
            this.DataBlocksPointer = (ulong)(this.DataBlocks != null ? this.DataBlocks.Position : 0);
            this.NamePointer = (ulong)(this.Name != null ? this.Name.Position : 0);
            this.UselessPointer = 0;
            this.StructureInfosCount = (ushort)(this.StructureInfos != null ? this.StructureInfos.Count : 0);
            this.EnumInfosCount = (ushort)(this.EnumInfos != null ? this.EnumInfos.Count : 0);
            this.DataBlocksCount = (ushort)(this.DataBlocks != null ? this.DataBlocks.Count : 0);

            // write structure data
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.Write(this.Unknown_18h);
            writer.Write(this.Unknown_1Ch);
            writer.Write(this.StructureInfosPointer);
            writer.Write(this.EnumInfosPointer);
            writer.Write(this.DataBlocksPointer);
            writer.Write(this.NamePointer);
            writer.Write(this.UselessPointer);
            writer.Write(this.StructureInfosCount);
            writer.Write(this.EnumInfosCount);
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
            if (StructureInfos != null) list.Add(StructureInfos);
            if (EnumInfos != null) list.Add(EnumInfos);
            if (DataBlocks != null) list.Add(DataBlocks);
            if (Name != null) list.Add(Name);
            return list.ToArray();
        }
    }
}
