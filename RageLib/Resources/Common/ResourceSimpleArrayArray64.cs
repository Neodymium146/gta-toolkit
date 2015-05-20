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
    public class ResourceSimpleArrayArray64<T> : ListBase<ResourceSimpleArray<T>> where T : IResourceSystemBlock, new()
    {
        /// <summary>
        /// Gets the length of the data block.
        /// </summary>
        public override long Length
        {
            get
            {
                long len = 8 * Data.Count;
                foreach (var f in Data)
                    len += f.Length;
                return len;
            }
        }


        public ResourceSimpleArrayArray64()
        {
            Data = new List<ResourceSimpleArray<T>>();
        }




        public List<ulong> ptr_list;



        /// <summary>
        /// Reads the data block.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {

            var numEl = (ResourceSimpleArray<uint_r>)parameters[1];

            ptr_list = new List<ulong>();
            for (int i = 0; i < numEl.Count; i++)
                ptr_list.Add(reader.ReadUInt64());

            for (int i = 0; i < numEl.Count; i++)
            {
                var xarr = reader.ReadBlockAt<ResourceSimpleArray<T>>(ptr_list[i], (uint)numEl[i]);
                Data.Add(xarr);
            }

            //int numElements = Convert.ToInt32(parameters[0]);

                //Data = new List<T>();
                //for (int i = 0; i < numElements; i++)
                //{
                //    T item = reader.ReadBlock<T>();
                //    Data.Add(item);
                //}
        }

        /// <summary>
        /// Writes the data block.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            //foreach (var f in Data)
            //    f.Write(writer);

            ptr_list = new List<ulong>();
            foreach (var x in Data)
                ptr_list.Add((ulong)x.Position);

            foreach (var x in ptr_list)
                writer.Write(x);

        }



        public override IResourceBlock[] GetReferences()
        {
            var children = new List<IResourceBlock>();

            //if (Data != null) children.AddRange(Data);

            return children.ToArray();
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            var children = new List<Tuple<long, IResourceBlock>>();

            if (Data != null)
            {
                long len = 8 * Data.Count;
                foreach (var f in Data)
                {
                    children.Add(new Tuple<long, IResourceBlock>(len, f));
                    len += f.Length;
                }
            }
      
            return children.ToArray();
        }

    }
}