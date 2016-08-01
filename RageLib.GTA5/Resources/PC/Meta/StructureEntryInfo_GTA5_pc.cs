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
        BYTE_01h = 0x01,
        BYTE_10h = 0x10,
        BYTE_11h = 0x11,
        BYTE_60h = 0x60,
        SHORT_12h = 0x12,
        SHORT_13h = 0x13,
        SHORT_64h = 0x64,
        INT24 = 0x50,
        INT_14h = 0x14,
        INT_15h = 0x15,
        INT_65h = 0x65,
        INT_63h = 0x63,
        UINT_HASH = 0x4A,
        UINT_ENUM = 0x62,
        FLOAT = 0x21,
        LONG = 0x59,
        FLOAT4_XYZ = 0x33,
        FLOAT4_XYZW = 0x34,
        CHAR64 = 0x40,
        GENERIC = 0x07,
        ARRAY = 0x52,
        CHARPTR = 0x44,
        STRUCTURE = 0x05
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
