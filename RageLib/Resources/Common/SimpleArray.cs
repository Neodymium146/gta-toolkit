using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace RageLib.Resources.Common
{
    /// <summary>
    /// Represents an array of type T.
    /// </summary>
    public class SimpleArray<T> : ResourceSystemBlock, IList<T> where T : unmanaged
    {
        public readonly int SizeOf;

        /// <summary>
        /// Gets the length of the data block.
        /// </summary>
        public override long BlockLength => Data != null ? Data.Count * SizeOf : 0;

        // structure data
        private List<T> Data;

        public SimpleArray()
        {
            Data = new List<T>();
            SizeOf = Unsafe.SizeOf<T>();
        }

        /// <summary>
        /// Reads the data block.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            int count = Convert.ToInt32(parameters[0]);

            Data.Capacity += count;
            Data.AddRange(reader.ReadUnmanaged<T>(count));
        }

        /// <summary>
        /// Writes the data block.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            writer.WriteUnmanaged<T>(Data.ToArray());
        }

        public int Count => Data.Count;

        public bool IsReadOnly => false;

        public T this[int index] 
        { 
            get => Data[index];
            set => Data[index] = value;
        }

        public int IndexOf(T item)
        {
            return Data.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            Data.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            Data.RemoveAt(index);
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

        public bool Remove(T item)
        {
            return Data.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Data.GetEnumerator();
        }
    }
}