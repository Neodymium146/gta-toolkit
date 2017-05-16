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
    // grmModel
    public class DrawableModel : ResourceSystemBlock
    {
        public override long Length => 0x30;

        // structure data
        public uint VFT;
        public uint Unknown_4h; // 0x00000001
        public ulong GeometriesPointer;
        public ushort GeometriesCount1;
        public ushort GeometriesCount2;
        public uint Unknown_14h; // 0x00000000
        public ulong Unknown_18h_Pointer;
        public ulong ShaderMappingPointer;
        public uint Unknown_28h;
        public uint Unknown_2Ch;

        // reference data
        public ResourcePointerArray64<DrawableGeometry> Geometries;
        public ResourceSimpleArray<RAGE_AABB> Unknown_18h_Data;
        public ResourceSimpleArray<ushort_r> ShaderMapping;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.VFT = reader.ReadUInt32();
            this.Unknown_4h = reader.ReadUInt32();
            this.GeometriesPointer = reader.ReadUInt64();
            this.GeometriesCount1 = reader.ReadUInt16();
            this.GeometriesCount2 = reader.ReadUInt16();
            this.Unknown_14h = reader.ReadUInt32();
            this.Unknown_18h_Pointer = reader.ReadUInt64();
            this.ShaderMappingPointer = reader.ReadUInt64();
            this.Unknown_28h = reader.ReadUInt32();
            this.Unknown_2Ch = reader.ReadUInt32();

            // read reference data
            this.Geometries = reader.ReadBlockAt<ResourcePointerArray64<DrawableGeometry>>(
                this.GeometriesPointer, // offset
                this.GeometriesCount1
            );
            this.Unknown_18h_Data = reader.ReadBlockAt<ResourceSimpleArray<RAGE_AABB>>(
                this.Unknown_18h_Pointer, // offset
                this.GeometriesCount1 > 1 ? this.GeometriesCount1 + 1 : this.GeometriesCount1
            );
            this.ShaderMapping = reader.ReadBlockAt<ResourceSimpleArray<ushort_r>>(
                this.ShaderMappingPointer, // offset
                this.GeometriesCount1
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.GeometriesPointer = (ulong)(this.Geometries != null ? this.Geometries.Position : 0);
            //	this.GeometriesCount1 = (ushort)(this.Geometries != null ? this.Geometries.Count : 0);
            this.Unknown_18h_Pointer = (ulong)(this.Unknown_18h_Data != null ? this.Unknown_18h_Data.Position : 0);
            this.ShaderMappingPointer = (ulong)(this.ShaderMapping != null ? this.ShaderMapping.Position : 0);

            // write structure data
            writer.Write(this.VFT);
            writer.Write(this.Unknown_4h);
            writer.Write(this.GeometriesPointer);
            writer.Write(this.GeometriesCount1);
            writer.Write(this.GeometriesCount2);
            writer.Write(this.Unknown_14h);
            writer.Write(this.Unknown_18h_Pointer);
            writer.Write(this.ShaderMappingPointer);
            writer.Write(this.Unknown_28h);
            writer.Write(this.Unknown_2Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (Geometries != null) list.Add(Geometries);
            if (Unknown_18h_Data != null) list.Add(Unknown_18h_Data);
            if (ShaderMapping != null) list.Add(ShaderMapping);
            return list.ToArray();
        }
    }
}
