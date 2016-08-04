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

namespace RageLib.Resources.GTA5.PC.Clips
{
    public class ClipDictionary_GTA5_pc : FileBase64_GTA5_pc
    {
        public override long Length
        {
            get { return 64; }
        }

        // structure data
        public uint Unknown_10h; // 0x00000000
        public uint Unknown_14h; // 0x00000000
        public ulong AnimationsPointer;
        public uint Unknown_20h; // 0x00000101
        public uint Unknown_24h; // 0x00000000
        public ulong ClipsPointer;
        public ushort ClipsMapCapacity;
        public ushort ClipsMapEntries;
        public uint Unknown_34h; // 0x01000000
        public uint Unknown_38h; // 0x00000000
        public uint Unknown_3Ch; // 0x00000000

        // reference data
        public AnimationMap Animations;
        public ResourcePointerArray64<ClipMapEntry_GTA5_pc> Clips;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.Unknown_10h = reader.ReadUInt32();
            this.Unknown_14h = reader.ReadUInt32();
            this.AnimationsPointer = reader.ReadUInt64();
            this.Unknown_20h = reader.ReadUInt32();
            this.Unknown_24h = reader.ReadUInt32();
            this.ClipsPointer = reader.ReadUInt64();
            this.ClipsMapCapacity = reader.ReadUInt16();
            this.ClipsMapEntries = reader.ReadUInt16();
            this.Unknown_34h = reader.ReadUInt32();
            this.Unknown_38h = reader.ReadUInt32();
            this.Unknown_3Ch = reader.ReadUInt32();

            // read reference data
            this.Animations = reader.ReadBlockAt<AnimationMap>(
                this.AnimationsPointer // offset
            );
            this.Clips = reader.ReadBlockAt<ResourcePointerArray64<ClipMapEntry_GTA5_pc>>(
                this.ClipsPointer, // offset
                this.ClipsMapCapacity
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.AnimationsPointer = (ulong)(this.Animations != null ? this.Animations.Position : 0);
            this.ClipsPointer = (ulong)(this.Clips != null ? this.Clips.Position : 0);
            //this.c1 = (ushort)(this.Clips != null ? this.Clips.Count : 0);

            // write structure data
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.Write(this.AnimationsPointer);
            writer.Write(this.Unknown_20h);
            writer.Write(this.Unknown_24h);
            writer.Write(this.ClipsPointer);
            writer.Write(this.ClipsMapCapacity);
            writer.Write(this.ClipsMapEntries);
            writer.Write(this.Unknown_34h);
            writer.Write(this.Unknown_38h);
            writer.Write(this.Unknown_3Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>(base.GetReferences());
            if (Animations != null) list.Add(Animations);
            if (Clips != null) list.Add(Clips);
            return list.ToArray();
        }
    }
}
