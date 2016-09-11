using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RageLib.GTA5.ResourceWrappers.PC.Meta.Descriptions
{
    [Serializable]
    public class MetaInformationXml
    {
        [XmlElement("Structure")]
        public List<MetaStructureXml> Structures { get; set; }

        [XmlElement("Enum")]
        public List<MetaEnumXml> Enums { get; set; }
    }

    [Serializable]
    public class MetaStructureXml
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
        public int Key { get; set; }

        [XmlAttribute("Key")]
        public string KeyAsHex
        {
            get { return HexConverter.ToHex(Key); }
            set { Key = HexConverter.ToUInt32(value); }
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
        public List<MetaStructureEntryXml> Entries { get; set; }
    }

    [Serializable]
    public class MetaStructureEntryXml
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
        public MetaStructureArrayTypeXml ArrayType { get; set; }
    }

    [Serializable]
    public class MetaStructureArrayTypeXml
    {
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

        [XmlElement("ArrayType")]
        public MetaStructureArrayTypeXml ArrayType { get; set; }
    }

    [Serializable]
    public class MetaEnumXml
    {
        [XmlIgnore]
        public int Key { get; set; }

        [XmlAttribute("Key")]
        public string KeyAsHex
        {
            get { return HexConverter.ToHex(Key); }
            set { Key = HexConverter.ToUInt32(value); }
        }


        [XmlIgnore]
        public int NameHash { get; set; }

        [XmlAttribute("NameHash")]
        public string NameHashAsHex
        {
            get { return HexConverter.ToHex(NameHash); }
            set { NameHash = HexConverter.ToUInt32(value); }
        }

        [XmlElement("EnumEntry")]
        public List<MetaEnumEntryXml> Entries { get; set; }
    }

    [Serializable]
    public class MetaEnumEntryXml
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
