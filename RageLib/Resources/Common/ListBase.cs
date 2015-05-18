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

using System.Collections;
using System.Collections.Generic;

namespace RageLib.Resources.Common
{
    public abstract class ListBase<T> : ResourceSystemBlock, IList<T> where T : IResourceSystemBlock, new()
    {

        // this is the data...
        public List<T> Data { get; set; }





        public T this[int index]
        {
            get
            {
                return Data[index];
            }
            set
            {
                Data[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return Data.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }






        public ListBase()
        {
            Data = new List<T>();
        }





        public void Add(T item)
        {
            Data.Add(item);
        }

        public void Clear()
        {
            Data.Clear();
        }

        public bool Contains(T item)
        {
            return Data.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Data.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return Data.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            Data.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return Data.Remove(item);
        }

        public void RemoveAt(int index)
        {
            Data.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Data.GetEnumerator();
        }
    }
}
