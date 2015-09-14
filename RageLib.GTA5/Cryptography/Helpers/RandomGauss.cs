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

using RageLib.GTA5.Cryptography;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RageLib.GTA5.Helpers
{
    public class RandomGaussRow
    {
        //private bool[] A = new bool[1024];
        private ulong[] A = new ulong[16];
        public bool B;


        public bool GetA(int idx)
        {
            int lidx = idx / 64;
            int bidx = idx % 64;
            return ((A[lidx] >> bidx) & 0x1) != 0;
        }

        public void SetA(int idx)
        {
            int lidx = idx / 64;
            int bidx = idx % 64;
            A[lidx] |= (ulong)1 << bidx;
        }

        public bool GetB()
        {
            return B;
        }

        public void SetB()
        {
            this.B = true;
        }

        public static RandomGaussRow operator ^(RandomGaussRow r1, RandomGaussRow r2)
        {
            var newRow = new RandomGaussRow();
            for (int i = 0; i < 16; i++)
                newRow.A[i] = r1.A[i] ^ r2.A[i];
            newRow.B = r1.B ^ r2.B;
            return newRow;
        }
    }

    public class RandomGauss
    {
        private const int TEST_ITERATIONS = 100000;

        public static bool[] Solve(
            uint[][] tables,
            int inByte0, int inByte1, int inByte2, int inByte3,
            int outByte, int outBit)
        {
            var noKey = new uint[] { 0, 0, 0, 0 };
            var random = new Random();

            var pivots = new List<RandomGaussRow>();

            var firstPivot = new RandomGaussRow();
            firstPivot.SetA(0);
            firstPivot.SetB();
            pivots.Add(firstPivot);

            var buf_encrypted = new byte[16];
            for (int pivotIdx = 1; pivotIdx < 1024; pivotIdx++)
            {
                while (true)
                {
                    random.NextBytes(buf_encrypted);

                    // decrypt                   
                    var buf_decrypted = GTA5Crypto.DecryptRoundA(
                        buf_encrypted,
                        noKey,
                        tables);

                    // make row
                    var row = new RandomGaussRow();
                    //row.A[0 + buf_decrypted[inByte0]] = true;
                    //row.A[256 + buf_decrypted[inByte1]] = true;
                    //row.A[512 + buf_decrypted[inByte2]] = true;
                    //row.A[768 + buf_decrypted[inByte3]] = true;
                    //row.B = (buf_encrypted[outByte] & (1 << outBit)) != 0;
                    row.SetA(0 + buf_decrypted[inByte0]);
                    row.SetA(256 + buf_decrypted[inByte1]);
                    row.SetA(512 + buf_decrypted[inByte2]);
                    row.SetA(768 + buf_decrypted[inByte3]);
                    if ((buf_encrypted[outByte] & (1 << outBit)) != 0)
                        row.SetB();

                    if (pivotIdx == 0x2ff)
                    {
                        row = new RandomGaussRow();
                        row.SetA(0x2ff);
                        row.SetB();
                    }
                    if (pivotIdx == 0x3ff)
                    {
                        row = new RandomGaussRow();
                        row.SetA(0x3ff);
                        row.SetB();
                    }

                    // apply pivotIdx-1 pivots
                    for (int k = 0; k < pivotIdx; k++)
                    {
                        if (row.GetA(k))
                        {
                            row ^= pivots[k];
                            //var ppp = pivots[k];
                            //for (int p = 0; p < 1024; p++)
                            //    row.A[p] ^= ppp.A[p];
                            //row.B ^= ppp.B;
                        }
                    }

                    // check if this row is a new pivot
                    if (row.GetA(pivotIdx))
                    {
                        pivots.Add(row);
                        //    Console.WriteLine("Found pivot for column " + pivotIdx.ToString());
                        break;
                    }
                }
            }

            var result = new bool[1024];
            for (int j = 1023; j >= 0; j--)
            {
                bool val = pivots[j].GetB();
                result[j] = val;
                for (int k = 0; k < j; k++)
                {
                    if (pivots[k].GetA(j))
                        pivots[k].B ^= val;
                }
            }

            return result;
        }

        public static uint[][] Solve(uint[][] tables)
        {
            var result = new uint[16][];
            for (int tabIdx = 0; tabIdx < 16; tabIdx++)
            {
                result[tabIdx] = new uint[256];
            }

            //for (int bitIdx = 0; bitIdx < 128; bitIdx++)
            Parallel.For(0, 128, (int bitIdx) =>
            {
                int outByte = bitIdx / 8;
                int uintIdx = outByte / 4;

                int inByte0 = 4 * uintIdx + 0;
                int inByte1 = 4 * uintIdx + 1;
                int inByte2 = 4 * uintIdx + 2;
                int inByte3 = 4 * uintIdx + 3;
                int outBit = bitIdx % 8;
                int z = bitIdx % 32;

                var bitResult = Solve(tables, inByte0, inByte1, inByte2, inByte3, outByte, outBit);
                lock (result)
                {
                    for (int i = 0; i < 256; i++)
                    {
                        if (bitResult[0 + i])
                            result[inByte0][i] |= (uint)(1 << z);
                        if (bitResult[256 + i])
                            result[inByte1][i] |= (uint)(1 << z);
                        if (bitResult[512 + i])
                            result[inByte2][i] |= (uint)(1 << z);
                        if (bitResult[768 + i])
                            result[inByte3][i] |= (uint)(1 << z);
                    }
                }

            });

            return result;
        }

    }
}