/*
    Copyright(c) 2017 Neodymium

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
using System.Collections.Generic;
using System.Numerics;

namespace RageLib.Resources.GTA5.PC.Navigations
{
    // CNavMesh
    public class Navigation : PgBase64
    {
        public override long BlockLength => 0x170;

        // structure data
        public uint Unknown_10h;
        public uint Unknown_14h; // 0x00010011
        public uint Unknown_18h; // 0x00000000
        public uint Unknown_1Ch; // 0x00000000
        public Matrix4x4 Unknown_20h;
        public Vector4 Unknown_60h;
        public ulong VerticesPointer;
        public uint Unknown_78h; // 0x00000000
        public uint Unknown_7Ch; // 0x00000000
        public ulong IndicesPointer;
        public ulong AdjPolysPointer;
        public uint Unknown_90h;
        public uint Unknown_94h;
        public uint Unknown_98h;
        public uint Unknown_9Ch;
        public uint Unknown_A0h;
        public uint Unknown_A4h;
        public uint Unknown_A8h;  
        public uint Unknown_ACh;
        public uint Unknown_B0h; // 0x00000000
        public uint Unknown_B4h; // 0x00000000
        public uint Unknown_B8h; // 0x00000000  
        public uint Unknown_BCh; // 0x00000000
        public uint Unknown_C0h; // 0x00000000
        public uint Unknown_C4h; // 0x00000000
        public uint Unknown_C8h; // 0x00000000  
        public uint Unknown_CCh; // 0x00000000
        public uint Unknown_D0h; // 0x00000000
        public uint Unknown_D4h; // 0x00000000
        public uint Unknown_D8h; // 0x00000000 
        public uint Unknown_DCh; // 0x00000000
        public uint Unknown_E0h; // 0x00000000
        public uint Unknown_E4h; // 0x00000000
        public uint Unknown_E8h; // 0x00000000 
        public uint Unknown_ECh; // 0x00000000
        public uint Unknown_F0h; // 0x00000000
        public uint Unknown_F4h; // 0x00000000
        public uint Unknown_F8h; // 0x00000000 
        public uint Unknown_FCh; // 0x00000000
        public uint Unknown_100h; // 0x00000000
        public uint Unknown_104h; // 0x00000000
        public uint Unknown_108h; // 0x00000000
        public uint Unknown_10Ch; // 0x00000000
        public uint Unknown_110h; // 0x00000000
        public uint Unknown_114h; // 0x00000000
        public ulong PolysPointer;
        public ulong SectorTreePointer;
        public ulong PortalsPointer;
        public ulong p8;
        public uint Unknown_138h;
        public uint Unknown_13Ch;
        public uint Unknown_140h;
        public uint Unknown_144h;
        public uint Unknown_148h;
        public uint PortalsCount;
        public uint c1;
        public uint Unknown_154h; // 0x00000000
        public uint Unknown_158h; // 0x00000000
        public uint Unknown_15Ch; // 0x00000000
        public uint Unknown_160h;
        public uint Unknown_164h; // 0x00000000
        public uint Unknown_168h; // 0x00000000
        public uint Unknown_16Ch; // 0x00000000

        // reference data
        public ResourceSplitArray<Vertex> Vertices;
        public ResourceSplitArray<ushort_r> Indices;
        public ResourceSplitArray<AdjPoly> AdjPolys;
        public ResourceSplitArray<Poly> Polys;
        public Sector SectorTree;
        public ResourceSimpleArray<Portal> Portals;
        public SimpleArray<ushort> p8data;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.Unknown_10h = reader.ReadUInt32();
            this.Unknown_14h = reader.ReadUInt32();
            this.Unknown_18h = reader.ReadUInt32();
            this.Unknown_1Ch = reader.ReadUInt32();
            this.Unknown_20h = reader.ReadMatrix4x4();
            this.Unknown_60h = reader.ReadVector4();
            this.VerticesPointer = reader.ReadUInt64();
            this.Unknown_78h = reader.ReadUInt32();
            this.Unknown_7Ch = reader.ReadUInt32();
            this.IndicesPointer = reader.ReadUInt64();
            this.AdjPolysPointer = reader.ReadUInt64();
            this.Unknown_90h = reader.ReadUInt32();
            this.Unknown_94h = reader.ReadUInt32();
            this.Unknown_98h = reader.ReadUInt32();
            this.Unknown_9Ch = reader.ReadUInt32();
            this.Unknown_A0h = reader.ReadUInt32();
            this.Unknown_A4h = reader.ReadUInt32();
            this.Unknown_A8h = reader.ReadUInt32();
            this.Unknown_ACh = reader.ReadUInt32();
            this.Unknown_B0h = reader.ReadUInt32();
            this.Unknown_B4h = reader.ReadUInt32();
            this.Unknown_B8h = reader.ReadUInt32();
            this.Unknown_BCh = reader.ReadUInt32();
            this.Unknown_C0h = reader.ReadUInt32();
            this.Unknown_C4h = reader.ReadUInt32();
            this.Unknown_C8h = reader.ReadUInt32();
            this.Unknown_CCh = reader.ReadUInt32();
            this.Unknown_D0h = reader.ReadUInt32();
            this.Unknown_D4h = reader.ReadUInt32();
            this.Unknown_D8h = reader.ReadUInt32();
            this.Unknown_DCh = reader.ReadUInt32();
            this.Unknown_E0h = reader.ReadUInt32();
            this.Unknown_E4h = reader.ReadUInt32();
            this.Unknown_E8h = reader.ReadUInt32();
            this.Unknown_ECh = reader.ReadUInt32();
            this.Unknown_F0h = reader.ReadUInt32();
            this.Unknown_F4h = reader.ReadUInt32();
            this.Unknown_F8h = reader.ReadUInt32();
            this.Unknown_FCh = reader.ReadUInt32();
            this.Unknown_100h = reader.ReadUInt32();
            this.Unknown_104h = reader.ReadUInt32();
            this.Unknown_108h = reader.ReadUInt32();
            this.Unknown_10Ch = reader.ReadUInt32();
            this.Unknown_110h = reader.ReadUInt32();
            this.Unknown_114h = reader.ReadUInt32();
            this.PolysPointer = reader.ReadUInt64();
            this.SectorTreePointer = reader.ReadUInt64();
            this.PortalsPointer = reader.ReadUInt64();
            this.p8 = reader.ReadUInt64();
            this.Unknown_138h = reader.ReadUInt32();
            this.Unknown_13Ch = reader.ReadUInt32();
            this.Unknown_140h = reader.ReadUInt32();
            this.Unknown_144h = reader.ReadUInt32();
            this.Unknown_148h = reader.ReadUInt32();
            this.PortalsCount = reader.ReadUInt32();
            this.c1 = reader.ReadUInt32();
            this.Unknown_154h = reader.ReadUInt32();
            this.Unknown_158h = reader.ReadUInt32();
            this.Unknown_15Ch = reader.ReadUInt32();
            this.Unknown_160h = reader.ReadUInt32();
            this.Unknown_164h = reader.ReadUInt32();
            this.Unknown_168h = reader.ReadUInt32();
            this.Unknown_16Ch = reader.ReadUInt32();

            // read reference data
            this.Vertices = reader.ReadBlockAt<ResourceSplitArray<Vertex>>(
                this.VerticesPointer // offset
            );
            this.Indices = reader.ReadBlockAt<ResourceSplitArray<ushort_r>>(
                this.IndicesPointer // offset
            );
            this.AdjPolys = reader.ReadBlockAt<ResourceSplitArray<AdjPoly>>(
                this.AdjPolysPointer // offset
            );
            this.Polys = reader.ReadBlockAt<ResourceSplitArray<Poly>>(
                this.PolysPointer // offset
            );
            this.SectorTree = reader.ReadBlockAt<Sector>(
                this.SectorTreePointer // offset
            );
            this.Portals = reader.ReadBlockAt<ResourceSimpleArray<Portal>>(
                this.PortalsPointer, // offset
                this.PortalsCount
            );
            this.p8data = reader.ReadBlockAt<SimpleArray<ushort>>(
                this.p8, // offset
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
            this.VerticesPointer = (ulong)(this.Vertices != null ? this.Vertices.BlockPosition : 0);
            this.IndicesPointer = (ulong)(this.Indices != null ? this.Indices.BlockPosition : 0);
            this.AdjPolysPointer = (ulong)(this.AdjPolys != null ? this.AdjPolys.BlockPosition : 0);
            this.PolysPointer = (ulong)(this.Polys != null ? this.Polys.BlockPosition : 0);
            this.SectorTreePointer = (ulong)(this.SectorTree != null ? this.SectorTree.BlockPosition : 0);
            this.PortalsPointer = (ulong)(this.Portals != null ? this.Portals.BlockPosition : 0);
            this.p8 = (ulong)(this.p8data != null ? this.p8data.BlockPosition : 0);
            // this.c0 = (uint)(this.p7data != null ? this.p7data.Count : 0);
            // this.c1 = (uint)(this.p8data != null ? this.p8data.Count : 0);

            // write structure data
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.Write(this.Unknown_18h);
            writer.Write(this.Unknown_1Ch);
            writer.Write(this.Unknown_20h);
            writer.Write(this.Unknown_60h);
            writer.Write(this.VerticesPointer);
            writer.Write(this.Unknown_78h);
            writer.Write(this.Unknown_7Ch);
            writer.Write(this.IndicesPointer);
            writer.Write(this.AdjPolysPointer);
            writer.Write(this.Unknown_90h);
            writer.Write(this.Unknown_94h);
            writer.Write(this.Unknown_98h);
            writer.Write(this.Unknown_9Ch);
            writer.Write(this.Unknown_A0h);
            writer.Write(this.Unknown_A4h);
            writer.Write(this.Unknown_A8h);
            writer.Write(this.Unknown_ACh);
            writer.Write(this.Unknown_B0h);
            writer.Write(this.Unknown_B4h);
            writer.Write(this.Unknown_B8h);
            writer.Write(this.Unknown_BCh);
            writer.Write(this.Unknown_C0h);
            writer.Write(this.Unknown_C4h);
            writer.Write(this.Unknown_C8h);
            writer.Write(this.Unknown_CCh);
            writer.Write(this.Unknown_D0h);
            writer.Write(this.Unknown_D4h);
            writer.Write(this.Unknown_D8h);
            writer.Write(this.Unknown_DCh);
            writer.Write(this.Unknown_E0h);
            writer.Write(this.Unknown_E4h);
            writer.Write(this.Unknown_E8h);
            writer.Write(this.Unknown_ECh);
            writer.Write(this.Unknown_F0h);
            writer.Write(this.Unknown_F4h);
            writer.Write(this.Unknown_F8h);
            writer.Write(this.Unknown_FCh);
            writer.Write(this.Unknown_100h);
            writer.Write(this.Unknown_104h);
            writer.Write(this.Unknown_108h);
            writer.Write(this.Unknown_10Ch);
            writer.Write(this.Unknown_110h);
            writer.Write(this.Unknown_114h);
            writer.Write(this.PolysPointer);
            writer.Write(this.SectorTreePointer);
            writer.Write(this.PortalsPointer);
            writer.Write(this.p8);
            writer.Write(this.Unknown_138h);
            writer.Write(this.Unknown_13Ch);
            writer.Write(this.Unknown_140h);
            writer.Write(this.Unknown_144h);
            writer.Write(this.Unknown_148h);
            writer.Write(this.PortalsCount);
            writer.Write(this.c1);
            writer.Write(this.Unknown_154h);
            writer.Write(this.Unknown_158h);
            writer.Write(this.Unknown_15Ch);
            writer.Write(this.Unknown_160h);
            writer.Write(this.Unknown_164h);
            writer.Write(this.Unknown_168h);
            writer.Write(this.Unknown_16Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>(base.GetReferences());
            if (Vertices != null) list.Add(Vertices);
            if (Indices != null) list.Add(Indices);
            if (AdjPolys != null) list.Add(AdjPolys);
            if (Polys != null) list.Add(Polys);
            if (SectorTree != null) list.Add(SectorTree);
            if (Portals != null) list.Add(Portals);
            if (p8data != null) list.Add(p8data);
            return list.ToArray();
        }

    }
}
