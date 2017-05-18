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
using RageLib.Resources.GTA5.PC.Bounds;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Fragments
{
    // pgBase
    // fragPhysicsLOD
    public class FragPhysicsLOD : ResourceSystemBlock
    {
        public override long Length => 0x130;

        // structure data
        public uint VFT;
        public uint Unknown_4h; // 0x00000001
        public uint Unknown_8h; // 0x00000000
        public uint Unknown_Ch; // 0x00000000
        public uint Unknown_10h; // 0x00000000
        public uint Unknown_14h;
        public uint Unknown_18h;
        public uint Unknown_1Ch;
        public ulong ArticulatedBodyTypePointer;
        public ulong Unknown_28h_Pointer;
        public RAGE_Vector4 Unknown_30h;
        public RAGE_Vector4 Unknown_40h;
        public RAGE_Vector4 Unknown_50h;
        public RAGE_Vector4 Unknown_60h;
        public RAGE_Vector4 Unknown_70h;
        public RAGE_Vector4 Unknown_80h;
        public RAGE_Vector4 Unknown_90h;
        public RAGE_Vector4 Unknown_A0h;
        public RAGE_Vector4 Unknown_B0h;
        public ulong GroupNamesPointer;
        public ulong GroupsPointer;
        public ulong ChildrenPointer;
        public ulong Archetype1Pointer;
        public ulong Archetype2Pointer;
        public ulong BoundPointer;
        public ulong Unknown_F0h_Pointer;
        public ulong Unknown_F8h_Pointer;
        public ulong Unknown_100h_Pointer;
        public ulong Unknown_108h_Pointer;
        public ulong Unknown_110h_Pointer;
        public byte Count1;
        public byte Count2;
        public byte GroupsCount;
        public byte Unknown_11Bh;
        public byte Unknown_11Ch;
        public byte ChildrenCount;
        public byte Count3;
        public byte Unknown_11Fh; // 0x00
        public uint Unknown_120h; // 0x00000000
        public uint Unknown_124h; // 0x00000000
        public uint Unknown_128h; // 0x00000000
        public uint Unknown_12Ch; // 0x00000000

        // reference data
        public ArticulatedBodyType ArticulatedBodyType;
        public ResourceSimpleArray<uint_r> Unknown_28h_Data;
        public ResourcePointerArray64<fragNameStruct> GroupNames;
        public ResourcePointerArray64<FragTypeGroup> Groups;
        public ResourcePointerArray64<FragTypeChild> Children;
        public Archetype Archetype1;
        public Archetype Archetype2;
        public Bound Bound;
        public ResourceSimpleArray<RAGE_Vector4> Unknown_F0h_Data;
        public ResourceSimpleArray<RAGE_Vector4> Unknown_F8h_Data;
        public Unknown_F_001 Unknown_100h_Data;
        public ResourceSimpleArray<byte_r> Unknown_108h_Data;
        public ResourceSimpleArray<byte_r> Unknown_110h_Data;

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
            this.Unknown_10h = reader.ReadUInt32();
            this.Unknown_14h = reader.ReadUInt32();
            this.Unknown_18h = reader.ReadUInt32();
            this.Unknown_1Ch = reader.ReadUInt32();
            this.ArticulatedBodyTypePointer = reader.ReadUInt64();
            this.Unknown_28h_Pointer = reader.ReadUInt64();
            this.Unknown_30h = reader.ReadBlock<RAGE_Vector4>();
            this.Unknown_40h = reader.ReadBlock<RAGE_Vector4>();
            this.Unknown_50h = reader.ReadBlock<RAGE_Vector4>();
            this.Unknown_60h = reader.ReadBlock<RAGE_Vector4>();
            this.Unknown_70h = reader.ReadBlock<RAGE_Vector4>();
            this.Unknown_80h = reader.ReadBlock<RAGE_Vector4>();
            this.Unknown_90h = reader.ReadBlock<RAGE_Vector4>();
            this.Unknown_A0h = reader.ReadBlock<RAGE_Vector4>();
            this.Unknown_B0h = reader.ReadBlock<RAGE_Vector4>();
            this.GroupNamesPointer = reader.ReadUInt64();
            this.GroupsPointer = reader.ReadUInt64();
            this.ChildrenPointer = reader.ReadUInt64();
            this.Archetype1Pointer = reader.ReadUInt64();
            this.Archetype2Pointer = reader.ReadUInt64();
            this.BoundPointer = reader.ReadUInt64();
            this.Unknown_F0h_Pointer = reader.ReadUInt64();
            this.Unknown_F8h_Pointer = reader.ReadUInt64();
            this.Unknown_100h_Pointer = reader.ReadUInt64();
            this.Unknown_108h_Pointer = reader.ReadUInt64();
            this.Unknown_110h_Pointer = reader.ReadUInt64();
            this.Count1 = reader.ReadByte();
            this.Count2 = reader.ReadByte();
            this.GroupsCount = reader.ReadByte();
            this.Unknown_11Bh = reader.ReadByte();
            this.Unknown_11Ch = reader.ReadByte();
            this.ChildrenCount = reader.ReadByte();
            this.Count3 = reader.ReadByte();
            this.Unknown_11Fh = reader.ReadByte();
            this.Unknown_120h = reader.ReadUInt32();
            this.Unknown_124h = reader.ReadUInt32();
            this.Unknown_128h = reader.ReadUInt32();
            this.Unknown_12Ch = reader.ReadUInt32();

            // read reference data
            this.ArticulatedBodyType = reader.ReadBlockAt<ArticulatedBodyType>(
                this.ArticulatedBodyTypePointer // offset
            );
            this.Unknown_28h_Data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(
                this.Unknown_28h_Pointer, // offset
                this.ChildrenCount
            );
            this.GroupNames = reader.ReadBlockAt<ResourcePointerArray64<fragNameStruct>>(
                this.GroupNamesPointer, // offset
                this.GroupsCount
            );
            this.Groups = reader.ReadBlockAt<ResourcePointerArray64<FragTypeGroup>>(
                this.GroupsPointer, // offset
                this.GroupsCount
            );
            this.Children = reader.ReadBlockAt<ResourcePointerArray64<FragTypeChild>>(
                this.ChildrenPointer, // offset
                this.ChildrenCount
            );
            this.Archetype1 = reader.ReadBlockAt<Archetype>(
                this.Archetype1Pointer // offset
            );
            this.Archetype2 = reader.ReadBlockAt<Archetype>(
                this.Archetype2Pointer // offset
            );
            this.Bound = reader.ReadBlockAt<Bound>(
                this.BoundPointer // offset
            );
            this.Unknown_F0h_Data = reader.ReadBlockAt<ResourceSimpleArray<RAGE_Vector4>>(
                this.Unknown_F0h_Pointer, // offset
                this.ChildrenCount
            );
            this.Unknown_F8h_Data = reader.ReadBlockAt<ResourceSimpleArray<RAGE_Vector4>>(
                this.Unknown_F8h_Pointer, // offset
                this.ChildrenCount
            );
            this.Unknown_100h_Data = reader.ReadBlockAt<Unknown_F_001>(
                this.Unknown_100h_Pointer // offset
            );
            this.Unknown_108h_Data = reader.ReadBlockAt<ResourceSimpleArray<byte_r>>(
                this.Unknown_108h_Pointer, // offset
                this.Count1
            );
            this.Unknown_110h_Data = reader.ReadBlockAt<ResourceSimpleArray<byte_r>>(
                this.Unknown_110h_Pointer, // offset
                this.Count2
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.ArticulatedBodyTypePointer = (ulong)(this.ArticulatedBodyType != null ? this.ArticulatedBodyType.Position : 0);
            this.Unknown_28h_Pointer = (ulong)(this.Unknown_28h_Data != null ? this.Unknown_28h_Data.Position : 0);
            this.GroupNamesPointer = (ulong)(this.GroupNames != null ? this.GroupNames.Position : 0);
            this.GroupsPointer = (ulong)(this.Groups != null ? this.Groups.Position : 0);
            this.ChildrenPointer = (ulong)(this.Children != null ? this.Children.Position : 0);
            this.Archetype1Pointer = (ulong)(this.Archetype1 != null ? this.Archetype1.Position : 0);
            this.Archetype2Pointer = (ulong)(this.Archetype2 != null ? this.Archetype2.Position : 0);
            this.BoundPointer = (ulong)(this.Bound != null ? this.Bound.Position : 0);
            this.Unknown_F0h_Pointer = (ulong)(this.Unknown_F0h_Data != null ? this.Unknown_F0h_Data.Position : 0);
            this.Unknown_F8h_Pointer = (ulong)(this.Unknown_F8h_Data != null ? this.Unknown_F8h_Data.Position : 0);
            this.Unknown_100h_Pointer = (ulong)(this.Unknown_100h_Data != null ? this.Unknown_100h_Data.Position : 0);
            this.Unknown_108h_Pointer = (ulong)(this.Unknown_108h_Data != null ? this.Unknown_108h_Data.Position : 0);
            this.Unknown_110h_Pointer = (ulong)(this.Unknown_110h_Data != null ? this.Unknown_110h_Data.Position : 0);
            //this.vvv1 = (byte)(this.pxxxxx_2data != null ? this.pxxxxx_2data.Count : 0);
            //this.vvv2 = (byte)(this.pxxxxx_3data != null ? this.pxxxxx_3data.Count : 0);
            //this.GroupsCount = (byte)(this.Groups != null ? this.Groups.Count : 0);
            //this.ChildrenCount = (byte)(this.p1data != null ? this.p1data.Count : 0);

            // write structure data
            writer.Write(this.VFT);
            writer.Write(this.Unknown_4h);
            writer.Write(this.Unknown_8h);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.Write(this.Unknown_18h);
            writer.Write(this.Unknown_1Ch);
            writer.Write(this.ArticulatedBodyTypePointer);
            writer.Write(this.Unknown_28h_Pointer);
            writer.WriteBlock(this.Unknown_30h);
            writer.WriteBlock(this.Unknown_40h);
            writer.WriteBlock(this.Unknown_50h);
            writer.WriteBlock(this.Unknown_60h);
            writer.WriteBlock(this.Unknown_70h);
            writer.WriteBlock(this.Unknown_80h);
            writer.WriteBlock(this.Unknown_90h);
            writer.WriteBlock(this.Unknown_A0h);
            writer.WriteBlock(this.Unknown_B0h);
            writer.Write(this.GroupNamesPointer);
            writer.Write(this.GroupsPointer);
            writer.Write(this.ChildrenPointer);
            writer.Write(this.Archetype1Pointer);
            writer.Write(this.Archetype2Pointer);
            writer.Write(this.BoundPointer);
            writer.Write(this.Unknown_F0h_Pointer);
            writer.Write(this.Unknown_F8h_Pointer);
            writer.Write(this.Unknown_100h_Pointer);
            writer.Write(this.Unknown_108h_Pointer);
            writer.Write(this.Unknown_110h_Pointer);
            writer.Write(this.Count1);
            writer.Write(this.Count2);
            writer.Write(this.GroupsCount);
            writer.Write(this.Unknown_11Bh);
            writer.Write(this.Unknown_11Ch);
            writer.Write(this.ChildrenCount);
            writer.Write(this.Count3);
            writer.Write(this.Unknown_11Fh);
            writer.Write(this.Unknown_120h);
            writer.Write(this.Unknown_124h);
            writer.Write(this.Unknown_128h);
            writer.Write(this.Unknown_12Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (ArticulatedBodyType != null) list.Add(ArticulatedBodyType);
            if (Unknown_28h_Data != null) list.Add(Unknown_28h_Data);
            if (Groups != null) list.Add(Groups);
            if (Children != null) list.Add(Children);
            if (Archetype1 != null) list.Add(Archetype1);
            if (Archetype2 != null) list.Add(Archetype2);
            if (Bound != null) list.Add(Bound);
            if (Unknown_F0h_Data != null) list.Add(Unknown_F0h_Data);
            if (Unknown_F8h_Data != null) list.Add(Unknown_F8h_Data);
            if (Unknown_100h_Data != null) list.Add(Unknown_100h_Data);
            if (Unknown_108h_Data != null) list.Add(Unknown_108h_Data);
            if (Unknown_110h_Data != null) list.Add(Unknown_110h_Data);
            if (GroupNames != null) list.Add(GroupNames);
            return list.ToArray();
        }
    }
}
