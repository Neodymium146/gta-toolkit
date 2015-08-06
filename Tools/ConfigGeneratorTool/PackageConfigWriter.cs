using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NDepend.Path;

namespace ConfigGeneratorTool
{
    internal class PackageConfigWriter
    {
        //private static string filePath = @"";
        //private static string filePath = @"update\update.rpf\common\data\";
        //private static string filePath = @"common.rpf\data\";

        private const string Line = @"<{0} targetDir=""{1}"" file=""{2}"" />";
        private const string TypeImport = "import";
        private const string TypeInsert = "insert";
        private const string RpfdataList = "rpfdata.list";

        [Obsolete] private static readonly string[] Ignore =
        {
            "ConfigGenerator.exe", "NDepend.Path.dll", "Newtonsoft.Json.dll",
            "package.config", RpfdataList
        };

        public static void WritePackageConfig(IAbsoluteDirectoryPath path, IAbsoluteDirectoryPath rpfListPath)
        {
            var rpfList = GetRpfList(rpfListPath);
            var output = Build(path, rpfList);
            File.WriteAllText(path.GetChildFileWithName("package.config").ToString(), output);
        }

        private static string Build(IAbsoluteDirectoryPath path, IReadOnlyCollection<IRelativeFilePath> rpfList)
        {
            var sb = new StringBuilder();
            sb.AppendLine(@"<?xml version=""1.0"" encoding=""utf-8""?>");
            sb.AppendLine(@"<package>");
            var files =
                path.DirectoryInfo.EnumerateFiles("*", SearchOption.AllDirectories)
                    .Select(x => new Data(x.FullName.ToAbsoluteFilePath(), path));
            foreach (var file in files.Where(file => !Ignore.Contains(file.FileName)))
            {
                if (rpfList != null && !rpfList.Any(x => x.Equals(file.RealFileLocation)))
                {
                    Console.WriteLine("The following file does not exist: {0}", file.FormattedRealFileLocation);
                    sb.AppendFormat(Line + "\n", TypeInsert, file.FormattedRpfPlacement, file.FormattedRealFileLocation);
                }
                else
                {
                    sb.AppendFormat(Line + "\n", TypeImport, file.FormattedRpfPlacement, file.FormattedRealFileLocation);
                }
            }
            sb.AppendLine(@"</package>");
            return sb.ToString();
        }

        private static IReadOnlyCollection<IRelativeFilePath> GetRpfList(IAbsoluteDirectoryPath rpfListPath)
        {
            IReadOnlyCollection<IRelativeFilePath> rpfList = null;
            var rpfDataListFile = rpfListPath.GetChildFileWithName(RpfdataList);
            if (rpfDataListFile.Exists)
            {
                Console.WriteLine("Found {0}, will check package config for validity.", rpfDataListFile);
                rpfList = File.ReadAllLines(rpfDataListFile.ToString()).Select(x => x.ToRelativeFilePath()).ToArray();
            }
            else
            {
                Console.WriteLine("Missing {0}, will NOT check package config for validity.", RpfdataList);
            }
            return rpfList;
        }

        public class Data
        {
            public Data(IAbsoluteFilePath realFile, IAbsoluteDirectoryPath basePath)
            {
                FileName = realFile.FileName;
                RealFileLocation = realFile.GetRelativePathFrom(basePath);
                RpfPlacement = RealFileLocation.ParentDirectoryPath;
            }

            public string FileName { get; }
            public IRelativeFilePath RealFileLocation { get; }
            public IRelativeDirectoryPath RpfPlacement { get; }
            public string FormattedRealFileLocation => RealFileLocation.ToString().Substring(2);

            public string FormattedRpfPlacement
                => RpfPlacement.ToString().Length > 1 ? RpfPlacement.ToString().Substring(2).TrimEnd('\\') : "";
        }
    }
}