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

namespace RageLib.Resources.GTA5.PC.VehicleRecords
{
    // this looks exactly like an rrr entry:
    // -> http://www.gtamodding.com/wiki/Carrec
    public class VehicleRecordsEntry : ResourceSystemBlock
    {
        public override long Length => 0x20;

        // structure data
        public uint Time;
        public ushort VelocityX;
        public ushort VelocityY;
        public ushort VelocityZ;
        public byte RightX;
        public byte RightY;
        public byte RightZ;
        public byte TopX;
        public byte TopY;
        public byte TopZ;
        public byte SteeringAngle;
        public byte GasPedalPower;
        public byte BrakePedalPower;
        public byte HandbrakeUsed;
        public float PositionX;
        public float PositionY;
        public float PositionZ;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.Time = reader.ReadUInt32();
            this.VelocityX = reader.ReadUInt16();
            this.VelocityY = reader.ReadUInt16();
            this.VelocityZ = reader.ReadUInt16();
            this.RightX = reader.ReadByte();
            this.RightY = reader.ReadByte();
            this.RightZ = reader.ReadByte();
            this.TopX = reader.ReadByte();
            this.TopY = reader.ReadByte();
            this.TopZ = reader.ReadByte();
            this.SteeringAngle = reader.ReadByte();
            this.GasPedalPower = reader.ReadByte();
            this.BrakePedalPower = reader.ReadByte();
            this.HandbrakeUsed = reader.ReadByte();
            this.PositionX = reader.ReadSingle();
            this.PositionY = reader.ReadSingle();
            this.PositionZ = reader.ReadSingle();
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // write structure data
            writer.Write(this.Time);
            writer.Write(this.VelocityX);
            writer.Write(this.VelocityY);
            writer.Write(this.VelocityZ);
            writer.Write(this.RightX);
            writer.Write(this.RightY);
            writer.Write(this.RightZ);
            writer.Write(this.TopX);
            writer.Write(this.TopY);
            writer.Write(this.TopZ);
            writer.Write(this.SteeringAngle);
            writer.Write(this.GasPedalPower);
            writer.Write(this.BrakePedalPower);
            writer.Write(this.HandbrakeUsed);
            writer.Write(this.PositionX);
            writer.Write(this.PositionY);
            writer.Write(this.PositionZ);
        }
    }
}
