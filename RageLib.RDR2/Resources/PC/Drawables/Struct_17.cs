using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageLib.Resources.RDR2.PC.Drawables
{
    public class Struct_17 : ResourceSystemBlock
    {
        public override long BlockLength => 0x40;

        // structure data
        public ulong VFT;                   // 0x0000000140912400
        public uint Unknown_08h;
        public uint Unknown_0Ch;
        public uint Unknown_10h;
        public uint Unknown_14h;
        public ulong Unknown_18h_Pointer;
        public ulong Unknown_20h;           // 0x0000000000000000
        public ulong Unknown_28h;           // 0x0000000000000000
        public ulong Unknown_30h_Pointer;
        public ulong Unknown_38h_Pointer;

        // reference data
        public Struct_15 Unknown_30h_Data;

        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data


            // read reference data
        }

        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // write structure data


            // write reference data
        }
    }
}
