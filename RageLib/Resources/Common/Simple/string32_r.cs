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

using System.Text;

namespace RageLib.Resources.Common
{
    // TODO: rework this, consider handling fixed length strings in DataReader/DataWriter
    public class string32_r : string_r
    {
        public override long BlockLength => 0x20;

        // structure data
        private byte[] Data;

        public new string Value
        {
            get
            {
                return Data != null ? Encoding.ASCII.GetString(Data).TrimEnd('\0') : null;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    return;

                string name = value.Length > 0x20 ? value.Substring(0, 0x20) : value.PadRight(0x20, '\0');
                Data = Encoding.ASCII.GetBytes(name);
            }
        }

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.Data = reader.ReadBytes(0x20);
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            if (string.IsNullOrEmpty(Value)) 
                Value = "INVALID_STRING";

            // write structure data
            writer.Write(this.Data);
        }
    }
}
