using System;
using System.Linq;
using UnityEngine;

namespace AdroModdingApi.Models;

/// <summary>
/// Information about an Adrorium mod.
/// </summary>
/// <param name="Name">The name of the mod.</param>
/// <param name="Author">The mod's author.</param>
/// <param name="Version">The mod version.</param>
/// <param name="Date">The date the mod was created. Example: "2024-10-18"</param>
/// <param name="Description">A short description of the mod.</param>
/// <param name="Compatibility">The game versions the mod is compatible with.</param>
/// <param name="Icon">The path to the mod's icon.</param>
public class AdroModInfo(string name, string author, string version, string? date, string? description, string[]? compatibleVersions, string? icon)
{
    /// <summary>
    /// The name of the mod.
    /// </summary>
    public readonly string Name = name;

    /// <summary>
    /// The mod's author.
    /// </summary>
    public readonly string Author = author;

    /// <summary>
    /// The mod version.
    /// </summary>
    public readonly string Version = version;

    /// <summary>
    /// The date the mod was created.
    /// Example: "2024-10-18"
    /// </summary>
    public readonly string? Date = date;

    /// <summary>
    /// A short description of the mod.
    /// </summary>
    public readonly string? Description = description;

    /// <summary>
    /// The game versions the mod is compatible with.
    /// Example: ["0.11.0"]
    /// </summary>
    public readonly string[] CompatibleVersions = compatibleVersions ?? ["all"];

    /// <summary>
    /// The path to the mod's icon.
    /// </summary>
    public readonly string? Icon = icon;

    /// <summary>
    /// Check if the mod is compatible with the current game version.
    /// </summary>
    /// <returns>Whether it is compatible or not.</returns>
    /// <exception cref="NullReferenceException">This was called too early, a <see cref="GAME_Control" /> object could not be found.</exception>
    public bool IsCompatible()
    {
        if (CompatibleVersions.Select((it) => it.ToLower()).Contains("all"))
        {
            return true;
        }

        var manager = GameObject.FindObjectOfType<GAME_Control>();

        if (manager != null)
        {
            var gameVersion = manager.version;

            return CompatibleVersions.Contains(gameVersion) || CompatibleVersions.Contains(gameVersion.Split("v").Last());
        }
        else
        {
            throw new NullReferenceException("Could not find a GAME_Control object! Maybe we were called too early?");
        }
    }
}
