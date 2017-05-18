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
using RageLib.Resources.GTA5.PC.Meta;
using System;
using System.Text;

namespace RageLib.GTA5.ResourceWrappers.PC.Meta.Types
{
    public class MetaArrayOfChars : IMetaValue
    {
        public readonly StructureEntryInfo info;

        public string Value { get; set; }

        public MetaArrayOfChars(StructureEntryInfo info)
        {
            this.info = info;
        }

        public MetaArrayOfChars(StructureEntryInfo inf, string value)
        {
            this.info = inf;
            this.Value = value;
        }

        public void Read(DataReader reader)
        {
            var valueBuilder = new StringBuilder();
            var valueValid = true;
            for (int i = 0; i < info.ReferenceKey; i++)
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

        public void Write(DataWriter writer)
        {
            for (int i = 0; i < Value.Length; i++)
            {
                writer.Write((byte)Value[i]);
            }
            for (int i = Value.Length; i < info.ReferenceKey; i++)
            {
                writer.Write((byte)0);
            }
        }
    }
}
