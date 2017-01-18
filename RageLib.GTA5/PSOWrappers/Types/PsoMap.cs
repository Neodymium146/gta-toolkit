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
using RageLib.GTA5.PSOWrappers.Data;
using System;
using System.Collections.Generic;

namespace RageLib.GTA5.PSOWrappers.Types
{
    public class PsoMap : IPsoValue
    {
        public readonly PsoFile pso;
        public readonly PsoStructureInfo structureInfo;
        public readonly PsoStructureEntryInfo keyEntryInfo;
        public readonly PsoStructureEntryInfo valueEntryInfo;
        public List<PsoStructure> Entries { get; set; }

        public PsoMap(
            PsoFile pso,
            PsoStructureInfo structureInfo,
          PsoStructureEntryInfo keyEntryInfo,
          PsoStructureEntryInfo valueEntryInfo)
        {
            this.pso = pso;
            this.structureInfo = structureInfo;
            this.keyEntryInfo = keyEntryInfo;
            this.valueEntryInfo = valueEntryInfo;
        }

        public void Read(PsoDataReader reader)
        {
            int x1 = reader.ReadInt32();
            int x2 = reader.ReadInt32();
            int x3 = reader.ReadInt32();
            int unk = (x3 >> 12) & 0x000FFFFF;
            int sectionIndex = x3 & 0x00000FFF;

            int x4 = reader.ReadInt32();


            int x5 = reader.ReadInt32();
            int length1 = (x5 >> 16) & 0x0000FFFF;
            int length2 = x5 & 0x0000FFFF;
            if (length1 != length2)
                throw new Exception("length does not match");

            int x6 = reader.ReadInt32();




            // read reference data...
            var backupOfSection = reader.CurrentSectionIndex;
            var backupOfPosition = reader.Position;

            reader.SetSectionIndex(sectionIndex - 1);
            reader.Position = unk;

            int nameOfDataSection = pso.DataMappingSection.Entries[sectionIndex - 1].NameHash;
            var sectionInfo = (PsoStructureInfo)null;
            //var sectionIdxInfo = (PsoElementIndexInfo)null;
            for (int k = 0; k < pso.DefinitionSection.EntriesIdx.Count; k++)
            {
                if (pso.DefinitionSection.EntriesIdx[k].NameHash == nameOfDataSection)
                {
                    sectionInfo = (PsoStructureInfo)pso.DefinitionSection.Entries[k];
                    //sectionIdxInfo = pso.DefinitionSection.EntriesIdx[k];
                }
            }

            Entries = new List<PsoStructure>();
            for (int i = 0; i < length1; i++)
            {
                var entryStr = new PsoStructure(pso, sectionInfo, null, null);
                entryStr.Read(reader);
                Entries.Add(entryStr);
            }

            reader.SetSectionIndex(backupOfSection);
            reader.Position = backupOfPosition;
        }

        public void Write(DataWriter writer)
        {
        }
    }
}
