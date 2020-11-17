using RageLib.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RageLib.RDR2.Resources.PC.Drawables
{
    public class Struct_22 : ResourceSystemBlock
    {
        public override long BlockLength => 0x110;

        // structure data
        public Vector4 Unknown_0h;
        public Vector4 Unknown_10h;
        public Vector4 Unknown_20h;
        public Vector4 Unknown_30h;
        public Vector4 Unknown_40h;
        public Vector4 Unknown_50h;
        public Vector4 Unknown_60h;
        public Vector4 Unknown_70h;
        public Vector4 Unknown_80h;
        public Vector4 Unknown_90h;
        public Vector4 Unknown_100h;

        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.Unknown_0h = reader.ReadVector4();
            this.Unknown_10h = reader.ReadVector4();
            this.Unknown_20h = reader.ReadVector4();
            this.Unknown_30h = reader.ReadVector4();
            this.Unknown_40h = reader.ReadVector4();
            this.Unknown_50h = reader.ReadVector4();
            this.Unknown_60h = reader.ReadVector4();
            this.Unknown_70h = reader.ReadVector4();
            this.Unknown_80h = reader.ReadVector4();
            this.Unknown_90h = reader.ReadVector4();
            this.Unknown_100h = reader.ReadVector4();
        }

        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
