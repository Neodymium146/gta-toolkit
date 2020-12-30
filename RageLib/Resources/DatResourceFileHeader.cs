namespace RageLib.Resources
{
    // datResourceFileHeader
    public struct DatResourceFileHeader
    {
        public uint Id;
        public uint Flags;
        public DatResourceInfo ResourceInfo;

        public DatResourceFileHeader(uint id, uint flags, uint virtualFlags, uint physicalFlags)
        {
            Id = id;
            Flags = flags;
            ResourceInfo = new DatResourceInfo(virtualFlags, physicalFlags);
        }
    }

    // datResourceInfo
    public struct DatResourceInfo
    {
        public uint VirtualFlags;
        public uint PhysicalFlags;

        public DatResourceInfo(uint virtualFlags, uint physicalFlags)
        {
            VirtualFlags = virtualFlags;
            PhysicalFlags = physicalFlags;
        }
    }
}
