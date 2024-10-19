using AdroModdingApi.Systems;
using HarmonyLib;

namespace AdroModdingApi.Patches;

internal static class ModReaderPatch {
    [HarmonyPatch(typeof(DATA_Control), nameof(DATA_Control.readmods))]
    [HarmonyPostfix]
    public static void ReadModsPost(ref ConfigData __result) {
        AdroPluginManager.TryLoadPlugins();

        foreach (var mod in AdroPluginManager.GetLoadedMods()) {
            // TODO: Mod disabling
            __result.modnames += $"[{mod.ModInfo.Name}] ";
        }
    }
}
