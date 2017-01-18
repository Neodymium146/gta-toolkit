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
    public class PsoString0 : IPsoValue
    {
        private readonly int length;
        public string Value { get; set; }

        public PsoString0(int length)
        {
            this.length = length;
        }

        public void Read(PsoDataReader reader)
        {
            Value = "";
            bool isok = true;
            for (int i = 0; i < length; i++)
            {
                char c = (char)reader.ReadByte();
                if (c == 0)
                {
                    isok = false;
                }
                else
                {
                    if (!isok)
                        throw new Exception("Unexpected char.");
                    Value += c;
                }
            }
        }

        public void Write(DataWriter writer)
        {

        }
    }
}
