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
using System.Text;
using System.Threading.Tasks;

namespace RageLib.GTA5.Cryptography.Helpers
{

    public class GTA5NGLUT
    {
        public byte[][] LUT0;
        public byte[][] LUT1;
        public byte[] Indices;

        public GTA5NGLUT()
        {
            LUT0 = new byte[256][];
            for (int i = 0; i < 256; i++)
                LUT0[i] = new byte[256];

            LUT1 = new byte[256][];
            for (int i = 0; i < 256; i++)
                LUT1[i] = new byte[256];

            Indices = new byte[65536];
        }

        public byte LookUp(uint value)
        {
            uint h16 = (value & 0xFFFF0000) >> 16;
            uint l8 = (value & 0x0000FF00) >> 8;
            uint l0 = (value & 0x000000FF) >> 0;
            return LUT0[LUT1[Indices[h16]][l8]][l0];
        }
    }


    ///// <summary>
    ///// Represents a 'structured' look-up-table.
    ///// </summary>
    //[Serializable]
    //public class GTA5CryptoLUT
    //{
    //    public byte[][] Tables;
    //    public byte[] LUT;

    //    public byte LookUp(uint value)
    //    {
    //        uint h = (value & 0xFFFFFF00) >> 8;
    //        uint l = (value & 0x000000FF);

    //        return Tables[GetTableIndex(h)][l];
    //    }

    //    public virtual byte GetTableIndex(uint h)
    //    {
    //        return LUT[h];
    //    }
    //}

    //public class GTA5CryptoLUTX : GTA5CryptoLUT
    //{
    //    public GTA5CryptoLUT subLUT;

    //    public override byte GetTableIndex(uint h)
    //    {
    //        return subLUT.LookUp(h);
    //    }
    //}

}
