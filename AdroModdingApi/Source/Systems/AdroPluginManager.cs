using System;
using System.Collections.Generic;
using System.Linq;
using AdroModdingApi.Attributes;
using AdroModdingApi.Util;

namespace AdroModdingApi.Systems;

public static class AdroPluginManager
{
    /// <summary>
    /// A map of assemblies to types with the <see cref="AdroMod"/> attribute.
    /// This should be nullable as a built-in check if the runtime has been scanned yet.
    /// </summary>
    private static Dictionary<string, List<Type>>? CandidateTypes;

    /// <summary>
    /// A map of assemblies to a list of loaded mods.
    /// </summary>
    private static readonly Dictionary<string, List<AdroPlugin>> LoadedMods = [];

    public static List<Type> GetCandidateTypes()
    {
        CandidateTypes ??= ReflectionUtil.FindClassesWithAttribute<AdroMod>();

        return CandidateTypes.Values.SelectMany((v) => v).ToList();
    }

    public static void TryLoadPlugins()
    {
        foreach (var type in GetCandidateTypes())
        {
            var plugin = (AdroPlugin)Activator.CreateInstance(type);

            LoadedMods.GetOrCreate(type.Assembly.FullName, () => []).Add(plugin);

            // TODO: Actually do something with the plugin
            // Right now this is just a fancy BepInEx built for this game
        }
    }

    public static List<AdroPlugin> GetLoadedMods() {
        return LoadedMods.Values.SelectMany((v) => v).ToList();
    }
}
