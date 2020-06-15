using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageLib.Resources
{
    // datBase
    public class DatBase64_GTA5_pc : ResourceSystemBlock
    {
        public override long Length => 0x8;

        // structure data
        public ulong VFT;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            // read structure data
            this.VFT = reader.ReadUInt64();
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            // write structure data
            writer.Write(this.VFT);
        }
    }

    // TODO: enum all known VFT
    public enum KnownVFT : ulong
    {
        fragType = 0x0000000140573148,
        fragDrawable = 0x0000000140606be8,
        fragPhysicsLODGroup = 0x00000001406056d0,
        fragPhysicsLOD = 0x00000001406056f8,
    }
}
