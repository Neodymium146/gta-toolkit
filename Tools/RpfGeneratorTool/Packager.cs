using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using NDepend.Path;
using RageLib.Archives;
using RageLib.Extensions;
using RageLib.GTA5.ArchiveWrappers;

namespace RpfGeneratorTool
{
    public class Packager
    {
        private const string PackageConfigFileName = "package.config";
        private readonly PackagerConfig _config;
        private readonly IAbsoluteDirectoryPath _gamePath;
        private readonly IAbsoluteDirectoryPath _outputPath;
        private readonly RpfListBuilder _rpfListBuilder;
        private readonly IAbsoluteDirectoryPath _tempPath;

        public Packager(IAbsoluteDirectoryPath gamePath, IAbsoluteDirectoryPath outputPath,
            IAbsoluteDirectoryPath tempPath, PackagerConfig config)
        {
            _config = config;
            _gamePath = gamePath;
            _outputPath = outputPath;
            _tempPath = tempPath;
            _rpfListBuilder = new RpfListBuilder(_gamePath, _config.BuilderConfig);
        }

        public Packager(IAbsoluteDirectoryPath gamePath, IAbsoluteDirectoryPath outputPath,
            IAbsoluteDirectoryPath tempPath) : this(gamePath, outputPath, tempPath, new PackagerConfig())
        {
        }

        public void PackageMod(IAbsoluteDirectoryPath modPackagePath)
        {
            var packageConfig = ReadXmlFile(modPackagePath.GetChildFileWithName(PackageConfigFileName));
            var list = _rpfListBuilder.BuildRpfList(modPackagePath, packageConfig);
            foreach (var rpf in list)
                ProcessModdedRpf(rpf);
        }

        private void ProcessModdedRpf(RpfListBuilder.RootRpf rpf)
        {
            var relativeRpf = rpf.FilePath.GetRelativePathFrom(_gamePath);
            var moddedPath = relativeRpf.GetAbsolutePathFrom(_outputPath);

            CopyRpf(rpf.FilePath, moddedPath);
            WriteModdedArchive(rpf, moddedPath);
        }

        private void WriteModdedArchive(RpfListBuilder.IDirectory rpf, IAbsoluteFilePath moddedPath)
        {
            using (
                var archive = moddedPath.Exists
                    ? RageArchiveWrapper7.Open(moddedPath.ToString())
                    : RageArchiveWrapper7.Create(moddedPath.ToString()))
            {
                ProcessModdedRpfFile(rpf, archive);
                archive.Flush();
            }
        }

        private void ProcessModdedRpfFile(RpfListBuilder.IDirectory rpf, IArchive rageArchiveWrapper7)
        {
            foreach (var c in rpf.Contents)
                ProcessContent(c, rageArchiveWrapper7.Root);
        }

        private void Handle(IArchiveDirectory root, RpfListBuilder.IDirectory innerD, string name)
        {
            var dir = root.GetDirectory(name);
            foreach (var c in innerD.Contents)
                ProcessContent(c, dir);
        }

        private void ProcessContent(KeyValuePair<string, RpfListBuilder.IInnerContent> keyValuePair,
            IArchiveDirectory dir)
        {
            Handle(dir, (dynamic) keyValuePair.Value, keyValuePair.Key);
        }

        private void Handle(IArchiveDirectory root, RpfListBuilder.InnerRpf innerRpf,
            string name)
        {
            var rpf = root.GetFile(name);
            // IMPORTANT: The RPF must have the exact filename like original or it seems to make the RPF corrupt (loading either in RageLib, or in OIV)
            var tmpRpf = _tempPath.GetChildFileWithName(name);
            if (tmpRpf.Exists)
                tmpRpf.FileInfo.Delete();
            try
            {
                rpf.Export(tmpRpf.ToString());
                WriteModdedArchive(innerRpf, tmpRpf);
                NewImport(root, innerRpf, tmpRpf, name);
            }
            finally
            {
                tmpRpf.FileInfo.Delete();
            }
        }

