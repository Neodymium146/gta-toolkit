/*
    Copyright(c) 2015 Neodymium

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
*/

using RageLib.Cryptography;
using RageLib.Data;
using RageLib.GTA5.Cryptography;
using System;
using System.Collections.Generic;
using System.IO;

namespace RageLib.GTA5.Archives
{
    public interface IRageArchiveEntry7
    {
        uint NameOffset { get; set; }
        string Name { get; set; }

        void Read(DataReader reader);
        void Write(DataWriter writer);
    }

    public interface IRageArchiveFileEntry7 : IRageArchiveEntry7
    {
        uint FileOffset { get; set; }
        uint FileSize { get; set; }
    }

    public enum RageArchiveEncryption7
    {
        None = 0,
        OPEN = 0x4E45504F,
        AES = 0x0FFFFFF9,
        NG = 0x0FEFFFFF,
    }

    /// <summary>
    /// Represents an RPFv7 archive.
    /// </summary>
    public class RageArchive7 : IDisposable
    {
        private const uint IDENT = 0x52504637;

        public RageArchiveEncryption7 Encryption { get; set; }

        private bool LeaveOpen;
        public Stream BaseStream { get; private set; }

        public RageArchiveDirectory7 Root { get; set; }

        /// <summary>
        /// Creates an RPFv7 archive.
        /// </summary>
        public RageArchive7(Stream fileStream, bool leaveOpen = false)
        {
            BaseStream = fileStream;
            LeaveOpen = leaveOpen;
        }

        /// <summary>
        /// Reads the archive header.
        /// </summary>
        public void ReadHeader(byte[] aesKey = null, byte[] ngKey = null)
        {
            var reader = new DataReader(BaseStream);
            var posbak = reader.Position;
            reader.Position = 0;

            uint header_identifier = reader.ReadUInt32(); // 0x52504637
            if (header_identifier != IDENT)
                throw new Exception("The identifier " + header_identifier.ToString("X8") + " did not match the RPF7 one");

            uint header_entriesCount = reader.ReadUInt32();
            uint header_namesLength = reader.ReadUInt32();
            uint header_encryption = reader.ReadUInt32();

            byte[] entries_data_dec = null;
            byte[] names_data_dec = null;

            if (header_encryption == 0x4E45504F) // for OpenIV compatibility
            {
                // no encryption...
                Encryption = RageArchiveEncryption7.None;
                entries_data_dec = reader.ReadBytes(16 * (int)header_entriesCount);
                names_data_dec = reader.ReadBytes((int)header_namesLength);

            }
            else if (header_encryption == 0x0FFFFFF9)
            {
                // AES enceyption...                

                Encryption = RageArchiveEncryption7.AES;

                var entries_data = reader.ReadBytes(16 * (int)header_entriesCount);
                entries_data_dec = AesEncryption.DecryptData(entries_data, aesKey);

                var names_data = reader.ReadBytes((int)header_namesLength);
                names_data_dec = AesEncryption.DecryptData(names_data, aesKey);
            }
            else if (header_encryption == 0x0FEFFFFF)
            {
                // NG encryption...

                Encryption = RageArchiveEncryption7.NG;

                var entries_data = reader.ReadBytes(16 * (int)header_entriesCount);
                entries_data_dec = GTA5Crypto.Decrypt(entries_data, ngKey);

                var names_data = reader.ReadBytes((int)header_namesLength);
                names_data_dec = GTA5Crypto.Decrypt(names_data, ngKey);
            }
            else throw new Exception("Unknown RPF7 encryption type");

            var entries_reader = new DataReader(new MemoryStream(entries_data_dec));
            var names_reader = new DataReader(new MemoryStream(names_data_dec));

            var entries = new List<IRageArchiveEntry7>();
            for (var index = 0; index < header_entriesCount; index++)
            {
                uint y = entries_reader.ReadUInt32();
                uint x = entries_reader.ReadUInt32();
                entries_reader.Position -= 8;

                if (x == 0x7fffff00)
                {
                    // directory
                    var e = new RageArchiveDirectory7();
                    e.Read(entries_reader);

                    names_reader.Position = e.NameOffset;
                    e.Name = names_reader.ReadString();

                    entries.Add(e);
                }
                else
                {
                    if ((x & 0x80000000) == 0)
                    {
                        // binary file
                        var e = new RageArchiveBinaryFile7();
                        e.Read(entries_reader);

                        names_reader.Position = e.NameOffset;
                        e.Name = names_reader.ReadString();

                        entries.Add(e);
                    }
                    else
                    {
                        // resource file
                        var e = new RageArchiveResourceFile7();
                        e.Read(entries_reader);

                        // there are sometimes resources with length=0xffffff which actually
                        // means length>=0xffffff
                        if (e.FileSize == 0xFFFFFF)
                        {
                            reader.Position = 512 * e.FileOffset;
                            var buf = reader.ReadBytes(16);
                            e.FileSize = ((uint)buf[7] << 0) | ((uint)buf[14] << 8) | ((uint)buf[5] << 16) | ((uint)buf[2] << 24);
                        }

                        names_reader.Position = e.NameOffset;
                        e.Name = names_reader.ReadString();
                        
                        entries.Add(e);
                    }
                }
            }

            var stack = new Stack<RageArchiveDirectory7>();
            stack.Push((RageArchiveDirectory7)entries[0]);
            Root = (RageArchiveDirectory7)entries[0];
            while (stack.Count > 0)
            {
                var item = stack.Pop();

                for (int index = (int)item.EntriesIndex; index < (item.EntriesIndex + item.EntriesCount); index++)
                {
                    if (entries[index] is RageArchiveDirectory7)
                    {
                        item.Directories.Add(entries[index] as RageArchiveDirectory7);
                        stack.Push(entries[index] as RageArchiveDirectory7);
                    }
                    else
                    {
                        item.Files.Add(entries[index]);
                    }
                }
            }

            reader.Position = posbak;
        }

