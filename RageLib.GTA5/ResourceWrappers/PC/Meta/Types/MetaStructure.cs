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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageLib.GTA5.ResourceWrappers.PC.Meta.Types
{
    public class MetaStructure : IMetaValue
    {
        private readonly Meta_GTA5_pc meta;
        public readonly StructureInfo_GTA5_pc info;

        public Dictionary<uint, IMetaValue> Values { get; set; }

        public MetaStructure(Meta_GTA5_pc meta, StructureInfo_GTA5_pc info)
        {
            this.meta = meta;
            this.info = info;
        }

        public void Read(DataReader reader)
        {
            long position = reader.Position;

            this.Values = new Dictionary<uint, Types.IMetaValue>();
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
                            entryValue.Read(reader);
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
                    case StructureEntryDataType.Byte_A:
                        {
                            var entryValue = new MetaByte_A();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.Byte_B:
                        {
                            var entryValue = new MetaByte_B();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.Byte_Enum:
                        {
                            var entryValue = new MetaByte_Enum();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.Char64:
                        {
                            var entryValue = new MetaChar64();
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
                    case StructureEntryDataType.Float4_XYZ:
                        {
                            var entryValue = new MetaFloat4_XYZ();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.Float4_XYZW:
                        {
                            var entryValue = new MetaFloat4_XYZW();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.Generic:
                        {
                            var entryValue = new MetaGeneric();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.Int16_A:
                        {
                            var entryValue = new MetaInt16_A();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.Int16_B:
                        {
                            var entryValue = new MetaInt16_B();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.Int16_Enum:
                        {
                            var entryValue = new MetaInt16_Enum();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.Int24:
                        {
                            var entryValue = new MetaInt24();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.Int32_A:
                        {
                            var entryValue = new MetaInt32_A();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.Int32_B:
                        {
                            var entryValue = new MetaInt32_B();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.Int32_Enum1:
                        {
                            var entryValue = new MetaInt32_Enum1();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.Int32_Enum2:
                        {
                            var entryValue = new MetaInt32_Enum2();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.Int32_Enum3:
                        {
                            var entryValue = new MetaInt32_Enum3();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.Int32_Hash:
                        {
                            var entryValue = new MetaInt32_Hash();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.Int64:
                        {
                            var entryValue = new MetaInt64();
                            entryValue.Read(reader);
                            this.Values.Add(entry.EntryNameHash, entryValue);
                            break;
                        }
                    case StructureEntryDataType.Structure:
                        {
                            var entryValue = new MetaStructure(meta, GetInfo(meta, entry.ReferenceKey));
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

        public static StructureInfo_GTA5_pc GetInfo(Meta_GTA5_pc meta, uint structureKey)
        {
            StructureInfo_GTA5_pc info = null;
            foreach (var x in meta.StructureInfos)
                if (x.StructureKey == structureKey)
                    info = x;
            return info;
        }
    }
}
