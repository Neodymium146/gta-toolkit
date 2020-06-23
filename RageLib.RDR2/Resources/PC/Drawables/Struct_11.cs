using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageLib.Resources.RDR2.PC.Drawables
{
    public class Struct_11 : ResourceSystemBlock
    {
		public override long Length => 0x70;

		// structure data
		public ulong Unknown_00h;			// 0x0000000000000000
		public ulong Unknown_08h_Pointer;
		public ulong Unknown_10h;			// 0x0000000000000000
		public ulong Unknown_18h;			// 0x0000000000000000
		public ulong Unknown_20h;			// 0x0000000000000000
		public ulong Unknown_28h;			// 0x0000000000000000
		public ulong Unknown_30h;			// 0x0000000000000000
		public ulong Unknown_38h;			// 0x0000000000000000
		public ulong Unknown_40h;			// 0x0000000000000000
		public ulong Unknown_48h;			// 0x0000000000000000
		public ulong Unknown_50h;			// 0x0000000000000000
		public ulong Unknown_58h;			// 0x0000000000000000
		public ushort Unknown_60h;
		public ushort Unknown_62h;
		public ushort Unknown_64h;
		public ushort Unknown_66h;
		public ulong Unknown_68h;			// 0x0000000000000000

		// reference data
		public Struct_13 Unknown_08h_Data;


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
