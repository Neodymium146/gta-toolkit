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

using System;
using System.Collections.Generic;
using System.Linq;

namespace RageLib.Resources
{
    // TODO: make pgRscBuilder class
    public static class ResourceHelpers
    {
        private const int BASE_SIZE = 0x2000;
        private const int SKIP_SIZE = 16;
        private const int ALIGN_SIZE = 16;


        //private static void GetPagesFromFlags(
        //    int flags,
        //    out int pagesDiv16,
        //    out int pagesDiv8,
        //    out int pagesDiv4,
        //    out int pagesDiv2,
        //    out int pagesMul1,
        //    out int pagesMul2,
        //    out int pagesMul4,
        //    out int pagesMul8,
        //    out int pagesMul16,
        //    out int pagesSizeShift)
        //{
        //    pagesDiv16 = (int)(flags >> 27) & 0x1;
        //    pagesDiv8 = (int)(flags >> 26) & 0x1;
        //    pagesDiv4 = (int)(flags >> 25) & 0x1;
        //    pagesDiv2 = (int)(flags >> 24) & 0x1;
        //    pagesMul1 = (int)(flags >> 17) & 0x7F;
        //    pagesMul2 = (int)(flags >> 11) & 0x3F;
        //    pagesMul4 = (int)(flags >> 7) & 0xF;
        //    pagesMul8 = (int)(flags >> 5) & 0x3;
        //    pagesMul16 = (int)(flags >> 4) & 0x1;
        //    pagesSizeShift = (int)(flags >> 0) & 0xF;
        //}

        //private static int GetFlagsFromPages(
        //    int pagesDiv16,
        //    int pagesDiv8,
        //    int pagesDiv4,
        //    int pagesDiv2,
        //    int pagesMul1,
        //    int pagesMul2,
        //    int pagesMul4,
        //    int pagesMul8,
        //    int pagesMul16,
        //    int pagesSizeShift)
        //{
        //    if (pagesDiv16 < 0 || pagesDiv16 > 1) throw new Exception("Illegal number of pages.");
        //    if (pagesDiv8 < 0 || pagesDiv8 > 1) throw new Exception("Illegal number of pages.");
        //    if (pagesDiv4 < 0 || pagesDiv4 > 1) throw new Exception("Illegal number of pages.");
        //    if (pagesDiv2 < 0 || pagesDiv2 > 1) throw new Exception("Illegal number of pages.");
        //    if (pagesMul1 < 0 || pagesMul1 > 127) throw new Exception("Illegal number of pages.");
        //    if (pagesMul2 < 0 || pagesMul2 > 63) throw new Exception("Illegal number of pages.");
        //    if (pagesMul4 < 0 || pagesMul4 > 15) throw new Exception("Illegal number of pages.");
        //    if (pagesMul8 < 0 || pagesMul8 > 3) throw new Exception("Illegal number of pages.");
        //    if (pagesMul16 < 0 || pagesMul16 > 1) throw new Exception("Illegal number of pages.");

        //    int flags = 0;
        //    flags |= pagesDiv16 << 27;
        //    flags |= pagesDiv8 << 26;
        //    flags |= pagesDiv4 << 25;
        //    flags |= pagesDiv2 << 24;
        //    flags |= pagesMul1 << 17;
        //    flags |= pagesMul2 << 11;
        //    flags |= pagesMul4 << 7;
        //    flags |= pagesMul8 << 5;
        //    flags |= pagesMul16 << 4;
        //    flags |= pagesSizeShift;
        //    return flags;
        //}

        public class ResourceBuilderBlockSet
        {
            private readonly Dictionary<long,LinkedList<IResourceBlock>> buckets;
            private List<long> _orderedKeys;
            private int _count;
            
            public IResourceBlock RootBlock = null;
            public int Count => _count;

