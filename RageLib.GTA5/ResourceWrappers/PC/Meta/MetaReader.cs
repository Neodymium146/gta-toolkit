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

using RageLib.Data;
using RageLib.GTA5.ResourceWrappers.PC.Meta.Types;
using RageLib.Resources.Common;
using RageLib.Resources.GTA5;
using RageLib.Resources.GTA5.PC.Meta;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RageLib.GTA5.ResourceWrappers.PC.Meta
{
    public class MetaReader
    {
        public IMetaValue Read(string fileName)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Open))
            {
                return Read(fileStream);
            }
        }

        public IMetaValue Read(Stream fileStream)
        {
            var resource = new ResourceFile_GTA5_pc<MetaFile>();
            resource.Load(fileStream);
            return Parse(resource.ResourceData);
        }

        public IMetaValue Parse(MetaFile meta)
        {
            var blockKeys = new List<int>();
            var blocks = new List<List<IMetaValue>>();

            //////////////////////////////////////////////////
            // first step: flat conversion
            //////////////////////////////////////////////////

            foreach (var block in meta.DataBlocks)
            {
                blockKeys.Add(block.StructureNameHash);
                switch (block.StructureNameHash)
                {
                    case 0x00000007:
                        blocks.Add(ReadBlock(block, () => new MetaGeneric())); // has no special type declaration in .meta -> pointer
                        break;
                    case 0x00000010:
                        blocks.Add(ReadBlock(block, () => new MetaByte_A())); // char_array
                        break;
                    case 0x00000011:
                        blocks.Add(ReadBlock(block, () => new MetaByte_B()));  // has no special type declaration in .meta -> string
                        break;
                    case 0x00000013:
                        blocks.Add(ReadBlock(block, () => new MetaInt16_B())); // probably short_array
                        break;
                    case 0x00000015:
                        blocks.Add(ReadBlock(block, () => new MetaInt32_B())); // int_array
                        break;
                    case 0x00000021:
                        blocks.Add(ReadBlock(block, () => new MetaFloat())); // float_array
                        break;
                    case 0x00000033:
                        blocks.Add(ReadBlock(block, () => new MetaFloat4_XYZ())); // vector3_array
                        break;
                    case 0x0000004A:
                        blocks.Add(ReadBlock(block, () => new MetaInt32_Hash())); // probably list of <Item>HASH_OF_SOME_NAME</Item>
                        break;
                    default:
                        blocks.Add(ReadBlock(block, () => new MetaStructure(meta, GetInfo(meta, block.StructureNameHash)))); // has no special type declaration in .meta -> structure
                        break;
                }
            }

            //////////////////////////////////////////////////
            // second step: map references
            //////////////////////////////////////////////////

            var referenced = new HashSet<IMetaValue>();
            var stack = new Stack<IMetaValue>();
            foreach (var block in blocks)
            {
                foreach (var entry in block)
                {
                    stack.Push(entry);
                }
            }
            while (stack.Count > 0)
            {
                var entry = stack.Pop();
                if (entry is MetaArray)
                {
                    var arrayEntry = entry as MetaArray;
                    var realBlockIndex = arrayEntry.BlockIndex - 1;
                    if (realBlockIndex >= 0)
                    {
                        arrayEntry.Entries = new List<IMetaValue>();
                        var realEntryIndex = arrayEntry.Offset / GetSize(meta, blockKeys[realBlockIndex]);
                        for (int i = 0; i < arrayEntry.NumberOfEntries; i++)
                        {
                            var x = blocks[realBlockIndex][realEntryIndex + i];
                            arrayEntry.Entries.Add(x);
                            referenced.Add(x);
                        }
                    }
                }
                if (entry is MetaCharPointer)
                {
                    var charPointerEntry = entry as MetaCharPointer;
                    var realBlockIndex = charPointerEntry.DataBlockIndex - 1;
                    if (realBlockIndex >= 0)
                    {
                        string value = "";
                        for (int i = 0; i < charPointerEntry.StringLength; i++)
                        {
                            var x = (MetaByte_A)blocks[realBlockIndex][i + charPointerEntry.DataOffset];
                            value += (char)x.Value;
                        }
                        charPointerEntry.Value = value;
                    }
                }
                if (entry is MetaDataBlockPointer)
                {
                    var dataPointerEntry = entry as MetaDataBlockPointer;
                    var realBlockIndex = dataPointerEntry.BlockIndex - 1;
                    if (realBlockIndex >= 0)
                    {
                        byte[] b = ToBytes(meta.DataBlocks[realBlockIndex].Data);
                        dataPointerEntry.Data = b;
                    }
                }
                if (entry is MetaGeneric)
                {
                    var genericEntry = entry as MetaGeneric;
                    var realBlockIndex = genericEntry.BlockIndex - 1;
                    var realEntryIndex = genericEntry.Offset * 16 / GetSize(meta, blockKeys[realBlockIndex]);
                    var x = blocks[realBlockIndex][realEntryIndex];
                    genericEntry.Value = x;
                    referenced.Add(x);
                }
                if (entry is MetaStructure)
                {
                    var structureEntry = entry as MetaStructure;
                    foreach (var x in structureEntry.Values)
                    {
                        stack.Push(x.Value);
                    }
                }
            }

            //////////////////////////////////////////////////
            // third step: find root
            //////////////////////////////////////////////////

            var rootSet = new HashSet<IMetaValue>();
            foreach (var x in blocks)
            {
                foreach (var y in x)
                {
                    if (y is MetaStructure && !referenced.Contains(y))
                    {
                        rootSet.Add(y);
                    }
                }
            }

            var res = rootSet.First();

            if (res != blocks[(int)meta.RootBlockIndex - 1][0])
                throw new System.Exception("wrong root block index");

            return res;
        }

        private List<IMetaValue> ReadBlock(DataBlock block, CreateMetaValueDelegate CreateMetaValue)
        {
            var result = new List<IMetaValue>();
            var reader = new DataReader(new MemoryStream(ToBytes(block.Data)));
            while (reader.Position < reader.Length)
            {
                var value = CreateMetaValue();
                value.Read(reader);
                result.Add(value);
            }
            return result;
        }

        private byte[] ToBytes(ResourceSimpleArray<byte_r> data)
        {
            var result = new byte[data.Count];
            for (int i = 0; i < data.Count; i++)
                result[i] = data[i].Value;
            return result;
        }

        public static StructureInfo GetInfo(MetaFile meta, int structureKey)
        {
            StructureInfo info = null;
            foreach (var x in meta.StructureInfos)
                if (x.StructureNameHash == structureKey)
                    info = x;
            return info;
        }

        public int GetSize(MetaFile meta, int typeKey)
        {
            switch (typeKey)
            {
                case 0x00000007:
                    return 8;
                case 0x00000010:
                    return 1;
                case 0x00000011:
                    return 1;
                case 0x00000013:
                    return 2;
                case 0x00000015:
                    return 4;
                case 0x00000021:
                    return 4;
                case 0x00000033:
                    return 16;
                case 0x0000004A:
                    return 4;
                default:
                    return (int)GetInfo(meta, typeKey).StructureLength;
            }
        }
    }
}
