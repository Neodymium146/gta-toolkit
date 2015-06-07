/*
    Copyright(c) 2015 Neodymium

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
    public class Behaviour_GTA5_pc : ResourceSystemBlock, IResourceXXSystemBlock
    {
        public override long Length
        {
            get { return 16; }
        }

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
            var type = reader.ReadUInt32();
            reader.Position -= 12;

            switch (type)
            {
                case 4122164138: return new BehaviourAge_GTA5_pc();
                case 3594362651: return new BehaviourAcceleration_GTA5_pc();
                case 1812404668: return new BehaviourVelocity_GTA5_pc();
                case 518407506: return new BehaviourRotation_GTA5_pc();
                case 951452224: return new BehaviourSize_GTA5_pc();
                case 86708883: return new BehaviourDampening_GTA5_pc();
                case 1692784386: return new BehaviourMatrixWeight_GTA5_pc();
                case 2458524741: return new BehaviourCollision_GTA5_pc();
                case 3970452510: return new BehaviourAnimateTexture_GTA5_pc();
                case 374008434: return new BehaviourColour_GTA5_pc();
                case 1761244149: return new BehaviourSprite_GTA5_pc();
                case 951466360: return new BehaviourWind_GTA5_pc();
                case 88393488: return new BehaviourLight_GTA5_pc();
                case 1647501914: return new BehaviourModel_GTA5_pc();
                case 2403033142: return new BehaviourDecal_GTA5_pc();
                case 2740744735: return new BehaviourZCull_GTA5_pc();
                case 3078614297: return new BehaviourNoise_GTA5_pc();
                case 632067127: return new BehaviourAttractor_GTA5_pc();
                case 3312678904: return new BehaviourTrail_GTA5_pc();
                case 2690491966: return new BehaviourFogVolume_GTA5_pc();
                case 3562621935: return new BehaviourRiver_GTA5_pc();
                case 2731990079: return new BehaviourDecalPool_GTA5_pc();
                case 3743585602: return new BehaviourLiquid_GTA5_pc();
                default: throw new Exception("Unknown type");
            }

        }
    }
}