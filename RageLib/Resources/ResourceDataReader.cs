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

namespace RageLib.Resources
{
    /// <summary>
    /// Represents a resource data reader.
    /// </summary>
    public class ResourceDataReader : DataReader
    {
        private const long VIRTUAL_BASE = 0x50000000;
        private const long PHYSICAL_BASE = 0x60000000;

        private Stream virtualStream;
        private Stream physicalStream;

        // this is a dictionary that contains all the resource blocks
        // which were read from this resource reader
        private Dictionary<long, List<IResourceBlock>> blockPool;

        /// <summary>
        /// Gets the length of the underlying stream.
        /// </summary>
        public override long Length
        {
            get
            {
                return -1;
            }
        }

        /// <summary>
        /// Gets or sets the position within the underlying stream.
        /// </summary>
        public override long Position
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new resource data reader for the specified virtual- and physical-stream.
        /// </summary>
        public ResourceDataReader(Stream virtualStream, Stream physicalStream, Endianess endianess = Endianess.LittleEndian)
            : base((Stream)null, endianess)
        {
            this.virtualStream = virtualStream;
            this.physicalStream = physicalStream;
            this.blockPool = new Dictionary<long, List<IResourceBlock>>();
        }

        /// <summary>
        /// Reads data from the underlying stream. This is the only method that directly accesses
        /// the data in the underlying stream.
        /// </summary>
        protected override byte[] ReadFromStream(int count, bool ignoreEndianess = false)
        {
            if ((Position & VIRTUAL_BASE) == VIRTUAL_BASE)
            {
                // read from virtual stream...

                virtualStream.Position = Position & ~0x50000000;

                var buffer = new byte[count];
                virtualStream.Read(buffer, 0, count);

                // handle endianess
                if (!ignoreEndianess && !endianessEqualsHostArchitecture)
                {
                    Array.Reverse(buffer);
                }

                Position = virtualStream.Position | 0x50000000;
                return buffer;

            }
            if ((Position & PHYSICAL_BASE) == PHYSICAL_BASE)
            {
                // read from physical stream...

                physicalStream.Position = Position & ~0x60000000;

                var buffer = new byte[count];
                physicalStream.Read(buffer, 0, count);

                // handle endianess
                if (!ignoreEndianess && !endianessEqualsHostArchitecture)
                {
                    Array.Reverse(buffer);
                }

                Position = physicalStream.Position | 0x60000000;
                return buffer;
            }
            throw new Exception("illegal position!");
        }

        /// <summary>
        /// Reads a block.
        /// </summary>
        public T ReadBlock<T>(params object[] parameters) where T : IResourceBlock, new()
        {
            // make sure to return the same object if the same
            // block is read again...
            if (blockPool.ContainsKey(Position))
            {
                var blocks = blockPool[Position];
                foreach (var block in blocks)
                    if (block is T)
                    {
                        Position += block.BlockLength;

                        // since a resource block of the same type
                        // has been found at the same address, return it
                        return (T)block;
                    }
#if DEBUG
                    else
                    {
                        // TODO:    Be sure we aren't reading a base class of an object that
                        //          we have already read at the same position as but derived type
                        //          This shouldn't happen, so far only happened if we read
                        //          ShaderParameter Texture data blocks before and then after
                        //          we read TextureDX11 from a texture dictionary embedded in the ShaderGroup
                        //          as the if check above will return false since Texture (in the pool) is not TextureDX11 (but the opposite)
                        //          the result is that the pool will create another block instead of returning the same
                        //          We have to workaround limitation of dealing with managed objects (so we can't just recast the pointer)
                        //          We want to replace it with the new most derived block, and update all the references to it
                        //          Maybe Texture has a field to which specifies which type of Texture it is?
                        //          see https://github.com/carmineos/gta-toolkit/issues/11

                        System.Diagnostics.Debug.Assert(!block.GetType().IsAssignableFrom(typeof(T)));
                    }
#endif
            }

            var result = new T();


            // replace with correct type...
            if (result is IResourceXXSystemBlock)
                result = (T)((IResourceXXSystemBlock)result).GetType(this, parameters);


            // add block to the block pool...
            if (blockPool.ContainsKey(Position))
            {
                blockPool[Position].Add(result);
            }
            else
            {
                var blocks = new List<IResourceBlock>();
                blocks.Add(result);
                blockPool.Add(Position, blocks);
            }

            var classPosition = Position;            
            result.Read(this, parameters);
            result.BlockPosition = classPosition;
            return (T)result;
        }

        /// <summary>
        /// Reads a block at a specified position.
        /// </summary>
        public T ReadBlockAt<T>(ulong position, params object[] parameters) where T : IResourceBlock, new()
        {
            if (position != 0)
            {
                var positionBackup = Position;

                Position = (long)position;
                var result = ReadBlock<T>(parameters);
                Position = positionBackup;

                return result;
            }
            else
            {
                return default(T);
            }
        }        
    }
}