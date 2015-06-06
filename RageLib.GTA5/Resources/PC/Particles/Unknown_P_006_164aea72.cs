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
using System.Collections.Generic;
using RageLib.Resources;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Particles
{
	public class Unknown_P_006_164aea72: Unknown_P_006
	{
		public override long Length
		{
			get { return 496; }
		}

		// structure data
		public ulong p1;
		public ushort c1;
		public ushort c2;
		public uint Unknown_1Ch;
		public uint Unknown_20h;
		public uint Unknown_24h;
		public uint Unknown_28h;
		public uint Unknown_2Ch;
		public Unknown_P_018 emb1;
		public Unknown_P_018 emb2;
		public Unknown_P_018 emb3;
		public uint Unknown_1E0h;
		public uint Unknown_1E4h;
		public uint Unknown_1E8h;
		public uint Unknown_1ECh;

		// reference data
		public ResourcePointerArray64<Unknown_P_018> p1data;

		/// <summary>
		/// Reads the data-block from a stream.
		/// </summary>
		public override void Read(ResourceDataReader reader, params object[] parameters)
		{
			base.Read(reader, parameters);

			// read structure data
			this.p1 = reader.ReadUInt64();
			this.c1 = reader.ReadUInt16();
			this.c2 = reader.ReadUInt16();
			this.Unknown_1Ch = reader.ReadUInt32();
			this.Unknown_20h = reader.ReadUInt32();
			this.Unknown_24h = reader.ReadUInt32();
			this.Unknown_28h = reader.ReadUInt32();
			this.Unknown_2Ch = reader.ReadUInt32();
			this.emb1 = reader.ReadBlock<Unknown_P_018>();
			this.emb2 = reader.ReadBlock<Unknown_P_018>();
			this.emb3 = reader.ReadBlock<Unknown_P_018>();
			this.Unknown_1E0h = reader.ReadUInt32();
			this.Unknown_1E4h = reader.ReadUInt32();
			this.Unknown_1E8h = reader.ReadUInt32();
			this.Unknown_1ECh = reader.ReadUInt32();

			// read reference data
			this.p1data = reader.ReadBlockAt<ResourcePointerArray64<Unknown_P_018>>(
				this.p1, // offset
				this.c1
			);
		}

		/// <summary>
		/// Writes the data-block to a stream.
		/// </summary>
		public override void Write(ResourceDataWriter writer, params object[] parameters)
		{
			base.Write(writer, parameters);

			// update structure data
			this.p1 = (ulong)(this.p1data != null ? this.p1data.Position : 0);
			this.c1 = (ushort)(this.p1data != null ? this.p1data.Count : 0);

			// write structure data
			writer.Write(this.p1);
			writer.Write(this.c1);
			writer.Write(this.c2);
			writer.Write(this.Unknown_1Ch);
			writer.Write(this.Unknown_20h);
			writer.Write(this.Unknown_24h);
			writer.Write(this.Unknown_28h);
			writer.Write(this.Unknown_2Ch);
			writer.WriteBlock(this.emb1);
			writer.WriteBlock(this.emb2);
			writer.WriteBlock(this.emb3);
			writer.Write(this.Unknown_1E0h);
			writer.Write(this.Unknown_1E4h);
			writer.Write(this.Unknown_1E8h);
			writer.Write(this.Unknown_1ECh);
		}

		/// <summary>
		/// Returns a list of data blocks which are referenced by this block.
		/// </summary>
		public override IResourceBlock[] GetReferences()
		{
			var list = new List<IResourceBlock>(base.GetReferences());
			if (p1data != null) list.Add(p1data);
			return list.ToArray();
		}

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(48,emb1),
                new Tuple<long, IResourceBlock>(192,emb2),
                new Tuple<long, IResourceBlock>(336,emb3)
            };
        }
    }
}
