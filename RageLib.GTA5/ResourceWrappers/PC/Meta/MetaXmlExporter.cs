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
using RageLib.GTA5.ResourceWrappers.PC.Meta.Types;
using RageLib.Hash;
using RageLib.Resources.Common;
using RageLib.Resources.GTA5.PC.Meta;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RageLib.GTA5.ResourceWrappers.PC.Meta
{
    public class MetaXmlExporter
    {
        public Dictionary<uint, string> HashMapping { get; set; }

        public void Export(IMetaValue value, string xmlFileName)
        {
            var strctureValue = (MetaStructure)value;

            var writer = new XmlTextWriter(xmlFileName, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement(GetNameForHash(strctureValue.info.StructureNameHash));
            WriteStructureContentXml(strctureValue, writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
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
                foreach (var k in arrayValue.Entries)
                {
                    writer.WriteStartElement("Item");
                    WriteStructureElementContentXml(k, writer);
                    writer.WriteEndElement();
                }
            }
            if (value is MetaBoolean)
            {
                var booleanValue = value as MetaBoolean;
                writer.WriteAttributeString("value", booleanValue.Value ? "true" : "false");
            }
            if (value is MetaByte_A)
            {
                var byteValue = value as MetaByte_A;
                writer.WriteAttributeString("value", byteValue.Value.ToString());
            }
            if (value is MetaByte_B)
            {
                var byteValue = value as MetaByte_B;
                writer.WriteAttributeString("value", byteValue.Value.ToString());
            }
            if (value is MetaByte_Enum)
            {
                var byteValue = value as MetaByte_Enum;
                writer.WriteAttributeString("value", byteValue.Value.ToString());
            }
            if (value is MetaChar64)
            {
                var stringValue = value as MetaChar64;
                writer.WriteString(stringValue.Value);
            }
            if (value is MetaCharPointer)
            {
                var stringValue = value as MetaCharPointer;
                writer.WriteString(stringValue.Value);
            }
            if (value is MetaFloat)
            {
                var floatValue = value as MetaFloat;
                writer.WriteAttributeString("value", floatValue.Value.ToString());
            }
            if (value is MetaFloat4_XYZ)
            {
                var floatVectorValue = value as MetaFloat4_XYZ;
                writer.WriteAttributeString("x", floatVectorValue.X.ToString());
                writer.WriteAttributeString("y", floatVectorValue.Y.ToString());
                writer.WriteAttributeString("z", floatVectorValue.Z.ToString());
            }
            if (value is MetaFloat4_XYZW)
            {
                var floatVectorValue = value as MetaFloat4_XYZW;
                writer.WriteAttributeString("x", floatVectorValue.X.ToString());
                writer.WriteAttributeString("y", floatVectorValue.Y.ToString());
                writer.WriteAttributeString("z", floatVectorValue.Z.ToString());
                writer.WriteAttributeString("w", floatVectorValue.W.ToString());
            }
            if (value is MetaGeneric)
            {
                var genericValue = value as MetaGeneric;
                var vbstrdata = (MetaStructure)genericValue.Value;
                writer.WriteAttributeString("type", GetNameForHash(vbstrdata.info.StructureNameHash));
                WriteStructureElementContentXml(vbstrdata, writer);
            }
            if (value is MetaInt16_A)
            {
                var shortValue = value as MetaInt16_A;
                writer.WriteAttributeString("value", shortValue.Value.ToString());
            }
            if (value is MetaInt16_B)
            {
                var shortValue = value as MetaInt16_B;
                writer.WriteAttributeString("value", shortValue.Value.ToString());
            }
            if (value is MetaInt16_Enum)
            {
                var shortValue = value as MetaInt16_Enum;
                writer.WriteAttributeString("value", shortValue.Value.ToString());
            }
            if (value is MetaInt24)
            {
                var intValue = value as MetaInt24;
                writer.WriteAttributeString("x1", intValue.X1.ToString());
                writer.WriteAttributeString("x2", intValue.X2.ToString());
                writer.WriteAttributeString("x3", intValue.X3.ToString());
            }
            if (value is MetaInt32_A)
            {
                var intValue = value as MetaInt32_A;
                writer.WriteAttributeString("value", intValue.Value.ToString());
            }
            if (value is MetaInt32_B)
            {
                var intValue = value as MetaInt32_B;
                writer.WriteAttributeString("value", intValue.Value.ToString());
            }
            if (value is MetaInt32_Enum1)
            {
                var intValue = value as MetaInt32_Enum1;
                writer.WriteAttributeString("value", intValue.Value.ToString());
            }
            if (value is MetaInt32_Enum2)
            {
                var intValue = value as MetaInt32_Enum2;
                writer.WriteAttributeString("value", intValue.Value.ToString());
            }
            if (value is MetaInt32_Enum3)
            {
                var intValue = value as MetaInt32_Enum3;
                writer.WriteAttributeString("value", intValue.Value.ToString());
            }
            if (value is MetaInt32_Hash)
            {
                var intValue = value as MetaInt32_Hash;
                writer.WriteAttributeString("value", GetNameForHash(intValue.Value));
            }
            if (value is MetaInt64)
            {
                var longValue = value as MetaInt64;
                writer.WriteAttributeString("value", longValue.Value.ToString());
            }
            if (value is MetaStructure)
            {
                var structureValue = value as MetaStructure;
                writer.WriteStartElement(GetNameForHash(structureValue.info.StructureNameHash));
                WriteStructureContentXml(structureValue, writer);
                writer.WriteEndElement();
            }
        }

        private string GetNameForHash(uint hash)
        {
            if (HashMapping.ContainsKey(hash))
            {
                var ss = HashMapping[hash];
                return ss;
            }
            return "0x" + hash.ToString("X8");
        }
    }
}
