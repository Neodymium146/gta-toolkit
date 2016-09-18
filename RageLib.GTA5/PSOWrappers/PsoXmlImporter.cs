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
using RageLib.GTA5.PSOWrappers.Xml;
using RageLib.Hash;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;

namespace RageLib.GTA5.PSOWrappers
{
    public class PsoXmlImporter
    {
        private PsoDefinitionXml xmlInfos;
        private List<Tuple<int,PsoStructureInfo>> strList;

        public PsoStructure Import(string xmlFileName)
        {
            using (var xmlFileStream = new FileStream(xmlFileName, FileMode.Open))
            {
                return Import(xmlFileStream);
            }
        }

        public PsoXmlImporter(PsoDefinitionXml xmlinfos)
        {
            this.xmlInfos = xmlinfos;
            MetaBuildStructureInfos(xmlinfos);
        }

        public PsoStructure Import(Stream xmlFileStream)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFileStream);
            var rootOfData = xmlDoc.LastChild;

            var rootInfo = FindAndCheckStructure(rootOfData);

            var res = ParseStructure(rootOfData, rootInfo);
            return res;
        }

        public PsoStructure ParseStructure(XmlNode node, PsoStructureXml info)
        {
            PsoStructure resultStructure = null;
            foreach (var x in strList)
                if (x.Item1 == info.NameHash)
                {
                    resultStructure = new PsoStructure();
                    resultStructure.psoSection = x.Item2;
                    resultStructure.psoEntryInfo = new PsoElementIndexInfo();
                    resultStructure.psoEntryInfo.NameHash = x.Item1;
                }
                   
            resultStructure.Values = new Dictionary<int, IPsoValue>();

            foreach (var xmlEntry in info.Entries)
            {
                XmlNode xmlNode = null;
                foreach (XmlNode x in node.ChildNodes)
                {
                    var hash = GetHashForName(x.Name);
                    if (hash == xmlEntry.NameHash)
                        xmlNode = x;
                }

                PsoStructureEntryInfo entryInfo = null;
                foreach (var x in resultStructure.psoSection.Entries)
                    if (x.EntryNameHash == xmlEntry.NameHash)
                        entryInfo = x;

                var type = (DataType)xmlEntry.Type;
                if (type == DataType.Array)
                {
                    var arrayType = (DataType)xmlEntry.ArrayType.Type;
                    if (arrayType == DataType.Structure)
                    {
                        PsoArray arrayValue = ReadStructureArray(xmlNode, xmlEntry.ArrayType.TypeHash);
                        arrayValue.psoSection = resultStructure.psoSection.Entries[entryInfo.ReferenceKey];
                        resultStructure.Values.Add(xmlEntry.NameHash, arrayValue);
                    }
                    else if (arrayType == DataType.INT_0Bh)
                    {
                        PsoArray arryVal = Read11Array(xmlNode);
                        arryVal.psoSection = resultStructure.psoSection.Entries[entryInfo.ReferenceKey];
                        resultStructure.Values.Add(xmlEntry.NameHash, arryVal);
                    }
                    else if (arrayType == DataType.SHORT_0Fh)
                    {
                        PsoArray arryVal = Read14Array(xmlNode);
                        arryVal.psoSection = resultStructure.psoSection.Entries[entryInfo.ReferenceKey];
                        resultStructure.Values.Add(xmlEntry.NameHash, arryVal);
                    }
                    else
                    {
                        throw new Exception("Unsupported array type.");
                    }
                }
                else if (type == DataType.INT_06h)
                {
                    resultStructure.Values.Add(xmlEntry.NameHash, ReadType6(xmlNode));
                }
                else if (type == DataType.INT_0Bh)
                {
                    resultStructure.Values.Add(xmlEntry.NameHash, ReadType11(xmlNode, xmlEntry.Unknown == 0));
                }
                else if (type == DataType.BYTE_ENUM_VALUE)
                {
                    resultStructure.Values.Add(xmlEntry.NameHash, ReadType14(xmlNode));
                }
                else if (type == DataType.SHORT_0Fh)
                {
                    resultStructure.Values.Add(xmlEntry.NameHash, ReadType15(xmlNode));
                }
                else if (type== DataType.Structure)
                {
                    var xmlInfo = FindAndCheckStructure(xmlEntry.TypeHash, xmlNode);
                    var structureValue = ParseStructure(xmlNode, xmlInfo);
                    resultStructure.Values.Add(xmlEntry.NameHash, structureValue);
                }
                else
                {
                    throw new Exception("Unsupported type.");
                }
            }

            return resultStructure;
        }








        
        private PsoType6 ReadType6(XmlNode node)
        {
            PsoType6 v = new Types.PsoType6();
            v.Value = long.Parse(node.Attributes["value"].Value);
            return v;
        }

        private PsoType11 ReadType11(XmlNode node, bool fullString)
        {
            if (fullString)
            {
                PsoType11 v = new PsoType11(64);
                v.Value = node.InnerText;
                return v;
            }
            else
            {
                PsoType11 v = new PsoType11(0);
                v.Value = null;
                v.ValueHash = GetHashForName(node.InnerText);
                return v;
            }
        }

        private PsoType14 ReadType14(XmlNode node)
        {
            PsoType14 v = new PsoType14();
           v.Value =  FromHex(node.InnerText);
            return v;            
        }

        private PsoType15 ReadType15(XmlNode node)
        {
            PsoType15 v = new PsoType15();
            v.Value = FromHex(node.InnerText);
            return v;
        }

     





       
        

        private PsoArray ReadStructureArray(XmlNode node, int structureNameHash)
        {
            var arrayValue = new PsoArray();
            var arrayType = structureNameHash;
            if (node.ChildNodes.Count > 0)
            {
                arrayValue.Entries = new List<IPsoValue>();
                foreach (XmlNode arrent in node.ChildNodes)
                {
                    var xnd = FindAndCheckStructure(arrayType, arrent);
                    var yy = ParseStructure(arrent, xnd);
                    arrayValue.Entries.Add(yy);
                }
            }
            return arrayValue;
        }

        private PsoArray Read11Array(XmlNode node)
        {
            var arrayValue = new PsoArray();
            if (node.ChildNodes.Count > 0)
            {
                arrayValue.Entries = new List<IPsoValue>();
                foreach (XmlNode arrent in node.ChildNodes)
                {
                    var y = new PsoType11(0);
                    y.Value = null;
                    y.ValueHash = GetHashForName(arrent.InnerText);
                    arrayValue.Entries.Add(y);
                }
            }
            return arrayValue;
        }

        private PsoArray Read14Array(XmlNode node)
        {
            var arrayValue = new PsoArray();
            if (node.ChildNodes.Count > 0)
            {
                arrayValue.Entries = new List<IPsoValue>();
                foreach (XmlNode arrent in node.ChildNodes)
                {
                    var y = new PsoType14();
                    y.Value = FromHex(arrent.Value);
                    arrayValue.Entries.Add(y);
                }
            }
            return arrayValue;
        }









        public int FromHex(string hashName)
        {
            var x = hashName.Substring(4);
            int intAgain = int.Parse(x, NumberStyles.HexNumber);
            return intAgain;
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

        private void MetaBuildStructureInfos(PsoDefinitionXml xmlInfo)
        {
            //meta.DefinitionSection.EntriesIdx = new List<PsoElementIndexInfo>();
            //meta.DefinitionSection.Entries = new List<PsoElementInfo>();
            strList = new List<Tuple<int, PsoStructureInfo>>();

            foreach (var xmlStructureInfo in xmlInfo.Structures)
            {
                var idxInfo = new PsoElementIndexInfo();
                idxInfo.Offset = 0;
                idxInfo.NameHash = xmlStructureInfo.NameHash;

                var structureInfo = new PsoStructureInfo();
                structureInfo.Type = 1;
                structureInfo.Unk = (byte)xmlStructureInfo.Unknown;
                structureInfo.StructureLength = xmlStructureInfo.Length;
                structureInfo.Entries = new List<PsoStructureEntryInfo>();
                foreach (var xmlStructureEntryInfo in xmlStructureInfo.Entries)
                {
                    var xmlArrayTypeStack = new Stack<PsoStructureEntryXml>();
                    var xmlArrayType = xmlStructureEntryInfo.ArrayType;
                    while (xmlArrayType != null)
                    {
                        xmlArrayTypeStack.Push(xmlArrayType);
                        xmlArrayType = xmlArrayType.ArrayType;
                    }

                    while (xmlArrayTypeStack.Count > 0)
                    {
                        xmlArrayType = xmlArrayTypeStack.Pop();
                        var arrayStructureEntryInfo = new PsoStructureEntryInfo();
                        arrayStructureEntryInfo.EntryNameHash = xmlArrayType.NameHash;
                        arrayStructureEntryInfo.Type = (DataType)xmlArrayType.Type;
                        arrayStructureEntryInfo.Unk_5h = (byte)xmlArrayType.Unknown;
                        arrayStructureEntryInfo.DataOffset = (short)xmlArrayType.Offset;
                        if (arrayStructureEntryInfo.Type == DataType.Array)
                        {
                            arrayStructureEntryInfo.ReferenceKey = (short)(structureInfo.Entries.Count - 1);
                        }
                        else
                        {
                            arrayStructureEntryInfo.ReferenceKey = 0;
                        }
                        arrayStructureEntryInfo.ReferenceKey = xmlArrayType.TypeHash;
                        structureInfo.Entries.Add(arrayStructureEntryInfo);
                    }

                    var structureEntryInfo = new PsoStructureEntryInfo();
                    structureEntryInfo.EntryNameHash = xmlStructureEntryInfo.NameHash;
                    structureEntryInfo.Type = (DataType)xmlStructureEntryInfo.Type;
                    structureEntryInfo.Unk_5h = (byte)xmlStructureEntryInfo.Unknown;
                    structureEntryInfo.DataOffset = (short)xmlStructureEntryInfo.Offset;
                    if (structureEntryInfo.Type == DataType.Array)
                    {
                        structureEntryInfo.ReferenceKey = (short)(structureInfo.Entries.Count - 1);
                    }
                    else
                    {
                        structureEntryInfo.ReferenceKey = 0;
                    }
                    structureEntryInfo.ReferenceKey = xmlStructureEntryInfo.TypeHash;

                    structureInfo.Entries.Add(structureEntryInfo);
                }

                strList.Add(new Tuple<int, PsoStructureInfo>(idxInfo.NameHash, structureInfo));

               
            }
        }

        public PsoStructureXml FindAndCheckStructure(XmlNode node)
        {
            int h = GetHashForName(node.Name);
            foreach (var x in xmlInfos.Structures)
            {
                if (x.NameHash == h)
                {                   
                    return x;
                }
            }

            return null;
        }

        public PsoStructureXml FindAndCheckStructure(int h, XmlNode node)
        {
            foreach (var x in xmlInfos.Structures)
            {
                if (x.NameHash == h)
                {                    
                    return x;
                }
            }

            return null;
        }
    }
}
