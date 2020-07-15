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

using System;
using System.Collections.Generic;
using System.Numerics;
using RageLib.GTA5.Resources.PC.Drawables;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Drawables
{
    // pgBase
    // crSkeletonData
    public class SkeletonData : PgBase64
    {
        public override long BlockLength => 0x70;

        // structure data
        public AtHashMap<uint_r> BoneMap;
        public ulong BoneDataPointer; // why this points to the array directly ?
        public ulong TransformationsInvertedPointer;
        public ulong TransformationsPointer;
        public ulong ParentIndicesPointer;
        public ulong ChildrenIndicesPointer;
        public ulong Unknown_48h; // 0x0000000000000000
        public uint Unknown_50h;
        public uint Unknown_54h;
        public uint DataCRC;
        public ushort Unknown_5Ch; // 0x0001
        public ushort BonesCount;
        public ushort ChildrenIndicesCount;
        public ushort Unknown_62h; // 0x0000
        public uint Unknown_64h; // 0x00000000
        public ulong Unknown_68h; // 0x0000000000000000

        // reference data
        public BoneData BoneData;
        public SimpleArray<Matrix4x4> TransformationsInverted;
        public SimpleArray<Matrix4x4> Transformations;
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
            this.BoneDataPointer = reader.ReadUInt64();
            this.TransformationsInvertedPointer = reader.ReadUInt64();
            this.TransformationsPointer = reader.ReadUInt64();
            this.ParentIndicesPointer = reader.ReadUInt64();
            this.ChildrenIndicesPointer = reader.ReadUInt64();
            this.Unknown_48h = reader.ReadUInt64();
            this.Unknown_50h = reader.ReadUInt32();
            this.Unknown_54h = reader.ReadUInt32();
            this.DataCRC = reader.ReadUInt32();
            this.Unknown_5Ch = reader.ReadUInt16();
            this.BonesCount = reader.ReadUInt16();
            this.ChildrenIndicesCount = reader.ReadUInt16();
            this.Unknown_62h = reader.ReadUInt16();
            this.Unknown_64h = reader.ReadUInt32();
            this.Unknown_68h = reader.ReadUInt64();

            // read reference data
            this.BoneData = reader.ReadBlockAt<BoneData>(
                this.BoneDataPointer - 16, // offset
                this.BonesCount
            );
            this.TransformationsInverted = reader.ReadBlockAt<SimpleArray<Matrix4x4>>(
                this.TransformationsInvertedPointer, // offset
                this.BonesCount
            );
            this.Transformations = reader.ReadBlockAt<SimpleArray<Matrix4x4>>(
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
            this.BoneDataPointer = (ulong)(this.BoneData != null ? this.BoneData.BlockPosition + 16 : 0);
            this.TransformationsInvertedPointer = (ulong)(this.TransformationsInverted != null ? this.TransformationsInverted.BlockPosition : 0);
            this.TransformationsPointer = (ulong)(this.Transformations != null ? this.Transformations.BlockPosition : 0);
            this.ParentIndicesPointer = (ulong)(this.ParentIndices != null ? this.ParentIndices.BlockPosition : 0);
            this.ChildrenIndicesPointer = (ulong)(this.ChildrenIndices != null ? this.ChildrenIndices.BlockPosition : 0);
            this.BonesCount = (ushort)(this.BoneData?.BonesCount ?? 0);
            this.ChildrenIndicesCount = (ushort)(this.ChildrenIndices != null ? this.ChildrenIndices.Count : 0);

            // write structure data
            writer.WriteBlock(this.BoneMap);
            writer.Write(this.BoneDataPointer);
            writer.Write(this.TransformationsInvertedPointer);
            writer.Write(this.TransformationsPointer);
            writer.Write(this.ParentIndicesPointer);
            writer.Write(this.ChildrenIndicesPointer);
            writer.Write(this.Unknown_48h);
            writer.Write(this.Unknown_50h);
            writer.Write(this.Unknown_54h);
            writer.Write(this.DataCRC);
            writer.Write(this.Unknown_5Ch);
            writer.Write(this.BonesCount);
            writer.Write(this.ChildrenIndicesCount);
            writer.Write(this.Unknown_62h);
            writer.Write(this.Unknown_64h);
            writer.Write(this.Unknown_68h);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>(base.GetReferences());
            if (BoneData != null) list.Add(BoneData);
            if (TransformationsInverted != null) list.Add(TransformationsInverted);
            if (Transformations != null) list.Add(Transformations);
            if (ParentIndices != null) list.Add(ParentIndices);
            if (ChildrenIndices != null) list.Add(ChildrenIndices);
            return list.ToArray();
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            var list = new List<Tuple<long, IResourceBlock>>(base.GetParts());
            list.AddRange(new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(0x10, BoneMap)
            });
            return list.ToArray();
        }

        public override void Update()
        {
            UpdateBoneIds();
            UpdateBoneMap();
        }

        private void UpdateBoneIds()
        {
            if (BoneData == null)
                return;

            foreach (var bone in BoneData.Bones)
            {
                // id of root bone seems to always be 0 
                if (bone.ParentIndex == ushort.MaxValue)
                {
                    bone.BoneId = 0;
                    continue;
                }

                string name = bone.Name?.Value;

                if (string.IsNullOrEmpty(name))
                    bone.BoneId = 0;
                else
                    bone.BoneId = Enum.TryParse(name, false, out PedBoneId id) ? (ushort)id : Bone.CalculateBoneIdFromName(name);
            }
        }

        private void UpdateBoneMap()
        {
            if (BoneData == null)
                return;

            List<KeyValuePair<uint, uint_r>> bonesIndexId = new List<KeyValuePair<uint, uint_r>>((int)BoneData.BonesCount);

            foreach (var bone in BoneData.Bones)
                bonesIndexId.Add(new KeyValuePair<uint, uint_r>(bone.BoneId, (uint_r)bone.Index));

            BoneMap = new AtHashMap<uint_r>(bonesIndexId);
        }
    }
}
