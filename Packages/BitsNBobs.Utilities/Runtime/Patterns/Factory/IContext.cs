using System;

namespace BitsNBobs.Patterns.Factory
{
    public interface IContext
    {
        Type Type { get; }
    }
}