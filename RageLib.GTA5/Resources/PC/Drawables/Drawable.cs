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
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Drawables
{
    // rmcDrawable
    public class Drawable : DrawableBase
    {
        public override long BlockLength => 0xA8;

        // structure data
        public ulong SkeletonPointer;
        public LodGroup LodGroup;
        public ulong JointsPointer;
        public ushort Unknown_98h;
        public ushort Unknown_9Ah;
        public uint Unknown_9Ch; // 0x00000000
        public ulong PrimaryDrawableModelsPointer;

        // reference data
        public SkeletonData Skeleton;
        public Joints Joints;
        public ResourcePointerList64<DrawableModel> PrimaryDrawableModels;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.SkeletonPointer = reader.ReadUInt64();
            this.LodGroup = reader.ReadBlock<LodGroup>();
            this.JointsPointer = reader.ReadUInt64();
            this.Unknown_98h = reader.ReadUInt16();
            this.Unknown_9Ah = reader.ReadUInt16();
            this.Unknown_9Ch = reader.ReadUInt32();
            this.PrimaryDrawableModelsPointer = reader.ReadUInt64();

            // read reference data
            this.Skeleton = reader.ReadBlockAt<SkeletonData>(
                this.SkeletonPointer // offset
            );
            this.Joints = reader.ReadBlockAt<Joints>(
                this.JointsPointer // offset
            );
            this.PrimaryDrawableModels = reader.ReadBlockAt<ResourcePointerList64<DrawableModel>>(
                this.PrimaryDrawableModelsPointer // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.SkeletonPointer = (ulong)(this.Skeleton != null ? this.Skeleton.BlockPosition : 0);
            this.JointsPointer = (ulong)(this.Joints != null ? this.Joints.BlockPosition : 0);
            this.PrimaryDrawableModelsPointer = (ulong)(this.PrimaryDrawableModels != null ? this.PrimaryDrawableModels.BlockPosition : 0);

            // write structure data
            writer.Write(this.SkeletonPointer);
            writer.WriteBlock(this.LodGroup);
            writer.Write(this.JointsPointer);
            writer.Write(this.Unknown_98h);
            writer.Write(this.Unknown_9Ah);
            writer.Write(this.Unknown_9Ch);
            writer.Write(this.PrimaryDrawableModelsPointer);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>(base.GetReferences());
            if (Skeleton != null) list.Add(Skeleton);
            if (Joints != null) list.Add(Joints);
            if (PrimaryDrawableModels != null) list.Add(PrimaryDrawableModels);
            return list.ToArray();
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(0x20, LodGroup)
            };
        }
    }
}
