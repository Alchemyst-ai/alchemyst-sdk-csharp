using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using AlchemystAISDK.Core;

namespace AlchemystAISDK.Models.V1.Org.Context;

[JsonConverter(typeof(ModelConverter<ContextViewResponse>))]
public sealed record class ContextViewResponse : ModelBase, IFromRaw<ContextViewResponse>
{
    public JsonElement? Contexts
    {
        get
        {
            if (!this.Properties.TryGetValue("contexts", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(element, ModelBase.SerializerOptions);
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
        _ = this.Contexts;
    }

    public ContextViewResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContextViewResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ContextViewResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
