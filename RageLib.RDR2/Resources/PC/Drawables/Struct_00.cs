using System.Collections.Generic;

namespace RageLib.Resources.RDR2.PC.Drawables
{
    public class Struct_00 : ResourceSystemBlock
	{
		public override long Length => 0x50;

		// structure data
		public ulong Unknown_00h;           // 0x0000000000000000
		public ulong Struct_02_Pointer;
		public ulong Struct_03_Pointer;
		public ulong Unknown_18h;           // 0x0000000000000000
		public float Unknown_20h;           // 0x00000000			// BBCenter?
		public float Unknown_24h;           // 0x00000000
		public float Unknown_28h;           // 0x3F000000 = 0.5
		public float Unknown_2Ch;           // 0x3F5DB3D0			// Sphere Radius?
		public float Unknown_30h;           // 0xBF000000 = -0.5	// BBMin?
		public float Unknown_34h;           // 0xBF000000 = -0.5
		public float Unknown_38h;           // 0x00000000
		public float Unknown_3Ch;           // 0x00000000
		public float Unknown_40h;           // 0x3F000000 = 0.5		// BBMax?
		public float Unknown_44h;           // 0x3F000000 = 0.5
		public float Unknown_48h;           // 0x3F800000 = 1
		public float Unknown_4Ch;           // 0x00000000

		// reference data
		public Struct_02 Struct_02_Data;
		public Struct_03 Struct_03_Data;

		public override void Read(ResourceDataReader reader, params object[] parameters)
		{
			// read structure data
			this.Unknown_00h = reader.ReadUInt64();
			this.Struct_02_Pointer = reader.ReadUInt64();
			this.Struct_03_Pointer = reader.ReadUInt64();
			this.Unknown_18h = reader.ReadUInt64();
			this.Unknown_20h = reader.ReadSingle();
			this.Unknown_24h = reader.ReadSingle();
			this.Unknown_28h = reader.ReadSingle();
			this.Unknown_2Ch = reader.ReadSingle();
			this.Unknown_30h = reader.ReadSingle();
			this.Unknown_34h = reader.ReadSingle();
			this.Unknown_38h = reader.ReadSingle();
			this.Unknown_3Ch = reader.ReadSingle();
			this.Unknown_40h = reader.ReadSingle();
			this.Unknown_44h = reader.ReadSingle();
			this.Unknown_48h = reader.ReadSingle();
			this.Unknown_4Ch = reader.ReadSingle();

			// read reference data
			this.Struct_02_Data = reader.ReadBlockAt<Struct_02>(this.Struct_02_Pointer);
			this.Struct_03_Data = reader.ReadBlockAt<Struct_03>(this.Struct_03_Pointer);
		}

		public override void Write(ResourceDataWriter writer, params object[] parameters)
		{
			// update structure data
			this.Struct_02_Pointer = (ulong)(this.Struct_02_Data != null ? this.Struct_02_Data.Position : 0);
			this.Struct_03_Pointer = (ulong)(this.Struct_03_Data != null ? this.Struct_03_Data.Position : 0);

			// write structure data
			writer.Write(this.Unknown_00h);
			writer.Write(this.Struct_02_Pointer);
			writer.Write(this.Struct_03_Pointer);
			writer.Write(this.Unknown_18h);
			writer.Write(this.Unknown_20h);
			writer.Write(this.Unknown_24h);
			writer.Write(this.Unknown_28h);
			writer.Write(this.Unknown_2Ch);
			writer.Write(this.Unknown_30h);
			writer.Write(this.Unknown_34h);
			writer.Write(this.Unknown_38h);
			writer.Write(this.Unknown_3Ch);
			writer.Write(this.Unknown_40h);
			writer.Write(this.Unknown_44h);
			writer.Write(this.Unknown_48h);
			writer.Write(this.Unknown_4Ch);
		}

		public override IResourceBlock[] GetReferences()
		{
			var list = new List<IResourceBlock>(base.GetReferences());
			if (Struct_02_Data != null) list.Add(Struct_02_Data);
			if (Struct_03_Data != null) list.Add(Struct_03_Data);
			return list.ToArray();
		}
	}
}
