/*
    Copyright(c) 2015 Neodymium

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

using RageLib.Resources.Common;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Meta
{
    public class MetaClassInfo_GTA5_pc : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 32; }
        }

        // structure data
        public uint NameHash;
        public uint Unknown_4h;
        public uint Unknown_8h;
        public uint Unknown_Ch; // 0x00000000
        public ulong FieldsPointer;
        public uint ClassLength;
        public ushort Unknown_1Ch; // 0x0000
        public ushort FieldsCount;

        // reference data
        public ResourceSimpleArray<MetaFieldInfo_GTA5_pc> Fields;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.NameHash = reader.ReadUInt32();
            this.Unknown_4h = reader.ReadUInt32();
            this.Unknown_8h = reader.ReadUInt32();
            this.Unknown_Ch = reader.ReadUInt32();
            this.FieldsPointer = reader.ReadUInt64();
            this.ClassLength = reader.ReadUInt32();
            this.Unknown_1Ch = reader.ReadUInt16();
            this.FieldsCount = reader.ReadUInt16();

            // read reference data
            this.Fields = reader.ReadBlockAt<ResourceSimpleArray<MetaFieldInfo_GTA5_pc>>(
                this.FieldsPointer, // offset
                this.FieldsCount
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.FieldsPointer = (ulong)(this.Fields != null ? this.Fields.Position : 0);
            //this.FieldsCount = (ushort)(this.Fields != null ? this.Fields.Count : 0);

            // write structure data
            writer.Write(this.NameHash);
            writer.Write(this.Unknown_4h);
            writer.Write(this.Unknown_8h);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.FieldsPointer);
            writer.Write(this.ClassLength);
            writer.Write(this.Unknown_1Ch);
            writer.Write(this.FieldsCount);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (Fields != null) list.Add(Fields);
            return list.ToArray();
        }

    }
}