using BepInEx;
using BepInEx.Logging;

namespace AdroModdingApi.Plugin;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class AdroApiPlugin : AdroPlugin
{
    internal static new ManualLogSource? Logger;

    public void Awake()
    {
        Logger = base.Logger;
        Logger.LogInfo($"Starting {MyPluginInfo.PLUGIN_GUID}...");
        ArdoAPI.Init();
        Logger.LogInfo($"Finished starting {MyPluginInfo.PLUGIN_GUID}!");
    }
}
