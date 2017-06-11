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

using RageLib.Archives;
using RageLib.Data;
using RageLib.GTA5.Archives;
using RageLib.GTA5.Cryptography;
using System;
using System.Collections.Generic;
using System.IO;

namespace RageLib.GTA5.ArchiveWrappers
{
    /// <summary>
    /// Represents a wrapper for an RPFv7 archive.
    /// </summary>
    public class RageArchiveWrapper7 : IArchive
    {
        public static int BLOCK_SIZE = 512;

        public RageArchive7 archive_;

        public string FileName { get; set; }

        /// <summary>
        /// Gets the root directory of the archive.
        /// </summary>
        public IArchiveDirectory Root
        {
            get { return new RageArchiveDirectoryWrapper7(this, archive_.Root); }
        }

        private RageArchiveWrapper7(Stream stream, string fileName, bool leaveOpen = false)
        {
            archive_ = new RageArchive7(stream, leaveOpen);
            this.FileName = fileName;
            //  archive_.ReadHeader();
        }

        /// <summary>
        /// Clears all buffers for this archive and causes any buffered data to be 
        /// written to the underlying device.
        /// </summary>
        public void Flush()
        {



            long headerSize = GetHeaderSize();
            do
            {
                var blocks = GetBlocks();
                long maxheaderlength = ArchiveHelpers.FindSpace(blocks, blocks[0]);
                if (maxheaderlength < headerSize)
                {
                    long newpos = ArchiveHelpers.FindOffset(blocks, blocks[1].Length, 512);
                    ArchiveHelpers.MoveBytes(archive_.BaseStream, blocks[1].Offset, newpos, blocks[1].Length);
                    ((IRageArchiveFileEntry7)blocks[1].Tag).FileOffset = (uint)(newpos / 512);

                    blocks = GetBlocks();
                    maxheaderlength = ArchiveHelpers.FindSpace(blocks, blocks[0]);
                }
                else
                    break;

            } while (true);




            // calculate key...
            var tmp1 = GTA5Hash.CalculateHash(FileName);
            var tmp2 = (tmp1 + (uint)archive_.BaseStream.Length + (101 - 40)) % 0x65;

            //  archive_.key_ = GTA5Crypto.key_gta5;
            archive_.WriteHeader(GTA5Constants.PC_AES_KEY, GTA5Constants.PC_NG_KEYS[tmp2]);
            archive_.BaseStream.Flush();

        }

        /// <summary>
        /// Releases all resources used by the archive.
        /// </summary>
        public void Dispose()
        {
            if (archive_ != null)
                archive_.Dispose();

            archive_ = null;
        }

        /////////////////////////////////////////////////////////////////////////////
        // helper functions
        /////////////////////////////////////////////////////////////////////////////

        internal Stream GetStream(RageArchiveBinaryFile7 file_)
        {

            return new PartialStream(
                    archive_.BaseStream,
                    delegate () // offset
                    {
                        return 512 * file_.FileOffset;
                    },
                    delegate () // size
                    {
                        if (file_.FileSize != 0)
                            return file_.FileSize; // compressed
                        else
                            return file_.FileUncompressedSize; // uncompressed
                    },
                    delegate (long newLength)
                    {
                        RequestBytes(file_, newLength);
                    }
                );

        }









        private long GetHeaderSize()
        {
            long len = 16;

            var st = new Stack<RageArchiveDirectory7>();
            st.Push(archive_.Root);
            while (st.Count > 0)
            {
                var x = st.Pop();
                len += 16; // entry
                len += x.Name.Length + 1; // name

                foreach (var q in x.Directories)
                    st.Push(q);
                foreach (var q in x.Files)
                    len += 16 + q.Name.Length + 1;
            }


            return len;
        }


        internal long FindSpace(long length)
        {
            // determine header size...
            long x = GetHeaderSize();

            List<DataBlock> blocks = GetBlocks();

            long offset = ArchiveHelpers.FindOffset(blocks, length, 512);
            return offset;
        }

