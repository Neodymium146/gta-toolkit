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

namespace RageLib.Resources.GTA5.PC.Fragments
{
    public class FragTypeGroup : ResourceSystemBlock
    {
        public override long BlockLength => 0xB0;

        // structure data
        public uint Unknown_0h; // 0x00000000
        public uint Unknown_4h; // 0x00000000
        public uint Unknown_8h; // 0x00000000
        public uint Unknown_Ch; // 0x00000000
        public float Strength;
        public float ForceTransmissionScaleUp;
        public float ForceTransmissionScaleDown;
        public float JointStiffness;
        public float MinSoftAngle1;
        public float MaxSoftAngle1;
        public float MaxSoftAngle2;
        public float MaxSoftAngle3;
        public float RotationSpeed;
        public float RotationStrength;
        public float RestoringStrength;
        public float RestoringMaxTorque;
        public float LatchStrength;
        public float Mass;
        public float Unknown_48h; // 0x00000000
        public byte Unknown_4Ch;
        public byte ParentIndex;
        public byte Index;
        public byte Unknown_4Fh;
        public byte Unknown_50h;
        public byte Unknown_51h;
        public byte Unknown_52h;
        public byte Unknown_53h; // disappearsWhenDead ?
        public float MinDamageForce;
        public float DamageHealth;
        public float Unknown_5Ch;
        public float Unknown_60h;
        public float Unknown_64h;
        public float Unknown_68h;
        public float Unknown_6Ch;
        public float Unknown_70h;
        public float Unknown_74h;
        public float Unknown_78h;
        public float Unknown_7Ch; // 0x00000000
        public string32_r Name;
        public float Unknown_A0h;
        public float Unknown_A4h;
        public float Unknown_A8h;
        public float Unknown_ACh; // 0x00000000

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.Unknown_0h = reader.ReadUInt32();
            this.Unknown_4h = reader.ReadUInt32();
            this.Unknown_8h = reader.ReadUInt32();
            this.Unknown_Ch = reader.ReadUInt32();
            this.Strength = reader.ReadSingle();
            this.ForceTransmissionScaleUp = reader.ReadSingle();
            this.ForceTransmissionScaleDown = reader.ReadSingle();
            this.JointStiffness = reader.ReadSingle();
            this.MinSoftAngle1 = reader.ReadSingle();
            this.MaxSoftAngle1 = reader.ReadSingle();
            this.MaxSoftAngle2 = reader.ReadSingle();
            this.MaxSoftAngle3 = reader.ReadSingle();
            this.RotationSpeed = reader.ReadSingle();
            this.RotationStrength = reader.ReadSingle();
            this.RestoringStrength = reader.ReadSingle();
            this.RestoringMaxTorque = reader.ReadSingle();
            this.LatchStrength = reader.ReadSingle();
            this.Mass = reader.ReadSingle();
            this.Unknown_48h = reader.ReadSingle();
            this.Unknown_4Ch = reader.ReadByte();
            this.ParentIndex = reader.ReadByte();
            this.Index = reader.ReadByte();
            this.Unknown_4Fh = reader.ReadByte();
            this.Unknown_50h = reader.ReadByte();
            this.Unknown_51h = reader.ReadByte();
            this.Unknown_52h = reader.ReadByte();
            this.Unknown_53h = reader.ReadByte();
            this.MinDamageForce = reader.ReadSingle();
            this.DamageHealth = reader.ReadSingle();
            this.Unknown_5Ch = reader.ReadSingle();
            this.Unknown_60h = reader.ReadSingle();
            this.Unknown_64h = reader.ReadSingle();
            this.Unknown_68h = reader.ReadSingle();
            this.Unknown_6Ch = reader.ReadSingle();
            this.Unknown_70h = reader.ReadSingle();
            this.Unknown_74h = reader.ReadSingle();
            this.Unknown_78h = reader.ReadSingle();
            this.Unknown_7Ch = reader.ReadSingle();
            this.Name = reader.ReadBlock<string32_r>();
            this.Unknown_A0h = reader.ReadSingle();
            this.Unknown_A4h = reader.ReadSingle();
            this.Unknown_A8h = reader.ReadSingle();
            this.Unknown_ACh = reader.ReadSingle();
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // write structure data
            writer.Write(this.Unknown_0h);
            writer.Write(this.Unknown_4h);
            writer.Write(this.Unknown_8h);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.Strength);
            writer.Write(this.ForceTransmissionScaleUp);
            writer.Write(this.ForceTransmissionScaleDown);
            writer.Write(this.JointStiffness);
            writer.Write(this.MinSoftAngle1);
            writer.Write(this.MaxSoftAngle1);
            writer.Write(this.MaxSoftAngle2);
            writer.Write(this.MaxSoftAngle3);
            writer.Write(this.RotationSpeed);
            writer.Write(this.RotationStrength);
            writer.Write(this.RestoringStrength);
            writer.Write(this.RestoringMaxTorque);
            writer.Write(this.LatchStrength);
            writer.Write(this.Mass);
            writer.Write(this.Unknown_48h);
            writer.Write(this.Unknown_4Ch);
            writer.Write(this.ParentIndex);
            writer.Write(this.Index);
            writer.Write(this.Unknown_4Fh);
            writer.Write(this.Unknown_50h);
            writer.Write(this.Unknown_51h);
            writer.Write(this.Unknown_52h);
            writer.Write(this.Unknown_53h);
            writer.Write(this.MinDamageForce);
            writer.Write(this.DamageHealth);
            writer.Write(this.Unknown_5Ch);
            writer.Write(this.Unknown_60h);
            writer.Write(this.Unknown_64h);
            writer.Write(this.Unknown_68h);
            writer.Write(this.Unknown_6Ch);
            writer.Write(this.Unknown_70h);
            writer.Write(this.Unknown_74h);
            writer.Write(this.Unknown_78h);
            writer.Write(this.Unknown_7Ch);
            writer.WriteBlock(this.Name);
            writer.Write(this.Unknown_A0h);
            writer.Write(this.Unknown_A4h);
            writer.Write(this.Unknown_A8h);
            writer.Write(this.Unknown_ACh);
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(0x80, Name)
            };
        }
    }
}
