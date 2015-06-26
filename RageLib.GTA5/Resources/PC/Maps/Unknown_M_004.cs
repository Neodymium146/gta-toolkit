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

using RageLib.Data;
using RageLib.Resources.Common;
using System;

namespace RageLib.Resources.GTA5.PC.Maps
{
    public class Unknown_M_004 : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 4 + Data.Length; }
        }

        // structure data
        public ushort Unknown_0h;
        public ushort DataLength;
        public ResourceSimpleArray<byte_r> Data;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.Unknown_0h = reader.ReadUInt16();

            reader.Endianess = Endianess.BigEndian;
            this.DataLength = reader.ReadUInt16();
            reader.Endianess = Endianess.LittleEndian;

            Data = reader.ReadBlock<ResourceSimpleArray<byte_r>>(DataLength);
        }


        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // write structure data
            writer.Write(this.Unknown_0h);

            writer.Endianess = Endianess.BigEndian;
            writer.Write(this.DataLength);
            writer.Endianess = Endianess.LittleEndian;

            writer.WriteBlock(Data);
        }

        /// <summary>
		/// Returns a list of data blocks which are referenced by this block.
		/// </summary>
		public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(0x4, Data)
            };
        }
    }
}