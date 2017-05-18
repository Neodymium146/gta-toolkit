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

namespace RageLib.Resources.GTA5.PC.Particles
{
    // pgBase
    // pgBaseRefCounted
    // ptxEmitterRule
    public class EmitterRule : ResourceSystemBlock
    {
        public override long Length => 0x630;

        // structure data
        public uint VFT;
        public uint Unknown_4h; // 0x00000001
        public uint Unknown_8h; // 0x00000000
        public uint Unknown_Ch; // 0x00000000
        public uint Unknown_10h;
        public uint Unknown_14h; // 0x00000000
        public uint Unknown_18h; // 0x40833333 
        public uint Unknown_1Ch; // 0x00000000
        public ulong NamePointer;
        public uint Unknown_28h; // 0x00000000
        public uint Unknown_2Ch; // 0x00000000
        public uint Unknown_30h; // 0x00000000
        public uint Unknown_34h; // 0x00000000
        public ulong p2;
        public uint Unknown_40h; // 0x00000000
        public uint Unknown_44h; // 0x00000000
        public ulong p3;
        public uint Unknown_50h; // 0x00000000
        public uint Unknown_54h; // 0x00000000
        public ulong p4;
        public uint Unknown_60h; // 0x00000000
        public uint Unknown_64h; // 0x00000000
        public uint Unknown_68h; // 0x00000000
        public uint Unknown_6Ch; // 0x00000000
        public uint Unknown_70h; // 0x00000000
        public uint Unknown_74h; // 0x00000000
        public KeyframeProp KeyframeProp0;
        public KeyframeProp KeyframeProp1;
        public KeyframeProp KeyframeProp2;
        public KeyframeProp KeyframeProp3;
        public KeyframeProp KeyframeProp4;
        public KeyframeProp KeyframeProp5;
        public KeyframeProp KeyframeProp6;
        public KeyframeProp KeyframeProp7;
        public KeyframeProp KeyframeProp8;
        public KeyframeProp KeyframeProp9;
        public ulong KeyframePropsPointer;
        public ushort KeyframePropsCount1; // 10
        public ushort KeyframePropsCount2; // 10
        public uint Unknown_624h; // 0x00000000
        public uint Unknown_628h;
        public uint Unknown_62Ch; // 0x00000000

        // reference data
        public string_r Name;
        public Domain p2data;
        public Domain p3data;
        public Domain p4data;
        public ResourcePointerArray64<KeyframeProp> KeyframeProps;

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
            this.Unknown_18h = reader.ReadUInt32();
            this.Unknown_1Ch = reader.ReadUInt32();
            this.NamePointer = reader.ReadUInt64();
            this.Unknown_28h = reader.ReadUInt32();
            this.Unknown_2Ch = reader.ReadUInt32();
            this.Unknown_30h = reader.ReadUInt32();
            this.Unknown_34h = reader.ReadUInt32();
            this.p2 = reader.ReadUInt64();
            this.Unknown_40h = reader.ReadUInt32();
            this.Unknown_44h = reader.ReadUInt32();
            this.p3 = reader.ReadUInt64();
            this.Unknown_50h = reader.ReadUInt32();
            this.Unknown_54h = reader.ReadUInt32();
            this.p4 = reader.ReadUInt64();
            this.Unknown_60h = reader.ReadUInt32();
            this.Unknown_64h = reader.ReadUInt32();
            this.Unknown_68h = reader.ReadUInt32();
            this.Unknown_6Ch = reader.ReadUInt32();
            this.Unknown_70h = reader.ReadUInt32();
            this.Unknown_74h = reader.ReadUInt32();
            this.KeyframeProp0 = reader.ReadBlock<KeyframeProp>();
            this.KeyframeProp1 = reader.ReadBlock<KeyframeProp>();
            this.KeyframeProp2 = reader.ReadBlock<KeyframeProp>();
            this.KeyframeProp3 = reader.ReadBlock<KeyframeProp>();
            this.KeyframeProp4 = reader.ReadBlock<KeyframeProp>();
            this.KeyframeProp5 = reader.ReadBlock<KeyframeProp>();
            this.KeyframeProp6 = reader.ReadBlock<KeyframeProp>();
            this.KeyframeProp7 = reader.ReadBlock<KeyframeProp>();
            this.KeyframeProp8 = reader.ReadBlock<KeyframeProp>();
            this.KeyframeProp9 = reader.ReadBlock<KeyframeProp>();
            this.KeyframePropsPointer = reader.ReadUInt64();
            this.KeyframePropsCount1 = reader.ReadUInt16();
            this.KeyframePropsCount2 = reader.ReadUInt16();
            this.Unknown_624h = reader.ReadUInt32();
            this.Unknown_628h = reader.ReadUInt32();
            this.Unknown_62Ch = reader.ReadUInt32();

