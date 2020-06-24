using RageLib.Resources.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageLib.Resources.RDR2.PC.Drawables
{
    public class Struct_06 : ResourceSystemBlock
    {
        public override long BlockLength => 0x40;

        // structure data
        public ulong VFT;                   // 0x0000000140912C58
        public ResourcePointerList64<Struct_19> Unknown_08h;
        public ulong Unknown_18h_Pointer;
        public ulong Unknown_20h_Pointer;
        public ulong Unknown_28h;           // 0x0000000000000000
        public uint Unknown_30h;
        public ushort Unknown_34h;
        public ushort Unknown_36h;
        public ulong Unknown_38h;           // 0x0000000000000000

        // reference data
        public Struct_07 Unknown_18h_Data;
        public Struct_08 Unknown_20h_Data;


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
