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
    /// Represents an array of pointers where each points to an object of type T.
    /// </summary>
    public class ResourcePointerArray<T> : ResourceSystemBlock, IList<T> where T : IResourceSystemBlock, new()
    {

        public override long Length
        {
            get { return 4 * data_items.Count; }
        }



        public int ResSize
        {
            get
            {
                return data_items.Count;
            }
        }

        public int ResCount
        {
            get
            {
                int i = 0;
                foreach (var q in data_items)
                    if (q != null)
                        i++;
                return i;
            }
        }




        // structure data
        public List<uint> data_pointers;

        // reference data
        public List<T> data_items;


        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            int numElements = Convert.ToInt32(parameters[0]);

            // read structure data            
            data_pointers = new List<uint>();
            for (int i = 0; i < numElements; i++)
            {
                data_pointers.Add(reader.ReadUInt32());
            }

            // read reference data
            data_items = new List<T>();
            for (int i = 0; i < numElements; i++)
            {
                data_items.Add(
                    reader.ReadBlockAt<T>(data_pointers[i])
                    );
            }
        }

        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update...
            data_pointers = new List<uint>();
            foreach (var x in data_items)
                if (x != null)
                    data_pointers.Add((uint)x.Position);
                else
                    data_pointers.Add((uint)0);

            // write...
            foreach (var x in data_pointers)
                writer.Write(x);
        }






        public override IResourceBlock[] GetReferences()
        {
            List<IResourceBlock> list = new List<IResourceBlock>();

            foreach (var x in data_items)
                list.Add(x);

            return list.ToArray();
        }




        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public T this[int index]
        {
            get
            {
                return this.data_items[index];
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Add(T item)
        {

            this.data_items.Add(item);
            this.data_pointers.Add(0);

        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return data_items.Count; }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {

            foreach (T t in data_items)
            {
                yield return t;
            }


        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


      


    }
}