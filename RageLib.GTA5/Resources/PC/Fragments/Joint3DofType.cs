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

using System.Numerics;

namespace RageLib.Resources.GTA5.PC.Fragments
{
    // phJoint3DofType
    public class Joint3DofType : JointType
    {
        public override long BlockLength => 0xF0;

        // structure data
        public Vector4 Unknown_20h;
        public Vector4 Unknown_30h;
        public Vector4 Unknown_40h;
        public Vector4 Unknown_50h;
        public Vector4 Unknown_60h;
        public Vector4 Unknown_70h;
        public Vector4 Unknown_80h;
        public Vector4 Unknown_90h;
        public Vector4 Unknown_A0h;
        public Vector4 Unknown_B0h; // 0x00000000
        public Vector4 Unknown_C0h; // 0x4CBEBC20
        public Vector4 Unknown_D0h; // 0xCCBEBC20
        public Vector4 Unknown_E0h; // 0x00000000

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.Unknown_20h = reader.ReadVector4();
            this.Unknown_30h = reader.ReadVector4();
            this.Unknown_40h = reader.ReadVector4();
            this.Unknown_50h = reader.ReadVector4();
            this.Unknown_60h = reader.ReadVector4();
            this.Unknown_70h = reader.ReadVector4();
            this.Unknown_80h = reader.ReadVector4();
            this.Unknown_90h = reader.ReadVector4();
            this.Unknown_A0h = reader.ReadVector4();
            this.Unknown_B0h = reader.ReadVector4();
            this.Unknown_C0h = reader.ReadVector4();
            this.Unknown_D0h = reader.ReadVector4();
            this.Unknown_E0h = reader.ReadVector4();
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // write structure data
            writer.Write(this.Unknown_20h);
            writer.Write(this.Unknown_30h);
            writer.Write(this.Unknown_40h);
            writer.Write(this.Unknown_50h);
            writer.Write(this.Unknown_60h);
            writer.Write(this.Unknown_70h);
            writer.Write(this.Unknown_80h);
            writer.Write(this.Unknown_90h);
            writer.Write(this.Unknown_A0h);
            writer.Write(this.Unknown_B0h);
            writer.Write(this.Unknown_C0h);
            writer.Write(this.Unknown_D0h);
            writer.Write(this.Unknown_E0h);
        }
    }
}
