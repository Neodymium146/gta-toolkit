using RageLib.RDR2.Resources.PC.Bounds;
using RageLib.Resources.Common;
using System.Collections.Generic;
using System.Numerics;

namespace RageLib.Resources.RDR2.PC.Drawables
{
	// pgBase
	// rmcDrawableBase
	// rmcDrawable
	// gtaDrawable
	public class GtaDrawable : PgBase64
	{
		public override long BlockLength => 0xD0;

		// structure data
		public ulong ShaderGroupPointer;
		public ulong Unknown_18h;					// 0x0000000000000000
		public Vector3 BoundingCenter;
		public float BoundingSphereRadius;
		public Vector4 BoundingBoxMin;
		public Vector4 BoundingBoxMax;
		public ulong DrawableModelsHighPointer;
		public ulong DrawableModelsMediumPointer;
		public ulong DrawableModelsLowPointer;
		public ulong DrawableModelsVeryLowPointer;
		public float LodDistanceHigh;               // 0x461C3800 = 9998
		public float LodDistanceMedium;             // 0x461C3800 = 9998
		public float LodDistanceLow;                // 0x461C3800 = 9998
		public float LodDistanceVeryLow;            // 0x461C3800 = 9998
		public uint DrawBucketMaskHigh;             // 0xFF010000
		public uint DrawBucketMaskMedium;           // 0x00000000
		public uint DrawBucketMaskLow;              // 0x00000000
		public uint DrawBucketMaskVeryLow;          // 0x00000000
		public ulong Unknown_40h;                   // 0x0000000000000000
		public ulong Unknown_48h;                   // 0x0000000000000000
		public ulong Unknown_50h;                   // 0x0000000000000000
		public ulong NamePointer;
		public ulong Unknown_60h;                   // 0x0000000000000000
		public ulong BoundPointer;
		public ulong Unknown_70h_Pointer;
		public ulong Unknown_78h;                   // 0x0000000000000000

		// reference data
		public ShaderGroup ShaderGroup;
		public ResourcePointerList64<DrawableModel> DrawableModelsHigh;
		public ResourcePointerList64<DrawableModel> DrawableModelsMedium;
		public ResourcePointerList64<DrawableModel> DrawableModelsLow;
		public ResourcePointerList64<DrawableModel> DrawableModelsVeryLow;
		public string_r Name;
		public Bound Bound;

		public override void Read(ResourceDataReader reader, params object[] parameters)
		{
			base.Read(reader, parameters);

			// read structure data
			this.ShaderGroupPointer = reader.ReadUInt64();
			this.Unknown_18h = reader.ReadUInt64();
			this.BoundingCenter = reader.ReadVector3();
			this.BoundingSphereRadius = reader.ReadSingle();
			this.BoundingBoxMin = reader.ReadVector4();
			this.BoundingBoxMax = reader.ReadVector4();
			this.DrawableModelsHighPointer = reader.ReadUInt64();
			this.DrawableModelsMediumPointer = reader.ReadUInt64();
			this.DrawableModelsLowPointer = reader.ReadUInt64();
			this.DrawableModelsVeryLowPointer = reader.ReadUInt64();
			this.LodDistanceHigh = reader.ReadSingle();
			this.LodDistanceMedium = reader.ReadSingle();
			this.LodDistanceLow = reader.ReadSingle();
			this.LodDistanceVeryLow = reader.ReadSingle();
			this.DrawBucketMaskHigh = reader.ReadUInt32();
			this.DrawBucketMaskMedium = reader.ReadUInt32();
			this.DrawBucketMaskLow = reader.ReadUInt32();
			this.DrawBucketMaskVeryLow = reader.ReadUInt32();
			this.Unknown_40h = reader.ReadUInt64();
			this.Unknown_48h = reader.ReadUInt64();
			this.Unknown_50h = reader.ReadUInt64();
			this.NamePointer = reader.ReadUInt64();
			this.Unknown_60h = reader.ReadUInt64();
			this.BoundPointer = reader.ReadUInt64();
			this.Unknown_70h_Pointer = reader.ReadUInt64();
			this.Unknown_78h = reader.ReadUInt64();

			// read reference data
			this.ShaderGroup = reader.ReadBlockAt<ShaderGroup>(this.ShaderGroupPointer);
			this.DrawableModelsHigh = reader.ReadBlockAt<ResourcePointerList64<DrawableModel>>(this.DrawableModelsHighPointer);
			this.DrawableModelsMedium = reader.ReadBlockAt<ResourcePointerList64<DrawableModel>>(this.DrawableModelsMediumPointer);
			this.DrawableModelsLow = reader.ReadBlockAt<ResourcePointerList64<DrawableModel>>(this.DrawableModelsLowPointer);
			this.DrawableModelsVeryLow = reader.ReadBlockAt<ResourcePointerList64<DrawableModel>>(this.DrawableModelsVeryLowPointer);
			this.Name = reader.ReadBlockAt<string_r>(NamePointer);
			this.Bound = reader.ReadBlockAt<Bound>(BoundPointer);
		}

		public override void Write(ResourceDataWriter writer, params object[] parameters)
		{
			base.Write(writer, parameters);

			// update structure data
			this.ShaderGroupPointer = (ulong)(this.ShaderGroup != null ? this.ShaderGroup.BlockPosition : 0);

			// write structure data
			writer.Write(this.ShaderGroupPointer);
			writer.Write(this.Unknown_18h);
			writer.Write(this.BoundingCenter);
			writer.Write(this.BoundingSphereRadius);
			writer.Write(this.BoundingBoxMin);
			writer.Write(this.BoundingBoxMax);
		}

		public override IResourceBlock[] GetReferences()
		{
			var list = new List<IResourceBlock>(base.GetReferences());
			if (ShaderGroup != null) list.Add(ShaderGroup);
			return list.ToArray();
		}
	}
}
