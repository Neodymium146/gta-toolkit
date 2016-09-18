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
using System;
using System.Text;

namespace RageLib.GTA5.PSOWrappers.Types
{
    public class PsoType11 : IPsoValue
    {
        private readonly int length;

        public int ValueHash { get; set; }
        public string Value { get; set; }

        public PsoType11(int length)
        {
            this.length = length;
        }

        public PsoType11(int length, string value)
        {
            this.length = length;
            this.Value = value;
        }

        public void Read(DataReader reader)
        {
            if (length == 0)
            {
                this.ValueHash = reader.ReadInt32();
            }
            else
            {
                var valueBuilder = new StringBuilder();
                var valueValid = true;
                for (int i = 0; i < length; i++)
                {
                    char c = (char)reader.ReadByte();
                    if (c == 0)
                    {
                        valueValid = false;
                    }
                    if (valueValid)
                    {
                        valueBuilder.Append((char)c);
                    }
                    else
                    {
                        if (c != 0)
                        {
                            throw new Exception("c should be 0");
                        }
                    }
                }
                this.Value = valueBuilder.ToString();
            }
        }

        public void Write(DataWriter writer)
        {
            if (length == 0)
            {
                writer.Write(ValueHash);
            }
            else
            {
                for (int i = 0; i < Value.Length; i++)
                {
                    writer.Write((byte)Value[i]);
                }
                for (int i = Value.Length; i < 64; i++)
                {
                    writer.Write((byte)0);
                }
            }
        }
    }
}