        private List<DataBlock> GetBlocks()
        {
            var blocks = new List<DataBlock>();

            // header
            blocks.Add(
                new DataBlock(0, GetHeaderSize())
            );

            var st = new Stack<RageArchiveDirectory7>();
            st.Push(archive_.Root);
            while (st.Count > 0)
            {
                var x = st.Pop();

                foreach (var q in x.Directories)
                    st.Push(q);
                foreach (IRageArchiveFileEntry7 q in x.Files)
                {
                    if (q is RageArchiveBinaryFile7)
                    {
                        // if(q.FileSize != 0)
                        RageArchiveBinaryFile7 fff = (RageArchiveBinaryFile7)q;

                        long l = 0;
                        if (q.FileSize == 0)
                            l = fff.FileUncompressedSize;
                        else
                            l = fff.FileSize;

                        blocks.Add(new DataBlock(q.FileOffset * 512, l, q));
                    }
                    else
                    {
                        // if(q.FileSize != 0)
                        RageArchiveResourceFile7 fff = (RageArchiveResourceFile7)q;

                        long l = fff.FileSize;

                        blocks.Add(new DataBlock(q.FileOffset * 512, l, q));
                    }
                }
            }

            blocks.Sort(
                        delegate (DataBlock a, DataBlock b)
                        {
                            if (a.Offset != b.Offset)
                                return a.Offset.CompareTo(b.Offset);
                            else
                                return a.Offset.CompareTo(b.Offset);
                        }
                    );

            return blocks;
        }



        public void RequestBytes(RageArchiveBinaryFile7 file_, long newLength)
        {
            // determine header size...
            long x = GetHeaderSize();

            DataBlock thisBlock = null;
            var blocks = GetBlocks();
            foreach (var q in blocks)
                if (q.Tag == file_)
                    thisBlock = q;

            long maxlength = ArchiveHelpers.FindSpace(blocks, thisBlock);
            if (maxlength < newLength)
            {
                // move...

                long offset = ArchiveHelpers.FindOffset(blocks, newLength, 512);
                ArchiveHelpers.MoveBytes(archive_.BaseStream, thisBlock.Offset, offset, thisBlock.Length);
                ((IRageArchiveFileEntry7)thisBlock.Tag).FileOffset = (uint)offset / 512;

            }

            if (file_.FileSize != 0)
                file_.FileSize = (uint)newLength;
            else
                file_.FileUncompressedSize = (uint)newLength;
        }

        public void RequestBytesRES(RageArchiveResourceFile7 file_, long newLength)
        {
            // determine header size...
            long x = GetHeaderSize();

            DataBlock thisBlock = null;
            List<DataBlock> blocks = GetBlocks();
            foreach (var q in blocks)
                if (q.Tag == file_)
                    thisBlock = q;

            long maxlength = ArchiveHelpers.FindSpace(blocks, thisBlock);
            if (maxlength < newLength)
            {
                // move...

                long offset = ArchiveHelpers.FindOffset(blocks, newLength, 512);
                ArchiveHelpers.MoveBytes(archive_.BaseStream, thisBlock.Offset, offset, thisBlock.Length);
                ((IRageArchiveFileEntry7)thisBlock.Tag).FileOffset = (uint)offset / 512;

            }

            file_.FileSize = (uint)newLength;
        }







        /////////////////////////////////////////////////////////////////////////////
        // static functions
        /////////////////////////////////////////////////////////////////////////////

        public static RageArchiveWrapper7 Create(string fileName)
        {
            var finfo = new FileInfo(fileName);
            var fs = new FileStream(fileName, FileMode.Create);
            var arch = new RageArchiveWrapper7(fs, finfo.Name, false);


            var rootD = new RageArchiveDirectory7();
            rootD.Name = "";
            arch.archive_.Root = rootD;


            //   arch.archive_.WriteHeader(); // write...
            return arch;
        }

        public static RageArchiveWrapper7 Create(Stream stream, string fileName, bool leaveOpen = false)
        {
            var arch = new RageArchiveWrapper7(stream, fileName, leaveOpen);


            var rootD = new RageArchiveDirectory7();
            rootD.Name = "";
            arch.archive_.Root = rootD;


            // arch.archive_.WriteHeader(); // write...
            return arch;
        }

