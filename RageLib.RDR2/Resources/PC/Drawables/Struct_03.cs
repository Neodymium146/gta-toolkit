using System.Collections.Generic;

namespace RageLib.Resources.RDR2.PC.Drawables
{
    public class Struct_03 : ResourceSystemBlock
    {
		public override long Length => 0x40;

		// structure data
		public ulong VFT;                   // 0x0000000140912C88
		public ulong Struct_18_Pointer;
		public ulong Struct_04_Pointer;
		public ushort Unknown_18h;          // 0x0001
		public ushort Unknown_1Ah;          // 0x0001
		public uint Unknown_1Ch;            // 0x00000000
		public ulong Unknown_20h;           // 0x0000000000000000
		public ulong Unknown_28h;           // 0x0000000000000000
		public ulong Unknown_30h;           // 0x0000000000000000
		public ulong Unknown_38h;           // 0x0000000000000000

		// reference data
		public Struct_18 Struct_18_Data;
		public Struct_04 Struct_04_Data;

		public override void Read(ResourceDataReader reader, params object[] parameters)
        {
			// read structure data
			this.VFT = reader.ReadUInt64();
			this.Struct_18_Pointer = reader.ReadUInt64();
			this.Struct_04_Pointer = reader.ReadUInt64();
			this.Unknown_18h = reader.ReadUInt16();
			this.Unknown_1Ah = reader.ReadUInt16();
			this.Unknown_1Ch = reader.ReadUInt32();
			this.Unknown_20h = reader.ReadUInt64();
			this.Unknown_28h = reader.ReadUInt64();
			this.Unknown_30h = reader.ReadUInt64();
			this.Unknown_38h = reader.ReadUInt64();

			// read reference data
			this.Struct_18_Data = reader.ReadBlockAt<Struct_18>(this.Struct_18_Pointer);
			this.Struct_04_Data = reader.ReadBlockAt<Struct_04>(this.Struct_04_Pointer);
		}

        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
			// update structure data
			this.Struct_18_Pointer = (ulong)(this.Struct_18_Data != null ? this.Struct_18_Data.Position : 0);
			this.Struct_04_Pointer = (ulong)(this.Struct_04_Data != null ? this.Struct_04_Data.Position : 0);

			// write structure data
			writer.Write(this.VFT);
			writer.Write(this.Struct_18_Pointer);
			writer.Write(this.Struct_04_Pointer);
			writer.Write(this.Unknown_18h);
			writer.Write(this.Unknown_1Ah);
			writer.Write(this.Unknown_1Ch);
			writer.Write(this.Unknown_20h);
			writer.Write(this.Unknown_28h);
			writer.Write(this.Unknown_30h);
			writer.Write(this.Unknown_38h);
		}

		public override IResourceBlock[] GetReferences()
		{
			var list = new List<IResourceBlock>(base.GetReferences());
			if (Struct_18_Data != null) list.Add(Struct_18_Data);
			if (Struct_04_Data != null) list.Add(Struct_04_Data);
			return list.ToArray();
		}
	}
}
