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

namespace RageLib.GTA5.ResourceWrappers.PC.Meta.Types
{
    public class MetaDataBlockPointer : IMetaValue
    {
        public readonly StructureEntryInfo info;

        public int BlockIndex { get; set; }

        public byte[] Data { get; set; }

        public MetaDataBlockPointer(StructureEntryInfo info)
        {
            this.info = info;
        }

        public MetaDataBlockPointer(StructureEntryInfo info, byte[] data)
        {
            this.info = info;
            this.Data = data;
        }

        public void Read(DataReader reader)
        {
            this.BlockIndex = reader.ReadInt32();
            var unk1 = reader.ReadInt32();
            if (unk1 != 0)
                throw new System.Exception("4h should be 0");
        }

        public void Write(DataWriter writer)
        {
            writer.Write(BlockIndex);
            writer.Write((int)0);
        }
    }
}
