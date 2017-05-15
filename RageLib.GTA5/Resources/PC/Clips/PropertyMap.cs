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

namespace RageLib.Resources.GTA5.PC.Clips
{
    public class PropertyMap : ResourceSystemBlock
    {
        public override long Length => 0x10;

        // structure data
        public ulong PropertyEntriesPointer;
        public ushort PropertyEntriesCount;
        public ushort PropertyEntriesTotalCount;
        public uint Unknown_Ch; // 0x01000000

        // reference data
        public ResourcePointerArray64<PropertyMapEntry> Properties;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.PropertyEntriesPointer = reader.ReadUInt64();
            this.PropertyEntriesCount = reader.ReadUInt16();
            this.PropertyEntriesTotalCount = reader.ReadUInt16();
            this.Unknown_Ch = reader.ReadUInt32();

            // read reference data
            this.Properties = reader.ReadBlockAt<ResourcePointerArray64<PropertyMapEntry>>(
                this.PropertyEntriesPointer, // offset
                this.PropertyEntriesCount
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.PropertyEntriesPointer = (ulong)(this.Properties != null ? this.Properties.Position : 0);
            this.PropertyEntriesCount = (ushort)(this.Properties != null ? this.Properties.Count : 0);
            if (this.Properties != null)
            {
                int i = 0;
                foreach (var x in this.Properties.data_items)
                {
                    if (x != null)
                    {
                        var y = x;
                        do
                        {
                            if (y.Data != null)
                            {
                                i++;
                            }
                            if (y.Next != null)
                            {
                                y = y.Next;
                            }
                            else
                            {
                                break;
                            }
                        } while (true);
                    }
                }
                this.PropertyEntriesTotalCount = (ushort)i;
            }
            else
            {
                this.PropertyEntriesTotalCount = 0;
            }

            // write structure data
            writer.Write(this.PropertyEntriesPointer);
            writer.Write(this.PropertyEntriesCount);
            writer.Write(this.PropertyEntriesTotalCount);
            writer.Write(this.Unknown_Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (Properties != null) list.Add(Properties);
            return list.ToArray();
        }
    }
}
