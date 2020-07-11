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

using System;

namespace RageLib.Resources.GTA5.PC.Bounds
{
    // phPrimitiveBase
    // phPrimitive
    public class BoundPrimitive : ResourceSystemBlock, IResourceXXSystemBlock
    {
        public override long BlockLength => 0x10;

        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public IResourceSystemBlock GetType(ResourceDataReader reader, params object[] parameters)
        {
            reader.Position += 16;
            var type = reader.ReadByte() & 0xF8 & 0x7;
            reader.Position -= 17;

            switch (type)
            {
                case 0: return new BoundPrimitiveTriangle();
                case 1: return new BoundPrimitiveSphere();
                case 2: return new BoundPrimitiveCapsule();
                case 3: return new BoundPrimitiveBox();
                case 4: return new BoundPrimitiveCylinder();
                default: throw new Exception("Unknown primitive bound type");
            }
        }
    }

    // PrimitiveTriangle
    public class BoundPrimitiveTriangle : BoundPrimitive
    {
        // structure data
        public float triArea;
        public ushort triIndex1;
        public ushort triIndex2;
        public ushort triIndex3;
        public short edgeIndex1;
        public short edgeIndex2;
        public short edgeIndex3;

        public int vertIndex1
        {
            get => triIndex1 & 0x7FFF;
            set { triIndex1 = (ushort)((value & 0x7FFF) + (vertFlag1 ? 0x8000 : 0)); }
        }

        public int vertIndex2
        {
            get => triIndex2 & 0x7FFF;
            set { triIndex2 = (ushort)((value & 0x7FFF) + (vertFlag2 ? 0x8000 : 0)); }
        }

        public int vertIndex3
        {
            get => triIndex3 & 0x7FFF;
            set { triIndex3 = (ushort)((value & 0x7FFF) + (vertFlag3 ? 0x8000 : 0)); }
        }

        public bool vertFlag1
        {
            get => (triIndex1 & 0x8000) > 0;
            set { triIndex1 = (ushort)(vertIndex1 + (value ? 0x8000 : 0)); }
        }

        public bool vertFlag2
        {
            get { return (triIndex2 & 0x8000) > 0; }
            set { triIndex2 = (ushort)(vertIndex2 + (value ? 0x8000 : 0)); }
        }

        public bool vertFlag3
        {
            get => (triIndex3 & 0x8000) > 0;
            set { triIndex3 = (ushort)(vertIndex3 + (value ? 0x8000 : 0)); }
        }

        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            triArea = reader.ReadSingle();
            triIndex1 = reader.ReadUInt16();
            triIndex2 = reader.ReadUInt16();
            triIndex3 = reader.ReadUInt16();
            edgeIndex1 = reader.ReadInt16();
            edgeIndex2 = reader.ReadInt16();
            edgeIndex3 = reader.ReadInt16();
        }

        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            writer.Write(triArea);
            writer.Write(triIndex1);
            writer.Write(triIndex2);
            writer.Write(triIndex3);
            writer.Write(edgeIndex1);
            writer.Write(edgeIndex2);
            writer.Write(edgeIndex3);
        }
    }

    // PrimitiveSphere
    public class BoundPrimitiveSphere : BoundPrimitive
    {
        // structure data

        public ushort sphereType;
        public ushort sphereIndex;
        public float sphereRadius;
        public uint unused0;
        public uint unused1;

        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            sphereType = reader.ReadUInt16();
            sphereIndex = reader.ReadUInt16();
            sphereRadius = reader.ReadSingle();
            unused0 = reader.ReadUInt32();
            unused1 = reader.ReadUInt32();
        }

        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            writer.Write(sphereType);
            writer.Write(sphereIndex);
            writer.Write(sphereRadius);
            writer.Write(unused0);
            writer.Write(unused1);
        }
    }

    // PrimitiveCapsule
    public class BoundPrimitiveCapsule : BoundPrimitive
    {
        // structure data

        public ushort capsuleType;
        public ushort capsuleIndex1;
        public float capsuleRadius;
        public ushort capsuleIndex2;
        public ushort unused0;
        public uint unused1;

        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            capsuleType = reader.ReadUInt16();
            capsuleIndex1 = reader.ReadUInt16();
            capsuleRadius = reader.ReadSingle();
            capsuleIndex2 = reader.ReadUInt16();
            unused0 = reader.ReadUInt16();
            unused1 = reader.ReadUInt32();
        }

        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            writer.Write(capsuleType);
            writer.Write(capsuleIndex1);
            writer.Write(capsuleRadius);
            writer.Write(capsuleIndex2);
            writer.Write(unused0);
            writer.Write(unused1);
        }
    }

    // PrimitiveBox
    public class BoundPrimitiveBox : BoundPrimitive
    {
        // structure data

        public uint boxType;
        public short boxIndex1;
        public short boxIndex2;
        public short boxIndex3;
        public short boxIndex4;
        public uint unused0;

        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            boxType = reader.ReadUInt32();
            boxIndex1 = reader.ReadInt16();
            boxIndex2 = reader.ReadInt16();
            boxIndex3 = reader.ReadInt16();
            boxIndex4 = reader.ReadInt16();
            unused0 = reader.ReadUInt32();
        }

        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            writer.Write(boxType);
            writer.Write(boxIndex1);
            writer.Write(boxIndex2);
            writer.Write(boxIndex3);
            writer.Write(boxIndex4);
            writer.Write(unused0);
        }
    }

    // PrimitiveCylinder
    public class BoundPrimitiveCylinder : BoundPrimitive
    {
        // structure data

        public ushort cylinderType;
        public ushort cylinderIndex1;
        public float cylinderRadius;
        public ushort cylinderIndex2;
        public ushort unused0;
        public uint unused1;

        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            cylinderType = reader.ReadUInt16();
            cylinderIndex1 = reader.ReadUInt16();
            cylinderRadius = reader.ReadSingle();
            cylinderIndex2 = reader.ReadUInt16();
            unused0 = reader.ReadUInt16();
            unused1 = reader.ReadUInt32();
        }

        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            writer.Write(cylinderType);
            writer.Write(cylinderIndex1);
            writer.Write(cylinderRadius);
            writer.Write(cylinderIndex2);
            writer.Write(unused0);
            writer.Write(unused1);
        }
    }
}
