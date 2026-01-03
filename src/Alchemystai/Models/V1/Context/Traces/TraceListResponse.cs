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
    public required Pagination Pagination
    {
        get { return JsonModel.GetNotNullClass<Pagination>(this.RawData, "pagination"); }
        init { JsonModel.Set(this._rawData, "pagination", value); }
    }

    public required IReadOnlyList<Trace> Traces
    {
        get { return JsonModel.GetNotNullClass<List<Trace>>(this.RawData, "traces"); }
        init { JsonModel.Set(this._rawData, "traces", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Pagination.Validate();
        foreach (var item in this.Traces)
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

[JsonConverter(typeof(JsonModelConverter<Pagination, PaginationFromRaw>))]
public sealed record class Pagination : JsonModel
{
    public required bool HasNextPage
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "hasNextPage"); }
        init { JsonModel.Set(this._rawData, "hasNextPage", value); }
    }

    public required bool HasPrevPage
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "hasPrevPage"); }
        init { JsonModel.Set(this._rawData, "hasPrevPage", value); }
    }

    public required long Limit
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "limit"); }
        init { JsonModel.Set(this._rawData, "limit", value); }
    }

    public required long Page
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "page"); }
        init { JsonModel.Set(this._rawData, "page", value); }
    }

    public required long Total
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "total"); }
        init { JsonModel.Set(this._rawData, "total", value); }
    }

    public required long TotalPages
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "totalPages"); }
        init { JsonModel.Set(this._rawData, "totalPages", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HasNextPage;
        _ = this.HasPrevPage;
        _ = this.Limit;
        _ = this.Page;
        _ = this.Total;
        _ = this.TotalPages;
    }

    public Pagination() { }

    public Pagination(Pagination pagination)
        : base(pagination) { }

    public Pagination(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Pagination(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PaginationFromRaw.FromRawUnchecked"/>
    public static Pagination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaginationFromRaw : IFromRawJson<Pagination>
{
    /// <inheritdoc/>
    public Pagination FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Pagination.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Trace, TraceFromRaw>))]
public sealed record class Trace : JsonModel
{
    public required string _ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "_id"); }
        init { JsonModel.Set(this._rawData, "_id", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get { return JsonModel.GetNotNullStruct<DateTimeOffset>(this.RawData, "createdAt"); }
        init { JsonModel.Set(this._rawData, "createdAt", value); }
    }

    public required JsonElement Data
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "data"); }
        init { JsonModel.Set(this._rawData, "data", value); }
    }

    public required string OrganizationID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "organizationId"); }
        init { JsonModel.Set(this._rawData, "organizationId", value); }
    }

    public required string Type
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    public required DateTimeOffset UpdatedAt
    {
        get { return JsonModel.GetNotNullStruct<DateTimeOffset>(this.RawData, "updatedAt"); }
        init { JsonModel.Set(this._rawData, "updatedAt", value); }
    }

    public required string UserID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "userId"); }
        init { JsonModel.Set(this._rawData, "userId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this._ID;
        _ = this.CreatedAt;
        _ = this.Data;
        _ = this.OrganizationID;
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