        /// <summary>
        /// Writes the archive header.
        /// </summary>
        public void WriteHeader(byte[] aesKey = null, byte[] ngKey = null)
        {
            // backup position
            var positionBackup = BaseStream.Position;

            var writer = new DataWriter(BaseStream);


            var entries = new List<IRageArchiveEntry7>();
            var stack = new Stack<RageArchiveDirectory7>();
            var nameOffset = 1;


            entries.Add(Root);
            stack.Push(Root);

            var nameDict = new Dictionary<string, uint>();
            nameDict.Add("", 0);

            while (stack.Count > 0)
            {
                var directory = stack.Pop();

                directory.EntriesIndex = (uint)entries.Count;
                directory.EntriesCount = (uint)directory.Directories.Count + (uint)directory.Files.Count;

                var theList = new List<IRageArchiveEntry7>();

                foreach (var xd in directory.Directories)
                {
                    if (!nameDict.ContainsKey(xd.Name))
                    {
                        nameDict.Add(xd.Name, (uint)nameOffset);
                        nameOffset += xd.Name.Length + 1;
                    }
                    xd.NameOffset = nameDict[xd.Name];

                    //xd.NameOffset = (ushort)nameOffset;
                    //nameOffset += xd.Name.Length + 1;
                    //entries.Add(xd);
                    //stack.Push(xd);
                    theList.Add(xd);
                }

                foreach (var xf in directory.Files)
                {
                    if (!nameDict.ContainsKey(xf.Name))
                    {
                        nameDict.Add(xf.Name, (uint)nameOffset);
                        nameOffset += xf.Name.Length + 1;
                    }
                    xf.NameOffset = nameDict[xf.Name];

                    //xf.NameOffset = (ushort)nameOffset;
                    //nameOffset += xf.Name.Length + 1;
                    //entries.Add(xf);
                    theList.Add(xf);
                }

                theList.Sort(
                    delegate (IRageArchiveEntry7 a, IRageArchiveEntry7 b)
                    {
                        return string.CompareOrdinal(a.Name, b.Name);
                    }
                    );
                foreach (var xx in theList)
                    entries.Add(xx);
                theList.Reverse();
                foreach (var xx in theList)
                    if (xx is RageArchiveDirectory7)
                        stack.Push((RageArchiveDirectory7)xx);
            }


            // there are sometimes resources with length>=0xffffff which actually
            // means length=0xffffff
            // -> we therefore just cut the file size
            foreach (var entry in entries)
                if (entry is RageArchiveResourceFile7)
                {
                    var resource = entry as RageArchiveResourceFile7;
                    if (resource.FileSize > 0xFFFFFF)
                    {
                        var buf = new byte[16];
                        buf[7] = (byte)((resource.FileSize >> 0) & 0xFF);
                        buf[14] = (byte)((resource.FileSize >> 8) & 0xFF);
                        buf[5] = (byte)((resource.FileSize >> 16) & 0xFF);
                        buf[2] = (byte)((resource.FileSize >> 24) & 0xFF);

                        if (writer.Length > 512 * resource.FileOffset)
                        {
                            writer.Position = 512 * resource.FileOffset;
                            writer.Write(buf);
                        }                     

                        resource.FileSize = 0xFFFFFF;
                    }                        
                }


            // entries...
            var ent_str = new MemoryStream();
            var ent_wr = new DataWriter(ent_str);
            foreach (var entry in entries)
                entry.Write(ent_wr);
            ent_str.Flush();

            var ent_buf = new byte[ent_str.Length];
            ent_str.Position = 0;
            ent_str.Read(ent_buf, 0, ent_buf.Length);

            if (Encryption == RageArchiveEncryption7.AES)
                ent_buf = AesEncryption.EncryptData(ent_buf, aesKey);
            if (Encryption == RageArchiveEncryption7.NG)
            {
                Encryption = RageArchiveEncryption7.None;
            }


            // names...
            var n_str = new MemoryStream();
            var n_wr = new DataWriter(n_str);
            //foreach (var entry in entries)
            //    n_wr.Write(entry.Name);
            foreach (var entry in nameDict)
                n_wr.Write(entry.Key);
            var empty = new byte[16 - (n_wr.Length % 16)];
            n_wr.Write(empty);
            n_str.Flush();

            var n_buf = new byte[n_str.Length];
            n_str.Position = 0;
            n_str.Read(n_buf, 0, n_buf.Length);

            if (Encryption == RageArchiveEncryption7.AES)
                n_buf = AesEncryption.EncryptData(n_buf, aesKey);
            
            writer.Position = 0;
            writer.Write((uint)IDENT);
            writer.Write((uint)entries.Count);
            writer.Write((uint)n_buf.Length);

            switch (Encryption)
            {
                case RageArchiveEncryption7.None:
                    writer.Write((uint)0x04E45504F);
                    break;
                case RageArchiveEncryption7.AES:
                    writer.Write((uint)0x0ffffff9);
                    break;
                case RageArchiveEncryption7.NG:
                    writer.Write((uint)0x0fefffff);
                    break;
            }

            writer.Write(ent_buf);
            writer.Write(n_buf);



            // restore position
            BaseStream.Position = positionBackup;
        }

