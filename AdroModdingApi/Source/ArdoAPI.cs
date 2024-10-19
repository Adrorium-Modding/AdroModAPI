using System;
using AdroModdingApi.Plugin;
using BepInEx.Logging;

namespace AdroModdingApi;

public static class ArdoAPI {
    public static bool Initialized;
    public static ManualLogSource Logger;

    public static void Init() {
        if (Initialized) {
            throw new InvalidOperationException("ArdoAPI has already been initialized!");
        }

        if (AdroApiPlugin.Logger == null) {
            throw new NullReferenceException("ArdoApiPlugin hasn't been initialized yet!");
        }

        Initialized = true;
        Logger = AdroApiPlugin.Logger;
    }
}
