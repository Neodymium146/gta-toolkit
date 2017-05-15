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
using System;

namespace RageLib.Resources.GTA5.PC.Bounds
{
    public class BVH : ResourceSystemBlock
    {
        public override long Length => 0x80;

        // structure data
        public ulong NodesPointer;
        public uint NodesCount;
        public uint NodesCapacity;
        public uint Unknown_10h; // 0x00000000
        public uint Unknown_14h; // 0x00000000
        public uint Unknown_18h; // 0x00000000
        public uint Unknown_1Ch; // 0x00000000
        public RAGE_Vector4 BoundingBoxMin;
        public RAGE_Vector4 BoundingBoxMax;
        public RAGE_Vector4 BoundingBoxCenter;
        public RAGE_Vector4 QuantumInverse;
        public RAGE_Vector4 Quantum; // bounding box dimension / 2^16
        public ulong TreesPointer;
        public ushort TreesCount1;
        public ushort TreesCount2;
        public uint Unknown_7Ch;

        // reference data
        public ResourceSimpleArray<BVHNode> Nodes;
        public ResourceSimpleArray<BVHTreeInfo> Trees;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.NodesPointer = reader.ReadUInt64();
            this.NodesCount = reader.ReadUInt32();
            this.NodesCapacity = reader.ReadUInt32();
            this.Unknown_10h = reader.ReadUInt32();
            this.Unknown_14h = reader.ReadUInt32();
            this.Unknown_18h = reader.ReadUInt32();
            this.Unknown_1Ch = reader.ReadUInt32();
            this.BoundingBoxMin = reader.ReadBlock<RAGE_Vector4>();
            this.BoundingBoxMax = reader.ReadBlock<RAGE_Vector4>();
            this.BoundingBoxCenter = reader.ReadBlock<RAGE_Vector4>();
            this.QuantumInverse = reader.ReadBlock<RAGE_Vector4>();
            this.Quantum = reader.ReadBlock<RAGE_Vector4>();
            this.TreesPointer = reader.ReadUInt64();
            this.TreesCount1 = reader.ReadUInt16();
            this.TreesCount2 = reader.ReadUInt16();
            this.Unknown_7Ch = reader.ReadUInt32();

            // read reference data
            this.Nodes = reader.ReadBlockAt<ResourceSimpleArray<BVHNode>>(
                this.NodesPointer, // offset
                this.NodesCount
            );
            this.Trees = reader.ReadBlockAt<ResourceSimpleArray<BVHTreeInfo>>(
               this.TreesPointer, // offset
               this.TreesCount1
           );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.NodesPointer = (ulong)(this.Nodes != null ? this.Nodes.Position : 0);
            this.NodesCount = (uint)(this.Nodes != null ? this.Nodes.Count : 0);
            this.NodesCapacity = (uint)(this.Nodes != null ? this.Nodes.Count : 0);
            this.TreesPointer = (ulong)(this.Trees != null ? this.Trees.Position : 0);
            this.TreesCount1 = (ushort)(this.Trees != null ? this.Trees.Count : 0);
            this.TreesCount2 = (ushort)(this.Trees != null ? this.Trees.Count : 0);

            // write structure data
            writer.Write(this.NodesPointer);
            writer.Write(this.NodesCount);
            writer.Write(this.NodesCapacity);
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.Write(this.Unknown_18h);
            writer.Write(this.Unknown_1Ch);
            writer.WriteBlock(this.BoundingBoxMin);
            writer.WriteBlock(this.BoundingBoxMax);
            writer.WriteBlock(this.BoundingBoxCenter);
            writer.WriteBlock(this.QuantumInverse);
            writer.WriteBlock(this.Quantum);
            writer.Write(this.TreesPointer);
            writer.Write(this.TreesCount1);
            writer.Write(this.TreesCount2);
            writer.Write(this.Unknown_7Ch);
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
                new Tuple<long, IResourceBlock>(0x60, Quantum)
            };
        }
    }
}
