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

using RageLib.Data;
using RageLib.GTA5.PSOWrappers.Data;
using System;

namespace RageLib.GTA5.PSOWrappers.Types
{
    public class PsoString3 : IPsoValue
    {
        public string Value { get; set; }

        public void Read(PsoDataReader reader)
        {
            var blockIndexAndOffset = reader.ReadUInt32();
            var BlockIndex = (int)(blockIndexAndOffset & 0x00000FFF);
            var Offset = (int)((blockIndexAndOffset & 0xFFFFF000) >> 12);
            var zero_4h = reader.ReadUInt32();
            if (zero_4h != 0)
            {
                throw new Exception("zero_4h should be 0");
            }
            var size1 = reader.ReadUInt16() & 0x0FFF;
            var size2 = reader.ReadUInt16() & 0x0FFF;
            //if (size1 != size2 - 1)
            //{
            //    throw new Exception("size1 should be size2");
            //}
            var NumberOfEntries = size2;
            var zero_Ch = reader.ReadUInt32();
            if (zero_Ch != 0)
            {
                throw new Exception("zero_Ch should be 0");
            }


            // read reference data...
            if (BlockIndex > 0)
            {

                var backupOfSection = reader.CurrentSectionIndex;
                var backupOfPosition = reader.Position;

                reader.SetSectionIndex(BlockIndex - 1);
                reader.Position = Offset;

                string s = "";
                for (int k = 0; k < NumberOfEntries; k++)
                {
                    s += (char)reader.ReadByte();
                }
                Value = s;

                reader.SetSectionIndex(backupOfSection);
                reader.Position = backupOfPosition;



            }
            else
            {
                Value = null;
            }
        }

        public void Write(DataWriter writer)
        {

        }
    }
}
