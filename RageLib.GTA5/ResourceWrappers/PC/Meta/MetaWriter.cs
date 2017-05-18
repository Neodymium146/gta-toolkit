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

using RageLib.GTA5.ResourceWrappers.PC.Meta.Data;
using RageLib.GTA5.ResourceWrappers.PC.Meta.Descriptions;
using RageLib.GTA5.ResourceWrappers.PC.Meta.Types;
using RageLib.Resources.Common;
using RageLib.Resources.GTA5;
using RageLib.Resources.GTA5.PC.Meta;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace RageLib.GTA5.ResourceWrappers.PC.Meta
{
    public class MetaWriter
    {
        private MetaFile meta;
        private ISet<int> usedStructureKeys = new HashSet<int>();

        public void Write(IMetaValue value, string fileName)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Create))
            {
                Write(value, fileStream);
            }
        }

        public void Write(IMetaValue value, Stream fileStream)
        {
            var resource = new ResourceFile_GTA5_pc<MetaFile>();
            resource.Version = 2;
            resource.ResourceData = Build(value);
            resource.Save(fileStream);
        }

        public MetaFile Build(IMetaValue value)
        {
            MetaInitialize();
            MetaBuildStructuresAndEnums();

            var writer = new MetaDataWriter();
            writer.SelectBlockByNameHash(((MetaStructure)value).info.StructureNameHash);
            WriteStructure(writer, (MetaStructure)value);

            for (int k = meta.StructureInfos.Count - 1; k >= 0; k--)
            {
                if (!usedStructureKeys.Contains(meta.StructureInfos[k].StructureKey))
                {
                    meta.StructureInfos.RemoveAt(k);
                }
            }

            meta.DataBlocks = new ResourceSimpleArray<DataBlock>();
            foreach (var block in writer.Blocks)
            {
                var metaDataBlock = new DataBlock();
                metaDataBlock.StructureNameHash = block.NameHash;
                metaDataBlock.Data = StreamToResourceBytes(block.Stream);
                meta.DataBlocks.Add(metaDataBlock);
            }

            for (int i = 0; i < meta.DataBlocks.Count; i++)
            {
                if (meta.DataBlocks[i].StructureNameHash == ((MetaStructure)value).info.StructureNameHash)
                {
                    meta.RootBlockIndex = i + 1;
                }
            }

            return meta;
        }

        private ResourceSimpleArray<byte_r> StreamToResourceBytes(Stream stream)
        {
            var resourceBytes = new ResourceSimpleArray<byte_r>();
            var buffer = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(buffer, 0, (int)stream.Length);
            foreach (var b in buffer)
            {
                var rb = new byte_r();
                rb.Value = b;
                resourceBytes.Add(rb);
            }
            return resourceBytes;
        }

        private void MetaInitialize()
        {
            meta = new MetaFile();
            meta.VFT = 0x405bc808;
            meta.Unknown_4h = 1;
            meta.Unknown_10h = 0x50524430;
            meta.Unknown_14h = 0x0079;
        }

        private void MetaBuildStructuresAndEnums()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream xmlStream = assembly.GetManifestResourceStream("RageLib.GTA5.ResourceWrappers.PC.Meta.Definitions.XmlInfos.xml"))
            {
                var ser = new XmlSerializer(typeof(MetaInformationXml));
                var xml = (MetaInformationXml)ser.Deserialize(xmlStream);
                MetaBuildStructureInfos(xml);
                MetaBuildEnumInfos(xml);
            }
        }

        private void MetaBuildStructureInfos(MetaInformationXml xmlInfo)
        {
            meta.StructureInfos = new ResourceSimpleArray<StructureInfo>();
            foreach (var xmlStructureInfo in xmlInfo.Structures)
            {
                var structureInfo = new StructureInfo();
                structureInfo.StructureNameHash = xmlStructureInfo.NameHash;
                structureInfo.StructureKey = xmlStructureInfo.Key;
                structureInfo.Unknown_8h = xmlStructureInfo.Unknown;
                structureInfo.StructureLength = xmlStructureInfo.Length;
                structureInfo.Entries = new ResourceSimpleArray<StructureEntryInfo>();
                foreach (var xmlStructureEntryInfo in xmlStructureInfo.Entries)
                {
                    var xmlArrayTypeStack = new Stack<MetaStructureArrayTypeXml>();
                    var xmlArrayType = xmlStructureEntryInfo.ArrayType;
                    while (xmlArrayType != null)
                    {
                        xmlArrayTypeStack.Push(xmlArrayType);
                        xmlArrayType = xmlArrayType.ArrayType;
                    }

                    while (xmlArrayTypeStack.Count > 0)
                    {
                        xmlArrayType = xmlArrayTypeStack.Pop();
                        var arrayStructureEntryInfo = new StructureEntryInfo();
                        arrayStructureEntryInfo.EntryNameHash = 0x100;
                        arrayStructureEntryInfo.DataOffset = 0;
                        arrayStructureEntryInfo.DataType = (StructureEntryDataType)xmlArrayType.Type;
                        arrayStructureEntryInfo.Unknown_9h = 0;
                        if (arrayStructureEntryInfo.DataType == StructureEntryDataType.Array)
                        {
                            arrayStructureEntryInfo.ReferenceTypeIndex = (short)(structureInfo.Entries.Count - 1);
                        }
                        else
                        {
                            arrayStructureEntryInfo.ReferenceTypeIndex = 0;
                        }
                        arrayStructureEntryInfo.ReferenceKey = xmlArrayType.TypeHash;
                        structureInfo.Entries.Add(arrayStructureEntryInfo);
                    }

                    var structureEntryInfo = new StructureEntryInfo();
                    structureEntryInfo.EntryNameHash = xmlStructureEntryInfo.NameHash;
                    structureEntryInfo.DataOffset = xmlStructureEntryInfo.Offset;
                    structureEntryInfo.DataType = (StructureEntryDataType)xmlStructureEntryInfo.Type;
                    structureEntryInfo.Unknown_9h = (byte)xmlStructureEntryInfo.Unknown;
                    if (structureEntryInfo.DataType == StructureEntryDataType.Array)
                    {
                        structureEntryInfo.ReferenceTypeIndex = (short)(structureInfo.Entries.Count - 1);
                    }
                    else
                    {
                        structureEntryInfo.ReferenceTypeIndex = 0;
                    }
                    structureEntryInfo.ReferenceKey = xmlStructureEntryInfo.TypeHash;

                    structureInfo.Entries.Add(structureEntryInfo);
                }
                meta.StructureInfos.Add(structureInfo);
            }
        }

        private void MetaBuildEnumInfos(MetaInformationXml xmlInfo)
        {
            meta.EnumInfos = new ResourceSimpleArray<EnumInfo>();
            foreach (var xmlEnumInfo in xmlInfo.Enums)
            {
                var enumInfo = new EnumInfo();
                enumInfo.EnumNameHash = xmlEnumInfo.NameHash;
                enumInfo.EnumKey = xmlEnumInfo.Key;
                enumInfo.Entries = new ResourceSimpleArray<EnumEntryInfo>();
                foreach (var xmlEnumEntryInfo in xmlEnumInfo.Entries)
                {
                    var enumEntryInfo = new EnumEntryInfo();
                    enumEntryInfo.EntryNameHash = xmlEnumEntryInfo.NameHash;
                    enumEntryInfo.EntryValue = xmlEnumEntryInfo.Value;
                    enumInfo.Entries.Add(enumEntryInfo);
                }
                meta.EnumInfos.Add(enumInfo);
            }
        }

        private void WriteStructure(MetaDataWriter writer, MetaStructure value)
        {
            var updateStack = new Stack<IMetaValue>();

            // build stack for update...
            var structuresToCheck = new Stack<MetaStructure>();
            structuresToCheck.Push(value);
            while (structuresToCheck.Count > 0)
            {
                var structureToCheck = structuresToCheck.Pop();

                // add structure to list of occurring structures
                usedStructureKeys.Add(structureToCheck.info.StructureKey);

                foreach (var structureEntryToCheck in structureToCheck.Values)
                {
                    if (structureEntryToCheck.Value is MetaArray)
                    {
                        updateStack.Push(structureEntryToCheck.Value);

                        var arrayStructureEntryToCheck = structureEntryToCheck.Value as MetaArray;
                        if (arrayStructureEntryToCheck.Entries != null)
                        {
                            for (int k = arrayStructureEntryToCheck.Entries.Count - 1; k >= 0; k--)
                            {
                                var x = arrayStructureEntryToCheck.Entries[k];
                                if (x is MetaStructure)
                                {
                                    structuresToCheck.Push(x as MetaStructure);
                                }
                                if (x is MetaGeneric)
                                {
                                    updateStack.Push(x);
                                    structuresToCheck.Push((MetaStructure)(x as MetaGeneric).Value);
                                }
                            }
                        }
                    }
                    if (structureEntryToCheck.Value is MetaCharPointer)
                    {
                        updateStack.Push(structureEntryToCheck.Value);
                    }
                    if (structureEntryToCheck.Value is MetaDataBlockPointer)
                    {
                        updateStack.Push(structureEntryToCheck.Value);
                    }
                    if (structureEntryToCheck.Value is MetaGeneric)
                    {
                        updateStack.Push(structureEntryToCheck.Value);

                        var genericStructureEntryToCheck = structureEntryToCheck.Value as MetaGeneric;
                        structuresToCheck.Push((MetaStructure)genericStructureEntryToCheck.Value);
                    }
                    if (structureEntryToCheck.Value is MetaStructure)
                    {
                        structuresToCheck.Push((MetaStructure)structureEntryToCheck.Value);
                    }
                }
            }

            // update structures...
            while (updateStack.Count > 0)
            {
                var v = updateStack.Pop();
                if (v is MetaArray)
                {
                    var arrayValue = (MetaArray)v;
                    if (arrayValue.Entries != null)
                    {
                        if (arrayValue.info.DataType == StructureEntryDataType.Structure)
                        {
                            // WORKAROUND
                            if (arrayValue.IsAlwaysAtZeroOffset)
                            {
                                writer.CreateBlockByNameHash(arrayValue.info.ReferenceKey);
                                writer.Position = writer.Length;
                            }
                            else
                            {
                                writer.SelectBlockByNameHash(arrayValue.info.ReferenceKey);
                                writer.Position = writer.Length;
                            }
                        }
                        else
                        {
                            writer.SelectBlockByNameHash((int)arrayValue.info.DataType);
                            writer.Position = writer.Length;
                        }
                        arrayValue.BlockIndex = writer.BlockIndex + 1;
                        arrayValue.Offset = (int)writer.Position;
                        arrayValue.NumberOfEntries = arrayValue.Entries.Count;
                        foreach (var entry in arrayValue.Entries)
                        {
                            entry.Write(writer);
                        }
                    }
                    else
                    {
                        arrayValue.BlockIndex = 0;
                        arrayValue.Offset = 0;
                        arrayValue.NumberOfEntries = 0;
                    }
                }
                if (v is MetaCharPointer)
                {
                    var charPointerValue = (MetaCharPointer)v;
                    if (charPointerValue.Value != null)
                    {
                        writer.SelectBlockByNameHash(0x10);
                        writer.Position = writer.Length;
                        charPointerValue.DataBlockIndex = writer.BlockIndex + 1;
                        charPointerValue.DataOffset = (int)writer.Position;
                        charPointerValue.StringLength = charPointerValue.Value.Length;
                        charPointerValue.StringCapacity = charPointerValue.Value.Length + 1;
                        writer.Write(charPointerValue.Value);
                    }
                    else
                    {
                        charPointerValue.DataBlockIndex = 0;
                        charPointerValue.DataOffset = 0;
                        charPointerValue.StringLength = 0;
                        charPointerValue.StringCapacity = 0;
                    }
                }
                if (v is MetaDataBlockPointer)
                {
                    var charPointerValue = (MetaDataBlockPointer)v;
                    if (charPointerValue.Data != null)
                    {
                        writer.CreateBlockByNameHash(0x11);
                        writer.Position = 0;
                        charPointerValue.BlockIndex = writer.BlockIndex + 1;
                        writer.Write(charPointerValue.Data);
                    }
                    else
                    {
                        charPointerValue.BlockIndex = 0;
                    }
                }
                if (v is MetaGeneric)
                {
                    var genericValue = (MetaGeneric)v;
                    writer.SelectBlockByNameHash(((MetaStructure)genericValue.Value).info.StructureNameHash);
                    writer.Position = writer.Length;
                    genericValue.BlockIndex = writer.BlockIndex + 1;
                    genericValue.Offset = (int)writer.Position / 16;
                    genericValue.Value.Write(writer);
                }
            }

            // now only the root itself is left...
            writer.SelectBlockByNameHash(value.info.StructureNameHash);
            writer.Position = writer.Length;
            value.Write(writer);
        }
    }
}
