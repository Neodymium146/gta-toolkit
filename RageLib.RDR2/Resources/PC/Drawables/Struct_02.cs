namespace RageLib.Resources.RDR2.PC.Drawables
{
	public class Struct_02 : ResourceSystemBlock
	{
		public override long Length => 0x20;

		// structure data
		public ulong Unknown_00h;
		public uint Unknown_08h;
		public uint Unknown_0Ch;
		public ulong Unknown_10h;
		public ulong Unknown_18h;

		public override void Read(ResourceDataReader reader, params object[] parameters)
		{
			// read structure data
			this.Unknown_00h = reader.ReadUInt64();
			this.Unknown_08h = reader.ReadUInt32();
			this.Unknown_0Ch = reader.ReadUInt32();
			this.Unknown_10h = reader.ReadUInt64();
			this.Unknown_18h = reader.ReadUInt64();
		}

		public override void Write(ResourceDataWriter writer, params object[] parameters)
		{
			// write structure data
			writer.Write(this.Unknown_00h);
			writer.Write(this.Unknown_08h);
			writer.Write(this.Unknown_0Ch);
			writer.Write(this.Unknown_10h);
			writer.Write(this.Unknown_18h);
		}
	}
}
