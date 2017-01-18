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

using RageLib.GTA5.ResourceWrappers.PC.Meta.Types;
using RageLib.Resources.GTA5.PC.Meta;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;

namespace RageLib.GTA5.ResourceWrappers.PC.Meta
{
    public class MetaXmlExporter
    {
        public Dictionary<int, string> HashMapping { get; set; }

        public MetaXmlExporter()
        {
            HashMapping = new Dictionary<int, string>();
        }

        public void Export(IMetaValue value, string xmlFileName)
        {
            using (var xmlFileStream = new FileStream(xmlFileName, FileMode.Create))
            {
                Export(value, xmlFileStream);
            }
        }

        public void Export(IMetaValue value, Stream xmlFileStream)
        {
            var strctureValue = (MetaStructure)value;

            var writer = new XmlTextWriter(xmlFileStream, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement(GetNameForHash(strctureValue.info.StructureNameHash));
            WriteStructureContentXml(strctureValue, writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
        }

        private void WriteStructureContentXml(MetaStructure value, XmlTextWriter writer)
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

        private void WriteStructureElementContentXml(IMetaValue value, XmlTextWriter writer)
        {
            if (value is MetaArray)
            {
                var arrayValue = value as MetaArray;
                if (arrayValue.Entries != null)
                {
                    if (arrayValue.info.DataType == StructureEntryDataType.UnsignedByte)
                    {
                        WriteByteArrayContent(writer, arrayValue);
                    }
                    else if (arrayValue.info.DataType == StructureEntryDataType.UnsignedShort)
                    {
                        WriteShortArrayContent(writer, arrayValue);
                    }
                    else if (arrayValue.info.DataType == StructureEntryDataType.UnsignedInt)
                    {
                        WriteIntArrayContent(writer, arrayValue);
                    }
                    else if (arrayValue.info.DataType == StructureEntryDataType.Float)
                    {
                        WriteFloatArrayContent(writer, arrayValue);
                    }
                    else if (arrayValue.info.DataType == StructureEntryDataType.Float_XYZ)
                    {
                        WriteFloatVectorArrayContent(writer, arrayValue);
                    }
                    else if (arrayValue.info.DataType == StructureEntryDataType.Hash)
                    {
                        WriteHashArrayContent(writer, arrayValue);
                    }
                    else
                    {
                        foreach (var k in arrayValue.Entries)
                        {
                            writer.WriteStartElement("Item");
                            if (k is MetaStructure)
                            {
                                WriteStructureContentXml(k as MetaStructure, writer);
                            }
                            else
                            {
                                WriteStructureElementContentXml(k, writer);
                            }
                            writer.WriteEndElement();
                        }
                    }
                }
            }
            if (value is MetaBoolean)
            {
                var booleanValue = value as MetaBoolean;
                WriteBooleanContent(writer, booleanValue);
            }
            if (value is MetaByte_A)
            {
                var byteValue = value as MetaByte_A;
                WriteSignedByteContent(writer, byteValue);
            }
            if (value is MetaByte_B)
            {
                var byteValue = value as MetaByte_B;
                WriteUnsignedByteContent(writer, byteValue);
            }
            if (value is MetaInt16_A)
            {
                var shortValue = value as MetaInt16_A;
                WriteSignedShortContent(writer, shortValue);
            }
            if (value is MetaInt16_B)
            {
                var shortValue = value as MetaInt16_B;
                WriteUnsignedShortContent(writer, shortValue);
            }
            if (value is MetaInt32_A)
            {
                var intValue = value as MetaInt32_A;
                WriteSignedIntContent(writer, intValue);
            }
            if (value is MetaInt32_B)
            {
                var intValue = value as MetaInt32_B;
                WriteUnsignedIntContent(writer, intValue);
            }
            if (value is MetaFloat)
            {
                var floatValue = value as MetaFloat;
                WriteFloatContent(writer, floatValue);
            }
            if (value is MetaFloat4_XYZ)
            {
                var floatVectorValue = value as MetaFloat4_XYZ;
                WriteFloatXYZContent(writer, floatVectorValue);
            }
            if (value is MetaFloat4_XYZW)
            {
                var floatVectorValue = value as MetaFloat4_XYZW;
                WriteFloatXYZWContent(writer, floatVectorValue);
            }
            if (value is MetaByte_Enum)
            {
                WriteByteEnumContent(writer, (MetaByte_Enum)value);
            }
            if (value is MetaInt32_Enum1)
            {
                WriteIntEnumContent(writer, (MetaInt32_Enum1)value);
            }
            if (value is MetaInt16_Enum)
            {
                WriteShortFlagsContent(writer, (MetaInt16_Enum)value);
            }
            if (value is MetaInt32_Enum2)
            {
                WriteIntFlags1Content(writer, (MetaInt32_Enum2)value);
            }
            if (value is MetaInt32_Enum3)
            {
                WriteIntFlags2Content(writer, (MetaInt32_Enum3)value);
            }





            if (value is MetaArrayOfChars)
            {
                var stringValue = value as MetaArrayOfChars;
                writer.WriteString(stringValue.Value);
            }
            if (value is MetaCharPointer)
            {
                var stringValue = value as MetaCharPointer;
                writer.WriteString(stringValue.Value);
            }

            if (value is MetaGeneric)
            {
                var genericValue = value as MetaGeneric;
                var val = (MetaStructure)genericValue.Value;
                if (val != null)
                {
                    var vbstrdata = val;
                    writer.WriteAttributeString("type", GetNameForHash(vbstrdata.info.StructureNameHash));
                    WriteStructureContentXml(vbstrdata, writer);
                }
                else
                {
                    writer.WriteAttributeString("type", "NULL");

                }

            }

            if (value is MetaArrayOfBytes)
            {
                var intValue = value as MetaArrayOfBytes;
                var sb = new StringBuilder();
                for (int i = 0; i < intValue.Value.Length; i++)
                {
                    sb.Append(intValue.Value[i].ToString());
                    if (i != intValue.Value.Length - 1)
                        sb.Append(" ");
                }
                writer.WriteString(sb.ToString());
            }

            if (value is MetaInt32_Hash)
            {
                var intValue = value as MetaInt32_Hash;
                if (intValue.Value != 0)
                {
                    writer.WriteString(GetNameForHash(intValue.Value));
                }
            }

            if (value is MetaDataBlockPointer)
            {
                var longValue = value as MetaDataBlockPointer;
                if (longValue.Data != null)
                {
                    writer.WriteString(ByteArrayToString(longValue.Data));
                }
            }

            if (value is MetaStructure)
            {
                var structureValue = value as MetaStructure;
                WriteStructureContentXml(structureValue, writer);
            }
        }

        private void WriteBooleanContent(XmlTextWriter writer, MetaBoolean booleanValue)
        {
            writer.WriteAttributeString("value", booleanValue.Value ? "true" : "false");
        }

        private void WriteSignedByteContent(XmlTextWriter writer, MetaByte_A byteValue)
        {
            writer.WriteAttributeString("value", unchecked((sbyte)byteValue.Value).ToString());
        }

        private void WriteUnsignedByteContent(XmlTextWriter writer, MetaByte_B byteValue)
        {
            writer.WriteAttributeString("value", byteValue.Value.ToString());
        }

        private void WriteSignedShortContent(XmlTextWriter writer, MetaInt16_A shortValue)
        {
            writer.WriteAttributeString("value", shortValue.Value.ToString());
        }

        private void WriteUnsignedShortContent(XmlTextWriter writer, MetaInt16_B shortValue)
        {
            writer.WriteAttributeString("value", shortValue.Value.ToString());
        }

        private void WriteSignedIntContent(XmlTextWriter writer, MetaInt32_A intValue)
        {
            writer.WriteAttributeString("value", intValue.Value.ToString());
        }

        private void WriteUnsignedIntContent(XmlTextWriter writer, MetaInt32_B intValue)
        {
            writer.WriteAttributeString("value", intValue.Value.ToString());
        }

        private void WriteFloatContent(XmlTextWriter writer, MetaFloat floatValue)
        {
            var s1 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", floatValue.Value);
            writer.WriteAttributeString("value", s1);
        }

        private void WriteFloatXYZContent(XmlTextWriter writer, MetaFloat4_XYZ floatVectorValue)
        {
            var s1 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", floatVectorValue.X);
            var s2 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", floatVectorValue.Y);
            var s3 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", floatVectorValue.Z);
            writer.WriteAttributeString("x", s1);
            writer.WriteAttributeString("y", s2);
            writer.WriteAttributeString("z", s3);
        }

        private void WriteFloatXYZWContent(XmlTextWriter writer, MetaFloat4_XYZW floatVectorValue)
        {
            var s1 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", floatVectorValue.X);
            var s2 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", floatVectorValue.Y);
            var s3 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", floatVectorValue.Z);
            var s4 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", floatVectorValue.W);
            writer.WriteAttributeString("x", s1);
            writer.WriteAttributeString("y", s2);
            writer.WriteAttributeString("z", s3);
            writer.WriteAttributeString("w", s4);
        }

        private void WriteByteEnumContent(XmlTextWriter writer, MetaByte_Enum byteValue)
        {
            var thehash = (int)0;
            foreach (var enty in byteValue.info.Entries)
                if (enty.EntryValue == byteValue.Value)
                    thehash = enty.EntryNameHash;
            writer.WriteString(GetEnumNameForHash(thehash));
        }

        private void WriteIntEnumContent(XmlTextWriter writer, MetaInt32_Enum1 intValue)
        {
            if (intValue.Value != -1)
            {
                var thehash = (int)0;
                foreach (var enty in intValue.info.Entries)
                    if (enty.EntryValue == intValue.Value)
                        thehash = enty.EntryNameHash;
                writer.WriteString(GetEnumNameForHash(thehash));
            }
            else
            {
                writer.WriteString("enum_NONE");
            }
        }

        private void WriteShortFlagsContent(XmlTextWriter writer, MetaInt16_Enum shortValue)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 16; i++)
            {
                if ((shortValue.Value & (1 << i)) != 0)
                {
                    foreach (var xy in shortValue.info.Entries)
                    {
                        if (xy.EntryValue == i)
                        {
                            sb.Append(" ");
                            sb.Append(GetFlagNameForHash(xy.EntryNameHash));
                        }
                    }
                }
            }
            writer.WriteString(sb.ToString().Trim());
        }

