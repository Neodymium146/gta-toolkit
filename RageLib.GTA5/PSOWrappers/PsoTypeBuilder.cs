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

using RageLib.GTA5.PSO;
using RageLib.GTA5.PSOWrappers.Types;
using System;

namespace RageLib.GTA5.PSOWrappers
{
    public static class PsoTypeBuilder
    {
        public static IPsoValue Make(PsoFile pso, PsoStructureInfo structureInfo, PsoStructureEntryInfo entryInfo)
        {
            switch (entryInfo.Type)
            {
                case DataType.Array:
                    {
                        switch (entryInfo.Unk_5h)
                        {
                            case 0:
                                {
                                    var t = structureInfo.Entries[entryInfo.ReferenceKey & 0x0000FFFF];
                                    return new PsoArray0(pso, structureInfo, t);
                                }
                            case 1:
                                {
                                    var typeIndex = entryInfo.ReferenceKey & 0x0000FFFF;
                                    var num = (entryInfo.ReferenceKey >> 16) & 0x0000FFFF;
                                    var t = structureInfo.Entries[typeIndex];
                                    return new PsoArray1(pso, structureInfo, t, num);
                                }
                            case 4:
                                {
                                    var typeIndex = entryInfo.ReferenceKey & 0x0000FFFF;
                                    var num = (entryInfo.ReferenceKey >> 16) & 0x0000FFFF;
                                    var t = structureInfo.Entries[typeIndex];
                                    return new PsoArray4(pso, structureInfo, t, num);
                                }
                            default:
                                {
                                    throw new Exception("Unsupported array type.");
                                }
                        }
                    }
                case DataType.String:
                    {
                        switch (entryInfo.Unk_5h)
                        {
                            case 0:
                                {
                                    var len = (entryInfo.ReferenceKey >> 16) & 0x0000FFFF;
                                    return new PsoString0(len);
                                }
                            case 1:
                                {
                                    return new PsoString1();
                                }
                            case 2:
                                {
                                    return new PsoString2();
                                }
                            case 3:
                                {
                                    return new PsoString3();
                                }
                            case 7:
                                {
                                    return new PsoString7();
                                }
                            case 8:
                                {
                                    return new PsoString8();
                                }
                            default:
                                {
                                    throw new Exception("Unsupported string type.");
                                }
                        }
                    }
                case DataType.Enum:
                    {
                        switch (entryInfo.Unk_5h)
                        {
                            case 0:
                                {
                                    var entryValue = new PsoEnumInt();
                                    entryValue.TypeInfo = GetEnumInfo(pso, entryInfo.ReferenceKey);
                                    return entryValue;
                                }
                            case 2:
                                {
                                    var entryValue = new PsoEnumByte();
                                    entryValue.TypeInfo = GetEnumInfo(pso, entryInfo.ReferenceKey);
                                    return entryValue;
                                }
                            default:
                                {
                                    throw new Exception("Unsupported enum type.");
                                }
                        }
                    }
                case DataType.Flags:
                    {
                        switch (entryInfo.Unk_5h)
                        {
                            case 0:
                                {
                                    var entryValue = new PsoFlagsInt();
                                    var sidx = entryInfo.ReferenceKey & 0x0000FFFF;

                                    if (sidx != 0xfff)
                                    {
                                        var reftype = structureInfo.Entries[sidx];
                                        entryValue.TypeInfo = GetEnumInfo(pso, reftype.ReferenceKey);
                                    }


                                    return entryValue;
                                }
                            case 1:
                                {
                                    var entryValue = new PsoFlagsShort();
                                    var sidx = entryInfo.ReferenceKey & 0x0000FFFF;

                                    var reftype = structureInfo.Entries[sidx];
                                    entryValue.TypeInfo = GetEnumInfo(pso, reftype.ReferenceKey);

                                    return entryValue;
                                }
                            case 2:
                                {
                                    var entryValue = new PsoFlagsByte();
                                    var sidx = entryInfo.ReferenceKey & 0x0000FFFF;
                                    var reftype = structureInfo.Entries[sidx];
                                    entryValue.TypeInfo = GetEnumInfo(pso, reftype.ReferenceKey);
                                    return entryValue;
                                }
                            default:
                                {
                                    throw new Exception("Unsupported flags type.");
                                }
                        }
                    }
                case DataType.Integer:
                    {
                        switch (entryInfo.Unk_5h)
                        {
                            case 0: return new PsoIntSigned();
                            case 1: return new PsoIntUnsigned();
                            default: throw new Exception("Unsupported integer type.");
                        }
                    }
                case DataType.Structure:
                    {
                        switch (entryInfo.Unk_5h)
                        {
                            case 0:
                                {
                                    var t1 = GetStructureInfo(pso, entryInfo.ReferenceKey);
                                    var t2 = GetStructureIndexInfo(pso, entryInfo.ReferenceKey);
                                    var entryValue = new PsoStructure(pso, t1, t2, entryInfo);
                                    return entryValue;
                                }
                            case 3:
                                {
                                    return new PsoStructure3(pso, structureInfo, entryInfo);
                                }
                            default:
                                {
                                    throw new Exception("Unsupported structure type.");
                                }
                        }
                    }
                case DataType.Map:
                    {
                        switch (entryInfo.Unk_5h)
                        {
                            case 1:
                                {
                                    var idx1 = entryInfo.ReferenceKey & 0x0000FFFF;
                                    var idx2 = (entryInfo.ReferenceKey >> 16) & 0x0000FFFF;
                                    var reftype1 = structureInfo.Entries[idx2];
                                    var reftype2 = structureInfo.Entries[idx1];
                                    return new PsoMap(pso, structureInfo, reftype1, reftype2);
                                }
                            default: throw new Exception("Unsupported PsoType5 type.");
                        }

                    }
                case DataType.INT_05h:
                    {
                        switch (entryInfo.Unk_5h)
                        {
                            case 0: return new PsoType5();
                            default: throw new Exception("Unsupported PsoType5 type.");
                        }
                    }
                case DataType.Byte:
                    {
                        switch (entryInfo.Unk_5h)
                        {
                            case 0: return new PsoByte();
                            default: throw new Exception("Unsupported PsoByte type.");
                        }
                    }
                case DataType.Boolean:
                    {
                        switch (entryInfo.Unk_5h)
                        {
                            case 0: return new PsoBoolean();
                            default: throw new Exception("Unsupported boolean type.");
                        }
                    }
                case DataType.Float:
                    {
                        switch (entryInfo.Unk_5h)
                        {
                            case 0: return new PsoFloat();
                            default: throw new Exception("Unsupported float type.");
                        }
                    }
                case DataType.Float2:
                    {
                        switch (entryInfo.Unk_5h)
                        {
                            case 0: return new PsoFloat2();
                            default: throw new Exception("Unsupported float2 type.");
                        }
                    }
                case DataType.Float3:
                    {
                        switch (entryInfo.Unk_5h)
                        {
                            case 0: return new PsoFloat4A();
                            default: throw new Exception("Unsupported float3 type.");
                        }
                    }
                case DataType.Float4:
                    {
                        switch (entryInfo.Unk_5h)
                        {
                            case 0: return new PsoFloat4B();
                            default: throw new Exception("Unsupported float4 type.");
                        }
                    }
                case DataType.TYPE_09h:
                    {
                        switch (entryInfo.Unk_5h)
                        {
                            case 0: return new PsoType9();
                            default: throw new Exception("Unsupported PsoType9 type.");
                        }
                    }
                case DataType.LONG_20h:
                    {
                        switch (entryInfo.Unk_5h)
                        {
                            case 0: return new PsoType32();
                            default: throw new Exception("Unsupported PsoType32 type.");
                        }
                    }
                case DataType.SHORT_1Eh:
                    {
                        switch (entryInfo.Unk_5h)
                        {
                            case 0: return new PsoXXHalf();
                            default: throw new Exception("Unsupported PsoType30 type.");
                        }
                    }
                case DataType.SHORT_03h:
                    {
                        switch (entryInfo.Unk_5h)
                        {
                            case 0: return new PsoType3();
                            default: throw new Exception("Unsupported PsoType3 type.");
                        }
                    }
                case DataType.SHORT_04h:
                    {
                        switch (entryInfo.Unk_5h)
                        {
                            case 0: return new PsoType4();
                            default: throw new Exception("Unsupported PsoType4 type.");
                        }
                    }
                case DataType.LONG_01h:
                    {
                        switch (entryInfo.Unk_5h)
                        {
                            case 0: return new PsoXXByte();
                            default: throw new Exception("Unsupported PsoType1 type.");
                        }
                    }
                case DataType.TYPE_14h:
                    {
                        switch (entryInfo.Unk_5h)
                        {
                            case 0: return new PsoFloat3();
                            default: throw new Exception("Unsupported PsoType20 type.");
                        }
                    }
                default:
                    throw new Exception("Unsupported type.");
            }
        }

        public static PsoStructureInfo GetStructureInfo(PsoFile meta, int structureKey)
        {
            PsoStructureInfo info = null;
            for (int i = 0; i < meta.DefinitionSection.Count; i++)
                if (meta.DefinitionSection.EntriesIdx[i].NameHash == structureKey)
                    info = (PsoStructureInfo)meta.DefinitionSection.Entries[i];
            return info;
        }

        public static PsoEnumInfo GetEnumInfo(PsoFile meta, int structureKey)
        {
            PsoEnumInfo info = null;
            for (int i = 0; i < meta.DefinitionSection.Count; i++)
                if (meta.DefinitionSection.EntriesIdx[i].NameHash == structureKey)
                    info = (PsoEnumInfo)meta.DefinitionSection.Entries[i];
            return info;
        }

        public static PsoElementIndexInfo GetStructureIndexInfo(PsoFile meta, int structureKey)
        {
            PsoElementIndexInfo info = null;
            for (int i = 0; i < meta.DefinitionSection.Count; i++)
                if (meta.DefinitionSection.EntriesIdx[i].NameHash == structureKey)
                    info = (PsoElementIndexInfo)meta.DefinitionSection.EntriesIdx[i];
            return info;
        }

    }
}
