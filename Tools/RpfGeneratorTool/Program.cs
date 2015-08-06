#if DEBUG
#define TESTING
#endif

using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using NDepend.Path;
using RageLib.GTA5.Cryptography;

namespace RpfGeneratorTool
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            LoadConsts();
#if TESTING
            if (args.Length == 0)
            {
                args = new[]
                {
                    @"D:\games\Rockstar Games\Grand Theft Auto V",
                    @"D:\games\Rockstar Games\Grand Theft Auto V\syncpackages\@RealismDispatchEnhanced"
                };
            }
#endif
            var gamePath = args.First().ToAbsoluteDirectoryPath();
            var tempPath = Path.GetTempPath().ToAbsoluteDirectoryPath().GetChildDirectoryWithName("RpfGenerator");
            try
            {
                if (!tempPath.Exists)
                    Directory.CreateDirectory(tempPath.ToString());
                var p = new Packager(gamePath, gamePath.GetChildDirectoryWithName("mods"), tempPath)
                {
                    TreatImportsAsInserts = true
                };
                var dir = args.Length > 1 ? args[1] : Directory.GetCurrentDirectory();
                p.PackageMod(dir.ToAbsoluteDirectoryPath());
            }
            finally
            {
                Directory.Delete(tempPath.ToString());
            }
        }

        private static void LoadConsts()
        {
            using (var fs = new FileStream("gta5_const.dat", FileMode.Open))
                LoadConsts(fs);
        }

        private static void LoadConsts(Stream fs)
        {
            var bf = new BinaryFormatter();

            GTA5Constants.PC_AES_KEY = (byte[]) bf.Deserialize(fs);
            GTA5Constants.PC_NG_KEYS = (byte[][]) bf.Deserialize(fs);
            GTA5Constants.PC_NG_DECRYPT_TABLES = (byte[][]) bf.Deserialize(fs);
            GTA5Constants.PC_LUT = (byte[]) bf.Deserialize(fs);
        }
    }
}