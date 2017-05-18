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

using RageLib.Data;
using RageLib.Resources.GTA5.PC.Meta;
using System;
using System.Collections.Generic;

namespace RageLib.GTA5.ResourceWrappers.PC.Meta.Types
{
    public class MetaStructure : IMetaValue
    {
        private readonly MetaFile meta;
        public readonly StructureInfo info;

        public Dictionary<int, IMetaValue> Values { get; set; }

        public MetaStructure(MetaFile meta, StructureInfo info)
        {
            this.meta = meta;
            this.info = info;
        }

        public void Read(DataReader reader)
        {
            long position = reader.Position;

            this.Values = new Dictionary<int, IMetaValue>();
            foreach (var entry in info.Entries)
            {
                if (entry.EntryNameHash == 0x100)
                    continue;

                reader.Position = position + entry.DataOffset;
                switch (entry.DataType)
                {
                    case StructureEntryDataType.Array:
                        {
                            var entryValue = new MetaArray();
                            entryValue.info = info.Entries[entry.ReferenceTypeIndex];
                            entryValue.Read(reader);

                            if (entry.Unknown_9h != 0)
                            {
                                entryValue.IsAlwaysAtZeroOffset = true;
                            }

                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.Boolean:
                        {
                            var entryValue = new MetaBoolean();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.SignedByte:
                        {
                            var entryValue = new MetaByte_A();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.UnsignedByte:
                        {
                            var entryValue = new MetaByte_B();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.ByteEnum:
                        {
                            var entryValue = new MetaByte_Enum();
                            entryValue.info = GetEnumInfo(meta, entry.ReferenceKey);
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.ArrayOfChars:
                        {
                            var entryValue = new MetaArrayOfChars(entry);
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.CharPointer:
                        {
                            var entryValue = new MetaCharPointer();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.Float:
                        {
                            var entryValue = new MetaFloat();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.Float_XYZ:
                        {
                            var entryValue = new MetaFloat4_XYZ();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.Float_XYZW:
                        {
                            var entryValue = new MetaFloat4_XYZW();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.StructurePointer:
                        {
                            var entryValue = new MetaGeneric();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.SignedShort:
                        {
                            var entryValue = new MetaInt16_A();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.UnsignedShort:
                        {
                            var entryValue = new MetaInt16_B();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.ShortFlags: // flags!
                        {
                            var entryValue = new MetaInt16_Enum();
                            entryValue.Read(reader);
                            entryValue.info = GetEnumInfo(meta, entry.ReferenceKey);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.ArrayOfBytes:
                        {
                            var entryValue = new MetaArrayOfBytes(entry);
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.SignedInt:
                        {
                            var entryValue = new MetaInt32_A();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.UnsignedInt:
                        {
                            var entryValue = new MetaInt32_B();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.IntEnum:
                        {
                            var entryValue = new MetaInt32_Enum1();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            entryValue.info = GetEnumInfo(meta, entry.ReferenceKey);
                            break;
                        }
                    case StructureEntryDataType.IntFlags1:
                        {
                            var entryValue = new MetaInt32_Enum2();
                            entryValue.Read(reader);
                            entryValue.info = GetEnumInfo(meta, entry.ReferenceKey);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.IntFlags2: // flags
                        {
                            var entryValue = new MetaInt32_Enum3();
                            entryValue.Read(reader);
                            entryValue.info = GetEnumInfo(meta, entry.ReferenceKey);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.Hash:
                        {
                            var entryValue = new MetaInt32_Hash();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.DataBlockPointer:
                        {
                            var entryValue = new MetaDataBlockPointer(entry);
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.Structure:
                        {
                            var entryValue = new MetaStructure(meta, GetStructureInfo(meta, entry.ReferenceKey));
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    default:
                        throw new Exception("Unknown Type");
                }
            }

            reader.Position = position + info.StructureLength;
        }

        public static StructureInfo GetStructureInfo(MetaFile meta, int structureKey)
        {
            StructureInfo info = null;
            foreach (var x in meta.StructureInfos)
                if (x.StructureNameHash == structureKey)
                    info = x;
            return info;
        }

        public static EnumInfo GetEnumInfo(MetaFile meta, int structureKey)
        {
            EnumInfo info = null;
            foreach (var x in meta.EnumInfos)
                if (x.EnumNameHash == structureKey)
                    info = x;
            return info;
        }

        public void Write(DataWriter writer)
        {
            long position = writer.Position;

            writer.Write(new byte[info.StructureLength]);
            writer.Position = position;

            foreach (var entry in info.Entries)
            {
                if (entry.EntryNameHash != 0x100)
                {
                    writer.Position = position + entry.DataOffset;
                    this.Values[entry.EntryNameHash].Write(writer);
                }
            }
            writer.Position = position + info.StructureLength;
        }
    }
}
