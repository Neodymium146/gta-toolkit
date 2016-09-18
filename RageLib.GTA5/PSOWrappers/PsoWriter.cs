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

using RageLib.GTA5.PSO;
using RageLib.GTA5.PSOWrappers.Types;
using RageLib.GTA5.PSOWrappers.Xml;
using RageLib.GTA5.ResourceWrappers.PC.Meta.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace RageLib.GTA5.PSOWrappers
{
    public class PsoWriter
    {
        private PsoFile meta;
        private ISet<int> usedStructureKeys = new HashSet<int>();

        public void Write(IPsoValue value, string fileName)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Create))
            {
                Write(value, fileStream);
            }
        }

        public void Write(IPsoValue value, Stream fileStream)
        {           
            var resource = Build(value);
            resource.Save(fileStream);
        }

        public PsoFile Build(IPsoValue value)
        {
            MetaInitialize();
            MetaBuildStructuresAndEnums();

            var writer = new MetaDataWriter(Data.Endianess.BigEndian);
            writer.SelectBlockByNameHash(((PsoStructure)value).psoEntryInfo.NameHash);
            WriteStructure(writer, (PsoStructure)value);

            meta.DataMappingSection.Entries = new List<PsoDataMappingEntry>();

             var ms = new MemoryStream();
            ms.Position = 16;
            foreach (var block in writer.Blocks)
            {
                var metaDataBlock = new PsoDataMappingEntry();
                metaDataBlock.NameHash = block.NameHash;
                metaDataBlock.Offset = (int)ms.Position;
                metaDataBlock.Length = (int)block.Stream.Length;

                var buf = new byte[block.Stream.Length];
                block.Stream.Position = 0;
                block.Stream.Read(buf, 0, buf.Length);
                ms.Write(buf, 0, buf.Length);

                // fill...
                buf = new byte[16 - ms.Position % 16];
                if (buf.Length != 16)
                    ms.Write(buf, 0, buf.Length);

                meta.DataMappingSection.Entries.Add(metaDataBlock);
            }

            var totalBuf = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(totalBuf, 0, totalBuf.Length);
            meta.DataSection.Data = totalBuf;

            for (int i = 0; i < meta.DataMappingSection.Entries.Count; i++)
            {
                if (meta.DataMappingSection.Entries[i].NameHash == ((PsoStructure)value).psoEntryInfo.NameHash)
                {
                    meta.DataMappingSection.RootIndex = i + 1;
                }
            }

            return meta;
        }

        private void MetaInitialize()
        {
            meta = new PsoFile();
            meta.DataMappingSection = new PsoDataMappingSection();
            meta.DataSection = new PsoDataSection();
            meta.DefinitionSection = new PsoDefinitionSection();
        }

        private void MetaBuildStructuresAndEnums()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream xmlStream = assembly.GetManifestResourceStream("RageLib.GTA5.PSOWrappers.Xml.PsoDefinitions.xml"))
            {
                var ser = new XmlSerializer(typeof(PsoDefinitionXml));
                var xml = (PsoDefinitionXml)ser.Deserialize(xmlStream);
                MetaBuildStructureInfos(xml);
                MetaBuildEnumInfos(xml);
            }
        }

        private void MetaBuildStructureInfos(PsoDefinitionXml xmlInfo)
        {
            meta.DefinitionSection.EntriesIdx = new List<PsoElementIndexInfo>();
            meta.DefinitionSection.Entries = new List<PsoElementInfo>();

            foreach (var xmlStructureInfo in xmlInfo.Structures)
            {
                var idxInfo = new PsoElementIndexInfo();
                idxInfo.Offset = 0;
                idxInfo.NameHash = xmlStructureInfo.NameHash;

                var structureInfo = new PsoStructureInfo();
                structureInfo.Type = 1;
                structureInfo.Unk = (byte)xmlStructureInfo.Unknown;
                structureInfo.StructureLength = xmlStructureInfo.Length;
                structureInfo.Entries = new List<PsoStructureEntryInfo>();
                foreach (var xmlStructureEntryInfo in xmlStructureInfo.Entries)
                {
                    var xmlArrayTypeStack = new Stack<PsoStructureEntryXml>();
                    var xmlArrayType = xmlStructureEntryInfo.ArrayType;
                    while (xmlArrayType != null)
                    {
                        xmlArrayTypeStack.Push(xmlArrayType);
                        xmlArrayType = xmlArrayType.ArrayType;
                    }

                    while (xmlArrayTypeStack.Count > 0)
                    {
                        xmlArrayType = xmlArrayTypeStack.Pop();
                        var arrayStructureEntryInfo = new PsoStructureEntryInfo();
                        arrayStructureEntryInfo.EntryNameHash = xmlArrayType.NameHash;
                        arrayStructureEntryInfo.Type = (DataType)xmlArrayType.Type;
                        arrayStructureEntryInfo.Unk_5h = (byte)xmlArrayType.Unknown;
                        arrayStructureEntryInfo.DataOffset = (short)xmlArrayType.Offset;
                        if (arrayStructureEntryInfo.Type == DataType.Array)
                        {
                            arrayStructureEntryInfo.ReferenceKey = (short)(structureInfo.Entries.Count - 1);
                        }
                        else
                        {
                            arrayStructureEntryInfo.ReferenceKey = 0;
                        }
                        arrayStructureEntryInfo.ReferenceKey = xmlArrayType.TypeHash;
                        structureInfo.Entries.Add(arrayStructureEntryInfo);
                    }

                    var structureEntryInfo = new PsoStructureEntryInfo();
                    structureEntryInfo.EntryNameHash = xmlStructureEntryInfo.NameHash;
                    structureEntryInfo.Type = (DataType)xmlStructureEntryInfo.Type;
                    structureEntryInfo.Unk_5h = (byte)xmlStructureEntryInfo.Unknown;
                    structureEntryInfo.DataOffset = (short)xmlStructureEntryInfo.Offset;
                    if (structureEntryInfo.Type == DataType.Array)
                    {
                        structureEntryInfo.ReferenceKey = (short)(structureInfo.Entries.Count - 1);
                    }
                    else
                    {
                        structureEntryInfo.ReferenceKey = 0;
                    }
                    structureEntryInfo.ReferenceKey = xmlStructureEntryInfo.TypeHash;

                    structureInfo.Entries.Add(structureEntryInfo);
                }


                meta.DefinitionSection.EntriesIdx.Add(idxInfo);
                meta.DefinitionSection.Entries.Add(structureInfo);
            }
        }

        private void MetaBuildEnumInfos(PsoDefinitionXml xmlInfo)
        {
            foreach (var xmlEnumInfo in xmlInfo.Enums)
            {
                var idxInfo = new PsoElementIndexInfo();
                idxInfo.Offset = 0;
                idxInfo.NameHash = xmlEnumInfo.NameHash;

                var info = new PsoEnumInfo();
                info.Entries = new List<PsoEnumEntryInfo>();
                foreach (var xmlEnumEntryInfo in xmlEnumInfo.Entries)
                {
                    var enumEntryInfo = new PsoEnumEntryInfo();
                    enumEntryInfo.EntryNameHash = xmlEnumEntryInfo.NameHash;
                    enumEntryInfo.EntryKey = xmlEnumEntryInfo.Value;
                    info.Entries.Add(enumEntryInfo);
                }

                meta.DefinitionSection.EntriesIdx.Add(idxInfo);
                meta.DefinitionSection.Entries.Add(info);
            }
        }

        private void WriteStructure(MetaDataWriter writer, PsoStructure value)
        {
            var updateStack = new Stack<IPsoValue>();

            // build stack for update...
            var structuresToCheck = new Stack<PsoStructure>();
            structuresToCheck.Push(value);
            while (structuresToCheck.Count > 0)
            {
                var structureToCheck = structuresToCheck.Pop();

                // add structure to list of occurring structures
                usedStructureKeys.Add(structureToCheck.psoEntryInfo.NameHash);

                foreach (var structureEntryToCheck in structureToCheck.Values)
                {
                    if (structureEntryToCheck.Value is PsoArray)
                    {
                        updateStack.Push(structureEntryToCheck.Value);

                        var arrayStructureEntryToCheck = structureEntryToCheck.Value as PsoArray;
                        if (arrayStructureEntryToCheck.Entries != null)
                        {
                            for (int k = arrayStructureEntryToCheck.Entries.Count - 1; k >= 0; k--)
                            {
                                var x = arrayStructureEntryToCheck.Entries[k];
                                if (x is PsoStructure)
                                {
                                    structuresToCheck.Push(x as PsoStructure);
                                }                              
                            }
                        }
                    }
                    if (structureEntryToCheck.Value is PsoStructure)
                    {
                        structuresToCheck.Push((PsoStructure)structureEntryToCheck.Value);
                    }
                }
            }

            // update structures...
            while (updateStack.Count > 0)
            {
                var v = updateStack.Pop();
                if (v is PsoArray)
                {
                    var arrayValue = (PsoArray)v;
                    if (arrayValue.Entries != null)
                    {

                        if (arrayValue.psoSection.Type == DataType.Structure)
                        {
                            writer.SelectBlockByNameHash((int)arrayValue.psoSection.ReferenceKey);
                            writer.Position = writer.Length;
                        }
                        else if (arrayValue.psoSection.Type == DataType.INT_0Bh)
                        {
                            writer.SelectBlockByNameHash(6);
                            writer.Position = writer.Length;
                        }
                        else
                        {
                            throw new Exception("Unknown array type.");
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
            }

            // now only the root itself is left...
            writer.SelectBlockByNameHash(value.psoEntryInfo.NameHash);
            writer.Position = writer.Length;
            value.Write(writer);
        }
    }
}
