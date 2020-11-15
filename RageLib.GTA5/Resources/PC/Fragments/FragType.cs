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
using System.Numerics;

namespace RageLib.Resources.GTA5.PC.Fragments
{
    // fragType
    // gtaFragType
    public class FragType : PgBase64
    {
        public override long BlockLength => 0x130;

        // structure data
        public ulong Unknown_10h; // 0x0000000000000000
        public ulong Unknown_18h; // 0x0000000000000000
        public Vector3 BoundingSphereCenter;
        public float BoundingSphereRadius;
        public ulong DrawablePointer;
        public ulong Unknown_28h_Pointer;
        public ulong Unknown_30h_Pointer;
        public uint Count0;
        public uint Unknown_4Ch;
        public ulong Unknown_50h; // 0x0000000000000000
        public ulong NamePointer;
        public ResourcePointerList64<EnvironmentCloth> Clothes;
        public ulong Unknown_70h; // 0x0000000000000000
        public ulong Unknown_78h; // 0x0000000000000000
        public ulong Unknown_80h; // 0x0000000000000000
        public ulong Unknown_88h; // 0x0000000000000000
        public ulong Unknown_90h; // 0x0000000000000000
        public ulong Unknown_98h; // 0x0000000000000000
        public ulong Unknown_A0h; // 0x0000000000000000
        public ulong MatrixSetPointer;
        public uint Unknown_B0h;
        public uint Unknown_B4h; // 0x00000000
        public uint Unknown_B8h;
        public uint Unknown_BCh;
        public uint Unknown_C0h;
        public uint Unknown_C4h;
        public uint Unknown_C8h; // 0xFFFFFFFF
        public uint Unknown_CCh;
        public float Unknown_D0h;
        public float Unknown_D4h;
        public byte Unknown_D8h;
        public byte Count3;
        public ushort Unknown_DAh;
        public uint Unknown_DCh; // 0x00000000
        public ulong Unknown_E0h_Pointer;
        public ulong Unknown_E8h; // 0x0000000000000000
        public ulong PhysicsLODGroupPointer;
        public ulong ClothDrawablePointer;
        public ulong Unknown_100h; // 0x0000000000000000
        public ulong Unknown_108h; // 0x0000000000000000
        public ResourceSimpleList64<LightAttributes> LightAttributes;
        public ulong VehicleGlassWindowDataPointer;
        public ulong Unknown_128h; // 0x0000000000000000

