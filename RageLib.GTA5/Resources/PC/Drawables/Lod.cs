using RageLib.Resources.Common;
using System;

namespace RageLib.Resources.GTA5.PC.Drawables
{
    // rmcLod
    public class Lod : ResourceSystemBlock
    {
        public override long BlockLength => 0x10;

        // structure data
        public ResourcePointerList64<DrawableModel> Models;

        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            Models = reader.ReadBlock<ResourcePointerList64<DrawableModel>>(reader, parameters);
        }

        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            writer.WriteBlock(Models);
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[]
            {
                new Tuple<long, IResourceBlock>(0x0,Models),
            };
        }
    }
}