        /// <summary>
        /// Releases all resources used by the archive.
        /// </summary>
        public void Dispose()
        {
            if (BaseStream != null)
                BaseStream.Dispose();

            BaseStream = null;
            Root = null;
        }
    }

    /// <summary>
    /// Represents a directory in an RPFv7 archive.
    /// </summary>
    public class RageArchiveDirectory7 : IRageArchiveEntry7
    {
        public uint NameOffset { get; set; }
        public uint EntriesIndex { get; set; }
        public uint EntriesCount { get; set; }

        public string Name { get; set; }
        public List<RageArchiveDirectory7> Directories = new List<RageArchiveDirectory7>();
        public List<IRageArchiveEntry7> Files = new List<IRageArchiveEntry7>();

        /// <summary>
        /// Reads the directory entry.
        /// </summary>
        public void Read(DataReader reader)
        {
            this.NameOffset = reader.ReadUInt32();

            uint ident = reader.ReadUInt32();
            if (ident != 0x7FFFFF00)
                throw new Exception("Error in RPF7 directory entry.");

            this.EntriesIndex = reader.ReadUInt32();
            this.EntriesCount = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes the directory entry.
        /// </summary>
        public void Write(DataWriter writer)
        {
            writer.Write(this.NameOffset);
            writer.Write((uint)0x7FFFFF00);
            writer.Write(this.EntriesIndex);
            writer.Write(this.EntriesCount);
        }
    }

    /// <summary>
    /// Represents a binary file in an RPFv7 archive.
    /// </summary>
    public class RageArchiveBinaryFile7 : IRageArchiveFileEntry7
    {
        public uint NameOffset { get; set; }
        public uint FileSize { get; set; }
        public uint FileOffset { get; set; }
        public uint FileUncompressedSize { get; set; }
        public bool IsEncrypted { get; set; }

