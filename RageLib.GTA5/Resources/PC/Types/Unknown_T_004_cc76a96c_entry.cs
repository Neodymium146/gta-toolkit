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

namespace RageLib.Resources.GTA5.PC.Types
{
    // occurrences: 502
    public class Unknown_T_004_cc76a96c_entry : ResourceSystemBlock
    {
        public override long Length
        {
            get { return 160; }
        }

        // structure data
        public uint Unknown_0h; // 0x00000000
        public uint Unknown_4h; // 0x00000000
        public uint Unknown_8h; // 0x00000000
        public uint Unknown_Ch; // 0x00000000
        public float Unknown_10h;
        public float Unknown_14h;
        public float Unknown_18h;
        public float Unknown_1Ch; // 0x7F800001
        public float Unknown_20h;
        public float Unknown_24h;
        public float Unknown_28h;
        public float Unknown_2Ch;
        public uint Unknown_30h;
        public float Unknown_34h;
        public float Unknown_38h;
        public uint Unknown_3Ch;
        public uint Unknown_40h;
        public uint Unknown_44h;
        public uint Unknown_48h;
        public uint Unknown_4Ch;
        public uint Unknown_50h;
        public uint Unknown_54h;
        public uint Unknown_58h;
        public uint Unknown_5Ch; // 0x00000000
        public uint Unknown_60h; // 0x00000000
        public uint Unknown_64h; // 0x00000000
        public uint Unknown_68h; // 0x00000000
        public uint Unknown_6Ch; // 0x00000000
        public uint Unknown_70h; // 0x00000000
        public uint Unknown_74h; // 0x00000000
        public uint Unknown_78h; // 0x00000000
        public uint Unknown_7Ch; // 0x00000000
        public uint Unknown_80h;
        public uint Unknown_84h; // 0x42C80000
        public uint Unknown_88h;
        public uint Unknown_8Ch; // 0x00000000
        public uint Unknown_90h;
        public uint Unknown_94h;
        public uint Unknown_98h;
        public uint Unknown_9Ch; // 0x7F800001

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.Unknown_0h = reader.ReadUInt32();
            this.Unknown_4h = reader.ReadUInt32();
            this.Unknown_8h = reader.ReadUInt32();
            this.Unknown_Ch = reader.ReadUInt32();
            this.Unknown_10h = reader.ReadSingle();
            this.Unknown_14h = reader.ReadSingle();
            this.Unknown_18h = reader.ReadSingle();
            this.Unknown_1Ch = reader.ReadSingle();
            this.Unknown_20h = reader.ReadSingle();
            this.Unknown_24h = reader.ReadSingle();
            this.Unknown_28h = reader.ReadSingle();
            this.Unknown_2Ch = reader.ReadSingle();
            this.Unknown_30h = reader.ReadUInt32();
            this.Unknown_34h = reader.ReadSingle();
            this.Unknown_38h = reader.ReadSingle();
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
            this.Unknown_80h = reader.ReadUInt32();
            this.Unknown_84h = reader.ReadUInt32();
            this.Unknown_88h = reader.ReadUInt32();
            this.Unknown_8Ch = reader.ReadUInt32();
            this.Unknown_90h = reader.ReadUInt32();
            this.Unknown_94h = reader.ReadUInt32();
            this.Unknown_98h = reader.ReadUInt32();
            this.Unknown_9Ch = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // write structure data
            writer.Write(this.Unknown_0h);
            writer.Write(this.Unknown_4h);
            writer.Write(this.Unknown_8h);
            writer.Write(this.Unknown_Ch);
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.Write(this.Unknown_18h);
            writer.Write(this.Unknown_1Ch);
            writer.Write(this.Unknown_20h);
            writer.Write(this.Unknown_24h);
            writer.Write(this.Unknown_28h);
            writer.Write(this.Unknown_2Ch);
            writer.Write(this.Unknown_30h);
            writer.Write(this.Unknown_34h);
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
            writer.Write(this.Unknown_80h);
            writer.Write(this.Unknown_84h);
            writer.Write(this.Unknown_88h);
            writer.Write(this.Unknown_8Ch);
            writer.Write(this.Unknown_90h);
            writer.Write(this.Unknown_94h);
            writer.Write(this.Unknown_98h);
            writer.Write(this.Unknown_9Ch);
        }


    }
}