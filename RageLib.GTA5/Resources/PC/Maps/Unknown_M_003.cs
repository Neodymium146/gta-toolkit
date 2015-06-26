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
using System;

namespace RageLib.Resources.GTA5.PC.Maps
{
    public class Unknown_M_003 : ResourceSystemBlock, IResourceXXSystemBlock
    {
        public override long Length
        {
            get { return 16; }
        }

        // structure data
        public uint DataType;
        public uint DataLength;
        public ulong DataPointer;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.DataType = reader.ReadUInt32();
            this.DataLength = reader.ReadUInt32();
            this.DataPointer = reader.ReadUInt64();
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // write structure data
            writer.Write(this.DataType);
            writer.Write(this.DataLength);
            writer.Write(this.DataPointer);


        }

        public IResourceSystemBlock GetType(ResourceDataReader reader, params object[] parameters)
        {
            reader.Position += 0;
            var type = reader.ReadUInt32();
            reader.Position -= 4;

            switch (type)
            {
                case 3545841574: return new Unknown_M_003_maps();
                case 16: return new Unknown_M_003_00000010();
                case 3461354627: return new Unknown_M_003_objs();
                case 7: return new Unknown_M_003_infos();
                case 74: return new Unknown_M_003_0000004a();
                case 1733268304: return new Unknown_M_003_674f9350();
                case 4115341947: return new Unknown_M_003_f54b227b();
                case 663891011: return new Unknown_M_003_27922c43();
                case 164374718: return new Unknown_M_003_09cc28be();
                case 2741784237: return new Unknown_M_003_a36c4ead();
                case 975711773: return new Unknown_M_003_3a282e1d();
                case 17: return new Unknown_M_003_00000011();
                case 3805007828: return new Unknown_M_003_e2cbcfd4();
                case 21: return new Unknown_M_003_00000015();
                case 33: return new Unknown_M_003_00000021();
                case 1860713439: return new Unknown_M_003_vehicles();
                case 2716862120: return new Unknown_M_003_a1f006a8();
                case 2085051229: return new Unknown_M_003_7c475b5d();
                case 3985044770: return new Unknown_M_003_ed86f522();
                case 1965932561: return new Unknown_M_003_752dc011();
                case 1701774085: return new Unknown_M_003_656f0305();
                case 847348117: return new Unknown_M_003_32818195();
                default: throw new Exception("Unknown type");
            }
        }
    }
}