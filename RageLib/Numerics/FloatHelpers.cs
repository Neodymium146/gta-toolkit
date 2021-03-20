using System;

namespace RageLib.Numerics
{
    public static class FloatHelpers
    {
        public static float SignalingNaN = BitConverter.Int32BitsToSingle(0x7F800001);
    }
}
