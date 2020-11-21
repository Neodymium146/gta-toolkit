using RageLib.Resources;
using System;
using System.Numerics;

namespace RageLib.RDR2.Resources.PC.Bounds
{
    // phBoundBase
    // phBound
    public class Bound : PgBase64, IResourceXXSystemBlock
    {
        public override long BlockLength => 0x70;

        // structure data
        public byte Type;
        public byte Unknown_11h;
        public ushort Unknown_12h;
        public float RadiusAroundCentroid;
        public uint Unknown_18h;
        public uint Unknown_1Ch;
        public Vector3 BoundingBoxMax;
        public float Margin;
        public Vector3 BoundingBoxMin;
        public uint RefCount;
        public Vector3 CentroidOffset;
        public uint MaterialId0;
        public Vector3 CGOffset;
        public uint MaterialId1;
        public Vector4 VolumeDistribution;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.Type = reader.ReadByte();
            this.Unknown_11h = reader.ReadByte();
            this.Unknown_12h = reader.ReadUInt16();
            this.RadiusAroundCentroid = reader.ReadSingle();
            this.Unknown_18h = reader.ReadUInt32();
            this.Unknown_1Ch = reader.ReadUInt32();
            this.BoundingBoxMax = reader.ReadVector3();
            this.Margin = reader.ReadSingle();
            this.BoundingBoxMin = reader.ReadVector3();
            this.RefCount = reader.ReadUInt32();
            this.CentroidOffset = reader.ReadVector3();
            this.MaterialId0 = reader.ReadUInt32();
            this.CGOffset = reader.ReadVector3();
            this.MaterialId1 = reader.ReadUInt32();
            this.VolumeDistribution = reader.ReadVector4();
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // write structure data
            writer.Write(this.Type);
            writer.Write(this.Unknown_11h);
            writer.Write(this.Unknown_12h);
            writer.Write(this.RadiusAroundCentroid);
            writer.Write(this.Unknown_18h);
            writer.Write(this.Unknown_1Ch);
            writer.Write(this.BoundingBoxMax);
            writer.Write(this.Margin);
            writer.Write(this.BoundingBoxMin);
            writer.Write(this.RefCount);
            writer.Write(this.CentroidOffset);
            writer.Write(this.MaterialId0);
            writer.Write(this.CGOffset);
            writer.Write(this.MaterialId1);
            writer.Write(this.VolumeDistribution);
        }

        public IResourceSystemBlock GetType(ResourceDataReader reader, params object[] parameters)
        {
            reader.Position += 16;
            var type = reader.ReadByte();
            reader.Position -= 17;

            switch (type)
            {
                case 6: return new BoundComposite();
                default: throw new Exception("Unknown bound type");
            }
        }
    }
}
