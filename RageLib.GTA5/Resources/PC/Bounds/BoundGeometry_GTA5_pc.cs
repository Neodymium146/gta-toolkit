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
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Bounds
{
    public class BoundGeometry_GTA5_pc : Bound_GTA5_pc
    {
        public override long Length
        {
            get { return 304; }
        }

        // structure data
        public uint Unknown_70h;
        public uint Unknown_74h;
        public ulong Unknown_78h_Pointer;
        public uint Unknown_80h;
        public uint Count1;
        public ulong PolygonsPointer;
        public uint Unknown_90h;
        public uint Unknown_94h;
        public uint Unknown_98h;
        public uint Unknown_9Ch;
        public uint Unknown_A0h;
        public uint Unknown_A4h;
        public uint Unknown_A8h;
        public uint Unknown_ACh;
        public ulong VerticesPointer;
        public ulong Unknown_B8h_Pointer;
        public ulong Unknown_C0h_Pointer;
        public ulong Unknown_C8h_Pointer;
        public uint VerticesCount;
        public uint PolygonsCount;
        public uint Unknown_D8h; // 0x00000000
        public uint Unknown_DCh; // 0x00000000
        public uint Unknown_E0h; // 0x00000000
        public uint Unknown_E4h; // 0x00000000
        public uint Unknown_E8h; // 0x00000000
        public uint Unknown_ECh; // 0x00000000
        public ulong MaterialsPointer;
        public ulong Unknown_F8h_Pointer;
        public uint Unknown_100h; // 0x00000000
        public uint Unknown_104h; // 0x00000000
        public uint Unknown_108h; // 0x00000000
        public uint Unknown_10Ch; // 0x00000000
        public uint Unknown_110h; // 0x00000000
        public uint Unknown_114h; // 0x00000000
        public ulong Unknown_118h_Pointer;
        public byte MaterialsCount;
        public byte Count2;
        public ushort Unknown_122h; // 0x0000
        public uint Unknown_124h; // 0x00000000
        public uint Unknown_128h; // 0x00000000
        public uint Unknown_12Ch; // 0x00000000

        // reference data
        public ResourceSimpleArray<BoundVertex_GTA5_pc> p1data;
        public ResourceSimpleArray<BoundPolygon_GTA5_pc> Polygons;
        public ResourceSimpleArray<BoundVertex_GTA5_pc> Vertices;
        public ResourceSimpleArray<uint_r> Unknown_B8h_Data;
        public ResourceSimpleArray<uint_r> Unknown_C0h_Data;
        public ResourceSimpleArrayArray64<uint_r> Unknown_C8h_Data;
        public ResourceSimpleArray<ulong_r> Materials;
        public ResourceSimpleArray<uint_r> Unknown_F8h_Data;
        public ResourceSimpleArray<byte_r> PolygonMaterials;

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
            this.Count1 = reader.ReadUInt32();
            this.PolygonsPointer = reader.ReadUInt64();
            this.Unknown_90h = reader.ReadUInt32();
            this.Unknown_94h = reader.ReadUInt32();
            this.Unknown_98h = reader.ReadUInt32();
            this.Unknown_9Ch = reader.ReadUInt32();
            this.Unknown_A0h = reader.ReadUInt32();
            this.Unknown_A4h = reader.ReadUInt32();
            this.Unknown_A8h = reader.ReadUInt32();
            this.Unknown_ACh = reader.ReadUInt32();
            this.VerticesPointer = reader.ReadUInt64();
            this.Unknown_B8h_Pointer = reader.ReadUInt64();
            this.Unknown_C0h_Pointer = reader.ReadUInt64();
            this.Unknown_C8h_Pointer = reader.ReadUInt64();
            this.VerticesCount = reader.ReadUInt32();
            this.PolygonsCount = reader.ReadUInt32();
            this.Unknown_D8h = reader.ReadUInt32();
            this.Unknown_DCh = reader.ReadUInt32();
            this.Unknown_E0h = reader.ReadUInt32();
            this.Unknown_E4h = reader.ReadUInt32();
            this.Unknown_E8h = reader.ReadUInt32();
            this.Unknown_ECh = reader.ReadUInt32();
            this.MaterialsPointer = reader.ReadUInt64();
            this.Unknown_F8h_Pointer = reader.ReadUInt64();
            this.Unknown_100h = reader.ReadUInt32();
            this.Unknown_104h = reader.ReadUInt32();
            this.Unknown_108h = reader.ReadUInt32();
            this.Unknown_10Ch = reader.ReadUInt32();
            this.Unknown_110h = reader.ReadUInt32();
            this.Unknown_114h = reader.ReadUInt32();
            this.Unknown_118h_Pointer = reader.ReadUInt64();
            this.MaterialsCount = reader.ReadByte();
            this.Count2 = reader.ReadByte();
            this.Unknown_122h = reader.ReadUInt16();
            this.Unknown_124h = reader.ReadUInt32();
            this.Unknown_128h = reader.ReadUInt32();
            this.Unknown_12Ch = reader.ReadUInt32();

            // read reference data
            this.p1data = reader.ReadBlockAt<ResourceSimpleArray<BoundVertex_GTA5_pc>>(
                this.Unknown_78h_Pointer, // offset
                this.VerticesCount
            );
            this.Polygons = reader.ReadBlockAt<ResourceSimpleArray<BoundPolygon_GTA5_pc>>(
                this.PolygonsPointer, // offset
                this.PolygonsCount
            );
            this.Vertices = reader.ReadBlockAt<ResourceSimpleArray<BoundVertex_GTA5_pc>>(
                this.VerticesPointer, // offset
                this.VerticesCount
            );
            this.Unknown_B8h_Data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(
                this.Unknown_B8h_Pointer, // offset
                this.VerticesCount
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
            this.Materials = reader.ReadBlockAt<ResourceSimpleArray<ulong_r>>(
                this.MaterialsPointer, // offset
                this.MaterialsCount
            );
            this.Unknown_F8h_Data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(
                this.Unknown_F8h_Pointer, // offset
                this.Count2
            );
            this.PolygonMaterials = reader.ReadBlockAt<ResourceSimpleArray<byte_r>>(
                this.Unknown_118h_Pointer, // offset
                this.PolygonsCount
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.Unknown_78h_Pointer = (ulong)(this.p1data != null ? this.p1data.Position : 0);
            this.PolygonsPointer = (ulong)(this.Polygons != null ? this.Polygons.Position : 0);
            this.VerticesPointer = (ulong)(this.Vertices != null ? this.Vertices.Position : 0);
            this.Unknown_B8h_Pointer = (ulong)(this.Unknown_B8h_Data != null ? this.Unknown_B8h_Data.Position : 0);
            this.Unknown_C0h_Pointer = (ulong)(this.Unknown_C0h_Data != null ? this.Unknown_C0h_Data.Position : 0);
            this.Unknown_C8h_Pointer = (ulong)(this.Unknown_C8h_Data != null ? this.Unknown_C8h_Data.Position : 0);
            this.VerticesCount = (uint)(this.Vertices != null ? this.Vertices.Count : 0);
            this.PolygonsCount = (uint)(this.Polygons != null ? this.Polygons.Count : 0);
            this.MaterialsPointer = (ulong)(this.Materials != null ? this.Materials.Position : 0);
            this.Unknown_F8h_Pointer = (ulong)(this.Unknown_F8h_Data != null ? this.Unknown_F8h_Data.Position : 0);
            this.Unknown_118h_Pointer = (ulong)(this.PolygonMaterials != null ? this.PolygonMaterials.Position : 0);
            this.MaterialsCount = (byte)(this.Materials != null ? this.Materials.Count : 0);
            this.Count2 = (byte)(this.Unknown_F8h_Data != null ? this.Unknown_F8h_Data.Count : 0);

            // write structure data
            writer.Write(this.Unknown_70h);
            writer.Write(this.Unknown_74h);
            writer.Write(this.Unknown_78h_Pointer);
            writer.Write(this.Unknown_80h);
            writer.Write(this.Count1);
            writer.Write(this.PolygonsPointer);
            writer.Write(this.Unknown_90h);
            writer.Write(this.Unknown_94h);
            writer.Write(this.Unknown_98h);
            writer.Write(this.Unknown_9Ch);
            writer.Write(this.Unknown_A0h);
            writer.Write(this.Unknown_A4h);
            writer.Write(this.Unknown_A8h);
            writer.Write(this.Unknown_ACh);
            writer.Write(this.VerticesPointer);
            writer.Write(this.Unknown_B8h_Pointer);
            writer.Write(this.Unknown_C0h_Pointer);
            writer.Write(this.Unknown_C8h_Pointer);
            writer.Write(this.VerticesCount);
            writer.Write(this.PolygonsCount);
            writer.Write(this.Unknown_D8h);
            writer.Write(this.Unknown_DCh);
            writer.Write(this.Unknown_E0h);
            writer.Write(this.Unknown_E4h);
            writer.Write(this.Unknown_E8h);
            writer.Write(this.Unknown_ECh);
            writer.Write(this.MaterialsPointer);
            writer.Write(this.Unknown_F8h_Pointer);
            writer.Write(this.Unknown_100h);
            writer.Write(this.Unknown_104h);
            writer.Write(this.Unknown_108h);
            writer.Write(this.Unknown_10Ch);
            writer.Write(this.Unknown_110h);
            writer.Write(this.Unknown_114h);
            writer.Write(this.Unknown_118h_Pointer);
            writer.Write(this.MaterialsCount);
            writer.Write(this.Count2);
            writer.Write(this.Unknown_122h);
            writer.Write(this.Unknown_124h);
            writer.Write(this.Unknown_128h);
            writer.Write(this.Unknown_12Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>(base.GetReferences());
            if (p1data != null) list.Add(p1data);
            if (Polygons != null) list.Add(Polygons);
            if (Vertices != null) list.Add(Vertices);
            if (Unknown_B8h_Data != null) list.Add(Unknown_B8h_Data);
            if (Unknown_C0h_Data != null) list.Add(Unknown_C0h_Data);
            if (Unknown_C8h_Data != null) list.Add(Unknown_C8h_Data);
            if (Materials != null) list.Add(Materials);
            if (Unknown_F8h_Data != null) list.Add(Unknown_F8h_Data);
            if (PolygonMaterials != null) list.Add(PolygonMaterials);
            return list.ToArray();
        }

    }
}