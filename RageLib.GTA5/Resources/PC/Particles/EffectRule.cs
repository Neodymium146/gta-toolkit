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
    // ptxEffectRule
    public class EffectRule : ResourceSystemBlock
    {
        public override long Length => 0x3C0;

        // structure data
        public uint VFT;
        public uint Unknown_4h; // 0x00000001
        public uint Unknown_8h; // 0x00000000
        public uint Unknown_Ch; // 0x00000000
        public uint Unknown_10h; // 0x00000001
        public uint Unknown_14h; // 0x00000000
        public uint Unknown_18h; // 0x40866666
        public uint Unknown_1Ch; // 0x00000000
        public ulong NamePointer;
        public uint Unknown_28h; // 0x50000000 -> ".?AVptxFxList@rage@@" pointer to itself
        public uint Unknown_2Ch; // 0x00000000
        public uint Unknown_30h;
        public uint Unknown_34h; // 0x00000001
        public ulong EventEmittersPointer;
        public ushort EventEmittersCount1;
        public ushort EventEmittersCount2;
        public uint Unknown_44h;
        public ulong p4;
        public uint Unknown_50h;
        public uint Unknown_54h;
        public uint Unknown_58h; // 0x00000000
        public uint Unknown_5Ch; // 0x00000000
        public uint Unknown_60h; // 0x00000000
        public uint Unknown_64h; // 0x00000000
        public uint Unknown_68h; // 0x00000000
        public uint Unknown_6Ch;
        public uint Unknown_70h;
        public uint Unknown_74h;
        public uint Unknown_78h;
        public uint Unknown_7Ch;
        public uint Unknown_80h;
        public uint Unknown_84h;
        public uint Unknown_88h;
        public uint Unknown_8Ch;
        public uint Unknown_90h;
        public uint Unknown_94h;
        public uint Unknown_98h;
        public uint Unknown_9Ch;
        public uint Unknown_A0h;
        public uint Unknown_A4h;
        public uint Unknown_A8h;
        public uint Unknown_ACh;
        public uint Unknown_B0h;
        public uint Unknown_B4h;
        public uint Unknown_B8h;
        public uint Unknown_BCh;
        public KeyframeProp KeyframeProp0;
        public KeyframeProp KeyframeProp1;
        public KeyframeProp KeyframeProp2;
        public KeyframeProp KeyframeProp3;
        public KeyframeProp KeyframeProp4;
        public ulong KeyframePropsPointer;
        public ushort KeyframePropsCount1;
        public ushort KeyframePropsCount2;
        public uint Unknown_39Ch; // 0x00000000
        public uint Unknown_3A0h;
        public uint Unknown_3A4h; // 0x00000000
        public uint Unknown_3A8h; // 0x42C80000
        public uint Unknown_3ACh; // 0x00000000
        public uint Unknown_3B0h; // 0x00000000
        public uint Unknown_3B4h; // 0x00000000
        public uint Unknown_3B8h; // 0x00000000
        public uint Unknown_3BCh; // 0x00000000

        // reference data
        public string_r Name;
        public ResourcePointerArray64<EventEmitter> EventEmitters;
        public Unknown_P_004 p4data;
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
            this.EventEmittersPointer = reader.ReadUInt64();
            this.EventEmittersCount1 = reader.ReadUInt16();
            this.EventEmittersCount2 = reader.ReadUInt16();
            this.Unknown_44h = reader.ReadUInt32();
            this.p4 = reader.ReadUInt64();
            this.Unknown_50h = reader.ReadUInt32();
            this.Unknown_54h = reader.ReadUInt32();
            this.Unknown_58h = reader.ReadUInt32();
            this.Unknown_5Ch = reader.ReadUInt32();
            this.Unknown_60h = reader.ReadUInt32();
            this.Unknown_64h = reader.ReadUInt32();
            this.Unknown_68h = reader.ReadUInt32();
            this.Unknown_6Ch = reader.ReadUInt32();
            this.Unknown_70h = reader.ReadUInt32();
            this.Unknown_74h = reader.ReadUInt32();
            this.Unknown_78h = reader.ReadUInt32();
            this.Unknown_7Ch = reader.ReadUInt32();
            this.Unknown_80h = reader.ReadUInt32();
            this.Unknown_84h = reader.ReadUInt32();
            this.Unknown_88h = reader.ReadUInt32();
            this.Unknown_8Ch = reader.ReadUInt32();
            this.Unknown_90h = reader.ReadUInt32();
            this.Unknown_94h = reader.ReadUInt32();
            this.Unknown_98h = reader.ReadUInt32();
            this.Unknown_9Ch = reader.ReadUInt32();
            this.Unknown_A0h = reader.ReadUInt32();
            this.Unknown_A4h = reader.ReadUInt32();
            this.Unknown_A8h = reader.ReadUInt32();
            this.Unknown_ACh = reader.ReadUInt32();
            this.Unknown_B0h = reader.ReadUInt32();
            this.Unknown_B4h = reader.ReadUInt32();
            this.Unknown_B8h = reader.ReadUInt32();
            this.Unknown_BCh = reader.ReadUInt32();
            this.KeyframeProp0 = reader.ReadBlock<KeyframeProp>();
            this.KeyframeProp1 = reader.ReadBlock<KeyframeProp>();
            this.KeyframeProp2 = reader.ReadBlock<KeyframeProp>();
            this.KeyframeProp3 = reader.ReadBlock<KeyframeProp>();
            this.KeyframeProp4 = reader.ReadBlock<KeyframeProp>();
            this.KeyframePropsPointer = reader.ReadUInt64();
            this.KeyframePropsCount1 = reader.ReadUInt16();
            this.KeyframePropsCount2 = reader.ReadUInt16();
            this.Unknown_39Ch = reader.ReadUInt32();
            this.Unknown_3A0h = reader.ReadUInt32();
            this.Unknown_3A4h = reader.ReadUInt32();
            this.Unknown_3A8h = reader.ReadUInt32();
            this.Unknown_3ACh = reader.ReadUInt32();
            this.Unknown_3B0h = reader.ReadUInt32();
            this.Unknown_3B4h = reader.ReadUInt32();
            this.Unknown_3B8h = reader.ReadUInt32();
            this.Unknown_3BCh = reader.ReadUInt32();

            // read reference data
            this.Name = reader.ReadBlockAt<string_r>(
                this.NamePointer // offset
            );
            this.EventEmitters = reader.ReadBlockAt<ResourcePointerArray64<EventEmitter>>(
                this.EventEmittersPointer, // offset
                this.EventEmittersCount1
            );
            this.p4data = reader.ReadBlockAt<Unknown_P_004>(
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
            this.EventEmittersPointer = (ulong)(this.EventEmitters != null ? this.EventEmitters.Position : 0);
            //this.c3b = (ushort)(this.p3data != null ? this.p3data.Count : 0);
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
            writer.Write(this.EventEmittersPointer);
            writer.Write(this.EventEmittersCount1);
            writer.Write(this.EventEmittersCount2);
            writer.Write(this.Unknown_44h);
            writer.Write(this.p4);
            writer.Write(this.Unknown_50h);
            writer.Write(this.Unknown_54h);
            writer.Write(this.Unknown_58h);
            writer.Write(this.Unknown_5Ch);
            writer.Write(this.Unknown_60h);
            writer.Write(this.Unknown_64h);
            writer.Write(this.Unknown_68h);
            writer.Write(this.Unknown_6Ch);
            writer.Write(this.Unknown_70h);
            writer.Write(this.Unknown_74h);
            writer.Write(this.Unknown_78h);
            writer.Write(this.Unknown_7Ch);
            writer.Write(this.Unknown_80h);
            writer.Write(this.Unknown_84h);
            writer.Write(this.Unknown_88h);
            writer.Write(this.Unknown_8Ch);
            writer.Write(this.Unknown_90h);
            writer.Write(this.Unknown_94h);
            writer.Write(this.Unknown_98h);
            writer.Write(this.Unknown_9Ch);
            writer.Write(this.Unknown_A0h);
            writer.Write(this.Unknown_A4h);
            writer.Write(this.Unknown_A8h);
            writer.Write(this.Unknown_ACh);
            writer.Write(this.Unknown_B0h);
            writer.Write(this.Unknown_B4h);
            writer.Write(this.Unknown_B8h);
            writer.Write(this.Unknown_BCh);
            writer.WriteBlock(this.KeyframeProp0);
            writer.WriteBlock(this.KeyframeProp1);
            writer.WriteBlock(this.KeyframeProp2);
            writer.WriteBlock(this.KeyframeProp3);
            writer.WriteBlock(this.KeyframeProp4);
            writer.Write(this.KeyframePropsPointer);
            writer.Write(this.KeyframePropsCount1);
            writer.Write(this.KeyframePropsCount2);
            writer.Write(this.Unknown_39Ch);
            writer.Write(this.Unknown_3A0h);
            writer.Write(this.Unknown_3A4h);
            writer.Write(this.Unknown_3A8h);
            writer.Write(this.Unknown_3ACh);
            writer.Write(this.Unknown_3B0h);
            writer.Write(this.Unknown_3B4h);
            writer.Write(this.Unknown_3B8h);
            writer.Write(this.Unknown_3BCh);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (Name != null) list.Add(Name);
            if (EventEmitters != null) list.Add(EventEmitters);
            if (p4data != null) list.Add(p4data);
            if (KeyframeProps != null) list.Add(KeyframeProps);
            return list.ToArray();
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(192, KeyframeProp0),
                new Tuple<long, IResourceBlock>(336, KeyframeProp1),
                new Tuple<long, IResourceBlock>(480, KeyframeProp2),
                new Tuple<long, IResourceBlock>(624, KeyframeProp3),
                new Tuple<long, IResourceBlock>(768, KeyframeProp4)
            };
        }
    }
}
