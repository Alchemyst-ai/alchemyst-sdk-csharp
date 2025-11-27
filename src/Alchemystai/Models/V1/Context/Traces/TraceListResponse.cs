using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Alchemystai.Core;

namespace Alchemystai.Models.V1.Context.Traces;

[JsonConverter(typeof(ModelConverter<TraceListResponse, TraceListResponseFromRaw>))]
public sealed record class TraceListResponse : ModelBase
{
    public IReadOnlyList<Trace>? Traces
    {
        get
        {
            if (!this._rawData.TryGetValue("traces", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Trace>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["traces"] = JsonSerializer.SerializeToElement(
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

    public static TraceListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TraceListResponseFromRaw : IFromRaw<TraceListResponse>
{
    public TraceListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TraceListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Trace, TraceFromRaw>))]
public sealed record class Trace : ModelBase
{
    public string? _ID
    {
        get
        {
            if (!this._rawData.TryGetValue("_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("createdAt", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["createdAt"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement? Data
    {
        get
        {
            if (!this._rawData.TryGetValue("data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("updatedAt", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["updatedAt"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? UserID
    {
        get
        {
            if (!this._rawData.TryGetValue("userId", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["userId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public static Trace FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TraceFromRaw : IFromRaw<Trace>
{
    public Trace FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Trace.FromRawUnchecked(rawData);
}
