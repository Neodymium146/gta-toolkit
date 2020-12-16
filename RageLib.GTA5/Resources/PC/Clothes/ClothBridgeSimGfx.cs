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

namespace RageLib.Resources.GTA5.PC.Clothes
{
    // pgBase
    // clothBridgeSimGfx
    public class ClothBridgeSimGfx : PgBase64
    {
        public override long BlockLength => 0x140;

        // structure data
        public uint Count;
        public uint Unknown_14h;
        public uint Unknown_18h;
        public uint Unknown_1Ch; // 0x00000000
        public SimpleList64<float> PinRadius0;
        public SimpleList64<float> PinRadius1;
        public SimpleList64<float> PinRadius2;
        public SimpleList64<float> PinRadius3;
        public SimpleList64<float> VertexWeight0;
        public SimpleList64<float> VertexWeight1;
        public SimpleList64<float> VertexWeight2;
        public SimpleList64<float> VertexWeight3;
        public SimpleList64<float> InflationScale0;
        public SimpleList64<float> InflationScale1;
        public SimpleList64<float> InflationScale2;
        public SimpleList64<float> InflationScale3;
        public SimpleList64<ushort> ClothDisplayMap0;
        public SimpleList64<ushort> ClothDisplayMap1;
        public SimpleList64<ushort> ClothDisplayMap2;
        public SimpleList64<ushort> ClothDisplayMap3;
        public ulong Unknown_120h; // 0x0000000000000000
        public SimpleList64<uint> Unknown_128h;
        public ulong Unknown_138h; // 0x0000000000000000

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.Count = reader.ReadUInt32();
            this.Unknown_14h = reader.ReadUInt32();
            this.Unknown_18h = reader.ReadUInt32();
            this.Unknown_1Ch = reader.ReadUInt32();
            this.PinRadius0 = reader.ReadBlock<SimpleList64<float>>();
            this.PinRadius1 = reader.ReadBlock<SimpleList64<float>>();
            this.PinRadius2 = reader.ReadBlock<SimpleList64<float>>();
            this.PinRadius3 = reader.ReadBlock<SimpleList64<float>>();
            this.VertexWeight0 = reader.ReadBlock<SimpleList64<float>>();
            this.VertexWeight1 = reader.ReadBlock<SimpleList64<float>>();
            this.VertexWeight2 = reader.ReadBlock<SimpleList64<float>>();
            this.VertexWeight3 = reader.ReadBlock<SimpleList64<float>>();
            this.InflationScale0 = reader.ReadBlock<SimpleList64<float>>();
            this.InflationScale1 = reader.ReadBlock<SimpleList64<float>>();
            this.InflationScale2 = reader.ReadBlock<SimpleList64<float>>();
            this.InflationScale3 = reader.ReadBlock<SimpleList64<float>>();
            this.ClothDisplayMap0 = reader.ReadBlock<SimpleList64<ushort>>();
            this.ClothDisplayMap1 = reader.ReadBlock<SimpleList64<ushort>>();
            this.ClothDisplayMap2 = reader.ReadBlock<SimpleList64<ushort>>();
            this.ClothDisplayMap3 = reader.ReadBlock<SimpleList64<ushort>>();
            this.Unknown_120h = reader.ReadUInt64();
            this.Unknown_128h = reader.ReadBlock<SimpleList64<uint>>();
            this.Unknown_138h = reader.ReadUInt64();
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // write structure data
            writer.Write(this.Count);
            writer.Write(this.Unknown_14h);
            writer.Write(this.Unknown_18h);
            writer.Write(this.Unknown_1Ch);
            writer.WriteBlock(this.PinRadius0);
            writer.WriteBlock(this.PinRadius1);
            writer.WriteBlock(this.PinRadius2);
            writer.WriteBlock(this.PinRadius3);
            writer.WriteBlock(this.VertexWeight0);
            writer.WriteBlock(this.VertexWeight1);
            writer.WriteBlock(this.VertexWeight2);
            writer.WriteBlock(this.VertexWeight3);
            writer.WriteBlock(this.InflationScale0);
            writer.WriteBlock(this.InflationScale1);
            writer.WriteBlock(this.InflationScale2);
            writer.WriteBlock(this.InflationScale3);
            writer.WriteBlock(this.ClothDisplayMap0);
            writer.WriteBlock(this.ClothDisplayMap1);
            writer.WriteBlock(this.ClothDisplayMap2);
            writer.WriteBlock(this.ClothDisplayMap3);
            writer.Write(this.Unknown_120h);
            writer.WriteBlock(this.Unknown_128h);
            writer.Write(this.Unknown_138h);
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(0x20, PinRadius0),
                new Tuple<long, IResourceBlock>(0x30, PinRadius1),
                new Tuple<long, IResourceBlock>(0x40, PinRadius2),
                new Tuple<long, IResourceBlock>(0x50, PinRadius3),
                new Tuple<long, IResourceBlock>(0x60, VertexWeight0),
                new Tuple<long, IResourceBlock>(0x70, VertexWeight1),
                new Tuple<long, IResourceBlock>(0x80, VertexWeight2),
                new Tuple<long, IResourceBlock>(0x90, VertexWeight3),
                new Tuple<long, IResourceBlock>(0xA0, InflationScale0),
                new Tuple<long, IResourceBlock>(0xB0, InflationScale1),
                new Tuple<long, IResourceBlock>(0xC0, InflationScale2),
                new Tuple<long, IResourceBlock>(0xD0, InflationScale3),
                new Tuple<long, IResourceBlock>(0xE0, ClothDisplayMap0),
                new Tuple<long, IResourceBlock>(0xF0, ClothDisplayMap1),
                new Tuple<long, IResourceBlock>(0x100, ClothDisplayMap2),
                new Tuple<long, IResourceBlock>(0x110, ClothDisplayMap3),
                new Tuple<long, IResourceBlock>(0x128, Unknown_128h)
            };
        }
    }
}
