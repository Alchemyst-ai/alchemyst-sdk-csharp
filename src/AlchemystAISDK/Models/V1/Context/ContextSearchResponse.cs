using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using AlchemystAISDK.Core;
using AlchemystAISDK.Models.V1.Context.ContextSearchResponseProperties;

namespace AlchemystAISDK.Models.V1.Context;

[JsonConverter(typeof(ModelConverter<ContextSearchResponse>))]
public sealed record class ContextSearchResponse : ModelBase, IFromRaw<ContextSearchResponse>
{
    public List<ContextModel>? Contexts
    {
        get
        {
            if (!this.Properties.TryGetValue("contexts", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ContextModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["contexts"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Contexts ?? [])
        {
            item.Validate();
        }
    }

    public ContextSearchResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContextSearchResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ContextSearchResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
