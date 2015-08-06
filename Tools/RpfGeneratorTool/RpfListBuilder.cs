using System;
using System.Collections.Generic;
using System.Linq;
using NDepend.Path;
using RageLib.Extensions;

namespace RpfGeneratorTool
{
    public class RpfListBuilder
    {
        private readonly string[] _audioPaths = {@"x64\audio"};
        private readonly RpfListBuilderConfig _config;
        private readonly IAbsoluteDirectoryPath _gameDir;

        public RpfListBuilder(IAbsoluteDirectoryPath gameDir, RpfListBuilderConfig config)
        {
            _gameDir = gameDir;
            _config = config;
        }

        public RpfListBuilder(IAbsoluteDirectoryPath gameDir) : this(gameDir, new RpfListBuilderConfig())
        {
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

        private void ProcessInserts(IAbsoluteDirectoryPath modPackagePath, Package p, ICollection<RootRpf> list)
        {
            foreach (var i in p.Insert)
            {
                BuildFileContent(modPackagePath, i.TargetDirPath.GetAbsolutePathFrom(_gameDir), i.FilePath, list,
                    ContentAction.Insert, GetType(i.Type));
            }
        }

        private void ProcessImports(IAbsoluteDirectoryPath modPackagePath, Package p, ICollection<RootRpf> list)
        {
            foreach (var i in p.Import)
            {
                BuildFileContent(modPackagePath, i.TargetDirPath.GetAbsolutePathFrom(_gameDir), i.FilePath, list,
                    ContentAction.Import, GetType(i.Type));
            }
        }

        private void ProcessDeletes(IAbsoluteDirectoryPath modPackagePath, Package p, ICollection<RootRpf> list)
        {
            foreach (var d in p.Delete)
            {
                BuildFileContent(modPackagePath, d.TargetDirPath.GetAbsolutePathFrom(_gameDir), d.FilePath, list,
                    ContentAction.Delete);
            }
        }

        private void BuildFileContent(IAbsoluteDirectoryPath modPackagePath, IAbsoluteDirectoryPath targetDir,
            IRelativeFilePath relativePath, ICollection<RootRpf> list, ContentAction action,
            FileType type = FileType.Default)
        {
            var rpfFile = RpfFile.FromPath(targetDir);
            if (!rpfFile.ExternalRpfFile.Exists)
            {
                throw new Exception("Unable to find an RPF file: " + rpfFile.ExternalRpfFile);
            }

            if (_config.AudioPathsOnly && !IsAudioPath(rpfFile))
                return;

            IDirectory root = list.FirstOrDefault(x => x.FilePath.Equals(rpfFile.ExternalRpfFile));
            if (root == null)
            {
                var rootRpf = new RootRpf(rpfFile.ExternalRpfFile);
                root = rootRpf;
                list.Add(rootRpf);
            }
            foreach (var p in rpfFile.PathParts)
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
            f.Action = action;
            f.Type = type;
        }

        private bool IsAudioPath(RpfFile rpfFile)
        {
            var path = rpfFile.GetPath();
            return _audioPaths.Any(x => path.StartsWith(x, StringComparison.CurrentCultureIgnoreCase));
        }

        public class RpfListBuilderConfig
        {
            public bool AudioPathsOnly { get; set; }
        }

        public class RpfFile
        {
            public IAbsoluteFilePath ExternalRpfFile { get; set; }
            public List<string> PathParts { get; set; }

            public static RpfFile FromPath(IAbsoluteDirectoryPath path)
            {
                var foundRoot = false;
                var rpfRoot = new List<string>();
                var internalPath = new List<string>();
                foreach (var p in path.ToString().Split('\\', '/'))
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
                    PathParts = internalPath
                };
            }

            public string GetPath()
            {
                return string.Join("\\", PathParts);
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