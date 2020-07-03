using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace RageLib.Resources.Common
{
    /// <summary>
    /// Represents an array of type T.
    /// </summary>
    public class SimpleArray<T> : ResourceSystemBlock where T : unmanaged
    {
        public readonly int SizeOf;

        /// <summary>
        /// Gets the length of the data block.
        /// </summary>
        public override long BlockLength => Data != null ? Data.Count * SizeOf : 0;

        // structure data
        public List<T> Data;

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

            Data.AddRange(reader.ReadUnmanaged<T>(count));
        }

        /// <summary>
        /// Writes the data block.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            writer.WriteUnmanaged<T>(Data.ToArray());
        }
    }
}