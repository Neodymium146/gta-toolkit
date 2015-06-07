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
    public class BoundComposite_GTA5_pc : Bound_GTA5_pc
    {
        public override long Length
        {
            get { return 176; }
        }

        // structure data
        public ulong ChildrenPointer;
        public ulong Unknown_78h_Pointer;
        public ulong Unknown_80h_Pointer;
        public ulong Unknown_88h_Pointer;
        public ulong Unknown_90h_Pointer;
        public ulong Unknown_98h_Pointer;
        public ushort ChildrenCount1;
        public ushort ChildrenCount2;
        public uint Unknown_A4h; // 0x00000000
        public ulong Unknown_A8h_Pointer;

        // reference data
        public ResourcePointerArray64<Bound_GTA5_pc> Children;
        public ResourceSimpleArray<RAGE_Matrix4> Unknown_78h_Data;
        public ResourceSimpleArray<RAGE_Matrix4> Unknown_80h_Data;
        public ResourceSimpleArray<RAGE_AABB> Unknown_88h_Data;
        public ResourceSimpleArray<Unknown_B_002> Unknown_90h_Data;
        public ResourceSimpleArray<Unknown_B_002> Unknown_98h_Data;
        public BVH_GTA5_pc Unknown_A8h_Data;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.ChildrenPointer = reader.ReadUInt64();
            this.Unknown_78h_Pointer = reader.ReadUInt64();
            this.Unknown_80h_Pointer = reader.ReadUInt64();
            this.Unknown_88h_Pointer = reader.ReadUInt64();
            this.Unknown_90h_Pointer = reader.ReadUInt64();
            this.Unknown_98h_Pointer = reader.ReadUInt64();
            this.ChildrenCount1 = reader.ReadUInt16();
            this.ChildrenCount2 = reader.ReadUInt16();
            this.Unknown_A4h = reader.ReadUInt32();
            this.Unknown_A8h_Pointer = reader.ReadUInt64();

            // read reference data
            this.Children = reader.ReadBlockAt<ResourcePointerArray64<Bound_GTA5_pc>>(
                this.ChildrenPointer, // offset
                this.ChildrenCount1
            );
            this.Unknown_78h_Data = reader.ReadBlockAt<ResourceSimpleArray<RAGE_Matrix4>>(
                this.Unknown_78h_Pointer, // offset
                this.ChildrenCount1
            );
            this.Unknown_80h_Data = reader.ReadBlockAt<ResourceSimpleArray<RAGE_Matrix4>>(
                this.Unknown_80h_Pointer, // offset
                this.ChildrenCount1
            );
            this.Unknown_88h_Data = reader.ReadBlockAt<ResourceSimpleArray<RAGE_AABB>>(
                this.Unknown_88h_Pointer, // offset
                this.ChildrenCount1
            );
            this.Unknown_90h_Data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_B_002>>(
                this.Unknown_90h_Pointer, // offset
                this.ChildrenCount1
            );
            this.Unknown_98h_Data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_B_002>>(
                this.Unknown_98h_Pointer, // offset
                this.ChildrenCount1
            );
            this.Unknown_A8h_Data = reader.ReadBlockAt<BVH_GTA5_pc>(
                this.Unknown_A8h_Pointer // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.ChildrenPointer = (ulong)(this.Children != null ? this.Children.Position : 0);
            this.Unknown_78h_Pointer = (ulong)(this.Unknown_78h_Data != null ? this.Unknown_78h_Data.Position : 0);
            this.Unknown_80h_Pointer = (ulong)(this.Unknown_80h_Data != null ? this.Unknown_80h_Data.Position : 0);
            this.Unknown_88h_Pointer = (ulong)(this.Unknown_88h_Data != null ? this.Unknown_88h_Data.Position : 0);
            this.Unknown_90h_Pointer = (ulong)(this.Unknown_90h_Data != null ? this.Unknown_90h_Data.Position : 0);
            this.Unknown_98h_Pointer = (ulong)(this.Unknown_98h_Data != null ? this.Unknown_98h_Data.Position : 0);
            this.ChildrenCount1 = (ushort)(this.Children != null ? this.Children.Count : 0);
            this.ChildrenCount2 = (ushort)(this.Children != null ? this.Children.Count : 0);
            this.Unknown_A8h_Pointer = (ulong)(this.Unknown_A8h_Data != null ? this.Unknown_A8h_Data.Position : 0);

            // write structure data
            writer.Write(this.ChildrenPointer);
            writer.Write(this.Unknown_78h_Pointer);
            writer.Write(this.Unknown_80h_Pointer);
            writer.Write(this.Unknown_88h_Pointer);
            writer.Write(this.Unknown_90h_Pointer);
            writer.Write(this.Unknown_98h_Pointer);
            writer.Write(this.ChildrenCount1);
            writer.Write(this.ChildrenCount2);
            writer.Write(this.Unknown_A4h);
            writer.Write(this.Unknown_A8h_Pointer);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>(base.GetReferences());
            if (Children != null) list.Add(Children);
            if (Unknown_78h_Data != null) list.Add(Unknown_78h_Data);
            if (Unknown_80h_Data != null) list.Add(Unknown_80h_Data);
            if (Unknown_88h_Data != null) list.Add(Unknown_88h_Data);
            if (Unknown_90h_Data != null) list.Add(Unknown_90h_Data);
            if (Unknown_98h_Data != null) list.Add(Unknown_98h_Data);
            if (Unknown_A8h_Data != null) list.Add(Unknown_A8h_Data);
            return list.ToArray();
        }

    }
}