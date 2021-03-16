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
using System.Numerics;

namespace RageLib.Resources.GTA5.PC.Particles
{
    // pgBase
    // pgBaseRefCounted
    // ptxEffectRule
    public class EffectRule : PgBase64
    {
        public override long BlockLength => 0x3C0;

        // structure data
        public uint Unknown_10h; // 0x00000001
        public uint Unknown_14h; // 0x00000000
        public float Unknown_18h; // 0x40866666
        public uint Unknown_1Ch; // 0x00000000
        public ulong NamePointer;
        public ulong Unknown_28h; // 0x5000000000000000 -> ".?AVptxFxList@rage@@" pointer to itself
        public ulong VFTx2;
        public ResourcePointerList64<EventEmitter> EventEmitters;
        public ulong p4;
        public uint Unknown_50h;
        public uint Unknown_54h;
        public uint Unknown_58h; // 0x00000000
        public uint Unknown_5Ch; // 0x00000000
        public Vector4 Unknown_60h;
        public Vector4 Unknown_70h;
        public float Unknown_80h;
        public float Unknown_84h;
        public uint Unknown_88h;
        public uint Unknown_8Ch;
        public Vector4 Unknown_90h;
        public Vector4 Unknown_A0h;
        public Vector4 Unknown_B0h;
        public KeyframeProp KeyframeProp0;
        public KeyframeProp KeyframeProp1;
        public KeyframeProp KeyframeProp2;
        public KeyframeProp KeyframeProp3;
        public KeyframeProp KeyframeProp4;
        public ResourcePointerList64<KeyframeProp> KeyframeProps;
        public uint Unknown_3A0h;
        public uint Unknown_3A4h; // 0x00000000
        public float Unknown_3A8h; // 0x42C80000
        public uint Unknown_3ACh; // 0x00000000
        public ulong Unknown_3B0h; // 0x0000000000000000
        public ulong Unknown_3B8h; // 0x0000000000000000

        // reference data
        public string_r Name;
        public EvolutionParameters p4data;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.Unknown_10h = reader.ReadUInt32();
            this.Unknown_14h = reader.ReadUInt32();
            this.Unknown_18h = reader.ReadSingle();
            this.Unknown_1Ch = reader.ReadUInt32();
            this.NamePointer = reader.ReadUInt64();
            this.Unknown_28h = reader.ReadUInt64();
            this.VFTx2 = reader.ReadUInt64();
            this.EventEmitters = reader.ReadBlock<ResourcePointerList64<EventEmitter>>();
            this.p4 = reader.ReadUInt64();
            this.Unknown_50h = reader.ReadUInt32();
            this.Unknown_54h = reader.ReadUInt32();
            this.Unknown_58h = reader.ReadUInt32();
            this.Unknown_5Ch = reader.ReadUInt32();
            this.Unknown_60h = reader.ReadVector4();
            this.Unknown_70h = reader.ReadVector4();
            this.Unknown_80h = reader.ReadSingle();
            this.Unknown_84h = reader.ReadSingle();
            this.Unknown_88h = reader.ReadUInt32();
            this.Unknown_8Ch = reader.ReadUInt32();
            this.Unknown_90h = reader.ReadVector4();
            this.Unknown_A0h = reader.ReadVector4();
            this.Unknown_B0h = reader.ReadVector4();
            this.KeyframeProp0 = reader.ReadBlock<KeyframeProp>();
            this.KeyframeProp1 = reader.ReadBlock<KeyframeProp>();
            this.KeyframeProp2 = reader.ReadBlock<KeyframeProp>();
            this.KeyframeProp3 = reader.ReadBlock<KeyframeProp>();
            this.KeyframeProp4 = reader.ReadBlock<KeyframeProp>();
            this.KeyframeProps = reader.ReadBlock<ResourcePointerList64<KeyframeProp>>();
            this.Unknown_3A0h = reader.ReadUInt32();
            this.Unknown_3A4h = reader.ReadUInt32();
            this.Unknown_3A8h = reader.ReadSingle();
            this.Unknown_3ACh = reader.ReadUInt32();
            this.Unknown_3B0h = reader.ReadUInt64();
            this.Unknown_3B8h = reader.ReadUInt64();

            // read reference data
            this.Name = reader.ReadBlockAt<string_r>(
                this.NamePointer // offset
            );
            this.p4data = reader.ReadBlockAt<EvolutionParameters>(
                this.p4 // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.NamePointer = (ulong)(this.Name != null ? this.Name.BlockPosition : 0);
            //this.c3b = (ushort)(this.p3data != null ? this.p3data.Count : 0);
            this.p4 = (ulong)(this.p4data != null ? this.p4data.BlockPosition : 0);
            //this.refcnt2 = (ushort)(this.refs != null ? this.refs.Count : 0);

            // write structure data
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.Write(this.Unknown_18h);
            writer.Write(this.Unknown_1Ch);
            writer.Write(this.NamePointer);
            writer.Write(this.Unknown_28h);
            writer.Write(this.VFTx2);
            writer.WriteBlock(this.EventEmitters);
            writer.Write(this.p4);
            writer.Write(this.Unknown_50h);
            writer.Write(this.Unknown_54h);
            writer.Write(this.Unknown_58h);
            writer.Write(this.Unknown_5Ch);
            writer.Write(this.Unknown_60h);
            writer.Write(this.Unknown_70h);
            writer.Write(this.Unknown_80h);
            writer.Write(this.Unknown_84h);
            writer.Write(this.Unknown_88h);
            writer.Write(this.Unknown_8Ch);
            writer.Write(this.Unknown_90h);
            writer.Write(this.Unknown_A0h);
            writer.Write(this.Unknown_B0h);
            writer.WriteBlock(this.KeyframeProp0);
            writer.WriteBlock(this.KeyframeProp1);
            writer.WriteBlock(this.KeyframeProp2);
            writer.WriteBlock(this.KeyframeProp3);
            writer.WriteBlock(this.KeyframeProp4);
            writer.WriteBlock(this.KeyframeProps);
            writer.Write(this.Unknown_3A0h);
            writer.Write(this.Unknown_3A4h);
            writer.Write(this.Unknown_3A8h);
            writer.Write(this.Unknown_3ACh);
            writer.Write(this.Unknown_3B0h);
            writer.Write(this.Unknown_3B8h);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>(base.GetReferences());
            if (Name != null) list.Add(Name);
            if (p4data != null) list.Add(p4data);
            return list.ToArray();
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(56, EventEmitters),
                new Tuple<long, IResourceBlock>(192, KeyframeProp0),
                new Tuple<long, IResourceBlock>(336, KeyframeProp1),
                new Tuple<long, IResourceBlock>(480, KeyframeProp2),
                new Tuple<long, IResourceBlock>(624, KeyframeProp3),
                new Tuple<long, IResourceBlock>(768, KeyframeProp4),
                new Tuple<long, IResourceBlock>(912, KeyframeProps)
            };
        }
    }
}
