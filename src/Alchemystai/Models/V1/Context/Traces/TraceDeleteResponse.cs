using System;
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
    public required TraceDeleteResponseTrace Trace
    {
        get { return JsonModel.GetNotNullClass<TraceDeleteResponseTrace>(this.RawData, "trace"); }
        init { JsonModel.Set(this._rawData, "trace", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Trace.Validate();
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

    [SetsRequiredMembers]
    public TraceDeleteResponse(TraceDeleteResponseTrace trace)
        : this()
    {
        this.Trace = trace;
    }
}

class TraceDeleteResponseFromRaw : IFromRawJson<TraceDeleteResponse>
{
    /// <inheritdoc/>
    public TraceDeleteResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TraceDeleteResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The deleted trace data
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<TraceDeleteResponseTrace, TraceDeleteResponseTraceFromRaw>)
)]
public sealed record class TraceDeleteResponseTrace : JsonModel
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

    public Data? Data
    {
        get { return JsonModel.GetNullableClass<Data>(this.RawData, "data"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "data", value);
        }
    }

    public string? OrganizationID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "organizationId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "organizationId", value);
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
        this.Data?.Validate();
        _ = this.OrganizationID;
        _ = this.Type;
        _ = this.UpdatedAt;
        _ = this.UserID;
    }

    public TraceDeleteResponseTrace() { }

    public TraceDeleteResponseTrace(TraceDeleteResponseTrace traceDeleteResponseTrace)
        : base(traceDeleteResponseTrace) { }

    public TraceDeleteResponseTrace(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TraceDeleteResponseTrace(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TraceDeleteResponseTraceFromRaw.FromRawUnchecked"/>
    public static TraceDeleteResponseTrace FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TraceDeleteResponseTraceFromRaw : IFromRawJson<TraceDeleteResponseTrace>
{
    /// <inheritdoc/>
    public TraceDeleteResponseTrace FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TraceDeleteResponseTrace.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public string? FileName
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "fileName"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "fileName", value);
        }
    }

    public string? Query
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "query"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "query", value);
        }
    }

    public string? Source
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "source"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "source", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileName;
        _ = this.Query;
        _ = this.Source;
    }

    public Data() { }

    public Data(Data data)
        : base(data) { }

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}
