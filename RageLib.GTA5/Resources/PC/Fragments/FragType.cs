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
using System.Collections.Generic;
using System;
using RageLib.Resources.GTA5.PC.Clothes;

namespace RageLib.Resources.GTA5.PC.Fragments
{
    // fragType
    // gtaFragType
    public class FragType : FileBase64_GTA5_pc
    {
        public override long Length => 0x130;

        // structure data
        public uint Unknown_10h; // 0x00000000
        public uint Unknown_14h; // 0x00000000
        public uint Unknown_18h; // 0x00000000
        public uint Unknown_1Ch; // 0x00000000
        public uint Unknown_20h;
        public uint Unknown_24h;
        public uint Unknown_28h;
        public uint Unknown_2Ch;
        public ulong DrawablePointer;
        public ulong Unknown_28h_Pointer;
        public ulong Unknown_30h_Pointer;
        public uint Count0;
        public uint Unknown_4Ch;
        public uint Unknown_50h; // 0x00000000
        public uint Unknown_54h; // 0x00000000
        public ulong NamePointer;
        public ResourcePointerList64<EnvironmentCloth> Clothes;
        public uint Unknown_70h; // 0x00000000
        public uint Unknown_74h; // 0x00000000
        public uint Unknown_78h; // 0x00000000
        public uint Unknown_7Ch; // 0x00000000
        public uint Unknown_80h; // 0x00000000
        public uint Unknown_84h; // 0x00000000
        public uint Unknown_88h; // 0x00000000
        public uint Unknown_8Ch; // 0x00000000
        public uint Unknown_90h; // 0x00000000
        public uint Unknown_94h; // 0x00000000
        public uint Unknown_98h; // 0x00000000
        public uint Unknown_9Ch; // 0x00000000
        public uint Unknown_A0h; // 0x00000000
        public uint Unknown_A4h; // 0x00000000
        public ulong Unknown_A8h_Pointer;
        public uint Unknown_B0h;
        public uint Unknown_B4h; // 0x00000000
        public uint Unknown_B8h;
        public uint Unknown_BCh;
        public uint Unknown_C0h;
        public uint Unknown_C4h;
        public uint Unknown_C8h; // 0xFFFFFFFF
        public uint Unknown_CCh;
        public uint Unknown_D0h;
        public uint Unknown_D4h;
        public byte Unknown_D8h;
        public byte Count3;
        public ushort Unknown_DAh;
        public uint Unknown_DCh; // 0x00000000
        public ulong Unknown_E0h_Pointer;
        public uint Unknown_E8h; // 0x00000000
        public uint Unknown_ECh; // 0x00000000
        public ulong PhysicsLODGroupPointer;
        public ulong Unknown_F8h_Pointer;
        public uint Unknown_100h; // 0x00000000
        public uint Unknown_104h; // 0x00000000
        public uint Unknown_108h; // 0x00000000
        public uint Unknown_10Ch; // 0x00000000
        public ResourceSimpleList64<LightAttributes> LightAttributes;
        public ulong Unknown_120h_Pointer;
        public uint Unknown_128h; // 0x00000000
        public uint Unknown_12Ch; // 0x00000000

