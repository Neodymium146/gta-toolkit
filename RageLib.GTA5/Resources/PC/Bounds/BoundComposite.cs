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

using RageLib.Resources.Common;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Bounds
{
    // phBoundComposite
    public class BoundComposite : Bound
    {
        public override long Length => 0xB0;

        // structure data
        public ulong ChildrenPointer;
        public ulong ChildTransformations1Pointer;
        public ulong ChildTransformations2Pointer;
        public ulong ChildBoundingBoxesPointer;
        public ulong ChildFlags1Pointer;
        public ulong ChildFlags2Pointer;
        public ushort ChildrenCount1;
        public ushort ChildrenCount2;
        public uint Unknown_A4h; // 0x00000000
        public ulong BVHPointer;

        // reference data
        public ResourcePointerArray64<Bound> Children;
        public ResourceSimpleArray<RAGE_Matrix4> ChildTransformations1;
        public ResourceSimpleArray<RAGE_Matrix4> ChildTransformations2;
        public ResourceSimpleArray<RAGE_AABB> ChildBoundingBoxes;
        public ResourceSimpleArray<ulong_r> ChildFlags1;
        public ResourceSimpleArray<ulong_r> ChildFlags2;
        public BVH BVH;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.ChildrenPointer = reader.ReadUInt64();
            this.ChildTransformations1Pointer = reader.ReadUInt64();
            this.ChildTransformations2Pointer = reader.ReadUInt64();
            this.ChildBoundingBoxesPointer = reader.ReadUInt64();
            this.ChildFlags1Pointer = reader.ReadUInt64();
            this.ChildFlags2Pointer = reader.ReadUInt64();
            this.ChildrenCount1 = reader.ReadUInt16();
            this.ChildrenCount2 = reader.ReadUInt16();
            this.Unknown_A4h = reader.ReadUInt32();
            this.BVHPointer = reader.ReadUInt64();

            // read reference data
            this.Children = reader.ReadBlockAt<ResourcePointerArray64<Bound>>(
                this.ChildrenPointer, // offset
                this.ChildrenCount1
            );
            this.ChildTransformations1 = reader.ReadBlockAt<ResourceSimpleArray<RAGE_Matrix4>>(
                this.ChildTransformations1Pointer, // offset
                this.ChildrenCount1
            );
            this.ChildTransformations2 = reader.ReadBlockAt<ResourceSimpleArray<RAGE_Matrix4>>(
                this.ChildTransformations2Pointer, // offset
                this.ChildrenCount1
            );
            this.ChildBoundingBoxes = reader.ReadBlockAt<ResourceSimpleArray<RAGE_AABB>>(
                this.ChildBoundingBoxesPointer, // offset
                this.ChildrenCount1
            );
            this.ChildFlags1 = reader.ReadBlockAt<ResourceSimpleArray<ulong_r>>(
                this.ChildFlags1Pointer, // offset
                this.ChildrenCount1
            );
            this.ChildFlags2 = reader.ReadBlockAt<ResourceSimpleArray<ulong_r>>(
                this.ChildFlags2Pointer, // offset
                this.ChildrenCount1
            );
            this.BVH = reader.ReadBlockAt<BVH>(
                this.BVHPointer // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.ChildrenPointer = (ulong)(this.Children != null ? this.Children.Position : 0);
            this.ChildTransformations1Pointer = (ulong)(this.ChildTransformations1 != null ? this.ChildTransformations1.Position : 0);
            this.ChildTransformations2Pointer = (ulong)(this.ChildTransformations2 != null ? this.ChildTransformations2.Position : 0);
            this.ChildBoundingBoxesPointer = (ulong)(this.ChildBoundingBoxes != null ? this.ChildBoundingBoxes.Position : 0);
            this.ChildFlags1Pointer = (ulong)(this.ChildFlags1 != null ? this.ChildFlags1.Position : 0);
            this.ChildFlags2Pointer = (ulong)(this.ChildFlags2 != null ? this.ChildFlags2.Position : 0);
            this.ChildrenCount1 = (ushort)(this.Children != null ? this.Children.Count : 0);
            this.ChildrenCount2 = (ushort)(this.Children != null ? this.Children.Count : 0);
            this.BVHPointer = (ulong)(this.BVH != null ? this.BVH.Position : 0);

            // write structure data
            writer.Write(this.ChildrenPointer);
            writer.Write(this.ChildTransformations1Pointer);
            writer.Write(this.ChildTransformations2Pointer);
            writer.Write(this.ChildBoundingBoxesPointer);
            writer.Write(this.ChildFlags1Pointer);
            writer.Write(this.ChildFlags2Pointer);
            writer.Write(this.ChildrenCount1);
            writer.Write(this.ChildrenCount2);
            writer.Write(this.Unknown_A4h);
            writer.Write(this.BVHPointer);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>(base.GetReferences());
            if (Children != null) list.Add(Children);
            if (ChildTransformations1 != null) list.Add(ChildTransformations1);
            if (ChildTransformations2 != null) list.Add(ChildTransformations2);
            if (ChildBoundingBoxes != null) list.Add(ChildBoundingBoxes);
            if (ChildFlags1 != null) list.Add(ChildFlags1);
            if (ChildFlags2 != null) list.Add(ChildFlags2);
            if (BVH != null) list.Add(BVH);
            return list.ToArray();
        }
    }
}