            // read reference data
            this.Name = reader.ReadBlockAt<string_r>(
                this.NamePointer // offset
            );
            this.p2data = reader.ReadBlockAt<Domain>(
                this.p2 // offset
            );
            this.p3data = reader.ReadBlockAt<Domain>(
                this.p3 // offset
            );
            this.p4data = reader.ReadBlockAt<Domain>(
                this.p4 // offset
            );
            this.KeyframeProps = reader.ReadBlockAt<ResourcePointerArray64<KeyframeProp>>(
                this.KeyframePropsPointer, // offset
                this.KeyframePropsCount2
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
            this.p4 = (ulong)(this.p4data != null ? this.p4data.Position : 0);
            this.KeyframePropsPointer = (ulong)(this.KeyframeProps != null ? this.KeyframeProps.Position : 0);
            //this.refcnt2 = (ushort)(this.refs != null ? this.refs.Count : 0);

            // write structure data
            writer.Write(this.VFT);
            writer.Write(this.Unknown_4h);
            writer.Write(this.Unknown_8h);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.Write(this.Unknown_18h);
            writer.Write(this.Unknown_1Ch);
            writer.Write(this.NamePointer);
            writer.Write(this.Unknown_28h);
            writer.Write(this.Unknown_2Ch);
            writer.Write(this.Unknown_30h);
            writer.Write(this.Unknown_34h);
            writer.Write(this.p2);
            writer.Write(this.Unknown_40h);
            writer.Write(this.Unknown_44h);
            writer.Write(this.p3);
            writer.Write(this.Unknown_50h);
            writer.Write(this.Unknown_54h);
            writer.Write(this.p4);
            writer.Write(this.Unknown_60h);
            writer.Write(this.Unknown_64h);
            writer.Write(this.Unknown_68h);
            writer.Write(this.Unknown_6Ch);
            writer.Write(this.Unknown_70h);
            writer.Write(this.Unknown_74h);
            writer.WriteBlock(this.KeyframeProp0);
            writer.WriteBlock(this.KeyframeProp1);
            writer.WriteBlock(this.KeyframeProp2);
            writer.WriteBlock(this.KeyframeProp3);
            writer.WriteBlock(this.KeyframeProp4);
            writer.WriteBlock(this.KeyframeProp5);
            writer.WriteBlock(this.KeyframeProp6);
            writer.WriteBlock(this.KeyframeProp7);
            writer.WriteBlock(this.KeyframeProp8);
            writer.WriteBlock(this.KeyframeProp9);
            writer.Write(this.KeyframePropsPointer);
            writer.Write(this.KeyframePropsCount1);
            writer.Write(this.KeyframePropsCount2);
            writer.Write(this.Unknown_624h);
            writer.Write(this.Unknown_628h);
            writer.Write(this.Unknown_62Ch);
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
            if (p4data != null) list.Add(p4data);
            if (KeyframeProps != null) list.Add(KeyframeProps);
            return list.ToArray();
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(120, KeyframeProp0),
                new Tuple<long, IResourceBlock>(264, KeyframeProp1),
                new Tuple<long, IResourceBlock>(408, KeyframeProp2),
                new Tuple<long, IResourceBlock>(552, KeyframeProp3),
                new Tuple<long, IResourceBlock>(696, KeyframeProp4),
                new Tuple<long, IResourceBlock>(840, KeyframeProp5),
                new Tuple<long, IResourceBlock>(984, KeyframeProp6),
                new Tuple<long, IResourceBlock>(1128, KeyframeProp7),
                new Tuple<long, IResourceBlock>(1272, KeyframeProp8),
                new Tuple<long, IResourceBlock>(1416, KeyframeProp9),
            };
        }
    }
}
