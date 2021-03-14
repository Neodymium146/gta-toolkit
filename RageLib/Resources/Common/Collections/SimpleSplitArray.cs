using System.Collections.Generic;

namespace RageLib.Resources.Common
{
    // aiSplitArray<T, C>
    // C is used as max capacity of each SplitArrayPart<T>
    // C = 16.384 / size of (T)
    // Examples: 
    //          aiSplitArray<CNavMeshCompressedVertex,2730>
    //          aiSplitArray<TAdjPoly,2048>
    //          aiSplitArray<ushort,8192>
    //          aiSplitArray<TNavMeshPoly,341>
    public class SimpleSplitArray<T> : ResourceSystemBlock where T : unmanaged
    {
        public override long BlockLength => 0x30;

        // structure data
        public ulong VFT;
        public uint EntriesCount;
        public uint Unknown_Ch; // 0x00000000
        public ulong PartsPointer;
        public ulong OffsetsPointer;
        public uint PartsCount;
        public uint Unknown_24h; // 0x00000000
        public uint Unknown_28h; // 0x00000000
        public uint Unknown_2Ch; // 0x00000000

        // reference data
        public ResourceSimpleArray<SimpleSplitArrayPart<T>> Parts;
        public SimpleArray<uint> Offsets;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.VFT = reader.ReadUInt64();
            this.EntriesCount = reader.ReadUInt32();
            this.Unknown_Ch = reader.ReadUInt32();
            this.PartsPointer = reader.ReadUInt64();
            this.OffsetsPointer = reader.ReadUInt64();
            this.PartsCount = reader.ReadUInt32();
            this.Unknown_24h = reader.ReadUInt32();
            this.Unknown_28h = reader.ReadUInt32();
            this.Unknown_2Ch = reader.ReadUInt32();

            // read reference data
            this.Parts = reader.ReadBlockAt<ResourceSimpleArray<SimpleSplitArrayPart<T>>>(
                this.PartsPointer, // offset
                this.PartsCount
            );
            this.Offsets = reader.ReadBlockAt<SimpleArray<uint>>(
                this.OffsetsPointer, // offset
                this.PartsCount
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.PartsPointer = (ulong)(this.Parts != null ? this.Parts.BlockPosition : 0);
            this.OffsetsPointer = (ulong)(this.Offsets != null ? this.Offsets.BlockPosition : 0);
            this.PartsCount = (uint)(this.Parts != null ? this.Parts.Count : 0);

            // write structure data
            writer.Write(this.VFT);
            writer.Write(this.EntriesCount);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.PartsPointer);
            writer.Write(this.OffsetsPointer);
            writer.Write(this.PartsCount);
            writer.Write(this.Unknown_24h);
            writer.Write(this.Unknown_28h);
            writer.Write(this.Unknown_2Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (Parts != null) list.Add(Parts);
            if (Offsets != null) list.Add(Offsets);
            return list.ToArray();
        }
    }

    public class SimpleSplitArrayPart<T> : ResourceSystemBlock where T : unmanaged
    {
        public override long BlockLength => 0x10;

        // structure data
        public ulong Pointer;
        public uint Count;
        public uint Unknown_Ch; // 0x00000000

        // reference data
        public SimpleArray<T> Entries;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.Pointer = reader.ReadUInt64();
            this.Count = reader.ReadUInt32();
            this.Unknown_Ch = reader.ReadUInt32();

            // read reference data
            this.Entries = reader.ReadBlockAt<SimpleArray<T>>(
                this.Pointer, // offset
                this.Count
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.Pointer = (ulong)(this.Entries != null ? this.Entries.BlockPosition : 0);
            this.Count = (uint)(this.Entries != null ? this.Entries.Count : 0);

            // write structure data
            writer.Write(this.Pointer);
            writer.Write(this.Count);
            writer.Write(this.Unknown_Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (Entries != null) list.Add(Entries);
            return list.ToArray();
        }
    }
}
