using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageLib.Resources
{
    // datResourceChunk
    public struct ResourceChunk
    {
        public ulong Offset { get; set; }
        public ulong Size { get; set; }
    }

    public struct ResourceChunkFlags
    {
        private uint Value;

        /// <summary>
        /// An array of all the chunks
        /// </summary>
        public ResourceChunk[] Chunks
        {
            get
            {
                if (Count == 0)
                    return null;

                var chunks = new ResourceChunk[Count];

                int chunksCount = 0;
                uint offset = 0;

                for (int bucket = 0; bucket < BucketsCount.Length; bucket++)
                {
                    var count = BucketsCount[bucket];
                    var size = ChunksSizes[bucket];

                    for (int chunk = 0; chunk < count; chunk++)
                    {
                        chunks[chunksCount] = new ResourceChunk() { Size = size, Offset = offset };
                        offset += size;
                        chunksCount++;
                    }
                }
                return chunks;
            }
        }

        /// <summary>
        /// The capacity of each bucket
        /// </summary>
        public uint[] BucketsSizesCapacity
        {
            get
            {
                return new uint[]
                {
                    ChunksSizes[0] * BucketsCapacity[0],
                    ChunksSizes[1] * BucketsCapacity[1],
                    ChunksSizes[2] * BucketsCapacity[2],
                    ChunksSizes[3] * BucketsCapacity[3],
                    ChunksSizes[4] * BucketsCapacity[4],
                    ChunksSizes[5] * BucketsCapacity[5],
                    ChunksSizes[6] * BucketsCapacity[6],
                    ChunksSizes[7] * BucketsCapacity[7],
                    ChunksSizes[8] * BucketsCapacity[8],
                };
            }
        }

        /// <summary>
        /// The capacity of all the buckets combined
        /// </summary>
        public uint TotalSizeCapacity
        {
            get
            {
                return BucketsSizesCapacity[0]
                    + BucketsSizesCapacity[1]
                    + BucketsSizesCapacity[2]
                    + BucketsSizesCapacity[3]
                    + BucketsSizesCapacity[4]
                    + BucketsSizesCapacity[5]
                    + BucketsSizesCapacity[6]
                    + BucketsSizesCapacity[7]
                    + BucketsSizesCapacity[8];
            }
        }

        public uint TypeVal => (Value >> 28) & 0xF;

        public uint BaseShift => (Value & 0xF);

        public uint BaseSize => (0x200u << (int)BaseShift);

        /// <summary>
        /// The chunk size for each bucket
        /// </summary>
        public uint[] ChunksSizes
        {
            get
            {
                return new uint[]
                {
                    BaseSize << 8,
                    BaseSize << 7,
                    BaseSize << 6,
                    BaseSize << 5,
                    BaseSize << 4,
                    BaseSize << 3,
                    BaseSize << 2,
                    BaseSize << 1,
                    BaseSize << 0,
                };
            }
        }

        /// <summary>
        /// The number of chunks in each bucket
        /// </summary>
        public uint[] BucketsCount
        {
            get
            {
                return new uint[]
                {
                    (Value >> BucketsShifts[0]) & BucketsCapacity[0],
                    (Value >> BucketsShifts[1]) & BucketsCapacity[1],
                    (Value >> BucketsShifts[2]) & BucketsCapacity[2],
                    (Value >> BucketsShifts[3]) & BucketsCapacity[3],
                    (Value >> BucketsShifts[4]) & BucketsCapacity[4],
                    (Value >> BucketsShifts[5]) & BucketsCapacity[5],
                    (Value >> BucketsShifts[6]) & BucketsCapacity[6],
                    (Value >> BucketsShifts[7]) & BucketsCapacity[7],
                    (Value >> BucketsShifts[8]) & BucketsCapacity[8],
                };
            }
        }

        /// <summary>
        /// The size of each bucket
        /// </summary>
        public uint[] BucketsSizes
        {
            get
            {
                return new uint[]
                {
                    ChunksSizes[0] * BucketsCount[0],
                    ChunksSizes[1] * BucketsCount[1],
                    ChunksSizes[2] * BucketsCount[2],
                    ChunksSizes[3] * BucketsCount[3],
                    ChunksSizes[4] * BucketsCount[4],
                    ChunksSizes[5] * BucketsCount[5],
                    ChunksSizes[6] * BucketsCount[6],
                    ChunksSizes[7] * BucketsCount[7],
                    ChunksSizes[8] * BucketsCount[8],
                };
            }
        }

        public uint Count
        {
            get
            {
                return BucketsCount[0]
                    + BucketsCount[1]
                    + BucketsCount[2]
                    + BucketsCount[3]
                    + BucketsCount[4]
                    + BucketsCount[5]
                    + BucketsCount[6]
                    + BucketsCount[7]
                    + BucketsCount[8];
            }
        }

        public uint Size
        {
            get
            {
                return BucketsSizes[0]
                    + BucketsSizes[1]
                    + BucketsSizes[2]
                    + BucketsSizes[3]
                    + BucketsSizes[4]
                    + BucketsSizes[5]
                    + BucketsSizes[6]
                    + BucketsSizes[7]
                    + BucketsSizes[8];
            }
        }

        public ResourceChunkFlags(uint v)
        {
            Value = v;
        }

        public ResourceChunkFlags(uint[] chunksCounts, uint baseShift)
        {
            var v = baseShift & 0xF;
            v += (chunksCounts[0] & BucketsCapacity[0]) << BucketsShifts[0];
            v += (chunksCounts[1] & BucketsCapacity[1]) << BucketsShifts[1];
            v += (chunksCounts[2] & BucketsCapacity[2]) << BucketsShifts[2];
            v += (chunksCounts[3] & BucketsCapacity[3]) << BucketsShifts[3];
            v += (chunksCounts[4] & BucketsCapacity[4]) << BucketsShifts[4];
            v += (chunksCounts[5] & BucketsCapacity[5]) << BucketsShifts[5];
            v += (chunksCounts[6] & BucketsCapacity[6]) << BucketsShifts[6];
            v += (chunksCounts[7] & BucketsCapacity[7]) << BucketsShifts[7];
            v += (chunksCounts[8] & BucketsCapacity[8]) << BucketsShifts[8];
            Value = v;
        }

        /// <summary>
        /// The number of chunks each bucket can contain
        /// </summary>
        public static readonly uint[] BucketsCapacity = new uint[9] { 0x1, 0x3, 0xF, 0x3F, 0x7F, 0x1, 0x1, 0x1, 0x1, };

        private static readonly int[] BucketsShifts = new int[9] { 4, 5, 7, 11, 17, 24, 25, 26, 27, };

        public bool CanAddChunk(int bucketIndex) => BucketsCount[bucketIndex] + 1 <= BucketsCapacity[bucketIndex];

        public bool TryAddChunk(int bucketIndex)
        {
            if (!CanAddChunk(bucketIndex))
                return false;

            var v = BaseShift & 0xF;

            for (int i = 0; i < 9; i++)
            {
                uint count = BucketsCount[i];
                
                if (i == bucketIndex)
                    count++;

                v += (count & BucketsCapacity[i]) << BucketsShifts[i];
            }

            Value = v;

            return true;
        }

        public static implicit operator uint(ResourceChunkFlags f)
        {
            return f.Value;
        }

        public static implicit operator ResourceChunkFlags(uint v)
        {
            return new ResourceChunkFlags(v);
        }
    }
}