        // reference data
        public FragDrawable Drawable;
        public ResourcePointerArray64<FragDrawable> Unknown_28h_Data;
        public ResourcePointerArray64<string_r> Unknown_30h_Data;
        public string_r Name;
        public Unknown_F_003 Unknown_A8h_Data;
        public ResourcePointerArray64<Unknown_F_004> Unknown_E0h_Data;
        public FragPhysicsLODGroup PhysicsLODGroup;
        public FragDrawable Unknown_F8h_Data;
        public Unknown_F_002 Unknown_120h_Data;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.Unknown_10h = reader.ReadUInt32();
            this.Unknown_14h = reader.ReadUInt32();
            this.Unknown_18h = reader.ReadUInt32();
            this.Unknown_1Ch = reader.ReadUInt32();
            this.Unknown_20h = reader.ReadUInt32();
            this.Unknown_24h = reader.ReadUInt32();
            this.Unknown_28h = reader.ReadUInt32();
            this.Unknown_2Ch = reader.ReadUInt32();
            this.DrawablePointer = reader.ReadUInt64();
            this.Unknown_28h_Pointer = reader.ReadUInt64();
            this.Unknown_30h_Pointer = reader.ReadUInt64();
            this.Count0 = reader.ReadUInt32();
            this.Unknown_4Ch = reader.ReadUInt32();
            this.Unknown_50h = reader.ReadUInt32();
            this.Unknown_54h = reader.ReadUInt32();
            this.NamePointer = reader.ReadUInt64();
            this.Clothes = reader.ReadBlock<ResourcePointerList64<EnvironmentCloth>>();
            this.Unknown_70h = reader.ReadUInt32();
            this.Unknown_74h = reader.ReadUInt32();
            this.Unknown_78h = reader.ReadUInt32();
            this.Unknown_7Ch = reader.ReadUInt32();
            this.Unknown_80h = reader.ReadUInt32();
            this.Unknown_84h = reader.ReadUInt32();
            this.Unknown_88h = reader.ReadUInt32();
            this.Unknown_8Ch = reader.ReadUInt32();
            this.Unknown_90h = reader.ReadUInt32();
            this.Unknown_94h = reader.ReadUInt32();
            this.Unknown_98h = reader.ReadUInt32();
            this.Unknown_9Ch = reader.ReadUInt32();
            this.Unknown_A0h = reader.ReadUInt32();
            this.Unknown_A4h = reader.ReadUInt32();
            this.Unknown_A8h_Pointer = reader.ReadUInt64();
            this.Unknown_B0h = reader.ReadUInt32();
            this.Unknown_B4h = reader.ReadUInt32();
            this.Unknown_B8h = reader.ReadUInt32();
            this.Unknown_BCh = reader.ReadUInt32();
            this.Unknown_C0h = reader.ReadUInt32();
            this.Unknown_C4h = reader.ReadUInt32();
            this.Unknown_C8h = reader.ReadUInt32();
            this.Unknown_CCh = reader.ReadUInt32();
            this.Unknown_D0h = reader.ReadUInt32();
            this.Unknown_D4h = reader.ReadUInt32();
            this.Unknown_D8h = reader.ReadByte();
            this.Count3 = reader.ReadByte();
            this.Unknown_DAh = reader.ReadUInt16();
            this.Unknown_DCh = reader.ReadUInt32();
            this.Unknown_E0h_Pointer = reader.ReadUInt64();
            this.Unknown_E8h = reader.ReadUInt32();
            this.Unknown_ECh = reader.ReadUInt32();
            this.PhysicsLODGroupPointer = reader.ReadUInt64();
            this.Unknown_F8h_Pointer = reader.ReadUInt64();
            this.Unknown_100h = reader.ReadUInt32();
            this.Unknown_104h = reader.ReadUInt32();
            this.Unknown_108h = reader.ReadUInt32();
            this.Unknown_10Ch = reader.ReadUInt32();
            this.LightAttributes = reader.ReadBlock<ResourceSimpleList64<LightAttributes>>();
            this.Unknown_120h_Pointer = reader.ReadUInt64();
            this.Unknown_128h = reader.ReadUInt32();
            this.Unknown_12Ch = reader.ReadUInt32();

