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

using RageLib.Data;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace RageLib.Resources.GTA5.PC.Bounds
{
    public interface IBoundPrimitive
    {
        public ref BoundPrimitive AsRawData();
    }

    public enum BoundPrimitiveType : byte
    {
        Triangle = 0,
        Sphere = 1,
        Capsule = 2,
        Box = 3,
        Cylinder = 4,
    }

    // phPrimitiveBase
    // phPrimitive
    public struct BoundPrimitive : IResourceStruct<BoundPrimitive>
    {
        public uint Data0;
        public uint Data1;
        public uint Data2;
        public uint Data3;

        public BoundPrimitiveType PrimitiveType 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (BoundPrimitiveType)(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref this, 1))[0] & 0x7); 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref BoundPrimitiveTriangle AsTriangle() => ref MemoryMarshal.AsRef<BoundPrimitiveTriangle>(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref this, 1)));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref BoundPrimitiveSphere AsSphere() => ref MemoryMarshal.AsRef<BoundPrimitiveSphere>(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref this, 1)));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref BoundPrimitiveCapsule AsCapsule() => ref MemoryMarshal.AsRef<BoundPrimitiveCapsule>(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref this, 1)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref BoundPrimitiveBox AsBox() => ref MemoryMarshal.AsRef<BoundPrimitiveBox>(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref this, 1)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref BoundPrimitiveCylinder AsCylinder() => ref MemoryMarshal.AsRef<BoundPrimitiveCylinder>(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref this, 1)));

        public BoundPrimitive ReverseEndianness()
        {
            return PrimitiveType switch
            {
                BoundPrimitiveType.Triangle => AsTriangle().ReverseEndianness().AsRawData(),
                BoundPrimitiveType.Sphere => AsSphere().ReverseEndianness().AsRawData(),
                BoundPrimitiveType.Capsule => AsSphere().ReverseEndianness().AsRawData(),
                BoundPrimitiveType.Box => AsBox().ReverseEndianness().AsRawData(),
                BoundPrimitiveType.Cylinder => AsCylinder().ReverseEndianness().AsRawData(),
                _ => this,
            };
        }
    }

    // PrimitiveTriangle
    public struct BoundPrimitiveTriangle : IBoundPrimitive, IResourceStruct<BoundPrimitiveTriangle>
    {
        // structure data
        public int triArea;
        public ushort triIndex1;
        public ushort triIndex2;
        public ushort triIndex3;
        public short NeighborIndex1;
        public short NeighborIndex2;
        public short NeighborIndex3;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref BoundPrimitive AsRawData() => ref MemoryMarshal.AsRef<BoundPrimitive>(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref this, 1)));

        public float Area
        {
            get => BitConverter.Int32BitsToSingle((int)(triArea & 0xFFFFFFF8));
            set => triArea = (int)(BitConverter.SingleToInt32Bits(value) & 0xFFFFFFF8);
        }

        public ushort VertexIndex1
        {
            get => (ushort)(triIndex1 & 0x7FFF);
            set => triIndex1 = (ushort)((triIndex1 & 0x8000) | (value & 0x7FFF));
        }

        public ushort VertexIndex2
        {
            get => (ushort)(triIndex2 & 0x7FFF);
            set => triIndex2 = (ushort)((triIndex2 & 0x8000) | (value & 0x7FFF));
        }

        public ushort VertexIndex3
        {
            get => (ushort)(triIndex3 & 0x7FFF);
            set => triIndex3 = (ushort)((triIndex3 & 0x8000) | (value & 0x7FFF));
        }

        public bool VertexFlag1
        {
            get => (triIndex1 & 0x8000) == 0x8000;
            set
            {
                if (value)
                    triIndex1 |= 0x8000;
                else
                    triIndex1 &= 0x7FFF;
            }
        }

        public bool VertexFlag2
        {
            get => (triIndex2 & 0x8000) == 0x8000;
            set
            {
                if (value)
                    triIndex2 |= 0x8000;
                else
                    triIndex2 &= 0x7FFF;
            }
        }

        public bool VertexFlag3
        {
            get => (triIndex3 & 0x8000) == 0x8000;
            set
            {
                if (value)
                    triIndex3 |= 0x8000;
                else
                    triIndex3 &= 0x7FFF;
            }
        }

        public BoundPrimitiveTriangle ReverseEndianness()
        {
            return new BoundPrimitiveTriangle()
            {
                triArea = EndiannessExtensions.ReverseEndianness(triArea),
                triIndex1 = EndiannessExtensions.ReverseEndianness(triIndex1),
                triIndex2 = EndiannessExtensions.ReverseEndianness(triIndex2),
                triIndex3 = EndiannessExtensions.ReverseEndianness(triIndex3),
                NeighborIndex1 = EndiannessExtensions.ReverseEndianness(NeighborIndex1),
                NeighborIndex2 = EndiannessExtensions.ReverseEndianness(NeighborIndex2),
                NeighborIndex3 = EndiannessExtensions.ReverseEndianness(NeighborIndex3),
            };
        }
    }

    // PrimitiveSphere
    public struct BoundPrimitiveSphere : IBoundPrimitive, IResourceStruct<BoundPrimitiveSphere>
    {
        // structure data
        public ushort sphereType;
        public ushort sphereIndex;
        public float sphereRadius;
        public uint unused0;
        public uint unused1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref BoundPrimitive AsRawData() => ref MemoryMarshal.AsRef<BoundPrimitive>(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref this, 1)));

        public BoundPrimitiveSphere ReverseEndianness()
        {
            return new BoundPrimitiveSphere()
            {
                sphereType = EndiannessExtensions.ReverseEndianness(sphereType),
                sphereIndex = EndiannessExtensions.ReverseEndianness(sphereIndex),
                sphereRadius = EndiannessExtensions.ReverseEndianness(sphereRadius),
                unused0 = EndiannessExtensions.ReverseEndianness(unused0),
                unused1 = EndiannessExtensions.ReverseEndianness(unused1),
            };
        }
    }

    // PrimitiveCapsule
    public struct BoundPrimitiveCapsule : IBoundPrimitive, IResourceStruct<BoundPrimitiveCapsule>
    {
        // structure data
        public ushort capsuleType;
        public ushort capsuleIndex1;
        public float capsuleRadius;
        public ushort capsuleIndex2;
        public ushort unused0;
        public uint unused1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref BoundPrimitive AsRawData() => ref MemoryMarshal.AsRef<BoundPrimitive>(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref this, 1)));

        public BoundPrimitiveCapsule ReverseEndianness()
        {
            return new BoundPrimitiveCapsule()
            {
                capsuleType = EndiannessExtensions.ReverseEndianness(capsuleType),
                capsuleIndex1 = EndiannessExtensions.ReverseEndianness(capsuleIndex1),
                capsuleRadius = EndiannessExtensions.ReverseEndianness(capsuleRadius),
                capsuleIndex2 = EndiannessExtensions.ReverseEndianness(capsuleIndex2),
                unused0 = EndiannessExtensions.ReverseEndianness(unused0),
                unused1 = EndiannessExtensions.ReverseEndianness(unused1),
            };
        }
    }

    // PrimitiveBox
    public struct BoundPrimitiveBox : IBoundPrimitive, IResourceStruct<BoundPrimitiveBox>
    {
        // structure data
        public uint boxType;
        public short boxIndex1;
        public short boxIndex2;
        public short boxIndex3;
        public short boxIndex4;
        public uint unused0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref BoundPrimitive AsRawData() => ref MemoryMarshal.AsRef<BoundPrimitive>(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref this, 1)));

        public BoundPrimitiveBox ReverseEndianness()
        {
            return new BoundPrimitiveBox()
            {
                boxType = EndiannessExtensions.ReverseEndianness(boxType),
                boxIndex1 = EndiannessExtensions.ReverseEndianness(boxIndex1),
                boxIndex2 = EndiannessExtensions.ReverseEndianness(boxIndex2),
                boxIndex3 = EndiannessExtensions.ReverseEndianness(boxIndex3),
                boxIndex4 = EndiannessExtensions.ReverseEndianness(boxIndex4),
                unused0 = EndiannessExtensions.ReverseEndianness(unused0),
            };
        }
    }

    // PrimitiveCylinder
    public struct BoundPrimitiveCylinder : IBoundPrimitive, IResourceStruct<BoundPrimitiveCylinder>
    {
        // structure data
        public ushort cylinderType;
        public ushort cylinderIndex1;
        public float cylinderRadius;
        public ushort cylinderIndex2;
        public ushort unused0;
        public uint unused1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref BoundPrimitive AsRawData() => ref MemoryMarshal.AsRef<BoundPrimitive>(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref this, 1)));

        public BoundPrimitiveCylinder ReverseEndianness()
        {
            return new BoundPrimitiveCylinder()
            {
                cylinderType = EndiannessExtensions.ReverseEndianness(cylinderType),
                cylinderIndex1 = EndiannessExtensions.ReverseEndianness(cylinderIndex1),
                cylinderRadius = EndiannessExtensions.ReverseEndianness(cylinderRadius),
                cylinderIndex2 = EndiannessExtensions.ReverseEndianness(cylinderIndex2),
                unused0 = EndiannessExtensions.ReverseEndianness(unused0),
                unused1 = EndiannessExtensions.ReverseEndianness(unused1),
            };
        }
    }
}
