using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageLib.Resources.RDR2.PC.Drawables
{
	public class Struct_04 : ResourceSystemBlock
    {
		public override long Length => 0x10;

		// structure data
		public ulong Struct_09_Pointer;
		public ushort Unknown_08h;          // 0x0001
		public ushort Unknown_0Ah;          // 0x0001
		public uint Unknown_0Ch;            // 0x00000000

		// reference data
		public Struct_09 Struct_09_Data;

        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.Struct_09_Pointer = reader.ReadUInt64();
            this.Unknown_08h = reader.ReadUInt16();
            this.Unknown_0Ah = reader.ReadUInt16();
            this.Unknown_0Ch = reader.ReadUInt32();

            // read reference data
            this.Struct_09_Data = reader.ReadBlockAt<Struct_09>(this.Struct_09_Pointer);
        }

        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.Struct_09_Pointer = (ulong)(this.Struct_09_Data != null ? this.Struct_09_Data.Position : 0);

            // write structure data
            writer.Write(this.Struct_09_Pointer);
            writer.Write(this.Unknown_08h);
            writer.Write(this.Unknown_0Ah);
            writer.Write(this.Unknown_0Ch);
        }

        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>(base.GetReferences());
            if (Struct_09_Data != null) list.Add(Struct_09_Data);
            return list.ToArray();
        }
    }
}