        // reference data
        public FragDrawable Drawable;
        public ResourcePointerArray64<FragDrawable> Unknown_28h_Data;
        public ResourcePointerArray64<string_r> Unknown_30h_Data;
        public string_r Name;
        public MatrixSet MatrixSet;
        public ResourcePointerArray64<Unknown_F_004> Unknown_E0h_Data;
        public FragPhysicsLODGroup PhysicsLODGroup;
        public FragDrawable ClothDrawable;
        public VehicleGlassWindowData VehicleGlassWindowData;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.Unknown_10h = reader.ReadUInt64();
            this.Unknown_18h = reader.ReadUInt64();
            this.BoundingSphereCenter = reader.ReadVector3();
            this.BoundingSphereRadius = reader.ReadSingle();
            this.DrawablePointer = reader.ReadUInt64();
            this.Unknown_28h_Pointer = reader.ReadUInt64();
            this.Unknown_30h_Pointer = reader.ReadUInt64();
            this.Count0 = reader.ReadUInt32();
            this.Unknown_4Ch = reader.ReadUInt32();
            this.Unknown_50h = reader.ReadUInt64();
            this.NamePointer = reader.ReadUInt64();
            this.Clothes = reader.ReadBlock<ResourcePointerList64<EnvironmentCloth>>();
            this.Unknown_70h = reader.ReadUInt64();
            this.Unknown_78h = reader.ReadUInt64();
            this.Unknown_80h = reader.ReadUInt64();
            this.Unknown_88h = reader.ReadUInt64();
            this.Unknown_90h = reader.ReadUInt64();
            this.Unknown_98h = reader.ReadUInt64();
            this.Unknown_A0h = reader.ReadUInt64();
            this.MatrixSetPointer = reader.ReadUInt64();
            this.Unknown_B0h = reader.ReadUInt32();
            this.Unknown_B4h = reader.ReadUInt32();
            this.Unknown_B8h = reader.ReadUInt32();
            this.Unknown_BCh = reader.ReadUInt32();
            this.Unknown_C0h = reader.ReadUInt32();
            this.Unknown_C4h = reader.ReadUInt32();
            this.Unknown_C8h = reader.ReadUInt32();
            this.Unknown_CCh = reader.ReadUInt32();
            this.Unknown_D0h = reader.ReadSingle();
            this.Unknown_D4h = reader.ReadSingle();
            this.Unknown_D8h = reader.ReadByte();
            this.Count3 = reader.ReadByte();
            this.Unknown_DAh = reader.ReadUInt16();
            this.Unknown_DCh = reader.ReadUInt32();
            this.Unknown_E0h_Pointer = reader.ReadUInt64();
            this.Unknown_E8h = reader.ReadUInt64();
            this.PhysicsLODGroupPointer = reader.ReadUInt64();
            this.ClothDrawablePointer = reader.ReadUInt64();
            this.Unknown_100h = reader.ReadUInt64();
            this.Unknown_108h = reader.ReadUInt64();
            this.LightAttributes = reader.ReadBlock<ResourceSimpleList64<LightAttributes>>();
            this.VehicleGlassWindowDataPointer = reader.ReadUInt64();
            this.Unknown_128h = reader.ReadUInt64();

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
            this.MatrixSet = reader.ReadBlockAt<MatrixSet>(
                this.MatrixSetPointer // offset
            );
            this.Unknown_E0h_Data = reader.ReadBlockAt<ResourcePointerArray64<Unknown_F_004>>(
                this.Unknown_E0h_Pointer, // offset
                this.Count3
            );
            this.PhysicsLODGroup = reader.ReadBlockAt<FragPhysicsLODGroup>(
                this.PhysicsLODGroupPointer // offset
            );
            this.ClothDrawable = reader.ReadBlockAt<FragDrawable>(
                this.ClothDrawablePointer // offset
            );
            this.VehicleGlassWindowData = reader.ReadBlockAt<VehicleGlassWindowData>(
                this.VehicleGlassWindowDataPointer // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.DrawablePointer = (ulong)(this.Drawable != null ? this.Drawable.BlockPosition : 0);
            this.Unknown_28h_Pointer = (ulong)(this.Unknown_28h_Data != null ? this.Unknown_28h_Data.BlockPosition : 0);
            this.Unknown_30h_Pointer = (ulong)(this.Unknown_30h_Data != null ? this.Unknown_30h_Data.BlockPosition : 0);
            this.NamePointer = (ulong)(this.Name != null ? this.Name.BlockPosition : 0);
            this.MatrixSetPointer = (ulong)(this.MatrixSet != null ? this.MatrixSet.BlockPosition : 0);
            this.Unknown_E0h_Pointer = (ulong)(this.Unknown_E0h_Data != null ? this.Unknown_E0h_Data.BlockPosition : 0);
            this.PhysicsLODGroupPointer = (ulong)(this.PhysicsLODGroup != null ? this.PhysicsLODGroup.BlockPosition : 0);
            this.ClothDrawablePointer = (ulong)(this.ClothDrawable != null ? this.ClothDrawable.BlockPosition : 0);
            this.VehicleGlassWindowDataPointer = (ulong)(this.VehicleGlassWindowData != null ? this.VehicleGlassWindowData.BlockPosition : 0);

            // write structure data
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_18h);
            writer.Write(this.BoundingSphereCenter);
            writer.Write(this.BoundingSphereRadius);
            writer.Write(this.DrawablePointer);
            writer.Write(this.Unknown_28h_Pointer);
            writer.Write(this.Unknown_30h_Pointer);
            writer.Write(this.Count0);
            writer.Write(this.Unknown_4Ch);
            writer.Write(this.Unknown_50h);
            writer.Write(this.NamePointer);
            writer.WriteBlock(this.Clothes);
            writer.Write(this.Unknown_70h);
            writer.Write(this.Unknown_78h);
            writer.Write(this.Unknown_80h);
            writer.Write(this.Unknown_88h);
            writer.Write(this.Unknown_90h);
            writer.Write(this.Unknown_98h);
            writer.Write(this.Unknown_A0h);
            writer.Write(this.MatrixSetPointer);
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
            writer.Write(this.PhysicsLODGroupPointer);
            writer.Write(this.ClothDrawablePointer);
            writer.Write(this.Unknown_100h);
            writer.Write(this.Unknown_108h);
            writer.WriteBlock(this.LightAttributes);
            writer.Write(this.VehicleGlassWindowDataPointer);
            writer.Write(this.Unknown_128h);
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
            if (MatrixSet != null) list.Add(MatrixSet);
            if (Unknown_E0h_Data != null) list.Add(Unknown_E0h_Data);
            if (PhysicsLODGroup != null) list.Add(PhysicsLODGroup);
            if (ClothDrawable != null) list.Add(ClothDrawable);
            if (VehicleGlassWindowData != null) list.Add(VehicleGlassWindowData);
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
