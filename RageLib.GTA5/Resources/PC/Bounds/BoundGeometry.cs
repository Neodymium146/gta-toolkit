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

namespace RageLib.Resources.GTA5.PC.Bounds
{
    // phBoundPolyhedron
    // phBoundGeometry
    public class BoundGeometry : BoundPolyhedron
    {
        public override long BlockLength => 0x130;

        // structure data
        public ulong MaterialsPointer;
        public ulong MaterialColoursPointer;
        public uint Unknown_100h; // 0x00000000
        public uint Unknown_104h; // 0x00000000
        public uint Unknown_108h; // 0x00000000
        public uint Unknown_10Ch; // 0x00000000
        public uint Unknown_110h; // 0x00000000
        public uint Unknown_114h; // 0x00000000
        public ulong PolygonMaterialIndicesPointer;
        public byte MaterialsCount;
        public byte MaterialColoursCount;
        public ushort Unknown_122h; // 0x0000
        public uint Unknown_124h; // 0x00000000
        public uint Unknown_128h; // 0x00000000
        public uint Unknown_12Ch; // 0x00000000

        // reference data
        public ResourceSimpleArray<BoundMaterial> Materials;
        public ResourceSimpleArray<uint_r> MaterialColours;
        public ResourceSimpleArray<byte_r> PolygonMaterialIndices;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.MaterialsPointer = reader.ReadUInt64();
            this.MaterialColoursPointer = reader.ReadUInt64();
            this.Unknown_100h = reader.ReadUInt32();
            this.Unknown_104h = reader.ReadUInt32();
            this.Unknown_108h = reader.ReadUInt32();
            this.Unknown_10Ch = reader.ReadUInt32();
            this.Unknown_110h = reader.ReadUInt32();
            this.Unknown_114h = reader.ReadUInt32();
            this.PolygonMaterialIndicesPointer = reader.ReadUInt64();
            this.MaterialsCount = reader.ReadByte();
            this.MaterialColoursCount = reader.ReadByte();
            this.Unknown_122h = reader.ReadUInt16();
            this.Unknown_124h = reader.ReadUInt32();
            this.Unknown_128h = reader.ReadUInt32();
            this.Unknown_12Ch = reader.ReadUInt32();

            // read reference data
            this.Materials = reader.ReadBlockAt<ResourceSimpleArray<BoundMaterial>>(
                this.MaterialsPointer, // offset
                this.MaterialsCount
            );
            this.MaterialColours = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(
                this.MaterialColoursPointer, // offset
                this.MaterialColoursCount
            );
            this.PolygonMaterialIndices = reader.ReadBlockAt<ResourceSimpleArray<byte_r>>(
                this.PolygonMaterialIndicesPointer, // offset
                this.PrimitivesCount
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.MaterialsPointer = (ulong)(this.Materials != null ? this.Materials.BlockPosition : 0);
            this.MaterialColoursPointer = (ulong)(this.MaterialColours != null ? this.MaterialColours.BlockPosition : 0);
            this.PolygonMaterialIndicesPointer = (ulong)(this.PolygonMaterialIndices != null ? this.PolygonMaterialIndices.BlockPosition : 0);
            this.MaterialsCount = (byte)(this.Materials != null ? this.Materials.Count : 0);
            this.MaterialColoursCount = (byte)(this.MaterialColours != null ? this.MaterialColours.Count : 0);

            // write structure data
            writer.Write(this.MaterialsPointer);
            writer.Write(this.MaterialColoursPointer);
            writer.Write(this.Unknown_100h);
            writer.Write(this.Unknown_104h);
            writer.Write(this.Unknown_108h);
            writer.Write(this.Unknown_10Ch);
            writer.Write(this.Unknown_110h);
            writer.Write(this.Unknown_114h);
            writer.Write(this.PolygonMaterialIndicesPointer);
            writer.Write(this.MaterialsCount);
            writer.Write(this.MaterialColoursCount);
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
            if (Materials != null) list.Add(Materials);
            if (MaterialColours != null) list.Add(MaterialColours);
            if (PolygonMaterialIndices != null) list.Add(PolygonMaterialIndices);
            return list.ToArray();
        }
    }
}
