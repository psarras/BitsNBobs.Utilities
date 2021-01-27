using System;

namespace BitsNBobs.Patterns.Factory
{
    /// <summary>
    /// This is a common package that would be provided to each constructor, before getting the object
    /// </summary>
    public interface IContext
    {
        Type Type { get; }
    }
}