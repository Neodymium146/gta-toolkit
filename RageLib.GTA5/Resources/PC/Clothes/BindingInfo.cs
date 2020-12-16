/*
    Copyright(c) 2017 Neodymium

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

using System.Numerics;

namespace RageLib.Resources.GTA5.PC.Clothes
{
    // rage__characterClothController__BindingInfo
    public class BindingInfo : ResourceSystemBlock
    {
        public override long BlockLength => 0x20;

        // structure data
        public Vector4 Weights;
        public uint BlendIndex0;
        public uint BlendIndex1;
        public uint BlendIndex2;
        public uint BlendIndex4;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.Weights = reader.ReadVector4();
            this.BlendIndex0 = reader.ReadUInt32();
            this.BlendIndex1 = reader.ReadUInt32();
            this.BlendIndex2 = reader.ReadUInt32();
            this.BlendIndex4 = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // write structure data
            writer.Write(this.Weights);
            writer.Write(this.BlendIndex0);
            writer.Write(this.BlendIndex1);
            writer.Write(this.BlendIndex2);
            writer.Write(this.BlendIndex4);
        }
    }
}
