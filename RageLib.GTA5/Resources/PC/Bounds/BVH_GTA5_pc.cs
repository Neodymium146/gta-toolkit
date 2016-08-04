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
using System.Collections.Generic;
using System;

namespace RageLib.Resources.GTA5.PC.Bounds
{
    public class BVH_GTA5_pc : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 128; }
        }

        // structure data
        public ulong NodesPointer;
        public uint NodesCount;
        public uint Count2;
        public uint Unknown_10h; // 0x00000000
        public uint Unknown_14h; // 0x00000000
        public uint Unknown_18h; // 0x00000000
        public uint Unknown_1Ch; // 0x00000000
        public RAGE_Vector4 BoundingBoxMin;
        public RAGE_Vector4 BoundingBoxMax;
        public RAGE_Vector4 BoundingBoxCenter;
        public RAGE_Vector4 QuantumInverse;
        public RAGE_Vector4 Quantum; // bounding box dimension / 2^16
        public ResourceSimpleList64<BVHTreeInfo_GTA5_pc> Trees;

        // reference data
        public ResourceSimpleArray2<BVHNode_GTA5_pc, Unknown_B_003> Nodes;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.NodesPointer = reader.ReadUInt64();
            this.NodesCount = reader.ReadUInt32();
            this.Count2 = reader.ReadUInt32();
            this.Unknown_10h = reader.ReadUInt32();
            this.Unknown_14h = reader.ReadUInt32();
            this.Unknown_18h = reader.ReadUInt32();
            this.Unknown_1Ch = reader.ReadUInt32();
            this.BoundingBoxMin = reader.ReadBlock<RAGE_Vector4>();
            this.BoundingBoxMax = reader.ReadBlock<RAGE_Vector4>();
            this.BoundingBoxCenter = reader.ReadBlock<RAGE_Vector4>();
            this.QuantumInverse = reader.ReadBlock<RAGE_Vector4>();
            this.Quantum = reader.ReadBlock<RAGE_Vector4>();
            this.Trees = reader.ReadBlock<ResourceSimpleList64<BVHTreeInfo_GTA5_pc>>();

            // read reference data
            this.Nodes = reader.ReadBlockAt<ResourceSimpleArray2<BVHNode_GTA5_pc, Unknown_B_003>>(
                this.NodesPointer, // offset
                this.NodesCount,
                this.Count2 - this.NodesCount
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.NodesPointer = (ulong)(this.Nodes != null ? this.Nodes.Position : 0);
            this.NodesCount = (uint)(this.Nodes != null ? this.Nodes.Array1.Count : 0);
            this.Count2 = (uint)(this.Nodes != null ? this.Nodes.Array1.Count + this.Nodes.Array2.Count : 0);

            // write structure data
            writer.Write(this.NodesPointer);
            writer.Write(this.NodesCount);
            writer.Write(this.Count2);
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.Write(this.Unknown_18h);
            writer.Write(this.Unknown_1Ch);
            writer.WriteBlock(this.BoundingBoxMin);
            writer.WriteBlock(this.BoundingBoxMax);
            writer.WriteBlock(this.BoundingBoxCenter);
            writer.WriteBlock(this.QuantumInverse);
            writer.WriteBlock(this.Quantum);
            writer.WriteBlock(this.Trees);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (Nodes != null) list.Add(Nodes);
            if (Trees != null) list.Add(Trees);
            return list.ToArray();
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(0x20, BoundingBoxMin),
                new Tuple<long, IResourceBlock>(0x30, BoundingBoxMax),
                new Tuple<long, IResourceBlock>(0x40, BoundingBoxCenter),
                new Tuple<long, IResourceBlock>(0x50, QuantumInverse),
                new Tuple<long, IResourceBlock>(0x60, Quantum),
                new Tuple<long, IResourceBlock>(0x70, Trees)
            };
        }
    }
}
