using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageLib.Resources.RDR2.PC.Drawables
{
    // grmGeometry
    // VFT - 0x0000000140912C48
    public class DrawableGeometry : DatBase64
    {
        public override long BlockLength => 0x40;

        // structure data
        public ulong VertexBufferPointer;
        public ulong IndexBufferPointer;
        public ulong Unknown_18h;           // 0x0000000000000000
        public ulong Unknown_20h;           // 0x0000000000000000
        public uint Unknown_28h;
        public ushort Unknown_2Ch;
        public ushort Unknown_2Eh;
        public uint Unknown_30h;
        public uint Unknown_34h;
        public ulong Unknown_38h;			// 0x0000000000000000

        // reference data
        public VertexBuffer VertexBuffer;
        public IndexBuffer IndexBuffer;

        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.VertexBufferPointer = reader.ReadUInt64();
            this.IndexBufferPointer = reader.ReadUInt64();
            this.Unknown_18h = reader.ReadUInt64();
            this.Unknown_20h = reader.ReadUInt64();
            this.Unknown_28h = reader.ReadUInt32();
            this.Unknown_2Ch = reader.ReadUInt16();
            this.Unknown_2Eh = reader.ReadUInt16();
            this.Unknown_30h = reader.ReadUInt32();
            this.Unknown_30h = reader.ReadUInt32();
            this.Unknown_38h = reader.ReadUInt64();

            // read reference data
            this.VertexBuffer = reader.ReadBlockAt<VertexBuffer>(VertexBufferPointer);
            this.IndexBuffer = reader.ReadBlockAt<IndexBuffer>(IndexBufferPointer);
        }

        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // write structure data


            // write reference data
        }
    }
}
