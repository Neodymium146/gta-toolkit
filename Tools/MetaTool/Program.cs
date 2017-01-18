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
using RageLib.GTA5.PSOWrappers;
using RageLib.GTA5.PSOWrappers.Xml;
using RageLib.GTA5.RBF;
using RageLib.GTA5.RBFWrappers;
using RageLib.GTA5.ResourceWrappers.PC.Meta;
using RageLib.GTA5.ResourceWrappers.PC.Meta.Descriptions;
using RageLib.Hash;
using RageLib.Resources.GTA5;
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
            if (arguments.Length > 0)
            {


                Convert();
            }
            else
            {
                Console.WriteLine("No input file specified.");
                Console.ReadLine();
            }
        }

        private void Convert()
        {
            if (arguments[0].EndsWith(".ymap.xml") ||
             arguments[0].EndsWith(".ytyp.xml") ||
             arguments[0].EndsWith(".ymt.xml"))
            {
                ConvertXmlToResource();
            }
            else if (arguments[0].EndsWith(".ymap") ||
                   arguments[0].EndsWith(".ytyp") ||
                   arguments[0].EndsWith(".ymt"))
            {
                if (ResourceFile_GTA5_pc.IsResourceFile(arguments[0]))
                {
                    ConvertResourceToXml();
                }
                else if (PsoFile.IsPSO(arguments[0]))
                {
                    ConvertPsoToXml();
                }
                else
                {
                    ConvertRbfToXml();
                }
            }
            else if (arguments[0].EndsWith(".ymf"))
            {
                ConvertPsoToXml();
            }
            else
            {
                Console.WriteLine("No supported file name specified.");
                Console.ReadLine();
            }
        }

        private void ConvertXmlToResource()
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
        
        private void ConvertResourceToXml()
        {
            string inputFileName = arguments[0];
            string outputFileName = inputFileName + ".xml";

            var reader = new MetaReader();
            var meta = reader.Read(inputFileName);
            var exporter = new MetaXmlExporter();
            exporter.HashMapping = new Dictionary<int, string>();
            AddHashForStrings(exporter, "MetaTool.Lists.FileNames.txt");
            AddHashForStrings(exporter, "MetaTool.Lists.MetaNames.txt");
            exporter.Export(meta, outputFileName);
        }

        private void ConvertPsoToXml()
        {
            string inputFileName = arguments[0];
            string outputFileName = inputFileName + ".pso.xml";

            var reader = new PsoReader();
            var meta = reader.Read(inputFileName);
            var exporter = new PsoXmlExporter();
            exporter.HashMapping = new Dictionary<int, string>();
            AddHashForStrings(exporter, "MetaTool.Lists.PsoTypeNames.txt");
            AddHashForStrings(exporter, "MetaTool.Lists.PsoFieldNames.txt");
            AddHashForStrings(exporter, "MetaTool.Lists.PsoEnumValues.txt");
            AddHashForStrings(exporter, "MetaTool.Lists.PsoCommon.txt");
            AddHashForStrings(exporter, "MetaTool.Lists.FileNames.txt");
            AddHashForStrings(exporter, "MetaTool.Lists.PsoCollisions.txt");
            exporter.Export(meta, outputFileName);
        }

        private void ConvertRbfToXml()
        {
            string inputFileName = arguments[0];
            string outputFileName = inputFileName + ".rbf.xml";

            var rbf = new RbfFile().Load(inputFileName);
            new RbfXmlExporter().Export(rbf, outputFileName);
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
