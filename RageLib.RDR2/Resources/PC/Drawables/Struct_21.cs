using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageLib.Resources.RDR2.PC.Drawables
{
    public class Struct_21 : ResourceSystemBlock
    {
        public override long BlockLength => 0x140;

        // structure data
        public ulong Unknown_0h;
        public ulong Unknown_8h;
        public ulong Unknown_10h;
        public ulong Unknown_18h;
        public ulong Unknown_20h;
        public ulong Unknown_28h;
        public ulong Unknown_30h;
        public ulong Unknown_38h;
        public ulong Unknown_40h;
        public ulong Unknown_48h;
        public ulong Unknown_50h;
        public ulong Unknown_58h;
        public uint Unknown_60h;
        public uint Unknown_64h;
        public ulong Unknown_68h;
        public uint Unknown_70h;
        public uint Unknown_74h;
        public ulong Unknown_78h;
        public ulong Unknown_80h;
        public ulong Unknown_88h;
        public ulong Unknown_90h;
        public ulong Unknown_98h;
        public ulong Unknown_100h;
        public ulong Unknown_108h;
        public ulong Unknown_110h;
        public ulong Unknown_118h;
        public ulong Unknown_120h;
        public ulong Unknown_128h;
        public uint Unknown_130h;
        public uint Unknown_134h;
        public ulong Unknown_138h;

        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.Unknown_0h = reader.ReadUInt64();
            this.Unknown_8h = reader.ReadUInt64();
            this.Unknown_10h = reader.ReadUInt64();
            this.Unknown_18h = reader.ReadUInt64();
            this.Unknown_20h = reader.ReadUInt64();
            this.Unknown_28h = reader.ReadUInt64();
            this.Unknown_30h = reader.ReadUInt64();
            this.Unknown_38h = reader.ReadUInt64();
            this.Unknown_40h = reader.ReadUInt64();
            this.Unknown_48h = reader.ReadUInt64();
            this.Unknown_50h = reader.ReadUInt64();
            this.Unknown_58h = reader.ReadUInt64();
            this.Unknown_60h = reader.ReadUInt32();
            this.Unknown_64h = reader.ReadUInt32();
            this.Unknown_68h = reader.ReadUInt64();
            this.Unknown_70h = reader.ReadUInt32();
            this.Unknown_74h = reader.ReadUInt32();
            this.Unknown_78h = reader.ReadUInt64();
            this.Unknown_80h = reader.ReadUInt64();
            this.Unknown_88h = reader.ReadUInt64();
            this.Unknown_90h = reader.ReadUInt64();
            this.Unknown_98h = reader.ReadUInt64();
            this.Unknown_100h = reader.ReadUInt64();
            this.Unknown_108h = reader.ReadUInt64();
            this.Unknown_110h = reader.ReadUInt64();
            this.Unknown_118h = reader.ReadUInt64();
            this.Unknown_120h = reader.ReadUInt64();
            this.Unknown_128h = reader.ReadUInt64();
            this.Unknown_130h = reader.ReadUInt32();
            this.Unknown_134h = reader.ReadUInt32();
            this.Unknown_138h = reader.ReadUInt64();

            // read reference data
        }

        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // write structure data


            // write reference data
        }
    }
}