        public static RageArchiveWrapper7 Open(string fileName)
        {
            var finfo = new FileInfo(fileName);
            var fs = new FileStream(fileName, FileMode.Open);
            var arch = new RageArchiveWrapper7(fs, finfo.Name, false);
            try
            {

                if (GTA5Constants.PC_LUT != null && GTA5Constants.PC_NG_KEYS != null)
                {
                    // calculate key...
                    var tmp1 = GTA5Hash.CalculateHash(arch.FileName);
                    var tmp2 = (tmp1 + (uint)finfo.Length + (101 - 40)) % 0x65;

                    arch.archive_.ReadHeader(GTA5Constants.PC_AES_KEY, GTA5Constants.PC_NG_KEYS[tmp2]); // read...
                }
                else
                {
                    arch.archive_.ReadHeader(GTA5Constants.PC_AES_KEY, null); // read...
                }

                
                return arch;
            }
            catch
            {
                fs.Dispose();
                arch.Dispose();
                throw;
            }
        }

        public static RageArchiveWrapper7 Open(Stream stream, string fileName, bool leaveOpen = false)
        {
            var arch = new RageArchiveWrapper7(stream, fileName, leaveOpen);
            try
            {
                if (GTA5Constants.PC_LUT != null && GTA5Constants.PC_NG_KEYS != null)
                {
                    // calculate key...
                    var tmp1 = GTA5Hash.CalculateHash(arch.FileName);
                    var tmp2 = (tmp1 + (uint)stream.Length + (101 - 40)) % 0x65;

                    arch.archive_.ReadHeader(GTA5Constants.PC_AES_KEY, GTA5Constants.PC_NG_KEYS[tmp2]); // read...
                }
                else
                {
                    arch.archive_.ReadHeader(GTA5Constants.PC_AES_KEY, null); // read...
                }

                return arch;
            }
            catch
            {
                arch.Dispose();
                throw;
            }
        }
    }

    /// <summary>
    /// Represents a wrapper for a directory in an RPFv7 archive.
    /// </summary>
    public class RageArchiveDirectoryWrapper7 : IArchiveDirectory, IDisposable
    {
        private RageArchiveWrapper7 archiveWrapper;
        internal RageArchiveDirectory7 directory;

        /// <summary>
        /// Gets or sets the name of the directory.
        /// </summary>
        public string Name
        {
            get
            {
                return directory.Name;
            }
            set
            {
                directory.Name = value;
            }
        }

        internal RageArchiveDirectoryWrapper7(RageArchiveWrapper7 archiveWrapper, RageArchiveDirectory7 directory)
        {
            this.archiveWrapper = archiveWrapper;
            this.directory = directory;
        }

        /// <summary>
        /// Returns a directory list from the current directory. 
        /// </summary>
        public IArchiveDirectory[] GetDirectories()
        {
            var directoryList = new List<IArchiveDirectory>();
            foreach (var directory in directory.Directories)
            {
                var directoryWrapper = new RageArchiveDirectoryWrapper7(archiveWrapper, directory);
                directoryList.Add(directoryWrapper);
            }
            return directoryList.ToArray();
        }

