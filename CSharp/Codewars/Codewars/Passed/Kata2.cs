using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Reflection.Emit;

namespace Codewars.Codewars.Passed
{
    public static class Kata2
    {
        private const string AssemblyNameString = "RuntimeAssembly";
        private static readonly AssemblyName AssemblyName = new AssemblyName(AssemblyNameString);

        private static readonly AssemblyBuilder AssemblyBuilder =
            AssemblyBuilder.DefineDynamicAssembly(AssemblyName, AssemblyBuilderAccess.RunAndCollect);

        private static readonly ModuleBuilder ModuleBuilder = AssemblyBuilder.DefineDynamicModule(AssemblyNameString);

        public static bool DefineClass(string className, Dictionary<string, Type> properties, ref Type actualType)
        {
            if (ModuleBuilder.GetType(className) != null) return false;
            var typeBuilder = ModuleBuilder.DefineType(className, TypeAttributes.Public | TypeAttributes.Class, null);

            foreach (var keyValuePair in properties)
            {
                CreateProperty(typeBuilder, keyValuePair.Key, keyValuePair.Value);
            }

            actualType = typeBuilder.CreateType();

            return true;
        }

        private static void CreateProperty(TypeBuilder typeBuilder, string propertyName, Type propertyType)
        {
            var backingFieldBuilder =
                typeBuilder.DefineField($"_{propertyName}", propertyType, FieldAttributes.Private);

            var propertyBuilder =
                typeBuilder.DefineProperty(propertyName, PropertyAttributes.None, propertyType, null);

            propertyBuilder.SetGetMethod(
                GetGetterBuilder(
                    typeBuilder,
                    propertyName,
                    propertyType,
                    backingFieldBuilder));
            propertyBuilder.SetSetMethod(
                GetSetterBuilder(
                    typeBuilder,
                    propertyName,
                    propertyType,
                    backingFieldBuilder));
        }

        private static MethodBuilder GetGetterBuilder(
            TypeBuilder typeBuilder,
            string propertyName,
            Type propertyType,
            FieldInfo backingFieldBuilder)
        {
            var methodName = $"get{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(propertyName.ToLower())}";

            var getterBuilder =
                typeBuilder.DefineMethod(methodName, MethodAttributes.Public, propertyType, null);
            var getterIl = getterBuilder.GetILGenerator();

            getterIl.Emit(OpCodes.Ldarg_0);
            getterIl.Emit(OpCodes.Ldfld, backingFieldBuilder);
            getterIl.Emit(OpCodes.Ret);

            return getterBuilder;
        }

        private static MethodBuilder GetSetterBuilder(
            TypeBuilder typeBuilder,
            string propertyName,
            Type propertyType,
            FieldInfo backingFieldBuilder)
        {
            var methodName = $"set{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(propertyName.ToLower())}";

            var setterBuilder =
                typeBuilder.DefineMethod(methodName, MethodAttributes.Public, null, new[] { propertyType });

            var setterIl = setterBuilder.GetILGenerator();

            setterIl.Emit(OpCodes.Ldarg_0);
            setterIl.Emit(OpCodes.Ldarg_1);
            setterIl.Emit(OpCodes.Stfld, backingFieldBuilder);
            setterIl.Emit(OpCodes.Nop);
            setterIl.Emit(OpCodes.Ret);

            return setterBuilder;
        }
    }
}