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
using RageLib.Resources.GTA5.PC.Textures;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace RageLib.Resources.GTA5
{
    public class ResourceFile_GTA5_pc : IResourceFile
    {
        protected const int BASE_SIZE = 0x2000;

        public int Version { get; set; }

        public int SystemPagesDiv16 { get; set; } // 0...1
        public int SystemPagesDiv8 { get; set; } // 0...1
        public int SystemPagesDiv4 { get; set; } // 0...1
        public int SystemPagesDiv2 { get; set; } // 0...1
        public int SystemPagesMul1 { get; set; } // 0...127
        public int SystemPagesMul2 { get; set; } // 0...63
        public int SystemPagesMul4 { get; set; } // 0...15
        public int SystemPagesMul8 { get; set; } // 0...3
        public int SystemPagesMul16 { get; set; } // 0...1
        public int SystemPagesSizeShift { get; set; } // 0..15

        public int GraphicsPagesDiv16 { get; set; } // 0...1
        public int GraphicsPagesDiv8 { get; set; } // 0...1
        public int GraphicsPagesDiv4 { get; set; } // 0...1
        public int GraphicsPagesDiv2 { get; set; } // 0...1
        public int GraphicsPagesMul1 { get; set; } // 0...127
        public int GraphicsPagesMul2 { get; set; } // 0...63
        public int GraphicsPagesMul4 { get; set; } // 0...15
        public int GraphicsPagesMul8 { get; set; } // 0...3
        public int GraphicsPagesMul16 { get; set; } // 0...1
        public int GraphicsPagesSizeShift { get; set; } // 0..15

        public byte[] SystemData { get; set; }
        public byte[] GraphicsData { get; set; }

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
            var systemFlags = reader.ReadUInt32();
            var graphicsFlags = reader.ReadUInt32();

            SystemPagesDiv16 = (int)(systemFlags >> 27) & 0x1;
            SystemPagesDiv8 = (int)(systemFlags >> 26) & 0x1;
            SystemPagesDiv4 = (int)(systemFlags >> 25) & 0x1;
            SystemPagesDiv2 = (int)(systemFlags >> 24) & 0x1;
            SystemPagesMul1 = (int)(systemFlags >> 17) & 0x7F;
            SystemPagesMul2 = (int)(systemFlags >> 11) & 0x3F;
            SystemPagesMul4 = (int)(systemFlags >> 7) & 0xF;
            SystemPagesMul8 = (int)(systemFlags >> 5) & 0x3;
            SystemPagesMul16 = (int)(systemFlags >> 4) & 0x1;
            SystemPagesSizeShift = (int)(systemFlags >> 0) & 0xF;
            var systemBaseSize = BASE_SIZE << SystemPagesSizeShift;
            var systemSize =
                systemBaseSize * SystemPagesDiv16 / 16 +
                systemBaseSize * SystemPagesDiv8 / 8 +
                systemBaseSize * SystemPagesDiv4 / 4 +
                systemBaseSize * SystemPagesDiv2 / 2 +
                systemBaseSize * SystemPagesMul1 * 1 +
                systemBaseSize * SystemPagesMul2 * 2 +
                systemBaseSize * SystemPagesMul4 * 4 +
                systemBaseSize * SystemPagesMul8 * 8 +
                systemBaseSize * SystemPagesMul16 * 16;

            GraphicsPagesDiv16 = (int)(graphicsFlags >> 27) & 0x1;
            GraphicsPagesDiv8 = (int)(graphicsFlags >> 26) & 0x1;
            GraphicsPagesDiv4 = (int)(graphicsFlags >> 25) & 0x1;
            GraphicsPagesDiv2 = (int)(graphicsFlags >> 24) & 0x1;
            GraphicsPagesMul1 = (int)(graphicsFlags >> 17) & 0x7F;
            GraphicsPagesMul2 = (int)(graphicsFlags >> 11) & 0x3F;
            GraphicsPagesMul4 = (int)(graphicsFlags >> 7) & 0xF;
            GraphicsPagesMul8 = (int)(graphicsFlags >> 5) & 0x3;
            GraphicsPagesMul16 = (int)(graphicsFlags >> 4) & 0x1;
            GraphicsPagesSizeShift = (int)(graphicsFlags >> 0) & 0xF;
            var graphicsBaseSize = BASE_SIZE << GraphicsPagesSizeShift;
            var graphicsSize =
                graphicsBaseSize * GraphicsPagesDiv16 / 16 +
                graphicsBaseSize * GraphicsPagesDiv8 / 8 +
                graphicsBaseSize * GraphicsPagesDiv4 / 4 +
                graphicsBaseSize * GraphicsPagesDiv2 / 2 +
                graphicsBaseSize * GraphicsPagesMul1 * 1 +
                graphicsBaseSize * GraphicsPagesMul2 * 2 +
                graphicsBaseSize * GraphicsPagesMul4 * 4 +
                graphicsBaseSize * GraphicsPagesMul8 * 8 +
                graphicsBaseSize * GraphicsPagesMul16 * 16;

            SystemData = new byte[systemSize];
            GraphicsData = new byte[graphicsSize];

            var deflateStream = new DeflateStream(stream, CompressionMode.Decompress, true);
            deflateStream.Read(SystemData, 0, systemSize);
            deflateStream.Read(GraphicsData, 0, graphicsSize);
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

            uint systemFlags = 0;
            systemFlags |= (uint)((Version >> 4) & 0x0F) << 28;
            systemFlags |= (uint)SystemPagesDiv16 << 27;
            systemFlags |= (uint)SystemPagesDiv8 << 26;
            systemFlags |= (uint)SystemPagesDiv4 << 25;
            systemFlags |= (uint)SystemPagesDiv2 << 24;
            systemFlags |= (uint)SystemPagesMul1 << 17;
            systemFlags |= (uint)SystemPagesMul2 << 11;
            systemFlags |= (uint)SystemPagesMul4 << 7;
            systemFlags |= (uint)SystemPagesMul8 << 5;
            systemFlags |= (uint)SystemPagesMul16 << 4;
            systemFlags |= (uint)SystemPagesSizeShift;

            uint graphicsFlags = 0;
            graphicsFlags |= (uint)((Version >> 0) & 0x0F) << 28;
            graphicsFlags |= (uint)GraphicsPagesDiv16 << 27;
            graphicsFlags |= (uint)GraphicsPagesDiv8 << 26;
            graphicsFlags |= (uint)GraphicsPagesDiv4 << 25;
            graphicsFlags |= (uint)GraphicsPagesDiv2 << 24;
            graphicsFlags |= (uint)GraphicsPagesMul1 << 17;
            graphicsFlags |= (uint)GraphicsPagesMul2 << 11;
            graphicsFlags |= (uint)GraphicsPagesMul4 << 7;
            graphicsFlags |= (uint)GraphicsPagesMul8 << 5;
            graphicsFlags |= (uint)GraphicsPagesMul16 << 4;
            graphicsFlags |= (uint)GraphicsPagesSizeShift;

            writer.Write((uint)0x37435352);
            writer.Write((int)Version);
            writer.Write((uint)systemFlags);
            writer.Write((uint)graphicsFlags);

            var deflateStream = new DeflateStream(stream, CompressionMode.Compress, true);
            deflateStream.Write(SystemData, 0, SystemData.Length);
            deflateStream.Write(GraphicsData, 0, GraphicsData.Length);
            deflateStream.Flush();
            deflateStream.Close();
        }
    }

    public class ResourceFile_GTA5_pc<T> : ResourceFile_GTA5_pc, IResourceFile<T> where T : IResourceBlock, new()
    {
        public T ResourceData { get; set; }

        public override void Load(Stream stream)
        {
            base.Load(stream);

            var systemStream = new MemoryStream(SystemData);
            var graphicsStream = new MemoryStream(GraphicsData);
            var resourceStream = new ResourceDataReader(systemStream, graphicsStream);
            resourceStream.Position = 0x50000000;

            ResourceData = resourceStream.ReadBlock<T>();           
        }

        public override void Save(Stream stream)
        {
            IList<IResourceBlock> systemBlocks;
            IList<IResourceBlock> graphicBlocks;
            ResourceHelpers.GetBlocks(ResourceData, out systemBlocks, out graphicBlocks);

            int systemPageSize = BASE_SIZE;
            int systemPageCount;
            ResourceHelpers.AssignPositions(systemBlocks, 0x50000000, ref systemPageSize, out systemPageCount);

            int graphicsPageSize = BASE_SIZE;
            int graphicsPageCount;
            ResourceHelpers.AssignPositions(graphicBlocks, 0x60000000, ref graphicsPageSize, out graphicsPageCount);





            var resBlock = (IResourceBlock)ResourceData;
            var fileBase = (FileBase64_GTA5_pc)resBlock;
            fileBase.PagesInfo = new PagesInfo_GTA5_pc();
            fileBase.PagesInfo.SystemPagesCount = 0;
            if (systemPageCount > 0)
                fileBase.PagesInfo.SystemPagesCount = 1;
            fileBase.PagesInfo.GraphicsPagesCount = (byte)graphicsPageCount;




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






            

            SystemPagesDiv16 = 0;
            SystemPagesDiv8 = 0;
            SystemPagesDiv4 = 0;
            SystemPagesDiv2 = 0;
         //   SystemPagesMul1 = (int)systemPageCount;
            SystemPagesMul1 = 1;
            SystemPagesMul2 = 0;
            SystemPagesMul4 = 0;
            SystemPagesMul8 = 0;
            SystemPagesMul16 = 0;
            SystemPagesSizeShift = 0;
            var realSizeC = 0x2000;
            while (realSizeC < systemStream.Length)
            {
                realSizeC *= 2;
                SystemPagesSizeShift++;
            }
            //SystemPagesSizeShift = 0;
            //var realSizeC = 0x2000;
            //while (realSizeC != systemPageSize)
            //{
            //    realSizeC *= 2;
            //    SystemPagesSizeShift++;
            //}

             var sysBuf = new byte[realSizeC];
            //var sysBuf = new byte[SystemPagesMul1 * realSizeC];
            systemStream.Flush();
            systemStream.Position = 0;
            systemStream.Read(sysBuf, 0, (int)systemStream.Length);
            SystemData = sysBuf;





            GraphicsPagesDiv16 = 0;
            GraphicsPagesDiv8 = 0;
            GraphicsPagesDiv4 = 0;
            GraphicsPagesDiv2 = 0;
            GraphicsPagesMul1 = (int)graphicsPageCount;
         //   GraphicsPagesMul1 = 1;
            GraphicsPagesMul2 = 0;
            GraphicsPagesMul4 = 0;
            GraphicsPagesMul8 = 0;
            GraphicsPagesMul16 = 0;
            //GraphicsPagesSizeShift = 0;
            //var realSizeG = 0x2000;
            //while (realSizeG < graphicsStream.Length)
            //{
            //    realSizeG *= 2;
            //    GraphicsPagesSizeShift++;
            //}
            GraphicsPagesSizeShift = 0;
            var realSizeG = 0x2000;
            while (realSizeG != graphicsPageSize)
            {
                realSizeG *= 2;
                GraphicsPagesSizeShift++;
            }

            //var gfxBuf = new byte[realSizeG];
            var gfxBuf = new byte[GraphicsPagesMul1 * realSizeG];
            graphicsStream.Flush();
            graphicsStream.Position = 0;
            graphicsStream.Read(gfxBuf, 0, (int)graphicsStream.Length);
            GraphicsData = gfxBuf;

            base.Save(stream);
        }        
    }
}