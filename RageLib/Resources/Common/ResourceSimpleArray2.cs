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

namespace RageLib.Resources.Common
{
    /// <summary>
    /// Represents an array of type T.
    /// </summary>
    public class ResourceSimpleArray2<T, U> : ResourceSystemBlock where T : IResourceSystemBlock, new() where U : IResourceSystemBlock, new()
    {
        public ResourceSimpleArray<T> Array1;
        public ResourceSimpleArray<U> Array2;

        /// <summary>
        /// Gets the length of the data block.
        /// </summary>
        public override long Length
        {
            get
            {
                return Array1.Length + Array2.Length;
            }
        }
                
        /// <summary>
        /// Reads the data block.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            int numElements1 = Convert.ToInt32(parameters[0]);
            int numElements2 = Convert.ToInt32(parameters[1]);
            Array1 = reader.ReadBlock<ResourceSimpleArray<T>>(numElements1);
            Array2 = reader.ReadBlock<ResourceSimpleArray<U>>(numElements2);
        }

        /// <summary>
        /// Writes the data block.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            writer.WriteBlock(Array1);
            writer.WriteBlock(Array2);
        }
        



        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            var list = new List<Tuple<long, IResourceBlock>>();
            list.Add(new Tuple<long, IResourceBlock>(0, Array1));
            list.Add(new Tuple<long, IResourceBlock>(Array1.Length, Array2));            
            return list.ToArray();
        }




        
    }
}