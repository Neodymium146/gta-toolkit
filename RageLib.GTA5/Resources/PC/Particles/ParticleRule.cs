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
    // ptxParticleRule
    public class ParticleRule : PgBase64
    {
        public override long BlockLength => 0x240;

        // structure data
        public uint Unknown_10h;
        public uint Unknown_14h; // 0x00000000
        public ulong Unknown_18h; // 0x0000000000000000
        public EffectSpawner emb1;
        public EffectSpawner emb2;
        public uint Unknown_100h;
        public uint Unknown_104h;
        public uint Unknown_108h;
        public uint Unknown_10Ch;
        public uint Unknown_110h; // 0x00000000
        public float Unknown_114h;
        public uint Unknown_118h;
        public uint Unknown_11Ch;
        public ulong NamePointer;
        public ResourcePointerList64<Behaviour> Unknown_128h;
        public ResourcePointerList64<Behaviour> Unknown_138h;
        public ResourcePointerList64<Behaviour> Unknown_148h;
        public ResourcePointerList64<Behaviour> Unknown_158h;
        public ResourcePointerList64<Behaviour> Unknown_168h;
        public ulong Unknown_178h; // 0x0000000000000000
        public ulong Unknown_180h; // 0x0000000000000000
        public ResourceSimpleList64<Unknown_P_013> Unknown_188h;
        public ulong Unknown_198h; // 0x0000000000000000
        public ulong Unknown_1A0h; // 0x0000000000000000
        public ulong Unknown_1A8h; // 0x0000000000000000
        public ulong VFTx3;
        public ulong ShaderNamePointer;
        public ulong ShaderTechniqueNamePointer;
        public ulong Unknown_1C8h; // 0x0000000000000000
        public uint Unknown_1D0h;
        public uint Unknown_1D4h; // 0x00000000
        public ulong VFTx4;
        public uint Unknown_1E0h;
        public uint Unknown_1E4h;
        public uint Unknown_1E8h;
        public uint Unknown_1ECh;
        public ResourcePointerList64<ShaderVar> ShaderVars;
        public uint Unknown_200h; // 0x00000001
        public uint Unknown_204h; // 0x00000000
        public uint ShaderNameHash;
        public uint Unknown_20Ch; // 0x00000000
        public ResourceSimpleList64<Unknown_P_012> Unknown_210h;
        public uint Unknown_220h;
        public uint Unknown_224h; // 0x00000000
        public ulong Unknown_228h; // 0x0000000000000000
        public ulong Unknown_230h; // 0x0000000000000000
        public ulong Unknown_238h; // 0x0000000000000000

        // reference data
        public string_r Name;
        public string_r ShaderName;
        public string_r ShaderTechniqueName;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.Unknown_10h = reader.ReadUInt32();
            this.Unknown_14h = reader.ReadUInt32();
            this.Unknown_18h = reader.ReadUInt64();
            this.emb1 = reader.ReadBlock<EffectSpawner>();
            this.emb2 = reader.ReadBlock<EffectSpawner>();
            this.Unknown_100h = reader.ReadUInt32();
            this.Unknown_104h = reader.ReadUInt32();
            this.Unknown_108h = reader.ReadUInt32();
            this.Unknown_10Ch = reader.ReadUInt32();
            this.Unknown_110h = reader.ReadUInt32();
            this.Unknown_114h = reader.ReadSingle();
            this.Unknown_118h = reader.ReadUInt32();
            this.Unknown_11Ch = reader.ReadUInt32();
            this.NamePointer = reader.ReadUInt64();
            this.Unknown_128h = reader.ReadBlock<ResourcePointerList64<Behaviour>>();
            this.Unknown_138h = reader.ReadBlock<ResourcePointerList64<Behaviour>>();
            this.Unknown_148h = reader.ReadBlock<ResourcePointerList64<Behaviour>>();
            this.Unknown_158h = reader.ReadBlock<ResourcePointerList64<Behaviour>>();
            this.Unknown_168h = reader.ReadBlock<ResourcePointerList64<Behaviour>>();
            this.Unknown_178h = reader.ReadUInt64();
            this.Unknown_180h = reader.ReadUInt64();
            this.Unknown_188h = reader.ReadBlock<ResourceSimpleList64<Unknown_P_013>>();
            this.Unknown_198h = reader.ReadUInt64();
            this.Unknown_1A0h = reader.ReadUInt64();
            this.Unknown_1A8h = reader.ReadUInt64();
            this.VFTx3 = reader.ReadUInt64();
            this.ShaderNamePointer = reader.ReadUInt64();
            this.ShaderTechniqueNamePointer = reader.ReadUInt64();
            this.Unknown_1C8h = reader.ReadUInt64();
            this.Unknown_1D0h = reader.ReadUInt32();
            this.Unknown_1D4h = reader.ReadUInt32();
            this.VFTx4 = reader.ReadUInt64();
            this.Unknown_1E0h = reader.ReadUInt32();
            this.Unknown_1E4h = reader.ReadUInt32();
            this.Unknown_1E8h = reader.ReadUInt32();
            this.Unknown_1ECh = reader.ReadUInt32();
            this.ShaderVars = reader.ReadBlock<ResourcePointerList64<ShaderVar>>();
            this.Unknown_200h = reader.ReadUInt32();
            this.Unknown_204h = reader.ReadUInt32();
            this.ShaderNameHash = reader.ReadUInt32();
            this.Unknown_20Ch = reader.ReadUInt32();
            this.Unknown_210h = reader.ReadBlock<ResourceSimpleList64<Unknown_P_012>>();
            this.Unknown_220h = reader.ReadUInt32();
            this.Unknown_224h = reader.ReadUInt32();
            this.Unknown_228h = reader.ReadUInt64();
            this.Unknown_230h = reader.ReadUInt64();
            this.Unknown_238h = reader.ReadUInt64();

            // read reference data
            this.Name = reader.ReadBlockAt<string_r>(
                this.NamePointer // offset
            );
            this.ShaderName = reader.ReadBlockAt<string_r>(
                this.ShaderNamePointer // offset
            );
            this.ShaderTechniqueName = reader.ReadBlockAt<string_r>(
                this.ShaderTechniqueNamePointer // offset
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
            this.ShaderNamePointer = (ulong)(this.ShaderName != null ? this.ShaderName.BlockPosition : 0);
            this.ShaderTechniqueNamePointer = (ulong)(this.ShaderTechniqueName != null ? this.ShaderTechniqueName.BlockPosition : 0);

            // write structure data
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.Write(this.Unknown_18h);
            writer.WriteBlock(this.emb1);
            writer.WriteBlock(this.emb2);
            writer.Write(this.Unknown_100h);
            writer.Write(this.Unknown_104h);
            writer.Write(this.Unknown_108h);
            writer.Write(this.Unknown_10Ch);
            writer.Write(this.Unknown_110h);
            writer.Write(this.Unknown_114h);
            writer.Write(this.Unknown_118h);
            writer.Write(this.Unknown_11Ch);
            writer.Write(this.NamePointer);
            writer.WriteBlock(this.Unknown_128h);
            writer.WriteBlock(this.Unknown_138h);
            writer.WriteBlock(this.Unknown_148h);
            writer.WriteBlock(this.Unknown_158h);
            writer.WriteBlock(this.Unknown_168h);
            writer.Write(this.Unknown_178h);
            writer.Write(this.Unknown_180h);
            writer.WriteBlock(this.Unknown_188h);
            writer.Write(this.Unknown_198h);
            writer.Write(this.Unknown_1A0h);
            writer.Write(this.Unknown_1A8h);
            writer.Write(this.VFTx3);
            writer.Write(this.ShaderNamePointer);
            writer.Write(this.ShaderTechniqueNamePointer);
            writer.Write(this.Unknown_1C8h);
            writer.Write(this.Unknown_1D0h);
            writer.Write(this.Unknown_1D4h);
            writer.Write(this.VFTx4);
            writer.Write(this.Unknown_1E0h);
            writer.Write(this.Unknown_1E4h);
            writer.Write(this.Unknown_1E8h);
            writer.Write(this.Unknown_1ECh);
            writer.WriteBlock(this.ShaderVars);
            writer.Write(this.Unknown_200h);
            writer.Write(this.Unknown_204h);
            writer.Write(this.ShaderNameHash);
            writer.Write(this.Unknown_20Ch);
            writer.WriteBlock(this.Unknown_210h);
            writer.Write(this.Unknown_220h);
            writer.Write(this.Unknown_224h);
            writer.Write(this.Unknown_228h);
            writer.Write(this.Unknown_230h);
            writer.Write(this.Unknown_238h);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>(base.GetReferences());
            if (Name != null) list.Add(Name);
            if (ShaderName != null) list.Add(ShaderName);
            if (ShaderTechniqueName != null) list.Add(ShaderTechniqueName);
            return list.ToArray();
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(88, emb1),
                new Tuple<long, IResourceBlock>(96, emb2),
                new Tuple<long, IResourceBlock>(0x128, Unknown_128h),
                new Tuple<long, IResourceBlock>(0x138, Unknown_138h),
                new Tuple<long, IResourceBlock>(0x148, Unknown_148h),
                new Tuple<long, IResourceBlock>(0x158, Unknown_158h),
                new Tuple<long, IResourceBlock>(0x168, Unknown_168h),
                new Tuple<long, IResourceBlock>(0x188, Unknown_188h),
                new Tuple<long, IResourceBlock>(0x1F0, ShaderVars),
                new Tuple<long, IResourceBlock>(0x210, Unknown_210h)
            };
        }
    }
}