        private void WriteIntFlags1Content(XmlTextWriter writer, MetaInt32_Enum2 intValue)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 32; i++)
            {
                if ((intValue.Value & (1 << i)) != 0)
                {
                    foreach (var xy in intValue.info.Entries)
                    {
                        if (xy.EntryValue == i)
                        {
                            sb.Append(" ");
                            sb.Append(GetFlagNameForHash(xy.EntryNameHash));
                        }
                    }
                }
            }
            writer.WriteString(sb.ToString().Trim());
        }

        private void WriteIntFlags2Content(XmlTextWriter writer, MetaInt32_Enum3 intValue)
        {
            if (intValue.Value != 0)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 32; i++)
                {
                    if ((intValue.Value & (1 << i)) != 0)
                    {

                        if (intValue.info != null)
                        {
                            foreach (var xy in intValue.info.Entries)
                            {
                                if (xy.EntryValue == i)
                                {
                                    sb.Append(" ");
                                    sb.Append(GetFlagNameForHash(xy.EntryNameHash));
                                }
                            }
                        }
                        else
                        {
                            sb.Append(" flag_index_");
                            sb.Append(i.ToString());
                        }
                    }
                }
                writer.WriteString(sb.ToString().Trim());
            }
        }

        private void WriteByteArrayContent(XmlTextWriter writer, MetaArray arrayValue)
        {
            writer.WriteAttributeString("content", "char_array");

            StringBuilder b = new StringBuilder();
            foreach (var k in arrayValue.Entries)
            {
                b.AppendLine(((MetaByte_B)k).Value.ToString());
            }
            writer.WriteString(b.ToString());
        }

        private void WriteShortArrayContent(XmlTextWriter writer, MetaArray arrayValue)
        {
            writer.WriteAttributeString("content", "short_array");

            StringBuilder b = new StringBuilder();
            foreach (var k in arrayValue.Entries)
            {
                b.AppendLine(((MetaInt16_B)k).Value.ToString());
            }
            writer.WriteString(b.ToString());
        }

        private void WriteIntArrayContent(XmlTextWriter writer, MetaArray arrayValue)
        {
            writer.WriteAttributeString("content", "int_array");

            StringBuilder b = new StringBuilder();
            foreach (var k in arrayValue.Entries)
            {
                b.AppendLine(((MetaInt32_B)k).Value.ToString());
            }
            writer.WriteString(b.ToString());
        }

        private void WriteFloatArrayContent(XmlTextWriter writer, MetaArray arrayValue)
        {
            writer.WriteAttributeString("content", "float_array");

            StringBuilder b = new StringBuilder();
            foreach (var k in arrayValue.Entries)
            {
                var s = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", ((MetaFloat)k).Value);
                b.AppendLine(s);
            }
            writer.WriteString(b.ToString());
        }

        private void WriteFloatVectorArrayContent(XmlTextWriter writer, MetaArray arrayValue)
        {
            writer.WriteAttributeString("content", "vector3_array");

            StringBuilder b = new StringBuilder();
            foreach (var k in arrayValue.Entries)
            {
                var s1 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", ((MetaFloat4_XYZ)k).X);
                var s2 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", ((MetaFloat4_XYZ)k).Y);
                var s3 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", ((MetaFloat4_XYZ)k).Z);
                b.AppendLine(s1 + " " + s2 + " " + s3);
            }
            writer.WriteString(b.ToString());
        }

        private void WriteHashArrayContent(XmlTextWriter writer, MetaArray arrayValue)
        {
            StringBuilder b = new StringBuilder();
            foreach (var k in arrayValue.Entries)
            {
                writer.WriteStartElement("Item");
                var ii = ((MetaInt32_Hash)k).Value;
                if (ii != 0)
                {
                    var ss = GetNameForHash(ii);
                    writer.WriteString(ss);
                }
                writer.WriteEndElement();
            }
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
