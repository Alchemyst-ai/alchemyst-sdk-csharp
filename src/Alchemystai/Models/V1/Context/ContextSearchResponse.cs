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
    public IReadOnlyList<ContextModel>? Contexts
    {
        get { return ModelBase.GetNullableClass<List<ContextModel>>(this.RawData, "contexts"); }
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

[JsonConverter(typeof(ModelConverter<ContextModel, ContextModelFromRaw>))]
public sealed record class ContextModel : ModelBase
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

    public ContextModel() { }

    public ContextModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContextModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ContextModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContextModelFromRaw : IFromRaw<ContextModel>
{
    public ContextModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ContextModel.FromRawUnchecked(rawData);
}
