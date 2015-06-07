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
        public RAGE_Vector4 Unknown_20h;
        public RAGE_Vector4 Unknown_30h;
        public RAGE_Vector4 Unknown_40h;
        public ulong DrawableModels1Pointer;
        public ulong DrawableModels2Pointer;
        public ulong DrawableModels3Pointer;
        public ulong DrawableModels4Pointer;
        public uint Unknown_70h;
        public uint Unknown_74h;
        public uint Unknown_78h;
        public uint Unknown_7Ch;
        public uint Unknown_80h;
        public uint Unknown_84h;
        public uint Unknown_88h;
        public uint Unknown_8Ch;
        public ulong Unknown_90h_Pointer;
        public uint Unknown_98h;
        public uint Unknown_9Ch; // 0x00000000
        public ulong DrawableModelsXPointer;
        
        // reference data
        public ShaderGroup_GTA5_pc ShaderGroup;
        public Skeleton_GTA5_pc Skeleton;
        public ResourcePointerList64<DrawableModel_GTA5_pc> DrawableModels1;
        public ResourcePointerList64<DrawableModel_GTA5_pc> DrawableModels2;
        public ResourcePointerList64<DrawableModel_GTA5_pc> DrawableModels3;
        public ResourcePointerList64<DrawableModel_GTA5_pc> DrawableModels4;
        public Unknown_D_002 Unknown_90h_Data;
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
            this.Unknown_20h = reader.ReadBlock<RAGE_Vector4>();
            this.Unknown_30h = reader.ReadBlock<RAGE_Vector4>();
            this.Unknown_40h = reader.ReadBlock<RAGE_Vector4>();
            this.DrawableModels1Pointer = reader.ReadUInt64();
            this.DrawableModels2Pointer = reader.ReadUInt64();
            this.DrawableModels3Pointer = reader.ReadUInt64();
            this.DrawableModels4Pointer = reader.ReadUInt64();
            this.Unknown_70h = reader.ReadUInt32();
            this.Unknown_74h = reader.ReadUInt32();
            this.Unknown_78h = reader.ReadUInt32();
            this.Unknown_7Ch = reader.ReadUInt32();
            this.Unknown_80h = reader.ReadUInt32();
            this.Unknown_84h = reader.ReadUInt32();
            this.Unknown_88h = reader.ReadUInt32();
            this.Unknown_8Ch = reader.ReadUInt32();
            this.Unknown_90h_Pointer = reader.ReadUInt64();
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
            this.DrawableModels1 = reader.ReadBlockAt<ResourcePointerList64<DrawableModel_GTA5_pc>>(
                this.DrawableModels1Pointer // offset
            );
            this.DrawableModels2 = reader.ReadBlockAt<ResourcePointerList64<DrawableModel_GTA5_pc>>(
                this.DrawableModels2Pointer // offset
            );
            this.DrawableModels3 = reader.ReadBlockAt<ResourcePointerList64<DrawableModel_GTA5_pc>>(
                this.DrawableModels3Pointer // offset
            );
            this.DrawableModels4 = reader.ReadBlockAt<ResourcePointerList64<DrawableModel_GTA5_pc>>(
                this.DrawableModels4Pointer // offset
            );
            this.Unknown_90h_Data = reader.ReadBlockAt<Unknown_D_002>(
                this.Unknown_90h_Pointer // offset
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
            this.DrawableModels1Pointer = (ulong)(this.DrawableModels1 != null ? this.DrawableModels1.Position : 0);
            this.DrawableModels2Pointer = (ulong)(this.DrawableModels2 != null ? this.DrawableModels2.Position : 0);
            this.DrawableModels3Pointer = (ulong)(this.DrawableModels3 != null ? this.DrawableModels3.Position : 0);
            this.DrawableModels4Pointer = (ulong)(this.DrawableModels4 != null ? this.DrawableModels4.Position : 0);
            this.Unknown_90h_Pointer = (ulong)(this.Unknown_90h_Data != null ? this.Unknown_90h_Data.Position : 0);
            this.DrawableModelsXPointer = (ulong)(this.DrawableModelsX != null ? this.DrawableModelsX.Position : 0);
            
            // write structure data
            writer.Write(this.ShaderGroupPointer);
            writer.Write(this.SkeletonPointer);
            writer.WriteBlock(this.Unknown_20h);
            writer.WriteBlock(this.Unknown_30h);
            writer.WriteBlock(this.Unknown_40h);
            writer.Write(this.DrawableModels1Pointer);
            writer.Write(this.DrawableModels2Pointer);
            writer.Write(this.DrawableModels3Pointer);
            writer.Write(this.DrawableModels4Pointer);
            writer.Write(this.Unknown_70h);
            writer.Write(this.Unknown_74h);
            writer.Write(this.Unknown_78h);
            writer.Write(this.Unknown_7Ch);
            writer.Write(this.Unknown_80h);
            writer.Write(this.Unknown_84h);
            writer.Write(this.Unknown_88h);
            writer.Write(this.Unknown_8Ch);
            writer.Write(this.Unknown_90h_Pointer);
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
            if (DrawableModels1 != null) list.Add(DrawableModels1);
            if (DrawableModels2 != null) list.Add(DrawableModels2);
            if (DrawableModels3 != null) list.Add(DrawableModels3);
            if (DrawableModels4 != null) list.Add(DrawableModels4);
            if (Unknown_90h_Data != null) list.Add(Unknown_90h_Data);
            if (DrawableModelsX != null) list.Add(DrawableModelsX);           
            return list.ToArray();
        }
    }
}