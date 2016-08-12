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

namespace RageLib.Resources.GTA5.PC.Meta
{
    public enum StructureEntryDataType : byte
    {
        Boolean = 0x01,
        Byte_A = 0x10,
        Byte_B = 0x11,
        Byte_Enum = 0x60,
        Int16_A = 0x12,
        Int16_B = 0x13,
        Int16_Enum = 0x64,
        Int24 = 0x50,
        Int32_A = 0x14,
        Int32_B = 0x15,
        Int32_Enum1 = 0x62,
        Int32_Enum2 = 0x63,
        Int32_Enum3 = 0x65,
        Int32_Hash = 0x4A,
        Float = 0x21,
        Int64 = 0x59,
        Float4_XYZ = 0x33,
        Float4_XYZW = 0x34,
        Char64 = 0x40,
        Generic = 0x07,
        Array = 0x52,
        CharPointer = 0x44,
        Structure = 0x05
    }

    public class StructureEntryInfo_GTA5_pc : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 16; }
        }

        // structure data
        public uint EntryNameHash;
        public uint DataOffset;
        public StructureEntryDataType DataType;
        public byte Unknown_9h;
        public ushort ReferenceTypeIndex;
        public uint ReferenceKey;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.EntryNameHash = reader.ReadUInt32();
            this.DataOffset = reader.ReadUInt32();
            this.DataType = (StructureEntryDataType)reader.ReadByte();
            this.Unknown_9h = reader.ReadByte();
            this.ReferenceTypeIndex = reader.ReadUInt16();
            this.ReferenceKey = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // write structure data
            writer.Write(this.EntryNameHash);
            writer.Write(this.DataOffset);
            writer.Write((byte)this.DataType);
            writer.Write(this.Unknown_9h);
            writer.Write(this.ReferenceTypeIndex);
            writer.Write(this.ReferenceKey);
        }
    }
}
