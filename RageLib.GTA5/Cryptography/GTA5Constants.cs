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

namespace RageLib.GTA5.Cryptography
{
    public static class GTA5Constants
    {
        // aes decryption/encryption key...
        public static byte[] PC_AES_KEY_HASH = null; // removed
        public static byte[] PC_AES_KEY;

        // ng decryption/encryption expanded keys...
        public static byte[][] PC_NG_KEY_HASHES = null; // removed
        public static byte[][] PC_NG_KEYS;

        // ng decryption tables...
        public static byte[][] PC_NG_DECRYPT_TABLE_HASHES = null; // removed
        public static byte[][] PC_NG_DECRYPT_TABLES;

        // ng encryption tables...
        // -> there are no hashes since these tables are calculated from decryption tables
        public static byte[][] PC_NG_ENCRYPT_TABLES;

        // hash lookup-table...
        public static byte[] PC_LUT_HASH = null; // removed
        public static byte[] PC_LUT;
    }
}
