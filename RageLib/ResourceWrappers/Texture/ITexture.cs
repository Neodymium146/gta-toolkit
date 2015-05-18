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

using System.Collections.Generic;

namespace RageLib.ResourceWrappers
{
    // D3DFORMAT
    public enum TextureFormat
    {
        D3DFMT_A8R8G8B8 = 21,
        D3DFMT_A1R5G5B5 = 25,
        D3DFMT_A8 = 28,
        D3DFMT_A8B8G8R8 = 32,
        D3DFMT_L8 = 50,

        // fourCC
        D3DFMT_DXT1 = 0x31545844,
        D3DFMT_DXT3 = 0x33545844,
        D3DFMT_DXT5 = 0x35545844,
        D3DFMT_ATI1 = 0x31495441,
        D3DFMT_ATI2 = 0x32495441,
        D3DFMT_BC7 = 0x20374342,

        UNKNOWN
    }

    /// <summary>
    /// Represents a texture list.
    /// </summary>
    public interface ITextureList : IList<ITexture>
    { }

    /// <summary>
    /// Represents a texture.
    /// </summary>
    public interface ITexture
    {
        /// <summary>
        /// Gets or sets the name of the texture.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets the width of the texture.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Gets the height of the texture.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Gets the number of mipmaps of the texture.
        /// </summary>
        int MipMapLevels { get; }

        /// <summary>
        /// Gets the compression format of the texture.
        /// </summary>
        TextureFormat Format { get; }

        int Stride { get; }

        /// <summary>
        /// Gets the texture data.
        /// </summary>
        byte[] GetTextureData();

        /// <summary>
        /// Gets the texture data of the specified mipMapLevel.
        /// </summary>
        byte[] GetTextureData(int mipMapLevel);

        /// <summary>
        /// Sets the texture data.
        /// </summary>
        void SetTextureData(byte[] data);

        /// <summary>
        /// Sets the texture data of the specified mipMapLevel.
        /// </summary>
        void SetTextureData(byte[] data, int mipMapLevel);

        /// <summary>
        /// Resets all the data of the texture.
        /// </summary>
        void Reset(
            int width,
            int height,
            int mipMapLevels,
            int stride,
            TextureFormat Format);        
    }
}