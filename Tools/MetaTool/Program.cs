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

using RageLib.GTA5.PSOWrappers;
using RageLib.GTA5.PSOWrappers.Xml;
using RageLib.GTA5.ResourceWrappers.PC.Meta;
using RageLib.GTA5.ResourceWrappers.PC.Meta.Descriptions;
using RageLib.Hash;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace MetaTool
{
    public class Program
    {
        private string[] arguments;

        public static void Main(string[] args)
        {
            new Program(args).Run();
        }

        public Program(string[] arguments)
        {
            this.arguments = arguments;
        }

        public void Run()
        {
            if (arguments[0].EndsWith(".ymap.xml") ||
                arguments[0].EndsWith(".ytyp.xml") ||
                arguments[0].EndsWith(".ymt.xml"))
            {
                ConvertToMetaResource();
            }
            else if (arguments[0].EndsWith(".ymf.xml"))
            {
                ConvertToMetaPso();
            }
            else if (arguments[0].EndsWith(".ymap") ||
                   arguments[0].EndsWith(".ytyp") ||
                   arguments[0].EndsWith(".ymt"))
            {

                ConvertResourceToXml();
            }
            else if (arguments[0].EndsWith(".ymf"))
            {
                ConvertPsoToXml();
            }
            else
            {
                Console.WriteLine("Unsupported file extension.");
                Console.ReadLine();
            }
        }

        private void ConvertToMetaResource()
        {
            string inputFileName = arguments[0];
            string outputFileName = inputFileName.Replace(".xml", "");

            var xml = (MetaInformationXml)null;
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream xmlStream = assembly.GetManifestResourceStream("MetaTool.XmlInfos.xml"))
            {
                var ser = new XmlSerializer(typeof(MetaInformationXml));
                xml = (MetaInformationXml)ser.Deserialize(xmlStream);
            }

            var importer = new MetaXmlImporter(xml);

            var imported = importer.Import(inputFileName);

            var writer = new MetaWriter();
            writer.Write(imported, outputFileName);
        }

        private void ConvertToMetaPso()
        {
            string inputFileName = arguments[0];
            string outputFileName = inputFileName.Replace(".xml", "");

            var xml = (PsoDefinitionXml)null;
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream xmlStream = assembly.GetManifestResourceStream("MetaTool.PsoDefinitions.xml"))
            {
                var ser = new XmlSerializer(typeof(PsoDefinitionXml));
                xml = (PsoDefinitionXml)ser.Deserialize(xmlStream);
            }

            var imported = new PsoXmlImporter(xml).Import(inputFileName);
            new PsoWriter().Write(imported, outputFileName);
        }

        private void ConvertResourceToXml()
        {
            string inputFileName = arguments[0];
            string outputFileName = inputFileName + ".xml";

            var reader = new MetaReader();
            var meta = reader.Read(inputFileName);
            var exporter = new MetaXmlExporter();
            exporter.HashMapping = new Dictionary<int, string>();
            AddHashForStrings(exporter, "MetaTool.Lists.FileNames.txt");
            AddHashForStrings(exporter, "MetaTool.Lists.StructureNames.txt");
            AddHashForStrings(exporter, "MetaTool.Lists.StructureFieldNames.txt");
            AddHashForStrings(exporter, "MetaTool.Lists.EnumNames.txt");
            exporter.Export(meta, outputFileName);
        }

        private void ConvertPsoToXml()
        {
            string inputFileName = arguments[0];
            string outputFileName = inputFileName + ".xml";

            var reader = new PsoReader();
            var meta = reader.Read(inputFileName);
            var exporter = new PsoXmlExporter();
            exporter.HashMapping = new Dictionary<int, string>();
            AddHashForStrings(exporter, "MetaTool.Lists.FileNames.txt");
            AddHashForStrings(exporter, "MetaTool.Lists.StructureNames.txt");
            AddHashForStrings(exporter, "MetaTool.Lists.StructureFieldNames.txt");
            AddHashForStrings(exporter, "MetaTool.Lists.EnumNames.txt");
            exporter.Export(meta, outputFileName);
        }

        private void AddHashForStrings(MetaXmlExporter exporter, string resourceFileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream namesStream = assembly.GetManifestResourceStream(resourceFileName))
            using (StreamReader namesReader = new StreamReader(namesStream))
            {
                while (!namesReader.EndOfStream)
                {
                    string name = namesReader.ReadLine();
                    uint hash = Jenkins.Hash(name);
                    if (!exporter.HashMapping.ContainsKey((int)hash))
                    {
                        exporter.HashMapping.Add((int)hash, name);
                    }
                }
            }
        }

        private void AddHashForStrings(PsoXmlExporter exporter, string resourceFileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream namesStream = assembly.GetManifestResourceStream(resourceFileName))
            using (StreamReader namesReader = new StreamReader(namesStream))
            {
                while (!namesReader.EndOfStream)
                {
                    string name = namesReader.ReadLine();
                    uint hash = Jenkins.Hash(name);
                    if (!exporter.HashMapping.ContainsKey((int)hash))
                    {
                        exporter.HashMapping.Add((int)hash, name);
                    }
                }
            }
        }
    }
}
