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
using RageLib.Resources.GTA5.PC.Fragments;
using System;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Clothes
{
    // pgBase
    // clothBase (TODO)
    // environmentCloth
    public class EnvironmentCloth : PgBase64
    {
        public override long BlockLength => 0x80;

        // structure data
        public ulong InstanceTuningPointer;
        public ulong DrawablePointer;
        public ulong Unknown_20h; // 0x0000000000000000
        public ulong ControllerPointer;
        public ulong Unknown_30h; // 0x0000000000000000
        public ulong Unknown_38h; // 0x0000000000000000
        public ulong Unknown_40h; // 0x0000000000000000
        public ulong Unknown_48h; // 0x0000000000000000
        public ulong Unknown_50h; // 0x0000000000000000
        public ulong Unknown_58h; // 0x0000000000000000
        public SimpleList64<uint> UserData;
        public ulong Unknown_70h; // 0x0000000000000000
        public uint Unknown_78h;
        public uint Unknown_7Ch; // 0x00000000

        // reference data
        public ClothInstanceTuning InstanceTuning;
        public FragDrawable Drawable;
        public ClothController Controller;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.InstanceTuningPointer = reader.ReadUInt64();
            this.DrawablePointer = reader.ReadUInt64();
            this.Unknown_20h = reader.ReadUInt64();
            this.ControllerPointer = reader.ReadUInt64();
            this.Unknown_30h = reader.ReadUInt64();
            this.Unknown_38h = reader.ReadUInt64();
            this.Unknown_40h = reader.ReadUInt64();
            this.Unknown_48h = reader.ReadUInt64();
            this.Unknown_50h = reader.ReadUInt64();
            this.Unknown_58h = reader.ReadUInt64();
            this.UserData = reader.ReadBlock<SimpleList64<uint>>();
            this.Unknown_70h = reader.ReadUInt64();
            this.Unknown_78h = reader.ReadUInt32();
            this.Unknown_7Ch = reader.ReadUInt32();

            // read reference data
            this.InstanceTuning = reader.ReadBlockAt<ClothInstanceTuning>(
                this.InstanceTuningPointer // offset
            );
            this.Drawable = reader.ReadBlockAt<FragDrawable>(
                this.DrawablePointer // offset
            );
            this.Controller = reader.ReadBlockAt<ClothController>(
                this.ControllerPointer // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.InstanceTuningPointer = (ulong)(this.InstanceTuning != null ? this.InstanceTuning.BlockPosition : 0);
            this.DrawablePointer = (ulong)(this.Drawable != null ? this.Drawable.BlockPosition : 0);
            this.ControllerPointer = (ulong)(this.Controller != null ? this.Controller.BlockPosition : 0);

            // write structure data
            writer.Write(this.InstanceTuningPointer);
            writer.Write(this.DrawablePointer);
            writer.Write(this.Unknown_20h);
            writer.Write(this.ControllerPointer);
            writer.Write(this.Unknown_30h);
            writer.Write(this.Unknown_38h);
            writer.Write(this.Unknown_40h);
            writer.Write(this.Unknown_48h);
            writer.Write(this.Unknown_50h);
            writer.Write(this.Unknown_58h);
            writer.WriteBlock(this.UserData);
            writer.Write(this.Unknown_70h);
            writer.Write(this.Unknown_78h);
            writer.Write(this.Unknown_7Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>(base.GetReferences());
            if (InstanceTuning != null) list.Add(InstanceTuning);
            if (Drawable != null) list.Add(Drawable);
            if (Controller != null) list.Add(Controller);
            return list.ToArray();
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(0x60, UserData)
            };
        }
    }
}
