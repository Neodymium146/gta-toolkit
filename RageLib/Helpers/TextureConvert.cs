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
        public static byte[] MakeRGBAFromA8(byte[] data, int width, int height)
        {
            return DirectXTex.ImageConverter.Convert(data, width, height, (int)DXGI_FORMAT.DXGI_FORMAT_A8_UNORM, (int)DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM);
        }

        public static byte[] MakeRGBAFromA8B8G8R8(byte[] data, int width, int height)
        {
            // return DirectXTex.ImageConverter.Convert(data, width, height, (int)DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM, (int)DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM);
            return data;
        }

        public static byte[] MakeRGBAFromA8R8G8B8(byte[] data, int width, int height)
        {
            return DirectXTex.ImageConverter.Convert(data, width, height, (int)DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM, (int)DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM);
        }

        public static byte[] MakeARGBFromL8(byte[] data, int width, int height)
        {
            return DirectXTex.ImageConverter.Convert(data, width, height, (int)DXGI_FORMAT.DXGI_FORMAT_R8_UNORM, (int)DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM);
        }

        public static byte[] MakeARGBFromA1R5G5B5(byte[] data, int width, int height)
        {
            return DirectXTex.ImageConverter.Convert(data, width, height, (int)DXGI_FORMAT.DXGI_FORMAT_B5G5R5A1_UNORM, (int)DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM);
        }
    }
}