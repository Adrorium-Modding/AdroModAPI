using System;
using System.Collections.Generic;
using System.Reflection;

namespace AdroModdingApi.Util;

public static class ReflectionUtil {
    public static Dictionary<string, List<Type>> FindClassesWithAttribute<T>() where T: Attribute {
        var classes = new Dictionary<string, List<Type>>();

        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
            foreach (var type in assembly.GetTypes()) {
                if (type.GetCustomAttribute<T>(false) == null) continue;

                classes.GetOrCreate(assembly.FullName, () => []).Add(type);
            }
        }

        return classes;
    }
}
