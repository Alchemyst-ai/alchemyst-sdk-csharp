using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Alchemystai.Core;

namespace Alchemystai.Models.V1.Context.Traces;

[JsonConverter(typeof(JsonModelConverter<TraceListResponse, TraceListResponseFromRaw>))]
public sealed record class TraceListResponse : JsonModel
{
    public IReadOnlyList<Trace>? Traces
    {
        get { return JsonModel.GetNullableClass<List<Trace>>(this.RawData, "traces"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "traces", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Traces ?? [])
        {
            item.Validate();
        }
    }

    public TraceListResponse() { }

    public TraceListResponse(TraceListResponse traceListResponse)
        : base(traceListResponse) { }

    public TraceListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TraceListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TraceListResponseFromRaw.FromRawUnchecked"/>
    public static TraceListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TraceListResponseFromRaw : IFromRawJson<TraceListResponse>
{
    /// <inheritdoc/>
    public TraceListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TraceListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Trace, TraceFromRaw>))]
public sealed record class Trace : JsonModel
{
    public string? _ID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "_id", value);
        }
    }

    public DateTimeOffset? CreatedAt
    {
        get { return JsonModel.GetNullableStruct<DateTimeOffset>(this.RawData, "createdAt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "createdAt", value);
        }
    }

    public JsonElement? Data
    {
        get { return JsonModel.GetNullableStruct<JsonElement>(this.RawData, "data"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "data", value);
        }
    }

    public string? Type
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "type"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "type", value);
        }
    }

    public DateTimeOffset? UpdatedAt
    {
        get { return JsonModel.GetNullableStruct<DateTimeOffset>(this.RawData, "updatedAt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "updatedAt", value);
        }
    }

    public string? UserID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "userId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "userId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this._ID;
        _ = this.CreatedAt;
        _ = this.Data;
        _ = this.Type;
        _ = this.UpdatedAt;
        _ = this.UserID;
    }

    public Trace() { }

    public Trace(Trace trace)
        : base(trace) { }

    public Trace(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Trace(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TraceFromRaw.FromRawUnchecked"/>
    public static Trace FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TraceFromRaw : IFromRawJson<Trace>
{
    /// <inheritdoc/>
    public Trace FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Trace.FromRawUnchecked(rawData);
}
