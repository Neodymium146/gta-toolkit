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

namespace RageLib.Resources.GTA5.PC.Particles
{
    // ptxu_Noise
    public class BehaviourNoise : Behaviour
    {
        public override long Length => 0x280;

        // structure data
        public ResourcePointerList64<KeyframeProp> KeyframeProps;
        public uint Unknown_20h; // 0x00000000
        public uint Unknown_24h; // 0x00000000
        public uint Unknown_28h; // 0x00000000
        public uint Unknown_2Ch; // 0x00000000
        public KeyframeProp KeyframeProp0;
        public KeyframeProp KeyframeProp1;
        public KeyframeProp KeyframeProp2;
        public KeyframeProp KeyframeProp3;
        public uint Unknown_270h; // 0x00000000
        public uint Unknown_274h;
        public uint Unknown_278h; // 0x00000000
        public uint Unknown_27Ch; // 0x00000000

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.KeyframeProps = reader.ReadBlock<ResourcePointerList64<KeyframeProp>>();
            this.Unknown_20h = reader.ReadUInt32();
            this.Unknown_24h = reader.ReadUInt32();
            this.Unknown_28h = reader.ReadUInt32();
            this.Unknown_2Ch = reader.ReadUInt32();
            this.KeyframeProp0 = reader.ReadBlock<KeyframeProp>();
            this.KeyframeProp1 = reader.ReadBlock<KeyframeProp>();
            this.KeyframeProp2 = reader.ReadBlock<KeyframeProp>();
            this.KeyframeProp3 = reader.ReadBlock<KeyframeProp>();
            this.Unknown_270h = reader.ReadUInt32();
            this.Unknown_274h = reader.ReadUInt32();
            this.Unknown_278h = reader.ReadUInt32();
            this.Unknown_27Ch = reader.ReadUInt32();

        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // write structure data
            writer.WriteBlock(this.KeyframeProps);
            writer.Write(this.Unknown_20h);
            writer.Write(this.Unknown_24h);
            writer.Write(this.Unknown_28h);
            writer.Write(this.Unknown_2Ch);
            writer.WriteBlock(this.KeyframeProp0);
            writer.WriteBlock(this.KeyframeProp1);
            writer.WriteBlock(this.KeyframeProp2);
            writer.WriteBlock(this.KeyframeProp3);
            writer.Write(this.Unknown_270h);
            writer.Write(this.Unknown_274h);
            writer.Write(this.Unknown_278h);
            writer.Write(this.Unknown_27Ch);
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(16, KeyframeProps),
                new Tuple<long, IResourceBlock>(48, KeyframeProp0),
                new Tuple<long, IResourceBlock>(192, KeyframeProp1),
                new Tuple<long, IResourceBlock>(336, KeyframeProp2),
                new Tuple<long, IResourceBlock>(480, KeyframeProp3)
            };
        }
    }
}
