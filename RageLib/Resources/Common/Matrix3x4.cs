using RageLib.Data;
using System.Numerics;

namespace RageLib.Resources.Common
{
    public struct Matrix3x4 : IResourceStruct<Matrix3x4>
    {
        public Vector4 Row1;
        public Vector4 Row2;
        public Vector4 Row3;

        public Matrix3x4 ReverseEndianness()
        {
            return new Matrix3x4()
            {
                Row1 = EndiannessExtensions.ReverseEndianness(Row1),
                Row2 = EndiannessExtensions.ReverseEndianness(Row2),
                Row3 = EndiannessExtensions.ReverseEndianness(Row3)
            };
        }
    }
}
