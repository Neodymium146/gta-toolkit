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
using RageLib.Resources.GTA5.PC.Bounds;
using RageLib.Resources.GTA5.PC.Drawables;
using System;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Fragments
{
    // fragDrawable
    public class FragDrawable : Drawable
    {
        public override long BlockLength => 0x150;

        // structure data
        public ulong Unknown_A8h; // 0x0000000000000000
        public RAGE_Matrix4x4 Unknown_B0h;      
        public ulong BoundPointer;
        public ResourceSimpleList64<ulong_r> Unknown_F8h_Data;
        public ResourceSimpleList64<RAGE_Matrix4x4> Unknown_108h_Data;
        public ulong Unknown_118h; // 0x0000000000000000
        public ulong Unknown_120h; // 0x0000000000000000
        public ulong Unknown_128h; // 0x0000000000000000
        public ulong NamePointer;
        public ulong Unknown_138h; // 0x0000000000000000
        public ulong Unknown_140h; // 0x0000000000000000
        public ulong Unknown_148h; // 0x0000000000000000

        // reference data
        public Bound Bound;
        public string_r Name;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.Unknown_A8h = reader.ReadUInt64();
            this.Unknown_B0h = reader.ReadBlock<RAGE_Matrix4x4>();
            this.BoundPointer = reader.ReadUInt64();
            this.Unknown_F8h_Data = reader.ReadBlock<ResourceSimpleList64<ulong_r>>();
            this.Unknown_108h_Data = reader.ReadBlock<ResourceSimpleList64<RAGE_Matrix4x4>>();
            this.Unknown_118h = reader.ReadUInt64();
            this.Unknown_120h = reader.ReadUInt64();
            this.Unknown_128h = reader.ReadUInt64();
            this.NamePointer = reader.ReadUInt64();
            this.Unknown_138h = reader.ReadUInt64();
            this.Unknown_140h = reader.ReadUInt64();
            this.Unknown_148h = reader.ReadUInt64();

            // read reference data
            this.Bound = reader.ReadBlockAt<Bound>(
                this.BoundPointer // offset
            );
            this.Name = reader.ReadBlockAt<string_r>(
                this.NamePointer // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.BoundPointer = (ulong)(this.Bound != null ? this.Bound.BlockPosition : 0);
            this.NamePointer = (ulong)(this.Name != null ? this.Name.BlockPosition : 0);

            // write structure data
            writer.Write(this.Unknown_A8h);
            writer.WriteBlock(this.Unknown_B0h);
            writer.Write(this.BoundPointer);
            writer.WriteBlock(this.Unknown_F8h_Data);
            writer.WriteBlock(this.Unknown_108h_Data);
            writer.Write(this.Unknown_118h);
            writer.Write(this.Unknown_120h);
            writer.Write(this.Unknown_128h);
            writer.Write(this.NamePointer);
            writer.Write(this.Unknown_138h);
            writer.Write(this.Unknown_140h);
            writer.Write(this.Unknown_148h);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>(base.GetReferences());
            if (Bound != null) list.Add(Bound);
            if (Name != null) list.Add(Name);
            return list.ToArray();
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            var list = new List<Tuple<long, IResourceBlock>>(base.GetParts());
            
            list.AddRange(new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(0xF8, Unknown_F8h_Data),
                new Tuple<long, IResourceBlock>(0x108, Unknown_108h_Data),
            });
            return list.ToArray();
        }
    }
}
