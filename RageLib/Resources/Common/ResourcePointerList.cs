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

namespace RageLib.Resources.Common
{
    public class ResourcePointerList<T> : ResourceSystemBlock where T : IResourceSystemBlock, new()
    {
        public override long BlockLength
        {
            get { return 8; }
        }

        // structure data
        public uint DataPointer;
        public ushort DataCount1;
        public ushort DataCount2;

        // reference data
        public ResourcePointerArray<T> data_items;
        
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            this.DataPointer = reader.ReadUInt32();
            this.DataCount1 = reader.ReadUInt16();
            this.DataCount2 = reader.ReadUInt16();

            this.data_items = reader.ReadBlockAt<ResourcePointerArray<T>>(
                this.DataPointer, // offset
                this.DataCount1
            );
        }

        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update...
            this.DataPointer = (uint)data_items.BlockPosition;
            this.DataCount1 = (ushort)data_items.Count;
            this.DataCount2 = (ushort)data_items.Count;

            // write...
            writer.Write(DataPointer);
            writer.Write(DataCount1);
            writer.Write(DataCount2);
        }
    }
}
