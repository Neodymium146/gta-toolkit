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
using System;
using System.Collections.Generic;

namespace RageLib.GTA5.PSOWrappers.Types
{
    public class PsoStructure : IPsoValue
    {
        public PsoFile pso;
        public PsoElementIndexInfo psoEntryInfo;
        public PsoStructureInfo psoSection;
        public Dictionary<int, IPsoValue> Values { get; set; }

        public void Read(DataReader reader)
        {
            long position = reader.Position;

            this.Values = new Dictionary<int, IPsoValue>();
            for (int i = 0; i < psoSection.Entries.Count; i++)
            {
                var x1 = psoSection.Entries[i];
                if (x1.EntryNameHash == 0x100)
                    continue;

                reader.Position = position + x1.DataOffset;
                switch (x1.Type)
                {
                    case DataType.Array:
                        {
                            var entryValue = new PsoArray();
                            entryValue.psoSection = psoSection.Entries[x1.ReferenceKey & 0x0000FFFF];
                            entryValue.Read(reader);
                            this.Values.Add(x1.EntryNameHash, entryValue);
                            break;
                        }
                    case DataType.INT_0Bh:
                        {
                            if (psoSection.Entries[i].ReferenceKey == 0)
                            {
                                var entryValue = new PsoType11(0);
                                entryValue.Read(reader);
                                this.Values.Add(x1.EntryNameHash, entryValue);
                            }
                            else
                            {
                                var entryValue = new PsoType11(64);
                                entryValue.Read(reader);
                                this.Values.Add(x1.EntryNameHash, entryValue);
                            }

                            break;
                        }
                    case DataType.BYTE_ENUM_VALUE:
                        {
                            var entryValue = new PsoType14();
                            entryValue.Read(reader);
                            this.Values.Add(x1.EntryNameHash, entryValue);
                            break;
                        }
                    case DataType.SHORT_0Fh:
                        {
                            var entryValue = new PsoType15();
                            entryValue.Read(reader);
                            this.Values.Add(x1.EntryNameHash, entryValue);
                            break;
                        }
                    case DataType.INT_06h:
                        {
                            var entryValue = new PsoType6();
                            entryValue.Read(reader);
                            this.Values.Add(x1.EntryNameHash, entryValue);
                            break;
                        }
                    case DataType.Structure:
                        {
                            var entryValue = new PsoStructure();
                            entryValue.pso = pso;
                            entryValue.psoSection = GetStructureInfo(pso, x1.ReferenceKey);
                            entryValue.psoEntryInfo = GetStructureIndexInfo(pso, x1.ReferenceKey);
                            entryValue.Read(reader);
                            this.Values.Add(x1.EntryNameHash, entryValue);
                            break;
                        }


                    case DataType.TYPE_10h:
                        {
                            var entryValue = new PsoType16();
                            entryValue.Read(reader);
                            this.Values.Add(x1.EntryNameHash, entryValue);
                            break;
                        }
                    case DataType.INT_05h:
                        {
                            var entryValue = new PsoType5();
                            entryValue.Read(reader);
                            this.Values.Add(x1.EntryNameHash, entryValue);
                            break;
                        }
                    case DataType.BYTE_02h:
                        {
                            var entryValue = new PsoType2();
                            entryValue.Read(reader);
                            this.Values.Add(x1.EntryNameHash, entryValue);
                            break;
                        }
                    case DataType.Float:
                        {
                            var entryValue = new PsoFloat();
                            entryValue.Read(reader);
                            this.Values.Add(x1.EntryNameHash, entryValue);
                            break;
                        }
                    case DataType.BYTE_00h:
                        {
                            var entryValue = new PsoType0();
                            entryValue.Read(reader);
                            this.Values.Add(x1.EntryNameHash, entryValue);
                            break;
                        }
                    case DataType.TYPE_15h:
                        {
                            var entryValue = new PsoType21();
                            entryValue.Read(reader);
                            this.Values.Add(x1.EntryNameHash, entryValue);
                            break;
                        }
                    default:
                        throw new Exception("Unknown Type");
                }
            }

            reader.Position = position + psoSection.StructureLength;
        }

        public void Write(DataWriter writer)
        {
            long position = writer.Position;

            writer.Write(new byte[psoSection.StructureLength]);
            writer.Position = position;

            foreach (var entry in psoSection.Entries)
            {
                if (entry.EntryNameHash != 0x100)
                {
                    writer.Position = position + entry.DataOffset;
                    this.Values[entry.EntryNameHash].Write(writer);
                }
            }
            writer.Position = position + psoSection.StructureLength;
        }

        public static PsoStructureInfo GetStructureInfo(PsoFile meta, int structureKey)
        {
            PsoStructureInfo info = null;
            for (int i = 0; i < meta.DefinitionSection.Count; i++)
                if (meta.DefinitionSection.EntriesIdx[i].NameHash == structureKey)
                    info = (PsoStructureInfo)meta.DefinitionSection.Entries[i];
            return info;
        }

        public static PsoElementIndexInfo GetStructureIndexInfo(PsoFile meta, int structureKey)
        {
            PsoElementIndexInfo info = null;
            for (int i = 0; i < meta.DefinitionSection.Count; i++)
                if (meta.DefinitionSection.EntriesIdx[i].NameHash == structureKey)
                    info = (PsoElementIndexInfo)meta.DefinitionSection.EntriesIdx[i];
            return info;
        }
    }
}
