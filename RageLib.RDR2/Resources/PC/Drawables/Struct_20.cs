using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageLib.Resources.RDR2.PC.Drawables
{
    public class Struct_20 : ResourceSystemBlock
    {
        public override long BlockLength => 0xF0;

        // structure data
        public uint Unknown_0h;
        public uint Unknown_4h;
        public ulong Unknown_8h_Pointer;    // ResourcePointerArray
        public ulong Unknown_10h_Pointer;
        public ulong Unknown_18h_Pointer;
        public ulong Unknown_20h_Pointer;
        public ulong Unknown_28h;
        public ulong Unknown_30h;
        public ulong Unknown_38h;
        public ulong Unknown_40h;
        public ulong Unknown_48h;
        public ulong Unknown_50h;
        public ulong Unknown_58h;
        public ulong Unknown_60h;
        public ulong Unknown_68h;

        // reference data


        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.Unknown_0h = reader.ReadUInt32();
            this.Unknown_4h = reader.ReadUInt32();
            this.Unknown_8h_Pointer = reader.ReadUInt64();
            this.Unknown_10h_Pointer = reader.ReadUInt64();
            this.Unknown_18h_Pointer = reader.ReadUInt64();
            this.Unknown_20h_Pointer = reader.ReadUInt64();
            this.Unknown_28h = reader.ReadUInt64();
            this.Unknown_30h = reader.ReadUInt64();
            this.Unknown_38h = reader.ReadUInt64();
            this.Unknown_40h = reader.ReadUInt64();
            this.Unknown_48h = reader.ReadUInt64();
            this.Unknown_50h = reader.ReadUInt64();
            this.Unknown_58h = reader.ReadUInt64();
            this.Unknown_60h = reader.ReadUInt64();
            this.Unknown_68h = reader.ReadUInt64();

            // read reference data
        }

        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // write structure data


            // write reference data
        }
    }
}