            public IResourceBlock GetBestBlock(long size)
            {
                if (size == 0) return null;
                
                long bucketKey = 0;
                LinkedList<IResourceBlock> bucketValue = null;

                // If there is a bucket for blocks of the exact requested size
                if (buckets.TryGetValue(size, out LinkedList<IResourceBlock> bucket))
                {
                    bucketKey = size;
                    bucketValue = bucket;
                }
                else
                {
                    // Iterate the ordered keys until we find a buckets for blocks of size less or equal to the requested size
                    foreach (var key in _orderedKeys)
                    {
                        if (key > size)
                            continue;

                        bucketValue = buckets[key];
                        bucketKey = key;
                        break;
                    }
                }

                // In case no bucket is found, then we have no block to fit the requested size
                if (bucketValue is null)
                    return null;

                // Get the block
                var lastNode = bucketValue.Last;
                bucketValue.RemoveLast();
                _count--;

                // If such bucket hasn't any block left, remove it and update ordered keys
                if (bucketValue.Count == 0)
                {
                    buckets.Remove(bucketKey);
                    _orderedKeys.Remove(bucketKey);
                }

                return lastNode.Value;
            }

            public ResourceBuilderBlockSet(IList<IResourceBlock> blocks, bool hasRootBlock)
            {
                if (blocks.Count < 1)
                    return;

                int indexStart = 0;

                _count = blocks.Count;

                if (hasRootBlock)
                {
                    RootBlock = blocks[0];
                    indexStart = 1;
                    _count--;
                }

                buckets = new Dictionary<long, LinkedList<IResourceBlock>>();

                for (int i = indexStart; i < blocks.Count; i++)
                {
                    var block = blocks[i];
                    long bucketKey = block.BlockLength;

                    if (buckets.TryGetValue(bucketKey, out LinkedList<IResourceBlock> bucketValue))
                        bucketValue.AddLast(block);
                    else
                    {
                        var linkedList = new LinkedList<IResourceBlock>();
                        linkedList.AddLast(block);
                        buckets[bucketKey] = linkedList;
                    }
                }

                _orderedKeys = buckets.Keys.ToList();
                _orderedKeys.Sort((a, b) => b.CompareTo(a));
                
                // Because of central limit theorem the function of the block-size will have a normal distribution,
                // with average being around 32 bytes (and a very small variance), so some buckets will still be too much long compared to the others
                // So using the buckets approach increased a lot the performances, but it's not the optimal case.
                // A better approach would be to have a bucket for each different size,
                // which in the worst case would require to have a number of checks equals to the number of different sizes
                // this number of sizes seems always be a very small amount (not even 100 in core.ypt which is the asset with the highest amount of blocks),
                // but once we have our bucket we can just pick the tail/head item
                // compared to the actual approach which allows to access a bucket in constant time but the number of elements to iterate in such bucket could be still very high!

                // So the idea is to use something like 
                // Dictionary<long,LinkedList<IResourceBlock>> Buckets
                // And have a property to cache keys collection sorted which removes the specific key when a buckets has sorted all its blocks
            }
        }

        private static long Pad(long p)
        {
            return ((ALIGN_SIZE - (p % ALIGN_SIZE)) % ALIGN_SIZE);
        }

        public static void RebuildBlocks(IResourceBlock rootBlock)
        {
            var processed = new HashSet<IResourceBlock>();

            void RebuildChildren(IResourceBlock block)
            {
                if (block is IResourceSystemBlock sblock)
                {
                    if (processed.Add(block))
                    {
                        var references = sblock.GetReferences();
                        foreach (var reference in references)
                        {
                            RebuildChildren(reference);
                        }

                        var parts = sblock.GetParts();
                        foreach (var part in parts)
                        {
                            RebuildChildren(part.Item2);
                        }

                        sblock.Rebuild();
                    }
                }
            }

            RebuildChildren(rootBlock);
        }

        public static void GetBlocks(IResourceBlock rootBlock, out IList<IResourceBlock> sys, out IList<IResourceBlock> gfx)
        {
            var systemBlocks = new HashSet<IResourceBlock>();
            var graphicBlocks = new HashSet<IResourceBlock>();
            var processed = new HashSet<IResourceBlock>();


            void addBlock(IResourceBlock block)
            {
                if (block is IResourceSystemBlock)
                {
                    systemBlocks.Add(block);
                }
                else if (block is IResourceGraphicsBlock)
                {
                    graphicBlocks.Add(block);
                }
            }
            void addChildren(IResourceBlock block)
            {
                if (block is IResourceSystemBlock sblock)
                {
                    var references = sblock.GetReferences();
                    foreach (var reference in references)
                    {
                        if (processed.Add(reference))
                        {
                            addBlock(reference);
                            addChildren(reference);
                        }
                    }
                    var parts = sblock.GetParts();
                    foreach (var part in parts)
                    {
                        addChildren(part.Item2);
                    }
                }
            }

            addBlock(rootBlock);
            addChildren(rootBlock);

            sys = new List<IResourceBlock>(systemBlocks);
            gfx = new List<IResourceBlock>(graphicBlocks);
        }