        private void Handle(IArchiveDirectory root, RpfListBuilder.InnerFile file, string name)
        {
            switch (file.Action)
            {
                case ContentAction.Delete:
                    var archiveFile = root.GetFile(name);
                    if (archiveFile != null)
                        root.DeleteFile(archiveFile);
                    break;
                case ContentAction.Import:
                {
                    if (!_config.TreatImportsAsInserts)
                        break;
                    NewImport(root, file, file.FilePath, name);
                    break;
                }
                case ContentAction.Insert:
                {
                    NewImport(root, file, file.FilePath, name);
                    break;
                }
            }
        }

        private static void NewImport(IArchiveDirectory root, RpfListBuilder.IFileContent fc, IAbsoluteFilePath tmpRpf,
            string name)
        {
            var existingFile = root.GetFile(name);
            var af = root.CreateArchiveFile(tmpRpf.ToString(),
                fc.Type == FileType.Default && existingFile != null ? DetermineType(existingFile) : fc.Type);
            if (existingFile != null)
                root.DeleteFile(existingFile);
            //af.IsCompressed = true;
            af.Name = name;
            af.Import(tmpRpf.ToString());
        }

        public static FileType DetermineType(IArchiveFile file)
        {
            return file is RageArchiveBinaryFileWrapper7 ? FileType.Binary : FileType.Resource;
        }

        private static void CopyRpf(IAbsoluteFilePath rpf, IAbsoluteFilePath moddedPath)
        {
            if (moddedPath.Exists)
            {
                Console.WriteLine("{0} already exists, will not copy the original.", moddedPath);
                return;
            }
            Directory.CreateDirectory(moddedPath.ParentDirectoryPath.ToString());
            File.Copy(rpf.ToString(), moddedPath.ToString());
        }

        private static Package ReadXmlFile(IAbsoluteFilePath xmlPath)
        {
            var serializer = new XmlSerializer(typeof (Package));

            using (var stream = new StringReader(File.ReadAllText(xmlPath.ToString())))
            using (var reader = XmlReader.Create(stream))
            {
                return (Package) serializer.Deserialize(reader);
            }
        }

        public class PackagerConfig
        {
            public bool TreatImportsAsInserts { get; set; }

            public RpfListBuilder.RpfListBuilderConfig BuilderConfig { get; set; } =
                new RpfListBuilder.RpfListBuilderConfig();
        }
    }

    [XmlRoot(ElementName = "import")]
    public class Import
    {
        [XmlAttribute(AttributeName = "targetDir")]
        public string TargetDir { get; set; }

        public IRelativeDirectoryPath TargetDirPath
        {
            get { return (".\\" + TargetDir).ToRelativeDirectoryPath(); }
        }

        [XmlAttribute(AttributeName = "file")]
        public string File { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlIgnore]
        public IRelativeFilePath FilePath
        {
            get { return (".\\" + File).ToRelativeFilePath(); }
        }
    }

    [XmlRoot(ElementName = "delete")]
    public class Delete
    {
        [XmlAttribute(AttributeName = "targetDir")]
        public string TargetDir { get; set; }

        [XmlIgnore]
        public IRelativeDirectoryPath TargetDirPath
        {
            get { return (".\\" + TargetDir).ToRelativeDirectoryPath(); }
        }

        [XmlAttribute(AttributeName = "file")]
        public string File { get; set; }

        // TODO: For deleting files we don't want to rely on the File path, but instead the targetdirpath...
        [XmlIgnore]
        public IRelativeFilePath FilePath
        {
            get { return (".\\" + File).ToRelativeFilePath(); }
        }
    }

    [XmlRoot(ElementName = "insert")]
    public class Insert
    {
        [XmlAttribute(AttributeName = "targetDir")]
        public string TargetDir { get; set; }

        [XmlIgnore]
        public IRelativeDirectoryPath TargetDirPath
        {
            get { return (".\\" + TargetDir).ToRelativeDirectoryPath(); }
        }

        [XmlAttribute(AttributeName = "file")]
        public string File { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlIgnore]
        public IRelativeFilePath FilePath
        {
            get { return (".\\" + File).ToRelativeFilePath(); }
        }
    }

    [XmlRoot(ElementName = "package")]
    public class Package
    {
        [XmlElement(ElementName = "import")]
        public List<Import> Import { get; set; }

        [XmlElement(ElementName = "insert")]
        public List<Insert> Insert { get; set; }

        [XmlElement(ElementName = "delete")]
        public List<Delete> Delete { get; set; }
    }

    public enum ContentAction
    {
        Insert,
        Import,
        Delete
    }
}