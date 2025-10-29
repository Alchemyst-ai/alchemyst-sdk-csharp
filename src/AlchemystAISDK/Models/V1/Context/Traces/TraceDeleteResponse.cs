using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using AlchemystAISDK.Core;

namespace AlchemystAISDK.Models.V1.Context.Traces;

[JsonConverter(typeof(ModelConverter<TraceDeleteResponse>))]
public sealed record class TraceDeleteResponse : ModelBase, IFromRaw<TraceDeleteResponse>
{
    /// <summary>
    /// The deleted trace data
    /// </summary>
    public JsonElement? Trace
    {
        get
        {
            if (!this.Properties.TryGetValue("trace", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["trace"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Trace;
    }

    public TraceDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TraceDeleteResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TraceDeleteResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
