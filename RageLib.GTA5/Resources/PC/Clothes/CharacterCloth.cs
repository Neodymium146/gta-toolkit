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
using System.Numerics;

namespace RageLib.Resources.GTA5.PC.Clothes
{
    // pgBase
    // clothBase (TODO)
    // characterCloth
    public class CharacterCloth : PgBase64
    {
        public override long BlockLength => 0xD0;

        // structure data
        public ResourceSimpleList64<DataVec3V> Poses;
        public ulong ControllerPointer;
        public ulong BoundCompositePointer;
        public SimpleList64<uint> Unknown_30h;
        public ulong Unknown_40h; // 0x0000000000000000
        public ulong Unknown_48h; // 0x0000000000000000
        public Matrix4x4 Unknown_50h;
        public SimpleList64<uint> BoneIndex;
        public ulong Unknown_A0h; // 0x0000000000000000
        public ulong Unknown_A8h; // 0x0000000000000000
        public ulong Unknown_B0h; // 0x0000000000000000
        public ulong Unknown_B8h; // 0x0000000000000000
        public uint Unknown_C0h; // 0x00000001
        public uint Unknown_C4h; // 0x00000000
        public ulong Unknown_C8h; // 0x0000000000000000

        // reference data
        public CharacterClothController Controller;
        public BoundComposite BoundComposite;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.Poses = reader.ReadBlock<ResourceSimpleList64<DataVec3V>>();
            this.ControllerPointer = reader.ReadUInt64();
            this.BoundCompositePointer = reader.ReadUInt64();
            this.Unknown_30h = reader.ReadBlock<SimpleList64<uint>>();
            this.Unknown_40h = reader.ReadUInt64();
            this.Unknown_48h = reader.ReadUInt64();
            this.Unknown_50h = reader.ReadMatrix4x4();
            this.BoneIndex = reader.ReadBlock<SimpleList64<uint>>();
            this.Unknown_A0h = reader.ReadUInt64();
            this.Unknown_A8h = reader.ReadUInt64();
            this.Unknown_B0h = reader.ReadUInt64();
            this.Unknown_B8h = reader.ReadUInt64();
            this.Unknown_C0h = reader.ReadUInt32();
            this.Unknown_C4h = reader.ReadUInt32();
            this.Unknown_C8h = reader.ReadUInt64();

            // read reference data
            this.Controller = reader.ReadBlockAt<CharacterClothController>(
                this.ControllerPointer // offset
            );
            this.BoundComposite = reader.ReadBlockAt<BoundComposite>(
                this.BoundCompositePointer // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.ControllerPointer = (ulong)(this.Controller != null ? this.Controller.BlockPosition : 0);
            this.BoundCompositePointer = (ulong)(this.BoundComposite != null ? this.BoundComposite.BlockPosition : 0);

            // write structure data
            writer.WriteBlock(this.Poses);
            writer.Write(this.ControllerPointer);
            writer.Write(this.BoundCompositePointer);
            writer.WriteBlock(this.Unknown_30h);
            writer.Write(this.Unknown_40h);
            writer.Write(this.Unknown_48h);
            writer.Write(this.Unknown_50h);
            writer.WriteBlock(this.BoneIndex);
            writer.Write(this.Unknown_A0h);
            writer.Write(this.Unknown_A8h);
            writer.Write(this.Unknown_B0h);
            writer.Write(this.Unknown_B8h);
            writer.Write(this.Unknown_C0h);
            writer.Write(this.Unknown_C4h);
            writer.Write(this.Unknown_C8h);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>(base.GetReferences());
            if (Controller != null) list.Add(Controller);
            if (BoundComposite != null) list.Add(BoundComposite);
            return list.ToArray();
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(0x10, Poses),
                new Tuple<long, IResourceBlock>(0x30, Unknown_30h),
                new Tuple<long, IResourceBlock>(0x90, BoneIndex)
            };
        }
    }
}
