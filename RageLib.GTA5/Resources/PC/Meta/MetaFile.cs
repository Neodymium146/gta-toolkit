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

using RageLib.Resources.Common;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Meta
{
    // psoResourceData
    public class MetaFile : FileBase64_GTA5_pc
    {
        public override long Length => 0x70;

        // structure data
        public int Unknown_10h { get; set; } = 0x50524430;
        public short Unknown_14h { get; set; } = 0x0079;
        public byte HasUselessData { get; set; }
        public byte Unknown_17h { get; set; } = 0x00;
        public int Unknown_18h { get; set; } = 0x00000000;
        public int RootBlockIndex { get; set; }
        public long StructureInfosPointer { get; private set; }
        public long EnumInfosPointer { get; private set; }
        public long DataBlocksPointer { get; private set; }
        public long NamePointer { get; private set; }
        public long UselessPointer { get; private set; }
        public short StructureInfosCount { get; private set; }
        public short EnumInfosCount { get; private set; }
        public short DataBlocksCount { get; private set; }
        public short Unknown_4Eh { get; set; } = 0x0000;
        public int Unknown_50h { get; set; } = 0x00000000;
        public int Unknown_54h { get; set; } = 0x00000000;
        public int Unknown_58h { get; set; } = 0x00000000;
        public int Unknown_5Ch { get; set; } = 0x00000000;
        public int Unknown_60h { get; set; } = 0x00000000;
        public int Unknown_64h { get; set; } = 0x00000000;
        public int Unknown_68h { get; set; } = 0x00000000;
        public int Unknown_6Ch { get; set; } = 0x00000000;

        // reference data
        public ResourceSimpleArray<StructureInfo> StructureInfos;
        public ResourceSimpleArray<EnumInfo> EnumInfos;
        public ResourceSimpleArray<DataBlock> DataBlocks;
        public string_r Name;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.Unknown_10h = reader.ReadInt32();
            this.Unknown_14h = reader.ReadInt16();
            this.HasUselessData = reader.ReadByte();
            this.Unknown_17h = reader.ReadByte();
            this.Unknown_18h = reader.ReadInt32();
            this.RootBlockIndex = reader.ReadInt32();
            this.StructureInfosPointer = reader.ReadInt64();
            this.EnumInfosPointer = reader.ReadInt64();
            this.DataBlocksPointer = reader.ReadInt64();
            this.NamePointer = reader.ReadInt64();
            this.UselessPointer = reader.ReadInt64();
            this.StructureInfosCount = reader.ReadInt16();
            this.EnumInfosCount = reader.ReadInt16();
            this.DataBlocksCount = reader.ReadInt16();
            this.Unknown_4Eh = reader.ReadInt16();
            this.Unknown_50h = reader.ReadInt32();
            this.Unknown_54h = reader.ReadInt32();
            this.Unknown_58h = reader.ReadInt32();
            this.Unknown_5Ch = reader.ReadInt32();
            this.Unknown_60h = reader.ReadInt32();
            this.Unknown_64h = reader.ReadInt32();
            this.Unknown_68h = reader.ReadInt32();
            this.Unknown_6Ch = reader.ReadInt32();

            // read reference data
            this.StructureInfos = reader.ReadBlockAt<ResourceSimpleArray<StructureInfo>>(
                (ulong)this.StructureInfosPointer, // offset
                this.StructureInfosCount
            );
            this.EnumInfos = reader.ReadBlockAt<ResourceSimpleArray<EnumInfo>>(
                (ulong)this.EnumInfosPointer, // offset
                this.EnumInfosCount
            );
            this.DataBlocks = reader.ReadBlockAt<ResourceSimpleArray<DataBlock>>(
                (ulong)this.DataBlocksPointer, // offset
                this.DataBlocksCount
            );
            this.Name = reader.ReadBlockAt<string_r>(
                (ulong)this.NamePointer // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.StructureInfosPointer = this.StructureInfos?.Position ?? 0;
            this.EnumInfosPointer = this.EnumInfos?.Position ?? 0;
            this.DataBlocksPointer = this.DataBlocks?.Position ?? 0;
            this.NamePointer = this.Name?.Position ?? 0;
            this.UselessPointer = 0;
            this.StructureInfosCount = (short)(this.StructureInfos?.Count ?? 0);
            this.EnumInfosCount = (short)(this.EnumInfos?.Count ?? 0);
            this.DataBlocksCount = (short)(this.DataBlocks?.Count ?? 0);

            // write structure data
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.Write(this.HasUselessData);
            writer.Write(this.Unknown_17h);
            writer.Write(this.Unknown_18h);
            writer.Write(this.RootBlockIndex);
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
