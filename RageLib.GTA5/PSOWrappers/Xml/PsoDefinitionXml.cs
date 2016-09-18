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

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;

namespace RageLib.GTA5.PSOWrappers.Xml
{
    [Serializable]
    public class PsoDefinitionXml
    {
        [XmlElement("Structure")]
        public List<PsoStructureXml> Structures { get; set; }

        [XmlElement("Enum")]
        public List<PsoEnumXml> Enums { get; set; }
    }

    [Serializable]
    public class PsoStructureXml
    {
        [XmlIgnore]
        public int NameHash { get; set; }

        [XmlAttribute("NameHash")]
        public string NameHashAsHex
        {
            get { return HexConverter.ToHex(NameHash); }
            set { NameHash = HexConverter.ToUInt32(value); }
        }
        
        [XmlIgnore]
        public int Unknown { get; set; }

        [XmlAttribute("Unknown")]
        public string UnknownAsHex
        {
            get { return HexConverter.ToHex(Unknown); }
            set { Unknown = HexConverter.ToUInt32(value); }
        }

        [XmlAttribute("Length")]
        public int Length { get; set; }

        [XmlElement("StructureEntry")]
        public List<PsoStructureEntryXml> Entries { get; set; }
    }

    [Serializable]
    public class PsoStructureEntryXml
    {
        [XmlIgnore]
        public int NameHash { get; set; }

        [XmlAttribute("NameHash")]
        public string NameHashAsHex
        {
            get { return HexConverter.ToHex(NameHash); }
            set { NameHash = HexConverter.ToUInt32(value); }
        }

        [XmlAttribute("Offset")]
        public int Offset { get; set; }

        [XmlAttribute("Type")]
        public int Type { get; set; }

        [XmlIgnore]
        public int TypeHash { get; set; }

        [XmlAttribute("TypeHash")]
        public string TypeHashAsHex
        {
            get { return HexConverter.ToHex(TypeHash); }
            set { TypeHash = HexConverter.ToUInt32(value); }
        }

        [XmlIgnore]
        public int Unknown { get; set; }

        [XmlAttribute("Unknown")]
        public string UnknownAsHex
        {
            get { return HexConverter.ToHex(Unknown); }
            set { Unknown = HexConverter.ToUInt32(value); }
        }

        [XmlElement("ArrayType")]
        public PsoStructureEntryXml ArrayType { get; set; }
    }

    [Serializable]
    public class PsoEnumXml
    {
        [XmlIgnore]
        public int NameHash { get; set; }

        [XmlAttribute("NameHash")]
        public string NameHashAsHex
        {
            get { return HexConverter.ToHex(NameHash); }
            set { NameHash = HexConverter.ToUInt32(value); }
        }

        [XmlElement("EnumEntry")]
        public List<PsoEnumEntryXml> Entries { get; set; }
    }

    [Serializable]
    public class PsoEnumEntryXml
    {
        [XmlIgnore]
        public int NameHash { get; set; }

        [XmlAttribute("NameHash")]
        public string NameHashAsHex
        {
            get { return HexConverter.ToHex(NameHash); }
            set { NameHash = HexConverter.ToUInt32(value); }
        }

        [XmlAttribute("Value")]
        public int Value { get; set; }
    }

    public static class HexConverter
    {
        public static string ToHex(int value)
        {
            return "0x" + value.ToString("X8");
        }

        public static int ToUInt32(string value)
        {
            if (value.StartsWith("0x"))
            {
                return int.Parse(value.Substring(2), NumberStyles.HexNumber);
            }
            else
            {
                return int.Parse(value, NumberStyles.HexNumber);
            }
        }
    }

}
