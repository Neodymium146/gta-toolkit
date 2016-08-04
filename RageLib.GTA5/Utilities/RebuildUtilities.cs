/*
    Copyright(c) 2016 Neodymium

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
using RageLib.GTA5.Archives;
using RageLib.GTA5.ArchiveWrappers;
using RageLib.GTA5.Resources.PC;
using RageLib.Resources;
using RageLib.Resources.GTA5;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace RageLib.GTA5.Utilities
{
    public interface IRebuildBinaryFileHandler
    {
        bool CanRebuild(IArchiveBinaryFile sourceFile);
        void Rebuild(IArchiveBinaryFile sourceFile, IArchiveDirectory targetDirectory, RageArchiveEncryption7 encryption);
    }

    public interface IRebuildResourceFileHandler
    {
        bool CanRebuild(IArchiveResourceFile sourceFile);
        void Rebuild(IArchiveResourceFile sourceFile, IArchiveDirectory targetDirectory, RageArchiveEncryption7 encryption);
    }

    public class RebuildResourceFileHandler<T> : IRebuildResourceFileHandler where T : IResourceBlock, new()
    {
        private ResourceFileType fileType;

        public RebuildResourceFileHandler(ResourceFileType fileType)
        {
            this.fileType = fileType;
        }

        public bool CanRebuild(IArchiveResourceFile sourceFile)
        {
            return sourceFile.Name.EndsWith("." + fileType.Extension, StringComparison.OrdinalIgnoreCase);
        }

        public void Rebuild(IArchiveResourceFile sourceFile, IArchiveDirectory targetDirectory, RageArchiveEncryption7 encryption)
        {
            try
            {
                var resourceStream = new MemoryStream();
                sourceFile.Export(resourceStream);

                var buffer = new byte[resourceStream.Length];
                resourceStream.Position = 0;
                resourceStream.Read(buffer, 0, (int)resourceStream.Length);
                resourceStream = new MemoryStream(buffer);

                var resource = new ResourceFile_GTA5_pc<T>();
                resourceStream.Position = 0;
                resource.Load(resourceStream);

                if (resource.Version != fileType.Version)
                {
                    throw new Exception("Wrong version");
                }

                var newResourceStream = new MemoryStream();
                resource.Save(newResourceStream);

                buffer = new byte[newResourceStream.Length];
                newResourceStream.Position = 0;
                newResourceStream.Read(buffer, 0, (int)newResourceStream.Length);
                newResourceStream = new MemoryStream(buffer);

                var targetResource = targetDirectory.CreateResourceFile();
                targetResource.Name = sourceFile.Name;
                newResourceStream.Position = 0;
                targetResource.Import(newResourceStream);

                Console.WriteLine("Rebuilt " + sourceFile.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR in " + sourceFile.Name + ": " + ex.Message);
            }
        }
    }

    public class GameRebuilder
    {
        public List<IRebuildBinaryFileHandler> BinaryFileHandlers = new List<IRebuildBinaryFileHandler>();
        public List<IRebuildResourceFileHandler> ResourceFileHandlers = new List<IRebuildResourceFileHandler>();

        public void Rebuild(string sourceGameDirectoryName, string destinationGameDirectoryName)
        {
            var archiveFileNames = Directory.GetFiles(sourceGameDirectoryName, "*.rpf", SearchOption.AllDirectories);
            foreach (var archiveFileName in archiveFileNames)
            {
                RebuildArchive(
                    archiveFileName,
                    archiveFileName.Replace(sourceGameDirectoryName, destinationGameDirectoryName));
            }
        }

        public void RebuildParallel(string sourceGameDirectoryName, string destinationGameDirectoryName)
        {
            var archiveFileNames = Directory.GetFiles(sourceGameDirectoryName, "*.rpf", SearchOption.AllDirectories);
            Parallel.ForEach(archiveFileNames, (archiveFileName) =>
            {
                RebuildArchive(
                    archiveFileName,
                    archiveFileName.Replace(sourceGameDirectoryName, destinationGameDirectoryName));
            });
        }

        private void RebuildArchive(string sourceArchiveFileName, string destinationArchiveFileName)
        {
            var fileInfo = new FileInfo(sourceArchiveFileName);
            var fileStream = new FileStream(sourceArchiveFileName, FileMode.Open);
            var sourceArchive = RageArchiveWrapper7.Open(fileStream, fileInfo.Name);
            var destinationArchive = RageArchiveWrapper7.Create(destinationArchiveFileName);
            RebuildDictionary(sourceArchive.Root, destinationArchive.Root, sourceArchive.archive_.Encryption);
            destinationArchive.FileName = fileInfo.Name;
            destinationArchive.archive_.Encryption = sourceArchive.archive_.Encryption;
            destinationArchive.Flush();
        }

        private void RebuildDictionary(IArchiveDirectory sourceDirectory, IArchiveDirectory destinationDirectory, RageArchiveEncryption7 archiveEncryption)
        {
            foreach (var sourceFile in sourceDirectory.GetFiles())
            {
                RebuildFile(sourceFile, destinationDirectory, archiveEncryption);
            }
            foreach (var sourceSubDirectory in sourceDirectory.GetDirectories())
            {
                var destinationSubDirectory = destinationDirectory.CreateDirectory();
                destinationSubDirectory.Name = sourceSubDirectory.Name;
                RebuildDictionary(sourceSubDirectory, destinationSubDirectory, archiveEncryption);
            }
        }

        private void RebuildFile(IArchiveFile sourceFile, IArchiveDirectory destinationDirectory, RageArchiveEncryption7 archiveEncryption)
        {
            if (sourceFile is IArchiveBinaryFile)
            {
                var binaryFile = (IArchiveBinaryFile)sourceFile;
                if (binaryFile.Name.EndsWith(".rpf", StringComparison.OrdinalIgnoreCase))
                {
                    RebuildArchiveFile(binaryFile, destinationDirectory);
                }
                else
                {
                    RebuildBinaryFile(binaryFile, destinationDirectory, archiveEncryption);
                }
            }
            else
            {
                var resourceFile = (IArchiveResourceFile)sourceFile;
                RebuildResourceFile(resourceFile, destinationDirectory, archiveEncryption);
            }
        }

        private void RebuildArchiveFile(IArchiveBinaryFile sourceFile, IArchiveDirectory destinationDirectory)
        {
            var fileStream = sourceFile.GetStream();
            var inputArchive = RageArchiveWrapper7.Open(fileStream, sourceFile.Name);
            var newF = destinationDirectory.CreateBinaryFile();
            newF.Name = sourceFile.Name;
            var outStream = newF.GetStream();
            var outputArchive = RageArchiveWrapper7.Create(outStream, sourceFile.Name);
            RebuildDictionary(inputArchive.Root, outputArchive.Root, inputArchive.archive_.Encryption);
            outputArchive.FileName = sourceFile.Name;
            outputArchive.archive_.Encryption = inputArchive.archive_.Encryption;
            outputArchive.Flush();
        }

        private void RebuildBinaryFile(IArchiveBinaryFile sourceFile, IArchiveDirectory destinationDirectory, RageArchiveEncryption7 archiveEncryption)
        {
            foreach (var handler in BinaryFileHandlers)
            {
                if (handler.CanRebuild(sourceFile))
                {
                    handler.Rebuild(sourceFile, destinationDirectory, archiveEncryption);
                    return;
                }
            }

            var ms = new MemoryStream();
            sourceFile.Export(ms);
            ms.Position = 0;

            var buf = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(buf, 0, buf.Length);

            var newF = destinationDirectory.CreateBinaryFile();
            newF.Name = sourceFile.Name;

            newF.Import(new MemoryStream(buf));
            newF.IsEncrypted = sourceFile.IsEncrypted;

            if (sourceFile.IsCompressed)
            {
                newF.IsCompressed = sourceFile.IsCompressed;
                newF.UncompressedSize = sourceFile.UncompressedSize;
            }
        }

        private void RebuildResourceFile(IArchiveResourceFile sourceFile, IArchiveDirectory destinationDirectory, RageArchiveEncryption7 archiveEncryption)
        {
            foreach (var handler in ResourceFileHandlers)
            {
                if (handler.CanRebuild(sourceFile))
                {
                    handler.Rebuild(sourceFile, destinationDirectory, archiveEncryption);
                    return;
                }
            }

            CopyResource(sourceFile, destinationDirectory);
        }

        private static void CopyResource(IArchiveResourceFile sourceResource, IArchiveDirectory targetDirectory)
        {
            var resourceStream = new MemoryStream();
            sourceResource.Export(resourceStream);

            var targetResource = targetDirectory.CreateResourceFile();
            targetResource.Name = sourceResource.Name;
            resourceStream.Position = 0;
            targetResource.Import(resourceStream);
        }
    }
}