        public string Name { get; set; }
        public uint EncryptionType { get; set; }

        /// <summary>
        /// Reads the binary file entry.
        /// </summary>
        public void Read(DataReader reader)
        {
            NameOffset = reader.ReadUInt16();

            var buf1 = reader.ReadBytes(3);
            FileSize = (uint)buf1[0] + (uint)(buf1[1] << 8) + (uint)(buf1[2] << 16);

            var buf2 = reader.ReadBytes(3);
            FileOffset = (uint)buf2[0] + (uint)(buf2[1] << 8) + (uint)(buf2[2] << 16);

            FileUncompressedSize = reader.ReadUInt32();
            EncryptionType = reader.ReadUInt32();
            
            switch (EncryptionType)
            {
                case 0: IsEncrypted = false; break;
                case 1: IsEncrypted = true; break;
                default:
                    throw new Exception("Unknown encryption type in RPF7 file entry.");
            }
        }

        /// <summary>
        /// Writes the binary file entry.
        /// </summary>
        public void Write(DataWriter writer)
        {
            writer.Write((ushort)NameOffset);

            var buf1 = new byte[] {
                (byte)((FileSize >> 0) & 0xFF),
                (byte)((FileSize >> 8) & 0xFF),
                (byte)((FileSize >> 16) & 0xFF)
            };
            writer.Write(buf1);

            var buf2 = new byte[] {
                (byte)((FileOffset >> 0) & 0xFF),
                (byte)((FileOffset >> 8) & 0xFF),
                (byte)((FileOffset >> 16) & 0xFF)
            };
            writer.Write(buf2);

            writer.Write(FileUncompressedSize);

            writer.Write(EncryptionType);
        }
    }

    /// <summary>
    /// Represents a resource file in an RPFv7 archive.
    /// </summary>
    public class RageArchiveResourceFile7 : IRageArchiveFileEntry7
    {
        public uint NameOffset { get; set; }
        public uint FileSize { get; set; }
        public uint FileOffset { get; set; }
        public ResourceFilePageFlags VirtualFlags { get; set; }
        public ResourceFilePageFlags PhysicalFlags { get; set; }

        public int Version
        {
            get
            {
                var vf = (VirtualFlags >> 28) & 0xF;
                var pf = (PhysicalFlags >> 28) & 0xF;
                return (int)((vf << 4) + pf);
            }
        }

        public int VirtualSize => (int)VirtualFlags.Size;

        public int PhysicalSize => (int)PhysicalFlags.Size;

        public string Name { get; set; }
        /// <summary>
        /// Reads the resource file entry.
        /// </summary>
        public void Read(DataReader reader)
        {
            NameOffset = reader.ReadUInt16();

            var buf1 = reader.ReadBytes(3);
            FileSize = (uint)buf1[0] + (uint)(buf1[1] << 8) + (uint)(buf1[2] << 16);

            var buf2 = reader.ReadBytes(3);
            FileOffset = ((uint)buf2[0] + (uint)(buf2[1] << 8) + (uint)(buf2[2] << 16)) & 0x7FFFFF;

            VirtualFlags = reader.ReadUInt32();
            PhysicalFlags = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes the resource file entry.
        /// </summary>
        public void Write(DataWriter writer)
        {
            writer.Write((ushort)NameOffset);

            var buf1 = new byte[] {
                (byte)((FileSize >> 0) & 0xFF),
                (byte)((FileSize >> 8) & 0xFF),
                (byte)((FileSize >> 16) & 0xFF)
            };
            writer.Write(buf1);

            var buf2 = new byte[] {
                (byte)((FileOffset >> 0) & 0xFF),
                (byte)((FileOffset >> 8) & 0xFF),
                (byte)(((FileOffset >> 16) & 0xFF) | 0x80)
            };
            writer.Write(buf2);

            writer.Write(VirtualFlags);
            writer.Write(PhysicalFlags);
        }
    }

    public struct ResourceFilePage
    {
        public uint Size { get; set; }
        public uint Offset { get; set; }
    }

    public struct ResourceFilePageFlags
    {
        public uint Value { get; set; }