        public static void AssignPositions(IList<IResourceBlock> blocks, uint basePosition, out ResourceChunkFlags flags, uint usedPages)
        {
            flags = new ResourceChunkFlags();

            if (blocks.Count <= 0)
            {
                return;
            }

            long largestBlockSize = 0; // find largest structure
            long startPageSize = BASE_SIZE;// 0x2000; // find starting page size
            long totalBlockSize = 0;

            foreach (var block in blocks)
            {
                // Get size of all blocks padded
                var blockLength = block.BlockLength;
                totalBlockSize += blockLength;
                totalBlockSize += Pad(totalBlockSize);

                // Get biggest block
                if (largestBlockSize < blockLength)
                {
                    largestBlockSize = blockLength;
                }
            }

            // Get minimum page size to contain biggest block
            while (startPageSize < largestBlockSize)
            {
                startPageSize *= 2;
            }

            var pageSizeMult = 1;
            long currentPosition;

            var sys = (basePosition == 0x50000000);
            bool invalidLayout;

            do
            {
                invalidLayout = false;
                var blockset = new ResourceBuilderBlockSet(blocks, sys);
                var rootblock = blockset.RootBlock;
                currentPosition = 0L;
                var currentPageSize = startPageSize;
                var currentPageStart = 0L;
                var currentPageSpace = startPageSize;
                long currentRemainder = totalBlockSize;
                var bucketIndex = 0;
                var targetPageSize = Math.Max(65536 * pageSizeMult, startPageSize >> (sys ? 5 : 2));
                var minPageSize = Math.Max(512 * pageSizeMult, Math.Min(targetPageSize, startPageSize) >> 4);
                var baseShift = 0u;
                var baseSize = 512;

                while (baseSize < minPageSize)
                {
                    baseShift++;
                    baseSize *= 2;
                    if (baseShift >= 0xF) break;
                }

                flags = new ResourceChunkFlags(new uint[9], baseShift);

                var baseSizeMax = baseSize << 8;
                var baseSizeMaxTest = startPageSize;

                while (baseSizeMaxTest < baseSizeMax)
                {
                    bucketIndex++;
                    baseSizeMaxTest *= 2;
                }

                if (!flags.TryAddChunk(bucketIndex))
                    break;

                while (blockset.Count > 0)
                {
                    var isroot = sys && (currentPosition == 0);
                    var block = isroot ? rootblock : blockset.GetBestBlock(currentPageSpace);

                    // If there is no block to fit in space left
                    if (block == null)
                    {
                        //allocate a new page
                        currentPageStart += currentPageSize;
                        currentPosition = currentPageStart;

                        // Get the biggest block
                        block = blockset.GetBestBlock(long.MaxValue);
                        var blockLength = block?.BlockLength ?? 0;

                        // Get the smallest page which can contain the block
                        while (blockLength <= (currentPageSize >> 1))
                        {
                            if (currentPageSize <= minPageSize) break;
                            if (bucketIndex >= 8) break;
                            if ((currentPageSize <= targetPageSize) && (currentRemainder >= (currentPageSize - minPageSize))) break;

                            currentPageSize = currentPageSize >> 1;
                            bucketIndex++;
                        }

                        currentPageSpace = currentPageSize;

                        // Try adding another chunk to this bucket
                        if (!flags.TryAddChunk(bucketIndex))
                        {
                            invalidLayout = true;
                            break;
                        }
                    }

                    //add this block to the current page.
                    block.BlockPosition = basePosition + currentPosition;
                    var opos = currentPosition;
                    currentPosition += block.BlockLength;
                    currentPosition += Pad(currentPosition);
                    var usedspace = currentPosition - opos;
                    currentPageSpace -= usedspace;
                    currentRemainder -= usedspace;
                }

                startPageSize *= 2;
                pageSizeMult *= 2;
            }
            while ((invalidLayout) || (flags.Size < totalBlockSize) || (flags.Count + usedPages > 128));

        }
    }
}