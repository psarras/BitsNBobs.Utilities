using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BitsNBobs.Patterns.Factory
{
    public abstract class ObjectFactory<O>
    {
        private static Dictionary<Type, IObject<O>> Constructors { get; set; }

        public static bool CreateInputs(IContext context, out O output)
        {
            output = default;
            if (!CreateInputs(context, out IObject<O> outObj))
                return false;

            output = outObj.CreateObject(context);
            return true;
        }

        private static bool CreateInputs(IContext context, out IObject<O> guiConstructor)
        {
            guiConstructor = null;
            if (Constructors == null)
                InstantiateConstructors();

            var type = context.Type;
            var matchingType = Constructors.Keys.Where(x => x.IsAssignableFrom(type)).FirstOrDefault();
            if (matchingType == null) return false;
            guiConstructor = Constructors[matchingType];
            return true;
        }

        private static void InstantiateConstructors()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var baseType = typeof(IObject<O>);
            var allTypes = assemblies.Select(x => x.GetTypes()).SelectMany(x => x);
            var types = allTypes.Where(x =>
                x != baseType &&
                baseType.IsAssignableFrom(x) &&
                !x.IsAbstract
            ).ToList();
            Constructors = new Dictionary<Type, IObject<O>>();
            foreach (var type in types)
            {
                var iObject = Activator.CreateInstance(type) as IObject<O>;
                Constructors.Add(iObject.Type, iObject);
            }
        }
    }
}