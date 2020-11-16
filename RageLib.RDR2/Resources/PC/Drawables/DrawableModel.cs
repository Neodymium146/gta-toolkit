using RageLib.Resources.Common;

namespace RageLib.Resources.RDR2.PC.Drawables
{
    // grmModel
    // VFT - 0x0000000140912C58
    public class DrawableModel : DatBase64
    {
        public override long BlockLength => 0x40;

        // structure data
        public ResourcePointerList64<DrawableGeometry> Geometries;
        public ulong GeometriesBoundsPointer;
        public ulong ShaderMappingPointer;
        public ulong Unknown_28h;           // 0x0000000000000000
        public uint Unknown_30h;
        public ushort Unknown_34h;
        public ushort GeometriesCount;
        public ulong Unknown_38h;           // 0x0000000000000000

        // reference data
        public ResourceSimpleArray<RAGE_AABB> GeometriesBounds;
        public SimpleArray<ushort> ShaderMapping;

        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.Geometries = reader.ReadBlock<ResourcePointerList64<DrawableGeometry>>();
            this.GeometriesBoundsPointer = reader.ReadUInt64();
            this.ShaderMappingPointer = reader.ReadUInt64();
            this.Unknown_28h = reader.ReadUInt64();
            this.Unknown_30h = reader.ReadUInt32();
            this.Unknown_34h = reader.ReadUInt16();
            this.GeometriesCount = reader.ReadUInt16();
            this.Unknown_38h = reader.ReadUInt64();

            // read reference data
            this.GeometriesBounds = reader.ReadBlockAt<ResourceSimpleArray<RAGE_AABB>>(GeometriesBoundsPointer, GeometriesCount);
            this.ShaderMapping = reader.ReadBlockAt<SimpleArray<ushort>>(ShaderMappingPointer, GeometriesCount);
        }

        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // write structure data


            // write reference data
        }
    }
}
