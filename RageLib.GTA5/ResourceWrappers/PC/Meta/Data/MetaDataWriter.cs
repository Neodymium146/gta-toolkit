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

using RageLib.Data;
using System;
using System.Collections.Generic;
using System.IO;

namespace RageLib.GTA5.ResourceWrappers.PC.Meta.Data
{
    public class MetaDataBlock
    {
        public int NameHash { get; private set; }
        public Stream Stream { get; private set; }

        public MetaDataBlock(int nameHash, Stream stream)
        {
            this.NameHash = nameHash;
            this.Stream = stream;
        }
    }

    public class MetaDataWriter : DataWriter
    {
        private List<MetaDataBlock> blocks;
        public List<MetaDataBlock> Blocks
        {
            get
            {
                return blocks;
            }
        }

        public int BlocksCount
        {
            get
            {
                return blocks.Count;
            }
        }

        private int blockIndex;
        public int BlockIndex
        {
            get
            {
                return blockIndex;
            }
        }

        public override long Length
        {
            get
            {
                return blocks[BlockIndex].Stream.Length;
            }
        }

        public override long Position
        {
            get
            {
                return blocks[BlockIndex].Stream.Position;
            }

            set
            {
                blocks[BlockIndex].Stream.Position = value;
            }
        }

        public MetaDataWriter() : base(null, Endianess.LittleEndian)
        {
            this.blocks = new List<MetaDataBlock>();
            this.blockIndex = -1;
        }

        public MetaDataWriter(Endianess e) : base(null, e)
        {
            this.blocks = new List<MetaDataBlock>();
            this.blockIndex = -1;
        }

        protected override void WriteToStream(byte[] value, bool ignoreEndianess = true)
        {
            var currentStream = blocks[BlockIndex].Stream;
            if (!ignoreEndianess && (Endianess == Endianess.BigEndian))
            {
                var buffer = (byte[])value.Clone();
                Array.Reverse(buffer);
                currentStream.Write(buffer, 0, buffer.Length);
            }
            else
            {
                currentStream.Write(value, 0, value.Length);
            }
        }

        public void SelectBlockByNameHash(int nameHash)
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                if (blocks[i].NameHash == nameHash && blocks[i].Stream.Length < 0x4000)
                {
                    SelectBlockByIndex(i);
                    return;
                }
            }

            CreateBlockByNameHash(nameHash);
        }

        public void CreateBlockByNameHash(int nameHash)
        {
            var newBlock = new MetaDataBlock(nameHash, new MemoryStream());
            blocks.Add(newBlock);
            SelectBlockByIndex(blocks.Count - 1);
        }

        public void SelectBlockByIndex(int index)
        {
            blockIndex = index;
        }
    }
}
