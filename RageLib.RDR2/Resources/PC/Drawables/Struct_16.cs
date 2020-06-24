using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageLib.Resources.RDR2.PC.Drawables
{
    // VFT = 0x00000001409100B0
    public class Struct_16 : DatBase64
    {
        public override long BlockLength => 0xB0;

        // structure data
        public uint Unknown_08h;
        public uint Unknown_0Ch;
        public uint Unknown_10h;
        public uint Unknown_14h;
        public uint Unknown_18h;
        public uint Unknown_1Ch;
        public uint Unknown_20h;
        public uint Unknown_24h;
        public ulong Unknown_28h_Pointer;
        public ulong Unknown_30h_Pointer;
        public ulong Unknown_38h_Pointer;   // Graphics Pointer?
        public ulong Unknown_40h;           // 0x0000000000000000
        public ulong Unknown_48h;           // 0x0000000000000000
        public ulong Unknown_50h;           // 0x0000000000000000
        public ulong Unknown_58h;           // 0x0000000000000000
        public ulong Unknown_60h;           // 0x0000000000000000
        public Struct_15 Unknown_68h;       // 0x0000000140910080	Embedded block 
        public ulong Unknown_A8h;           // 0x0000000000000000

        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data


            // read reference data
        }

        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // write structure data


            // write reference data
        }
    }
}
