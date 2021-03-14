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

using RageLib.Data;

namespace RageLib.Resources.GTA5.PC.Bounds
{
    public struct BVHTreeInfo : IResourceStruct<BVHTreeInfo>
    {
        public short MinX;
        public short MinY;
        public short MinZ;
        public short MaxX;
        public short MaxY;
        public short MaxZ;
        public short NodeIndex1;
        public short NodeIndex2;

        public BVHTreeInfo ReverseEndianness()
        {
            return new BVHTreeInfo()
            {
                MinX = EndiannessExtensions.ReverseEndianness(MinX),
                MinY = EndiannessExtensions.ReverseEndianness(MinY),
                MinZ = EndiannessExtensions.ReverseEndianness(MinZ),
                MaxX = EndiannessExtensions.ReverseEndianness(MaxX),
                MaxY = EndiannessExtensions.ReverseEndianness(MaxY),
                MaxZ = EndiannessExtensions.ReverseEndianness(MaxZ),
                NodeIndex1 = EndiannessExtensions.ReverseEndianness(NodeIndex1),
                NodeIndex2 = EndiannessExtensions.ReverseEndianness(NodeIndex2),
            };
        }
    }
}
