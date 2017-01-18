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
    public class PsoString2 : IPsoValue
    {
        public string Value { get; set; }

        public void Read(PsoDataReader reader)
        {
            int x1 = reader.ReadInt32();
            int x2 = reader.ReadInt32();
            if (x2 != 0)
            {
                throw new Exception("zero_Ch should be 0");
            }

            var BlockIndex = (int)(x1 & 0x00000FFF);
            var Offset = (int)((x1 & 0xFFFFF000) >> 12);

            // read reference data...
            var backupOfSection = reader.CurrentSectionIndex;
            var backupOfPosition = reader.Position;

            reader.SetSectionIndex(BlockIndex - 1);
            reader.Position = Offset;

            Value = reader.ReadString();

            reader.SetSectionIndex(backupOfSection);
            reader.Position = backupOfPosition;
        }

        public void Write(DataWriter writer)
        {

        }
    }
}
