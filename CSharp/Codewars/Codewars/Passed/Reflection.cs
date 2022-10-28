using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Codewars.Codewars.Passed
{
    public static class Reflection
    {
        public static void GetTypes(List<Tuple<object, Type>> objectTypes)
        {
            for (var i = 0; i < objectTypes.Count; i++)
            {
                var o = objectTypes[i].Item1;
                objectTypes[i] = new Tuple<object, Type>(o, o?.GetType());
            }
        }

        public static string[] GetMethodNames(object obj)
        {
            if (obj == null) return new string[0];

            return obj.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static).Select(x => x.Name).ToArray();
        }

        public static string ConcatStringMembers(object obj)
        {
            if (obj == null) return string.Empty;
            var attrs = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.NonPublic;

            var methods = obj.GetType()
                             .GetMethods(attrs)
                             .Where(x => x.ReturnType == typeof(string) && x.GetParameters().Length == 0)
                             .Select(x => (string)x.Invoke(obj, null))
                             .ToList();

            var fields = obj.GetType()
                            .GetFields(attrs)
                            .Where(x => x.FieldType == typeof(string))
                            .Select(x => (string)x.GetValue(obj))
                            .ToList();

            var result = methods.Concat(fields).Where(x => x != null).ToList();

            return string.Join(",", result.OrderByDescending(x => x?.Length ?? 0).ThenBy(x => x));
        }

        public static string InvokeMethod(string typeName)
        {
            if (string.IsNullOrEmpty(typeName)) return null;

            var type = Type.GetType(typeName, false);

            if (type == null) return null;

            var args = type.GetConstructors().First().GetParameters().Length;
            //var obj = Activator.CreateInstance(type, new object[args]);

            var attrs = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.NonPublic;

            var method1 = type.GetMethods(attrs);
            var a = method1[0].GetBaseDefinition() == method1[0];
            var methods = type.GetMethods(attrs)
                              .Where(x => x.GetBaseDefinition() == x)
                              .Select(x => x.Name);

            return string.Join(",", methods);
        }
    
        public static void Activator()
        {
            var type = GetAssemblies()
                       .SelectMany(x => x.GetTypes())
                       .FirstOrDefault(x => x.Name == "ReflectionTests");

            var method = type.GetMethod("Activate", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            method.Invoke(null, null);
        }
    
        public static IEnumerable<Assembly> GetAssemblies()
        {
            var list = new List<string>();
            var stack = new Stack<Assembly>();

            stack.Push(Assembly.GetEntryAssembly());

            do
            {
                var asm = stack.Pop();

                yield return asm;

                foreach (var reference in asm.GetReferencedAssemblies())
                    if (!list.Contains(reference.FullName))
                    {
                        stack.Push(Assembly.Load(reference));
                        list.Add(reference.FullName);
                    }
            } while (stack.Count > 0);
        }
    }
}