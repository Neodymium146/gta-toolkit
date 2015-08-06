using System.IO;
using System.Linq;
using RageLib.Archives;

namespace RageLib.Extensions
{
    public static class RageArchiveExtensions
    {
        // TODO: Not all of these are confirmed..
        // TODO: Sometimes these are resources, sometimes these are binary files:
        // - .ymt
        private static readonly string[] ResourceExtensions =
        {
            ".ytd", ".ydr", ".ymf", ".ymap", ".ynd", ".ysc", ".ydd",
            ".yed", ".ycd", ".ypt", ".ytyp", ".yft", ".yfd", ".yvr", ".ybn", ".ynv", ".yld", ".ypdb", ".ybd", ".ywr",
            ".ypl"
        };

        public static IArchiveFile CreateArchiveFile(this IArchiveDirectory dir, string filePath, FileType type)
        {
            switch (type)
            {
                case FileType.Resource:
                    return dir.CreateResourceFile();
                case FileType.Binary:
                    return dir.CreateBinaryFile();
                default:
                    if (ResourceExtensions.Contains(new FileInfo(filePath).Extension))
                        return dir.CreateResourceFile();
                    return dir.CreateBinaryFile();
            }
        }

        public static FileType DetermineType(FileSystemInfo info2)
        {
            return ResourceExtensions.Contains(info2.Extension.ToLower()) ? FileType.Resource : FileType.Binary;
        }
    }

    public enum FileType
    {
        Default,
        Binary,
        Resource
    }
}