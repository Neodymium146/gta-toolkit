using RageLib.Resources.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageLib.Resources.RDR2.PC.Drawables
{
    // rage::sga::Texture
    // VFT = 0x00000001409100B0
    public class Texture : DatBase64
    {
        public override long BlockLength => 0xB0;

        // structure data
        public uint Unknown_08h;
        public uint Unknown_0Ch;
        public uint Unknown_10h;
        public uint Unknown_14h;
        public uint Unknown_18h;
        public uint Unknown_1Ch;
        public uint Unknown_20h;
        public uint Unknown_24h;
        public ulong NamePointer;
        public ulong Unknown_30h_Pointer;
        public ulong Unknown_38h_Pointer;   // Graphics Pointer?
        public ulong Unknown_40h;           // 0x0000000000000000
        public ulong Unknown_48h;           // 0x0000000000000000
        public ulong Unknown_50h;           // 0x0000000000000000
        public ulong Unknown_58h;           // 0x0000000000000000
        public ulong Unknown_60h;           // 0x0000000000000000
        public ShaderResourceView Unknown_68h;       // 0x0000000140910080	Embedded block 
        public ulong Unknown_A8h;           // 0x0000000000000000

        // reference data
        public string_r Name;
        public ShaderResourceView Unknown_30h_Data;

        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.Unknown_08h = reader.ReadUInt32();
            this.Unknown_0Ch = reader.ReadUInt32();
            this.Unknown_10h = reader.ReadUInt32();
            this.Unknown_14h = reader.ReadUInt32();
            this.Unknown_18h = reader.ReadUInt32();
            this.Unknown_1Ch = reader.ReadUInt32();
            this.Unknown_20h = reader.ReadUInt32();
            this.Unknown_24h = reader.ReadUInt32();
            this.NamePointer = reader.ReadUInt64();
            this.Unknown_30h_Pointer = reader.ReadUInt64();
            this.Unknown_38h_Pointer = reader.ReadUInt64();
            this.Unknown_40h = reader.ReadUInt64();
            this.Unknown_48h = reader.ReadUInt64();
            this.Unknown_50h = reader.ReadUInt64();
            this.Unknown_58h = reader.ReadUInt64();
            this.Unknown_60h = reader.ReadUInt64();
            this.Unknown_68h = reader.ReadBlock<ShaderResourceView>();
            this.Unknown_A8h = reader.ReadUInt64();

            // read reference data
            this.Name = reader.ReadBlockAt<string_r>(NamePointer);
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
