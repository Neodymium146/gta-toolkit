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
using RageLib.Resources.GTA5.PC.Drawables;
using RageLib.Resources.GTA5.PC.Textures;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Particles
{
    // pgBase
    // ptxFxList
    public class ParticleEffectsList : FileBase64_GTA5_pc
    {
        public override long Length => 0x60;

        // structure data
        public ulong NamePointer;
        public uint Unknown_18h; // 0x00000000
        public uint Unknown_1Ch; // 0x00000000
        public ulong TextureDictionaryPointer;
        public uint Unknown_28h; // 0x00000000
        public uint Unknown_2Ch; // 0x00000000
        public ulong DrawableDictionaryPointer;
        public ulong ParticleRuleDictionaryPointer;
        public uint Unknown_40h; // 0x00000000
        public uint Unknown_44h; // 0x00000000
        public ulong EmitterRuleDictionaryPointer;
        public ulong EffectRuleDictionaryPointer;
        public uint Unknown_58h; // 0x00000000
        public uint Unknown_5Ch; // 0x00000000

        // reference data
        public string_r Name;
        public TextureDictionary TextureDictionary;
        public DrawableDictionary DrawableDictionary;
        public ParticleRuleDictionary ParticleRuleDictionary;
        public EffectRuleDictionary EffectRuleDictionary;
        public EmitterRuleDictionary EmitterRuleDictionary;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.NamePointer = reader.ReadUInt64();
            this.Unknown_18h = reader.ReadUInt32();
            this.Unknown_1Ch = reader.ReadUInt32();
            this.TextureDictionaryPointer = reader.ReadUInt64();
            this.Unknown_28h = reader.ReadUInt32();
            this.Unknown_2Ch = reader.ReadUInt32();
            this.DrawableDictionaryPointer = reader.ReadUInt64();
            this.ParticleRuleDictionaryPointer = reader.ReadUInt64();
            this.Unknown_40h = reader.ReadUInt32();
            this.Unknown_44h = reader.ReadUInt32();
            this.EmitterRuleDictionaryPointer = reader.ReadUInt64();
            this.EffectRuleDictionaryPointer = reader.ReadUInt64();
            this.Unknown_58h = reader.ReadUInt32();
            this.Unknown_5Ch = reader.ReadUInt32();

            // read reference data
            this.Name = reader.ReadBlockAt<string_r>(
                this.NamePointer // offset
            );
            this.TextureDictionary = reader.ReadBlockAt<TextureDictionary>(
                this.TextureDictionaryPointer // offset
            );
            this.DrawableDictionary = reader.ReadBlockAt<DrawableDictionary>(
                this.DrawableDictionaryPointer // offset
            );
            this.ParticleRuleDictionary = reader.ReadBlockAt<ParticleRuleDictionary>(
                this.ParticleRuleDictionaryPointer // offset
            );
            this.EffectRuleDictionary = reader.ReadBlockAt<EffectRuleDictionary>(
                this.EmitterRuleDictionaryPointer // offset
            );
            this.EmitterRuleDictionary = reader.ReadBlockAt<EmitterRuleDictionary>(
                this.EffectRuleDictionaryPointer // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.NamePointer = (ulong)(this.Name != null ? this.Name.Position : 0);
            this.TextureDictionaryPointer = (ulong)(this.TextureDictionary != null ? this.TextureDictionary.Position : 0);
            this.DrawableDictionaryPointer = (ulong)(this.DrawableDictionary != null ? this.DrawableDictionary.Position : 0);
            this.ParticleRuleDictionaryPointer = (ulong)(this.ParticleRuleDictionary != null ? this.ParticleRuleDictionary.Position : 0);
            this.EmitterRuleDictionaryPointer = (ulong)(this.EffectRuleDictionary != null ? this.EffectRuleDictionary.Position : 0);
            this.EffectRuleDictionaryPointer = (ulong)(this.EmitterRuleDictionary != null ? this.EmitterRuleDictionary.Position : 0);

            // write structure data
            writer.Write(this.NamePointer);
            writer.Write(this.Unknown_18h);
            writer.Write(this.Unknown_1Ch);
            writer.Write(this.TextureDictionaryPointer);
            writer.Write(this.Unknown_28h);
            writer.Write(this.Unknown_2Ch);
            writer.Write(this.DrawableDictionaryPointer);
            writer.Write(this.ParticleRuleDictionaryPointer);
            writer.Write(this.Unknown_40h);
            writer.Write(this.Unknown_44h);
            writer.Write(this.EmitterRuleDictionaryPointer);
            writer.Write(this.EffectRuleDictionaryPointer);
            writer.Write(this.Unknown_58h);
            writer.Write(this.Unknown_5Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>(base.GetReferences());
            if (Name != null) list.Add(Name);
            if (TextureDictionary != null) list.Add(TextureDictionary);
            if (DrawableDictionary != null) list.Add(DrawableDictionary);
            if (ParticleRuleDictionary != null) list.Add(ParticleRuleDictionary);
            if (EffectRuleDictionary != null) list.Add(EffectRuleDictionary);
            if (EmitterRuleDictionary != null) list.Add(EmitterRuleDictionary);
            return list.ToArray();
        }
    }
}
