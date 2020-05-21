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

namespace RageLib.Helpers
{
    //public class DDSIO
    //{
    //    public static void LoadTextureData(ITexture texture, string fileName)
    //    {
    //        DirectXTex.ImageStruct img = DirectXTex.DDSIO.ReadDDS(fileName);
    //
    //        switch ((DXGI_FORMAT)img.Format)
    //        {
    //            // compressed
    //            case DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM:
    //                texture.Reset(img.Width, img.Height, img.MipMapLevels, img.GetRowPitch() / 4, TextureFormat.D3DFMT_DXT1);
    //                texture.SetTextureData(img.Data);
    //                break;
    //
    //            case DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM:
    //                texture.Reset(img.Width, img.Height, img.MipMapLevels, img.GetRowPitch() / 4, TextureFormat.D3DFMT_DXT3);
    //                texture.SetTextureData(img.Data);
    //                break;
    //
    //            case DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM:
    //                texture.Reset(img.Width, img.Height, img.MipMapLevels, img.GetRowPitch() / 4, TextureFormat.D3DFMT_DXT5);
    //                texture.SetTextureData(img.Data);
    //                break;
    //
    //            case DXGI_FORMAT.DXGI_FORMAT_BC4_UNORM:
    //                texture.Reset(img.Width, img.Height, img.MipMapLevels, img.GetRowPitch() / 4, TextureFormat.D3DFMT_ATI1);
    //                texture.SetTextureData(img.Data);
    //                break;
    //
    //            case DXGI_FORMAT.DXGI_FORMAT_BC5_UNORM:
    //                texture.Reset(img.Width, img.Height, img.MipMapLevels, img.GetRowPitch() / 4, TextureFormat.D3DFMT_ATI2);
    //                texture.SetTextureData(img.Data);
    //                break;
    //
    //            case DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM:
    //                texture.Reset(img.Width, img.Height, img.MipMapLevels, img.GetRowPitch() / 4, TextureFormat.D3DFMT_BC7);
    //                texture.SetTextureData(img.Data);
    //                break;
    //
    //
    //
    //            // uncompressed
    //            case DXGI_FORMAT.DXGI_FORMAT_B5G5R5A1_UNORM:
    //                texture.Reset(img.Width, img.Height, img.MipMapLevels, img.GetRowPitch(), TextureFormat.D3DFMT_A1R5G5B5);
    //                texture.SetTextureData(img.Data);
    //                break;
    //
    //            case DXGI_FORMAT.DXGI_FORMAT_A8_UNORM:
    //                texture.Reset(img.Width, img.Height, img.MipMapLevels, img.GetRowPitch(), TextureFormat.D3DFMT_A8);
    //                texture.SetTextureData(img.Data);
    //                break;
    //
    //            case DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM:
    //                texture.Reset(img.Width, img.Height, img.MipMapLevels, img.GetRowPitch(), TextureFormat.D3DFMT_A8B8G8R8);
    //                texture.SetTextureData(img.Data);
    //                break;
    //
    //            case DXGI_FORMAT.DXGI_FORMAT_R8_UNORM:
    //                texture.Reset(img.Width, img.Height, img.MipMapLevels, img.GetRowPitch(), TextureFormat.D3DFMT_L8);
    //                texture.SetTextureData(img.Data);
    //                break;
    //
    //            case DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM:
    //                texture.Reset(img.Width, img.Height, img.MipMapLevels, img.GetRowPitch(), TextureFormat.D3DFMT_A8R8G8B8);
    //                texture.SetTextureData(img.Data);
    //                break;
    //
    //            default:
    //                throw new Exception("unsupported format");
    //        }
    //    }
    //
    //    public static void SaveTextureData(ITexture texture, string fileName)
    //    {
    //        var data = texture.GetTextureData();
    //
    //        var format = DXGI_FORMAT.DXGI_FORMAT_UNKNOWN;
    //        switch (texture.Format)
    //        {
    //            // compressed
    //            case TextureFormat.D3DFMT_DXT1: format = DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM; break;
    //            case TextureFormat.D3DFMT_DXT3: format = DXGI_FORMAT.DXGI_FORMAT_BC2_UNORM; break;
    //            case TextureFormat.D3DFMT_DXT5: format = DXGI_FORMAT.DXGI_FORMAT_BC3_UNORM; break;
    //            case TextureFormat.D3DFMT_ATI1: format = DXGI_FORMAT.DXGI_FORMAT_BC4_UNORM; break;
    //            case TextureFormat.D3DFMT_ATI2: format = DXGI_FORMAT.DXGI_FORMAT_BC5_UNORM; break;
    //            case TextureFormat.D3DFMT_BC7: format = DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM; break;
    //
    //            // uncompressed
    //            case TextureFormat.D3DFMT_A1R5G5B5: format = DXGI_FORMAT.DXGI_FORMAT_B5G5R5A1_UNORM; break;
    //            case TextureFormat.D3DFMT_A8: format = DXGI_FORMAT.DXGI_FORMAT_A8_UNORM; break;
    //            case TextureFormat.D3DFMT_A8B8G8R8: format = DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM; break;
    //            case TextureFormat.D3DFMT_L8: format = DXGI_FORMAT.DXGI_FORMAT_R8_UNORM; break;
    //            case TextureFormat.D3DFMT_A8R8G8B8: format = DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM; break;
    //        }
    //
    //        DirectXTex.ImageStruct img = new DirectXTex.ImageStruct();
    //        img.Data = data;
    //        img.Width = texture.Width;
    //        img.Height = texture.Height;
    //        img.MipMapLevels = texture.MipMapLevels;
    //        img.Format = (int)format;
    //
    //        DirectXTex.DDSIO.WriteDDS(fileName, img);
    //    }
    //
    //}
}
