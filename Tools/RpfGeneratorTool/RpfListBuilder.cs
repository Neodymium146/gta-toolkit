using System;
using System.Collections.Generic;
using System.Linq;
using NDepend.Path;
using RageLib.Extensions;

namespace RpfGeneratorTool
{
    public class RpfListBuilder
    {
        private readonly IAbsoluteDirectoryPath _gameDir;

        public RpfListBuilder(IAbsoluteDirectoryPath gameDir)
        {
            _gameDir = gameDir;
        }

        private static FileType GetType(string type)
        {
            switch (type)
            {
                case "binary":
                    return FileType.Binary;
                case "resource":
                    return FileType.Resource;
            }
            return FileType.Default;
        }

        public List<RootRpf> BuildRpfList(IAbsoluteDirectoryPath modPackagePath, params Package[] packages)
        {
            var list = new List<RootRpf>();
            foreach (var p in packages)
            {
                ProcessInserts(modPackagePath, p, list);
            }
            foreach (var p in packages)
            {
                ProcessImports(modPackagePath, p, list);
            }
            foreach (var p in packages)
            {
                ProcessDeletes(modPackagePath, p, list);
            }
            return list;
        }

        private void ProcessDeletes(IAbsoluteDirectoryPath modPackagePath, Package p, ICollection<RootRpf> list)
        {
            foreach (var d in p.Delete)
            {
                var f = BuildFileContent(modPackagePath, d.TargetDirPath.GetAbsolutePathFrom(_gameDir), d.FilePath, list);
                f.Action = ContentAction.Delete;
                //f.Type = GetType(d.Type);
            }
        }

        private void ProcessImports(IAbsoluteDirectoryPath modPackagePath, Package p, ICollection<RootRpf> list)
        {
            foreach (var i in p.Import)
            {
                var f = BuildFileContent(modPackagePath, i.TargetDirPath.GetAbsolutePathFrom(_gameDir), i.FilePath, list);
                f.Action = ContentAction.Import;
                f.Type = GetType(i.Type);
            }
        }

        private void ProcessInserts(IAbsoluteDirectoryPath modPackagePath, Package p, ICollection<RootRpf> list)
        {
            foreach (var i in p.Insert)
            {
                var f = BuildFileContent(modPackagePath, i.TargetDirPath.GetAbsolutePathFrom(_gameDir), i.FilePath, list);
                f.Action = ContentAction.Insert;
                f.Type = GetType(i.Type);
            }
        }

        private static IFileContent BuildFileContent(IAbsoluteDirectoryPath modPackagePath,
            IAbsoluteDirectoryPath targetDir,
            IRelativeFilePath relativePath, ICollection<RootRpf> list)
        {
            var rpfFile = RpfFile.FromPath(targetDir.ToString());
            if (!rpfFile.ExternalRpfFile.Exists)
            {
                throw new Exception("Unable to find an RPF file: " + rpfFile.ExternalRpfFile);
            }

            IDirectory root = list.FirstOrDefault(x => x.FilePath.Equals(rpfFile.ExternalRpfFile));
            if (root == null)
            {
                var rootRpf = new RootRpf(rpfFile.ExternalRpfFile);
                root = rootRpf;
                list.Add(rootRpf);
            }
            foreach (var p in rpfFile.Path)
            {
                if (p.EndsWith(".rpf"))
                {
                    root = root.Contents.ContainsKey(p)
                        ? (InnerRpf) root.Contents[p]
                        : (InnerRpf) (root.Contents[p] = new InnerRpf());
                }
                else
                {
                    root = root.Contents.ContainsKey(p)
                        ? (InnerDirectory) root.Contents[p]
                        : (InnerDirectory) (root.Contents[p] = new InnerDirectory());
                }
            }

            var file = relativePath.FileName;
            IFileContent f;
            if (file.EndsWith(".rpf"))
                f = root.Contents.ContainsKey(file)
                    ? (InnerRpf) root.Contents[file]
                    : (InnerRpf) (root.Contents[file] = new InnerRpf());
            else
                f = root.Contents.ContainsKey(file)
                    ? (InnerFile) root.Contents[file]
                    : (InnerFile) (root.Contents[file] = new InnerFile());
            f.FilePath = relativePath.GetAbsolutePathFrom(modPackagePath);
            return f;
        }

        public class RpfFile
        {
            public IAbsoluteFilePath ExternalRpfFile { get; set; }
            public List<string> Path { get; set; }

            public static RpfFile FromPath(string path)
            {
                var foundRoot = false;
                var rpfRoot = new List<string>();
                var internalPath = new List<string>();
                foreach (var p in path.Split('\\', '/'))
                {
                    if (foundRoot)
                    {
                        internalPath.Add(p);
                    }
                    else
                    {
                        if (p.EndsWith(".rpf"))
                        {
                            rpfRoot.Add(p);
                            foundRoot = true;
                        }
                        else
                        {
                            rpfRoot.Add(p);
                        }
                    }
                }
                return new RpfFile
                {
                    ExternalRpfFile = string.Join("\\", rpfRoot).ToAbsoluteFilePath(),
                    Path = internalPath
                };
            }
        }

        public interface IInnerContent
        {
        }

        public interface IFileContent : IInnerContent
        {
            ContentAction Action { get; set; }
            IAbsoluteFilePath FilePath { get; set; }
            FileType Type { get; set; }
        }

        public interface IContent
        {
        }

        public interface IDirectory : IContent
        {
            Dictionary<string, IInnerContent> Contents { get; set; }
        }

        public class RootRpf : IDirectory
        {
            public RootRpf(IAbsoluteFilePath filePath)
            {
                FilePath = filePath;
            }

            public IAbsoluteFilePath FilePath { get; set; }
            public Dictionary<string, IInnerContent> Contents { get; set; } = new Dictionary<string, IInnerContent>();
        }

        public class FileContent : IContent, IFileContent
        {
            public IAbsoluteFilePath FilePath { get; set; }
            public FileType Type { get; set; }
            public ContentAction Action { get; set; }
        }

        public class InnerRpf : FileContent, IDirectory
        {
            public Dictionary<string, IInnerContent> Contents { get; set; } = new Dictionary<string, IInnerContent>();
        }

        public class InnerFile : FileContent
        {
        }

        public class InnerDirectory : IDirectory, IInnerContent
        {
            public Dictionary<string, IInnerContent> Contents { get; set; } = new Dictionary<string, IInnerContent>();
        }
    }
}