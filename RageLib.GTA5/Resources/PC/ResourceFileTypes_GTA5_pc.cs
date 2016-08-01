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

using System.Collections.Generic;

namespace RageLib.GTA5.Resources.PC
{
    public class ResourceFileType
    {
        public string Extension { get; private set; }
        public int Version { get; private set; }

        public ResourceFileType(string extension, int version)
        {
            this.Extension = extension;
            this.Version = version;
        }
    }

    public class ResourceFileTypes_GTA5_pc
    {
        public static readonly ResourceFileType Bound = new ResourceFileType("ybn", 43);
        public static readonly ResourceFileType BoundDictionary = new ResourceFileType("ybd", 43);
        public static readonly ResourceFileType ClipDictionary = new ResourceFileType("ycd", 46);
        public static readonly ResourceFileType ClothDictionary = new ResourceFileType("yld", 8);
        public static readonly ResourceFileType Drawable = new ResourceFileType("ydr", 165);
        public static readonly ResourceFileType DrawableDictionary = new ResourceFileType("ydd", 165);
        public static readonly ResourceFileType ExpressionDictionary = new ResourceFileType("yed", 25);
        public static readonly ResourceFileType FilterDictionary = new ResourceFileType("yfd", 4);
        public static readonly ResourceFileType Fragment = new ResourceFileType("yft", 162);
        public static readonly ResourceFileType Maps = new ResourceFileType("ymap", 2);
        public static readonly ResourceFileType Meta = new ResourceFileType("ymt", 2);
        public static readonly ResourceFileType Navigations = new ResourceFileType("ynv", 2);
        public static readonly ResourceFileType Nodes = new ResourceFileType("ynd", 1);
        public static readonly ResourceFileType Particles = new ResourceFileType("ypt", 68);
        public static readonly ResourceFileType Script = new ResourceFileType("ysc", 10);
        public static readonly ResourceFileType TextureDictionary = new ResourceFileType("ytd", 13);
        public static readonly ResourceFileType Types = new ResourceFileType("ytyp", 2);
        public static readonly ResourceFileType VehicleRecords = new ResourceFileType("yvr", 1);
        public static readonly ResourceFileType WaypointRecords = new ResourceFileType("ywr", 1);

        public static readonly List<ResourceFileType> AllTypes = new List<ResourceFileType>
        {
            Bound,
            BoundDictionary,
            ClipDictionary,
            ClothDictionary,
            Drawable,
            DrawableDictionary,
            ExpressionDictionary,
            FilterDictionary,
            Fragment,
            Maps,
            Meta,
            Navigations,
            Nodes,
            Particles,
            Script,
            TextureDictionary,
            Types,
            VehicleRecords,
            WaypointRecords
        };
    }
}
