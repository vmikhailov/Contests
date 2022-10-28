using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace Codewars.Codewars.Passed
{
    public static class KataClass
    {
        private static ModuleBuilder ModuleBuilder { get; set; }

        public static bool DefineClass(string className, Dictionary<string, Type> properties, ref Type actualType)
        {
            var asmName = "RuntimeAssembly";
            if (ModuleBuilder == null)
            {
                var aName = new AssemblyName(asmName);
                var ab = AssemblyBuilder.DefineDynamicAssembly(aName, AssemblyBuilderAccess.Run);
                ModuleBuilder = ab.DefineDynamicModule("Test");
            }

            if (ModuleBuilder.GetType(className) != null)
            {
                return false;
            }

            var tb = ModuleBuilder.DefineType(className, TypeAttributes.Public | TypeAttributes.Class);

            foreach (var kv in properties)
            {
                var fieldName = $"_{kv.Key}";
                var propName = kv.Key;
                var type = kv.Value;

                //build field
                var field = tb.DefineField(fieldName, type, FieldAttributes.Private);

                //define property
                var property = tb.DefineProperty(propName, PropertyAttributes.None, type, null);

                var attr = MethodAttributes.Public;

                //build setter
                var setter = tb.DefineMethod("set_" + propName, attr, null, new Type[] { type });
                var setterILG = setter.GetILGenerator();
                setterILG.Emit(OpCodes.Ldarg_0);
                setterILG.Emit(OpCodes.Ldarg_1);
                setterILG.Emit(OpCodes.Stfld, field);
                setterILG.Emit(OpCodes.Ret);
                property.SetSetMethod(setter);

                //build getter
                var getter = tb.DefineMethod("get_" + propName, attr, type, Type.EmptyTypes);
                var getterILG = getter.GetILGenerator();
                getterILG.Emit(OpCodes.Ldarg_0);
                getterILG.Emit(OpCodes.Ldfld, field);
                getterILG.Emit(OpCodes.Ret);
                property.SetGetMethod(getter);
            }

            actualType = tb.CreateType();

            return true;
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
