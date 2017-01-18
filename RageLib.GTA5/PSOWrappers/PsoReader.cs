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
using RageLib.GTA5.PSOWrappers.Data;
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

            var t1 = (PsoStructureInfo)null;
            var t2 = (PsoElementIndexInfo)null;
            var rootHash = meta.DataMappingSection.Entries[meta.DataMappingSection.RootIndex - 1].NameHash;
            for (int i = 0; i < meta.DefinitionSection.Count; i++)
            {
                if (meta.DefinitionSection.EntriesIdx[i].NameHash == rootHash)
                {
                    t1 = (PsoStructureInfo)meta.DefinitionSection.Entries[i];
                    t2 = meta.DefinitionSection.EntriesIdx[i];
                }
            }

            var resultStructure = new PsoStructure(meta, t1, t2, null);

            var reader = new PsoDataReader(meta);
            reader.SetSectionIndex(meta.DataMappingSection.RootIndex - 1);
            reader.Position = 0;
            resultStructure.Read(reader);
            return resultStructure;
        }
    }
}
