using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageLib.Resources.RDR2.PC.Drawables
{
    public class Struct_07 : ResourceSystemBlock
    {
        public override long BlockLength => 0x20;

        // structure data
        public uint Unknown_00h;
        public uint Unknown_04h;
        public uint Unknown_08h;
        public uint Unknown_0Ch;
        public uint Unknown_10h;
        public uint Unknown_14h;
        public uint Unknown_18h;
        public uint Unknown_1Ch;

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
