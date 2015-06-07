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

using RageLib.Resources.Common;
using System;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Particles
{
    public class Unknown_P_004 : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 640; }
        }

        // structure data
        public uint VFT;
        public uint Unknown_4h; // 0x00000001
        public uint Unknown_8h;
        public uint Unknown_Ch;
        public uint Unknown_10h;
        public uint Unknown_14h; // 0x00000000
        public Unknown_P_018 emb1;
        public Unknown_P_018 emb2;
        public Unknown_P_018 emb3;
        public Unknown_P_018 emb4;
        public uint Unknown_258h;
        public uint Unknown_25Ch; // 0x00000000
        public ulong pref;
        public ushort refcnt1;
        public ushort refcnt2;
        public uint Unknown_26Ch; // 0x00000000
        public uint Unknown_270h; // 0x00000000
        public uint Unknown_274h; // 0x00000000
        public uint Unknown_278h; // 0x00000000
        public uint Unknown_27Ch; // 0x00000000

        // reference data
        public ResourcePointerArray64<Unknown_P_018> refs;

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
            this.Unknown_10h = reader.ReadUInt32();
            this.Unknown_14h = reader.ReadUInt32();
            this.emb1 = reader.ReadBlock<Unknown_P_018>();
            this.emb2 = reader.ReadBlock<Unknown_P_018>();
            this.emb3 = reader.ReadBlock<Unknown_P_018>();
            this.emb4 = reader.ReadBlock<Unknown_P_018>();
            this.Unknown_258h = reader.ReadUInt32();
            this.Unknown_25Ch = reader.ReadUInt32();
            this.pref = reader.ReadUInt64();
            this.refcnt1 = reader.ReadUInt16();
            this.refcnt2 = reader.ReadUInt16();
            this.Unknown_26Ch = reader.ReadUInt32();
            this.Unknown_270h = reader.ReadUInt32();
            this.Unknown_274h = reader.ReadUInt32();
            this.Unknown_278h = reader.ReadUInt32();
            this.Unknown_27Ch = reader.ReadUInt32();

            // read reference data
            this.refs = reader.ReadBlockAt<ResourcePointerArray64<Unknown_P_018>>(
                this.pref, // offset
                this.refcnt2
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.pref = (ulong)(this.refs != null ? this.refs.Position : 0);
            //this.refcnt2 = (ushort)(this.refs != null ? this.refs.Count : 0);

            // write structure data
            writer.Write(this.VFT);
            writer.Write(this.Unknown_4h);
            writer.Write(this.Unknown_8h);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.WriteBlock(this.emb1);
            writer.WriteBlock(this.emb2);
            writer.WriteBlock(this.emb3);
            writer.WriteBlock(this.emb4);
            writer.Write(this.Unknown_258h);
            writer.Write(this.Unknown_25Ch);
            writer.Write(this.pref);
            writer.Write(this.refcnt1);
            writer.Write(this.refcnt2);
            writer.Write(this.Unknown_26Ch);
            writer.Write(this.Unknown_270h);
            writer.Write(this.Unknown_274h);
            writer.Write(this.Unknown_278h);
            writer.Write(this.Unknown_27Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (refs != null) list.Add(refs);
            return list.ToArray();
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(24, emb1),
                new Tuple<long, IResourceBlock>(168, emb2),
                new Tuple<long, IResourceBlock>(312, emb3),
                new Tuple<long, IResourceBlock>(456, emb4)
            };
        }
    }
}