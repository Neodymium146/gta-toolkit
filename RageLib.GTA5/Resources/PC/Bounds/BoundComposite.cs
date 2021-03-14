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
using System.Numerics;

namespace RageLib.Resources.GTA5.PC.Bounds
{
    // phBoundComposite
    public class BoundComposite : Bound
    {
        public override long BlockLength => 0xB0;

        // structure data
        public ulong BoundsPointer;
        public ulong CurrentMatricesPointer;
        public ulong LastMatricesPointer;
        public ulong ChildBoundingBoxesPointer;
        public ulong TypeAndIncludeFlagsPointer;
        public ulong OwnedTypeAndIncludeFlagsPointer;
        public ushort MaxNumBounds;
        public ushort NumBounds;
        public uint Unknown_A4h; // 0x00000000
        public ulong BVHPointer;

        // reference data
        public ResourcePointerArray64<Bound> Bounds;
        public SimpleArray<Matrix4x4> CurrentMatrices;
        public SimpleArray<Matrix4x4> LastMatrices;
        public SimpleArray<Aabb> ChildBoundingBoxes;
        public SimpleArray<ulong> TypeAndIncludeFlags;
        public SimpleArray<ulong> OwnedTypeAndIncludeFlags;
        public BVH BVH;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.BoundsPointer = reader.ReadUInt64();
            this.CurrentMatricesPointer = reader.ReadUInt64();
            this.LastMatricesPointer = reader.ReadUInt64();
            this.ChildBoundingBoxesPointer = reader.ReadUInt64();
            this.TypeAndIncludeFlagsPointer = reader.ReadUInt64();
            this.OwnedTypeAndIncludeFlagsPointer = reader.ReadUInt64();
            this.MaxNumBounds = reader.ReadUInt16();
            this.NumBounds = reader.ReadUInt16();
            this.Unknown_A4h = reader.ReadUInt32();
            this.BVHPointer = reader.ReadUInt64();

            // read reference data
            this.Bounds = reader.ReadBlockAt<ResourcePointerArray64<Bound>>(
                this.BoundsPointer, // offset
                this.MaxNumBounds
            );
            this.CurrentMatrices = reader.ReadBlockAt<SimpleArray<Matrix4x4>>(
                this.CurrentMatricesPointer, // offset
                this.MaxNumBounds
            );
            this.LastMatrices = reader.ReadBlockAt<SimpleArray<Matrix4x4>>(
                this.LastMatricesPointer, // offset
                this.MaxNumBounds
            );
            this.ChildBoundingBoxes = reader.ReadBlockAt<SimpleArray<Aabb>>(
                this.ChildBoundingBoxesPointer, // offset
                this.MaxNumBounds
            );
            this.TypeAndIncludeFlags = reader.ReadBlockAt<SimpleArray<ulong>>(
                this.TypeAndIncludeFlagsPointer, // offset
                this.MaxNumBounds
            );
            this.OwnedTypeAndIncludeFlags = reader.ReadBlockAt<SimpleArray<ulong>>(
                this.OwnedTypeAndIncludeFlagsPointer, // offset
                this.MaxNumBounds
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
            this.BoundsPointer = (ulong)(this.Bounds != null ? this.Bounds.BlockPosition : 0);
            this.CurrentMatricesPointer = (ulong)(this.CurrentMatrices != null ? this.CurrentMatrices.BlockPosition : 0);
            this.LastMatricesPointer = (ulong)(this.LastMatrices != null ? this.LastMatrices.BlockPosition : 0);
            this.ChildBoundingBoxesPointer = (ulong)(this.ChildBoundingBoxes != null ? this.ChildBoundingBoxes.BlockPosition : 0);
            this.TypeAndIncludeFlagsPointer = (ulong)(this.TypeAndIncludeFlags != null ? this.TypeAndIncludeFlags.BlockPosition : 0);
            this.OwnedTypeAndIncludeFlagsPointer = (ulong)(this.OwnedTypeAndIncludeFlags != null ? this.OwnedTypeAndIncludeFlags.BlockPosition : 0);
            this.MaxNumBounds = (ushort)(this.Bounds != null ? this.Bounds.Count : 0);
            this.NumBounds = (ushort)(this.Bounds != null ? this.Bounds.Count : 0);
            this.BVHPointer = (ulong)(this.BVH != null ? this.BVH.BlockPosition : 0);

            // write structure data
            writer.Write(this.BoundsPointer);
            writer.Write(this.CurrentMatricesPointer);
            writer.Write(this.LastMatricesPointer);
            writer.Write(this.ChildBoundingBoxesPointer);
            writer.Write(this.TypeAndIncludeFlagsPointer);
            writer.Write(this.OwnedTypeAndIncludeFlagsPointer);
            writer.Write(this.MaxNumBounds);
            writer.Write(this.NumBounds);
            writer.Write(this.Unknown_A4h);
            writer.Write(this.BVHPointer);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>(base.GetReferences());
            if (Bounds != null) list.Add(Bounds);
            if (CurrentMatrices != null) list.Add(CurrentMatrices);
            if (LastMatrices != null) list.Add(LastMatrices);
            if (ChildBoundingBoxes != null) list.Add(ChildBoundingBoxes);
            if (TypeAndIncludeFlags != null) list.Add(TypeAndIncludeFlags);
            if (OwnedTypeAndIncludeFlags != null) list.Add(OwnedTypeAndIncludeFlags);
            if (BVH != null) list.Add(BVH);
            return list.ToArray();
        }
    }
}
