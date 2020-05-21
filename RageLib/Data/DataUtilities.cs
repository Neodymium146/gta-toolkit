using System;

namespace RageLib.Data
{
    public static class DataUtilities
    {
        public static bool EndianessMatchesCurrentArchitecture(Endianess endianess)
        {
            return (endianess == Endianess.LittleEndian && BitConverter.IsLittleEndian) || (endianess == Endianess.BigEndian && !BitConverter.IsLittleEndian);
        }
    }
}
