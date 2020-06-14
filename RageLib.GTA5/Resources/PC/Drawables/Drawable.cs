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

namespace RageLib.Resources.GTA5.PC.Drawables
{
    // rmcDrawable
    // rmcLodGroup
    public class Drawable : DrawableBase
    {
        public override long Length => 0xA8;

        // structure data
        public ulong SkeletonPointer;
        public Vector3 BoundingCenter; // start of rmcLodGroup
        public float BoundingSphereRadius;
        public Vector4 BoundingBoxMin;
        public Vector4 BoundingBoxMax;
        public ulong DrawableModelsHighPointer;
        public ulong DrawableModelsMediumPointer;
        public ulong DrawableModelsLowPointer;
        public ulong DrawableModelsVeryLowPointer;
        public float LodDistanceHigh;
        public float LodDistanceMedium;
        public float LodDistanceLow;
        public float LodDistanceVeryLow;
        public uint DrawBucketMaskHigh;
        public uint DrawBucketMaskMedium;
        public uint DrawBucketMaskLow;
        public uint DrawBucketMaskVeryLow; // end of rmcLodGroup
        public ulong JointsPointer;
        public uint Unknown_98h;
        public uint Unknown_9Ch; // 0x00000000
        public ulong DrawableModelsXPointer;

        // reference data
        public SkeletonData Skeleton;
        public ResourcePointerList64<DrawableModel> DrawableModelsHigh;
        public ResourcePointerList64<DrawableModel> DrawableModelsMedium;
        public ResourcePointerList64<DrawableModel> DrawableModelsLow;
        public ResourcePointerList64<DrawableModel> DrawableModelsVeryLow;
        public Joints Joints;
        public ResourcePointerList64<DrawableModel> DrawableModelsX;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.SkeletonPointer = reader.ReadUInt64();
            this.BoundingCenter = reader.ReadVector3();
            this.BoundingSphereRadius = reader.ReadSingle();
            this.BoundingBoxMin = reader.ReadVector4();
            this.BoundingBoxMax = reader.ReadVector4();
            this.DrawableModelsHighPointer = reader.ReadUInt64();
            this.DrawableModelsMediumPointer = reader.ReadUInt64();
            this.DrawableModelsLowPointer = reader.ReadUInt64();
            this.DrawableModelsVeryLowPointer = reader.ReadUInt64();
            this.LodDistanceHigh = reader.ReadSingle();
            this.LodDistanceMedium = reader.ReadSingle();
            this.LodDistanceLow = reader.ReadSingle();
            this.LodDistanceVeryLow = reader.ReadSingle();
            this.DrawBucketMaskHigh = reader.ReadUInt32();
            this.DrawBucketMaskMedium = reader.ReadUInt32();
            this.DrawBucketMaskLow = reader.ReadUInt32();
            this.DrawBucketMaskVeryLow = reader.ReadUInt32();
            this.JointsPointer = reader.ReadUInt64();
            this.Unknown_98h = reader.ReadUInt32();
            this.Unknown_9Ch = reader.ReadUInt32();
            this.DrawableModelsXPointer = reader.ReadUInt64();

            // read reference data
            this.Skeleton = reader.ReadBlockAt<SkeletonData>(
                this.SkeletonPointer // offset
            );
            this.DrawableModelsHigh = reader.ReadBlockAt<ResourcePointerList64<DrawableModel>>(
                this.DrawableModelsHighPointer // offset
            );
            this.DrawableModelsMedium = reader.ReadBlockAt<ResourcePointerList64<DrawableModel>>(
                this.DrawableModelsMediumPointer // offset
            );
            this.DrawableModelsLow = reader.ReadBlockAt<ResourcePointerList64<DrawableModel>>(
                this.DrawableModelsLowPointer // offset
            );
            this.DrawableModelsVeryLow = reader.ReadBlockAt<ResourcePointerList64<DrawableModel>>(
                this.DrawableModelsVeryLowPointer // offset
            );
            this.Joints = reader.ReadBlockAt<Joints>(
                this.JointsPointer // offset
            );
            this.DrawableModelsX = reader.ReadBlockAt<ResourcePointerList64<DrawableModel>>(
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
            this.SkeletonPointer = (ulong)(this.Skeleton != null ? this.Skeleton.Position : 0);
            this.DrawableModelsHighPointer = (ulong)(this.DrawableModelsHigh != null ? this.DrawableModelsHigh.Position : 0);
            this.DrawableModelsMediumPointer = (ulong)(this.DrawableModelsMedium != null ? this.DrawableModelsMedium.Position : 0);
            this.DrawableModelsLowPointer = (ulong)(this.DrawableModelsLow != null ? this.DrawableModelsLow.Position : 0);
            this.DrawableModelsVeryLowPointer = (ulong)(this.DrawableModelsVeryLow != null ? this.DrawableModelsVeryLow.Position : 0);
            this.JointsPointer = (ulong)(this.Joints != null ? this.Joints.Position : 0);
            this.DrawableModelsXPointer = (ulong)(this.DrawableModelsX != null ? this.DrawableModelsX.Position : 0);

            // write structure data
            writer.Write(this.SkeletonPointer);
            writer.Write(this.BoundingCenter);
            writer.Write(this.BoundingSphereRadius);
            writer.Write(this.BoundingBoxMin);
            writer.Write(this.BoundingBoxMax);
            writer.Write(this.DrawableModelsHighPointer);
            writer.Write(this.DrawableModelsMediumPointer);
            writer.Write(this.DrawableModelsLowPointer);
            writer.Write(this.DrawableModelsVeryLowPointer);
            writer.Write(this.LodDistanceHigh);
            writer.Write(this.LodDistanceMedium);
            writer.Write(this.LodDistanceLow);
            writer.Write(this.LodDistanceVeryLow);
            writer.Write(this.DrawBucketMaskHigh);
            writer.Write(this.DrawBucketMaskMedium);
            writer.Write(this.DrawBucketMaskLow);
            writer.Write(this.DrawBucketMaskVeryLow);
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
