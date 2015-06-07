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

using RageLib.Resources.Common;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Drawables
{
    public class Skeleton_GTA5_pc : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 112; }
        }

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
        public ulong Unknown_28h_Pointer;
        public ulong Unknown_30h_Pointer;
        public ulong Unknown_38h_Pointer;
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
        public ResourcePointerArray64<Unknown_D_001> Unknown_10h_Data;
        public ResourceSimpleArray<Bone_GTA5_pc> Bones;
        public ResourceSimpleArray<RAGE_Matrix4> Unknown_28h_Data;
        public ResourceSimpleArray<RAGE_Matrix4> Unknown_30h_Data;
        public ResourceSimpleArray<ushort_r> Unknown_38h_Data;
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
            this.Unknown_28h_Pointer = reader.ReadUInt64();
            this.Unknown_30h_Pointer = reader.ReadUInt64();
            this.Unknown_38h_Pointer = reader.ReadUInt64();
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
            this.Bones = reader.ReadBlockAt<ResourceSimpleArray<Bone_GTA5_pc>>(
                this.BonesPointer, // offset
                this.BonesCount
            );
            this.Unknown_28h_Data = reader.ReadBlockAt<ResourceSimpleArray<RAGE_Matrix4>>(
                this.Unknown_28h_Pointer, // offset
                this.BonesCount
            );
            this.Unknown_30h_Data = reader.ReadBlockAt<ResourceSimpleArray<RAGE_Matrix4>>(
                this.Unknown_30h_Pointer, // offset
                this.BonesCount
            );
            this.Unknown_38h_Data = reader.ReadBlockAt<ResourceSimpleArray<ushort_r>>(
                this.Unknown_38h_Pointer, // offset
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
            //	this.c1 = (ushort)(this.arr1 != null ? this.arr1.Count : 0);
            this.BonesPointer = (ulong)(this.Bones != null ? this.Bones.Position : 0);
            this.Unknown_28h_Pointer = (ulong)(this.Unknown_28h_Data != null ? this.Unknown_28h_Data.Position : 0);
            this.Unknown_30h_Pointer = (ulong)(this.Unknown_30h_Data != null ? this.Unknown_30h_Data.Position : 0);
            this.Unknown_38h_Pointer = (ulong)(this.Unknown_38h_Data != null ? this.Unknown_38h_Data.Position : 0);
            this.Unknown_40h_Pointer = (ulong)(this.Unknown_40h_Data != null ? this.Unknown_40h_Data.Position : 0);
            //	this.c3 = (ushort)(this.Bones != null ? this.Bones.Count : 0);
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
            writer.Write(this.Unknown_28h_Pointer);
            writer.Write(this.Unknown_30h_Pointer);
            writer.Write(this.Unknown_38h_Pointer);
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
            if (Unknown_28h_Data != null) list.Add(Unknown_28h_Data);
            if (Unknown_30h_Data != null) list.Add(Unknown_30h_Data);
            if (Unknown_38h_Data != null) list.Add(Unknown_38h_Data);
            if (Unknown_40h_Data != null) list.Add(Unknown_40h_Data);
            return list.ToArray();
        }

    }
}