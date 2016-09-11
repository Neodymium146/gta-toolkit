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

using NUnit.Framework;
using RageLib.GTA5.ResourceWrappers.PC.Meta;
using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace RageLib.GTA5.Tests.ResourceWrappers.PC.Meta
{
    [TestFixture]
    public class MetaXmlExporterIntegrationTests
    {
        private const string TEST_DATASET = "RageLib.GTA5.Tests.ResourceWrappers.PC.Meta.TestDataset.xml";

        [Test]
        public void Export_Always_CorrectlyExportsXml()
        {
            var exporter = new MetaXmlExporter();
            var xmlStream = new MemoryStream();

            var rootStructure = TestDataset.MakeDataset();

            exporter.Export(rootStructure, xmlStream);

            var assembly = Assembly.GetExecutingAssembly();
            var expectedDocument = new XmlDocument();
            using (var expectedDocumentStream = assembly.GetManifestResourceStream(TEST_DATASET))
            {
                expectedDocument.Load(expectedDocumentStream);
            }
            var actualDocument = new XmlDocument();
            xmlStream.Position = 0;
            actualDocument.Load(xmlStream);
            AssertXml(expectedDocument, actualDocument);
        }

        public void AssertXml(XmlDocument expectedDocument, XmlDocument actualDocument)
        {
            var expectedNodes = expectedDocument.ChildNodes;
            var actualNodes = actualDocument.ChildNodes;

            Assert.AreEqual(expectedNodes.Count, actualNodes.Count);
            for (int i = 0; i < expectedNodes.Count; i++)
            {
                AssertXmlNode(expectedNodes[i], actualNodes[i]);
            }
        }

        public void AssertXmlNode(XmlNode expectedNode, XmlNode actualNode)
        {
            if (expectedNode.NodeType == XmlNodeType.Text)
            {
                string[] s1 = expectedNode.Value.Trim().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                string[] s2 = actualNode.Value.Trim().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                Assert.AreEqual(s1.Length, s2.Length);
                for (int i = 0; i < s1.Length; i++)
                {
                    Assert.AreEqual(s1[i].Trim(), s2[i].Trim());
                }
            }
            else
            {
                AssertXmlAttributes(expectedNode.Attributes, actualNode.Attributes);

                var expectedNodes = expectedNode.ChildNodes;
                var actualNodes = actualNode.ChildNodes;
                Assert.AreEqual(expectedNodes.Count, actualNodes.Count);
                for (int i = 0; i < expectedNodes.Count; i++)
                {
                    AssertXmlNode(expectedNodes[i], actualNodes[i]);
                }
            }

        }

        public void AssertXmlAttributes(XmlAttributeCollection expectedAttributes, XmlAttributeCollection actualAttributes)
        {
            Assert.AreEqual(expectedAttributes?.Count, actualAttributes?.Count);
            if (expectedAttributes != null)
            {
                for (int i = 0; i < expectedAttributes.Count; i++)
                {
                    Assert.AreEqual(expectedAttributes[i].Name, actualAttributes[i].Name);
                    Assert.AreEqual(expectedAttributes[i].Value, actualAttributes[i].Value);
                }
            }
        }
    }
}
