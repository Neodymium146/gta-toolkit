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

using RageLib.Compression;

namespace RageLib.Helpers
{
    public static class TextureConvert
    {
        //case TextureFormat.D3DFMT_A8: format = DXGI_FORMAT.DXGI_FORMAT_A8_UNORM; break;
        public static byte[] MakeRGBAFromA8(byte[] data, int width, int height)
        {
            var buf = new byte[width * height * 4];
            DXTex.ConvertImage(
                data, (int)DXGI_FORMAT.DXGI_FORMAT_A8_UNORM, width,
                buf, (int)DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM, width * 4,
                width, height);
            return buf;
        }

        //case TextureFormat.D3DFMT_A8B8G8R8: format = DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM; break;  
        public static byte[] MakeRGBAFromA8B8G8R8(byte[] data, int width, int height)
        {
            var buf = new byte[width * height * 4];
            DXTex.ConvertImage(
                data, (int)DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM, width * 4,
                buf, (int)DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM, width * 4,
                width, height);
            return buf;
        }
        
        //case TextureFormat.D3DFMT_A8R8G8B8: format = DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM; break;
        public static byte[] MakeRGBAFromA8R8G8B8(byte[] data, int width, int height)
        {
            var buf = new byte[width * height * 4];
            DXTex.ConvertImage(
                data, (int)DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM, width * 4,
                buf, (int)DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM, width * 4,
                width, height);
            return buf;
        }
        
        //case TextureFormat.D3DFMT_L8: format = DXGI_FORMAT.DXGI_FORMAT_R8_UNORM; break;
        public static byte[] MakeARGBFromL8(byte[] data, int width, int height)
        {
            var buf = new byte[width * height * 4];
            DXTex.ConvertImage(
                data, (int)DXGI_FORMAT.DXGI_FORMAT_R8_UNORM, width,
                buf, (int)DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM, width * 4,
                width, height);
            return buf;
        }
        
        //case TextureFormat.D3DFMT_A1R5G5B5: format = DXGI_FORMAT.DXGI_FORMAT_B5G5R5A1_UNORM; break;
        public static byte[] MakeARGBFromA1R5G5B5(byte[] data, int width, int height)
        {
            var buf = new byte[width * height * 4];
            DXTex.ConvertImage(
                data, (int)DXGI_FORMAT.DXGI_FORMAT_B5G5R5A1_UNORM, width * 2,
                buf, (int)DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM, width * 4,
                width, height);
            return buf;
        }       
    }
}
