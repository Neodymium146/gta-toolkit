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

using RageLib.GTA5.ResourceWrappers.PC.Meta.Descriptions;
using RageLib.GTA5.ResourceWrappers.PC.Meta.Types;
using RageLib.Hash;
using RageLib.Resources.Common;
using RageLib.Resources.GTA5.PC.Meta;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;

namespace RageLib.GTA5.ResourceWrappers.PC.Meta
{
    public class MetaXmlImporter
    {
        private MetaInformationXml xmlInfos;
        private ResourceSimpleArray<StructureInfo> strList;

        public MetaStructure Import(string xmlFileName)
        {
            using (var xmlFileStream = new FileStream(xmlFileName, FileMode.Open))
            {
                return Import(xmlFileStream);
            }
        }

        public MetaXmlImporter(MetaInformationXml xmlinfos)
        {
            this.xmlInfos = xmlinfos;
            MetaBuildStructureInfos(xmlinfos);
        }

        public MetaStructure Import(Stream xmlFileStream)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFileStream);
            var rootOfData = xmlDoc.LastChild;
            
            var rootInfo = FindAndCheckStructure(rootOfData);

            var res = ParseStructure(rootOfData, rootInfo);
            return res;
        }

        public MetaStructure ParseStructure(XmlNode node, MetaStructureXml info)
        {
            MetaStructure resultStructure = null;
            foreach (var x in strList)
                if (x.StructureKey == info.Key)
                    resultStructure = new MetaStructure(null, x);
            resultStructure.Values = new Dictionary<int, IMetaValue>();

            foreach (var xmlEntry in info.Entries)
            {
                XmlNode xmlNode = null;
                foreach (XmlNode x in node.ChildNodes)
                {
                    var hash = GetHashForName(x.Name);
                    if (hash == xmlEntry.NameHash)
                        xmlNode = x;
                }

                StructureEntryInfo entryInfo = null;
                foreach (var x in resultStructure.info.Entries)
                    if (x.EntryNameHash == xmlEntry.NameHash)
                        entryInfo = x;

                var type = (StructureEntryDataType)xmlEntry.Type;
                if (type == StructureEntryDataType.Array)
                {

                    var arrayType = (StructureEntryDataType)xmlEntry.ArrayType.Type;
                    if (arrayType == StructureEntryDataType.StructurePointer)
                    {
                        MetaArray arrayValue = ReadPointerArray(xmlNode);
                        arrayValue.info = resultStructure.info.Entries[entryInfo.ReferenceTypeIndex];
                        resultStructure.Values.Add(xmlEntry.NameHash, arrayValue);
                    }
                    if (arrayType == StructureEntryDataType.Structure)
                    {
                        MetaArray arryVal = ReadStructureArray(xmlNode, xmlEntry.ArrayType.TypeHash);
                        arryVal.info = resultStructure.info.Entries[entryInfo.ReferenceTypeIndex];
                        resultStructure.Values.Add(xmlEntry.NameHash, arryVal);
                    }
                    if (arrayType == StructureEntryDataType.UnsignedByte)
                    {
                        MetaArray arryVal = ReadByteArray(xmlNode);
                        arryVal.info = resultStructure.info.Entries[entryInfo.ReferenceTypeIndex];
                        resultStructure.Values.Add(xmlEntry.NameHash, arryVal);
                    }
                    if (arrayType == StructureEntryDataType.UnsignedShort)
                    {
                        MetaArray arryVal = ReadShortArray(xmlNode);
                        arryVal.info = resultStructure.info.Entries[entryInfo.ReferenceTypeIndex];
                        resultStructure.Values.Add(xmlEntry.NameHash, arryVal);
                    }
                    if (arrayType == StructureEntryDataType.UnsignedInt)
                    {
                        MetaArray arryVal = ReadIntArray(xmlNode);
                        arryVal.info = resultStructure.info.Entries[entryInfo.ReferenceTypeIndex];
                        resultStructure.Values.Add(xmlEntry.NameHash, arryVal);
                    }
                    if (arrayType == StructureEntryDataType.Float)
                    {
                        MetaArray arryVal = ReadFloatArray(xmlNode);
                        arryVal.info = resultStructure.info.Entries[entryInfo.ReferenceTypeIndex];
                        resultStructure.Values.Add(xmlEntry.NameHash, arryVal);
                    }
                    if (arrayType == StructureEntryDataType.Float_XYZ)
                    {
                        MetaArray arryVal = ReadFloatVectorArray(xmlNode);
                        arryVal.info = resultStructure.info.Entries[entryInfo.ReferenceTypeIndex];
                        resultStructure.Values.Add(xmlEntry.NameHash, arryVal);
                    }
                    if (arrayType == StructureEntryDataType.Hash)
                    {
                        MetaArray arryVal = ReadHashArray(xmlNode);
                        arryVal.info = resultStructure.info.Entries[entryInfo.ReferenceTypeIndex];
                        resultStructure.Values.Add(xmlEntry.NameHash, arryVal);
                    }



                }


                if (type == StructureEntryDataType.Boolean)
                {
                    resultStructure.Values.Add(xmlEntry.NameHash, ReadBoolean(xmlNode));
                }
                if (type == StructureEntryDataType.SignedByte)
                {
                    resultStructure.Values.Add(xmlEntry.NameHash, ReadSignedByte(xmlNode));
                }
                if (type == StructureEntryDataType.UnsignedByte)
                {
                    resultStructure.Values.Add(xmlEntry.NameHash, ReadUnsignedByte(xmlNode));
                }
                if (type == StructureEntryDataType.SignedShort)
                {
                    resultStructure.Values.Add(xmlEntry.NameHash, ReadSignedShort(xmlNode));
                }
                if (type == StructureEntryDataType.UnsignedShort)
                {
                    resultStructure.Values.Add(xmlEntry.NameHash, ReadUnsignedShort(xmlNode));
                }
                if (type == StructureEntryDataType.SignedInt)
                {
                    resultStructure.Values.Add(xmlEntry.NameHash, ReadSignedInt(xmlNode));
                }
                if (type == StructureEntryDataType.UnsignedInt)
                {
                    resultStructure.Values.Add(xmlEntry.NameHash, ReadUnsignedInt(xmlNode));
                }
                if (type == StructureEntryDataType.Float)
                {
                    resultStructure.Values.Add(xmlEntry.NameHash, ReadFloat(xmlNode));
                }
                if (type == StructureEntryDataType.Float_XYZ)
                {
                    resultStructure.Values.Add(xmlEntry.NameHash, ReadFloatXYZ(xmlNode));
                }
                if (type == StructureEntryDataType.Float_XYZW)
                {
                    resultStructure.Values.Add(xmlEntry.NameHash, ReadFloatXYZW(xmlNode));
                }
                if (type == StructureEntryDataType.ByteEnum)
                {
                    resultStructure.Values.Add(xmlEntry.NameHash, ReadByteEnum(xmlNode, entryInfo.ReferenceKey));
                }
                if (type == StructureEntryDataType.IntEnum)
                {
                    resultStructure.Values.Add(xmlEntry.NameHash, ReadIntEnum(xmlNode, entryInfo.ReferenceKey));
                }
                if (type == StructureEntryDataType.ShortFlags)
                {
                    resultStructure.Values.Add(xmlEntry.NameHash, ReadShortFlags(xmlNode, entryInfo.ReferenceKey));
                }
                if (type == StructureEntryDataType.IntFlags1)
                {
                    resultStructure.Values.Add(xmlEntry.NameHash, ReadIntFlags1(xmlNode, entryInfo.ReferenceKey));
                }
                if (type == StructureEntryDataType.IntFlags2)
                {
                    resultStructure.Values.Add(xmlEntry.NameHash, ReadIntFlags2(xmlNode, entryInfo.ReferenceKey));
                }






                if (type == StructureEntryDataType.ArrayOfBytes)
                {
                    var byteArrayValue = new MetaArrayOfBytes();
                    byteArrayValue.Value = ByteFromString(xmlNode.InnerText);
                    resultStructure.Values.Add(xmlEntry.NameHash, byteArrayValue);
                }
                if (type == StructureEntryDataType.ArrayOfChars)
                {
                    var charArrayValue = new MetaArrayOfChars(entryInfo);
                    charArrayValue.Value = xmlNode.InnerText;
                    resultStructure.Values.Add(xmlEntry.NameHash, charArrayValue);
                }
                if (type == StructureEntryDataType.Hash)
                {
                    var hashValue = new MetaInt32_Hash();
                    if (xmlNode.InnerText.Trim().Length > 0)
                    {
                        hashValue.Value = GetHashForName(xmlNode.InnerText);
                    }
                    resultStructure.Values.Add(xmlEntry.NameHash, hashValue);
                }
                if (type == StructureEntryDataType.CharPointer)
                {
                    var charPointerValue = new MetaCharPointer();
                    charPointerValue.Value = xmlNode.InnerText;
                    if (charPointerValue.Value.Equals(""))
                        charPointerValue.Value = null;
                    resultStructure.Values.Add(xmlEntry.NameHash, charPointerValue);
                }
                if (type == StructureEntryDataType.DataBlockPointer)
                {
                    var dataBlockValue = new MetaDataBlockPointer(entryInfo);
                    dataBlockValue.Data = ByteFromString(xmlNode.InnerText);
                    if (dataBlockValue.Data.Length == 0)
                        dataBlockValue.Data = null;
                    resultStructure.Values.Add(xmlEntry.NameHash, dataBlockValue);
                }
                if (type == StructureEntryDataType.Structure)
                {
                    var xmlInfo = FindAndCheckStructure(xmlEntry.TypeHash, xmlNode);
                    var structureValue = ParseStructure(xmlNode, xmlInfo);
                    resultStructure.Values.Add(xmlEntry.NameHash, structureValue);
                }
            }

            return resultStructure;
        }








        private MetaBoolean ReadBoolean(XmlNode node)
        {
            var booleanValue = new MetaBoolean();
            booleanValue.Value = bool.Parse(node.Attributes["value"].Value);
            return booleanValue;
        }

        private MetaByte_A ReadSignedByte(XmlNode node)
        {
            var byteValue = new MetaByte_A();
            byteValue.Value = sbyte.Parse(node.Attributes["value"].Value);
            return byteValue;
        }

        private MetaByte_B ReadUnsignedByte(XmlNode node)
        {
            var byteValue = new MetaByte_B();
            byteValue.Value = byte.Parse(node.Attributes["value"].Value);
            return byteValue;
        }

        private MetaInt16_A ReadSignedShort(XmlNode node)
        {
            var shortValue = new MetaInt16_A();
            shortValue.Value = short.Parse(node.Attributes["value"].Value);
            return shortValue;
        }

        private MetaInt16_B ReadUnsignedShort(XmlNode node)
        {
            var shortValue = new MetaInt16_B();
            shortValue.Value = ushort.Parse(node.Attributes["value"].Value);
            return shortValue;
        }

        private MetaInt32_A ReadSignedInt(XmlNode node)
        {
            var intValue = new MetaInt32_A();
            intValue.Value = int.Parse(node.Attributes["value"].Value);
            return intValue;
        }

        private MetaInt32_B ReadUnsignedInt(XmlNode node)
        {
            var intValue = new MetaInt32_B();
            intValue.Value = uint.Parse(node.Attributes["value"].Value);
            return intValue;
        }

        private MetaFloat ReadFloat(XmlNode node)
        {
            var floatValue = new MetaFloat();
            floatValue.Value = float.Parse(node.Attributes["value"].Value);
            return floatValue;
        }

        private MetaFloat4_XYZ ReadFloatXYZ(XmlNode node)
        {
            var floatVectorValue = new MetaFloat4_XYZ();
            floatVectorValue.X = float.Parse(node.Attributes["x"].Value);
            floatVectorValue.Y = float.Parse(node.Attributes["y"].Value);
            floatVectorValue.Z = float.Parse(node.Attributes["z"].Value);
            return floatVectorValue;
        }

        private MetaFloat4_XYZW ReadFloatXYZW(XmlNode node)
        {
            var floatVectorValue = new MetaFloat4_XYZW();
            floatVectorValue.X = float.Parse(node.Attributes["x"].Value);
            floatVectorValue.Y = float.Parse(node.Attributes["y"].Value);
            floatVectorValue.Z = float.Parse(node.Attributes["z"].Value);
            floatVectorValue.W = float.Parse(node.Attributes["w"].Value);
            return floatVectorValue;
        }
        
        private MetaByte_Enum ReadByteEnum(XmlNode node, int enumNameHash)
        {
            var byteEnum = new MetaByte_Enum();
            var enumKey = GetHashForEnumName(node.InnerText);
            var enumInfo = (MetaEnumXml)null;
            foreach (var x in xmlInfos.Enums)
            {
                if (x.NameHash == enumNameHash)
                    enumInfo = x;
            }
            foreach (var x in enumInfo.Entries)
            {
                if (x.NameHash == enumKey)
                    byteEnum.Value = (byte)x.Value;
            }
            return byteEnum;
        }

        private MetaInt32_Enum1 ReadIntEnum(XmlNode node, int enumNameHash)
        {
            var intEnum = new MetaInt32_Enum1();
            var it = node.InnerText.Trim();
            if (it.Equals("enum_NONE"))
            {
                intEnum.Value = -1;
            }
            else
            {
                var enumKey = GetHashForEnumName(it);
                var enumInfo = (MetaEnumXml)null;
                foreach (var x in xmlInfos.Enums)
                {
                    if (x.NameHash == enumNameHash)
                        enumInfo = x;
                }
                foreach (var x in enumInfo.Entries)
                {
                    if (x.NameHash == enumKey)
                        intEnum.Value = x.Value;
                }
            }
            return intEnum;
        }

        private MetaInt16_Enum ReadShortFlags(XmlNode node, int enumNameHash)
        {
            var shortFlags = new MetaInt16_Enum();
            var enumInfo = (MetaEnumXml)null;
            foreach (var x in xmlInfos.Enums)
            {
                if (x.NameHash == enumNameHash)
                    enumInfo = x;
            }

            var keyStrings = node.InnerText.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var x in keyStrings)
            {
                var enumKey = GetHashForFlagName(x);
                foreach (var p in enumInfo.Entries)
                {
                    if (p.NameHash == enumKey)
                        shortFlags.Value += (ushort)(1 << p.Value);
                }
            }

            return shortFlags;
        }

        private MetaInt32_Enum2 ReadIntFlags1(XmlNode node, int enumNameHash)
        {
            var intFlags = new MetaInt32_Enum2();

            var enumInfo = (MetaEnumXml)null;
            foreach (var x in xmlInfos.Enums)
            {
                if (x.NameHash == enumNameHash)
                    enumInfo = x;
            }

            var keyStrings = node.InnerText.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var x in keyStrings)
            {
                var enumKey = GetHashForFlagName(x);
                foreach (var p in enumInfo.Entries)
                {
                    if (p.NameHash == enumKey)
                        intFlags.Value += (uint)(1 << p.Value);
                }
            }

            return intFlags;
        }

        private MetaInt32_Enum3 ReadIntFlags2(XmlNode node, int enumNameHash)
        {
            var intFlags = new MetaInt32_Enum3();

            if (enumNameHash == 0)
            {
                var keyStrings = node.InnerText.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var x in keyStrings)
                {
                    var enumIdx = int.Parse(x.Substring(11));
                    intFlags.Value += (uint)(1 << enumIdx);
                }
            }
            else
            {
                var enumInfo = (MetaEnumXml)null;
                foreach (var x in xmlInfos.Enums)
                {
                    if (x.NameHash == enumNameHash)
                        enumInfo = x;
                }
                var keyStrings = node.InnerText.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var x in keyStrings)
                {
                    var enumKey = GetHashForFlagName(x);
                    foreach (var y in enumInfo.Entries)
                    {
                        if (y.NameHash == enumKey)
                            intFlags.Value += (uint)(1 << y.Value);
                    }
                }
            }

            return intFlags;
        }





        private MetaArray ReadPointerArray(XmlNode node)
        {
            var arrayValue = new MetaArray();
            if (node.ChildNodes.Count > 0)
            {
                arrayValue.Entries = new List<IMetaValue>();
                foreach (XmlNode xmlPointerValue in node.ChildNodes)
                {
                    MetaGeneric gen = new MetaGeneric();
                    var theType = xmlPointerValue.Attributes["type"].Value;
                    if (!theType.Equals("NULL"))
                    {
                        var theHash = GetHashForName(theType);

                        var xnd = FindAndCheckStructure(theHash, xmlPointerValue);
                        var yy = ParseStructure(xmlPointerValue, xnd);
                        gen.Value = yy;
                    }
                    arrayValue.Entries.Add(gen);
                }
            }

            return arrayValue;
        }

        private MetaArray ReadStructureArray(XmlNode node, int structureNameHash)
        {
            var arrayValue = new MetaArray();
            var arrayType = structureNameHash;
            if (node.ChildNodes.Count > 0)
            {
                arrayValue.Entries = new List<IMetaValue>();
                foreach (XmlNode arrent in node.ChildNodes)
                {
                    var xnd = FindAndCheckStructure(arrayType, arrent);
                    var yy = ParseStructure(arrent, xnd);
                    arrayValue.Entries.Add(yy);
                }
            }
            return arrayValue;
        }

        private MetaArray ReadByteArray(XmlNode node)
        {
            var arrayValue = new MetaArray();
            var v = node.InnerText.Trim();
            if (!string.IsNullOrEmpty(v))
            {
                arrayValue.Entries = new List<IMetaValue>();
                string[] k = v.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var kkk in k)
                {
                    arrayValue.Entries.Add(new MetaByte_B(byte.Parse(kkk)));
                }
            }
            return arrayValue;
        }

        private MetaArray ReadShortArray(XmlNode node)
        {
            var arrayValue = new MetaArray();
            var v = node.InnerText.Trim();
            if (!string.IsNullOrEmpty(v))
            {
                arrayValue.Entries = new List<Types.IMetaValue>();

                string[] k = v.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var kkk in k)
                {
                    arrayValue.Entries.Add(new MetaInt16_B(ushort.Parse(kkk)));
                }
            }

            return arrayValue;
        }

        private MetaArray ReadIntArray(XmlNode node)
        {
            var arrayValue = new MetaArray();
            var v = node.InnerText.Trim();
            if (!string.IsNullOrEmpty(v))
            {
                arrayValue.Entries = new List<Types.IMetaValue>();

                string[] k = v.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var kkk in k)
                {
                    arrayValue.Entries.Add(new MetaInt32_B(uint.Parse(kkk)));
                }
            }

            return arrayValue;
        }

        private MetaArray ReadFloatArray(XmlNode node)
        {
            var arrayValue = new MetaArray();
            var v = node.InnerText.Trim();
            if (!string.IsNullOrEmpty(v))
            {
                arrayValue.Entries = new List<Types.IMetaValue>();

                string[] k = v.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var kkk in k)
                {
                    arrayValue.Entries.Add(new MetaFloat(float.Parse(kkk)));
                }
            }

            return arrayValue;
        }

        private MetaArray ReadFloatVectorArray(XmlNode node)
        {
            var arrayValue = new MetaArray();
            var v = node.InnerText.Trim();
            if (!string.IsNullOrEmpty(v))
            {
                arrayValue.Entries = new List<Types.IMetaValue>();

                string[] k = v.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                int iii = 0;
                while (iii < k.Length)
                {
                    arrayValue.Entries.Add(new MetaFloat4_XYZ(float.Parse(k[iii++]), float.Parse(k[iii++]), float.Parse(k[iii++])));
                }
            }

            return arrayValue;
        }

        private MetaArray ReadHashArray(XmlNode node)
        {
            var arrayValue = new MetaArray();
            if (node.ChildNodes.Count > 0)
            {
                arrayValue.Entries = new List<Types.IMetaValue>();
                foreach (XmlNode kkk in node.ChildNodes)
                {
                    var p = kkk.InnerText.Trim();
                    if (!string.IsNullOrEmpty(p))
                    {


                        arrayValue.Entries.Add(new MetaInt32_Hash(GetHashForName(p)));
                    }
                    else
                    {
                        arrayValue.Entries.Add(new MetaInt32_Hash(0));
                    }
                }
            }

            return arrayValue;
        }







        public int GetHashForEnumName(string hashName)
        {
            if (hashName.StartsWith("enum_hash_", StringComparison.OrdinalIgnoreCase))
            {
                var x = hashName.Substring(10);
                int intAgain = int.Parse(x, NumberStyles.HexNumber);
                return intAgain;
            }
            else
            {
                return (int)Jenkins.Hash(hashName);
            }
        }

        public int GetHashForFlagName(string hashName)
        {
            if (hashName.StartsWith("flag_hash_", StringComparison.OrdinalIgnoreCase))
            {
                var x = hashName.Substring(10);
                int intAgain = int.Parse(x, NumberStyles.HexNumber);
                return intAgain;
            }
            else
            {
                return (int)Jenkins.Hash(hashName);
            }
        }

        public byte[] ByteFromString(string str)
        {
            string[] ss = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            byte[] res = new byte[ss.Length];
            for (int i = 0; i < ss.Length; i++)
            {
                res[i] = byte.Parse(ss[i]);
            }
            return res;
        }

        public int GetHashForName(string hashName)
        {
            if (hashName.StartsWith("hash_", StringComparison.OrdinalIgnoreCase))
            {
                var x = hashName.Substring(5);
                int intAgain = int.Parse(x, NumberStyles.HexNumber);
                return intAgain;
            }
            else
            {
                return (int)Jenkins.Hash(hashName);
            }
        }

        private void MetaBuildStructureInfos(MetaInformationXml xmlInfo)
        {
            strList = new ResourceSimpleArray<StructureInfo>();
            foreach (var xmlStructureInfo in xmlInfo.Structures)
            {
                var structureInfo = new StructureInfo();
                structureInfo.StructureNameHash = xmlStructureInfo.NameHash;
                structureInfo.StructureKey = xmlStructureInfo.Key;
                structureInfo.Unknown_8h = xmlStructureInfo.Unknown;
                structureInfo.StructureLength = xmlStructureInfo.Length;
                structureInfo.Entries = new ResourceSimpleArray<StructureEntryInfo>();
                foreach (var xmlStructureEntryInfo in xmlStructureInfo.Entries)
                {
                    var xmlArrayTypeStack = new Stack<MetaStructureArrayTypeXml>();
                    var xmlArrayType = xmlStructureEntryInfo.ArrayType;
                    while (xmlArrayType != null)
                    {
                        xmlArrayTypeStack.Push(xmlArrayType);
                        xmlArrayType = xmlArrayType.ArrayType;
                    }

                    while (xmlArrayTypeStack.Count > 0)
                    {
                        xmlArrayType = xmlArrayTypeStack.Pop();
                        var arrayStructureEntryInfo = new StructureEntryInfo();
                        arrayStructureEntryInfo.EntryNameHash = 0x100;
                        arrayStructureEntryInfo.DataOffset = 0;
                        arrayStructureEntryInfo.DataType = (StructureEntryDataType)xmlArrayType.Type;
                        arrayStructureEntryInfo.Unknown_9h = 0;
                        if (arrayStructureEntryInfo.DataType == StructureEntryDataType.Array)
                        {
                            arrayStructureEntryInfo.ReferenceTypeIndex = (short)(structureInfo.Entries.Count - 1);
                        }
                        else
                        {
                            arrayStructureEntryInfo.ReferenceTypeIndex = 0;
                        }
                        arrayStructureEntryInfo.ReferenceKey = xmlArrayType.TypeHash;
                        structureInfo.Entries.Add(arrayStructureEntryInfo);
                    }

                    var structureEntryInfo = new StructureEntryInfo();
                    structureEntryInfo.EntryNameHash = xmlStructureEntryInfo.NameHash;
                    structureEntryInfo.DataOffset = xmlStructureEntryInfo.Offset;
                    structureEntryInfo.DataType = (StructureEntryDataType)xmlStructureEntryInfo.Type;
                    structureEntryInfo.Unknown_9h = (byte)xmlStructureEntryInfo.Unknown;
                    if (structureEntryInfo.DataType == StructureEntryDataType.Array)
                    {
                        structureEntryInfo.ReferenceTypeIndex = (short)(structureInfo.Entries.Count - 1);
                    }
                    else
                    {
                        structureEntryInfo.ReferenceTypeIndex = 0;
                    }
                    structureEntryInfo.ReferenceKey = xmlStructureEntryInfo.TypeHash;

                    structureInfo.Entries.Add(structureEntryInfo);
                }
                strList.Add(structureInfo);
            }
        }

        public MetaStructureXml FindAndCheckStructure(XmlNode node)
        {
            int h = GetHashForName(node.Name);
            foreach(var x in xmlInfos.Structures)
            {
                if (x.NameHash == h)
                {
                    if (x.Entries.Count != node.ChildNodes.Count)
                        continue;

                    bool everythinOk = true;
                    foreach (var zz in x.Entries)
                    {
                        bool fnd = false;
                        foreach (XmlNode qq in node.ChildNodes)
                        {
                            var qqnamehash = GetHashForName(qq.Name);
                            if (qqnamehash == zz.NameHash)
                                fnd = true;
                        }
                        if (!fnd)
                            everythinOk = false;
                    }
                    if (!everythinOk)
                        continue;


                    return x;
                }
            }

            return null;
        }

        public MetaStructureXml FindAndCheckStructure(int h, XmlNode node)
        {
            foreach (var x in xmlInfos.Structures)
            {
                if (x.NameHash == h)
                {
                    if (x.Entries.Count != node.ChildNodes.Count)
                        continue;

                    bool everythinOk = true;
                    foreach (var zz in x.Entries)
                    {
                        bool fnd = false;
                        foreach (XmlNode qq in node.ChildNodes)
                        {
                            var qqnamehash = GetHashForName(qq.Name);
                            if (qqnamehash == zz.NameHash)
                                fnd = true;
                        }
                        if (!fnd)
                            everythinOk = false;
                    }
                    if (!everythinOk)
                        continue;


                    return x;
                }
            }

            return null;
        }

    }
}
