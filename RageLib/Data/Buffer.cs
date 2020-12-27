using System;
using System.Buffers;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace RageLib.Data
{
    public readonly ref struct Buffer<T> where T : unmanaged
    {
        public readonly byte[] Bytes;

        public readonly int Size;

        public readonly int Count;

        public Buffer(int count)
        {
            Size = count * Unsafe.SizeOf<T>();
            Bytes = ArrayPool<byte>.Shared.Rent(Size);
            Count = count;
        }

        public Span<T> Span
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => MemoryMarshal.Cast<byte, T>(Bytes.AsSpan(0, Size));
        }

        public Span<byte> BytesSpan
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Bytes.AsSpan(0, Size);
        }

        public void Dispose()
        {
            ArrayPool<byte>.Shared.Return(Bytes);
        }

        public void Reverse()
        {
            if (Unsafe.SizeOf<T>() > 1)
            {
                for (int i = 0; i < Count; i++)
                    Bytes.AsSpan(i * Unsafe.SizeOf<T>(), Unsafe.SizeOf<T>()).Reverse();
            }
        }
    }
}
