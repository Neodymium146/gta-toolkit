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
using System.Collections.Generic;

namespace RageLib.GTA5.PSO
{
    public class PsoDataMappingSection
    {
        public int Ident { get; set; } = 0x504D4150;
        public int Length { get; private set; }
        public int RootIndex { get; set; }
        public short EntriesCount { get; private set; }
        public short Unknown_Eh { get; set; } = 0x7070;
        public List<PsoDataMappingEntry> Entries { get; set; }

        public void Read(DataReader reader)
        {
            Ident = reader.ReadInt32();
            Length = reader.ReadInt32();
            RootIndex = reader.ReadInt32();
            EntriesCount = reader.ReadInt16();
            Unknown_Eh = reader.ReadInt16();
            Entries = new List<PsoDataMappingEntry>();
            for (int i = 0; i < EntriesCount; i++)
            {
                var entry = new PsoDataMappingEntry();
                entry.Read(reader);
                Entries.Add(entry);
            }
        }

        public void Write(DataWriter writer)
        {
            // update...
            EntriesCount = (short)Entries.Count;
            Length = 16 + EntriesCount * 16;           

            writer.Write(Ident);
            writer.Write(Length);
            writer.Write(RootIndex);
            writer.Write(EntriesCount);
            writer.Write(Unknown_Eh);
            foreach (var entry in Entries)
            {
                entry.Write(writer);
            }
        }
    }

    public class PsoDataMappingEntry
    {
        public int NameHash { get; set; }
        public int Offset { get; set; }
        public int Unknown_8h { get; set; } = 0x00000000;
        public int Length { get; set; }

        public void Read(DataReader reader)
        {
            this.NameHash = reader.ReadInt32();
            this.Offset = reader.ReadInt32();
            this.Unknown_8h = reader.ReadInt32();
            this.Length = reader.ReadInt32();
        }

        public void Write(DataWriter writer)
        {
            writer.Write(NameHash);
            writer.Write(Offset);
            writer.Write(Unknown_8h);
            writer.Write(Length);
        }
    }
}
