using System;
using AdroModdingApi.Attributes;
using AdroModdingApi.Models;
using BepInEx;

namespace AdroModdingApi;

/// <summary>
/// The base plugin type that is used by the BepInEx plugin loader and our plugin system.
/// </summary>
#pragma warning disable BepInEx001 // Class inheriting from BaseUnityPlugin missing BepInPlugin attribute
public class AdroPlugin : BaseUnityPlugin
#pragma warning restore BepInEx001 // Class inheriting from BaseUnityPlugin missing BepInPlugin attribute
{
    /// <summary>
    /// Information about the mod.
    /// </summary>
    public AdroModInfo ModInfo { get; }

    /// <summary>
    /// Create a new instance of a plugin and all of its tied in objects.
    /// </summary>
    /// <exception cref="InvalidOperationException">BepInPlugin or AdroPlugin attribute is missing.</exception>
    protected AdroPlugin() : base()
    {
        object[] attrs = GetType().GetCustomAttributes(typeof(AdroMod), inherit: false);

        if (attrs.Length == 0)
        {
            throw new InvalidOperationException("Can't create an instance of " + GetType().FullName + " because it inherits from AdroMod and the AdroPlugin attribute is missing!");
        }

        ModInfo = ((AdroMod)attrs[0]).AsModInfo();
    }
}
