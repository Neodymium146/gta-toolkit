using RageLib.Resources;
using RageLib.Resources.Common;
using RageLib.Resources.GTA5.PC.Drawables;
using System;

namespace RageLib.GTA5.Resources.PC.Drawables
{
    // crBoneData ?
    public class BoneData : ResourceSystemBlock
    {
        public override long BlockLength => 0x10 + (Bones != null ? Bones.BlockLength : 0);

        // structure data
        public uint BonesCount;
        public uint Unknown_04h; // 0x00000000
        public uint Unknown_08h; // 0x00000000
        public uint Unknown_0Ch; // 0x00000000
        public ResourceSimpleArray<Bone> Bones;

        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            BonesCount = reader.ReadUInt32();
            Unknown_04h = reader.ReadUInt32();
            Unknown_08h = reader.ReadUInt32();
            Unknown_0Ch = reader.ReadUInt32();
            Bones = reader.ReadBlock<ResourceSimpleArray<Bone>>(BonesCount);
        }

        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // update structure data
            BonesCount = (uint)Bones.Count;

            // write structure data
            writer.Write(BonesCount);
            writer.Write(Unknown_04h);
            writer.Write(Unknown_08h);
            writer.Write(Unknown_0Ch);
            writer.WriteBlock(Bones);
        }

        public override Tuple<long, IResourceBlock>[] GetParts()
        {
            return new Tuple<long, IResourceBlock>[]
            {
                new Tuple<long, IResourceBlock>(0x10, Bones),
            };
        }
    }
}
