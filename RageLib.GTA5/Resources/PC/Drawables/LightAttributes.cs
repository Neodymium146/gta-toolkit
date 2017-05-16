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

namespace RageLib.Resources.GTA5.PC.Drawables
{
    // CLightAttr
    public class LightAttributes : ResourceSystemBlock
    {
        public override long Length => 0xA8;

        // structure data
        public uint Unknown_0h; // 0x00000000
        public uint Unknown_4h; // 0x00000000
        public float PositionX;
        public float PositionY;
        public float PositionZ;
        public uint Unknown_14h; // 0x00000000
        public byte ColorR;
        public byte ColorG;
        public byte ColorB;
        public byte Unknown_1Bh;
        public float Intensity;
        public uint Unknown_20h;
        public ushort BoneId;
        public ushort Type;
        public uint Unknown_28h;
        public float Falloff;
        public float FalloffExponent;
        public float CullingPlaneNormalX;
        public float CullingPlaneNormalY;
        public float CullingPlaneNormalZ;
        public float CullingPlaneOffset;
        public byte ShadowBlur;
        public byte Unknown_45h;
        public ushort Unknown_46h;
        public uint Unknown_48h; // 0x00000000
        public float VolumeIntensity;
        public float VolumeSizeScale;
        public byte VolumeOuterColorR;
        public byte VolumeOuterColorG;
        public byte VolumeOuterColorB;
        public byte LightHash;
        public float VolumeOuterIntensity;
        public float CoronaSize;
        public float VolumeOuterExponent;
        public byte LightFadeDistance;
        public byte ShadowFadeDistance;
        public byte SpecularFadeDistance;
        public byte VolumetricFadeDistance;
        public float ShadowNearClip;
        public float CoronaIntensity;
        public float CoronaZBias;
        public float DirectionX;
        public float DirectionY;
        public float DirectionZ;
        public float TangentX;
        public float TangentY;
        public float TangentZ;
        public float ConeInnerAngle;
        public float ConeOuterAngle;
        public float ExtentX;
        public float ExtentY;
        public float ExtentZ;
        public uint ProjectedTextureHash;
        public uint Unknown_A4h; // 0x00000000

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.Unknown_0h = reader.ReadUInt32();
            this.Unknown_4h = reader.ReadUInt32();
            this.PositionX = reader.ReadSingle();
            this.PositionY = reader.ReadSingle();
            this.PositionZ = reader.ReadSingle();
            this.Unknown_14h = reader.ReadUInt32();
            this.ColorR = reader.ReadByte();
            this.ColorG = reader.ReadByte();
            this.ColorB = reader.ReadByte();
            this.Unknown_1Bh = reader.ReadByte();
            this.Intensity = reader.ReadSingle();
            this.Unknown_20h = reader.ReadUInt32();
            this.BoneId = reader.ReadUInt16();
            this.Type = reader.ReadUInt16();
            this.Unknown_28h = reader.ReadUInt32();
            this.Falloff = reader.ReadSingle();
            this.FalloffExponent = reader.ReadSingle();
            this.CullingPlaneNormalX = reader.ReadSingle();
            this.CullingPlaneNormalY = reader.ReadSingle();
            this.CullingPlaneNormalZ = reader.ReadSingle();
            this.CullingPlaneOffset = reader.ReadSingle();
            this.ShadowBlur = reader.ReadByte();
            this.Unknown_45h = reader.ReadByte();
            this.Unknown_46h = reader.ReadUInt16();
            this.Unknown_48h = reader.ReadUInt32();
            this.VolumeIntensity = reader.ReadSingle();
            this.VolumeSizeScale = reader.ReadSingle();
            this.VolumeOuterColorR = reader.ReadByte();
            this.VolumeOuterColorG = reader.ReadByte();
            this.VolumeOuterColorB = reader.ReadByte();
            this.LightHash = reader.ReadByte();
            this.VolumeOuterIntensity = reader.ReadSingle();
            this.CoronaSize = reader.ReadSingle();
            this.VolumeOuterExponent = reader.ReadSingle();
            this.LightFadeDistance = reader.ReadByte();
            this.ShadowFadeDistance = reader.ReadByte();
            this.SpecularFadeDistance = reader.ReadByte();
            this.VolumetricFadeDistance = reader.ReadByte();
            this.ShadowNearClip = reader.ReadSingle();
            this.CoronaIntensity = reader.ReadSingle();
            this.CoronaZBias = reader.ReadSingle();
            this.DirectionX = reader.ReadSingle();
            this.DirectionY = reader.ReadSingle();
            this.DirectionZ = reader.ReadSingle();
            this.TangentX = reader.ReadSingle();
            this.TangentY = reader.ReadSingle();
            this.TangentZ = reader.ReadSingle();
            this.ConeInnerAngle = reader.ReadSingle();
            this.ConeOuterAngle = reader.ReadSingle();
            this.ExtentX = reader.ReadSingle();
            this.ExtentY = reader.ReadSingle();
            this.ExtentZ = reader.ReadSingle();
            this.ProjectedTextureHash = reader.ReadUInt32();
            this.Unknown_A4h = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // write structure data
            writer.Write(this.Unknown_0h);
            writer.Write(this.Unknown_4h);
            writer.Write(this.PositionX);
            writer.Write(this.PositionY);
            writer.Write(this.PositionZ);
            writer.Write(this.Unknown_14h);
            writer.Write(this.ColorR);
            writer.Write(this.ColorG);
            writer.Write(this.ColorB);
            writer.Write(this.Unknown_1Bh);
            writer.Write(this.Intensity);
            writer.Write(this.Unknown_20h);
            writer.Write(this.BoneId);
            writer.Write(this.Type);
            writer.Write(this.Unknown_28h);
            writer.Write(this.Falloff);
            writer.Write(this.FalloffExponent);
            writer.Write(this.CullingPlaneNormalX);
            writer.Write(this.CullingPlaneNormalY);
            writer.Write(this.CullingPlaneNormalZ);
            writer.Write(this.CullingPlaneOffset);
            writer.Write(this.ShadowBlur);
            writer.Write(this.Unknown_45h);
            writer.Write(this.Unknown_46h);
            writer.Write(this.Unknown_48h);
            writer.Write(this.VolumeIntensity);
            writer.Write(this.VolumeSizeScale);
            writer.Write(this.VolumeOuterColorR);
            writer.Write(this.VolumeOuterColorG);
            writer.Write(this.VolumeOuterColorB);
            writer.Write(this.LightHash);
            writer.Write(this.VolumeOuterIntensity);
            writer.Write(this.CoronaSize);
            writer.Write(this.VolumeOuterExponent);
            writer.Write(this.LightFadeDistance);
            writer.Write(this.ShadowFadeDistance);
            writer.Write(this.SpecularFadeDistance);
            writer.Write(this.VolumetricFadeDistance);
            writer.Write(this.ShadowNearClip);
            writer.Write(this.CoronaIntensity);
            writer.Write(this.CoronaZBias);
            writer.Write(this.DirectionX);
            writer.Write(this.DirectionY);
            writer.Write(this.DirectionZ);
            writer.Write(this.TangentX);
            writer.Write(this.TangentY);
            writer.Write(this.TangentZ);
            writer.Write(this.ConeInnerAngle);
            writer.Write(this.ConeOuterAngle);
            writer.Write(this.ExtentX);
            writer.Write(this.ExtentY);
            writer.Write(this.ExtentZ);
            writer.Write(this.ProjectedTextureHash);
            writer.Write(this.Unknown_A4h);
        }
    }
}
