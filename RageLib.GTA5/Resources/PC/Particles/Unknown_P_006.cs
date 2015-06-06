/*
    Copyright(c) 2015 Neodymium

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
*/

using System;

namespace RageLib.Resources.GTA5.PC.Particles
{
    public class Unknown_P_006: ResourceSystemBlock, IResourceXXSystemBlock
    {
		public override long Length
		{
			get { return 16; }
		}

		// structure data
		public uint VFT;
		public uint Unknown_4h;
		public uint Unknown_8h;
		public uint Unknown_Ch;

		/// <summary>
		/// Reads the data-block from a stream.
		/// </summary>
		public override void Read(ResourceDataReader reader, params object[] parameters)
		{
			// read structure data
			this.VFT = reader.ReadUInt32();
			this.Unknown_4h = reader.ReadUInt32();
			this.Unknown_8h = reader.ReadUInt32();
			this.Unknown_Ch = reader.ReadUInt32();		
		}

		/// <summary>
		/// Writes the data-block to a stream.
		/// </summary>
		public override void Write(ResourceDataWriter writer, params object[] parameters)
		{
			// write structure data
			writer.Write(this.VFT);
			writer.Write(this.Unknown_4h);
			writer.Write(this.Unknown_8h);
			writer.Write(this.Unknown_Ch);
		}

        public IResourceSystemBlock GetType(ResourceDataReader reader, params object[] parameters)
        {

            reader.Position += 8;
            var type = reader.ReadUInt32();
            reader.Position -= 12;

            switch (type)
            {
                case 4122164138: return new Unknown_P_006_f5b33baa();
                case 3594362651: return new Unknown_P_006_d63d9f1b();
                case 1812404668: return new Unknown_P_006_6c0719bc();
                case 518407506: return new Unknown_P_006_1ee64552();
                case 951452224: return new Unknown_P_006_38b60240();
                case 86708883: return new Unknown_P_006_052b1293();
                case 1692784386: return new Unknown_P_006_64e5d702();
                case 2458524741: return new Unknown_P_006_928a1c45();
                case 3970452510: return new Unknown_P_006_eca84c1e();
                case 374008434: return new Unknown_P_006_164aea72();
                case 1761244149: return new Unknown_P_006_68fa73f5();
                case 951466360: return new Unknown_P_006_38b63978();
                case 88393488: return new Unknown_P_006_0544c710();
                case 1647501914: return new Unknown_P_006_6232e25a();
                case 2403033142: return new Unknown_P_006_8f3b6036();
                case 2740744735: return new Unknown_P_006_a35c721f();
                case 3078614297: return new Unknown_P_006_b77fed19();
                case 632067127: return new Unknown_P_006_25ac9437();
                case 3312678904: return new Unknown_P_006_c57377f8();
                case 2690491966: return new Unknown_P_006_a05da63e();
                case 3562621935: return new Unknown_P_006_d4594bef();
                case 2731990079: return new Unknown_P_006_a2d6dc3f();
                case 3743585602: return new Unknown_P_006_df229542();
                default: throw new Exception("Unknown type");
            }

        }
    }
}
