using RageLib.Resources.Common;
using System;

namespace RageLib.Resources.Common
{
    // pgBase
    // pgDictionaryBase
    // pgDictionary<T>
    public class PgDictionary64<T> : PgBase64 where T : IResourceSystemBlock, new()
    {
        public override long BlockLength => 0x40;

        // structure data
        public ulong ParentPointer; // 0x0000000000000000
        public uint Count; // 0x00000001
        public uint Unknown_1Ch; // 0x00000000
        public SimpleList64<uint> Hashes;
        public ResourcePointerList64<T> Values;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.ParentPointer = reader.ReadUInt64();
            this.Count = reader.ReadUInt32();
            this.Unknown_1Ch = reader.ReadUInt32();
            this.Hashes = reader.ReadBlock<SimpleList64<uint>>();
            this.Values = reader.ReadBlock<ResourcePointerList64<T>>();
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // write structure data
            writer.Write(this.ParentPointer);
            writer.Write(this.Count);
            writer.Write(this.Unknown_1Ch);
            writer.WriteBlock(this.Hashes);
            writer.WriteBlock(this.Values);
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[] {
                new Tuple<long, IResourceBlock>(0x20, Hashes),
                new Tuple<long, IResourceBlock>(0x30, Values)
            };
        }
    }
}
