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
using System;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Drawables
{
    // pgBase
    // crSkeletonData
    public class SkeletonData : PgBase64
    {
        public override long BlockLength => 0x70;

        // structure data
        public AtHashMap<uint_r> BoneMap;
        public ulong BonesPointer;
        public ulong TransformationsInvertedPointer;
        public ulong TransformationsPointer;
        public ulong ParentIndicesPointer;
        public ulong ChildrenIndicesPointer;
        public uint Unknown_48h; // 0x00000000
        public uint Unknown_4Ch; // 0x00000000
        public uint Unknown_50h;
        public uint Unknown_54h;
        public uint DataCRC;
        public ushort Unknown_5Ch; // 0x0001
        public ushort BonesCount;
        public ushort ChildrenIndicesCount;
        public ushort Unknown_62h; // 0x0000
        public uint Unknown_64h; // 0x00000000
        public uint Unknown_68h; // 0x00000000
        public uint Unknown_6Ch; // 0x00000000

        // reference data
        public ResourceSimpleArray<Bone> Bones;
        public ResourceSimpleArray<RAGE_Matrix4> TransformationsInverted;
        public ResourceSimpleArray<RAGE_Matrix4> Transformations;
        public ResourceSimpleArray<ushort_r> ParentIndices;
        public ResourceSimpleArray<ushort_r> ChildrenIndices;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.BoneMap = reader.ReadBlock<AtHashMap<uint_r>>();
            this.BonesPointer = reader.ReadUInt64();
            this.TransformationsInvertedPointer = reader.ReadUInt64();
            this.TransformationsPointer = reader.ReadUInt64();
            this.ParentIndicesPointer = reader.ReadUInt64();
            this.ChildrenIndicesPointer = reader.ReadUInt64();
            this.Unknown_48h = reader.ReadUInt32();
            this.Unknown_4Ch = reader.ReadUInt32();
            this.Unknown_50h = reader.ReadUInt32();
            this.Unknown_54h = reader.ReadUInt32();
            this.DataCRC = reader.ReadUInt32();
            this.Unknown_5Ch = reader.ReadUInt16();
            this.BonesCount = reader.ReadUInt16();
            this.ChildrenIndicesCount = reader.ReadUInt16();
            this.Unknown_62h = reader.ReadUInt16();
            this.Unknown_64h = reader.ReadUInt32();
            this.Unknown_68h = reader.ReadUInt32();
            this.Unknown_6Ch = reader.ReadUInt32();

            // read reference data
            this.Bones = reader.ReadBlockAt<ResourceSimpleArray<Bone>>(
                this.BonesPointer, // offset
                this.BonesCount
            );
            this.TransformationsInverted = reader.ReadBlockAt<ResourceSimpleArray<RAGE_Matrix4>>(
                this.TransformationsInvertedPointer, // offset
                this.BonesCount
            );
            this.Transformations = reader.ReadBlockAt<ResourceSimpleArray<RAGE_Matrix4>>(
                this.TransformationsPointer, // offset
                this.BonesCount
            );
            this.ParentIndices = reader.ReadBlockAt<ResourceSimpleArray<ushort_r>>(
                this.ParentIndicesPointer, // offset
                this.BonesCount
            );
            this.ChildrenIndices = reader.ReadBlockAt<ResourceSimpleArray<ushort_r>>(
                this.ChildrenIndicesPointer, // offset
                this.ChildrenIndicesCount
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.BonesPointer = (ulong)(this.Bones != null ? this.Bones.BlockPosition : 0);
            this.TransformationsInvertedPointer = (ulong)(this.TransformationsInverted != null ? this.TransformationsInverted.BlockPosition : 0);
            this.TransformationsPointer = (ulong)(this.Transformations != null ? this.Transformations.BlockPosition : 0);
            this.ParentIndicesPointer = (ulong)(this.ParentIndices != null ? this.ParentIndices.BlockPosition : 0);
            this.ChildrenIndicesPointer = (ulong)(this.ChildrenIndices != null ? this.ChildrenIndices.BlockPosition : 0);
            this.BonesCount = (ushort)(this.Bones?.Count ?? 0);
            this.ChildrenIndicesCount = (ushort)(this.ChildrenIndices != null ? this.ChildrenIndices.Count : 0);

            // write structure data
            writer.WriteBlock(this.BoneMap);
            writer.Write(this.BonesPointer);
            writer.Write(this.TransformationsInvertedPointer);
            writer.Write(this.TransformationsPointer);
            writer.Write(this.ParentIndicesPointer);
            writer.Write(this.ChildrenIndicesPointer);
            writer.Write(this.Unknown_48h);
            writer.Write(this.Unknown_4Ch);
            writer.Write(this.Unknown_50h);
            writer.Write(this.Unknown_54h);
            writer.Write(this.DataCRC);
            writer.Write(this.Unknown_5Ch);
            writer.Write(this.BonesCount);
            writer.Write(this.ChildrenIndicesCount);
            writer.Write(this.Unknown_62h);
            writer.Write(this.Unknown_64h);
            writer.Write(this.Unknown_68h);
            writer.Write(this.Unknown_6Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (BoneMap != null) list.Add(BoneMap);
            if (Bones != null) list.Add(Bones);
            if (TransformationsInverted != null) list.Add(TransformationsInverted);
            if (Transformations != null) list.Add(Transformations);
            if (ParentIndices != null) list.Add(ParentIndices);
            if (ChildrenIndices != null) list.Add(ChildrenIndices);
            return list.ToArray();
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(0x10, BoneMap)
            };
        }
    }
}
