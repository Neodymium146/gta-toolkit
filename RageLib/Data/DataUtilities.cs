using System;

namespace RageLib.Data
{
    public static class DataUtilities
    {
        public static bool EndianessMatchesCurrentArchitecture(Endianess endianess)
        {
            if (BitConverter.IsLittleEndian)
                return endianess == Endianess.LittleEndian;
            else
                return endianess == Endianess.BigEndian;
        }
    }
}