        /// <summary>
        /// Returns a directory from the current directory. 
        /// </summary>
        public IArchiveDirectory GetDirectory(string name)
        {
            foreach (var directory in directory.Directories)
            {
                if (directory.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return new RageArchiveDirectoryWrapper7(archiveWrapper, directory);
            }
            return null;
        }

        /// <summary>
        /// Creates a new directory inside this directory.
        /// </summary>
        public IArchiveDirectory CreateDirectory()
        {
            var newDirectory = new RageArchiveDirectory7();
            var newDirectoryWrapper = new RageArchiveDirectoryWrapper7(archiveWrapper, newDirectory);

            this.directory.Directories.Add(newDirectory);

            return newDirectoryWrapper;
        }

        /// <summary>
        /// Deletes an existing directory inside this directory.
        /// </summary>
        public void DeleteDirectory(IArchiveDirectory directory)
        {
            this.directory.Directories.Remove(((RageArchiveDirectoryWrapper7)directory).directory);
        }

        /// <summary>
        /// Returns a file list from the current directory. 
        /// </summary>
        public IArchiveFile[] GetFiles()
        {
            var fileList = new List<IArchiveFile>();
            foreach (var rawFile in directory.Files)
            {
                if (rawFile is RageArchiveBinaryFile7)
                    fileList.Add(new RageArchiveBinaryFileWrapper7(archiveWrapper, (RageArchiveBinaryFile7)rawFile));
                if (rawFile is RageArchiveResourceFile7)
                    fileList.Add(new RageArchiveResourceFileWrapper7(archiveWrapper, (RageArchiveResourceFile7)rawFile));
            }
            return fileList.ToArray();
        }

        /// <summary>
        /// Returns a file from the current directory. 
        /// </summary>
        public IArchiveFile GetFile(string name)
        {
            foreach (var f in directory.Files)
            {
                if (f.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    if (f is RageArchiveResourceFile7)
                        return new RageArchiveResourceFileWrapper7(archiveWrapper, (RageArchiveResourceFile7)f);
                    else
                        return new RageArchiveBinaryFileWrapper7(archiveWrapper, (RageArchiveBinaryFile7)f);
            }
            return null;
        }

        /// <summary>
        /// Creates a new binary file inside this directory.
        /// </summary>
        public IArchiveBinaryFile CreateBinaryFile()
        {
            RageArchiveBinaryFile7 realF = new RageArchiveBinaryFile7();
            RageArchiveBinaryFileWrapper7 wrD = new RageArchiveBinaryFileWrapper7(archiveWrapper, realF);


            realF.Name = "";
            var offset = archiveWrapper.FindSpace(64);
            realF.FileOffset = (uint)(offset / 512);

            directory.Files.Add(realF);

            return wrD;
        }

        /// <summary>
        /// Creates a new resource file inside this directory.
        /// </summary>
        public IArchiveResourceFile CreateResourceFile()
        {
            RageArchiveResourceFile7 realF = new RageArchiveResourceFile7();
            RageArchiveResourceFileWrapper7 wrD = new RageArchiveResourceFileWrapper7(archiveWrapper, realF);


            realF.Name = "";
            var offset = archiveWrapper.FindSpace(64);
            realF.FileOffset = (uint)(offset / 512);

            directory.Files.Add(realF);

            return wrD;
        }

        /// <summary>
        /// Deletes an existing file inside this directory.
        /// </summary>
        public void DeleteFile(IArchiveFile file)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this.archiveWrapper = null;
            this.directory = null;
        }
    }

