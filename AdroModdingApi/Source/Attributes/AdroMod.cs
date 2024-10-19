using System;
using AdroModdingApi.Models;
using JetBrains.Annotations;

namespace AdroModdingApi.Attributes;

[MeansImplicitUse]
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class AdroMod(string name, string author, string version, string? date = null, string? description = null, string[]? compatibility = null, string? icon = null) : Attribute
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
    /// Example: ["0.11.0"]
    /// </summary>
    public readonly string[]? Compatibility = compatibility;

    /// <summary>
    /// The path to mod's icon.
    /// </summary>
    public readonly string? Icon = icon;

    // These are replaced with registries!
    // public readonly string[] Ships;
    // public readonly string[] Meshes;
    // public readonly string[] Materials;
    // public readonly string[] Audio;

    /// <summary>
    /// Convert this into a <see cref="AdroModInfo" />.
    /// </summary>
    /// <returns>The mod's info.</returns>
    public AdroModInfo AsModInfo()
    {
        return new(Name, Author, Version, Date, Description, Compatibility, Icon);
    }
}
