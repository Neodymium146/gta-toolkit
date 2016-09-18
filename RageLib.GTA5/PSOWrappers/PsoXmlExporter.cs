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
using RageLib.GTA5.PSOWrappers.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RageLib.GTA5.PSOWrappers
{
    public class PsoXmlExporter
    {
        public Dictionary<int, string> HashMapping { get; set; }

        public PsoXmlExporter()
        {
            HashMapping = new Dictionary<int, string>();
        }

        public void Export(IPsoValue value, string xmlFileName)
        {
            using (var xmlFileStream = new FileStream(xmlFileName, FileMode.Create))
            {
                Export(value, xmlFileStream);
            }
        }

        public void Export(IPsoValue value, Stream xmlFileStream)
        {
            var strctureValue = (PsoStructure)value;

            var writer = new XmlTextWriter(xmlFileStream, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement(GetNameForHash(strctureValue.psoEntryInfo.NameHash));
            WriteStructureContentXml(strctureValue, writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
        }

        private void WriteStructureContentXml(PsoStructure value, XmlTextWriter writer)
        {
            foreach (var field in value.Values)
            {
                var fieldNameHash = field.Key;
                var fieldValue = field.Value;
                writer.WriteStartElement(GetNameForHash(fieldNameHash));
                WriteStructureElementContentXml(fieldValue, writer);
                writer.WriteEndElement();
            }
        }

        private void WriteStructureElementContentXml(IPsoValue value, XmlTextWriter writer)
        {
            if (value is PsoArray)
            {
                var arrayValue = value as PsoArray;
                if (arrayValue.Entries != null)
                {
                    if (arrayValue.psoSection.Type == DataType.INT_0Bh)
                    {
                        // TODO write content...
                        //WriteByteArrayContent(writer, arrayValue);

                        foreach (var k in arrayValue.Entries)
                        {
                            writer.WriteStartElement("Item");
                            var kk = k as PsoType11;
                            if (kk.Value == null)
                            {
                                writer.WriteString(GetNameForHash(kk.ValueHash));
                            }
                            else
                            {
                                writer.WriteString(kk.Value);
                            }
                            writer.WriteEndElement();
                        }

                    }
                    else if (arrayValue.psoSection.Type == DataType.BYTE_ENUM_VALUE)
                    {
                        // TODO write content...
                        //WriteByteArrayContent(writer, arrayValue);

                        foreach (var k in arrayValue.Entries)
                        {
                            writer.WriteStartElement("Item");
                            writer.WriteString(GetHex(((PsoType14)k).Value));
                            writer.WriteEndElement();
                        }

                    }
                    else if (arrayValue.psoSection.Type == DataType.Structure)
                    {
                        foreach (var k in arrayValue.Entries)
                        {
                            writer.WriteStartElement("Item");
                            if (k is PsoStructure)
                            {
                                WriteStructureContentXml(k as PsoStructure, writer);
                            }
                            else
                            {
                                WriteStructureElementContentXml(k, writer);
                            }
                            writer.WriteEndElement();
                        }
                    }
                    else
                    {
                        throw new Exception("unsupperde type");
                    }
                }
            }
            if (value is PsoType6)
            {
                var v = value as PsoType6;
                Write6Content(writer, v);
            }
            if (value is PsoType11)
            {
                var v = value as PsoType11;
                Write11Content(writer, v);
            }
            if (value is PsoType14)
            {
                var v = value as PsoType14;
                Write14Content(writer, v);
            }
            if (value is PsoType15)
            {
                var v = value as PsoType15;
                Write15Content(writer, v);
            }
            if (value is PsoStructure)
            {
                var structureValue = value as PsoStructure;
                WriteStructureContentXml(structureValue, writer);
            }
        }

        private void Write6Content(XmlTextWriter writer, PsoType6 value)
        {
            writer.WriteAttributeString("value", value.Value.ToString());
        }
        
        private void Write11Content(XmlTextWriter writer, PsoType11 value)
        {
            if (value.Value == null)
            {
                writer.WriteString(GetNameForHash(value.ValueHash));
            }
            else
            {
                writer.WriteString(value.Value);
            }
        }

        private void Write14Content(XmlTextWriter writer, PsoType14 value)
        {
            //var sb = new StringBuilder();
            //for (int i = 0; i < 32; i++)
            //{
            //    if ((value.Value & (1 << i)) != 0)
            //    {
            //        sb.Append("flag_index_" + i.ToString() + " ");
            //    }
            //}

            //writer.WriteString(sb.ToString().Trim());

            writer.WriteString(GetHex(value.Value));
        }

        private void Write15Content(XmlTextWriter writer, PsoType15 value)
        {
            //var sb = new StringBuilder();
            //for (int i = 0; i < 32; i++)
            //{
            //    if ((value.Value & (1 << i)) != 0)
            //    {
            //        sb.Append("flag_index_" + i.ToString() + " ");
            //    }
            //}

            //writer.WriteString(sb.ToString().Trim());

            writer.WriteString(GetHex(value.Value));
        }






        private string GetHex(int hash)
        {          
            return "hex_" + hash.ToString("X8");
        }

        private string GetNameForHash(int hash)
        {
            if (HashMapping.ContainsKey(hash))
            {
                var ss = HashMapping[hash];
                return ss;
            }
            return "hash_" + hash.ToString("X8");
        }

        private string GetEnumNameForHash(int hash)
        {
            if (HashMapping.ContainsKey(hash))
            {
                var ss = HashMapping[hash];
                return ss;
            }
            return "enum_hash_" + hash.ToString("X8");
        }

        private string GetFlagNameForHash(int hash)
        {
            if (HashMapping.ContainsKey(hash))
            {
                var ss = HashMapping[hash];
                return ss;
            }
            return "flag_hash_" + hash.ToString("X8");
        }

        public string ByteArrayToString(byte[] b)
        {
            var result = new StringBuilder();
            for (int i = 0; i < b.Length; i++)
            {
                //result.Append("0x");
                result.Append(b[i].ToString());
                if (i != b.Length - 1)
                {
                    result.Append(" ");
                }
            }
            return result.ToString();
        }

    }
}
