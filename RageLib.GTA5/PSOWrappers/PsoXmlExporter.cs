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
using System.Globalization;
using System.IO;
using System.Text;
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
            writer.WriteStartElement(GetNameForHash(strctureValue.entryIndexInfo.NameHash));
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
                var fixedName = GetNameForHash(fieldNameHash);

                writer.WriteStartElement(fixedName);
                WriteStructureElementContentXml(fieldValue, writer);
                writer.WriteEndElement();
            }
        }

        private void WriteStructureContentXml(PsoStructure3 value, XmlTextWriter writer)
        {
            if (value.Value != null)
            {
                writer.WriteAttributeString("type", GetNameForHash(value.Value.entryIndexInfo.NameHash));
                foreach (var field in value.Value.Values)
                {
                    var fieldNameHash = field.Key;
                    var fieldValue = field.Value;
                    var fixedName = GetNameForHash(fieldNameHash);
                    writer.WriteStartElement(fixedName);
                    WriteStructureElementContentXml(fieldValue, writer);
                    writer.WriteEndElement();
                }
            }
        }

        private void WriteStructureElementContentXml(IPsoValue value, XmlTextWriter writer)
        {
            if (value is PsoArray0)
            {
                WriteArrayContent(writer, (PsoArray0)value);
            }
            else if (value is PsoArray1)
            {
                WriteArrayContent(writer, (PsoArray1)value);
            }
            else if (value is PsoArray4)
            {
                WriteArrayContent(writer, (PsoArray4)value);
            }
            else if (value is PsoBoolean)
            {
                WriteBooleanContent(writer, (PsoBoolean)value);
            }
            else if (value is PsoByte)
            {
                WriteByteContent(writer, (PsoByte)value);
            }
            else if (value is PsoEnumByte)
            {
                WriteEnumContent(writer, (PsoEnumByte)value);
            }
            else if (value is PsoEnumInt)
            {
                WriteEnumContent(writer, (PsoEnumInt)value);
            }
            else if (value is PsoFlagsByte)
            {
                WriteFlagsContent(writer, (PsoFlagsByte)value);
            }
            else if (value is PsoFlagsShort)
            {
                WriteFlagsContent(writer, (PsoFlagsShort)value);
            }
            else if (value is PsoFlagsInt)
            {
                WriteFlagsContent(writer, (PsoFlagsInt)value);
            }
            else if (value is PsoFloat)
            {
                WriteFloatContent(writer, (PsoFloat)value);
            }
            else if (value is PsoFloat2)
            {
                WriteFloatContent(writer, (PsoFloat2)value);
            }
            else if (value is PsoFloat3)
            {
                WriteFloatContent(writer, (PsoFloat3)value);
            }
            else if (value is PsoFloat4A)
            {
                WriteFloatContent(writer, (PsoFloat4A)value);
            }
            else if (value is PsoFloat4B)
            {
                WriteFloatContent(writer, (PsoFloat4B)value);
            }
            else if (value is PsoIntSigned)
            {
                WriteIntegerContent(writer, (PsoIntSigned)value);
            }
            else if (value is PsoIntUnsigned)
            {
                WriteIntegerContent(writer, (PsoIntUnsigned)value);
            }
            else if (value is PsoMap)
            {
                WriteMapContent(writer, (PsoMap)value);
            }
            else if (value is PsoString0)
            {
                WriteStringContent(writer, (PsoString0)value);
            }
            else if (value is PsoString1)
            {
                WriteStringContent(writer, (PsoString1)value);
            }
            else if (value is PsoString2)
            {
                WriteStringContent(writer, (PsoString2)value);
            }
            else if (value is PsoString3)
            {
                WriteStringContent(writer, (PsoString3)value);
            }
            else if (value is PsoString7)
            {
                WriteStringContent(writer, (PsoString7)value);
            }
            else if (value is PsoString8)
            {
                WriteStringContent(writer, (PsoString8)value);
            }


            else if (value is PsoType5)
            {
                var v = value as PsoType5;
                Write5Content(writer, v);
            }
            else if (value is PsoStructure)
            {
                var structureValue = value as PsoStructure;
                WriteStructureContentXml(structureValue, writer);
            }
            else if (value is PsoStructure3)
            {
                var structureValue = value as PsoStructure3;
                WriteStructureContentXml(structureValue, writer);
            }
            else if (value is PsoXXHalf)
            {
                throw new NotImplementedException();
            }
            else if (value is PsoType4)
            {
                throw new NotImplementedException();
            }
            else if (value is PsoType9)
            {
                throw new NotImplementedException();
            }
            else if (value is PsoType32)
            {
                throw new NotImplementedException();
            }
            else if (value is PsoType3)
            {
                throw new NotImplementedException();
            }
            else if (value is PsoXXByte)
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new Exception("Unknown type");
            }
        }





        private void WriteArrayContent(XmlTextWriter writer, PsoArray0 arrayValue)
        {
            if (arrayValue.Entries != null)
            {
                foreach (var arrayEntry in arrayValue.Entries)
                {
                    writer.WriteStartElement("Item");
                    if (arrayEntry is PsoStructure)
                    {
                        WriteStructureContentXml((PsoStructure)arrayEntry, writer);
                    }
                    else if (arrayEntry is PsoStructure3)
                    {
                        WriteStructureContentXml((PsoStructure3)arrayEntry, writer);
                    }
                    else
                    {
                        WriteStructureElementContentXml(arrayEntry, writer);
                    }
                    writer.WriteEndElement();
                }
            }
        }

        private void WriteArrayContent(XmlTextWriter writer, PsoArray1 arrayValue)
        {
            foreach (var arrayEntry in arrayValue.Entries)
            {
                writer.WriteStartElement("Item");
                if (arrayEntry is PsoStructure)
                {
                    WriteStructureContentXml((PsoStructure)arrayEntry, writer);
                }
                else if (arrayEntry is PsoStructure3)
                {
                    WriteStructureContentXml((PsoStructure3)arrayEntry, writer);
                }
                else
                {
                    WriteStructureElementContentXml(arrayEntry, writer);
                }
                writer.WriteEndElement();
            }
        }

        private void WriteArrayContent(XmlTextWriter writer, PsoArray4 arrayValue)
        {
            foreach (var arrayEntry in arrayValue.Entries)
            {
                writer.WriteStartElement("Item");
                if (arrayEntry is PsoStructure)
                {
                    WriteStructureContentXml((PsoStructure)arrayEntry, writer);
                }
                else if (arrayEntry is PsoStructure3)
                {
                    WriteStructureContentXml((PsoStructure3)arrayEntry, writer);
                }
                else
                {
                    WriteStructureElementContentXml(arrayEntry, writer);
                }
                writer.WriteEndElement();
            }
        }

        private void WriteBooleanContent(XmlTextWriter writer, PsoBoolean value)
        {
            if (value.Value)
            {
                writer.WriteAttributeString("value", "true");
            }
            else
            {
                writer.WriteAttributeString("value", "false");
            }
        }

        private void WriteByteContent(XmlTextWriter writer, PsoByte value)
        {
            writer.WriteAttributeString("value", value.Value.ToString());
        }

        private void WriteEnumContent(XmlTextWriter writer, PsoEnumByte value)
        {
            var matchingEnumEntry = (PsoEnumEntryInfo)null;
            foreach (var enumEntry in value.TypeInfo.Entries)
            {
                if (enumEntry.EntryKey == value.Value)
                    matchingEnumEntry = enumEntry;
            }

            if (matchingEnumEntry != null)
            {
                var matchingEntryName = GetNameForHash(matchingEnumEntry.EntryNameHash);
                writer.WriteString(matchingEntryName);
            }
        }

        private void WriteEnumContent(XmlTextWriter writer, PsoEnumInt value)
        {
            var matchingEnumEntry = (PsoEnumEntryInfo)null;
            foreach (var enumEntry in value.TypeInfo.Entries)
            {
                if (enumEntry.EntryKey == value.Value)
                    matchingEnumEntry = enumEntry;
            }

            if (matchingEnumEntry != null)
            {
                var matchingEntryName = GetNameForHash(matchingEnumEntry.EntryNameHash);
                writer.WriteString(matchingEntryName);
            }
        }

        private void WriteFlagsContent(XmlTextWriter writer, PsoFlagsByte value)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 8; i++)
            {
                if ((value.Value & (1 << i)) != 0)
                {
                    var machingFlagEntry = (PsoEnumEntryInfo)null;
                    foreach (var flagEntry in value.TypeInfo.Entries)
                    {
                        if (flagEntry.EntryKey == i)
                            machingFlagEntry = flagEntry;
                    }

                    var matchingFlagName = GetNameForHash(machingFlagEntry.EntryNameHash);
                    sb.Append(matchingFlagName + " ");
                }
            }

            var flagsString = sb.ToString().Trim();
            writer.WriteString(flagsString);
        }

        private void WriteFlagsContent(XmlTextWriter writer, PsoFlagsShort value)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 16; i++)
            {
                if ((value.Value & (1 << i)) != 0)
                {
                    var machingFlagEntry = (PsoEnumEntryInfo)null;
                    foreach (var flagEntry in value.TypeInfo.Entries)
                    {
                        if (flagEntry.EntryKey == i)
                            machingFlagEntry = flagEntry;
                    }

                    var matchingFlagName = GetNameForHash(machingFlagEntry.EntryNameHash);
                    sb.Append(matchingFlagName + " ");
                }
            }

            var flagsString = sb.ToString().Trim();
            writer.WriteString(flagsString);
        }

        private void WriteFlagsContent(XmlTextWriter writer, PsoFlagsInt value)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 32; i++)
            {
                if ((value.Value & (1 << i)) != 0)
                {
                    var machingFlagEntry = (PsoEnumEntryInfo)null;
                    foreach (var flagEntry in value.TypeInfo.Entries)
                    {
                        if (flagEntry.EntryKey == i)
                            machingFlagEntry = flagEntry;
                    }

                    var matchingFlagName = GetNameForHash(machingFlagEntry.EntryNameHash);
                    sb.Append(matchingFlagName + " ");
                }
            }

            var flagsString = sb.ToString().Trim();
            writer.WriteString(flagsString);
        }

        private void WriteFloatContent(XmlTextWriter writer, PsoFloat value)
        {
            var s1 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.Value);
            writer.WriteAttributeString("value", s1);
        }

        private void WriteFloatContent(XmlTextWriter writer, PsoFloat2 value)
        {
            var s1 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.X);
            var s2 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.Y);
            writer.WriteAttributeString("x", s1);
            writer.WriteAttributeString("y", s2);
        }

        private void WriteFloatContent(XmlTextWriter writer, PsoFloat3 value)
        {
            var s1 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.X);
            var s2 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.Y);
            var s3 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.Z);
            writer.WriteAttributeString("x", s1);
            writer.WriteAttributeString("y", s2);
            writer.WriteAttributeString("z", s3);
        }

        private void WriteFloatContent(XmlTextWriter writer, PsoFloat4A value)
        {
            var s1 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.X);
            var s2 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.Y);
            var s3 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.Z);
            var s4 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.W);
            writer.WriteAttributeString("x", s1);
            writer.WriteAttributeString("y", s2);
            writer.WriteAttributeString("z", s3);
            writer.WriteAttributeString("w", s4);
        }

        private void WriteFloatContent(XmlTextWriter writer, PsoFloat4B value)
        {
            var s1 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.X);
            var s2 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.Y);
            var s3 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.Z);
            var s4 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.W);
            writer.WriteAttributeString("x", s1);
            writer.WriteAttributeString("y", s2);
            writer.WriteAttributeString("z", s3);
            writer.WriteAttributeString("w", s4);
        }

        private void WriteIntegerContent(XmlTextWriter writer, PsoIntSigned value)
        {
            writer.WriteAttributeString("value", value.Value.ToString());
        }

        private void WriteIntegerContent(XmlTextWriter writer, PsoIntUnsigned value)
        {
            writer.WriteAttributeString("value", value.Value.ToString("X8"));
        }

        private void WriteMapContent(XmlTextWriter writer, PsoMap value)
        {
            if (value.Entries != null)
            {
                foreach (var arrayEntry in value.Entries)
                {
                    writer.WriteStartElement("Item");

                    var strKey = (PsoString7)arrayEntry.Values[0x6098a50e];
                    writer.WriteAttributeString("key", GetNameForHash(strKey.Value));

                    var kk = arrayEntry.Values[0x063fa3f2];
                    if (kk is PsoStructure)
                    {
                        WriteStructureContentXml((PsoStructure)kk, writer);
                    }
                    else if (kk is PsoStructure3)
                    {
                        WriteStructureContentXml((PsoStructure3)kk, writer);
                    }
                    else
                    {
                        WriteStructureElementContentXml(kk, writer);
                    }


                    writer.WriteEndElement();
                }
            }
        }

        private void WriteStringContent(XmlTextWriter writer, PsoString0 value)
        {
            if (value.Value != null)
            {
                writer.WriteString(value.Value.Replace("\0", ""));
            }
        }

        private void WriteStringContent(XmlTextWriter writer, PsoString1 value)
        {
            if (value.Value != null)
            {
                writer.WriteString(value.Value.Replace("\0", ""));
            }
        }

        private void WriteStringContent(XmlTextWriter writer, PsoString2 value)
        {
            if (value.Value != null)
            {
                writer.WriteString(value.Value.Replace("\0", ""));
            }
        }

        private void WriteStringContent(XmlTextWriter writer, PsoString3 value)
        {
            if (value.Value != null)
            {
                writer.WriteString(value.Value.Replace("\0", ""));
            }
        }

        private void WriteStringContent(XmlTextWriter writer, PsoString7 value)
        {
            if (value.Value != 0)
            {
                writer.WriteString(GetNameForHash(value.Value));
            }
        }

        private void WriteStringContent(XmlTextWriter writer, PsoString8 value)
        {
            if (value.Value != 0)
            {
                writer.WriteString(GetNameForHash(value.Value));
            }
        }









        private void Write5Content(XmlTextWriter writer, PsoType5 value)
        {
            writer.WriteAttributeString("value", value.Value.ToString());
        }






        private string GetNameForHash(int hash)
        {
            if (HashMapping.ContainsKey(hash))
            {
                var ss = HashMapping[hash];
                return ss;
            }
            else
            {
                throw new Exception("Hash 0x" + hash.ToString("X8") + "could not be replaced by a string.");
            }
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
