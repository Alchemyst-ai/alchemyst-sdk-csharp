using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using AlchemystAISDK.Core;
using AlchemystAISDK.Models.V1.Context.Traces.TraceListResponseProperties;

namespace AlchemystAISDK.Models.V1.Context.Traces;

[JsonConverter(typeof(ModelConverter<TraceListResponse>))]
public sealed record class TraceListResponse : ModelBase, IFromRaw<TraceListResponse>
{
    public List<Trace>? Traces
    {
        get
        {
            if (!this.Properties.TryGetValue("traces", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Trace>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["traces"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Traces ?? [])
        {
            item.Validate();
        }
    }

    public TraceListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TraceListResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TraceListResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
