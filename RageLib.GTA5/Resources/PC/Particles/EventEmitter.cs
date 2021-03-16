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
using System.Collections.Generic;
using System.Numerics;

namespace RageLib.Resources.GTA5.PC.Particles
{
    // ptxEvent
    // ptxEventEmitter
    public class EventEmitter : ResourceSystemBlock
    {
        public override long BlockLength => 0x70;

        // structure data
        public ulong VFT;
        public uint Index;
        public uint Unknown_Ch; // 0x00000000
        public uint Unknown_10h;
        public float Unknown_14h; // 0x00000000
        public ulong EvolutionParamsPointer;
        public ulong Unknown_20h; // 0x0000000000000000
        public ulong Unknown_28h; // 0x0000000000000000
        public ulong EmitterNamePointer;
        public ulong ParticleNamePointer;
        public ulong EmitterRulePointer;
        public ulong ParticleRulePointer;
        public float MoveSpeedScale;
        public float MoveSpeedScaleModifier;
        public float ParticleScale;
        public float ParticleScaleModifier;
        public uint Unknown_60h;
        public uint Unknown_64h;
        public ulong Unknown_68h; // 0x0000000000000000

        // reference data
        public EvolutionParameters EvolutionParams;
        public string_r EmitterName;
        public string_r ParticleName;
        public EmitterRule EmitterRule;
        public ParticleRule ParticleRule;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.VFT = reader.ReadUInt64();
            this.Index = reader.ReadUInt32();
            this.Unknown_Ch = reader.ReadUInt32();
            this.Unknown_10h = reader.ReadUInt32();
            this.Unknown_14h = reader.ReadSingle();
            this.EvolutionParamsPointer = reader.ReadUInt64();
            this.Unknown_20h = reader.ReadUInt64();
            this.Unknown_28h = reader.ReadUInt64();
            this.EmitterNamePointer = reader.ReadUInt64();
            this.ParticleNamePointer = reader.ReadUInt64();
            this.EmitterRulePointer = reader.ReadUInt64();
            this.ParticleRulePointer = reader.ReadUInt64();
            this.MoveSpeedScale = reader.ReadSingle();
            this.MoveSpeedScaleModifier = reader.ReadSingle();
            this.ParticleScale = reader.ReadSingle();
            this.ParticleScaleModifier = reader.ReadSingle();
            this.Unknown_60h = reader.ReadUInt32();
            this.Unknown_64h = reader.ReadUInt32();
            this.Unknown_68h = reader.ReadUInt64();

            // read reference data
            this.EvolutionParams = reader.ReadBlockAt<EvolutionParameters>(
                this.EvolutionParamsPointer // offset
            );
            this.EmitterName = reader.ReadBlockAt<string_r>(
                this.EmitterNamePointer // offset
            );
            this.ParticleName = reader.ReadBlockAt<string_r>(
                this.ParticleNamePointer // offset
            );
            this.EmitterRule = reader.ReadBlockAt<EmitterRule>(
                this.EmitterRulePointer // offset
            );
            this.ParticleRule = reader.ReadBlockAt<ParticleRule>(
                this.ParticleRulePointer // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.EvolutionParamsPointer = (ulong)(this.EvolutionParams != null ? this.EvolutionParams.BlockPosition : 0);
            this.EmitterNamePointer = (ulong)(this.EmitterName != null ? this.EmitterName.BlockPosition : 0);
            this.ParticleNamePointer = (ulong)(this.ParticleName != null ? this.ParticleName.BlockPosition : 0);
            this.EmitterRulePointer = (ulong)(this.EmitterRule != null ? this.EmitterRule.BlockPosition : 0);
            this.ParticleRulePointer = (ulong)(this.ParticleRule != null ? this.ParticleRule.BlockPosition : 0);

            // write structure data
            writer.Write(this.VFT);
            writer.Write(this.Index);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.Write(this.EvolutionParamsPointer);
            writer.Write(this.Unknown_20h);
            writer.Write(this.Unknown_28h);
            writer.Write(this.EmitterNamePointer);
            writer.Write(this.ParticleNamePointer);
            writer.Write(this.EmitterRulePointer);
            writer.Write(this.ParticleRulePointer);
            writer.Write(this.MoveSpeedScale);
            writer.Write(this.MoveSpeedScaleModifier);
            writer.Write(this.ParticleScale);
            writer.Write(this.ParticleScaleModifier);
            writer.Write(this.Unknown_60h);
            writer.Write(this.Unknown_64h);
            writer.Write(this.Unknown_68h);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (EvolutionParams != null) list.Add(EvolutionParams);
            if (EmitterName != null) list.Add(EmitterName);
            if (ParticleName != null) list.Add(ParticleName);
            if (EmitterRule != null) list.Add(EmitterRule);
            if (ParticleRule != null) list.Add(ParticleRule);
            return list.ToArray();
        }
    }
}
