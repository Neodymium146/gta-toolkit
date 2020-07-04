using RageLib.Resources.GTA5;
using RageLib.Resources.GTA5.PC.Bounds;
using RageLib.ResourceWrappers.Bounds;
using System.IO;

namespace RageLib.ResourceWrappers.GTA5.PC.Bounds
{
    public class BoundFileWrapper_GTA5_pc : IBoundFile
    {
        private Bound bound;

        public IBound Bound
        {
            get
            {
                return new BoundWrapper_GTA5_pc(bound);
            }
        }

        public void Load(Stream stream)
        {
            var resource = new ResourceFile_GTA5_pc<Bound>();
            resource.Load(stream);

            bound = resource.ResourceData;
        }

        /// <summary>
        /// Loads the bound from a file.
        /// </summary>
        public void Load(string fileName)
        {
            var resource = new ResourceFile_GTA5_pc<Bound>();
            resource.Load(fileName);

            bound = resource.ResourceData;
        }

        public void Save(Stream stream)
        {
            var resource = new ResourceFile_GTA5_pc<Bound>();
            resource.ResourceData = bound;
            resource.Version = 43;
            resource.Save(stream);
        }

        /// <summary>
        /// Saves the bound to a file.
        /// </summary>
        public void Save(string fileName)
        {
            var resource = new ResourceFile_GTA5_pc<Bound>();
            resource.ResourceData = bound;
            resource.Version = 43;
            resource.Save(fileName);
        }
    }
}
