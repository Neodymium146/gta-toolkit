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
using RageLib.Resources.GTA5.PC.Drawables;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Fragments
{
    public class FragDrawable_GTA5_pc: DrawableBase_GTA5_pc
	{
		public override long Length
		{
			get { return 336; }
		}

		// structure data
		public uint Unknown_B0h;
		public uint Unknown_B4h;
		public uint Unknown_B8h;
		public uint Unknown_BCh;
		public uint Unknown_C0h;
		public uint Unknown_C4h;
		public uint Unknown_C8h;
		public uint Unknown_CCh;
		public uint Unknown_D0h;
		public uint Unknown_D4h;
		public uint Unknown_D8h;
		public uint Unknown_DCh;
		public uint Unknown_E0h;
		public uint Unknown_E4h;
		public uint Unknown_E8h;
		public uint Unknown_ECh;
		public ulong BoundPointer;
		public ulong Unknown_F8h_Pointer;
		public ushort Count1;
		public ushort Count2;
		public uint Unknown_104h;
		public ulong Unknown_108h_Pointer;
		public ushort Count3;
		public ushort Count4;
		public uint Unknown_114h;
		public uint Unknown_118h;
		public uint Unknown_11Ch;
		public uint Unknown_120h;
		public uint Unknown_124h;
		public uint Unknown_128h;
		public uint Unknown_12Ch;
		public ulong NamePointer2;
		public uint Unknown_138h;
		public uint Unknown_13Ch;
		public uint Unknown_140h;
		public uint Unknown_144h;
		public uint Unknown_148h;
		public uint Unknown_14Ch;

		// reference data
		public Bound_GTA5_pc Bound;
		public ResourceSimpleArray<ulong_r> Unknown_F8h_Data;
		public ResourceSimpleArray<RAGE_Matrix4> Unknown_108h_Data;
		public string_r Name2;

		/// <summary>
		/// Reads the data-block from a stream.
		/// </summary>
		public override void Read(ResourceDataReader reader, params object[] parameters)
		{
			base.Read(reader, parameters);

			// read structure data
			this.Unknown_B0h = reader.ReadUInt32();
			this.Unknown_B4h = reader.ReadUInt32();
			this.Unknown_B8h = reader.ReadUInt32();
			this.Unknown_BCh = reader.ReadUInt32();
			this.Unknown_C0h = reader.ReadUInt32();
			this.Unknown_C4h = reader.ReadUInt32();
			this.Unknown_C8h = reader.ReadUInt32();
			this.Unknown_CCh = reader.ReadUInt32();
			this.Unknown_D0h = reader.ReadUInt32();
			this.Unknown_D4h = reader.ReadUInt32();
			this.Unknown_D8h = reader.ReadUInt32();
			this.Unknown_DCh = reader.ReadUInt32();
			this.Unknown_E0h = reader.ReadUInt32();
			this.Unknown_E4h = reader.ReadUInt32();
			this.Unknown_E8h = reader.ReadUInt32();
			this.Unknown_ECh = reader.ReadUInt32();
			this.BoundPointer = reader.ReadUInt64();
			this.Unknown_F8h_Pointer = reader.ReadUInt64();
			this.Count1 = reader.ReadUInt16();
			this.Count2 = reader.ReadUInt16();
			this.Unknown_104h = reader.ReadUInt32();
			this.Unknown_108h_Pointer = reader.ReadUInt64();
			this.Count3 = reader.ReadUInt16();
			this.Count4 = reader.ReadUInt16();
			this.Unknown_114h = reader.ReadUInt32();
			this.Unknown_118h = reader.ReadUInt32();
			this.Unknown_11Ch = reader.ReadUInt32();
			this.Unknown_120h = reader.ReadUInt32();
			this.Unknown_124h = reader.ReadUInt32();
			this.Unknown_128h = reader.ReadUInt32();
			this.Unknown_12Ch = reader.ReadUInt32();
			this.NamePointer2 = reader.ReadUInt64();
			this.Unknown_138h = reader.ReadUInt32();
			this.Unknown_13Ch = reader.ReadUInt32();
			this.Unknown_140h = reader.ReadUInt32();
			this.Unknown_144h = reader.ReadUInt32();
			this.Unknown_148h = reader.ReadUInt32();
			this.Unknown_14Ch = reader.ReadUInt32();

			// read reference data
			this.Bound = reader.ReadBlockAt<Bound_GTA5_pc>(
				this.BoundPointer // offset
			);
			this.Unknown_F8h_Data = reader.ReadBlockAt<ResourceSimpleArray<ulong_r>>(
				this.Unknown_F8h_Pointer, // offset
				this.Count1
			);
			this.Unknown_108h_Data = reader.ReadBlockAt<ResourceSimpleArray<RAGE_Matrix4>>(
				this.Unknown_108h_Pointer, // offset
				this.Count2
			);
			this.Name2 = reader.ReadBlockAt<string_r>(
				this.NamePointer2 // offset
			);
		}

		/// <summary>
		/// Writes the data-block to a stream.
		/// </summary>
		public override void Write(ResourceDataWriter writer, params object[] parameters)
		{
			base.Write(writer, parameters);

			// update structure data
			this.BoundPointer = (ulong)(this.Bound != null ? this.Bound.Position : 0);
			this.Unknown_F8h_Pointer = (ulong)(this.Unknown_F8h_Data != null ? this.Unknown_F8h_Data.Position : 0);
			//this.c1qqq = (ushort)(this.pxx2data != null ? this.pxx2data.Count : 0);
			//this.c2qqq = (ushort)(this.pxx3data != null ? this.pxx3data.Count : 0);
			this.Unknown_108h_Pointer = (ulong)(this.Unknown_108h_Data != null ? this.Unknown_108h_Data.Position : 0);
			this.NamePointer2 = (ulong)(this.Name2 != null ? this.Name2.Position : 0);

			// write structure data
			writer.Write(this.Unknown_B0h);
			writer.Write(this.Unknown_B4h);
			writer.Write(this.Unknown_B8h);
			writer.Write(this.Unknown_BCh);
			writer.Write(this.Unknown_C0h);
			writer.Write(this.Unknown_C4h);
			writer.Write(this.Unknown_C8h);
			writer.Write(this.Unknown_CCh);
			writer.Write(this.Unknown_D0h);
			writer.Write(this.Unknown_D4h);
			writer.Write(this.Unknown_D8h);
			writer.Write(this.Unknown_DCh);
			writer.Write(this.Unknown_E0h);
			writer.Write(this.Unknown_E4h);
			writer.Write(this.Unknown_E8h);
			writer.Write(this.Unknown_ECh);
			writer.Write(this.BoundPointer);
			writer.Write(this.Unknown_F8h_Pointer);
			writer.Write(this.Count1);
			writer.Write(this.Count2);
			writer.Write(this.Unknown_104h);
			writer.Write(this.Unknown_108h_Pointer);
			writer.Write(this.Count3);
			writer.Write(this.Count4);
			writer.Write(this.Unknown_114h);
			writer.Write(this.Unknown_118h);
			writer.Write(this.Unknown_11Ch);
			writer.Write(this.Unknown_120h);
			writer.Write(this.Unknown_124h);
			writer.Write(this.Unknown_128h);
			writer.Write(this.Unknown_12Ch);
			writer.Write(this.NamePointer2);
			writer.Write(this.Unknown_138h);
			writer.Write(this.Unknown_13Ch);
			writer.Write(this.Unknown_140h);
			writer.Write(this.Unknown_144h);
			writer.Write(this.Unknown_148h);
			writer.Write(this.Unknown_14Ch);
		}

		/// <summary>
		/// Returns a list of data blocks which are referenced by this block.
		/// </summary>
		public override IResourceBlock[] GetReferences()
		{
			var list = new List<IResourceBlock>(base.GetReferences());
			if (Bound != null) list.Add(Bound);
			if (Unknown_F8h_Data != null) list.Add(Unknown_F8h_Data);
			if (Unknown_108h_Data != null) list.Add(Unknown_108h_Data);
			if (Name2 != null) list.Add(Name2);
			return list.ToArray();
		}

	}
}
