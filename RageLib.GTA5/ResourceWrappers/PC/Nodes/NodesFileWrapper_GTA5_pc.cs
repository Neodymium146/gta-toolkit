using RageLib.Resources.GTA5;
using RageLib.Resources.GTA5.PC.Nodes;
using System.IO;

namespace RageLib.GTA5.ResourceWrappers.PC.Nodes
{
    public class NodesFileWrapper_GTA5_pc
    {
        private NodesFile nodes;

        public void Load(Stream stream)
        {
            var resource = new ResourceFile_GTA5_pc<NodesFile>();
            resource.Load(stream);

            nodes = resource.ResourceData;
        }

        public void Load(string fileName)
        {
            var resource = new ResourceFile_GTA5_pc<NodesFile>();
            resource.Load(fileName);

            nodes = resource.ResourceData;
        }

        public void Save(Stream stream)
        {
            var resource = new ResourceFile_GTA5_pc<NodesFile>();
            resource.ResourceData = nodes;
            resource.Version = 1;
            resource.Save(stream);
        }

        public void Save(string fileName)
        {
            var resource = new ResourceFile_GTA5_pc<NodesFile>();
            resource.ResourceData = nodes;
            resource.Version = 1;
            resource.Save(fileName);
        }
    }
}
