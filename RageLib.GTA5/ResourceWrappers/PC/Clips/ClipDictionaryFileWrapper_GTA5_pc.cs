using RageLib.Resources.GTA5;
using RageLib.Resources.GTA5.PC.Clips;
using System.IO;

namespace RageLib.GTA5.ResourceWrappers.PC.Clips
{
    public class ClipDictionaryFileWrapper_GTA5_pc
    {
        private ClipDictionary clipDictionary;

        public void Load(Stream stream)
        {
            var resource = new ResourceFile_GTA5_pc<ClipDictionary>();
            resource.Load(stream);

            clipDictionary = resource.ResourceData;
        }

        public void Load(string fileName)
        {
            var resource = new ResourceFile_GTA5_pc<ClipDictionary>();
            resource.Load(fileName);

            clipDictionary = resource.ResourceData;
        }

        public void Save(Stream stream)
        {
            var resource = new ResourceFile_GTA5_pc<ClipDictionary>();
            resource.ResourceData = clipDictionary;
            resource.Version = 46;
            resource.Save(stream);
        }

        public void Save(string fileName)
        {
            var resource = new ResourceFile_GTA5_pc<ClipDictionary>();
            resource.ResourceData = clipDictionary;
            resource.Version = 46;
            resource.Save(fileName);
        }
    }
}
