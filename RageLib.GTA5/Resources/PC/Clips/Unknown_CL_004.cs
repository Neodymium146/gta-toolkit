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

namespace RageLib.Resources.GTA5.PC.Clips
{
    public class Unknown_CL_004 : ResourceSystemBlock, IResourceXXSystemBlock
    {
        public override long Length
        {
            get { return 16; }
        }

        // structure data
        public uint VFT;
        public uint Unknown_4h; // 0x00000001
        public byte type;
        public byte Unknown_9h;
        public ushort Unknown_Ah;
        public uint Unknown_Ch;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.VFT = reader.ReadUInt32();
            this.Unknown_4h = reader.ReadUInt32();
            this.type = reader.ReadByte();
            this.Unknown_9h = reader.ReadByte();
            this.Unknown_Ah = reader.ReadUInt16();
            this.Unknown_Ch = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // write structure data
            writer.Write(this.VFT);
            writer.Write(this.Unknown_4h);
            writer.Write(this.type);
            writer.Write(this.Unknown_9h);
            writer.Write(this.Unknown_Ah);
            writer.Write(this.Unknown_Ch);
        }

        public IResourceSystemBlock GetType(ResourceDataReader reader, params object[] parameters)
        {
            reader.Position += 8;
            var type = reader.ReadByte();
            reader.Position -= 9;

            switch (type)
            {
                case 1: return new Unknown_CL_004_type1();
                case 2: return new Unknown_CL_004_type2();
                case 3: return new Unknown_CL_004_type3();
                case 4: return new Unknown_CL_004_type4();
                case 6: return new Unknown_CL_004_type6();
                case 8: return new Unknown_CL_004_type8();
                default: throw new Exception("Unknown type");
            }
        }
    }
}
