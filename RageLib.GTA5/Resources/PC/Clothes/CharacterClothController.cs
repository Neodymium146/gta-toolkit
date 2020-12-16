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
using System.Numerics;

namespace RageLib.Resources.GTA5.PC.Clothes
{
    // characterClothController
    public class CharacterClothController : ClothController
    {
        public override long BlockLength => 0xF0;

        // structure data      
        public SimpleList64<ushort> TriIndices;
        public SimpleList64<Vector4> OriginalPos;
        public float Unknown_A0h; // 0x3D23D70A
        public uint Unknown_A4h; // 0x00000000
        public uint Unknown_A8h; // 0x00000000
        public uint Unknown_ACh; // 0x00000000
        public SimpleList64<uint> BoneIndexMap;
        public ResourceSimpleList64<BindingInfo> BindingInfo;
        public uint Unknown_D0h; // 0x00000000
        public uint Unknown_D4h; // 0x00000000
        public uint Unknown_D8h; // 0x00000000
        public float Unknown_DCh; // 0x3F800000
        public SimpleList64<uint> BoneIDMap;
        
        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data         
            this.TriIndices = reader.ReadBlock<SimpleList64<ushort>>();
            this.OriginalPos = reader.ReadBlock<SimpleList64<Vector4>>();
            this.Unknown_A0h = reader.ReadSingle();
            this.Unknown_A4h = reader.ReadUInt32();
            this.Unknown_A8h = reader.ReadUInt32();
            this.Unknown_ACh = reader.ReadUInt32();
            this.BoneIndexMap = reader.ReadBlock<SimpleList64<uint>>();
            this.BindingInfo = reader.ReadBlock<ResourceSimpleList64<BindingInfo>>();
            this.Unknown_D0h = reader.ReadUInt32();
            this.Unknown_D4h = reader.ReadUInt32();
            this.Unknown_D8h = reader.ReadUInt32();
            this.Unknown_DCh = reader.ReadSingle();
            this.BoneIDMap = reader.ReadBlock<SimpleList64<uint>>();
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // write structure data           
            writer.WriteBlock(this.TriIndices);
            writer.WriteBlock(this.OriginalPos);
            writer.Write(this.Unknown_A0h);
            writer.Write(this.Unknown_A4h);
            writer.Write(this.Unknown_A8h);
            writer.Write(this.Unknown_ACh);
            writer.WriteBlock(this.BoneIndexMap);
            writer.WriteBlock(this.BindingInfo);
            writer.Write(this.Unknown_D0h);
            writer.Write(this.Unknown_D4h);
            writer.Write(this.Unknown_D8h);
            writer.Write(this.Unknown_DCh);
            writer.WriteBlock(this.BoneIDMap);
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(0x80, TriIndices),
                new Tuple<long, IResourceBlock>(0x90, OriginalPos),
                new Tuple<long, IResourceBlock>(0xB0, BoneIndexMap),
                new Tuple<long, IResourceBlock>(0xC0, BindingInfo),
                new Tuple<long, IResourceBlock>(0xE0, BoneIDMap)
            };
        }
    }
}
