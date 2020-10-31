using RageLib.Resources.GTA5.PC.Bounds;
using RageLib.ResourceWrappers.Bounds;

namespace RageLib.GTA5.ResourceWrappers.PC.Bounds
{
    public class BoundWrapper_GTA5_pc : IBound
    {
        private Bound bound;

        public BoundWrapper_GTA5_pc(Bound bound)
        {
            this.bound = bound;
        }
    }
}