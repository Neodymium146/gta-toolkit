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
using System.IO;

namespace RageLib.Data
{
    public delegate long GetOffsetDelegate();
    public delegate long GetLengthDelegate();
    public delegate void SetLengthDelegate(long length);

    /// <summary>
    /// Represents a part of a stream.
    /// </summary>
    public class PartialStream : Stream
    {
        private Stream baseStream;
        private GetOffsetDelegate getOffsetDelegate;
        private GetLengthDelegate getLengthDelegate;
        private SetLengthDelegate setLengthDelegate;
        private long relativePosiiton;

        /// <summary>
        /// Gets a value indicating whether the stream supports seeking. 
        /// </summary>
        public override bool CanSeek
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the stream supports reading. 
        /// </summary>
        public override bool CanRead
        {
            get
            {
                return baseStream.CanRead;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the stream supports writing. 
        /// </summary>
        public override bool CanWrite
        {
            get
            {
                return baseStream.CanWrite;
            }
        }

        /// <summary>
        /// Gets the length of the stream.
        /// </summary>
        public override long Length
        {
            get
            {
                return getLengthDelegate();
            }
        }

        /// <summary>
        /// Gets or sets the position within the stream.
        /// </summary>
        public override long Position
        {
            get
            {
                return relativePosiiton;
            }
            set
            {
                //value = Math.Min(value, getLengthDelegate());
                //value = Math.Max(value, 0);
                if (Position > Length)
                    SetLength(Position);                
                relativePosiiton = value;
            }
        }

        public PartialStream(
            Stream baseStream,
            GetOffsetDelegate getOffsetDelegate,
            GetLengthDelegate getLengthDelegate,
            SetLengthDelegate setLengthDelegate = null)
        {
            this.baseStream = baseStream;
            this.getOffsetDelegate = getOffsetDelegate;
            this.getLengthDelegate = getLengthDelegate;
            this.setLengthDelegate = setLengthDelegate;
        }

        /// <summary>
        /// Reads a sequence of bytes from the stream.
        /// </summary>
        public override int Read(byte[] buffer, int offset, int count)
        {
            // backup position
            var positionBackup = baseStream.Position;

            int maxCount = (int)(getLengthDelegate() - relativePosiiton);
            int newcount = Math.Min(count, maxCount);

            baseStream.Position = getOffsetDelegate() + relativePosiiton;
            int r = baseStream.Read(buffer, offset, newcount);
            relativePosiiton += r;

            // restore position
            baseStream.Position = positionBackup;

            return r;
        }

        /// <summary>
        /// Writes a sequence of bytes to the stream.
        /// </summary>
        public override void Write(byte[] buffer, int offset, int count)
        {
            // backup position
            var positionBackup = baseStream.Position;

            var newlen = relativePosiiton + count;
            if (newlen > Length)
                setLengthDelegate(newlen);

            int maxCount = (int)(getLengthDelegate() - relativePosiiton);
            var newcount = Math.Min(count, maxCount);

            baseStream.Position = getOffsetDelegate() + relativePosiiton;
            baseStream.Write(buffer, offset, count);
            relativePosiiton += count;

            // restore position
            baseStream.Position = positionBackup;
        }

        /// <summary>
        /// Sets the position within the stream. 
        /// </summary>
        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    {
                        relativePosiiton = offset;
                        break;
                    }
                case SeekOrigin.Current:
                    {
                        relativePosiiton += offset;
                        break;
                    }
                case SeekOrigin.End:
                    {
                        relativePosiiton = getLengthDelegate() + offset;
                        break;
                    }
            }

            return relativePosiiton;
        }

        /// <summary>
        /// Sets the length of the stream. 
        /// </summary>
        public override void SetLength(long value)
        {
            setLengthDelegate(value);
        }

        /// <summary>
        /// Clears all buffers for the stream.
        /// </summary>
        public override void Flush()
        {
            baseStream.Flush();
        }
    }
}