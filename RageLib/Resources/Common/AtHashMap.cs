using System;
using System.Collections.Generic;

namespace RageLib.Resources.Common
{
    // atHashMap
    public class AtHashMap<T> : ResourceSystemBlock where T : IResourceSystemBlock, new()
    {
        public override long BlockLength => 0x10;

        // structure data
        public ulong Pointer;
        public ushort BucketsCount;
        public ushort Count;
        public ushort Unknown_Ch;
        public byte Unknown_Eh;
        public byte Initialized;

        // reference data
        public ResourcePointerArray64<AtHashMapEntry<T>> Data;

        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.Pointer = reader.ReadUInt64();
            this.BucketsCount = reader.ReadUInt16();
            this.Count = reader.ReadUInt16();
            this.Unknown_Ch = reader.ReadUInt16();
            this.Unknown_Eh = reader.ReadByte();
            this.Initialized = reader.ReadByte();

            // read reference data
            this.Data = reader.ReadBlockAt<ResourcePointerArray64<AtHashMapEntry<T>>>(
                this.Pointer, // offset
                this.BucketsCount
            );
        }

        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.Pointer = (ulong)(this.Data != null ? this.Data.BlockPosition : 0);
            if (this.Data != null)
            {
                int i = 0;
                foreach (var x in this.Data.data_items)
                {
                    if (x != null)
                    {
                        var y = x;
                        do
                        {
                            i++;
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
                this.Count = (ushort)i;
            }
            else
            {
                this.Count = 0;
            }
            this.BucketsCount = (ushort)(this.Data != null ? GetBucketsCount(Count) : 0);

            // write structure data
            writer.Write(this.Pointer);
            writer.Write(this.BucketsCount);
            writer.Write(this.Count);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.Unknown_Eh);
            writer.Write(this.Initialized);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (Data != null) list.Add(Data);
            return list.ToArray();
        }

        public ushort GetBucketsCount(uint hashesCount)
        {
            if (hashesCount < 11) return 11;
            else if (hashesCount < 29) return 29;
            else if (hashesCount < 59) return 59;
            else if (hashesCount < 107) return 107;
            else if (hashesCount < 191) return 191;
            else if (hashesCount < 331) return 331;
            else if (hashesCount < 563) return 563;
            else if (hashesCount < 953) return 953;
            else if (hashesCount < 1609) return 1609;
            else if (hashesCount < 2729) return 2729;
            else if (hashesCount < 4621) return 4621;
            else if (hashesCount < 7841) return 7841;
            else if (hashesCount < 13297) return 13297;
            else if (hashesCount < 22571) return 22571;
            else if (hashesCount < 38351) return 38351;
            else if (hashesCount < 65167) return 65167;
            else if (hashesCount < 65521) return 65521;
            else return 0;
        }
    }

    public class AtHashMapEntry<T> : ResourceSystemBlock where T : IResourceSystemBlock, new()
    {
        public override long BlockLength => 0xC + (Data != null ? Data.BlockLength : 0);

        // structure data
        public uint Hash;
        public T Data;
        public ulong NextPointer;

        // reference data
        public AtHashMapEntry<T> Next;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.Hash = reader.ReadUInt32();
            this.Data = reader.ReadBlock<T>();
            this.NextPointer = reader.ReadUInt64();

            // read reference data
            this.Next = reader.ReadBlockAt<AtHashMapEntry<T>>(
                this.NextPointer // offset
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.NextPointer = (ulong)(this.Next != null ? this.Next.BlockPosition : 0);

            // write structure data
            writer.Write(this.Hash);
            writer.WriteBlock(this.Data);
            writer.Write(this.NextPointer);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (Next != null) list.Add(Next);
            return list.ToArray();
        }
    }
}