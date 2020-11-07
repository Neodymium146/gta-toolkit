using RageLib.Data;
using System.Collections.Generic;
using System.IO;

namespace RageLib.GTA5.PSO
{
    public class PsoSTRSSection
    {
        public int Ident { get; private set; } = 0x53545253;
        public int Length { get; set; }
        public List<string> Strings { get; set; }


        public void Read(DataReader reader)
        {
            Ident = reader.ReadInt32();
            Length = reader.ReadInt32();

            Strings = new List<string>();
            while (reader.Position < reader.Length)
            {
                Strings.Add(reader.ReadString());
            }
        }

        public void Write(DataWriter writer)
        {
            var strStream = new MemoryStream();
            var strWriter = new DataWriter(strStream, Endianess.BigEndian);
            foreach (var str in Strings)
            {
                strWriter.Write(str);
            }

            Length = (int)strStream.Length + 8;

            writer.Write(Ident);
            writer.Write(Length);

            if (strStream.Length > 0)
            {
                var buf1 = new byte[strStream.Length];
                strStream.Position = 0;
                strStream.Read(buf1, 0, buf1.Length);
                writer.Write(buf1);
            }
        }
    }
}
