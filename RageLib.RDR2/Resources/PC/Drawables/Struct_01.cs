using RageLib.Resources.Common;

namespace RageLib.Resources.RDR2.PC.Drawables
{
	public class Struct_01 : ResourceSystemBlock
	{
		public override long Length => 0x70;

		// structure data
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
		public ulong Unknown_68h;                   // 0x0000000000000000

		// reference data
		public ResourcePointerList64<Struct_09> DrawableModelsHigh;
		public ResourcePointerList64<Struct_09> DrawableModelsMedium;
		public ResourcePointerList64<Struct_09> DrawableModelsLow;
		public ResourcePointerList64<Struct_09> DrawableModelsVeryLow;
		public string_r Name;

		public override void Read(ResourceDataReader reader, params object[] parameters)
		{
			// read structure data
			
		}

		public override void Write(ResourceDataWriter writer, params object[] parameters)
		{
			// write structure data
			
		}
	}
}
