using AdroModdingApi.Attributes;
using BepInEx;
using BepInEx.Logging;

namespace ExampleMod;

[AdroMod(MyPluginInfo.PLUGIN_NAME, "Adrorium Modding Contributors", MyPluginInfo.PLUGIN_VERSION, "2024-10-18", "A nice API for modding Adrorium!", ["all"])]
[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;
        
    private void Awake()
    {
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
    }
}
