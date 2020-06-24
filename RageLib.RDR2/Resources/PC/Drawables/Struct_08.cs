using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageLib.Resources.RDR2.PC.Drawables
{
    public class Struct_08 : ResourceSystemBlock
    {
        public override long Length => 0x10;

        // structure data
        public uint Unknown_00h;
        public uint Unknown_04h;
        public uint Unknown_08h;
        public uint Unknown_0Ch;

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
