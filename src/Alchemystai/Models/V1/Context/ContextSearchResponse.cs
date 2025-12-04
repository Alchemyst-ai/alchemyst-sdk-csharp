using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Alchemystai.Core;

namespace Alchemystai.Models.V1.Context;

[JsonConverter(typeof(ModelConverter<ContextSearchResponse, ContextSearchResponseFromRaw>))]
public sealed record class ContextSearchResponse : ModelBase
{
    public IReadOnlyList<ContextSearchResponseContext>? Contexts
    {
        get
        {
            return ModelBase.GetNullableClass<List<ContextSearchResponseContext>>(
                this.RawData,
                "contexts"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "contexts", value);
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Contexts ?? [])
        {
            item.Validate();
        }
    }

    public ContextSearchResponse() { }

    public ContextSearchResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContextSearchResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ContextSearchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContextSearchResponseFromRaw : IFromRaw<ContextSearchResponse>
{
    public ContextSearchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContextSearchResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<ContextSearchResponseContext, ContextSearchResponseContextFromRaw>)
)]
public sealed record class ContextSearchResponseContext : ModelBase
{
    public string? Content
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "content"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "content", value);
        }
    }

    public DateTimeOffset? CreatedAt
    {
        get { return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawData, "createdAt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "createdAt", value);
        }
    }

    /// <summary>
    /// Only included when query parameter metadata=true
    /// </summary>
    public JsonElement? Metadata
    {
        get { return ModelBase.GetNullableStruct<JsonElement>(this.RawData, "metadata"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "metadata", value);
        }
    }

    public double? Score
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "score"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "score", value);
        }
    }

    public DateTimeOffset? UpdatedAt
    {
        get { return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawData, "updatedAt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "updatedAt", value);
        }
    }

    public override void Validate()
    {
        _ = this.Content;
        _ = this.CreatedAt;
        _ = this.Metadata;
        _ = this.Score;
        _ = this.UpdatedAt;
    }

    public ContextSearchResponseContext() { }

    public ContextSearchResponseContext(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContextSearchResponseContext(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ContextSearchResponseContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContextSearchResponseContextFromRaw : IFromRaw<ContextSearchResponseContext>
{
    public ContextSearchResponseContext FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContextSearchResponseContext.FromRawUnchecked(rawData);
}
