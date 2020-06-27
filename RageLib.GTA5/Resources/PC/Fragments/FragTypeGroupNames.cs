using RageLib.Resources.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageLib.Resources.GTA5.PC.Fragments
{
    public class FragTypeGroupNames : ResourceSystemBlock
    {
        public override long BlockLength => GroupNames.BlockLength + 8;

        // structure data
        public ResourcePointerArray64<fragNameStruct> GroupNames;
        public ulong Unknown_VFT;

        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            int cnt = Convert.ToInt32(parameters[0]);

            // read structure data
            GroupNames = reader.ReadBlock<ResourcePointerArray64<fragNameStruct>>(cnt);
            Unknown_VFT = reader.ReadUInt64();
        }

        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // write structure data
            writer.WriteBlock(GroupNames);
            writer.Write(Unknown_VFT);
        }
    }
}
