using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using AlchemystAISDK.Core;

namespace AlchemystAISDK.Models.V1.Context.ContextAddParamsProperties;

[JsonConverter(typeof(ModelConverter<Document>))]
public sealed record class Document : ModelBase, IFromRaw<Document>
{
    /// <summary>
    /// The content of the document
    /// </summary>
    public string? Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Content;
    }

    public Document() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Document(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Document FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
