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

using HtmlAgilityPack;
using RageLib.Cryptography;
using RageLib.GTA5.Archives;
using RageLib.GTA5.Cryptography;
using RageLib.GTA5.PSO;
using RageLib.GTA5.Resources.PC;
using RageLib.Hash;
using RageLib.Resources.GTA5;
using RageLib.Resources.GTA5.PC.Meta;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace RageLib.GTA5.Utilities
{
    public static class MetaUtilities
    {
        public static HashSet<int> GetAllHashesFromMetas(string gameDirectoryName)
        {
            var hashes = new HashSet<int>();
            foreach (var hash in GetAllHashesFromResourceMetas(gameDirectoryName))
                hashes.Add(hash);
            foreach (var hash in GetAllHashesFromPsoMetas(gameDirectoryName))
                hashes.Add(hash);
            return hashes;
        }

        public static HashSet<int> GetAllHashesFromResourceMetas(string gameDirectoryName)
        {
            var hashes = new HashSet<int>();
            ArchiveUtilities.ForEachResourceFile(gameDirectoryName, (fullFileName, file, encryption) =>
            {
                if (file.Name.EndsWith(ResourceFileTypes_GTA5_pc.Meta.Extension, StringComparison.OrdinalIgnoreCase) ||
                file.Name.EndsWith(ResourceFileTypes_GTA5_pc.Types.Extension, StringComparison.OrdinalIgnoreCase) ||
                file.Name.EndsWith(ResourceFileTypes_GTA5_pc.Maps.Extension, StringComparison.OrdinalIgnoreCase)
                )
                {
                    var stream = new MemoryStream();
                    file.Export(stream);
                    stream.Position = 0;

                    var resource = new ResourceFile_GTA5_pc<MetaFile>();
                    resource.Load(stream);

                    var meta = resource.ResourceData;
                    if (meta.StructureInfos != null)
                    {
                        foreach (var structureInfo in meta.StructureInfos)
                        {
                            hashes.Add(structureInfo.StructureKey);
                            hashes.Add(structureInfo.StructureNameHash);
                            foreach (var structureEntryInfo in structureInfo.Entries)
                            {
                                if (structureEntryInfo.EntryNameHash != 0x100)
                                {
                                    hashes.Add(structureEntryInfo.EntryNameHash);
                                }
                            }
                        }
                    }

                    if (meta.EnumInfos != null)
                    {
                        foreach (var enumInfo in meta.EnumInfos)
                        {
                            hashes.Add(enumInfo.EnumKey);
                            hashes.Add(enumInfo.EnumNameHash);
                            foreach (var enumEntryInfo in enumInfo.Entries)
                            {
                                hashes.Add(enumEntryInfo.EntryNameHash);
                            }
                        }
                    }

                    Console.WriteLine(file.Name);
                }
            });
            return hashes;
        }

        public static HashSet<int> GetAllHashesFromPsoMetas(string gameDirectoryName)
        {
            var hashes = new HashSet<int>();
            ArchiveUtilities.ForEachBinaryFile(gameDirectoryName, (fullFileName, file, encryption) =>
            {
                if (file.Name.EndsWith(".ymf") || file.Name.EndsWith(".ymt"))
                {
                    var stream = new MemoryStream();
                    file.Export(stream);

                    var buf = new byte[stream.Length];
                    stream.Position = 0;
                    stream.Read(buf, 0, buf.Length);

                    if (file.IsEncrypted)
                    {
                        if (encryption == RageArchiveEncryption7.AES)
                        {
                            buf = AesEncryption.DecryptData(buf, GTA5Constants.PC_AES_KEY);
                        }
                        else
                        {
                            var qq = GTA5Hash.CalculateHash(file.Name);
                            var gg = (qq + (uint)file.UncompressedSize + (101 - 40)) % 0x65;
                            buf = GTA5Crypto.Decrypt(buf, GTA5Constants.PC_NG_KEYS[gg]);
                        }
                    }

                    if (file.IsCompressed)
                    {
                        var def = new DeflateStream(new MemoryStream(buf), CompressionMode.Decompress);
                        var bufnew = new byte[file.UncompressedSize];
                        def.Read(bufnew, 0, (int)file.UncompressedSize);
                        buf = bufnew;
                    }

                    var cleanStream = new MemoryStream(buf);
                    if (PsoFile.IsPSO(cleanStream))
                    {
                        PsoFile pso = new PsoFile();
                        pso.Load(cleanStream);

                        foreach (var info in pso.DefinitionSection.EntriesIdx)
                        {
                            hashes.Add(info.NameHash);
                        }
                        foreach (var info in pso.DefinitionSection.Entries)
                        {
                            if (info is PsoStructureInfo)
                            {
                                var structureInfo = (PsoStructureInfo)info;
                                foreach (var entryInfo in structureInfo.Entries)
                                {
                                    hashes.Add(entryInfo.EntryNameHash);
                                }
                            }

                            if (info is PsoEnumInfo)
                            {
                                var enumInfo = (PsoEnumInfo)info;
                                foreach (var entryInfo in enumInfo.Entries)
                                {
                                    hashes.Add(entryInfo.EntryNameHash);
                                }
                            }
                        }

                        Console.WriteLine(file.Name);
                    }
                }
            });
            return hashes;
        }
        
        public static HashSet<string> GetAllStringsFromAllXmls(string gameDirectoryName)
        {
            var xmlStrings = new HashSet<string>();

            ArchiveUtilities.ForEachBinaryFile(gameDirectoryName, (fullFileName, file, encryption) =>
            {
                if (file.Name.EndsWith(".meta", StringComparison.OrdinalIgnoreCase) ||
                 file.Name.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                {
                    var fileStream = new MemoryStream();
                    file.Export(fileStream);

                    var buf = new byte[fileStream.Length];
                    fileStream.Position = 0;
                    fileStream.Read(buf, 0, buf.Length);

                    if (file.IsEncrypted)
                    {
                        if (encryption == RageArchiveEncryption7.AES)
                        {
                            buf = AesEncryption.DecryptData(buf, GTA5Constants.PC_AES_KEY);
                        }
                        else
                        {
                            var qq = GTA5Hash.CalculateHash(file.Name);
                            var gg = (qq + (uint)file.UncompressedSize + (101 - 40)) % 0x65;
                            buf = GTA5Crypto.Decrypt(buf, GTA5Constants.PC_NG_KEYS[gg]);
                        }
                    }

                    if (file.IsCompressed)
                    {
                        var def = new DeflateStream(new MemoryStream(buf), CompressionMode.Decompress);
                        var bufnew = new byte[file.UncompressedSize];
                        def.Read(bufnew, 0, (int)file.UncompressedSize);
                        buf = bufnew;
                    }

                    var cleanedStream = new MemoryStream(buf);
                    foreach (string xmlString in GetAllStringsFromXml(cleanedStream))
                    {
                        xmlStrings.Add(xmlString);
                    }

                    Console.WriteLine(file.Name);
                }
            });

            return xmlStrings;
        }

        public static HashSet<string> GetAllStringsFromXml(string xmlFileName)
        {
            using (var xmlFileStream = new FileStream(xmlFileName, FileMode.Open))
            {
                return GetAllStringsFromXml(xmlFileStream);
            }
        }

        public static HashSet<string> GetAllStringsFromXml(Stream xmlFileStream)
        {
            var xmlStrings = new HashSet<string>();

            var document = new HtmlDocument();
            document.OptionOutputOriginalCase = true;
            document.OptionWriteEmptyNodes = true;
            document.Load(xmlFileStream);

            var stack = new Stack<HtmlNode>();
            stack.Push(document.DocumentNode);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                foreach (var descendantNode in node.Descendants())
                {
                    stack.Push(descendantNode);
                }
                if (node.NodeType == HtmlNodeType.Text)
                {
                    xmlStrings.Add(node.InnerText.Trim());

                    // for flags...
                    string[] splitted = node.InnerText.Split(new char[] {' ','\t','\n' },StringSplitOptions.RemoveEmptyEntries);
                    foreach (var x in splitted)
                    {
                        xmlStrings.Add(x.Trim());
                    }
                }
                if (node.NodeType == HtmlNodeType.Element)
                {
                    xmlStrings.Add(node.OriginalName.Trim());
                    foreach (var attribute in node.Attributes)
                    {
                        xmlStrings.Add(attribute.OriginalName.Trim());
                        xmlStrings.Add(attribute.Value.Trim());
                    }
                }
            }

            return xmlStrings;
        }

        public static HashSet<string> GetAllStringsThatMatchAHash(IEnumerable<string> listOfStrings, ISet<int> listOfHashes)
        {
            var matchingStrings = new HashSet<string>();
            foreach (var s in listOfStrings)
            {
                int hash = unchecked((int)Jenkins.Hash(s));
                if (listOfHashes.Contains(hash))
                    matchingStrings.Add(s);
            }
            return matchingStrings;
        }
    }
}
