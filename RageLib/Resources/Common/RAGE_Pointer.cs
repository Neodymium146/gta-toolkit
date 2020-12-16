using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageLib.Resources.Common
{
	// PgRef64<T> ?
	public class RAGE_Pointer<T> : ResourceSystemBlock where T : IResourceBlock, new()
	{
		public override long BlockLength => 0x8;

		// structure data
		public ulong Pointer;

		// reference data
		public T Data;

		public override void Read(ResourceDataReader reader, params object[] parameters)
		{
			// read structure data
			this.Pointer = reader.ReadUInt64();

			// read reference data
			this.Data = reader.ReadBlockAt<T>(this.Pointer);
		}

		public override void Write(ResourceDataWriter writer, params object[] parameters)
		{
			// update structure data
			this.Pointer = (ulong)(this.Data != null ? this.Data.BlockPosition : 0);

			// write structure data
			writer.Write(this.Pointer);
		}

		public override IResourceBlock[] GetReferences()
        {
			return Data is null ? Array.Empty<IResourceBlock>() : new IResourceBlock[] { Data };
		}
	}
}
