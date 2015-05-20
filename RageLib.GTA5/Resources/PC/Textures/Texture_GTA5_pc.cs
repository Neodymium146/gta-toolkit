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

namespace RageLib.Resources.GTA5.PC.Textures
{
    public class Texture_GTA5_pc : TextureBase_GTA5_pc
    {
        public override long Length
        {
            get { return 144; }
        }

        // structure data
        public uint Unknown_40h;
        public uint Unknown_44h;
        public uint Unknown_48h;
        public uint Unknown_4Ch;
        public ushort Width;
        public ushort Height;
        public ushort Unknown_54h;
        public ushort Stride;
        public uint Format;
        public byte Unknown_5Ch;
        public byte Levels;
        public ushort Unknown_5Eh;
        public uint Unknown_60h;
        public uint Unknown_64h;
        public uint Unknown_68h;
        public uint Unknown_6Ch;
        public ulong DataPointer;
        public uint Unknown_78h;
        public uint Unknown_7Ch;
        public uint Unknown_80h;
        public uint Unknown_84h;
        public uint Unknown_88h;
        public uint Unknown_8Ch;

        // reference data
        public TextureData_GTA5_pc Data;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.Unknown_40h = reader.ReadUInt32();
            this.Unknown_44h = reader.ReadUInt32();
            this.Unknown_48h = reader.ReadUInt32();
            this.Unknown_4Ch = reader.ReadUInt32();
            this.Width = reader.ReadUInt16();
            this.Height = reader.ReadUInt16();
            this.Unknown_54h = reader.ReadUInt16();
            this.Stride = reader.ReadUInt16();
            this.Format = reader.ReadUInt32();
            this.Unknown_5Ch = reader.ReadByte();
            this.Levels = reader.ReadByte();
            this.Unknown_5Eh = reader.ReadUInt16();
            this.Unknown_60h = reader.ReadUInt32();
            this.Unknown_64h = reader.ReadUInt32();
            this.Unknown_68h = reader.ReadUInt32();
            this.Unknown_6Ch = reader.ReadUInt32();
            this.DataPointer = reader.ReadUInt64();
            this.Unknown_78h = reader.ReadUInt32();
            this.Unknown_7Ch = reader.ReadUInt32();
            this.Unknown_80h = reader.ReadUInt32();
            this.Unknown_84h = reader.ReadUInt32();
            this.Unknown_88h = reader.ReadUInt32();
            this.Unknown_8Ch = reader.ReadUInt32();
            
            // read reference data
            this.Data = reader.ReadBlockAt<TextureData_GTA5_pc>(
                this.DataPointer, // offset
                this.Format,
                this.Width,
                this.Height,
                this.Levels,
                this.Stride
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            this.DataPointer = (ulong)this.Data.Position;

            // write structure data
            writer.Write(this.Unknown_40h);
            writer.Write(this.Unknown_44h);
            writer.Write(this.Unknown_48h);
            writer.Write(this.Unknown_4Ch);
            writer.Write(this.Width);
            writer.Write(this.Height);
            writer.Write(this.Unknown_54h);
            writer.Write(this.Stride);
            writer.Write(this.Format);
            writer.Write(this.Unknown_5Ch);
            writer.Write(this.Levels);
            writer.Write(this.Unknown_5Eh);
            writer.Write(this.Unknown_60h);
            writer.Write(this.Unknown_64h);
            writer.Write(this.Unknown_68h);
            writer.Write(this.Unknown_6Ch);
            writer.Write(this.DataPointer);
            writer.Write(this.Unknown_78h);
            writer.Write(this.Unknown_7Ch);
            writer.Write(this.Unknown_80h);
            writer.Write(this.Unknown_84h);
            writer.Write(this.Unknown_88h);
            writer.Write(this.Unknown_8Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>(base.GetReferences());
            list.Add(Data);
            return list.ToArray();
        }
    }

    public class TextureData_GTA5_pc : ResourceGraphicsBlock
    {
        //public override long Length
        //{
        //    get
        //    {
        //        int length = 0;
        //        foreach (var x in Data)
        //            length += x.Length;
        //        return length;
        //    }
        //}

        //public List<byte[]> Data;

        public override long Length
        {
            get
            {
                return FullData.Length;
            }
        }

        public byte[] FullData;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            uint format = Convert.ToUInt32(parameters[0]);
            int Width = Convert.ToInt32(parameters[1]);
            int Height = Convert.ToInt32(parameters[2]);
            int Levels = Convert.ToInt32(parameters[3]);
            int Stride = Convert.ToInt32(parameters[4]);

            //Data = new List<byte[]>();
            //int length = Stride * Height;
            //for (int i = 0; i < Levels; i++)
            //{
            //    var buf = reader.ReadBytes(length);
            //    Data.Add(buf);
            //    length /= 4;
            //}

            int fullLength = 0;
            int length = Stride * Height;
            for (int i = 0; i < Levels; i++)
            {
                fullLength += length;
                length /= 4;
            }

            FullData = reader.ReadBytes(fullLength);
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            //foreach (var q in Data)
            //    writer.Write(q);

            writer.Write(FullData);
        }
    }
}