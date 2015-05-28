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

namespace RageLib.Resources
{
    public static class ResourceHelpers
    {
        private const int SKIP_SIZE = 64;
        private const int ALIGN_SIZE = 64;


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


        public static void GetBlocks(IResourceBlock rootBlock, out IList<IResourceBlock> sys, out IList<IResourceBlock> gfx)
        {
            var systemBlocks = new HashSet<IResourceBlock>();
            var graphicBlocks = new HashSet<IResourceBlock>();
            var protectedBlocks = new List<IResourceBlock>();

            var stack = new Stack<IResourceBlock>();
            stack.Push(rootBlock);

            var processed = new HashSet<IResourceBlock>();
            processed.Add(rootBlock);

            while (stack.Count > 0)
            {
                var block = stack.Pop();
                if (block == null)
                    continue;

                if (block is IResourceSystemBlock)
                {
                    if (!systemBlocks.Contains(block))
                        systemBlocks.Add(block);

                    // for system blocks, also process references...

                    var references = ((IResourceSystemBlock)block).GetReferences();
                    //Array.Reverse(references);
                    foreach (var reference in references)
                        if (!processed.Contains(reference))
                        {
                            stack.Push(reference);
                            processed.Add(reference);
                        }
                    var subs = new Stack<IResourceSystemBlock>();
                    foreach (var part in ((IResourceSystemBlock)block).GetParts())
                        subs.Push((IResourceSystemBlock)part.Item2);
                    while (subs.Count > 0)
                    {
                        var sub = subs.Pop();

                        foreach (var x in sub.GetReferences())
                            if (!processed.Contains(x))
                            {
                                stack.Push(x);
                                processed.Add(x);
                            }
                        foreach (var x in sub.GetParts())
                            subs.Push((IResourceSystemBlock)x.Item2);

                        protectedBlocks.Add(sub);
                    }

                }
                else
                {
                    if (!graphicBlocks.Contains(block))
                        graphicBlocks.Add(block);
                }
            }

            //var result = new List<IResourceBlock>();
            //result.AddRange(systemBlocks);
            //result.AddRange(graphicBlocks);
            //return result;

            // there are now sys-blocks in the list that actually
            // only substructures and therefore must not get
            // a new position!
            // -> remove them from the list
            foreach (var q in protectedBlocks)
                if (systemBlocks.Contains(q))
                    systemBlocks.Remove(q);


            sys = new List<IResourceBlock>();
            foreach (var s in systemBlocks)
                sys.Add(s);
            gfx = new List<IResourceBlock>();
            foreach (var s in graphicBlocks)
                gfx.Add(s);
        }

        public static void AssignPositions(IList<IResourceBlock> blocks, uint basePosition, ref int pageSize, out int pageCount)
        {
            // find largest structure
            long largestBlockSize = 0;
            foreach (var block in blocks)
            {
                if (largestBlockSize < block.Length)
                    largestBlockSize = block.Length;
            }

            // find minimum page size
            long currentPageSize = 0x2000;
            while (currentPageSize < largestBlockSize)
                currentPageSize *= 2;

            long currentPageCount;
            long currentPosition;
            while (true)
            {
                currentPageCount = 0;
                currentPosition = 0;

                // reset all positions
                foreach (var block in blocks)
                    block.Position = -1;

                foreach (var block in blocks)
                {
                    if (block.Position != -1)
                        throw new Exception("A position of -1 is not possible!");
                    //if (block.Length == 0)
                    //    throw new Exception("A length of 0 is not allowed!");

                    // check if new page is necessary...
                    // if yes, add a new page and align to it
                    long maxSpace = currentPageCount * currentPageSize - currentPosition;
                    if (maxSpace < (block.Length + SKIP_SIZE))
                    {
                        currentPageCount++;
                        currentPosition = currentPageSize * (currentPageCount - 1);
                    }

                    // set position
                    block.Position = basePosition + currentPosition;
                    currentPosition += block.Length + SKIP_SIZE;

                    // align...
                    if ((currentPosition % ALIGN_SIZE) != 0)
                        currentPosition += (ALIGN_SIZE - (currentPosition % ALIGN_SIZE));
                }

                // break if everything fits...
                if (currentPageCount < 128)
                    break;

                currentPageSize *= 2;
            }

            pageSize = (int)currentPageSize;
            pageCount = (int)currentPageCount;
        }
    }
}