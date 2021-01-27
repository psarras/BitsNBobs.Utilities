using System;

namespace BitsNBobs.Patterns.Factory
{
    /// <summary>
    /// Each object constructor would have to implement this
    /// </summary>
    /// <typeparam name="O">This is the type for the object you want to generate</typeparam>
    public interface IObject<O>
    {
        /// <summary>
        /// Type hint to be used when selecting the correct constructor
        /// </summary>
        Type Type { get; }
        
        /// <summary>
        /// The Constructor for Producing O
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        O CreateObject(IContext context);
    }
}