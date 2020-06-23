using RageLib.Resources.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageLib.Resources.RDR2.PC.Drawables
{
	// some Texture struct
    public class Struct_13 : ResourceSystemBlock
    {
		public override long Length => 0x50;

		// structure data
		public ulong VFT;           // 0x0000000140910008
		public ulong Unknown_08h;   // 0x0000000000000000
		public uint Unknown_10h;
		public uint Unknown_14h;
		public uint Unknown_18h;
		public ushort Unknown_1Ch;
		public ushort Unknown_1Eh;
		public ushort Unknown_20h;
		public ushort Unknown_22h;
		public ushort Unknown_24h;
		public ushort Unknown_26h;
		public ulong NamePointer;
		public ulong Unknown_30h;   // 0x0000000000000000
		public ulong Unknown_38h;   // 0x0000000000000000
		public ulong Unknown_40h;   // 0x0000000000000000
		public ulong Unknown_48h;   // 0x0000000000000000

		// reference data
		public string_r Name;


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
