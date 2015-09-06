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

namespace RageLib.Resources.GTA5.PC.Nodes
{
    public class NodesFile_GTA5_pc : FileBase64_GTA5_pc
    {
        public override long Length
        {
            get { return 112; }
        }

        // structure data
        public ulong p1;
        public uint len1;
        public uint len2;
        public uint Unknown_20h;
        public uint Unknown_24h; // 0x00000000
        public ulong p2;
        public uint len3;
        public uint Unknown_34h; // 0x00000000
        public ulong p3;
        public ulong p4;
        public uint Unknown_48h; // 0x00000001
        public uint Unknown_4Ch; // 0x00000000
        public ulong p5;
        public ushort cnt5a;
        public ushort cnt5b;
        public uint Unknown_5Ch; // 0x00000000
        public uint len4;
        public uint len5;
        public uint Unknown_68h; // 0x00000000
        public uint Unknown_6Ch; // 0x00000000

        // reference data
        public ResourceSimpleArray<Node> Nodes;
        public ResourceSimpleArray<Unknown_ND_002> p2_data;
        public ResourceSimpleArray<Unknown_ND_003> p3_data;
        public ResourceSimpleArray<byte_r> p4_data;
        public ResourceSimpleArray<Unknown_ND_004> p5_data;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.p1 = reader.ReadUInt64();
            this.len1 = reader.ReadUInt32();
            this.len2 = reader.ReadUInt32();
            this.Unknown_20h = reader.ReadUInt32();
            this.Unknown_24h = reader.ReadUInt32();
            this.p2 = reader.ReadUInt64();
            this.len3 = reader.ReadUInt32();
            this.Unknown_34h = reader.ReadUInt32();
            this.p3 = reader.ReadUInt64();
            this.p4 = reader.ReadUInt64();
            this.Unknown_48h = reader.ReadUInt32();
            this.Unknown_4Ch = reader.ReadUInt32();
            this.p5 = reader.ReadUInt64();
            this.cnt5a = reader.ReadUInt16();
            this.cnt5b = reader.ReadUInt16();
            this.Unknown_5Ch = reader.ReadUInt32();
            this.len4 = reader.ReadUInt32();
            this.len5 = reader.ReadUInt32();
            this.Unknown_68h = reader.ReadUInt32();
            this.Unknown_6Ch = reader.ReadUInt32();

            // read reference data
            this.Nodes = reader.ReadBlockAt<ResourceSimpleArray<Node>>(
                this.p1, // offset
                this.len1
            );
            this.p2_data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_ND_002>>(
                this.p2, // offset
                this.len3
            );
            this.p3_data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_ND_003>>(
                this.p3, // offset
                this.len4
            );
            this.p4_data = reader.ReadBlockAt<ResourceSimpleArray<byte_r>>(
                this.p4, // offset
                this.len5
            );
            this.p5_data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_ND_004>>(
                this.p5, // offset
                this.cnt5b
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.p1 = (ulong)(this.Nodes != null ? this.Nodes.Position : 0);
            //this.len1 = (uint)(this.Nodes != null ? this.Nodes.Count : 0);
            this.p2 = (ulong)(this.p2_data != null ? this.p2_data.Position : 0);
            //this.len3 = (uint)(this.p2_data != null ? this.p2_data.Count : 0);
            this.p3 = (ulong)(this.p3_data != null ? this.p3_data.Position : 0);
            this.p4 = (ulong)(this.p4_data != null ? this.p4_data.Position : 0);
            this.p5 = (ulong)(this.p5_data != null ? this.p5_data.Position : 0);
            //this.cnt5b = (ushort)(this.p5_data != null ? this.p5_data.Count : 0);
            //this.len4 = (uint)(this.p3_data != null ? this.p3_data.Count : 0);
            //this.len5 = (uint)(this.p4_data != null ? this.p4_data.Count : 0);

            // write structure data
            writer.Write(this.p1);
            writer.Write(this.len1);
            writer.Write(this.len2);
            writer.Write(this.Unknown_20h);
            writer.Write(this.Unknown_24h);
            writer.Write(this.p2);
            writer.Write(this.len3);
            writer.Write(this.Unknown_34h);
            writer.Write(this.p3);
            writer.Write(this.p4);
            writer.Write(this.Unknown_48h);
            writer.Write(this.Unknown_4Ch);
            writer.Write(this.p5);
            writer.Write(this.cnt5a);
            writer.Write(this.cnt5b);
            writer.Write(this.Unknown_5Ch);
            writer.Write(this.len4);
            writer.Write(this.len5);
            writer.Write(this.Unknown_68h);
            writer.Write(this.Unknown_6Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>(base.GetReferences());
            if (Nodes != null) list.Add(Nodes);
            if (p2_data != null) list.Add(p2_data);
            if (p3_data != null) list.Add(p3_data);
            if (p4_data != null) list.Add(p4_data);
            if (p5_data != null) list.Add(p5_data);
            return list.ToArray();
        }

    }
}