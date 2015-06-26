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

using System;

namespace RageLib.Resources.GTA5.PC.Types
{
    public class Unknown_T_004 : ResourceSystemBlock, IResourceXXSystemBlock
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
                case 16: return new Unknown_T_004_00000010();
                case 186126833: return new Unknown_T_004_0b1811f1();
                case 2572186314: return new Unknown_T_004_995072ca();
                case 3461354627: return new Unknown_T_004_ce501483();
                case 3649811809: return new Unknown_T_004_types();
                case 51: return new Unknown_T_004_00000033();
                case 7: return new Unknown_T_004_infos();
                case 273704021: return new Unknown_T_004_10506455();
                case 2195127427: return new Unknown_T_004_objs();
                case 21: return new Unknown_T_004_00000015();
                case 2182960161: return new Unknown_T_004_821d5421();
                case 1991296364: return new Unknown_T_004_objs2();
                case 807246248: return new Unknown_T_004_301d99a8();
                case 366926375: return new Unknown_T_004_15deda27();
                case 975627745: return new Unknown_T_004_3a26e5e1();
                case 2565191912: return new Unknown_T_004_98e5b8e8();
                case 569228403: return new Unknown_T_004_21edbc73();
                case 3601308153: return new Unknown_T_004_d6a799f9();
                case 1965932561: return new Unknown_T_004_752dc011();
                case 2716862120: return new Unknown_T_004_a1f006a8();
                case 663891011: return new Unknown_T_004_27922c43();
                case 637823035: return new Unknown_T_004_2604683b();
                case 4115341947: return new Unknown_T_004_f54b227b();
                case 2718997053: return new Unknown_T_004_a2109a3d();
                case 3870521079: return new Unknown_T_004_e6b376f7();
                case 3300062776: return new Unknown_T_004_c4b2f638();
                case 749982947: return new Unknown_T_004_2cb3d4e3();
                case 104349545: return new Unknown_T_004_06383f69();
                case 1185771007: return new Unknown_T_004_46ad6dff();
                case 3430328684: return new Unknown_T_004_cc76a96c();
                case 1980345114: return new Unknown_T_004_7609ab1a();
                default: throw new Exception("Unknown type");
            }

        }
    }
}