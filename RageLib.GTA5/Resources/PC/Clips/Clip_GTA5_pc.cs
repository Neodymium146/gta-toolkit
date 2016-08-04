/*
    Copyright(c) 2016 Neodymium

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
using System;

namespace RageLib.Resources.GTA5.PC.Clips
{
    public class Clip_GTA5_pc : ResourceSystemBlock, IResourceXXSystemBlock
    {
        public override long Length
        {
            get { return 112; }
        }

        // structure data
        public uint VFT;
        public uint Unknown_4h; // 0x00000001
        public uint Unknown_8h; // 0x00000000
        public uint Unknown_Ch; // 0x00000000
        public uint Unknown_10h;
        public uint Unknown_14h; // 0x00000000
        public ulong NamePointer;
        public uint Unknown_20h; // short, short -> name length (+1)
        public uint Unknown_24h; // 0x00000000
        public uint Unknown_28h; // 0x50000000
        public uint Unknown_2Ch; // 0x00000000
        public uint Unknown_30h;
        public uint Unknown_34h; // 0x00000000
        public ulong p2;
        public ulong p3;
        public uint Unknown_48h; // 0x00000001
        public uint Unknown_4Ch; // 0x00000000       

        // reference data
        public string_r Name;
        public Unknown_CL_200 p2data;
        public Unknown_CL_001 p3data;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.VFT = reader.ReadUInt32();
            this.Unknown_4h = reader.ReadUInt32();
            this.Unknown_8h = reader.ReadUInt32();
            this.Unknown_Ch = reader.ReadUInt32();
            this.Unknown_10h = reader.ReadUInt32();
            this.Unknown_14h = reader.ReadUInt32();
            this.NamePointer = reader.ReadUInt64();
            this.Unknown_20h = reader.ReadUInt32();
            this.Unknown_24h = reader.ReadUInt32();
            this.Unknown_28h = reader.ReadUInt32();
            this.Unknown_2Ch = reader.ReadUInt32();
            this.Unknown_30h = reader.ReadUInt32();
            this.Unknown_34h = reader.ReadUInt32();
            this.p2 = reader.ReadUInt64();
            this.p3 = reader.ReadUInt64();
            this.Unknown_48h = reader.ReadUInt32();
            this.Unknown_4Ch = reader.ReadUInt32();

            // read reference data
            this.Name = reader.ReadBlockAt<string_r>(
                this.NamePointer // offset
            );
            this.p2data = reader.ReadBlockAt<Unknown_CL_200>(
                this.p2 // offset
            );
            this.p3data = reader.ReadBlockAt<Unknown_CL_001>(
                this.p3 // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.NamePointer = (ulong)(this.Name != null ? this.Name.Position : 0);
            this.p2 = (ulong)(this.p2data != null ? this.p2data.Position : 0);
            this.p3 = (ulong)(this.p3data != null ? this.p3data.Position : 0);

            // write structure data
            writer.Write(this.VFT);
            writer.Write(this.Unknown_4h);
            writer.Write(this.Unknown_8h);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.Write(this.NamePointer);
            writer.Write(this.Unknown_20h);
            writer.Write(this.Unknown_24h);
            writer.Write(this.Unknown_28h);
            writer.Write(this.Unknown_2Ch);
            writer.Write(this.Unknown_30h);
            writer.Write(this.Unknown_34h);
            writer.Write(this.p2);
            writer.Write(this.p3);
            writer.Write(this.Unknown_48h);
            writer.Write(this.Unknown_4Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (Name != null) list.Add(Name);
            if (p2data != null) list.Add(p2data);
            if (p3data != null) list.Add(p3data);
            return list.ToArray();
        }

        public IResourceSystemBlock GetType(ResourceDataReader reader, params object[] parameters)
        {
            reader.Position += 16;
            var type = reader.ReadByte();
            reader.Position -= 17;

            switch (type)
            {
                case 1: return new ClipAnimation_GTA5_pc();
                case 2: return new ClipAnimations_GTA5_pc();
                default: throw new Exception("Unknown type");
            }
        }
    }
}
