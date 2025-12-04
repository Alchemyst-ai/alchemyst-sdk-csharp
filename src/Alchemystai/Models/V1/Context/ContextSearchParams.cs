using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Alchemystai.Core;
using Alchemystai.Exceptions;

namespace Alchemystai.Models.V1.Context;

/// <summary>
/// This endpoint sends a search request to the context processor to retrieve relevant
/// context data based on the provided query.
/// </summary>
public sealed record class ContextSearchParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Minimum similarity threshold
    /// </summary>
    public required double MinimumSimilarityThreshold
    {
        get
        {
            return ModelBase.GetNotNullStruct<double>(
                this.RawBodyData,
                "minimum_similarity_threshold"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "minimum_similarity_threshold", value); }
    }

    /// <summary>
    /// The search query used to search for context data
    /// </summary>
    public required string Query
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "query"); }
        init { ModelBase.Set(this._rawBodyData, "query", value); }
    }

    /// <summary>
    /// Maximum similarity threshold (must be >= minimum_similarity_threshold)
    /// </summary>
    public required double SimilarityThreshold
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawBodyData, "similarity_threshold"); }
        init { ModelBase.Set(this._rawBodyData, "similarity_threshold", value); }
    }

    /// <summary>
    /// Controls whether metadata is included in the response: - metadata=true → metadata
    /// will be included in each context item in the response. - metadata=false (or
    /// omitted) → metadata will be excluded from the response for better performance.
    /// </summary>
    public ApiEnum<string, ContextSearchParamsMetadata>? Metadata
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, ContextSearchParamsMetadata>>(
                this.RawQueryData,
                "metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "metadata", value);
        }
    }

    /// <summary>
    /// Controls the search mode: - mode=fast → prioritizes speed over completeness.
    /// - mode=standard → performs a comprehensive search (default if omitted).
    /// </summary>
    public ApiEnum<string, Mode>? Mode
    {
        get { return ModelBase.GetNullableClass<ApiEnum<string, Mode>>(this.RawQueryData, "mode"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "mode", value);
        }
    }

    /// <summary>
    /// Additional metadata for the search
    /// </summary>
    public JsonElement? MetadataValue
    {
        get { return ModelBase.GetNullableStruct<JsonElement>(this.RawBodyData, "metadata"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "metadata", value);
        }
    }

    /// <summary>
    /// Search scope
    /// </summary>
    public ApiEnum<string, ContextSearchParamsScope>? Scope
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, ContextSearchParamsScope>>(
                this.RawBodyData,
                "scope"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "scope", value);
        }
    }

    /// <summary>
    /// The ID of the user making the request
    /// </summary>
    [Obsolete("deprecated")]
    public string? UserID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "user_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "user_id", value);
        }
    }

    public ContextSearchParams() { }

    public ContextSearchParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContextSearchParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static ContextSearchParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/context/search")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

/// <summary>
/// Controls whether metadata is included in the response: - metadata=true → metadata
/// will be included in each context item in the response. - metadata=false (or omitted)
/// → metadata will be excluded from the response for better performance.
/// </summary>
[JsonConverter(typeof(ContextSearchParamsMetadataConverter))]
public enum ContextSearchParamsMetadata
{
    True,
    False,
}

sealed class ContextSearchParamsMetadataConverter : JsonConverter<ContextSearchParamsMetadata>
{
    public override ContextSearchParamsMetadata Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "true" => ContextSearchParamsMetadata.True,
            "false" => ContextSearchParamsMetadata.False,
            _ => (ContextSearchParamsMetadata)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContextSearchParamsMetadata value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContextSearchParamsMetadata.True => "true",
                ContextSearchParamsMetadata.False => "false",
                _ => throw new AlchemystAIInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Controls the search mode: - mode=fast → prioritizes speed over completeness. -
/// mode=standard → performs a comprehensive search (default if omitted).
/// </summary>
[JsonConverter(typeof(ModeConverter))]
public enum Mode
{
    Fast,
    Standard,
}

sealed class ModeConverter : JsonConverter<Mode>
{
    public override Mode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fast" => Mode.Fast,
            "standard" => Mode.Standard,
            _ => (Mode)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Mode value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Mode.Fast => "fast",
                Mode.Standard => "standard",
                _ => throw new AlchemystAIInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Search scope
/// </summary>
[JsonConverter(typeof(ContextSearchParamsScopeConverter))]
public enum ContextSearchParamsScope
{
    Internal,
    External,
}

sealed class ContextSearchParamsScopeConverter : JsonConverter<ContextSearchParamsScope>
{
    public override ContextSearchParamsScope Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "internal" => ContextSearchParamsScope.Internal,
            "external" => ContextSearchParamsScope.External,
            _ => (ContextSearchParamsScope)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContextSearchParamsScope value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContextSearchParamsScope.Internal => "internal",
                ContextSearchParamsScope.External => "external",
                _ => throw new AlchemystAIInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
