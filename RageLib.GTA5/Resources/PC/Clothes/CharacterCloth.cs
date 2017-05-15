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
using System;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Clothes
{
    // pgBase
    // clothBase (TODO)
    // characterCloth
    public class CharacterCloth : ResourceSystemBlock
    {
        public override long Length => 0xD0;

        // structure data
        public uint VFT;
        public uint Unknown_4h; // 0x00000001
        public uint Unknown_8h; // 0x00000000
        public uint Unknown_Ch; // 0x00000000
        public ResourceSimpleList64<Unknown_C_001> Unknown_10h;
        public ulong ControllerPointer;
        public ulong BoundPointer;
        public ResourceSimpleList64<uint_r> Unknown_30h;
        public uint Unknown_40h; // 0x00000000
        public uint Unknown_44h; // 0x00000000
        public uint Unknown_48h; // 0x00000000
        public uint Unknown_4Ch; // 0x00000000
        public uint Unknown_50h; // 0x3F800000
        public uint Unknown_54h; // 0x00000000
        public uint Unknown_58h; // 0x00000000
        public uint Unknown_5Ch; // 0x00000000
        public uint Unknown_60h; // 0x00000000
        public uint Unknown_64h; // 0x3F800000
        public uint Unknown_68h; // 0x00000000
        public uint Unknown_6Ch; // 0x00000000
        public uint Unknown_70h; // 0x00000000
        public uint Unknown_74h; // 0x00000000
        public uint Unknown_78h; // 0x3F800000
        public uint Unknown_7Ch; // 0x00000000
        public uint Unknown_80h; // 0x00000000
        public uint Unknown_84h; // 0x00000000
        public uint Unknown_88h; // 0x00000000
        public uint Unknown_8Ch; // 0x00000000
        public ResourceSimpleList64<uint_r> Unknown_90h;
        public uint Unknown_A0h; // 0x00000000
        public uint Unknown_A4h; // 0x00000000
        public uint Unknown_A8h; // 0x00000000
        public uint Unknown_ACh; // 0x00000000
        public uint Unknown_B0h; // 0x00000000
        public uint Unknown_B4h; // 0x00000000
        public uint Unknown_B8h; // 0x00000000
        public uint Unknown_BCh; // 0x00000000
        public uint Unknown_C0h; // 0x00000001
        public uint Unknown_C4h; // 0x00000000
        public uint Unknown_C8h; // 0x00000000
        public uint Unknown_CCh; // 0x00000000

        // reference data
        public CharacterClothController Controller;
        public Bound Bound;

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
            this.Unknown_10h = reader.ReadBlock<ResourceSimpleList64<Unknown_C_001>>();
            this.ControllerPointer = reader.ReadUInt64();
            this.BoundPointer = reader.ReadUInt64();
            this.Unknown_30h = reader.ReadBlock<ResourceSimpleList64<uint_r>>();
            this.Unknown_40h = reader.ReadUInt32();
            this.Unknown_44h = reader.ReadUInt32();
            this.Unknown_48h = reader.ReadUInt32();
            this.Unknown_4Ch = reader.ReadUInt32();
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
            this.Unknown_90h = reader.ReadBlock<ResourceSimpleList64<uint_r>>();
            this.Unknown_A0h = reader.ReadUInt32();
            this.Unknown_A4h = reader.ReadUInt32();
            this.Unknown_A8h = reader.ReadUInt32();
            this.Unknown_ACh = reader.ReadUInt32();
            this.Unknown_B0h = reader.ReadUInt32();
            this.Unknown_B4h = reader.ReadUInt32();
            this.Unknown_B8h = reader.ReadUInt32();
            this.Unknown_BCh = reader.ReadUInt32();
            this.Unknown_C0h = reader.ReadUInt32();
            this.Unknown_C4h = reader.ReadUInt32();
            this.Unknown_C8h = reader.ReadUInt32();
            this.Unknown_CCh = reader.ReadUInt32();

            // read reference data
            this.Controller = reader.ReadBlockAt<CharacterClothController>(
                this.ControllerPointer // offset
            );
            this.Bound = reader.ReadBlockAt<Bound>(
                this.BoundPointer // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.ControllerPointer = (ulong)(this.Controller != null ? this.Controller.Position : 0);
            this.BoundPointer = (ulong)(this.Bound != null ? this.Bound.Position : 0);

            // write structure data
            writer.Write(this.VFT);
            writer.Write(this.Unknown_4h);
            writer.Write(this.Unknown_8h);
            writer.Write(this.Unknown_Ch);
            writer.WriteBlock(this.Unknown_10h);
            writer.Write(this.ControllerPointer);
            writer.Write(this.BoundPointer);
            writer.WriteBlock(this.Unknown_30h);
            writer.Write(this.Unknown_40h);
            writer.Write(this.Unknown_44h);
            writer.Write(this.Unknown_48h);
            writer.Write(this.Unknown_4Ch);
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
            writer.WriteBlock(this.Unknown_90h);
            writer.Write(this.Unknown_A0h);
            writer.Write(this.Unknown_A4h);
            writer.Write(this.Unknown_A8h);
            writer.Write(this.Unknown_ACh);
            writer.Write(this.Unknown_B0h);
            writer.Write(this.Unknown_B4h);
            writer.Write(this.Unknown_B8h);
            writer.Write(this.Unknown_BCh);
            writer.Write(this.Unknown_C0h);
            writer.Write(this.Unknown_C4h);
            writer.Write(this.Unknown_C8h);
            writer.Write(this.Unknown_CCh);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (Controller != null) list.Add(Controller);
            if (Bound != null) list.Add(Bound);
            return list.ToArray();
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(0x10, Unknown_10h),
                new Tuple<long, IResourceBlock>(0x30, Unknown_30h),
                new Tuple<long, IResourceBlock>(0x90, Unknown_90h)
            };
        }
    }
}
