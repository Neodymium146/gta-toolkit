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

using RageLib.Data;
using System.IO;

namespace RageLib.GTA5.Cryptography.Helpers
{
    public class CryptoIO
    {
        public static byte[][] ReadNgKeys(string fileName)
        {
            byte[][] result;

            var fs = new FileStream(fileName, FileMode.Open);
            var rd = new DataReader(fs);

            result = new byte[101][];
            for (int i = 0; i < 101; i++)
            {
                result[i] = rd.ReadBytes(272);
            }

            fs.Close();

            return result;
        }

        public static void WriteNgKeys(string fileName, byte[][] keys)
        {
            var fs = new FileStream(fileName, FileMode.Create);
            var wr = new DataWriter(fs);

            for (int i = 0; i < 101; i++)
            {
                wr.Write(keys[i]);
            }

            fs.Close();
        }

        public static uint[][][] ReadNgTables(string fileName)
        {
            uint[][][] result;

            var fs = new FileStream(fileName, FileMode.Open);
            var rd = new DataReader(fs);

            // 17 rounds...
            result = new uint[17][][];
            for (int i = 0; i < 17; i++)
            {
                // 16 bytes...
                result[i] = new uint[16][];
                for (int j = 0; j < 16; j++)
                {
                    // 256 entries...
                    result[i][j] = new uint[256];
                    for (int k = 0; k < 256; k++)
                    {
                        result[i][j][k] = rd.ReadUInt32();
                    }
                }
            }

            fs.Close();

            return result;
        }

        public static void WriteNgTables(string fileName, uint[][][] tableData)
        {
            var fs = new FileStream(fileName, FileMode.Create);
            var wr = new DataWriter(fs);

            // 17 rounds...
            for (int i = 0; i < 17; i++)
            {
                // 16 bytes...
                for (int j = 0; j < 16; j++)
                {
                    // 256 entries...
                    for (int k = 0; k < 256; k++)
                    {
                        wr.Write(tableData[i][j][k]);
                    }
                }
            }

            fs.Close();
        }

        public static GTA5NGLUT[][] ReadNgLuts(string fileName)
        {
            GTA5NGLUT[][] result;

            var fs = new FileStream(fileName, FileMode.Open);
            var rd = new DataReader(fs);

            // 17 rounds...
            result = new GTA5NGLUT[17][];
            for (int i = 0; i < 17; i++)
            {
                // 16 bytes...
                result[i] = new GTA5NGLUT[16];
                for (int j = 0; j < 16; j++)
                {
                    result[i][j] = new GTA5NGLUT();

                    // first compression step (2^32 -> 2^24)
                    result[i][j].LUT0 = new byte[256][];
                    for (int k = 0; k < 256; k++)
                    {
                        //result[i][j].LUT0[k] = new byte[256];
                        //for (int l = 0; l < 256; l++)
                        //    result[i][j].LUT0[k][l] = rd.ReadByte();
                        result[i][j].LUT0[k] = rd.ReadBytes(256);
                    }

                    // second compression step (2^24 -> 2^16)
                    result[i][j].LUT1 = new byte[256][];
                    for (int k = 0; k < 256; k++)
                    {
                        //result[i][j].LUT1[k] = new byte[256];
                        //for (int l = 0; l < 256; l++)
                        //    result[i][j].LUT1[k][l] = rd.ReadByte();
                        result[i][j].LUT1[k] = rd.ReadBytes(256);
                    }

                    // indices
                    //result[i][j].Indices = new byte[65536];
                    //for (int k = 0; k < 65536; k++)
                    //    result[i][j].Indices[k] = rd.ReadByte();
                    result[i][j].Indices = rd.ReadBytes(65536);
                }
            }


            fs.Close();

            return result;
        }

        public static void WriteLuts(string fileName, GTA5NGLUT[][] lutData)
        {
            var fs = new FileStream(fileName, FileMode.Create);
            var wr = new DataWriter(fs);

            // 17 rounds...
            for (int i = 0; i < 17; i++)
            {
                // 16 bytes...
                for (int j = 0; j < 16; j++)
                {
                    GTA5NGLUT lut = lutData[i][j];

                    // first compression step (2^32 -> 2^24)
                    for (int k = 0; k < 256; k++)
                        for (int l = 0; l < 256; l++)
                            wr.Write(lut.LUT0[k][l]);

                    // second compression step (2^24 -> 2^16)
                    for (int k = 0; k < 256; k++)
                        for (int l = 0; l < 256; l++)
                            wr.Write(lut.LUT1[k][l]);

                    // indices
                    for (int k = 0; k < 65536; k++)
                        wr.Write(lut.Indices[k]);
                }
            }

            fs.Close();
        }
    }
}