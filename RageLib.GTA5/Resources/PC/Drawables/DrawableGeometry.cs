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

namespace RageLib.Resources.GTA5.PC.Drawables
{
    // datBase
    // grmGeometry
    // grmGeometryQB
    public class DrawableGeometry : DatBase64
    {
        public override long BlockLength => 0xA0;

        // structure data
        public ulong Unknown_8h; // 0x0000000000000000
        public ulong Unknown_10h; // 0x0000000000000000
        public ulong VertexBufferPointer;
        public ulong Unknown_20h; // 0x0000000000000000
        public ulong Unknown_28h; // 0x0000000000000000
        public ulong Unknown_30h; // 0x0000000000000000
        public ulong IndexBufferPointer;
        public ulong Unknown_40h; // 0x0000000000000000
        public ulong Unknown_48h; // 0x0000000000000000
        public ulong Unknown_50h; // 0x0000000000000000
        public uint IndicesCount;
        public uint FacesCount;
        public ushort VerticesCount;
        public ushort IndicesPerFace; // 0x0003
        public uint Unknown_64h; // 0x00000000
        public ulong BonesIdPointer;
        public ushort VertexStride;
        public ushort BonesCount;
        public uint Unknown_74h; // 0x00000000
        public ulong VertexDataPointer;
        public ulong Unknown_80h; // 0x0000000000000000
        public ulong Unknown_88h; // 0x0000000000000000
        public ulong Unknown_90h; // 0x0000000000000000
        public ulong Unknown_98h; // 0x0000000000000000

        // reference data
        public VertexBuffer VertexBuffer;
        public IndexBuffer IndexBuffer;
        public SimpleArray<ushort> BonesId;
        public VertexData_GTA5_pc VertexData;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.Unknown_8h = reader.ReadUInt64();
            this.Unknown_10h = reader.ReadUInt64();
            this.VertexBufferPointer = reader.ReadUInt64();
            this.Unknown_20h = reader.ReadUInt64();
            this.Unknown_28h = reader.ReadUInt64();
            this.Unknown_30h = reader.ReadUInt64();
            this.IndexBufferPointer = reader.ReadUInt64();
            this.Unknown_40h = reader.ReadUInt64();
            this.Unknown_48h = reader.ReadUInt64();
            this.Unknown_50h = reader.ReadUInt64();
            this.IndicesCount = reader.ReadUInt32();
            this.FacesCount = reader.ReadUInt32();
            this.VerticesCount = reader.ReadUInt16();
            this.IndicesPerFace = reader.ReadUInt16();
            this.Unknown_64h = reader.ReadUInt32();
            this.BonesIdPointer = reader.ReadUInt64();
            this.VertexStride = reader.ReadUInt16();
            this.BonesCount = reader.ReadUInt16();
            this.Unknown_74h = reader.ReadUInt32();
            this.VertexDataPointer = reader.ReadUInt64();
            this.Unknown_80h = reader.ReadUInt64();
            this.Unknown_88h = reader.ReadUInt64();
            this.Unknown_90h = reader.ReadUInt64();
            this.Unknown_98h = reader.ReadUInt64();

            // read reference data
            this.VertexBuffer = reader.ReadBlockAt<VertexBuffer>(
                this.VertexBufferPointer // offset
            );
            this.IndexBuffer = reader.ReadBlockAt<IndexBuffer>(
                this.IndexBufferPointer // offset
            );
            this.BonesId = reader.ReadBlockAt<SimpleArray<ushort>>(
                this.BonesIdPointer, // offset
                this.BonesCount
            );
            this.VertexData = reader.ReadBlockAt<VertexData_GTA5_pc>(
                this.VertexDataPointer, // offset
                this.VertexStride,
                this.VerticesCount,
                this.VertexBuffer.Info
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.VertexBufferPointer = (ulong)(this.VertexBuffer != null ? this.VertexBuffer.BlockPosition : 0);
            this.IndexBufferPointer = (ulong)(this.IndexBuffer != null ? this.IndexBuffer.BlockPosition : 0);
            //this.IndicesCount = (uint)(this.IndexBuffer?.Indices?.Count ?? 0);
            //this.VerticesCount = (ushort)(this.VertexBuffer?.VertexCount ?? 0); // assume vertex buffer is aleady updated
            this.BonesIdPointer = (ulong)(this.BonesId != null ? this.BonesId.BlockPosition : 0);
            //this.Count1 = (ushort)(this.Unknown_68h_Data?.Length ?? 0);
            //this.VertexStride = (ushort)(this.VertexData != null ? this.VertexData.Count : 0);
            this.VertexDataPointer = (ulong)(this.VertexData != null ? this.VertexData.BlockPosition : 0);

            // write structure data
            writer.Write(this.Unknown_8h);
            writer.Write(this.Unknown_10h);
            writer.Write(this.VertexBufferPointer);
            writer.Write(this.Unknown_20h);
            writer.Write(this.Unknown_28h);
            writer.Write(this.Unknown_30h);
            writer.Write(this.IndexBufferPointer);
            writer.Write(this.Unknown_40h);
            writer.Write(this.Unknown_48h);
            writer.Write(this.Unknown_50h);
            writer.Write(this.IndicesCount);
            writer.Write(this.FacesCount);
            writer.Write(this.VerticesCount);
            writer.Write(this.IndicesPerFace);
            writer.Write(this.Unknown_64h);
            writer.Write(this.BonesIdPointer);
            writer.Write(this.VertexStride);
            writer.Write(this.BonesCount);
            writer.Write(this.Unknown_74h);
            writer.Write(this.VertexDataPointer);
            writer.Write(this.Unknown_80h);
            writer.Write(this.Unknown_88h);
            writer.Write(this.Unknown_90h);
            writer.Write(this.Unknown_98h);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (VertexBuffer != null) list.Add(VertexBuffer);
            if (IndexBuffer != null) list.Add(IndexBuffer);
            if (BonesId != null) list.Add(BonesId);
            if (VertexData != null) list.Add(VertexData);
            return list.ToArray();
        }
    }
}
