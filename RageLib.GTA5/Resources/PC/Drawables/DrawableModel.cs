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

namespace RageLib.Resources.GTA5.PC.Drawables
{
    // datBase
    // grmModel
    public class DrawableModel : DatBase64
    {
        public override long Length => 0x30;

        // structure data
        public ResourcePointerList64<DrawableGeometry> Geometries;
        public ulong GeometriesBoundsPointer;
        public ulong ShaderMappingPointer;
        public uint Unknown_28h;
        public ushort Unknown_2Ch;
        public ushort GeometriesCount;

        // reference data
        public ResourceSimpleArray<RAGE_AABB> GeometriesBounds;
        public ResourceSimpleArray<ushort_r> ShaderMapping;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.Geometries = reader.ReadBlock<ResourcePointerList64<DrawableGeometry>>();
            this.GeometriesBoundsPointer = reader.ReadUInt64();
            this.ShaderMappingPointer = reader.ReadUInt64();
            this.Unknown_28h = reader.ReadUInt32();
            this.Unknown_2Ch = reader.ReadUInt16();
            this.GeometriesCount = reader.ReadUInt16();

            // read reference data
            this.GeometriesBounds = reader.ReadBlockAt<ResourceSimpleArray<RAGE_AABB>>(
                this.GeometriesBoundsPointer, // offset
                this.GeometriesCount > 1 ? this.GeometriesCount + 1 : this.GeometriesCount
            );
            this.ShaderMapping = reader.ReadBlockAt<ResourceSimpleArray<ushort_r>>(
                this.ShaderMappingPointer, // offset
                this.GeometriesCount
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.GeometriesBoundsPointer = (ulong)(this.GeometriesBounds != null ? this.GeometriesBounds.Position : 0);
            this.ShaderMappingPointer = (ulong)(this.ShaderMapping != null ? this.ShaderMapping.Position : 0);

            // write structure data
            writer.WriteBlock(this.Geometries);
            writer.Write(this.GeometriesBoundsPointer);
            writer.Write(this.ShaderMappingPointer);
            writer.Write(this.Unknown_28h);
            writer.Write(this.Unknown_2Ch);
            writer.Write(this.GeometriesCount);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (Geometries != null) list.Add(Geometries);
            if (GeometriesBounds != null) list.Add(GeometriesBounds);
            if (ShaderMapping != null) list.Add(ShaderMapping);
            return list.ToArray();
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(0x8, Geometries)
            };
        }
    }
}
