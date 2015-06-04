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

using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Fragments
{
    public class Unknown_F_010: ResourceSystemBlock
	{
		public override long Length
		{
			get { return 128; }
		}

		// structure data
		public uint VFT;
		public uint Unknown_4h;
		public uint Unknown_8h;
		public uint Unknown_Ch;
		public ulong pxxxxx_0;
		public ulong pxxxxx_1;
		public ulong pxxxxx_2;
		public ulong pxxxxx_3;
		public ulong pxxxxx_4;
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

		// reference data
		public Unknown_F_009 pxxxxx_0data;
		public Unknown_F_008 pxxxxx_1data;
		public Unknown_F_005 pxxxxx_2data;
		public Unknown_F_005 pxxxxx_3data;
		public Unknown_F_005 pxxxxx_4data;

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
			this.pxxxxx_0 = reader.ReadUInt64();
			this.pxxxxx_1 = reader.ReadUInt64();
			this.pxxxxx_2 = reader.ReadUInt64();
			this.pxxxxx_3 = reader.ReadUInt64();
			this.pxxxxx_4 = reader.ReadUInt64();
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

			// read reference data
			this.pxxxxx_0data = reader.ReadBlockAt<Unknown_F_009>(
				this.pxxxxx_0 // offset
			);
			this.pxxxxx_1data = reader.ReadBlockAt<Unknown_F_008>(
				this.pxxxxx_1 // offset
			);
			this.pxxxxx_2data = reader.ReadBlockAt<Unknown_F_005>(
				this.pxxxxx_2 // offset
			);
			this.pxxxxx_3data = reader.ReadBlockAt<Unknown_F_005>(
				this.pxxxxx_3 // offset
			);
			this.pxxxxx_4data = reader.ReadBlockAt<Unknown_F_005>(
				this.pxxxxx_4 // offset
			);
		}

		/// <summary>
		/// Writes the data-block to a stream.
		/// </summary>
		public override void Write(ResourceDataWriter writer, params object[] parameters)
		{
			// update structure data
			this.pxxxxx_0 = (ulong)(this.pxxxxx_0data != null ? this.pxxxxx_0data.Position : 0);
			this.pxxxxx_1 = (ulong)(this.pxxxxx_1data != null ? this.pxxxxx_1data.Position : 0);
			this.pxxxxx_2 = (ulong)(this.pxxxxx_2data != null ? this.pxxxxx_2data.Position : 0);
			this.pxxxxx_3 = (ulong)(this.pxxxxx_3data != null ? this.pxxxxx_3data.Position : 0);
			this.pxxxxx_4 = (ulong)(this.pxxxxx_4data != null ? this.pxxxxx_4data.Position : 0);

			// write structure data
			writer.Write(this.VFT);
			writer.Write(this.Unknown_4h);
			writer.Write(this.Unknown_8h);
			writer.Write(this.Unknown_Ch);
			writer.Write(this.pxxxxx_0);
			writer.Write(this.pxxxxx_1);
			writer.Write(this.pxxxxx_2);
			writer.Write(this.pxxxxx_3);
			writer.Write(this.pxxxxx_4);
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
		}

		/// <summary>
		/// Returns a list of data blocks which are referenced by this block.
		/// </summary>
		public override IResourceBlock[] GetReferences()
		{
			var list = new List<IResourceBlock>();
			if (pxxxxx_0data != null) list.Add(pxxxxx_0data);
			if (pxxxxx_1data != null) list.Add(pxxxxx_1data);
			if (pxxxxx_2data != null) list.Add(pxxxxx_2data);
			if (pxxxxx_3data != null) list.Add(pxxxxx_3data);
			if (pxxxxx_4data != null) list.Add(pxxxxx_4data);
			return list.ToArray();
		}

	}
}
