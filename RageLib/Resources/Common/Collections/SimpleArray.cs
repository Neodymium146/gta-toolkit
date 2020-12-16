using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace RageLib.Resources.Common
{
    /// <summary>
    /// A <see cref="ResourceSystemBlock"/> which holds an array of unmanaged type.
    /// </summary>
    public class SimpleArray<T> : ResourceSystemBlock, IEnumerable where T : unmanaged
    {
        /// <summary>
        /// Gets the length of the data block.
        /// </summary>
        public override long BlockLength => Data.Length * Unsafe.SizeOf<T>();

        // structure data
        private T[] Data;

        public SimpleArray()
        {
            Data = Array.Empty<T>();
        }

        public SimpleArray(T[] array)
        {
            Data = array;
        }

        /// <summary>
        /// Reads the data block.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            int count = Convert.ToInt32(parameters[0]);

            Data = reader.ReadArray<T>(count);
        }

        /// <summary>
        /// Writes the data block.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            writer.WriteArray<T>(Data);
        }

        public IEnumerator GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        public int Count => Data.Length;

        public T this[int index] 
        { 
            get => Data[index];
            set => Data[index] = value;
        }

        // TODO: Check usage to know if it's safe to return without creating a copy
        public T[] ToArray()
        {
            return (T[])Data.Clone();
        }
    }
}