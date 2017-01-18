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
using System.IO;

namespace RageLib.GTA5.PSO
{
    public enum PsoSection : uint
    {
        Data = 0x5053494E,
        DataMapping = 0x504D4150,
        Definition = 0x50534348,
    }

    public class PsoFile
    {
        public PsoDataSection DataSection { get; set; }
        public PsoDataMappingSection DataMappingSection { get; set; }
        public PsoDefinitionSection DefinitionSection { get; set; }

        public void Load(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
                Load(stream);
        }

        public virtual void Load(Stream stream)
        {
            stream.Position = 0;

            var reader = new DataReader(stream, Endianess.BigEndian);
            while (reader.Position < reader.Length)
            {
                var identInt = reader.ReadUInt32();
                var ident = (PsoSection)identInt;
                var length = reader.ReadInt32();

                reader.Position -= 8;

                var sectionData = reader.ReadBytes(length);
                var sectionStream = new MemoryStream(sectionData);
                var sectionReader = new DataReader(sectionStream, Endianess.BigEndian);

                switch (ident)
                {
                    case PsoSection.Data:
                        DataSection = new PsoDataSection();
                        DataSection.Read(sectionReader);
                        break;

                    case PsoSection.DataMapping:
                        DataMappingSection = new PsoDataMappingSection();
                        DataMappingSection.Read(sectionReader);
                        break;

                    case PsoSection.Definition:
                        DefinitionSection = new PsoDefinitionSection();
                        DefinitionSection.Read(sectionReader);
                        break;

                    default:
                        // ignore
                        break;
                }
            }
        }

        public void Save(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Create))
                Save(stream);
        }

        public virtual void Save(Stream stream)
        {
            var writer = new DataWriter(stream, Endianess.BigEndian);
            if (DataSection != null) DataSection.Write(writer);
            if (DataMappingSection != null) DataMappingSection.Write(writer);
            if (DefinitionSection != null) DefinitionSection.Write(writer);
        }



        public static bool IsPSO(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
                return !IsRBF(stream);
        }

        public static bool IsPSO(Stream stream)
        {
            return !IsRBF(stream);
        }

        public static bool IsRBF(Stream stream)
        {
            var reader = new DataReader(stream, Endianess.BigEndian);
            var identInt = reader.ReadUInt32();
            stream.Position = 0;
            return ((identInt & 0xFFFFFF00) == 0x52424600);
        }
    }
}
