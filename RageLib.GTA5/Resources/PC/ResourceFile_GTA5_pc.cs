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

using RageLib.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace RageLib.Resources.GTA5
{
    // datResourceInfo
    public struct ResourceInfo
    {
        public ResourceChunkFlags VirtualFlags { get; set; }
        public ResourceChunkFlags PhysicalFlags { get; set; }
    }

    // datResourceFileHeader
    public struct ResourceFileHeader
    {
        public int Id;
        public int Version;
        public ResourceInfo ResourceInfo;
    }

    // TODO: refactor everywhere to include ResourceFileHeader
    public class ResourceFile_GTA5_pc : IResourceFile
    {
        protected const int RESOURCE_IDENT = 0x37435352;

        public int Version { get; set; }

        public ResourceInfo ResourceInfo { get; set; }

        public byte[] VirtualData { get; set; }
        public byte[] PhysicalData { get; set; }

        public void Load(string fileName)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Open))
                Load(fileStream);
        }

        public virtual void Load(Stream stream)
        {
            var reader = new DataReader(stream);
            reader.Position = 0;

            var ident = reader.ReadUInt32();
            Version = reader.ReadInt32();
            ResourceChunkFlags virtualPageFlags = reader.ReadUInt32();
            ResourceChunkFlags physicalPageFlags = reader.ReadUInt32();

            ResourceInfo = new ResourceInfo()
            {
                VirtualFlags = virtualPageFlags,
                PhysicalFlags = physicalPageFlags
            };

            VirtualData = new byte[virtualPageFlags.Size];
            PhysicalData = new byte[physicalPageFlags.Size];

            var deflateStream = new DeflateStream(stream, CompressionMode.Decompress, true);
            deflateStream.Read(VirtualData, 0, (int)virtualPageFlags.Size);
            deflateStream.Read(PhysicalData, 0, (int)physicalPageFlags.Size);
            deflateStream.Close();
        }

        public void Save(string fileName)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Create))
                Save(fileStream);
        }

        public virtual void Save(Stream stream)
        {
            var writer = new DataWriter(stream);

            writer.Write((uint)0x37435352);
            writer.Write((int)Version);
            writer.Write((uint)ResourceInfo.VirtualFlags);
            writer.Write((uint)ResourceInfo.PhysicalFlags);

            var deflateStream = new DeflateStream(stream, CompressionMode.Compress, true);
            deflateStream.Write(VirtualData, 0, VirtualData.Length);
            deflateStream.Write(PhysicalData, 0, PhysicalData.Length);
            deflateStream.Flush();
            deflateStream.Close();
        }

        public static bool IsResourceFile(string fileName)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Open))
            {
                var reader = new DataReader(fileStream);
                var ident = reader.ReadInt32();
                return ident == RESOURCE_IDENT;
            }
        }
    }

    public class ResourceFile_GTA5_pc<T> : ResourceFile_GTA5_pc, IResourceFile<T> where T : IResourceBlock, new()
    {
        public T ResourceData { get; set; }

        public override void Load(Stream stream)
        {
            base.Load(stream);

            var systemStream = new MemoryStream(VirtualData);
            var graphicsStream = new MemoryStream(PhysicalData);
            var resourceStream = new ResourceDataReader(systemStream, graphicsStream);
            resourceStream.Position = 0x50000000;

            ResourceData = resourceStream.ReadBlock<T>();           
        }

        public override void Save(Stream stream)
        {
            var resBlock = (IResourceBlock)ResourceData;
            var fileBase = (FileBase64_GTA5_pc)resBlock;

            // Create a temp datResourceMap
            fileBase.PagesInfo = new PagesInfo_GTA5_pc(64, 64);

            ResourceHelpers.GetBlocks(ResourceData, out IList<IResourceBlock> systemBlocks, out IList<IResourceBlock> graphicBlocks);

            ResourceHelpers.AssignPositions(systemBlocks, 0x50000000, out ResourceChunkFlags virtualPageFlags, 0);
            
            ResourceHelpers.AssignPositions(graphicBlocks, 0x60000000, out ResourceChunkFlags physicalPageFlags, virtualPageFlags.Count);

            fileBase.PagesInfo.VirtualPagesCount = (byte)virtualPageFlags.Count;
            fileBase.PagesInfo.PhysicalPagesCount = (byte)physicalPageFlags.Count;

            // Add version to the flags
            virtualPageFlags = virtualPageFlags.Value + ((((uint)Version >> 4) & 0xF) << 28);
            physicalPageFlags = physicalPageFlags.Value + ((((uint)Version >> 0) & 0xF) << 28);

            ResourceInfo = new ResourceInfo()
            {
                VirtualFlags = virtualPageFlags,
                PhysicalFlags = physicalPageFlags
            };

            ////////////////////////////////////////////////////////////////////////////
            // data to byte-array
            ////////////////////////////////////////////////////////////////////////////

            var systemStream = new MemoryStream();
            var graphicsStream = new MemoryStream();
            var resourceWriter = new ResourceDataWriter(systemStream, graphicsStream);

            resourceWriter.Position = 0x50000000;
            foreach (var block in systemBlocks)
            {
                resourceWriter.Position = block.Position;

                var pos_before = resourceWriter.Position;
                block.Write(resourceWriter);
                var pos_after = resourceWriter.Position;

                if ((pos_after - pos_before) != block.Length)
                {
                    throw new Exception("error in system length");
                }
            }

            resourceWriter.Position = 0x60000000;
            foreach (var block in graphicBlocks)
            {
                resourceWriter.Position = block.Position;

                var pos_before = resourceWriter.Position;
                block.Write(resourceWriter);
                var pos_after = resourceWriter.Position;

                if ((pos_after - pos_before) != block.Length)
                {
                    throw new Exception("error in graphics length");
                }
            }

            var sysBuf = new byte[virtualPageFlags.Size];
            systemStream.Flush();
            systemStream.Position = 0;
            systemStream.Read(sysBuf, 0, (int)systemStream.Length);
            VirtualData = sysBuf;

            var gfxBuf = new byte[physicalPageFlags.Size];
            graphicsStream.Flush();
            graphicsStream.Position = 0;
            graphicsStream.Read(gfxBuf, 0, (int)graphicsStream.Length);
            PhysicalData = gfxBuf;

            base.Save(stream);
        }        
    }
}