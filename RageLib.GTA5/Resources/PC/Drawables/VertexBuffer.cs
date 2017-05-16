/*
    Copyright(c) 2017 Neodymium

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

namespace RageLib.Resources.GTA5.PC.Drawables
{
    // datBase
    // grcVertexBuffer
    // grcVertexBufferD3D11
    public class VertexBuffer : ResourceSystemBlock
    {
        public override long Length => 0x80;

        // structure data
        public uint VFT;
        public uint Unknown_4h; // 0x00000001
        public ushort VertexStride;
        public ushort Unknown_Ah;
        public uint Unknown_Ch; // 0x00000000
        public ulong DataPointer1;
        public uint VertexCount;
        public uint Unknown_1Ch; // 0x00000000
        public ulong DataPointer2;
        public uint Unknown_28h; // 0x00000000
        public uint Unknown_2Ch; // 0x00000000
        public ulong InfoPointer;
        public uint Unknown_38h; // 0x00000000
        public uint Unknown_3Ch; // 0x00000000
        public uint Unknown_40h; // 0x00000000
        public uint Unknown_44h; // 0x00000000
        public uint Unknown_48h; // 0x00000000
        public uint Unknown_4Ch; // 0x00000000
        public uint Unknown_50h; // 0x00000000
        public uint Unknown_54h; // 0x00000000
        public uint Unknown_58h; // 0x00000000
        public uint Unknown_5Ch; // 0x00000000
        public uint Unknown_60h; // 0x00000000
        public uint Unknown_64h; // 0x00000000
        public uint Unknown_68h; // 0x00000000
        public uint Unknown_6Ch; // 0x00000000
        public uint Unknown_70h; // 0x00000000
        public uint Unknown_74h; // 0x00000000
        public uint Unknown_78h; // 0x00000000
        public uint Unknown_7Ch; // 0x00000000

        // reference data
        public VertexData_GTA5_pc Data1;
        public VertexData_GTA5_pc Data2;
        public VertexDeclaration Info;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.VFT = reader.ReadUInt32();
            this.Unknown_4h = reader.ReadUInt32();
            this.VertexStride = reader.ReadUInt16();
            this.Unknown_Ah = reader.ReadUInt16();
            this.Unknown_Ch = reader.ReadUInt32();
            this.DataPointer1 = reader.ReadUInt64();
            this.VertexCount = reader.ReadUInt32();
            this.Unknown_1Ch = reader.ReadUInt32();
            this.DataPointer2 = reader.ReadUInt64();
            this.Unknown_28h = reader.ReadUInt32();
            this.Unknown_2Ch = reader.ReadUInt32();
            this.InfoPointer = reader.ReadUInt64();
            this.Unknown_38h = reader.ReadUInt32();
            this.Unknown_3Ch = reader.ReadUInt32();
            this.Unknown_40h = reader.ReadUInt32();
            this.Unknown_44h = reader.ReadUInt32();
            this.Unknown_48h = reader.ReadUInt32();
            this.Unknown_4Ch = reader.ReadUInt32();
            this.Unknown_50h = reader.ReadUInt32();
            this.Unknown_54h = reader.ReadUInt32();
            this.Unknown_58h = reader.ReadUInt32();
            this.Unknown_5Ch = reader.ReadUInt32();
            this.Unknown_60h = reader.ReadUInt32();
            this.Unknown_64h = reader.ReadUInt32();
            this.Unknown_68h = reader.ReadUInt32();
            this.Unknown_6Ch = reader.ReadUInt32();
            this.Unknown_70h = reader.ReadUInt32();
            this.Unknown_74h = reader.ReadUInt32();
            this.Unknown_78h = reader.ReadUInt32();
            this.Unknown_7Ch = reader.ReadUInt32();

            // read reference data
            this.Info = reader.ReadBlockAt<VertexDeclaration>(
                this.InfoPointer // offset
            );
            this.Data1 = reader.ReadBlockAt<VertexData_GTA5_pc>(
                this.DataPointer1, // offset
                this.VertexStride,
                this.VertexCount,
                this.Info
            );
            this.Data2 = reader.ReadBlockAt<VertexData_GTA5_pc>(
                this.DataPointer2, // offset
                this.VertexStride,
                this.VertexCount,
                this.Info
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            this.DataPointer1 = (ulong)(this.Data1 != null ? this.Data1.Position : 0);
            this.DataPointer2 = (ulong)(this.Data2 != null ? this.Data2.Position : 0);
            this.InfoPointer = (ulong)(this.Info != null ? this.Info.Position : 0);

            // write structure data
            writer.Write(this.VFT);
            writer.Write(this.Unknown_4h);
            writer.Write(this.VertexStride);
            writer.Write(this.Unknown_Ah);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.DataPointer1);
            writer.Write(this.VertexCount);
            writer.Write(this.Unknown_1Ch);
            writer.Write(this.DataPointer2);
            writer.Write(this.Unknown_28h);
            writer.Write(this.Unknown_2Ch);
            writer.Write(this.InfoPointer);
            writer.Write(this.Unknown_38h);
            writer.Write(this.Unknown_3Ch);
            writer.Write(this.Unknown_40h);
            writer.Write(this.Unknown_44h);
            writer.Write(this.Unknown_48h);
            writer.Write(this.Unknown_4Ch);
            writer.Write(this.Unknown_50h);
            writer.Write(this.Unknown_54h);
            writer.Write(this.Unknown_58h);
            writer.Write(this.Unknown_5Ch);
            writer.Write(this.Unknown_60h);
            writer.Write(this.Unknown_64h);
            writer.Write(this.Unknown_68h);
            writer.Write(this.Unknown_6Ch);
            writer.Write(this.Unknown_70h);
            writer.Write(this.Unknown_74h);
            writer.Write(this.Unknown_78h);
            writer.Write(this.Unknown_7Ch);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>();
            if (Data1 != null) list.Add(Data1);
            if (Data2 != null) list.Add(Data2);
            if (Info != null) list.Add(Info);
            return list.ToArray();
        }
    }

    public class VertexData_GTA5_pc : ResourceSystemBlock
    {


        private int length = 0;
        public override long Length
        {
            get
            {
                return this.length;
            }
        }



        public int cnt;
        private VertexDeclaration info;
        public object[] VertexData;
        private uint[] Types;




        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            int stride = Convert.ToInt32(parameters[0]);
            int count = Convert.ToInt32(parameters[1]);
            var info = (VertexDeclaration)parameters[2];
            this.cnt = count;
            this.info = info;



            bool[] IsUsed = new bool[16];
            for (int i = 0; i < 16; i++)
                IsUsed[i] = ((info.Flags >> i) & 0x1) == 1;

            Types = new uint[16];
            for (int i = 0; i < 16; i++)
                Types[i] = (uint)((info.Types >> (int)(4 * i)) & 0xF);



            VertexData = new object[16];
            for (int i = 0; i < 16; i++)
            {
                if (IsUsed[i])
                {
                    switch (Types[i])
                    {
                        case 0: VertexData[i] = new ushort[1 * count]; break;
                        case 1: VertexData[i] = new ushort[2 * count]; break;
                        case 2: VertexData[i] = new ushort[3 * count]; break;
                        case 3: VertexData[i] = new ushort[4 * count]; break;
                        case 4: VertexData[i] = new float[1 * count]; break;
                        case 5: VertexData[i] = new float[2 * count]; break;
                        case 6: VertexData[i] = new float[3 * count]; break;
                        case 7: VertexData[i] = new float[4 * count]; break;
                        case 8: VertexData[i] = new uint[count]; break;
                        case 9: VertexData[i] = new uint[count]; break;
                        case 10: VertexData[i] = new uint[count]; break;
                        default:
                            throw new Exception();
                    }
                }
            }



            long pos = reader.Position;

            // read...
            for (int i = 0; i < count; i++)
            {

                for (int k = 0; k < 16; k++)
                {
                    if (IsUsed[k])
                    {
                        switch (Types[k])
                        {
                            // float16
                            case 0:
                                {
                                    var buf = VertexData[k] as ushort[];
                                    buf[i * 1 + 0] = reader.ReadUInt16();
                                    break;
                                }
                            case 1:
                                {
                                    var buf = VertexData[k] as ushort[];
                                    buf[i * 2 + 0] = reader.ReadUInt16();
                                    buf[i * 2 + 1] = reader.ReadUInt16();
                                    break;
                                }
                            case 2:
                                {
                                    var buf = VertexData[k] as ushort[];
                                    buf[i * 3 + 0] = reader.ReadUInt16();
                                    buf[i * 3 + 1] = reader.ReadUInt16();
                                    buf[i * 3 + 2] = reader.ReadUInt16();
                                    break;
                                }
                            case 3:
                                {
                                    var buf = VertexData[k] as ushort[];
                                    buf[i * 4 + 0] = reader.ReadUInt16();
                                    buf[i * 4 + 1] = reader.ReadUInt16();
                                    buf[i * 4 + 2] = reader.ReadUInt16();
                                    buf[i * 4 + 3] = reader.ReadUInt16();
                                    break;
                                }

                            // float32
                            case 4:
                                {
                                    var buf = VertexData[k] as float[];
                                    buf[i * 1 + 0] = reader.ReadSingle();
                                    break;
                                }
                            case 5:
                                {
                                    var buf = VertexData[k] as float[];
                                    buf[i * 2 + 0] = reader.ReadSingle();
                                    buf[i * 2 + 1] = reader.ReadSingle();
                                    break;
                                }
                            case 6:
                                {
                                    var buf = VertexData[k] as float[];
                                    buf[i * 3 + 0] = reader.ReadSingle();
                                    buf[i * 3 + 1] = reader.ReadSingle();
                                    buf[i * 3 + 2] = reader.ReadSingle();
                                    break;
                                }
                            case 7:
                                {
                                    var buf = VertexData[k] as float[];
                                    buf[i * 4 + 0] = reader.ReadSingle();
                                    buf[i * 4 + 1] = reader.ReadSingle();
                                    buf[i * 4 + 2] = reader.ReadSingle();
                                    buf[i * 4 + 3] = reader.ReadSingle();
                                    break;
                                }

                            case 8:
                            case 9:
                            case 10:
                                {
                                    var buf = VertexData[k] as uint[];
                                    buf[i * 1 + 0] = reader.ReadUInt32();
                                    break;
                                }

                            default:
                                throw new Exception();
                        }
                    }
                }

            }

            this.length = stride * count;
        }

        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {

            // write...
            for (int i = 0; i < cnt; i++)
            {

                for (int k = 0; k < 16; k++)
                {
                    if (VertexData[k] != null)
                    {
                        switch (Types[k])
                        {
                            // float16
                            case 0:
                                {
                                    var buf = VertexData[k] as ushort[];
                                    writer.Write(buf[i * 1 + 0]);
                                    break;
                                }
                            case 1:
                                {
                                    var buf = VertexData[k] as ushort[];
                                    writer.Write(buf[i * 2 + 0]);
                                    writer.Write(buf[i * 2 + 1]);
                                    break;
                                }
                            case 2:
                                {
                                    var buf = VertexData[k] as ushort[];
                                    writer.Write(buf[i * 3 + 0]);
                                    writer.Write(buf[i * 3 + 1]);
                                    writer.Write(buf[i * 3 + 2]);
                                    break;
                                }
                            case 3:
                                {
                                    var buf = VertexData[k] as ushort[];
                                    writer.Write(buf[i * 4 + 0]);
                                    writer.Write(buf[i * 4 + 1]);
                                    writer.Write(buf[i * 4 + 2]);
                                    writer.Write(buf[i * 4 + 3]);
                                    break;
                                }

                            // float32
                            case 4:
                                {
                                    var buf = VertexData[k] as float[];
                                    writer.Write(buf[i * 1 + 0]);
                                    break;
                                }
                            case 5:
                                {
                                    var buf = VertexData[k] as float[];
                                    writer.Write(buf[i * 2 + 0]);
                                    writer.Write(buf[i * 2 + 1]);
                                    break;
                                }
                            case 6:
                                {
                                    var buf = VertexData[k] as float[];
                                    writer.Write(buf[i * 3 + 0]);
                                    writer.Write(buf[i * 3 + 1]);
                                    writer.Write(buf[i * 3 + 2]);
                                    break;
                                }
                            case 7:
                                {
                                    var buf = VertexData[k] as float[];
                                    writer.Write(buf[i * 4 + 0]);
                                    writer.Write(buf[i * 4 + 1]);
                                    writer.Write(buf[i * 4 + 2]);
                                    writer.Write(buf[i * 4 + 3]);
                                    break;
                                }

                            case 8:
                            case 9:
                            case 10:
                                {
                                    var buf = VertexData[k] as uint[];
                                    writer.Write(buf[i * 1 + 0]);
                                    break;
                                }

                            default:
                                throw new Exception();
                        }
                    }
                }

            }

        }

    }
}
