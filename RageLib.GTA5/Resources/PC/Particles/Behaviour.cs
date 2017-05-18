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

using System;

namespace RageLib.Resources.GTA5.PC.Particles
{
    public enum BehaviourType : uint
    {
        Age = 0xF5B33BAA,
        Acceleration = 0xD63D9F1B,
        Velocity = 0x6C0719BC,
        Rotation = 0x1EE64552,
        Size = 0x38B60240,
        Dampening = 0x052B1293,
        MatrixWeight = 0x64E5D702,
        Collision = 0x928A1C45,
        AnimateTexture = 0xECA84C1E,
        Colour = 0x164AEA72,
        Sprite = 0x68FA73F5,
        Wind = 0x38B63978,
        Light = 0x0544C710,
        Model = 0x6232E25A,
        Decal = 0x8F3B6036,
        ZCull = 0xA35C721F,
        Noise = 0xB77FED19,
        Attractor = 0x25AC9437,
        Trail = 0xC57377F8,
        FogVolume = 0xA05DA63E,
        River = 0xD4594BEF,
        DecalPool = 0xA2D6DC3F,
        Liquid = 0xDF229542
    }

    // ptxBehaviour
    public class Behaviour : ResourceSystemBlock, IResourceXXSystemBlock
    {
        public override long Length => 0x10;

        // structure data
        public uint VFT;
        public uint Unknown_4h; // 0x00000001
        public uint Type;
        public uint Unknown_Ch; // 0x00000000

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.VFT = reader.ReadUInt32();
            this.Unknown_4h = reader.ReadUInt32();
            this.Type = reader.ReadUInt32();
            this.Unknown_Ch = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // write structure data
            writer.Write(this.VFT);
            writer.Write(this.Unknown_4h);
            writer.Write(this.Type);
            writer.Write(this.Unknown_Ch);
        }

        public IResourceSystemBlock GetType(ResourceDataReader reader, params object[] parameters)
        {

            reader.Position += 8;
            BehaviourType type = (BehaviourType)reader.ReadUInt32();
            reader.Position -= 12;

            switch (type)
            {
                case BehaviourType.Age: return new BehaviourAge();
                case BehaviourType.Acceleration: return new BehaviourAcceleration();
                case BehaviourType.Velocity: return new BehaviourVelocity();
                case BehaviourType.Rotation: return new BehaviourRotation();
                case BehaviourType.Size: return new BehaviourSize();
                case BehaviourType.Dampening: return new BehaviourDampening();
                case BehaviourType.MatrixWeight: return new BehaviourMatrixWeight();
                case BehaviourType.Collision: return new BehaviourCollision();
                case BehaviourType.AnimateTexture: return new BehaviourAnimateTexture();
                case BehaviourType.Colour: return new BehaviourColour();
                case BehaviourType.Sprite: return new BehaviourSprite();
                case BehaviourType.Wind: return new BehaviourWind();
                case BehaviourType.Light: return new BehaviourLight();
                case BehaviourType.Model: return new BehaviourModel();
                case BehaviourType.Decal: return new BehaviourDecal();
                case BehaviourType.ZCull: return new BehaviourZCull();
                case BehaviourType.Noise: return new BehaviourNoise();
                case BehaviourType.Attractor: return new BehaviourAttractor();
                case BehaviourType.Trail: return new BehaviourTrail();
                case BehaviourType.FogVolume: return new BehaviourFogVolume();
                case BehaviourType.River: return new BehaviourRiver();
                case BehaviourType.DecalPool: return new BehaviourDecalPool();
                case BehaviourType.Liquid: return new BehaviourLiquid();
                default: throw new Exception("Unknown behaviour type");
            }
        }
    }
}
