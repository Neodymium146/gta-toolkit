using RageLib.Resources;

namespace RageLib.Resources.GTA5.PC.Clips
{
    // crTrack ?
    public class Animation_Unknown : ResourceSystemBlock
    {
        public override long BlockLength => 0x4;

        // structure data
        public ushort BoneId;
        public byte Unknown_02h;
        public byte Unknown_03h;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            BoneId = reader.ReadUInt16();
            Unknown_02h = reader.ReadByte();
            Unknown_03h = reader.ReadByte();
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            writer.Write(BoneId);
            writer.Write(Unknown_02h);
            writer.Write(Unknown_03h);
        }
    }
}
