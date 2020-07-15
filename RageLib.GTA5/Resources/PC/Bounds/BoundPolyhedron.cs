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

namespace RageLib.Resources.GTA5.PC.Bounds
{
    // phBoundPolyhedron
    public class BoundPolyhedron : Bound
    {
        public override long BlockLength => 0xF0;

        // structure data
        public uint Unknown_70h;
        public uint Unknown_74h;
        public ulong Unknown_78h_Pointer;
        public uint Unknown_80h;
        public uint VerticesCount1;
        public ulong PrimitivesPointer;
        public Vector4 Quantum;
        public Vector4 Offset;
        public ulong VerticesPointer;
        public ulong Unknown_B8h_Pointer;
        public ulong Unknown_C0h_Pointer;
        public ulong Unknown_C8h_Pointer;
        public uint VerticesCount2;
        public uint PrimitivesCount;
        public ulong Unknown_D8h; // 0x0000000000000000
        public ulong Unknown_E0h; // 0x0000000000000000
        public ulong Unknown_E8h; // 0x0000000000000000

        // reference data
        public ResourceSimpleArray<BoundVertex> Unknown_78h_Data;
        public ResourceSimpleArray<BoundPrimitive> Primitives;
        public ResourceSimpleArray<BoundVertex> Vertices;
        public ResourceSimpleArray<uint_r> Unknown_B8h_Data;
        public ResourceSimpleArray<uint_r> Unknown_C0h_Data;
        public ResourceSimpleArrayArray64<uint_r> Unknown_C8h_Data;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.Unknown_70h = reader.ReadUInt32();
            this.Unknown_74h = reader.ReadUInt32();
            this.Unknown_78h_Pointer = reader.ReadUInt64();
            this.Unknown_80h = reader.ReadUInt32();
            this.VerticesCount1 = reader.ReadUInt32();
            this.PrimitivesPointer = reader.ReadUInt64();
            this.Quantum = reader.ReadVector4();
            this.Offset = reader.ReadVector4();
            this.VerticesPointer = reader.ReadUInt64();
            this.Unknown_B8h_Pointer = reader.ReadUInt64();
            this.Unknown_C0h_Pointer = reader.ReadUInt64();
            this.Unknown_C8h_Pointer = reader.ReadUInt64();
            this.VerticesCount2 = reader.ReadUInt32();
            this.PrimitivesCount = reader.ReadUInt32();
            this.Unknown_D8h = reader.ReadUInt64();
            this.Unknown_E0h = reader.ReadUInt64();
            this.Unknown_E8h = reader.ReadUInt64();

            // read reference data
            this.Unknown_78h_Data = reader.ReadBlockAt<ResourceSimpleArray<BoundVertex>>(
                this.Unknown_78h_Pointer, // offset
                this.VerticesCount2
            );
            this.Primitives = reader.ReadBlockAt<ResourceSimpleArray<BoundPrimitive>>(
                this.PrimitivesPointer, // offset
                this.PrimitivesCount
            );
            this.Vertices = reader.ReadBlockAt<ResourceSimpleArray<BoundVertex>>(
                this.VerticesPointer, // offset
                this.VerticesCount2
            );
            this.Unknown_B8h_Data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(
                this.Unknown_B8h_Pointer, // offset
                this.VerticesCount2
            );
            this.Unknown_C0h_Data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(
                this.Unknown_C0h_Pointer, // offset
                8
            );
            this.Unknown_C8h_Data = reader.ReadBlockAt<ResourceSimpleArrayArray64<uint_r>>(
                this.Unknown_C8h_Pointer, // offset
                8,
                this.Unknown_C0h_Data
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.Unknown_78h_Pointer = (ulong)(this.Unknown_78h_Data != null ? this.Unknown_78h_Data.BlockPosition : 0);
            this.VerticesCount1 = (uint)(this.Vertices != null ? this.Vertices.Count : 0);
            this.PrimitivesPointer = (ulong)(this.Primitives != null ? this.Primitives.BlockPosition : 0);
            this.VerticesPointer = (ulong)(this.Vertices != null ? this.Vertices.BlockPosition : 0);
            this.Unknown_B8h_Pointer = (ulong)(this.Unknown_B8h_Data != null ? this.Unknown_B8h_Data.BlockPosition : 0);
            this.Unknown_C0h_Pointer = (ulong)(this.Unknown_C0h_Data != null ? this.Unknown_C0h_Data.BlockPosition : 0);
            this.Unknown_C8h_Pointer = (ulong)(this.Unknown_C8h_Data != null ? this.Unknown_C8h_Data.BlockPosition : 0);
            this.VerticesCount2 = (uint)(this.Vertices != null ? this.Vertices.Count : 0);
            this.PrimitivesCount = (uint)(this.Primitives != null ? this.Primitives.Count : 0);

            // write structure data
            writer.Write(this.Unknown_70h);
            writer.Write(this.Unknown_74h);
            writer.Write(this.Unknown_78h_Pointer);
            writer.Write(this.Unknown_80h);
            writer.Write(this.VerticesCount1);
            writer.Write(this.PrimitivesPointer);
            writer.Write(this.Quantum);
            writer.Write(this.Offset);
            writer.Write(this.VerticesPointer);
            writer.Write(this.Unknown_B8h_Pointer);
            writer.Write(this.Unknown_C0h_Pointer);
            writer.Write(this.Unknown_C8h_Pointer);
            writer.Write(this.VerticesCount2);
            writer.Write(this.PrimitivesCount);
            writer.Write(this.Unknown_D8h);
            writer.Write(this.Unknown_E0h);
            writer.Write(this.Unknown_E8h);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>(base.GetReferences());
            if (Unknown_78h_Data != null) list.Add(Unknown_78h_Data);
            if (Primitives != null) list.Add(Primitives);
            if (Vertices != null) list.Add(Vertices);
            if (Unknown_B8h_Data != null) list.Add(Unknown_B8h_Data);
            if (Unknown_C0h_Data != null) list.Add(Unknown_C0h_Data);
            if (Unknown_C8h_Data != null) list.Add(Unknown_C8h_Data);
            return list.ToArray();
        }
    }
}
