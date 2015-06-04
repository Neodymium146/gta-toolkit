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
using RageLib.Resources.GTA5.PC.Bounds;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Fragments
{
    public class FragPhysicsLOD_GTA5_pc: ResourceSystemBlock
	{
		public override long Length
		{
			get { return 304; }
		}

		// structure data
		public uint VFT;
		public uint Unknown_4h;
		public uint Unknown_8h;
		public uint Unknown_Ch;
		public uint Unknown_10h;
		public uint Unknown_14h;
		public uint Unknown_18h;
		public uint Unknown_1Ch;
		public ulong Unknown_20h_Pointer;
		public ulong Unknown_28h_Pointer;
		public uint Unknown_30h;
		public uint Unknown_34h;
		public uint Unknown_38h;
		public uint Unknown_3Ch;
		public uint Unknown_40h;
		public uint Unknown_44h;
		public uint Unknown_48h;
		public uint Unknown_4Ch;
		public uint Unknown_50h;
		public uint Unknown_54h;
		public uint Unknown_58h;
		public uint Unknown_5Ch;
		public uint Unknown_60h;
		public uint Unknown_64h;
		public uint Unknown_68h;
		public uint Unknown_6Ch;
		public uint Unknown_70h;
		public uint Unknown_74h;
		public uint Unknown_78h;
		public uint Unknown_7Ch;
		public uint Unknown_80h;
		public uint Unknown_84h;
		public uint Unknown_88h;
		public uint Unknown_8Ch;
		public uint Unknown_90h;
		public uint Unknown_94h;
		public uint Unknown_98h;
		public uint Unknown_9Ch;
		public uint Unknown_A0h;
		public uint Unknown_A4h;
		public uint Unknown_A8h;
		public uint Unknown_ACh;
		public uint Unknown_B0h;
		public uint Unknown_B4h;
		public uint Unknown_B8h;
		public uint Unknown_BCh;
		public ulong GroupNamesPointer;
		public ulong GroupsPointer;
		public ulong ChildrenPointer;
		public ulong Unknown_D8h_Pointer;
		public ulong Unknown_E0h_Pointer;
		public ulong Unknown_E8h_Pointer;
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
		public byte Unknown_11Fh;
		public uint Unknown_120h;
		public uint Unknown_124h;
		public uint Unknown_128h;
		public uint Unknown_12Ch;

		// reference data
		public Unknown_F_030 Unknown_20h_Data;
		public ResourceSimpleArray<uint_r> Unknown_28h_Data;
		public ResourcePointerArray64<FragTypeGroup_GTA5_pc> Groups;
		public ResourcePointerArray64<FragTypeChild_GTA5_pc> Children;
		public Archetype_GTA5_pc Unknown_D8h_Data;
		public Archetype_GTA5_pc Unknown_E0h_Data;
		public Bound_GTA5_pc Unknown_E8h_Data;
		public ResourceSimpleArray<RAGE_Vector4> Unknown_F0h_Data;
		public ResourceSimpleArray<RAGE_Vector4> Unknown_F8h_Data;
		public Unknown_F_002 Unknown_100h_Data;
		public ResourceSimpleArray<byte_r> Unknown_108h_Data;
		public ResourceSimpleArray<byte_r> Unknown_110h_Data;
		public ResourcePointerArray64<fragNameStruct_GTA5_pc> GroupNames;

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
			this.Unknown_20h_Pointer = reader.ReadUInt64();
			this.Unknown_28h_Pointer = reader.ReadUInt64();
			this.Unknown_30h = reader.ReadUInt32();
			this.Unknown_34h = reader.ReadUInt32();
			this.Unknown_38h = reader.ReadUInt32();
			this.Unknown_3Ch = reader.ReadUInt32();
			this.Unknown_40h = reader.ReadUInt32();
			this.Unknown_44h = reader.ReadUInt32();
			this.Unknown_48h = reader.ReadUInt32();
			this.Unknown_4Ch = reader.ReadUInt32();
			this.Unknown_50h = reader.ReadUInt32();
			this.Unknown_54h = reader.ReadUInt32();
			this.Unknown_58h = reader.ReadUInt32();
			this.Unknown_5Ch = reader.ReadUInt32();
			this.Unknown_60h = reader.ReadUInt32();
			this.Unknown_64h = reader.ReadUInt32();
			this.Unknown_68h = reader.ReadUInt32();
			this.Unknown_6Ch = reader.ReadUInt32();
			this.Unknown_70h = reader.ReadUInt32();
			this.Unknown_74h = reader.ReadUInt32();
			this.Unknown_78h = reader.ReadUInt32();
			this.Unknown_7Ch = reader.ReadUInt32();
			this.Unknown_80h = reader.ReadUInt32();
			this.Unknown_84h = reader.ReadUInt32();
			this.Unknown_88h = reader.ReadUInt32();
			this.Unknown_8Ch = reader.ReadUInt32();
			this.Unknown_90h = reader.ReadUInt32();
			this.Unknown_94h = reader.ReadUInt32();
			this.Unknown_98h = reader.ReadUInt32();
			this.Unknown_9Ch = reader.ReadUInt32();
			this.Unknown_A0h = reader.ReadUInt32();
			this.Unknown_A4h = reader.ReadUInt32();
			this.Unknown_A8h = reader.ReadUInt32();
			this.Unknown_ACh = reader.ReadUInt32();
			this.Unknown_B0h = reader.ReadUInt32();
			this.Unknown_B4h = reader.ReadUInt32();
			this.Unknown_B8h = reader.ReadUInt32();
			this.Unknown_BCh = reader.ReadUInt32();
			this.GroupNamesPointer = reader.ReadUInt64();
			this.GroupsPointer = reader.ReadUInt64();
			this.ChildrenPointer = reader.ReadUInt64();
			this.Unknown_D8h_Pointer = reader.ReadUInt64();
			this.Unknown_E0h_Pointer = reader.ReadUInt64();
			this.Unknown_E8h_Pointer = reader.ReadUInt64();
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
			this.Unknown_20h_Data = reader.ReadBlockAt<Unknown_F_030>(
				this.Unknown_20h_Pointer // offset
			);
			this.Unknown_28h_Data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(
				this.Unknown_28h_Pointer, // offset
				this.ChildrenCount
			);
			this.Groups = reader.ReadBlockAt<ResourcePointerArray64<FragTypeGroup_GTA5_pc>>(
				this.GroupsPointer, // offset
				this.GroupsCount
			);
			this.Children = reader.ReadBlockAt<ResourcePointerArray64<FragTypeChild_GTA5_pc>>(
				this.ChildrenPointer, // offset
				this.ChildrenCount
			);
			this.Unknown_D8h_Data = reader.ReadBlockAt<Archetype_GTA5_pc>(
				this.Unknown_D8h_Pointer // offset
			);
			this.Unknown_E0h_Data = reader.ReadBlockAt<Archetype_GTA5_pc>(
				this.Unknown_E0h_Pointer // offset
			);
			this.Unknown_E8h_Data = reader.ReadBlockAt<Bound_GTA5_pc>(
				this.Unknown_E8h_Pointer // offset
			);
			this.Unknown_F0h_Data = reader.ReadBlockAt<ResourceSimpleArray<RAGE_Vector4>>(
				this.Unknown_F0h_Pointer, // offset
				this.ChildrenCount
			);
			this.Unknown_F8h_Data = reader.ReadBlockAt<ResourceSimpleArray<RAGE_Vector4>>(
				this.Unknown_F8h_Pointer, // offset
				this.ChildrenCount
			);
			this.Unknown_100h_Data = reader.ReadBlockAt<Unknown_F_002>(
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
			this.GroupNames = reader.ReadBlockAt<ResourcePointerArray64<fragNameStruct_GTA5_pc>>(
				this.GroupNamesPointer, // offset
				this.GroupsCount
			);
		}

		/// <summary>
		/// Writes the data-block to a stream.
		/// </summary>
		public override void Write(ResourceDataWriter writer, params object[] parameters)
		{
			// update structure data
			this.Unknown_20h_Pointer = (ulong)(this.Unknown_20h_Data != null ? this.Unknown_20h_Data.Position : 0);
			this.Unknown_28h_Pointer = (ulong)(this.Unknown_28h_Data != null ? this.Unknown_28h_Data.Position : 0);
			this.GroupNamesPointer = (ulong)(this.GroupNames != null ? this.GroupNames.Position : 0);
			this.GroupsPointer = (ulong)(this.Groups != null ? this.Groups.Position : 0);
			this.ChildrenPointer = (ulong)(this.Children != null ? this.Children.Position : 0);
			this.Unknown_D8h_Pointer = (ulong)(this.Unknown_D8h_Data != null ? this.Unknown_D8h_Data.Position : 0);
			this.Unknown_E0h_Pointer = (ulong)(this.Unknown_E0h_Data != null ? this.Unknown_E0h_Data.Position : 0);
			this.Unknown_E8h_Pointer = (ulong)(this.Unknown_E8h_Data != null ? this.Unknown_E8h_Data.Position : 0);
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
			writer.Write(this.Unknown_20h_Pointer);
			writer.Write(this.Unknown_28h_Pointer);
			writer.Write(this.Unknown_30h);
			writer.Write(this.Unknown_34h);
			writer.Write(this.Unknown_38h);
			writer.Write(this.Unknown_3Ch);
			writer.Write(this.Unknown_40h);
			writer.Write(this.Unknown_44h);
			writer.Write(this.Unknown_48h);
			writer.Write(this.Unknown_4Ch);
			writer.Write(this.Unknown_50h);
			writer.Write(this.Unknown_54h);
			writer.Write(this.Unknown_58h);
			writer.Write(this.Unknown_5Ch);
			writer.Write(this.Unknown_60h);
			writer.Write(this.Unknown_64h);
			writer.Write(this.Unknown_68h);
			writer.Write(this.Unknown_6Ch);
			writer.Write(this.Unknown_70h);
			writer.Write(this.Unknown_74h);
			writer.Write(this.Unknown_78h);
			writer.Write(this.Unknown_7Ch);
			writer.Write(this.Unknown_80h);
			writer.Write(this.Unknown_84h);
			writer.Write(this.Unknown_88h);
			writer.Write(this.Unknown_8Ch);
			writer.Write(this.Unknown_90h);
			writer.Write(this.Unknown_94h);
			writer.Write(this.Unknown_98h);
			writer.Write(this.Unknown_9Ch);
			writer.Write(this.Unknown_A0h);
			writer.Write(this.Unknown_A4h);
			writer.Write(this.Unknown_A8h);
			writer.Write(this.Unknown_ACh);
			writer.Write(this.Unknown_B0h);
			writer.Write(this.Unknown_B4h);
			writer.Write(this.Unknown_B8h);
			writer.Write(this.Unknown_BCh);
			writer.Write(this.GroupNamesPointer);
			writer.Write(this.GroupsPointer);
			writer.Write(this.ChildrenPointer);
			writer.Write(this.Unknown_D8h_Pointer);
			writer.Write(this.Unknown_E0h_Pointer);
			writer.Write(this.Unknown_E8h_Pointer);
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
			if (Unknown_20h_Data != null) list.Add(Unknown_20h_Data);
			if (Unknown_28h_Data != null) list.Add(Unknown_28h_Data);
			if (Groups != null) list.Add(Groups);
			if (Children != null) list.Add(Children);
			if (Unknown_D8h_Data != null) list.Add(Unknown_D8h_Data);
			if (Unknown_E0h_Data != null) list.Add(Unknown_E0h_Data);
			if (Unknown_E8h_Data != null) list.Add(Unknown_E8h_Data);
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
