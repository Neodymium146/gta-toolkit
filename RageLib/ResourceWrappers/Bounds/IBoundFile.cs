namespace RageLib.ResourceWrappers.Bounds
{
    /// <summary>
    /// Represents a bound file.
    /// </summary>
    public interface IBoundFile : IResourceFile
    {
        /// <summary>
        /// Gets the bound.
        /// </summary>
        IBound Bound { get; }
    }
}