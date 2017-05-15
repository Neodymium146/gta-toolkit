/*
    Copyright(c) 2017 Neodymium

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

namespace RageLib.Resources.GTA5.PC.Clips
{
    // crPropertyAttributeString
    public class PropertyAttributeString : PropertyAttribute
    {
        public override long Length => 0x30;

        // structure data
        public ulong ValuePointer;
        public ushort ValueLength1;
        public ushort ValueLength2;
        public uint Unknown_2Ch; // 0x00000000

        // reference data
        public string_r Value;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.ValuePointer = reader.ReadUInt64();
            this.ValueLength1 = reader.ReadUInt16();
            this.ValueLength2 = reader.ReadUInt16();
            this.Unknown_2Ch = reader.ReadUInt32();

            // read reference data
            this.Value = reader.ReadBlockAt<string_r>(
                this.ValuePointer // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.ValuePointer = (ulong)(this.Value != null ? this.Value.Position : 0);
            this.ValueLength1 = (ushort)(this.Value != null ? this.Value.Value.Length : 0);
            this.ValueLength2 = (ushort)(this.Value != null ? this.Value.Value.Length + 1 : 0);

            // write structure data
            writer.Write(this.ValuePointer);
            writer.Write(this.ValueLength1);
            writer.Write(this.ValueLength2);
            writer.Write(this.Unknown_2Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>(base.GetReferences());
            if (Value != null) list.Add(Value);
            return list.ToArray();
        }
    }
}