            // read reference data
            this.Drawable = reader.ReadBlockAt<FragDrawable>(
                this.DrawablePointer // offset
            );
            this.Unknown_28h_Data = reader.ReadBlockAt<ResourcePointerArray64<FragDrawable>>(
                this.Unknown_28h_Pointer, // offset
                this.Count0
            );
            this.Unknown_30h_Data = reader.ReadBlockAt<ResourcePointerArray64<string_r>>(
                this.Unknown_30h_Pointer, // offset
                this.Count0
            );
            this.Name = reader.ReadBlockAt<string_r>(
                this.NamePointer // offset
            );
            this.Unknown_A8h_Data = reader.ReadBlockAt<Unknown_F_003>(
                this.Unknown_A8h_Pointer // offset
            );
            this.Unknown_E0h_Data = reader.ReadBlockAt<ResourcePointerArray64<Unknown_F_004>>(
                this.Unknown_E0h_Pointer, // offset
                this.Count3
            );
            this.PhysicsLODGroup = reader.ReadBlockAt<FragPhysicsLODGroup>(
                this.PhysicsLODGroupPointer // offset
            );
            this.Unknown_F8h_Data = reader.ReadBlockAt<FragDrawable>(
                this.Unknown_F8h_Pointer // offset
            );
            this.Unknown_120h_Data = reader.ReadBlockAt<Unknown_F_002>(
                this.Unknown_120h_Pointer // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.DrawablePointer = (ulong)(this.Drawable != null ? this.Drawable.Position : 0);
            this.Unknown_28h_Pointer = (ulong)(this.Unknown_28h_Data != null ? this.Unknown_28h_Data.Position : 0);
            this.Unknown_30h_Pointer = (ulong)(this.Unknown_30h_Data != null ? this.Unknown_30h_Data.Position : 0);
            //this.cc00 = (uint)(this.pxxxxx_0data != null ? this.pxxxxx_0data.Count : 0);
            this.NamePointer = (ulong)(this.Name != null ? this.Name.Position : 0);
            //this.cnt1 = (ushort)(this.pxxxxx_2data != null ? this.pxxxxx_2data.Count : 0);
            this.Unknown_A8h_Pointer = (ulong)(this.Unknown_A8h_Data != null ? this.Unknown_A8h_Data.Position : 0);
            //this.anotherCount = (byte)(this.pxxxxx_3data != null ? this.pxxxxx_3data.Count : 0);
            this.Unknown_E0h_Pointer = (ulong)(this.Unknown_E0h_Data != null ? this.Unknown_E0h_Data.Position : 0);
            this.PhysicsLODGroupPointer = (ulong)(this.PhysicsLODGroup != null ? this.PhysicsLODGroup.Position : 0);
            this.Unknown_F8h_Pointer = (ulong)(this.Unknown_F8h_Data != null ? this.Unknown_F8h_Data.Position : 0);
            //this.cntxx51a = (ushort)(this.pxxxxx_5data != null ? this.pxxxxx_5data.Count : 0);
            this.Unknown_120h_Pointer = (ulong)(this.Unknown_120h_Data != null ? this.Unknown_120h_Data.Position : 0);

            // write structure data
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.Write(this.Unknown_18h);
            writer.Write(this.Unknown_1Ch);
            writer.Write(this.Unknown_20h);
            writer.Write(this.Unknown_24h);
            writer.Write(this.Unknown_28h);
            writer.Write(this.Unknown_2Ch);
            writer.Write(this.DrawablePointer);
            writer.Write(this.Unknown_28h_Pointer);
            writer.Write(this.Unknown_30h_Pointer);
            writer.Write(this.Count0);
            writer.Write(this.Unknown_4Ch);
            writer.Write(this.Unknown_50h);
            writer.Write(this.Unknown_54h);
            writer.Write(this.NamePointer);
            writer.WriteBlock(this.Clothes);
            writer.Write(this.Unknown_70h);
            writer.Write(this.Unknown_74h);
            writer.Write(this.Unknown_78h);
            writer.Write(this.Unknown_7Ch);
            writer.Write(this.Unknown_80h);
            writer.Write(this.Unknown_84h);
            writer.Write(this.Unknown_88h);
            writer.Write(this.Unknown_8Ch);
            writer.Write(this.Unknown_90h);
            writer.Write(this.Unknown_94h);
            writer.Write(this.Unknown_98h);
            writer.Write(this.Unknown_9Ch);
            writer.Write(this.Unknown_A0h);
            writer.Write(this.Unknown_A4h);
            writer.Write(this.Unknown_A8h_Pointer);
            writer.Write(this.Unknown_B0h);
            writer.Write(this.Unknown_B4h);
            writer.Write(this.Unknown_B8h);
            writer.Write(this.Unknown_BCh);
            writer.Write(this.Unknown_C0h);
            writer.Write(this.Unknown_C4h);
            writer.Write(this.Unknown_C8h);
            writer.Write(this.Unknown_CCh);
            writer.Write(this.Unknown_D0h);
            writer.Write(this.Unknown_D4h);
            writer.Write(this.Unknown_D8h);
            writer.Write(this.Count3);
            writer.Write(this.Unknown_DAh);
            writer.Write(this.Unknown_DCh);
            writer.Write(this.Unknown_E0h_Pointer);
            writer.Write(this.Unknown_E8h);
            writer.Write(this.Unknown_ECh);
            writer.Write(this.PhysicsLODGroupPointer);
            writer.Write(this.Unknown_F8h_Pointer);
            writer.Write(this.Unknown_100h);
            writer.Write(this.Unknown_104h);
            writer.Write(this.Unknown_108h);
            writer.Write(this.Unknown_10Ch);
            writer.WriteBlock(this.LightAttributes);
            writer.Write(this.Unknown_120h_Pointer);
            writer.Write(this.Unknown_128h);
            writer.Write(this.Unknown_12Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>(base.GetReferences());
            if (Drawable != null) list.Add(Drawable);
            if (Unknown_28h_Data != null) list.Add(Unknown_28h_Data);
            if (Unknown_30h_Data != null) list.Add(Unknown_30h_Data);
            if (Name != null) list.Add(Name);
            if (Unknown_A8h_Data != null) list.Add(Unknown_A8h_Data);
            if (Unknown_E0h_Data != null) list.Add(Unknown_E0h_Data);
            if (PhysicsLODGroup != null) list.Add(PhysicsLODGroup);
            if (Unknown_F8h_Data != null) list.Add(Unknown_F8h_Data);
            if (Unknown_120h_Data != null) list.Add(Unknown_120h_Data);
            return list.ToArray();
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(0x60, Clothes),
                new Tuple<long, IResourceBlock>(0x110, LightAttributes)
            };
        }
    }
}
