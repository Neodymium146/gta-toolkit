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
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace RageLib.Resources.GTA5.PC.Bounds
{
    // phBoundPolyhedron
    public class BoundPolyhedron : Bound
    {
        public override long BlockLength => 0xF0;

        // structure data
        public uint Unknown_70h;
        public uint Unknown_74h;
        public ulong ShrunkVerticesPointer;
        public uint Unknown_80h;
        public uint VerticesCount1;
        public ulong PrimitivesPointer;
        public Vector3 Quantum;
        public float Unknown_9Ch;
        public Vector3 Offset;
        public float Unknown_ACh;
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
        public ResourceSimpleArray<BoundVertex> ShrunkVertices;
        public ResourceSimpleArray<BoundPrimitive> Primitives;
        public ResourceSimpleArray<BoundVertex> Vertices;
        public SimpleArray<uint> Unknown_B8h_Data;
        public SimpleArray<uint> Unknown_C0h_Data;
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
            this.ShrunkVerticesPointer = reader.ReadUInt64();
            this.Unknown_80h = reader.ReadUInt32();
            this.VerticesCount1 = reader.ReadUInt32();
            this.PrimitivesPointer = reader.ReadUInt64();
            this.Quantum = reader.ReadVector3();
            this.Unknown_9Ch = reader.ReadSingle();
            this.Offset = reader.ReadVector3();
            this.Unknown_ACh = reader.ReadSingle();
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
            this.ShrunkVertices = reader.ReadBlockAt<ResourceSimpleArray<BoundVertex>>(
                this.ShrunkVerticesPointer, // offset
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
            this.Unknown_B8h_Data = reader.ReadBlockAt<SimpleArray<uint>>(
                this.Unknown_B8h_Pointer, // offset
                this.VerticesCount2
            );
            this.Unknown_C0h_Data = reader.ReadBlockAt<SimpleArray<uint>>(
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
            this.ShrunkVerticesPointer = (ulong)(this.ShrunkVertices != null ? this.ShrunkVertices.BlockPosition : 0);
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
            writer.Write(this.ShrunkVerticesPointer);
            writer.Write(this.Unknown_80h);
            writer.Write(this.VerticesCount1);
            writer.Write(this.PrimitivesPointer);
            writer.Write(this.Quantum);
            writer.Write(this.Unknown_9Ch);
            writer.Write(this.Offset);
            writer.Write(this.Unknown_ACh);
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
            if (ShrunkVertices != null) list.Add(ShrunkVertices);
            if (Primitives != null) list.Add(Primitives);
            if (Vertices != null) list.Add(Vertices);
            if (Unknown_B8h_Data != null) list.Add(Unknown_B8h_Data);
            if (Unknown_C0h_Data != null) list.Add(Unknown_C0h_Data);
            if (Unknown_C8h_Data != null) list.Add(Unknown_C8h_Data);
            return list.ToArray();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3 GetVertex(BoundVertex quantizedVertex)
        {
            return new Vector3(quantizedVertex.X * Quantum.X, quantizedVertex.Y * Quantum.Y, quantizedVertex.Z * Quantum.Z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector3 GetVertexOffset(Vector3 vertex)
        {
            return vertex + Offset;
        }

        public Vector3 CalculateQuantum()
        {
            var aabbMin = new Vector3(float.MaxValue);
            var aabbMax = new Vector3(float.MinValue);

            for (int i = 0; i < VerticesCount2; i++)
            {
                var vertex = GetVertex(Vertices[i]);

                aabbMin = Vector3.Min(aabbMin, vertex);
                aabbMax = Vector3.Max(aabbMax, vertex);
            }

            var size = aabbMax - aabbMin;
            var quantum = size / 65535.0f;
            return quantum;
        }

        public BoundVertex GetQuantizedVertex(Vector3 vertex)
        {
            BoundVertex boundVertex = new BoundVertex();
            boundVertex.X = (short)MathF.Round(vertex.X / Quantum.X);
            boundVertex.Y = (short)MathF.Round(vertex.Y / Quantum.Y);
            boundVertex.Z = (short)MathF.Round(vertex.Z / Quantum.Z);
            return boundVertex;
        }

        public override void Update()
        {
            // Test
            TestQuantum();
            TestTriangleArea();
            TestTriangleNeighbors();
            TestShrunkVertices();
        }

        public void TestShrunkVertices()
        {
            if (ShrunkVertices is null)
                return;

            // Margin is used to shrink vertices
            // OctantMap only seems to be present if ShrunkVertices are present too
            for (int i = 0; i < VerticesCount2; i++)
            {
                var vertex = GetVertexOffset(GetVertex(Vertices[i]));
                var shrunk = GetVertexOffset(GetVertex(ShrunkVertices[i]));

                var test = vertex - new Vector3(Margin);
            }
        }

        public void TestQuantum()
        {
            var quantum = CalculateQuantum();
            Debug.Assert(MathF.Abs(quantum.X - Quantum.X) < 0.0001f);
            Debug.Assert(MathF.Abs(quantum.Y - Quantum.Y) < 0.0001f);
            Debug.Assert(MathF.Abs(quantum.Z - Quantum.Z) < 0.0001f);
        }

        public void TestTriangleArea()
        {
            for (int i = 0; i < PrimitivesCount; i++)
            {
                var primitive = Primitives[i];

                if (primitive is not BoundPrimitiveTriangle primitiveTriangle)
                    continue;

                var vertex1 = GetVertex(Vertices[primitiveTriangle.VertexIndex1]);
                var vertex2 = GetVertex(Vertices[primitiveTriangle.VertexIndex2]);
                var vertex3 = GetVertex(Vertices[primitiveTriangle.VertexIndex3]);

                var triangleArea = Vector3.Cross(vertex2 - vertex1, vertex3 - vertex1).Length() * 0.5f;

                Debug.Assert(MathF.Abs(triangleArea - primitiveTriangle.triArea) < 0.0001f);
            }
        }

        public void TestTriangleNeighbors()
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            static ValueTuple<ushort, ushort> GetEdge(ushort vertexIndex1, ushort vertexIndex2)
            {
                return vertexIndex1 < vertexIndex2 ?
                    (vertexIndex1, vertexIndex2) :
                    (vertexIndex2, vertexIndex1);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            static int ChooseEdge(ValueTuple<int, int> edge, int i)
            {
                return edge.Item2 != i ? edge.Item2 : edge.Item1 != i ? edge.Item1 : -1;
            }

            // Key: (vertex1, vertex2) 
            // Value: (triangle1, triangle2)
            Dictionary <ValueTuple<ushort, ushort>, ValueTuple<int, int>> edgesMap = new();
            ValueTuple<ushort, ushort>[] edges = new (ushort, ushort)[3];

            for (int i = 0; i < PrimitivesCount; i++)
            {
                var primitive = Primitives[i];

                if (primitive is not BoundPrimitiveTriangle triangle)
                    continue;

                edges[0] = GetEdge(triangle.VertexIndex1, triangle.VertexIndex2);
                edges[1] = GetEdge(triangle.VertexIndex2, triangle.VertexIndex3);
                edges[2] = GetEdge(triangle.VertexIndex3, triangle.VertexIndex1);

                for (int e = 0; e < 3; e++)
                {
                    if (edgesMap.ContainsKey(edges[e]))
                    {
                        var triangles = edgesMap[edges[e]];
                        
                        edgesMap[edges[e]] = (triangles.Item1, i);
                    }   
                    else
                        edgesMap[edges[e]] = (i, -1);
                }
            }

            for (int i = 0; i < PrimitivesCount; i++)
            {
                var primitive = Primitives[i];

                if (primitive is not BoundPrimitiveTriangle triangle)
                    continue;

                var edge1 = edgesMap[GetEdge(triangle.VertexIndex1, triangle.VertexIndex2)];
                var edge2 = edgesMap[GetEdge(triangle.VertexIndex2, triangle.VertexIndex3)];
                var edge3 = edgesMap[GetEdge(triangle.VertexIndex3, triangle.VertexIndex1)];

                var edgeIndex1 = (short)ChooseEdge(edge1, i);
                var edgeIndex2 = (short)ChooseEdge(edge2, i);
                var edgeIndex3 = (short)ChooseEdge(edge3, i);

                Debug.Assert(edgeIndex1 == triangle.NeighborIndex1);
                Debug.Assert(edgeIndex2 == triangle.NeighborIndex2);
                Debug.Assert(edgeIndex3 == triangle.NeighborIndex3);
            }
        }
    }
}
