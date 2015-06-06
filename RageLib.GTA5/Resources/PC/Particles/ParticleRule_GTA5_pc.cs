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
    public class ParticleRule_GTA5_pc : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 576; }
        }

        // structure data
        public uint VFT;
        public uint Unknown_4h;
        public uint Unknown_8h;
        public uint Unknown_Ch;
        public uint Unknown_10h;
        public uint Unknown_14h;
        public uint Unknown_18h;
        public uint Unknown_1Ch;
        public Unknown_P_020 emb1;
        public Unknown_P_020 emb2;
        public uint Unknown_100h;
        public uint Unknown_104h;
        public uint Unknown_108h;
        public uint Unknown_10Ch;
        public uint Unknown_110h;
        public uint Unknown_114h;
        public uint Unknown_118h;
        public uint Unknown_11Ch;
        public ulong NamePointer;
        public ulong p4;
        public ushort c1;
        public ushort c2;
        public uint Unknown_134h;
        public ulong p5;
        public ushort c3;
        public ushort c4;
        public uint Unknown_144h;
        public ulong p6;
        public ushort c5;
        public ushort c6;
        public uint Unknown_154h;
        public ulong p7;
        public ushort c7a;
        public ushort c7b;
        public uint Unknown_164h;
        public ulong p8;
        public ushort c8;
        public ushort c9;
        public uint Unknown_174h;
        public uint Unknown_178h;
        public uint Unknown_17Ch;
        public uint Unknown_180h;
        public uint Unknown_184h;
        public ulong pxx;
        public ushort cxx1;
        public ushort cxx2;
        public uint Unknown_194h;
        public uint Unknown_198h;
        public uint Unknown_19Ch;
        public uint Unknown_1A0h;
        public uint Unknown_1A4h;
        public uint Unknown_1A8h;
        public uint Unknown_1ACh;
        public uint VFTx3;
        public uint Unknown_1B4h;
        public ulong p9;
        public ulong p10;
        public uint Unknown_1C8h;
        public uint Unknown_1CCh;
        public uint Unknown_1D0h;
        public uint Unknown_1D4h;
        public uint VFTx4;
        public uint Unknown_1DCh;
        public uint Unknown_1E0h;
        public uint Unknown_1E4h;
        public uint Unknown_1E8h;
        public uint Unknown_1ECh;
        public ulong p11;
        public ushort c11a;
        public ushort c11b;
        public uint Unknown_1FCh;
        public uint Unknown_200h;
        public uint Unknown_204h;
        public uint Unknown_208h;
        public uint Unknown_20Ch;
        public ulong p12;
        public ushort c12a;
        public ushort c12b;
        public uint Unknown_21Ch;
        public uint Unknown_220h;
        public uint Unknown_224h;
        public uint Unknown_228h;
        public uint Unknown_22Ch;
        public uint Unknown_230h;
        public uint Unknown_234h;
        public uint Unknown_238h;
        public uint Unknown_23Ch;

        // reference data
        public string_r Name;
        public ResourcePointerArray64<Unknown_P_006> p4data;
        public ResourcePointerArray64<Unknown_P_006> p5data;
        public ResourcePointerArray64<Unknown_P_006> p6data;
        public ResourcePointerArray64<Unknown_P_006> p7data;
        public ResourcePointerArray64<Unknown_P_006> p8data;
        public ResourceSimpleArray<Unknown_P_032> pxxdata;
        public string_r p9data;
        public string_r p10data;
        public ResourcePointerArray64<Unknown_P_007> p11data;
        public ResourceSimpleArray<Unknown_P_022> p12data;

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
            this.emb1 = reader.ReadBlock<Unknown_P_020>();
            this.emb2 = reader.ReadBlock<Unknown_P_020>();
            this.Unknown_100h = reader.ReadUInt32();
            this.Unknown_104h = reader.ReadUInt32();
            this.Unknown_108h = reader.ReadUInt32();
            this.Unknown_10Ch = reader.ReadUInt32();
            this.Unknown_110h = reader.ReadUInt32();
            this.Unknown_114h = reader.ReadUInt32();
            this.Unknown_118h = reader.ReadUInt32();
            this.Unknown_11Ch = reader.ReadUInt32();
            this.NamePointer = reader.ReadUInt64();
            this.p4 = reader.ReadUInt64();
            this.c1 = reader.ReadUInt16();
            this.c2 = reader.ReadUInt16();
            this.Unknown_134h = reader.ReadUInt32();
            this.p5 = reader.ReadUInt64();
            this.c3 = reader.ReadUInt16();
            this.c4 = reader.ReadUInt16();
            this.Unknown_144h = reader.ReadUInt32();
            this.p6 = reader.ReadUInt64();
            this.c5 = reader.ReadUInt16();
            this.c6 = reader.ReadUInt16();
            this.Unknown_154h = reader.ReadUInt32();
            this.p7 = reader.ReadUInt64();
            this.c7a = reader.ReadUInt16();
            this.c7b = reader.ReadUInt16();
            this.Unknown_164h = reader.ReadUInt32();
            this.p8 = reader.ReadUInt64();
            this.c8 = reader.ReadUInt16();
            this.c9 = reader.ReadUInt16();
            this.Unknown_174h = reader.ReadUInt32();
            this.Unknown_178h = reader.ReadUInt32();
            this.Unknown_17Ch = reader.ReadUInt32();
            this.Unknown_180h = reader.ReadUInt32();
            this.Unknown_184h = reader.ReadUInt32();
            this.pxx = reader.ReadUInt64();
            this.cxx1 = reader.ReadUInt16();
            this.cxx2 = reader.ReadUInt16();
            this.Unknown_194h = reader.ReadUInt32();
            this.Unknown_198h = reader.ReadUInt32();
            this.Unknown_19Ch = reader.ReadUInt32();
            this.Unknown_1A0h = reader.ReadUInt32();
            this.Unknown_1A4h = reader.ReadUInt32();
            this.Unknown_1A8h = reader.ReadUInt32();
            this.Unknown_1ACh = reader.ReadUInt32();
            this.VFTx3 = reader.ReadUInt32();
            this.Unknown_1B4h = reader.ReadUInt32();
            this.p9 = reader.ReadUInt64();
            this.p10 = reader.ReadUInt64();
            this.Unknown_1C8h = reader.ReadUInt32();
            this.Unknown_1CCh = reader.ReadUInt32();
            this.Unknown_1D0h = reader.ReadUInt32();
            this.Unknown_1D4h = reader.ReadUInt32();
            this.VFTx4 = reader.ReadUInt32();
            this.Unknown_1DCh = reader.ReadUInt32();
            this.Unknown_1E0h = reader.ReadUInt32();
            this.Unknown_1E4h = reader.ReadUInt32();
            this.Unknown_1E8h = reader.ReadUInt32();
            this.Unknown_1ECh = reader.ReadUInt32();
            this.p11 = reader.ReadUInt64();
            this.c11a = reader.ReadUInt16();
            this.c11b = reader.ReadUInt16();
            this.Unknown_1FCh = reader.ReadUInt32();
            this.Unknown_200h = reader.ReadUInt32();
            this.Unknown_204h = reader.ReadUInt32();
            this.Unknown_208h = reader.ReadUInt32();
            this.Unknown_20Ch = reader.ReadUInt32();
            this.p12 = reader.ReadUInt64();
            this.c12a = reader.ReadUInt16();
            this.c12b = reader.ReadUInt16();
            this.Unknown_21Ch = reader.ReadUInt32();
            this.Unknown_220h = reader.ReadUInt32();
            this.Unknown_224h = reader.ReadUInt32();
            this.Unknown_228h = reader.ReadUInt32();
            this.Unknown_22Ch = reader.ReadUInt32();
            this.Unknown_230h = reader.ReadUInt32();
            this.Unknown_234h = reader.ReadUInt32();
            this.Unknown_238h = reader.ReadUInt32();
            this.Unknown_23Ch = reader.ReadUInt32();

            // read reference data
            this.Name = reader.ReadBlockAt<string_r>(
                this.NamePointer // offset
            );
            this.p4data = reader.ReadBlockAt<ResourcePointerArray64<Unknown_P_006>>(
                this.p4, // offset
                this.c1
            );
            this.p5data = reader.ReadBlockAt<ResourcePointerArray64<Unknown_P_006>>(
                this.p5, // offset
                this.c3
            );
            this.p6data = reader.ReadBlockAt<ResourcePointerArray64<Unknown_P_006>>(
                this.p6, // offset
                this.c5
            );
            this.p7data = reader.ReadBlockAt<ResourcePointerArray64<Unknown_P_006>>(
                this.p7, // offset
                this.c7a
            );
            this.p8data = reader.ReadBlockAt<ResourcePointerArray64<Unknown_P_006>>(
                this.p8, // offset
                this.c8
            );
            this.pxxdata = reader.ReadBlockAt<ResourceSimpleArray<Unknown_P_032>>(
                this.pxx, // offset
                this.cxx1
            );
            this.p9data = reader.ReadBlockAt<string_r>(
                this.p9 // offset
            );
            this.p10data = reader.ReadBlockAt<string_r>(
                this.p10 // offset
            );
            this.p11data = reader.ReadBlockAt<ResourcePointerArray64<Unknown_P_007>>(
                this.p11, // offset
                this.c11a
            );
            this.p12data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_P_022>>(
                this.p12, // offset
                this.c12a
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.NamePointer = (ulong)(this.Name != null ? this.Name.Position : 0);
            this.p4 = (ulong)(this.p4data != null ? this.p4data.Position : 0);
            //this.c1 = (ushort)(this.p4data != null ? this.p4data.Count : 0);
            this.p5 = (ulong)(this.p5data != null ? this.p5data.Position : 0);
            //this.c3 = (ushort)(this.p5data != null ? this.p5data.Count : 0);
            this.p6 = (ulong)(this.p6data != null ? this.p6data.Position : 0);
            //this.c5 = (ushort)(this.p6data != null ? this.p6data.Count : 0);
            this.p7 = (ulong)(this.p7data != null ? this.p7data.Position : 0);
            //this.c7a = (ushort)(this.p7data != null ? this.p7data.Count : 0);
            this.p8 = (ulong)(this.p8data != null ? this.p8data.Position : 0);
            //this.c8 = (ushort)(this.p8data != null ? this.p8data.Count : 0);
            this.pxx = (ulong)(this.pxxdata != null ? this.pxxdata.Position : 0);
            //this.cxx1 = (ushort)(this.pxxdata != null ? this.pxxdata.Count : 0);
            this.p9 = (ulong)(this.p9data != null ? this.p9data.Position : 0);
            this.p10 = (ulong)(this.p10data != null ? this.p10data.Position : 0);
            this.p11 = (ulong)(this.p11data != null ? this.p11data.Position : 0);
            //this.c11a = (ushort)(this.p11data != null ? this.p11data.Count : 0);
            this.p12 = (ulong)(this.p12data != null ? this.p12data.Position : 0);
            //this.c12a = (ushort)(this.p12data != null ? this.p12data.Count : 0);

            // write structure data
            writer.Write(this.VFT);
            writer.Write(this.Unknown_4h);
            writer.Write(this.Unknown_8h);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.Write(this.Unknown_18h);
            writer.Write(this.Unknown_1Ch);
            writer.WriteBlock(this.emb1);
            writer.WriteBlock(this.emb2);
            writer.Write(this.Unknown_100h);
            writer.Write(this.Unknown_104h);
            writer.Write(this.Unknown_108h);
            writer.Write(this.Unknown_10Ch);
            writer.Write(this.Unknown_110h);
            writer.Write(this.Unknown_114h);
            writer.Write(this.Unknown_118h);
            writer.Write(this.Unknown_11Ch);
            writer.Write(this.NamePointer);
            writer.Write(this.p4);
            writer.Write(this.c1);
            writer.Write(this.c2);
            writer.Write(this.Unknown_134h);
            writer.Write(this.p5);
            writer.Write(this.c3);
            writer.Write(this.c4);
            writer.Write(this.Unknown_144h);
            writer.Write(this.p6);
            writer.Write(this.c5);
            writer.Write(this.c6);
            writer.Write(this.Unknown_154h);
            writer.Write(this.p7);
            writer.Write(this.c7a);
            writer.Write(this.c7b);
            writer.Write(this.Unknown_164h);
            writer.Write(this.p8);
            writer.Write(this.c8);
            writer.Write(this.c9);
            writer.Write(this.Unknown_174h);
            writer.Write(this.Unknown_178h);
            writer.Write(this.Unknown_17Ch);
            writer.Write(this.Unknown_180h);
            writer.Write(this.Unknown_184h);
            writer.Write(this.pxx);
            writer.Write(this.cxx1);
            writer.Write(this.cxx2);
            writer.Write(this.Unknown_194h);
            writer.Write(this.Unknown_198h);
            writer.Write(this.Unknown_19Ch);
            writer.Write(this.Unknown_1A0h);
            writer.Write(this.Unknown_1A4h);
            writer.Write(this.Unknown_1A8h);
            writer.Write(this.Unknown_1ACh);
            writer.Write(this.VFTx3);
            writer.Write(this.Unknown_1B4h);
            writer.Write(this.p9);
            writer.Write(this.p10);
            writer.Write(this.Unknown_1C8h);
            writer.Write(this.Unknown_1CCh);
            writer.Write(this.Unknown_1D0h);
            writer.Write(this.Unknown_1D4h);
            writer.Write(this.VFTx4);
            writer.Write(this.Unknown_1DCh);
            writer.Write(this.Unknown_1E0h);
            writer.Write(this.Unknown_1E4h);
            writer.Write(this.Unknown_1E8h);
            writer.Write(this.Unknown_1ECh);
            writer.Write(this.p11);
            writer.Write(this.c11a);
            writer.Write(this.c11b);
            writer.Write(this.Unknown_1FCh);
            writer.Write(this.Unknown_200h);
            writer.Write(this.Unknown_204h);
            writer.Write(this.Unknown_208h);
            writer.Write(this.Unknown_20Ch);
            writer.Write(this.p12);
            writer.Write(this.c12a);
            writer.Write(this.c12b);
            writer.Write(this.Unknown_21Ch);
            writer.Write(this.Unknown_220h);
            writer.Write(this.Unknown_224h);
            writer.Write(this.Unknown_228h);
            writer.Write(this.Unknown_22Ch);
            writer.Write(this.Unknown_230h);
            writer.Write(this.Unknown_234h);
            writer.Write(this.Unknown_238h);
            writer.Write(this.Unknown_23Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (Name != null) list.Add(Name);
            if (p4data != null) list.Add(p4data);
            if (p5data != null) list.Add(p5data);
            if (p6data != null) list.Add(p6data);
            if (p7data != null) list.Add(p7data);
            if (p8data != null) list.Add(p8data);
            if (pxxdata != null) list.Add(pxxdata);
            if (p9data != null) list.Add(p9data);
            if (p10data != null) list.Add(p10data);
            if (p11data != null) list.Add(p11data);
            if (p12data != null) list.Add(p12data);
            return list.ToArray();
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(88, emb1),
                new Tuple<long, IResourceBlock>(96, emb2)
            };
        }

    }
}