using RageLib.Resources.Common;
using RageLib.Resources.GTA5;
using RageLib.Resources.GTA5.PC.Filters;
using System.IO;

namespace RageLib.GTA5.ResourceWrappers.PC.Filters
{
    public class FilterDictionaryFileWrapper_GTA5_pc
    {
        private PgDictionary64<Filter> filterDictionary;

        public void Load(Stream stream)
        {
            var resource = new ResourceFile_GTA5_pc<PgDictionary64<Filter>>();
            resource.Load(stream);

            filterDictionary = resource.ResourceData;
        }

        public void Load(string fileName)
        {
            var resource = new ResourceFile_GTA5_pc<PgDictionary64<Filter>>();
            resource.Load(fileName);

            filterDictionary = resource.ResourceData;
        }

        public void Save(Stream stream)
        {
            var resource = new ResourceFile_GTA5_pc<PgDictionary64<Filter>>();
            resource.ResourceData = filterDictionary;
            resource.Version = 4;
            resource.Save(stream);
        }

        public void Save(string fileName)
        {
            var resource = new ResourceFile_GTA5_pc<PgDictionary64<Filter>>();
            resource.ResourceData = filterDictionary;
            resource.Version = 4;
            resource.Save(fileName);
        }
    }
}
