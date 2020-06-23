using System.Collections.Generic;
using System.Numerics;

namespace RageLib.Resources.RDR2.PC.Drawables
{
    public class Struct_00 : PgBase64
	{	
		public override long Length => 0x50;

		// structure data
		public ulong Struct_03_Pointer;
		public ulong Unknown_18h;           // 0x0000000000000000
		public Vector3 BoundingCenter;
		public float BoundingSphereRadius;
		public Vector4 BoundingBoxMin;
		public Vector4 BoundingBoxMax;

		// reference data
		public Struct_03 Struct_03_Data;

		public override void Read(ResourceDataReader reader, params object[] parameters)
		{
			base.Read(reader, parameters);

			// read structure data
			this.Struct_03_Pointer = reader.ReadUInt64();
			this.Unknown_18h = reader.ReadUInt64();
			this.BoundingCenter = reader.ReadVector3();
			this.BoundingSphereRadius = reader.ReadSingle();
			this.BoundingBoxMin = reader.ReadVector4();
			this.BoundingBoxMax = reader.ReadVector4();

			// read reference data
			this.Struct_03_Data = reader.ReadBlockAt<Struct_03>(this.Struct_03_Pointer);
		}

		public override void Write(ResourceDataWriter writer, params object[] parameters)
		{
			base.Write(writer, parameters);

			// update structure data
			this.Struct_03_Pointer = (ulong)(this.Struct_03_Data != null ? this.Struct_03_Data.Position : 0);

			// write structure data
			writer.Write(this.Struct_03_Pointer);
			writer.Write(this.Unknown_18h);
			writer.Write(this.BoundingCenter);
			writer.Write(this.BoundingSphereRadius);
			writer.Write(this.BoundingBoxMin);
			writer.Write(this.BoundingBoxMax);
		}

		public override IResourceBlock[] GetReferences()
		{
			var list = new List<IResourceBlock>(base.GetReferences());
			if (Struct_03_Data != null) list.Add(Struct_03_Data);
			return list.ToArray();
		}
	}
}