        public ResourceFilePage[] Pages
        {
            get
            {
                var count = Count;
                if (count == 0) return null;
                var pages = new ResourceFilePage[count];
                var counts = PageCounts;
                var sizes = BaseSizes;
                int n = 0;
                uint o = 0;
                for (int i = 0; i < counts.Length; i++)
                {
                    var c = counts[i];
                    var s = sizes[i];
                    for (int p = 0; p < c; p++)
                    {
                        pages[n] = new ResourceFilePage() { Size = s, Offset = o };
                        o += s;
                        n++;
                    }
                }
                return pages;
            }
        }

        public uint TypeVal => (Value >> 28) & 0xF;

        public uint BaseShift => (Value & 0xF);

        public uint BaseSize => (0x200u << (int)BaseShift);

        public uint[] BaseSizes
        {
            get
            {
                var baseSize = BaseSize;
                return new uint[]
                {
                    baseSize << 8,
                    baseSize << 7,
                    baseSize << 6,
                    baseSize << 5,
                    baseSize << 4,
                    baseSize << 3,
                    baseSize << 2,
                    baseSize << 1,
                    baseSize << 0,
                };
            }
        }

        public uint[] PageCounts
        {
            get
            {
                return new uint[]
                {
                    ((Value >> 4)  & 0x1),
                    ((Value >> 5)  & 0x3),
                    ((Value >> 7)  & 0xF),
                    ((Value >> 11) & 0x3F),
                    ((Value >> 17) & 0x7F),
                    ((Value >> 24) & 0x1),
                    ((Value >> 25) & 0x1),
                    ((Value >> 26) & 0x1),
                    ((Value >> 27) & 0x1),
                };
            }
        }

        public uint[] PageSizes
        {
            get
            {
                var counts = PageCounts;
                var baseSizes = BaseSizes;
                return new uint[]
                {
                    baseSizes[0] * counts[0],
                    baseSizes[1] * counts[1],
                    baseSizes[2] * counts[2],
                    baseSizes[3] * counts[3],
                    baseSizes[4] * counts[4],
                    baseSizes[5] * counts[5],
                    baseSizes[6] * counts[6],
                    baseSizes[7] * counts[7],
                    baseSizes[8] * counts[8],
                };
            }
        }

        public uint Count
        {
            get
            {
                var c = PageCounts;
                return c[0] + c[1] + c[2] + c[3] + c[4] + c[5] + c[6] + c[7] + c[8];
            }
        }

        public uint Size
        {
            get
            {
                var flags = Value;
                var s0 = ((flags >> 27) & 0x1) << 0;
                var s1 = ((flags >> 26) & 0x1) << 1;
                var s2 = ((flags >> 25) & 0x1) << 2;
                var s3 = ((flags >> 24) & 0x1) << 3;
                var s4 = ((flags >> 17) & 0x7F) << 4;
                var s5 = ((flags >> 11) & 0x3F) << 5;
                var s6 = ((flags >> 7) & 0xF) << 6;
                var s7 = ((flags >> 5) & 0x3) << 7;
                var s8 = ((flags >> 4) & 0x1) << 8;
                var ss = ((flags >> 0) & 0xF);
                var baseSize = 0x200u << (int)ss;
                return baseSize * (s0 + s1 + s2 + s3 + s4 + s5 + s6 + s7 + s8);
            }
        }

        public ResourceFilePageFlags(uint v)
        {
            Value = v;
        }

        public ResourceFilePageFlags(uint[] pageCounts, uint baseShift)
        {
            var v = baseShift & 0xF;
            v += (pageCounts[0] & 0x1) << 4;
            v += (pageCounts[1] & 0x3) << 5;
            v += (pageCounts[2] & 0xF) << 7;
            v += (pageCounts[3] & 0x3F) << 11;
            v += (pageCounts[4] & 0x7F) << 17;
            v += (pageCounts[5] & 0x1) << 24;
            v += (pageCounts[6] & 0x1) << 25;
            v += (pageCounts[7] & 0x1) << 26;
            v += (pageCounts[8] & 0x1) << 27;
            Value = v;
        }

        public static implicit operator uint(ResourceFilePageFlags f)
        {
            return f.Value;
        }

        public static implicit operator ResourceFilePageFlags(uint v)
        {
            return new ResourceFilePageFlags(v);
        }
    }
}