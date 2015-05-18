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
using RageLib.ResourceWrappers;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RageLib.Helpers
{
    class DXTexdds
    {
        [DllImport("DirectXTex.dll", EntryPoint = "SaveDDSImage", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SaveDDSImage(
                 [MarshalAs(UnmanagedType.LPWStr)] string fileName,
                 [MarshalAs(UnmanagedType.LPArray)] byte[] pIn,
                 int size, int width, int height, int stride, int mipLevels, int format
             );

        [DllImport("DirectXTex.dll", EntryPoint = "LoadDDSImage", CallingConvention = CallingConvention.Cdecl)]
        public static extern void LoadDDSImage(
                [MarshalAs(UnmanagedType.LPWStr)] string fileName,
                [MarshalAs(UnmanagedType.LPArray)] byte[] dataPointer, ref int dataLength,
                ref int width, ref int height, ref int stride, ref int mipLevels, ref int format
            );


        [DllImport("DirectXTex.dll", EntryPoint = "SaveDDSImageToStream", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SaveDDSImageToStream(
                 [MarshalAs(UnmanagedType.LPArray)] byte[] pStreamData, ref int length,
                 [MarshalAs(UnmanagedType.LPArray)] byte[] pIn,
                 int size, int width, int height, int stride, int mipLevels, int format
             );

        [DllImport("DirectXTex.dll", EntryPoint = "LoadDDSImageFromStream", CallingConvention = CallingConvention.Cdecl)]
        public static extern void LoadDDSImageFromStream(
                [MarshalAs(UnmanagedType.LPArray)] byte[] pStreamData, int streamLength,
                [MarshalAs(UnmanagedType.LPArray)] byte[] dataPointer, ref int dataLength,
                ref int width, ref int height, ref int stride, ref int mipLevels, ref int format
            );
    }

    public class DDSIO
    {
        public static void LoadTextureData(ITexture texture, Stream stream)
        {
            byte[] readbuf = new byte[16777216];

            IntPtr p = IntPtr.Zero;
            int width = 0;
            int height = 0;
            int mipLevels = 0;
            int format = 0;
            int stride = 0;
            int readsize = 16777216;

            var strBuf = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(strBuf, 0, strBuf.Length);

            DXTexdds.LoadDDSImageFromStream(strBuf, strBuf.Length, readbuf, ref readsize, ref width, ref height, ref stride, ref mipLevels, ref format);

            if (readsize > 16777216)
            {
                readbuf = new byte[readsize];
                DXTexdds.LoadDDSImageFromStream(strBuf, strBuf.Length, readbuf, ref readsize, ref width, ref height, ref stride, ref mipLevels, ref format);
            }

            Array.Resize<byte>(ref readbuf, readsize);
            //int length = stride * height / 4;
            //int totalLength = 0;
            //for (int i = 0; i < mipLevels; i++)
            //{
            //    totalLength += length;
            //    length /= 4;
            //}

            //var buffer = new byte[totalLength/2];
            //Marshal.Copy(p, buffer, 0, buffer.Length);

            switch ((DXGI_FORMAT)format)
            {
                // compressed
                case DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM:
                    texture.Reset(width, height, mipLevels, stride / 4, TextureFormat.D3DFMT_DXT1);
                    texture.SetTextureData(readbuf);
                    break;

                case DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM:
                    texture.Reset(width, height, mipLevels, stride / 4, TextureFormat.D3DFMT_DXT3);
                    texture.SetTextureData(readbuf);
                    break;

                case DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM:
                    texture.Reset(width, height, mipLevels, stride / 4, TextureFormat.D3DFMT_DXT5);
                    texture.SetTextureData(readbuf);
                    break;

                case DXGI_FORMAT.DXGI_FORMAT_BC4_UNORM:
                    texture.Reset(width, height, mipLevels, stride / 4, TextureFormat.D3DFMT_ATI1);
                    texture.SetTextureData(readbuf);
                    break;

                case DXGI_FORMAT.DXGI_FORMAT_BC5_UNORM:
                    texture.Reset(width, height, mipLevels, stride / 4, TextureFormat.D3DFMT_ATI2);
                    texture.SetTextureData(readbuf);
                    break;

                case DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM:
                    texture.Reset(width, height, mipLevels, stride / 4, TextureFormat.D3DFMT_BC7);
                    texture.SetTextureData(readbuf);
                    break;



                // uncompressed
                case DXGI_FORMAT.DXGI_FORMAT_B5G5R5A1_UNORM:
                    texture.Reset(width, height, mipLevels, stride, TextureFormat.D3DFMT_A1R5G5B5);
                    texture.SetTextureData(readbuf);
                    break;

                case DXGI_FORMAT.DXGI_FORMAT_A8_UNORM:
                    texture.Reset(width, height, mipLevels, stride, TextureFormat.D3DFMT_A8);
                    texture.SetTextureData(readbuf);
                    break;

                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM:
                    texture.Reset(width, height, mipLevels, stride, TextureFormat.D3DFMT_A8B8G8R8);
                    texture.SetTextureData(readbuf);
                    break;

                case DXGI_FORMAT.DXGI_FORMAT_R8_UNORM:
                    texture.Reset(width, height, mipLevels, stride, TextureFormat.D3DFMT_L8);
                    texture.SetTextureData(readbuf);
                    break;

                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM:
                    texture.Reset(width, height, mipLevels, stride, TextureFormat.D3DFMT_A8R8G8B8);
                    texture.SetTextureData(readbuf);
                    break;

                default:
                    MessageBox.Show("format not supported!");
                    throw new Exception("unsupported format");
            }
        }

        public static void LoadTextureData(ITexture texture, string fileName)
        {
            byte[] readbuf = new byte[16777216];

            IntPtr p = IntPtr.Zero;
            int width = 0;
            int height = 0;
            int mipLevels = 0;
            int format = 0;
            int stride = 0;
            int readsize = 16777216;
            DXTexdds.LoadDDSImage(fileName, readbuf, ref readsize, ref width, ref height, ref stride, ref mipLevels, ref format);

            if (readsize > 16777216)
            {
                readbuf = new byte[readsize];
                DXTexdds.LoadDDSImage(fileName, readbuf, ref readsize, ref width, ref height, ref stride, ref mipLevels, ref format);
            }

            Array.Resize<byte>(ref readbuf, readsize);
            //int length = stride * height / 4;
            //int totalLength = 0;
            //for (int i = 0; i < mipLevels; i++)
            //{
            //    totalLength += length;
            //    length /= 4;
            //}
            
            //var buffer = new byte[totalLength/2];
            //Marshal.Copy(p, buffer, 0, buffer.Length);

            switch ((DXGI_FORMAT)format)
            {
                // compressed
                case DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM:
                    texture.Reset(width, height, mipLevels, stride / 4, TextureFormat.D3DFMT_DXT1);
                    texture.SetTextureData(readbuf);
                    break;

                case DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM:
                    texture.Reset(width, height, mipLevels, stride / 4, TextureFormat.D3DFMT_DXT3);
                    texture.SetTextureData(readbuf);
                    break;

                case DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM:
                    texture.Reset(width, height, mipLevels, stride / 4, TextureFormat.D3DFMT_DXT5);
                    texture.SetTextureData(readbuf);
                    break;

                case DXGI_FORMAT.DXGI_FORMAT_BC4_UNORM:
                    texture.Reset(width, height, mipLevels, stride / 4, TextureFormat.D3DFMT_ATI1);
                    texture.SetTextureData(readbuf);
                    break;

                case DXGI_FORMAT.DXGI_FORMAT_BC5_UNORM:
                    texture.Reset(width, height, mipLevels, stride / 4, TextureFormat.D3DFMT_ATI2);
                    texture.SetTextureData(readbuf);
                    break;

                case DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM:
                    texture.Reset(width, height, mipLevels, stride / 4, TextureFormat.D3DFMT_BC7);
                    texture.SetTextureData(readbuf);
                    break;



                // uncompressed
                case DXGI_FORMAT.DXGI_FORMAT_B5G5R5A1_UNORM:
                    texture.Reset(width, height, mipLevels, stride, TextureFormat.D3DFMT_A1R5G5B5);
                    texture.SetTextureData(readbuf);
                    break;

                case DXGI_FORMAT.DXGI_FORMAT_A8_UNORM:
                    texture.Reset(width, height, mipLevels, stride, TextureFormat.D3DFMT_A8);
                    texture.SetTextureData(readbuf);
                    break;

                case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM:
                    texture.Reset(width, height, mipLevels, stride, TextureFormat.D3DFMT_A8B8G8R8);
                    texture.SetTextureData(readbuf);
                    break;

                case DXGI_FORMAT.DXGI_FORMAT_R8_UNORM:
                    texture.Reset(width, height, mipLevels, stride, TextureFormat.D3DFMT_L8);
                    texture.SetTextureData(readbuf);
                    break;

                case DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM:
                    texture.Reset(width, height, mipLevels, stride, TextureFormat.D3DFMT_A8R8G8B8);
                    texture.SetTextureData(readbuf);
                    break;

                default:
                    MessageBox.Show("format not supported!");
                    throw new Exception("unsupported format");
            }
        }

        public static void SaveTextureData(ITexture texture, Stream stream)
        {
            var data = texture.GetTextureData();

            var format = DXGI_FORMAT.DXGI_FORMAT_UNKNOWN;
            switch (texture.Format)
            {
                // compressed
                case TextureFormat.D3DFMT_DXT1: format = DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM; break;
                case TextureFormat.D3DFMT_DXT3: format = DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM; break;
                case TextureFormat.D3DFMT_DXT5: format = DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM; break;
                case TextureFormat.D3DFMT_ATI1: format = DXGI_FORMAT.DXGI_FORMAT_BC4_UNORM; break;
                case TextureFormat.D3DFMT_ATI2: format = DXGI_FORMAT.DXGI_FORMAT_BC5_UNORM; break;
                case TextureFormat.D3DFMT_BC7: format = DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM; break;

                // uncompressed
                case TextureFormat.D3DFMT_A1R5G5B5: format = DXGI_FORMAT.DXGI_FORMAT_B5G5R5A1_UNORM; break;
                case TextureFormat.D3DFMT_A8: format = DXGI_FORMAT.DXGI_FORMAT_A8_UNORM; break;
                case TextureFormat.D3DFMT_A8B8G8R8: format = DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM; break;
                case TextureFormat.D3DFMT_L8: format = DXGI_FORMAT.DXGI_FORMAT_R8_UNORM; break;
                case TextureFormat.D3DFMT_A8R8G8B8: format = DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM; break;
            }

            byte[] strbuf = new byte[16777216];
            int strlen = 16777216;
            DXTexdds.SaveDDSImageToStream(strbuf, ref strlen, data, 0, texture.Width, texture.Height, 2 * texture.Width, texture.MipMapLevels, (int)format);
            if (strlen > 16777216)
            {
                strbuf = new byte[strlen];
                DXTexdds.SaveDDSImageToStream(strbuf, ref strlen, data, 0, texture.Width, texture.Height, 2 * texture.Width, texture.MipMapLevels, (int)format);
            }

            stream.Write(strbuf, 0, strlen);
        }

        public static void SaveTextureData(ITexture texture, string fileName)
        {
            var data = texture.GetTextureData();

            var format = DXGI_FORMAT.DXGI_FORMAT_UNKNOWN;
            switch (texture.Format)
            {
                // compressed
                case TextureFormat.D3DFMT_DXT1: format = DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM; break;
                case TextureFormat.D3DFMT_DXT3: format = DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM; break;
                case TextureFormat.D3DFMT_DXT5: format = DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM; break;
                case TextureFormat.D3DFMT_ATI1: format = DXGI_FORMAT.DXGI_FORMAT_BC4_UNORM; break;
                case TextureFormat.D3DFMT_ATI2: format = DXGI_FORMAT.DXGI_FORMAT_BC5_UNORM; break;
                case TextureFormat.D3DFMT_BC7: format = DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM; break;

                // uncompressed
                case TextureFormat.D3DFMT_A1R5G5B5: format = DXGI_FORMAT.DXGI_FORMAT_B5G5R5A1_UNORM; break;
                case TextureFormat.D3DFMT_A8: format = DXGI_FORMAT.DXGI_FORMAT_A8_UNORM; break;
                case TextureFormat.D3DFMT_A8B8G8R8: format = DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM; break;
                case TextureFormat.D3DFMT_L8: format = DXGI_FORMAT.DXGI_FORMAT_R8_UNORM; break;
                case TextureFormat.D3DFMT_A8R8G8B8: format = DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM; break;
            }

            DXTexdds.SaveDDSImage(fileName, data, 0, texture.Width, texture.Height, 2 * texture.Width, texture.MipMapLevels, (int)format);
        }

    }
}
