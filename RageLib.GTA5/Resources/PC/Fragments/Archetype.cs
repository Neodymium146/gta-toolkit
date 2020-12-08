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
using RageLib.Resources.GTA5.PC.Bounds;
using System.Collections.Generic;
using System.Numerics;

namespace RageLib.Resources.GTA5.PC.Fragments
{
    // pgBase
    // phArchetypeBase
    // phArchetype
    // phArchetypePhys
    // phArchetypeDamp
    public class Archetype : PgBase64
    {
        public override long BlockLength => 0xE0;

        // structure data
        public uint Unknown_10h; // 0x00000002 -> type=phArchetypeDamp
        public uint Unknown_14h; // 0x00000000
        public ulong NamePointer;
        public ulong BoundPointer;
        public uint TypeFlags; // 0x00000001
        public uint IncludeFlags; // 0xFFFFFFFF
        public uint PropertyFlags; // 0x00010000
        public uint Unknown_34h; // 0x00000000
        public uint Unknown_38h; // 0x00000000
        public uint Unknown_3Ch; // 0x00000000
        public float Mass;
        public float InvMass;
        public float Unknown_48h; // 1.0f
        public float MaxSpeed; // 150.0f
        public float MaxAngSpeed; // 6.2831855f = 2*pi
        public float Unknown_54h; // 1.0f
        public uint Unknown_58h; // 0x00000000
        public uint Unknown_5Ch; // 0x00000000
        public Vector4 AngInertia;
        public Vector4 InvAngInertia;
        public Vector4 Unknown_80h; // 0.0 0.0 0.0 NaN
        public Vector4 Unknown_90h; // 0.0 0.0 0.0 NaN
        public Vector4 Unknown_A0h; // 0.0 0.0 0.0 NaN
        public Vector4 Unknown_B0h; // 0.0 0.0 0.0 NaN
        public Vector4 Unknown_C0h; // 0.0 0.0 0.0 NaN
        public Vector4 Unknown_D0h; // 0.0 0.0 0.0 NaN

        // reference data
        public string_r Name;
        public Bound Bound;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.Unknown_10h = reader.ReadUInt32();
            this.Unknown_14h = reader.ReadUInt32();
            this.NamePointer = reader.ReadUInt64();
            this.BoundPointer = reader.ReadUInt64();
            this.TypeFlags = reader.ReadUInt32();
            this.IncludeFlags = reader.ReadUInt32();
            this.PropertyFlags = reader.ReadUInt32();
            this.Unknown_34h = reader.ReadUInt32();
            this.Unknown_38h = reader.ReadUInt32();
            this.Unknown_3Ch = reader.ReadUInt32();
            this.Mass = reader.ReadSingle();
            this.InvMass = reader.ReadSingle();
            this.Unknown_48h = reader.ReadSingle();
            this.MaxSpeed = reader.ReadSingle();
            this.MaxAngSpeed = reader.ReadSingle();
            this.Unknown_54h = reader.ReadSingle();
            this.Unknown_58h = reader.ReadUInt32();
            this.Unknown_5Ch = reader.ReadUInt32();
            this.AngInertia = reader.ReadVector4();
            this.InvAngInertia = reader.ReadVector4();
            this.Unknown_80h = reader.ReadVector4();
            this.Unknown_90h = reader.ReadVector4();
            this.Unknown_A0h = reader.ReadVector4();
            this.Unknown_B0h = reader.ReadVector4();
            this.Unknown_C0h = reader.ReadVector4();
            this.Unknown_D0h = reader.ReadVector4();

            // read reference data
            this.Name = reader.ReadBlockAt<string_r>(
                this.NamePointer // offset
            );
            this.Bound = reader.ReadBlockAt<Bound>(
                this.BoundPointer // offset
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
            this.BoundPointer = (ulong)(this.Bound != null ? this.Bound.BlockPosition : 0);

            // write structure data
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.Write(this.NamePointer);
            writer.Write(this.BoundPointer);
            writer.Write(this.TypeFlags);
            writer.Write(this.IncludeFlags);
            writer.Write(this.PropertyFlags);
            writer.Write(this.Unknown_34h);
            writer.Write(this.Unknown_38h);
            writer.Write(this.Unknown_3Ch);
            writer.Write(this.Mass);
            writer.Write(this.InvMass);
            writer.Write(this.Unknown_48h);
            writer.Write(this.MaxSpeed);
            writer.Write(this.MaxAngSpeed);
            writer.Write(this.Unknown_54h);
            writer.Write(this.Unknown_58h);
            writer.Write(this.Unknown_5Ch);
            writer.Write(this.AngInertia);
            writer.Write(this.InvAngInertia);
            writer.Write(this.Unknown_80h);
            writer.Write(this.Unknown_90h);
            writer.Write(this.Unknown_A0h);
            writer.Write(this.Unknown_B0h);
            writer.Write(this.Unknown_C0h);
            writer.Write(this.Unknown_D0h);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>(base.GetReferences());
            if (Name != null) list.Add(Name);
            if (Bound != null) list.Add(Bound);
            return list.ToArray();
        }
    }
}
