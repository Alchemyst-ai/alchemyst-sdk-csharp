using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using AlchemystAISDK.Core;

namespace AlchemystAISDK.Models.V1.Context.View;

[JsonConverter(typeof(ModelConverter<ViewRetrieveResponse>))]
public sealed record class ViewRetrieveResponse : ModelBase, IFromRaw<ViewRetrieveResponse>
{
    /// <summary>
    /// List of context items
    /// </summary>
    public List<JsonElement>? Context
    {
        get
        {
            if (!this.Properties.TryGetValue("context", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["context"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Context ?? [])
        {
            _ = item;
        }
    }

    public ViewRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewRetrieveResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ViewRetrieveResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
