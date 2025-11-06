using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Alchemystai.Core;
using Alchemystai.Exceptions;
using System = System;

namespace Alchemystai.Models.V1.Context;

/// <summary>
/// This endpoint sends a search request to the context processor to retrieve relevant
/// context data based on the provided query.
/// </summary>
public sealed record class ContextSearchParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    /// <summary>
    /// Minimum similarity threshold
    /// </summary>
    public required double MinimumSimilarityThreshold
    {
        get
        {
            if (
                !this._bodyProperties.TryGetValue(
                    "minimum_similarity_threshold",
                    out JsonElement element
                )
            )
                throw new AlchemystAIInvalidDataException(
                    "'minimum_similarity_threshold' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "minimum_similarity_threshold",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["minimum_similarity_threshold"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// The search query used to search for context data
    /// </summary>
    public required string Query
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("query", out JsonElement element))
                throw new AlchemystAIInvalidDataException(
                    "'query' cannot be null",
                    new System::ArgumentOutOfRangeException("query", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AlchemystAIInvalidDataException(
                    "'query' cannot be null",
                    new System::ArgumentNullException("query")
                );
        }
        init
        {
            this._bodyProperties["query"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Maximum similarity threshold (must be >= minimum_similarity_threshold)
    /// </summary>
    public required double SimilarityThreshold
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("similarity_threshold", out JsonElement element))
                throw new AlchemystAIInvalidDataException(
                    "'similarity_threshold' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "similarity_threshold",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["similarity_threshold"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Additional metadata for the search
    /// </summary>
    public JsonElement? Metadata
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Search scope
    /// </summary>
    public ApiEnum<string, ScopeModel>? Scope
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("scope", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, ScopeModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["scope"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The ID of the user making the request
    /// </summary>
    public string? UserID
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("user_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["user_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ContextSearchParams() { }

    public ContextSearchParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContextSearchParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties,
        FrozenDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }
#pragma warning restore CS8618

    public static ContextSearchParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties),
            FrozenDictionary.ToFrozenDictionary(bodyProperties)
        );
    }

    public override System::Uri Url(IAlchemystAIClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + "/api/v1/context/search"
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request,
        IAlchemystAIClient client
    )
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

/// <summary>
/// Search scope
/// </summary>
[JsonConverter(typeof(ScopeModelConverter))]
public enum ScopeModel
{
    Internal,
    External,
}

sealed class ScopeModelConverter : JsonConverter<ScopeModel>
{
    public override ScopeModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "internal" => ScopeModel.Internal,
            "external" => ScopeModel.External,
            _ => (ScopeModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ScopeModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ScopeModel.Internal => "internal",
                ScopeModel.External => "external",
                _ => throw new AlchemystAIInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
