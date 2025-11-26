using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Alchemystai.Core;

namespace Alchemystai.Models.V1.Org.Context;

[JsonConverter(typeof(ModelConverter<ContextViewResponse, ContextViewResponseFromRaw>))]
public sealed record class ContextViewResponse : ModelBase
{
    public JsonElement? Contexts
    {
        get
        {
            if (!this._rawData.TryGetValue("contexts", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["contexts"] = JsonSerializer.SerializeToElement(
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

    public ContextViewResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContextViewResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ContextViewResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContextViewResponseFromRaw : IFromRaw<ContextViewResponse>
{
    public ContextViewResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ContextViewResponse.FromRawUnchecked(rawData);
}
