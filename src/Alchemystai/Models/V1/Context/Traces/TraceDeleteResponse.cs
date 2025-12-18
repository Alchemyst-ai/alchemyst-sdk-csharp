using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Alchemystai.Core;

namespace Alchemystai.Models.V1.Context.Traces;

[JsonConverter(typeof(JsonModelConverter<TraceDeleteResponse, TraceDeleteResponseFromRaw>))]
public sealed record class TraceDeleteResponse : JsonModel
{
    /// <summary>
    /// The deleted trace data
    /// </summary>
    public JsonElement? Trace
    {
        get { return JsonModel.GetNullableStruct<JsonElement>(this.RawData, "trace"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "trace", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Trace;
    }

    public TraceDeleteResponse() { }

    public TraceDeleteResponse(TraceDeleteResponse traceDeleteResponse)
        : base(traceDeleteResponse) { }

    public TraceDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TraceDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TraceDeleteResponseFromRaw.FromRawUnchecked"/>
    public static TraceDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TraceDeleteResponseFromRaw : IFromRawJson<TraceDeleteResponse>
{
    /// <inheritdoc/>
    public TraceDeleteResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TraceDeleteResponse.FromRawUnchecked(rawData);
}
