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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using RageLib.GTA5.PSO;

namespace RageLib.GTA5.PSOWrappers.Data
{
    public class PsoDataReader : DataReader
    {
        private readonly PsoFile psoFile;

        public override long Length
        {
            get
            {
                return psoFile.DataMappingSection.Entries[CurrentSectionIndex].Length;
            }
        }

        public int CurrentSectionIndex
        {
            get;
            private set;
        }

        public int CurrentSectionHash
        {
            get;
            private set;
        }

        public override long Position
        {
            get;
            set;
        }



        public PsoDataReader(PsoFile psoFile) : base(null, Endianess.BigEndian)
        {
            this.psoFile = psoFile;
        }

        protected override byte[] ReadFromStream(int count, bool ignoreEndianess = false)
        {
            // TODO very bad performance, improve this!
            var str = new MemoryStream(psoFile.DataSection.Data);
            str.Position = psoFile.DataMappingSection.Entries[CurrentSectionIndex].Offset;
            str.Position += Position;

            var buffer = new byte[count];
            str.Read(buffer, 0, count);

            Position += count;

            // handle endianess
            if (!ignoreEndianess && (Endianess == Endianess.BigEndian))
            {
                Array.Reverse(buffer);
            }

            return buffer;
        }

        public void SetSectionIndex(int index)
        {
            CurrentSectionIndex = index;
            CurrentSectionHash = psoFile.DataMappingSection.Entries[index].NameHash;
        }
    }
}
