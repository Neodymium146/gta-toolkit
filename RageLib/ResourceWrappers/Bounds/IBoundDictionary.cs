namespace RageLib.ResourceWrappers.Bounds
{
    public interface IBoundDictionary
    {
        IBoundList Bounds { get; set; }

        uint GetHash(int index);
    }
}
