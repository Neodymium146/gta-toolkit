/*
    Copyright(c) 2016 Neodymium

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
    public class EffectRule_GTA5_pc : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 1584; }
        }

        // structure data
        public uint VFT;
        public uint Unknown_4h; // 0x00000001
        public uint Unknown_8h; // 0x00000000
        public uint Unknown_Ch; // 0x00000000
        public uint Unknown_10h;
        public uint Unknown_14h; // 0x00000000
        public uint Unknown_18h;
        public uint Unknown_1Ch; // 0x00000000
        public ulong NamePointer;
        public uint Unknown_28h; // 0x00000000
        public uint Unknown_2Ch; // 0x00000000
        public uint Unknown_30h; // 0x00000000
        public uint Unknown_34h; // 0x00000000
        public ulong p2;
        public uint Unknown_40h; // 0x00000000
        public uint Unknown_44h; // 0x00000000
        public ulong p3;
        public uint Unknown_50h; // 0x00000000
        public uint Unknown_54h; // 0x00000000
        public ulong p4;
        public uint Unknown_60h; // 0x00000000
        public uint Unknown_64h; // 0x00000000
        public uint Unknown_68h; // 0x00000000
        public uint Unknown_6Ch; // 0x00000000
        public uint Unknown_70h; // 0x00000000
        public uint Unknown_74h; // 0x00000000
        public Unknown_P_018 emb1;
        public Unknown_P_018 emb2;
        public Unknown_P_018 emb3;
        public Unknown_P_018 emb4;
        public Unknown_P_018 emb5;
        public Unknown_P_018 emb6;
        public Unknown_P_018 emb7;
        public Unknown_P_018 emb8;
        public Unknown_P_018 emb9;
        public Unknown_P_018 emb10;
        public ulong pref;
        public ushort refcnt1;
        public ushort refcnt2;
        public uint Unknown_624h; // 0x00000000
        public uint Unknown_628h;
        public uint Unknown_62Ch; // 0x00000000

        // reference data
        public string_r Name;
        public Unknown_P_004 p2data;
        public Unknown_P_004 p3data;
        public Unknown_P_004 p4data;
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
            this.Unknown_18h = reader.ReadUInt32();
            this.Unknown_1Ch = reader.ReadUInt32();
            this.NamePointer = reader.ReadUInt64();
            this.Unknown_28h = reader.ReadUInt32();
            this.Unknown_2Ch = reader.ReadUInt32();
            this.Unknown_30h = reader.ReadUInt32();
            this.Unknown_34h = reader.ReadUInt32();
            this.p2 = reader.ReadUInt64();
            this.Unknown_40h = reader.ReadUInt32();
            this.Unknown_44h = reader.ReadUInt32();
            this.p3 = reader.ReadUInt64();
            this.Unknown_50h = reader.ReadUInt32();
            this.Unknown_54h = reader.ReadUInt32();
            this.p4 = reader.ReadUInt64();
            this.Unknown_60h = reader.ReadUInt32();
            this.Unknown_64h = reader.ReadUInt32();
            this.Unknown_68h = reader.ReadUInt32();
            this.Unknown_6Ch = reader.ReadUInt32();
            this.Unknown_70h = reader.ReadUInt32();
            this.Unknown_74h = reader.ReadUInt32();
            this.emb1 = reader.ReadBlock<Unknown_P_018>();
            this.emb2 = reader.ReadBlock<Unknown_P_018>();
            this.emb3 = reader.ReadBlock<Unknown_P_018>();
            this.emb4 = reader.ReadBlock<Unknown_P_018>();
            this.emb5 = reader.ReadBlock<Unknown_P_018>();
            this.emb6 = reader.ReadBlock<Unknown_P_018>();
            this.emb7 = reader.ReadBlock<Unknown_P_018>();
            this.emb8 = reader.ReadBlock<Unknown_P_018>();
            this.emb9 = reader.ReadBlock<Unknown_P_018>();
            this.emb10 = reader.ReadBlock<Unknown_P_018>();
            this.pref = reader.ReadUInt64();
            this.refcnt1 = reader.ReadUInt16();
            this.refcnt2 = reader.ReadUInt16();
            this.Unknown_624h = reader.ReadUInt32();
            this.Unknown_628h = reader.ReadUInt32();
            this.Unknown_62Ch = reader.ReadUInt32();

            // read reference data
            this.Name = reader.ReadBlockAt<string_r>(
                this.NamePointer // offset
            );
            this.p2data = reader.ReadBlockAt<Unknown_P_004>(
                this.p2 // offset
            );
            this.p3data = reader.ReadBlockAt<Unknown_P_004>(
                this.p3 // offset
            );
            this.p4data = reader.ReadBlockAt<Unknown_P_004>(
                this.p4 // offset
            );
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
            this.NamePointer = (ulong)(this.Name != null ? this.Name.Position : 0);
            this.p2 = (ulong)(this.p2data != null ? this.p2data.Position : 0);
            this.p3 = (ulong)(this.p3data != null ? this.p3data.Position : 0);
            this.p4 = (ulong)(this.p4data != null ? this.p4data.Position : 0);
            this.pref = (ulong)(this.refs != null ? this.refs.Position : 0);
            //this.refcnt2 = (ushort)(this.refs != null ? this.refs.Count : 0);

            // write structure data
            writer.Write(this.VFT);
            writer.Write(this.Unknown_4h);
            writer.Write(this.Unknown_8h);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.Write(this.Unknown_18h);
            writer.Write(this.Unknown_1Ch);
            writer.Write(this.NamePointer);
            writer.Write(this.Unknown_28h);
            writer.Write(this.Unknown_2Ch);
            writer.Write(this.Unknown_30h);
            writer.Write(this.Unknown_34h);
            writer.Write(this.p2);
            writer.Write(this.Unknown_40h);
            writer.Write(this.Unknown_44h);
            writer.Write(this.p3);
            writer.Write(this.Unknown_50h);
            writer.Write(this.Unknown_54h);
            writer.Write(this.p4);
            writer.Write(this.Unknown_60h);
            writer.Write(this.Unknown_64h);
            writer.Write(this.Unknown_68h);
            writer.Write(this.Unknown_6Ch);
            writer.Write(this.Unknown_70h);
            writer.Write(this.Unknown_74h);
            writer.WriteBlock(this.emb1);
            writer.WriteBlock(this.emb2);
            writer.WriteBlock(this.emb3);
            writer.WriteBlock(this.emb4);
            writer.WriteBlock(this.emb5);
            writer.WriteBlock(this.emb6);
            writer.WriteBlock(this.emb7);
            writer.WriteBlock(this.emb8);
            writer.WriteBlock(this.emb9);
            writer.WriteBlock(this.emb10);
            writer.Write(this.pref);
            writer.Write(this.refcnt1);
            writer.Write(this.refcnt2);
            writer.Write(this.Unknown_624h);
            writer.Write(this.Unknown_628h);
            writer.Write(this.Unknown_62Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (Name != null) list.Add(Name);
            if (p2data != null) list.Add(p2data);
            if (p3data != null) list.Add(p3data);
            if (p4data != null) list.Add(p4data);
            if (refs != null) list.Add(refs);
            return list.ToArray();
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(120, emb1),
                new Tuple<long, IResourceBlock>(264, emb2),
                new Tuple<long, IResourceBlock>(408, emb3),
                new Tuple<long, IResourceBlock>(552, emb4),
                new Tuple<long, IResourceBlock>(696, emb5),
                new Tuple<long, IResourceBlock>(840, emb6),
                new Tuple<long, IResourceBlock>(984, emb7),
                new Tuple<long, IResourceBlock>(1128, emb8),
                new Tuple<long, IResourceBlock>(1272, emb9),
                new Tuple<long, IResourceBlock>(1416, emb10),
            };
        }
    }
}
