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

namespace RageLib.Resources.GTA5.PC.Drawables
{
    // crSkeletonData
    public class SkeletonData : ResourceSystemBlock
    {
        public override long Length => 0x70;

        // structure data
        public uint VFT;
        public uint Unknown_4h; // 0x00000001
        public uint Unknown_8h; // 0x00000000
        public uint Unknown_Ch; // 0x00000000
        public ulong Unknown_10h_Pointer;
        public ushort Count1;
        public ushort Count2;
        public uint Unknown_1Ch;
        public ulong BonesPointer;
        public ulong TransformationsInvertedPointer;
        public ulong TransformationsPointer;
        public ulong ParentIndicesPointer;
        public ulong Unknown_40h_Pointer;
        public uint Unknown_48h; // 0x00000000
        public uint Unknown_4Ch; // 0x00000000
        public uint Unknown_50h;
        public uint Unknown_54h;
        public uint Unknown_58h;
        public ushort Unknown_5Ch; // 0x0001
        public ushort BonesCount;
        public ushort Count4;
        public ushort Unknown_62h; // 0x0000
        public uint Unknown_64h; // 0x00000000
        public uint Unknown_68h; // 0x00000000
        public uint Unknown_6Ch; // 0x00000000

        // reference data
        public ResourcePointerArray64<Unknown_D_001> Unknown_10h_Data; // some map
        public ResourceSimpleArray<Bone> Bones;
        public ResourceSimpleArray<RAGE_Matrix4> TransformationsInverted;
        public ResourceSimpleArray<RAGE_Matrix4> Transformations;
        public ResourceSimpleArray<ushort_r> ParentIndices;
        public ResourceSimpleArray<ushort_r> Unknown_40h_Data;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.VFT = reader.ReadUInt32();
            this.Unknown_4h = reader.ReadUInt32();
            this.Unknown_8h = reader.ReadUInt32();
            this.Unknown_Ch = reader.ReadUInt32();
            this.Unknown_10h_Pointer = reader.ReadUInt64();
            this.Count1 = reader.ReadUInt16();
            this.Count2 = reader.ReadUInt16();
            this.Unknown_1Ch = reader.ReadUInt32();
            this.BonesPointer = reader.ReadUInt64();
            this.TransformationsInvertedPointer = reader.ReadUInt64();
            this.TransformationsPointer = reader.ReadUInt64();
            this.ParentIndicesPointer = reader.ReadUInt64();
            this.Unknown_40h_Pointer = reader.ReadUInt64();
            this.Unknown_48h = reader.ReadUInt32();
            this.Unknown_4Ch = reader.ReadUInt32();
            this.Unknown_50h = reader.ReadUInt32();
            this.Unknown_54h = reader.ReadUInt32();
            this.Unknown_58h = reader.ReadUInt32();
            this.Unknown_5Ch = reader.ReadUInt16();
            this.BonesCount = reader.ReadUInt16();
            this.Count4 = reader.ReadUInt16();
            this.Unknown_62h = reader.ReadUInt16();
            this.Unknown_64h = reader.ReadUInt32();
            this.Unknown_68h = reader.ReadUInt32();
            this.Unknown_6Ch = reader.ReadUInt32();

            // read reference data
            this.Unknown_10h_Data = reader.ReadBlockAt<ResourcePointerArray64<Unknown_D_001>>(
                this.Unknown_10h_Pointer, // offset
                this.Count1
            );
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
            this.Unknown_40h_Data = reader.ReadBlockAt<ResourceSimpleArray<ushort_r>>(
                this.Unknown_40h_Pointer, // offset
                this.Count4
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.Unknown_10h_Pointer = (ulong)(this.Unknown_10h_Data != null ? this.Unknown_10h_Data.Position : 0);
            this.Count1 = (ushort)(this.Unknown_10h_Data?.Count ?? 0);
            if (this.Unknown_10h_Data != null)
            {
                int i = 0;
                foreach (var x in this.Unknown_10h_Data.data_items)
                {
                    if (x != null)
                    {
                        var y = x;
                        do
                        {
                            i++;
                            if (y.Next != null)
                            {
                                y = y.Next;
                            }
                            else
                            {
                                break;
                            }
                        } while (true);
                    }
                }
                this.Count2 = (ushort)i;
            }
            else
            {
                this.Count2 = 0;
            }
            this.BonesPointer = (ulong)(this.Bones != null ? this.Bones.Position : 0);
            this.TransformationsInvertedPointer = (ulong)(this.TransformationsInverted != null ? this.TransformationsInverted.Position : 0);
            this.TransformationsPointer = (ulong)(this.Transformations != null ? this.Transformations.Position : 0);
            this.ParentIndicesPointer = (ulong)(this.ParentIndices != null ? this.ParentIndices.Position : 0);
            this.Unknown_40h_Pointer = (ulong)(this.Unknown_40h_Data != null ? this.Unknown_40h_Data.Position : 0);
            this.BonesCount = (ushort)(this.Bones?.Count ?? 0);
            this.Count4 = (ushort)(this.Unknown_40h_Data != null ? this.Unknown_40h_Data.Count : 0);

            // write structure data
            writer.Write(this.VFT);
            writer.Write(this.Unknown_4h);
            writer.Write(this.Unknown_8h);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.Unknown_10h_Pointer);
            writer.Write(this.Count1);
            writer.Write(this.Count2);
            writer.Write(this.Unknown_1Ch);
            writer.Write(this.BonesPointer);
            writer.Write(this.TransformationsInvertedPointer);
            writer.Write(this.TransformationsPointer);
            writer.Write(this.ParentIndicesPointer);
            writer.Write(this.Unknown_40h_Pointer);
            writer.Write(this.Unknown_48h);
            writer.Write(this.Unknown_4Ch);
            writer.Write(this.Unknown_50h);
            writer.Write(this.Unknown_54h);
            writer.Write(this.Unknown_58h);
            writer.Write(this.Unknown_5Ch);
            writer.Write(this.BonesCount);
            writer.Write(this.Count4);
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
            if (Unknown_10h_Data != null) list.Add(Unknown_10h_Data);
            if (Bones != null) list.Add(Bones);
            if (TransformationsInverted != null) list.Add(TransformationsInverted);
            if (Transformations != null) list.Add(Transformations);
            if (ParentIndices != null) list.Add(ParentIndices);
            if (Unknown_40h_Data != null) list.Add(Unknown_40h_Data);
            return list.ToArray();
        }
    }
}
