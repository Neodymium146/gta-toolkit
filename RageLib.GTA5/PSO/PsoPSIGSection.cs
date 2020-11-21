using RageLib.Data;

namespace RageLib.GTA5.PSO
{
    public class PsoPSIGSection
    {
        public int Ident { get; private set; } = 0x50534947;
        public int Length { get; set; }
        public byte[] Data { get; set; }

        public void Read(DataReader reader)
        {
            Ident = reader.ReadInt32();
            Length = reader.ReadInt32();

            if (Length > 8)
            {
                Data = reader.ReadBytes(Length - 8);
            }
        }

        public void Write(DataWriter writer)
        {
            Length = (Data?.Length ?? 0) + 8;

            writer.Write(Ident);
            writer.Write(Length);

            if (Length > 8)
            {
                writer.Write(Data);
            }
        }
    }
}
