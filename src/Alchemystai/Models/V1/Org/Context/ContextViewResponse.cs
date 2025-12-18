using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Alchemystai.Core;

namespace Alchemystai.Models.V1.Org.Context;

[JsonConverter(typeof(JsonModelConverter<ContextViewResponse, ContextViewResponseFromRaw>))]
public sealed record class ContextViewResponse : JsonModel
{
    public JsonElement? Contexts
    {
        get { return JsonModel.GetNullableStruct<JsonElement>(this.RawData, "contexts"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "contexts", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Contexts;
    }

    public ContextViewResponse() { }

    public ContextViewResponse(ContextViewResponse contextViewResponse)
        : base(contextViewResponse) { }

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

class ContextViewResponseFromRaw : IFromRawJson<ContextViewResponse>
{
    /// <inheritdoc/>
    public ContextViewResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ContextViewResponse.FromRawUnchecked(rawData);
}
