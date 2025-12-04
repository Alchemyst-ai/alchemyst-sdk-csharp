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
        get { return ModelBase.GetNullableStruct<JsonElement>(this.RawData, "contexts"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "contexts", value);
        }
    }

    /// <inheritdoc/>
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

    /// <inheritdoc cref="ContextViewResponseFromRaw.FromRawUnchecked"/>
    public static ContextViewResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContextViewResponseFromRaw : IFromRaw<ContextViewResponse>
{
    /// <inheritdoc/>
    public ContextViewResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ContextViewResponse.FromRawUnchecked(rawData);
}
