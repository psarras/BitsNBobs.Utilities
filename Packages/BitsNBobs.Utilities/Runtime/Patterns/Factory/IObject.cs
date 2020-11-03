using System;

namespace BitsNBobs.Patterns.Factory
{
    public interface IObject<O>
    {
        Type Type { get; }
        O CreateObject(IContext context);
    }
}