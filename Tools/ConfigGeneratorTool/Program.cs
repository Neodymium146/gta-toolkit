using System;
using System.Linq;
using System.Reflection;
using NDepend.Path;

namespace ConfigGeneratorTool
{
    internal class Program
    {
        private static readonly IAbsoluteDirectoryPath AssemblyPath =
            Assembly.GetExecutingAssembly().Location.ToAbsoluteFilePath().ParentDirectoryPath;

        private static void Main(string[] args)
        {
            var path = args.Any()
                ? args.First().ToAbsoluteDirectoryPath()
                : AssemblyPath;
            // @"C:\Users\Oliver\Downloads\VirtualFileSystem-150621-Preview\test".ToAbsoluteDirectoryPath();
            PackageConfigWriter.WritePackageConfig(path, AssemblyPath);
            Console.WriteLine("Finished...");
            Console.ReadLine();
        }
    }
}