/*
    Copyright(c) 2017 Neodymium

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

using RageLib.GTA5.Cryptography;
using System.IO;

namespace ExtractKeysFromDump
{
    //
    // Example command for running the tool:
    // ExtractKeysFromDump.exe -executableFile "C:\GTA 5\GTA5-dump.exe" -keyPath "C:\GTA 5\Keys"
    //
    public class Program
    {
        private readonly string[] arguments;

        public Program(string[] arguments)
        {
            this.arguments = arguments;
        }

        public void Run()
        {
            string executableFile = GetArgument("-executableFile");
            string keyPath = GetArgument("-keyPath");
            ExtractKeysIntoDirectory(executableFile, keyPath);
        }

        private string GetArgument(string argumentName)
        {
            for (int i = 0; i < arguments.Length; i++)
            {
                if (arguments[i].Equals(argumentName))
                {
                    return arguments[i + 1];
                }
            }
            return null;
        }

        private void ExtractKeysIntoDirectory(string executableFile, string keyPath)
        {
            GTA5Constants.Generate(File.ReadAllBytes(executableFile));
            GTA5Constants.SaveToPath(keyPath);
        }

        static void Main(string[] args)
        {
            new Program(args).Run();
        }
    }
}
