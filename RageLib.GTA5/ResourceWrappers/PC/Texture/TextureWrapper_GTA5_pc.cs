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

using RageLib.Resources.Common;
using RageLib.Resources.GTA5.PC.Texture;
using System;
using System.Collections;
using System.Collections.Generic;

namespace RageLib.ResourceWrappers.GTA5.PC.Texture
{
    /// <summary>
    /// Represents a wrapper for a GTA5 PC texture list.
    /// </summary>
    public class TextureListWrapper_GTA5_pc : ITextureList
    {
        private IList<Texture_GTA5_pc> list;

        public TextureListWrapper_GTA5_pc(IList<Texture_GTA5_pc> list)
        {
            this.list = list;
        }



        public ITexture this[int index]
        {
            get
            {
                return new TextureWrapper_GTA5_pc(list[index]);
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Count
        {
            get
            {
                return list.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(ITexture item)
        {
            list.Add(((TextureWrapper_GTA5_pc)item).texture);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(ITexture item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(ITexture[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ITexture> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(ITexture item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, ITexture item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(ITexture item)
        {
            return list.Remove(((TextureWrapper_GTA5_pc)item).texture);
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Represents a wrapper for a GTA5 PC texture.
    /// </summary>
    public class TextureWrapper_GTA5_pc : ITexture
    {

        public Texture_GTA5_pc texture;

        public string Name
        {
            get
            {
                return (string)texture.Name;
            }
            set
            {
                texture.Name = (string_r)value;
            }
        }

        public int Width
        {
            get
            {
                return texture.Width;
            }
        }

        public int Height
        {
            get
            {
                return texture.Height;

            }
        }

        public TextureFormat Format
        {
            get
            {
                return (TextureFormat)texture.Format;
            }
        }

        public int Levels
        {
            get
            {
                return texture.Levels;
            }
        }

        public int MipMapLevels
        {
            get
            {
                return texture.Levels;
            }
        }

        public int Stride
        {
            get
            {
                return texture.Stride;
            }
        }

        public TextureWrapper_GTA5_pc()
        {
            this.texture = new Texture_GTA5_pc();
            this.texture.Data = new TextureData_GTA5_pc();
        }

        public TextureWrapper_GTA5_pc(Texture_GTA5_pc texture)
        {
            this.texture = texture;
        }


        public void Encode(byte[] data, TextureFormat format)
        {
            throw new NotImplementedException();
        }


        public byte[] GetTextureData(int mipMapLevel)
        {
            //byte[] data = null;

            //switch (texture.Type)
            //{
            //    case 0x31545844:
            //        {
            //            data = TextureCompression.DecompressDXT1(texture.Data.Data[0], texture.Width, texture.Height);
            //            break;
            //        }
            //    case 0x33545844:
            //        {
            //            data = TextureCompression.DecompressDXT3(texture.Data.Data[0], texture.Width, texture.Height);
            //            break;
            //        }
            //    case 0x35545844:
            //        {
            //            data = TextureCompression.DecompressDXT5(texture.Data.Data[0], texture.Width, texture.Height);
            //            break;
            //        }
            //    case 0x00000015:
            //    case 0x0000001C:
            //        {
            //            data = texture.Data.Data[0];
            //            break;
            //        }
            //}


            //return data;

            //return texture.Data.Data[mipMapLevel];

            int offset = 0;
            int length = texture.Height * texture.Stride;
            for (int i = 0; i < mipMapLevel - 1; i++)
            {
                offset += length;
                length /= 4;
            }

            byte[] buf = new byte[length];
            Buffer.BlockCopy(texture.Data.FullData, offset, buf, 0, buf.Length);

            return buf;
        }

        public void SetTextureData(byte[] data, int mipMapLevel)
        {
            int offset = 0;
            int length = texture.Height * texture.Stride;
            for (int i = 0; i < mipMapLevel - 1; i++)
            {
                offset += length;
                length /= 4;
            }

            //texture.Data.Data[mipMapLevel] = (byte[])data.Clone();
            byte[] buf = new byte[length];
            Buffer.BlockCopy(data, 0, texture.Data.FullData, offset, data.Length);
        }



        public byte[] GetTextureData()
        {
            return (byte[])texture.Data.FullData.Clone();
        }

        public void SetTextureData(byte[] data)
        {
            texture.Data.FullData = (byte[])data.Clone();
        }

        public void Reset(int width, int height, int mipMapLevels, int stride, TextureFormat format)
        {
            texture.Width = (ushort)width;
            texture.Height = (ushort)height;
            texture.Levels = (byte)mipMapLevels;
            texture.Stride = (ushort)stride;
            texture.Format = (uint)format;
        }




        public void UpdateClass()
        {

            texture.VFT = 0x40619638;
            texture.Unknown_4h = 0x00000001;
            texture.Unknown_8h = 0x00000000;
            texture.Unknown_Ch = 0x00000000;
            texture.Unknown_10h = 0x00000000;
            texture.Unknown_14h = 0x00000000;
            texture.Unknown_18h = 0x00000000;
            texture.Unknown_1Ch = 0x00000000;
            texture.Unknown_20h = 0x00000000;
            texture.Unknown_24h = 0x00000000;
            texture.Unknown_30h = 0x00800001; // ??
            texture.Unknown_34h = 0x00000000;
            texture.Unknown_38h = 0x00000000;
            texture.Unknown_3Ch = 0x00000000;
            texture.Unknown_40h = 0x00000000; // ??
            texture.Unknown_44h = 0x00000000;
            texture.Unknown_48h = 0x00000000;
            texture.Unknown_4Ch = 0x00000000;
            texture.Unknown_54h = 0x0001;
            texture.Unknown_5Ch = 0x00;
            texture.Unknown_5Eh = 0x0000;
            texture.Unknown_60h = 0x00000000;
            texture.Unknown_64h = 0x00000000;
            texture.Unknown_68h = 0x00000000;
            texture.Unknown_6Ch = 0x00000000;
            texture.Unknown_78h = 0x00000000;
            texture.Unknown_7Ch = 0x00000000;
            texture.Unknown_80h = 0x00000000;
            texture.Unknown_84h = 0x00000000;
            texture.Unknown_88h = 0x00000000;
            texture.Unknown_8Ch = 0x00000000;
        }
    }
}