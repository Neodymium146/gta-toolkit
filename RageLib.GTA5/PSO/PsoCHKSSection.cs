using RageLib.Data;

namespace RageLib.GTA5.PSO
{
    public class PsoCHKSSection
    {
        public int Ident { get; private set; } = 0x43484B53;
        public int Length { get; set; }
        public uint FileSize { get; set; }
        public uint Checksum { get; set; }
        public uint Unknown { get; set; } = 0x79707070;

        public void Read(DataReader reader)
        {
            Ident = reader.ReadInt32();
            Length = reader.ReadInt32();

            if (Length != 20)
                return;

            FileSize = reader.ReadUInt32();
            Checksum = reader.ReadUInt32();
            Unknown = reader.ReadUInt32();
        }

        public void Write(DataWriter writer)
        {
            Length = 20;

            writer.Write(Ident);
            writer.Write(Length);
            writer.Write(FileSize);
            writer.Write(Checksum);
            writer.Write(Unknown);
        }
    }
}
