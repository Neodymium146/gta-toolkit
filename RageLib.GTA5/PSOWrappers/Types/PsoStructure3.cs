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

namespace RageLib.GTA5.PSOWrappers.Types
{
    public class PsoStructure3 : IPsoValue
    {
        public readonly PsoFile pso;
        public readonly PsoStructureInfo structureInfo;
        public readonly PsoStructureEntryInfo entryInfo;
        public PsoStructure Value { get; set; }

        public PsoStructure3(PsoFile pso, PsoStructureInfo structureInfo, PsoStructureEntryInfo entryInfo)
        {
            this.pso = pso;
            this.structureInfo = structureInfo;
            this.entryInfo = entryInfo;
        }

        public void Read(PsoDataReader reader)
        {
            int z1 = reader.ReadInt32();
            int z2 = reader.ReadInt32();
            if (z2 != 0)
                throw new Exception("z2 should be zero");

            int offset = (z1 >> 12) & 0x000FFFFF;
            int sectionIndex = z1 & 0x00000FFF;

            if (sectionIndex > 0)
            {
                var nameHash = pso.DataMappingSection.Entries[sectionIndex - 1].NameHash;
                var strInfo = (PsoStructureInfo)null;
                var sectionIdxInfo = (PsoElementIndexInfo)null;
                for (int k = 0; k < pso.DefinitionSection.Entries.Count; k++)
                {
                    if (pso.DefinitionSection.EntriesIdx[k].NameHash == nameHash)
                    {
                        strInfo = (PsoStructureInfo)pso.DefinitionSection.Entries[k];
                        sectionIdxInfo = pso.DefinitionSection.EntriesIdx[k];
                    }
                }


                // read reference data...
                var backupOfSection = reader.CurrentSectionIndex;
                var backupOfPosition = reader.Position;

                reader.SetSectionIndex(sectionIndex - 1);
                reader.Position = offset;

                Value = new PsoStructure(pso, strInfo, sectionIdxInfo, null);
                Value.Read(reader);

                reader.SetSectionIndex(backupOfSection);
                reader.Position = backupOfPosition;
            }
            else
            {
                Value = null;
            }

        }

        public void Write(DataWriter writer)
        {
        }
    }
}
