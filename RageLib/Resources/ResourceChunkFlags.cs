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
        private uint _value;
        private static readonly uint[] _bucketsCapacity = new uint[9] { 0x1, 0x3, 0xF, 0x3F, 0x7F, 0x1, 0x1, 0x1, 0x1, };
        private static readonly int[] _bucketsShifts = new int[9] { 4, 5, 7, 11, 17, 24, 25, 26, 27, };

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
                var chunksSizes = ChunksSizes;
                return new uint[]
                {
                    chunksSizes[0] * _bucketsCapacity[0],
                    chunksSizes[1] * _bucketsCapacity[1],
                    chunksSizes[2] * _bucketsCapacity[2],
                    chunksSizes[3] * _bucketsCapacity[3],
                    chunksSizes[4] * _bucketsCapacity[4],
                    chunksSizes[5] * _bucketsCapacity[5],
                    chunksSizes[6] * _bucketsCapacity[6],
                    chunksSizes[7] * _bucketsCapacity[7],
                    chunksSizes[8] * _bucketsCapacity[8],
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
                var bucketsSizesCapacity = BucketsSizesCapacity;
                return bucketsSizesCapacity[0]
                    + bucketsSizesCapacity[1]
                    + bucketsSizesCapacity[2]
                    + bucketsSizesCapacity[3]
                    + bucketsSizesCapacity[4]
                    + bucketsSizesCapacity[5]
                    + bucketsSizesCapacity[6]
                    + bucketsSizesCapacity[7]
                    + bucketsSizesCapacity[8];
            }
        }

        public uint TypeVal => (_value >> 28) & 0xF;

        public uint BaseShift => (_value & 0xF);

        public uint BaseSize => (0x200u << (int)BaseShift);

        /// <summary>
        /// The chunk size for each bucket
        /// </summary>
        public uint[] ChunksSizes
        {
            get
            {
                var baseSize = BaseSize;
                return new uint[]
                {
                    baseSize << 8,
                    baseSize << 7,
                    baseSize << 6,
                    baseSize << 5,
                    baseSize << 4,
                    baseSize << 3,
                    baseSize << 2,
                    baseSize << 1,
                    baseSize << 0,
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
                    (_value >> _bucketsShifts[0]) & _bucketsCapacity[0],
                    (_value >> _bucketsShifts[1]) & _bucketsCapacity[1],
                    (_value >> _bucketsShifts[2]) & _bucketsCapacity[2],
                    (_value >> _bucketsShifts[3]) & _bucketsCapacity[3],
                    (_value >> _bucketsShifts[4]) & _bucketsCapacity[4],
                    (_value >> _bucketsShifts[5]) & _bucketsCapacity[5],
                    (_value >> _bucketsShifts[6]) & _bucketsCapacity[6],
                    (_value >> _bucketsShifts[7]) & _bucketsCapacity[7],
                    (_value >> _bucketsShifts[8]) & _bucketsCapacity[8],
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
                var chunksSizes = ChunksSizes;
                var bucketsCount = BucketsCount;
                return new uint[]
                {
                    chunksSizes[0] * bucketsCount[0],
                    chunksSizes[1] * bucketsCount[1],
                    chunksSizes[2] * bucketsCount[2],
                    chunksSizes[3] * bucketsCount[3],
                    chunksSizes[4] * bucketsCount[4],
                    chunksSizes[5] * bucketsCount[5],
                    chunksSizes[6] * bucketsCount[6],
                    chunksSizes[7] * bucketsCount[7],
                    chunksSizes[8] * bucketsCount[8],
                };
            }
        }

        public uint Count
        {
            get
            {
                var bucketsCount = BucketsCount;
                return bucketsCount[0]
                    + bucketsCount[1]
                    + bucketsCount[2]
                    + bucketsCount[3]
                    + bucketsCount[4]
                    + bucketsCount[5]
                    + bucketsCount[6]
                    + bucketsCount[7]
                    + bucketsCount[8];
            }
        }

        public uint Size
        {
            get
            {
                var bucketsSizes = BucketsSizes;
                return bucketsSizes[0]
                    + bucketsSizes[1]
                    + bucketsSizes[2]
                    + bucketsSizes[3]
                    + bucketsSizes[4]
                    + bucketsSizes[5]
                    + bucketsSizes[6]
                    + bucketsSizes[7]
                    + bucketsSizes[8];
            }
        }

        public ResourceChunkFlags(uint v)
        {
            _value = v;
        }

        public ResourceChunkFlags(uint[] chunksCounts, uint baseShift)
        {
            var v = baseShift & 0xF;
            v += (chunksCounts[0] & _bucketsCapacity[0]) << _bucketsShifts[0];
            v += (chunksCounts[1] & _bucketsCapacity[1]) << _bucketsShifts[1];
            v += (chunksCounts[2] & _bucketsCapacity[2]) << _bucketsShifts[2];
            v += (chunksCounts[3] & _bucketsCapacity[3]) << _bucketsShifts[3];
            v += (chunksCounts[4] & _bucketsCapacity[4]) << _bucketsShifts[4];
            v += (chunksCounts[5] & _bucketsCapacity[5]) << _bucketsShifts[5];
            v += (chunksCounts[6] & _bucketsCapacity[6]) << _bucketsShifts[6];
            v += (chunksCounts[7] & _bucketsCapacity[7]) << _bucketsShifts[7];
            v += (chunksCounts[8] & _bucketsCapacity[8]) << _bucketsShifts[8];
            _value = v;
        }

        public bool CanAddChunk(int bucketIndex) => BucketsCount[bucketIndex] + 1 <= _bucketsCapacity[bucketIndex];

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

                v += (count & _bucketsCapacity[i]) << _bucketsShifts[i];
            }

            _value = v;

            return true;
        }

        public static implicit operator uint(ResourceChunkFlags f)
        {
            return f._value;
        }

        public static implicit operator ResourceChunkFlags(uint v)
        {
            return new ResourceChunkFlags(v);
        }
    }
}
