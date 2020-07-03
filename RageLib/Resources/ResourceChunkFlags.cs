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
        public uint Value { get; set; }

        public ResourceChunk[] Pages
        {
            get
            {
                var count = Count;
                if (count == 0) return null;
                var pages = new ResourceChunk[count];
                var counts = PageCounts;
                var sizes = BaseSizes;
                int n = 0;
                uint o = 0;
                for (int i = 0; i < counts.Length; i++)
                {
                    var c = counts[i];
                    var s = sizes[i];
                    for (int p = 0; p < c; p++)
                    {
                        pages[n] = new ResourceChunk() { Size = s, Offset = o };
                        o += s;
                        n++;
                    }
                }
                return pages;
            }
        }

        public uint TypeVal => (Value >> 28) & 0xF;

        public uint BaseShift => (Value & 0xF);

        public uint BaseSize => (0x200u << (int)BaseShift);

        public uint[] BaseSizes
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

        public uint[] PageCounts
        {
            get
            {
                return new uint[]
                {
                    ((Value >> 4)  & 0x1),
                    ((Value >> 5)  & 0x3),
                    ((Value >> 7)  & 0xF),
                    ((Value >> 11) & 0x3F),
                    ((Value >> 17) & 0x7F),
                    ((Value >> 24) & 0x1),
                    ((Value >> 25) & 0x1),
                    ((Value >> 26) & 0x1),
                    ((Value >> 27) & 0x1),
                };
            }
        }

        public uint[] PageSizes
        {
            get
            {
                var counts = PageCounts;
                var baseSizes = BaseSizes;
                return new uint[]
                {
                    baseSizes[0] * counts[0],
                    baseSizes[1] * counts[1],
                    baseSizes[2] * counts[2],
                    baseSizes[3] * counts[3],
                    baseSizes[4] * counts[4],
                    baseSizes[5] * counts[5],
                    baseSizes[6] * counts[6],
                    baseSizes[7] * counts[7],
                    baseSizes[8] * counts[8],
                };
            }
        }

        public uint Count
        {
            get
            {
                var c = PageCounts;
                return c[0] + c[1] + c[2] + c[3] + c[4] + c[5] + c[6] + c[7] + c[8];
            }
        }

        public uint Size
        {
            get
            {
                var flags = Value;
                var s0 = ((flags >> 27) & 0x1) << 0;
                var s1 = ((flags >> 26) & 0x1) << 1;
                var s2 = ((flags >> 25) & 0x1) << 2;
                var s3 = ((flags >> 24) & 0x1) << 3;
                var s4 = ((flags >> 17) & 0x7F) << 4;
                var s5 = ((flags >> 11) & 0x3F) << 5;
                var s6 = ((flags >> 7) & 0xF) << 6;
                var s7 = ((flags >> 5) & 0x3) << 7;
                var s8 = ((flags >> 4) & 0x1) << 8;
                var ss = ((flags >> 0) & 0xF);
                var baseSize = 0x200u << (int)ss;
                return baseSize * (s0 + s1 + s2 + s3 + s4 + s5 + s6 + s7 + s8);
            }
        }

        public ResourceChunkFlags(uint v)
        {
            Value = v;
        }

        public ResourceChunkFlags(uint[] pageCounts, uint baseShift)
        {
            var v = baseShift & 0xF;
            v += (pageCounts[0] & 0x1) << 4;
            v += (pageCounts[1] & 0x3) << 5;
            v += (pageCounts[2] & 0xF) << 7;
            v += (pageCounts[3] & 0x3F) << 11;
            v += (pageCounts[4] & 0x7F) << 17;
            v += (pageCounts[5] & 0x1) << 24;
            v += (pageCounts[6] & 0x1) << 25;
            v += (pageCounts[7] & 0x1) << 26;
            v += (pageCounts[8] & 0x1) << 27;
            Value = v;
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
