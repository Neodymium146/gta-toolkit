using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageLib.Resources.RDR2.PC.Drawables
{
	// DrawableModel
	public class Struct_09 : ResourceSystemBlock
	{
		public override long Length => 0x40;

		// structure data
		public uint Unknown_00h;
		public uint Unknown_04h;
		public ulong Struct_10_Pointer;
		public ulong Struct_11_Pointer;
		public ulong Unknown_18h;       // 0x0000000000000000
		public ulong Struct_12_Pointer;
		public ulong Unknown_28h;       // 0x0000000000000000
		public ulong Unknown_30h;       // 0x0000000000000000
		public ushort Unknown_38h;
		public ushort Unknown_3Ah;
		public ushort Unknown_3Ch;
		public ushort Unknown_3Eh;

		// reference data
		public Struct_10 Struct_10_Data;
		public Struct_11 Struct_11_Data;
		public Struct_12 Struct_12_Data;


		public override void Read(ResourceDataReader reader, params object[] parameters)
		{
			// read structure data
			this.Unknown_00h = reader.ReadUInt32();
			this.Unknown_04h = reader.ReadUInt32();
			this.Struct_10_Pointer = reader.ReadUInt64();
			this.Struct_11_Pointer = reader.ReadUInt64();
			this.Struct_11_Pointer = reader.ReadUInt64();
			this.Unknown_18h = reader.ReadUInt64();
			this.Struct_12_Pointer = reader.ReadUInt64();
			this.Unknown_28h = reader.ReadUInt64();
			this.Unknown_30h = reader.ReadUInt64();
			this.Unknown_38h = reader.ReadUInt16();
			this.Unknown_3Ah = reader.ReadUInt16();
			this.Unknown_3Ch = reader.ReadUInt16();
			this.Unknown_3Eh = reader.ReadUInt16();

			// read reference data
			this.Struct_10_Data = reader.ReadBlockAt<Struct_10>(this.Struct_10_Pointer);
			this.Struct_11_Data = reader.ReadBlockAt<Struct_11>(this.Struct_11_Pointer);
			this.Struct_12_Data = reader.ReadBlockAt<Struct_12>(this.Struct_12_Pointer);
		}

		public override void Write(ResourceDataWriter writer, params object[] parameters)
		{
			// write structure data


			// write reference data
		}
	}
}
