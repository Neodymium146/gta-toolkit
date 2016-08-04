/*
    Copyright(c) 2016 Neodymium

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

namespace RageLib.Resources.GTA5.PC.Drawables
{
    public class DrawableBase_GTA5_pc : FileBase64_GTA5_pc
    {
        public override long Length
        {
            get { return 168; }
        }

        // structure data
        public ulong ShaderGroupPointer;
        public ulong SkeletonPointer;
        public RAGE_Vector3 BoundingCenter;
        public float BoundingSphereRadius;
        public RAGE_Vector4 BoundingBoxMin;
        public RAGE_Vector4 BoundingBoxMax;
        public ulong DrawableModelsHighPointer;
        public ulong DrawableModelsMediumPointer;
        public ulong DrawableModelsLowPointer;
        public ulong DrawableModelsVeryLowPointer;
        public float Unknown_70h;
        public float Unknown_74h;
        public float Unknown_78h;
        public float Unknown_7Ch;
        public uint Unknown_80h;
        public uint Unknown_84h;
        public uint Unknown_88h;
        public uint Unknown_8Ch;
        public ulong JointsPointer;
        public uint Unknown_98h;
        public uint Unknown_9Ch; // 0x00000000
        public ulong DrawableModelsXPointer;

        // reference data
        public ShaderGroup_GTA5_pc ShaderGroup;
        public Skeleton_GTA5_pc Skeleton;
        public ResourcePointerList64<DrawableModel_GTA5_pc> DrawableModelsHigh;
        public ResourcePointerList64<DrawableModel_GTA5_pc> DrawableModelsMedium;
        public ResourcePointerList64<DrawableModel_GTA5_pc> DrawableModelsLow;
        public ResourcePointerList64<DrawableModel_GTA5_pc> DrawableModelsVeryLow;
        public Joints_GTA5_pc Joints;
        public ResourcePointerList64<DrawableModel_GTA5_pc> DrawableModelsX;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.ShaderGroupPointer = reader.ReadUInt64();
            this.SkeletonPointer = reader.ReadUInt64();
            this.BoundingCenter = reader.ReadBlock<RAGE_Vector3>();
            this.BoundingSphereRadius = reader.ReadSingle();
            this.BoundingBoxMin = reader.ReadBlock<RAGE_Vector4>();
            this.BoundingBoxMax = reader.ReadBlock<RAGE_Vector4>();
            this.DrawableModelsHighPointer = reader.ReadUInt64();
            this.DrawableModelsMediumPointer = reader.ReadUInt64();
            this.DrawableModelsLowPointer = reader.ReadUInt64();
            this.DrawableModelsVeryLowPointer = reader.ReadUInt64();
            this.Unknown_70h = reader.ReadSingle();
            this.Unknown_74h = reader.ReadSingle();
            this.Unknown_78h = reader.ReadSingle();
            this.Unknown_7Ch = reader.ReadSingle();
            this.Unknown_80h = reader.ReadUInt32();
            this.Unknown_84h = reader.ReadUInt32();
            this.Unknown_88h = reader.ReadUInt32();
            this.Unknown_8Ch = reader.ReadUInt32();
            this.JointsPointer = reader.ReadUInt64();
            this.Unknown_98h = reader.ReadUInt32();
            this.Unknown_9Ch = reader.ReadUInt32();
            this.DrawableModelsXPointer = reader.ReadUInt64();

            // read reference data
            this.ShaderGroup = reader.ReadBlockAt<ShaderGroup_GTA5_pc>(
                this.ShaderGroupPointer // offset
            );
            this.Skeleton = reader.ReadBlockAt<Skeleton_GTA5_pc>(
                this.SkeletonPointer // offset
            );
            this.DrawableModelsHigh = reader.ReadBlockAt<ResourcePointerList64<DrawableModel_GTA5_pc>>(
                this.DrawableModelsHighPointer // offset
            );
            this.DrawableModelsMedium = reader.ReadBlockAt<ResourcePointerList64<DrawableModel_GTA5_pc>>(
                this.DrawableModelsMediumPointer // offset
            );
            this.DrawableModelsLow = reader.ReadBlockAt<ResourcePointerList64<DrawableModel_GTA5_pc>>(
                this.DrawableModelsLowPointer // offset
            );
            this.DrawableModelsVeryLow = reader.ReadBlockAt<ResourcePointerList64<DrawableModel_GTA5_pc>>(
                this.DrawableModelsVeryLowPointer // offset
            );
            this.Joints = reader.ReadBlockAt<Joints_GTA5_pc>(
                this.JointsPointer // offset
            );
            this.DrawableModelsX = reader.ReadBlockAt<ResourcePointerList64<DrawableModel_GTA5_pc>>(
                this.DrawableModelsXPointer // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.ShaderGroupPointer = (ulong)(this.ShaderGroup != null ? this.ShaderGroup.Position : 0);
            this.SkeletonPointer = (ulong)(this.Skeleton != null ? this.Skeleton.Position : 0);
            this.DrawableModelsHighPointer = (ulong)(this.DrawableModelsHigh != null ? this.DrawableModelsHigh.Position : 0);
            this.DrawableModelsMediumPointer = (ulong)(this.DrawableModelsMedium != null ? this.DrawableModelsMedium.Position : 0);
            this.DrawableModelsLowPointer = (ulong)(this.DrawableModelsLow != null ? this.DrawableModelsLow.Position : 0);
            this.DrawableModelsVeryLowPointer = (ulong)(this.DrawableModelsVeryLow != null ? this.DrawableModelsVeryLow.Position : 0);
            this.JointsPointer = (ulong)(this.Joints != null ? this.Joints.Position : 0);
            this.DrawableModelsXPointer = (ulong)(this.DrawableModelsX != null ? this.DrawableModelsX.Position : 0);

            // write structure data
            writer.Write(this.ShaderGroupPointer);
            writer.Write(this.SkeletonPointer);
            writer.WriteBlock(this.BoundingCenter);
            writer.Write(this.BoundingSphereRadius);
            writer.WriteBlock(this.BoundingBoxMin);
            writer.WriteBlock(this.BoundingBoxMax);
            writer.Write(this.DrawableModelsHighPointer);
            writer.Write(this.DrawableModelsMediumPointer);
            writer.Write(this.DrawableModelsLowPointer);
            writer.Write(this.DrawableModelsVeryLowPointer);
            writer.Write(this.Unknown_70h);
            writer.Write(this.Unknown_74h);
            writer.Write(this.Unknown_78h);
            writer.Write(this.Unknown_7Ch);
            writer.Write(this.Unknown_80h);
            writer.Write(this.Unknown_84h);
            writer.Write(this.Unknown_88h);
            writer.Write(this.Unknown_8Ch);
            writer.Write(this.JointsPointer);
            writer.Write(this.Unknown_98h);
            writer.Write(this.Unknown_9Ch);
            writer.Write(this.DrawableModelsXPointer);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>(base.GetReferences());
            if (ShaderGroup != null) list.Add(ShaderGroup);
            if (Skeleton != null) list.Add(Skeleton);
            if (DrawableModelsHigh != null) list.Add(DrawableModelsHigh);
            if (DrawableModelsMedium != null) list.Add(DrawableModelsMedium);
            if (DrawableModelsLow != null) list.Add(DrawableModelsLow);
            if (DrawableModelsVeryLow != null) list.Add(DrawableModelsVeryLow);
            if (Joints != null) list.Add(Joints);
            if (DrawableModelsX != null) list.Add(DrawableModelsX);
            return list.ToArray();
        }
    }
}
