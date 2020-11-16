namespace RageLib.Resources
{
    // datResourceFileHeader
    public struct DatResourceFileHeader
    {
        public uint Id;
        public uint Flags;
        public DatResourceInfo ResourceInfo;
    }

    // datResourceInfo
    public struct DatResourceInfo
    {
        public uint VirtualFlags;
        public uint PhysicalFlags;

        public static implicit operator ulong(DatResourceInfo value)
        {
            return (((ulong)value.VirtualFlags << 32) & 0xFFFFFFFF00000000) | (value.PhysicalFlags & 0x00000000FFFFFFFF);
        }

        public static implicit operator DatResourceInfo(ulong value)
        {
            return new DatResourceInfo()
            {
                VirtualFlags = (uint)((value & 0xFFFFFFFF00000000) >> 32),
                PhysicalFlags = (uint)(value & 0x00000000FFFFFFFF),
            };
        }
    }
}
