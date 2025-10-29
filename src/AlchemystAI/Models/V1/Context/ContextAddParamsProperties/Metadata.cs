using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using AlchemystAI.Core;

namespace AlchemystAI.Models.V1.Context.ContextAddParamsProperties;

/// <summary>
/// Additional metadata for the context
/// </summary>
[JsonConverter(typeof(ModelConverter<Metadata>))]
public sealed record class Metadata : ModelBase, IFromRaw<Metadata>
{
    /// <summary>
    /// Name of the file
    /// </summary>
    public string? FileName
    {
        get
        {
            if (!this.Properties.TryGetValue("fileName", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["fileName"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Size of the file in bytes
    /// </summary>
    public double? FileSize
    {
        get
        {
            if (!this.Properties.TryGetValue("fileSize", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["fileSize"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Type/MIME of the file
    /// </summary>
    public string? FileType
    {
        get
        {
            if (!this.Properties.TryGetValue("fileType", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["fileType"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Array of Group Name to which the file belongs to
    /// </summary>
    public List<string>? GroupName
    {
        get
        {
            if (!this.Properties.TryGetValue("groupName", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["groupName"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Last modified timestamp
    /// </summary>
    public string? LastModified
    {
        get
        {
            if (!this.Properties.TryGetValue("lastModified", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["lastModified"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.FileName;
        _ = this.FileSize;
        _ = this.FileType;
        foreach (var item in this.GroupName ?? [])
        {
            _ = item;
        }
        _ = this.LastModified;
    }

    public Metadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Metadata(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Metadata FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
