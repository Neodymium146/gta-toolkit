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
using RageLib.GTA5.PSO;
using RageLib.GTA5.PSOWrappers.Types;
using System.Collections.Generic;
using System.IO;

namespace RageLib.GTA5.PSOWrappers
{
    public class PsoReader
    {
        public IPsoValue Read(string fileName)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Open))
            {
                return Read(fileStream);
            }
        }

        public IPsoValue Read(Stream fileStream)
        {
            var resource = new PsoFile();
            resource.Load(fileStream);
            return Parse(resource);
        }

        public IPsoValue Parse(PsoFile meta)
        {
            var blockKeys = new List<int>();
            var blocks = new List<List<IPsoValue>>();


            var resultStructure = new PsoStructure();
            resultStructure.pso = meta;

            var rootHash = meta.DataMappingSection.Entries[meta.DataMappingSection.RootIndex - 1].NameHash;
            for (int i = 0; i < meta.DefinitionSection.Count; i++)
            {
                if (meta.DefinitionSection.EntriesIdx[i].NameHash == rootHash)
                {
                    resultStructure.psoSection = (PsoStructureInfo)meta.DefinitionSection.Entries[i];
                    resultStructure.psoEntryInfo = meta.DefinitionSection.EntriesIdx[i];
                }
            }

            var reader = new DataReader(new MemoryStream(meta.DataSection.Data), Endianess.BigEndian);
            reader.Position = meta.DataMappingSection.Entries[meta.DataMappingSection.RootIndex - 1].Offset;
            resultStructure.Read(reader);


            var stack = new Stack<PsoStructure>();
            stack.Push(resultStructure);
            while (stack.Count > 0)
            {
                var x = stack.Pop();
                foreach (var ee in x.psoSection.Entries)
                {
                    if (ee.EntryNameHash == 0x100)
                        continue;

                    var value = x.Values[ee.EntryNameHash];

                    if (value is PsoStructure)
                    {
                        stack.Push((PsoStructure)value);
                    }
                    if (value is PsoArray)
                    {
                        var arrayValue = (PsoArray)value;
                        switch (arrayValue.psoSection.Type)
                        {
                            case DataType.Structure:
                                {
                                    if (arrayValue.NumberOfEntries > 0)
                                    {
                                        arrayValue.Entries = new List<IPsoValue>();
                                        reader.Position = meta.DataMappingSection.Entries[arrayValue.BlockIndex - 1].Offset + arrayValue.Offset;
                                        for (int i = 0; i < arrayValue.NumberOfEntries; i++)
                                        {
                                            PsoStructure item = new PsoStructure();
                                            item.pso = meta;
                                            item.psoSection = null;
                                            for (int y = 0; y < meta.DefinitionSection.Count; y++)
                                            {
                                                if (meta.DefinitionSection.EntriesIdx[y].NameHash == arrayValue.psoSection.ReferenceKey)
                                                {
                                                    item.psoSection = (PsoStructureInfo)meta.DefinitionSection.Entries[y];
                                                    item.psoEntryInfo = meta.DefinitionSection.EntriesIdx[y];
                                                }
                                            }

                                            item.Read(reader);
                                            arrayValue.Entries.Add(item);
                                            stack.Push(item);

                                        }
                                    }

                                    break;
                                }
                            case DataType.INT_0Bh:
                                {
                                    if (arrayValue.NumberOfEntries > 0)
                                    {
                                        arrayValue.Entries = new List<IPsoValue>();
                                        reader.Position = meta.DataMappingSection.Entries[arrayValue.BlockIndex - 1].Offset + arrayValue.Offset;
                                        for (int i = 0; i < arrayValue.NumberOfEntries; i++)
                                        {
                                            PsoType11 item = new PsoType11(0);
                                            item.Read(reader);
                                            arrayValue.Entries.Add(item);
                                        }

                                    }


                                    break;
                                }
                            default:
                                throw new System.Exception("Unknown array type.");
                        }
                    }
                }
            }

            return resultStructure;
        }
    }
}
