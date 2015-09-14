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

using RageLib.GTA5.Cryptography.Helpers;
using System.Threading.Tasks;

namespace RageLib.GTA5.Cryptography
{
    public class LookUpTableGenerator
    {
        public static GTA5NGLUT[] BuildLUTs2(uint[][] tables)
        {
            var temp = new byte[16][];
            for (int i = 0; i < 16; i++)
                temp[i] = new byte[65536];

            var result = new GTA5NGLUT[16];
            for (int i = 0; i < 16; i++)
            {
                result[i] = new GTA5NGLUT();
                //result[i].Tables = new byte[256][];
                //result[i].LUT = new byte[16777216];
            }

            var tempLUTS = new byte[16][];
            for (int i = 0; i < 16; i++)
                tempLUTS[i] = new byte[16777216];

            var t0 = tables[0];
            var t1 = tables[1];
            var t2 = tables[2];
            var t3 = tables[3];
            var t4 = tables[4];
            var t5 = tables[5];
            var t6 = tables[6];
            var t7 = tables[7];
            var t8 = tables[8];
            var t9 = tables[9];
            var t10 = tables[10];
            var t11 = tables[11];
            var t12 = tables[12];
            var t13 = tables[13];
            var t14 = tables[14];
            var t15 = tables[15];

            Parallel.For(0, 0x100, (long k1) =>
            {
                for (long k2 = 0; k2 < 0x1000000; k2++)
                {
                    long i = k1 * 0x1000000 + k2;

                    byte b0 = (byte)((i >> 0) & 0xFF);
                    byte b1 = (byte)((i >> 8) & 0xFF);
                    byte b2 = (byte)((i >> 16) & 0xFF);
                    byte b3 = (byte)((i >> 24) & 0xFF);

                    var x1 =
                         t0[b0] ^
                         t7[b1] ^
                         t10[b2] ^
                         t13[b3];
                    var x2 =
                        t1[b0] ^
                        t4[b1] ^
                        t11[b2] ^
                        t14[b3];
                    var x3 =
                        t2[b0] ^
                        t5[b1] ^
                        t8[b2] ^
                        t15[b3];
                    var x4 =
                        t3[b0] ^
                        t6[b1] ^
                        t9[b2] ^
                        t12[b3];

                    // the first LUT-compression step is built-it
                    // because it would take 4GB ram per data byte (and there are 16)

                    if (x1 < 65536)
                    {
                        temp[0][x1] = b0;
                        temp[7][x1] = b1;
                        temp[10][x1] = b2;
                        temp[13][x1] = b3;
                    }

                    if (x2 < 65536)
                    {
                        temp[1][x2] = b0;
                        temp[4][x2] = b1;
                        temp[11][x2] = b2;
                        temp[14][x2] = b3;
                    }

                    if (x3 < 65536)
                    {
                        temp[2][x3] = b0;
                        temp[5][x3] = b1;
                        temp[8][x3] = b2;
                        temp[15][x3] = b3;
                    }

                    if (x4 < 65536)
                    {
                        temp[3][x4] = b0;
                        temp[6][x4] = b1;
                        temp[9][x4] = b2;
                        temp[12][x4] = b3;
                    }

                    if ((x1 & 0x000000FF) == 0)
                    {
                        tempLUTS[0][x1 >> 8] = b0;
                        tempLUTS[7][x1 >> 8] = b1;
                        tempLUTS[10][x1 >> 8] = b2;
                        tempLUTS[13][x1 >> 8] = b3;
                    }

                    if ((x2 & 0x000000FF) == 0)
                    {
                        tempLUTS[1][x2 >> 8] = b0;
                        tempLUTS[4][x2 >> 8] = b1;
                        tempLUTS[11][x2 >> 8] = b2;
                        tempLUTS[14][x2 >> 8] = b3;
                    }

                    if ((x3 & 0x000000FF) == 0)
                    {
                        tempLUTS[2][x3 >> 8] = b0;
                        tempLUTS[5][x3 >> 8] = b1;
                        tempLUTS[8][x3 >> 8] = b2;
                        tempLUTS[15][x3 >> 8] = b3;
                    }

                    if ((x4 & 0x000000FF) == 0)
                    {
                        tempLUTS[3][x4 >> 8] = b0;
                        tempLUTS[6][x4 >> 8] = b1;
                        tempLUTS[9][x4 >> 8] = b2;
                        tempLUTS[12][x4 >> 8] = b3;
                    }
                }
            });

            for (int i = 0; i < 16; i++)
            {
                result[i].LUT0 = new byte[256][];
                for (int blockIdx = 0; blockIdx < 256; blockIdx++)
                {

                    var xl = new byte[256];
                    for (int k = 0; k < 256; k++)
                    {
                        xl[k] = temp[i][256 * blockIdx + k];
                    }

                    result[i].LUT0[xl[0]] = xl;
                }
            }

            // compress tables...
            // length from 2^24 -> 2^16
            for (int i = 0; i < 16; i++)
            {
                GTA5NGLUT lut = result[i];
                lut.LUT1 = new byte[256][];
                lut.Indices = new byte[65536];    
                
                for (int blockIdx = 0; blockIdx < 256; blockIdx++)
                {
                    var xl = new byte[256];
                    for (int k = 0; k < 256; k++)
                    {
                        xl[k] = tempLUTS[i][256 * blockIdx + k];
                    }

                    lut.LUT1[xl[0]] = xl;
                }
                for (int blockIdx = 0; blockIdx < 65536; blockIdx++)
                {
                    lut.Indices[blockIdx] = tempLUTS[i][256 * blockIdx];
                }                
            }

            return result;
        }
    }
}
