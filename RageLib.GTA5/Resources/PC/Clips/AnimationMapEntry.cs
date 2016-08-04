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

using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Clips
{
    public class AnimationMapEntry : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 32; }
        }

        // structure data
        public uint Unknown_0h;
        public uint Unknown_4h; // 0x00000000
        public ulong p1;
        public ulong p2;
        public uint Unknown_18h; // 0x00000000
        public uint Unknown_1Ch; // 0x00000000

        // reference data
        public Animation Animation;
        public AnimationMapEntry NextEntry;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.Unknown_0h = reader.ReadUInt32();
            this.Unknown_4h = reader.ReadUInt32();
            this.p1 = reader.ReadUInt64();
            this.p2 = reader.ReadUInt64();
            this.Unknown_18h = reader.ReadUInt32();
            this.Unknown_1Ch = reader.ReadUInt32();

            // read reference data
            this.Animation = reader.ReadBlockAt<Animation>(
                this.p1 // offset
            );
            this.NextEntry = reader.ReadBlockAt<AnimationMapEntry>(
                this.p2 // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.p1 = (ulong)(this.Animation != null ? this.Animation.Position : 0);
            this.p2 = (ulong)(this.NextEntry != null ? this.NextEntry.Position : 0);

            // write structure data
            writer.Write(this.Unknown_0h);
            writer.Write(this.Unknown_4h);
            writer.Write(this.p1);
            writer.Write(this.p2);
            writer.Write(this.Unknown_18h);
            writer.Write(this.Unknown_1Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (Animation != null) list.Add(Animation);
            if (NextEntry != null) list.Add(NextEntry);
            return list.ToArray();
        }
    }
}
