using RageLib.Resources.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageLib.Resources.RDR2.PC.Drawables
{
    // IndexBuffer
    // VFT = 0x00000001409123E0 
    public class IndexBuffer : DatBase64
    {
        public override long BlockLength => 0x40;

        // structure data
        public ushort IndicesCount;
        public ushort Unknown_0Ah;
        public uint Unknown_0Ch;            // 2
        public uint Unknown_10h;
        public uint Unknown_14h;
        public ulong IndicesPointer;
        public ulong Unknown_20h;           // 0x0000000000000000
        public ulong Unknown_28h;           // 0x0000000000000000
        public ulong Unknown_30h_Pointer;
        public ulong Unknown_38h;           // 0x0000000000000000

        // reference data
        public SimpleArray<ushort> Indices;
        public ShaderResourceView Unknown_30h_Data;


        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.IndicesCount = reader.ReadUInt16();
            this.Unknown_0Ah = reader.ReadUInt16();
            this.Unknown_0Ch = reader.ReadUInt32();
            this.Unknown_10h = reader.ReadUInt32();
            this.Unknown_14h = reader.ReadUInt32();
            this.IndicesPointer = reader.ReadUInt64();
            this.Unknown_20h = reader.ReadUInt64();
            this.Unknown_28h = reader.ReadUInt64();
            this.Unknown_30h_Pointer = reader.ReadUInt64();
            this.Unknown_38h = reader.ReadUInt64();

            // read reference data
            this.Indices = reader.ReadBlockAt<SimpleArray<ushort>>(IndicesPointer, IndicesCount);
            this.Unknown_30h_Data = reader.ReadBlockAt<ShaderResourceView>(Unknown_30h_Pointer);
        }

        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // write structure data


            // write reference data
        }
    }
}