    /// <summary>
    /// Represents a wrapper for a binary file in an RPFv7 archive.
    /// </summary>
    public class RageArchiveBinaryFileWrapper7 : IArchiveBinaryFile
    {
        internal RageArchiveWrapper7 archiveWrapper;
        internal RageArchiveBinaryFile7 file;

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        public string Name
        {
            get
            {
                return file.Name;
            }
            set
            {
                file.Name = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the file is encrypted.
        /// </summary>
        public bool IsEncrypted
        {
            get
            {
                return file.IsEncrypted;
            }
            set
            {
                file.IsEncrypted = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the file is compressed.
        /// </summary>
        public bool IsCompressed
        {
            get
            {
                return file.FileSize != 0;
            }
            set
            {
                if (value)
                {
                    file.FileSize = file.FileUncompressedSize;
                }
                else
                {
                    file.FileUncompressedSize = file.FileSize;
                    file.FileSize = 0;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the uncompressed size of the file. This 
        /// property can only be set if the file is compressed.
        /// </summary>
        public long UncompressedSize
        {
            get
            {
                // uncompressed size
                return file.FileUncompressedSize;
            }
            set
            {
                file.FileUncompressedSize = (uint)value;
            }
        }

        /// <summary>
        /// Gets the compressed size of the file.
        /// </summary>
        public long CompressedSize
        {
            get
            {
                // compressed size, 0 if not compressed
                return file.FileSize;
            }
        }

        public long Size
        {
            get
            {
                if (file.FileSize != 0)
                    return file.FileSize;
                else
                    return file.FileUncompressedSize;
            }
        }

        internal RageArchiveBinaryFileWrapper7(RageArchiveWrapper7 archiveWrapper, RageArchiveBinaryFile7 file)
        {
            this.archiveWrapper = archiveWrapper;
            this.file = file;
        }

        /// <summary>
        /// Gets the stream that respresents the possibly compressed content of the file.
        /// </summary>
        public Stream GetStream()
        {
            return archiveWrapper.GetStream(file);
        }





        /// <summary>
        /// Imports a binary file.
        /// </summary>
        public void Import(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
                Import(stream);
        }

        /// <summary>
        /// Imports a binary file.
        /// </summary>
        public void Import(Stream stream)
        {
            var binaryStream = GetStream();
            binaryStream.SetLength(stream.Length);

            byte[] buf = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(buf, 0, buf.Length);
            binaryStream.Write(buf, 0, buf.Length);
        }

        /// <summary>
        /// Exports a binary file.
        /// </summary>
        public void Export(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Create))
                Export(stream);
        }

        /// <summary>
        /// Exports a binary file.
        /// </summary>
        public void Export(Stream stream)
        {
            var binaryStream = GetStream();

            var buf = new byte[binaryStream.Length];
            binaryStream.Read(buf, 0, buf.Length);
            stream.Write(buf, 0, buf.Length);
        }
    }

    /// <summary>
    /// Represents a wrapper for a resource file in an RPFv7 archive.
    /// </summary>
    public class RageArchiveResourceFileWrapper7 : IArchiveResourceFile
    {
        private RageArchiveWrapper7 archiveWrapper;
        private RageArchiveResourceFile7 file;

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        public string Name
        {
            get
            {
                return file.Name;
            }
            set
            {
                file.Name = value;
            }
        }

        /// <summary>
        /// Gets the size of the file.
        /// </summary>
        public long Size
        {
            get
            {
                return file.FileSize;
            }
        }

        internal RageArchiveResourceFileWrapper7(RageArchiveWrapper7 archiveWrapper, RageArchiveResourceFile7 file)
        {
            this.archiveWrapper = archiveWrapper;
            this.file = file;
        }

        /// <summary>
        /// Imports a resource file.
        /// </summary>
        public void Import(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
                Import(stream);
        }

        /// <summary>
        /// Imports a resource file.
        /// </summary>
        public void Import(Stream stream)
        {
            var resourceStream = new PartialStream(
                   archiveWrapper.archive_.BaseStream,
                   delegate () // offset
                   {
                       return file.FileOffset * RageArchiveWrapper7.BLOCK_SIZE;
                   },
                   delegate () // size
                   {
                       return file.FileSize;
                   },
                   delegate (long length)
                   {
                       archiveWrapper.RequestBytesRES(file, length);
                   }

               );
            resourceStream.SetLength(stream.Length);

            // read resource
            var reader = new DataReader(stream);
            reader.Position = 0;
            var ident = reader.ReadUInt32();
            var version = reader.ReadUInt32();
            var systemFlags = reader.ReadUInt32();
            var graphicsFlags = reader.ReadUInt32();

            reader.Position = 0;
            var buffer = reader.ReadBytes((int)stream.Length);

            file.SystemFlags = systemFlags;
            file.GraphicsFlags = graphicsFlags;
            resourceStream.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// Exports a resource file.
        /// </summary>
        public void Export(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Create))
                Export(stream);
        }

        /// <summary>
        /// Exports a resource file.
        /// </summary>
        public void Export(Stream stream)
        {
            // find version
            // -> http://dageron.com/?page_id=5446&lang=en
            var version = ((file.GraphicsFlags & 0xF0000000) >> 28) |
                          ((file.SystemFlags & 0xF0000000) >> 24);

            var writer = new DataWriter(stream);
            writer.Write((uint)0x07435352);
            writer.Write((uint)version);
            writer.Write((uint)file.SystemFlags);
            writer.Write((uint)file.GraphicsFlags);

            var resourceStream = new PartialStream(
                   archiveWrapper.archive_.BaseStream,
                   delegate () // offset
                   {
                       return file.FileOffset * RageArchiveWrapper7.BLOCK_SIZE;
                   },
                   delegate () // size
                   {
                       return file.FileSize;
                   }
               );
            var resourceReader = new DataReader(resourceStream);

            resourceReader.Position = 16;
            var buf = resourceReader.ReadBytes((int)resourceReader.Length - 16);
            writer.Write(buf);
        }
    }
}