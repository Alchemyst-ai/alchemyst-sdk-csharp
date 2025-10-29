using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using AlchemystAISDK.Core;
using AlchemystAISDK.Exceptions;
using AlchemystAISDK.Models.V1.Context.ContextSearchParamsProperties;

namespace AlchemystAISDK.Models.V1.Context;

/// <summary>
/// This endpoint sends a search request to the context processor to retrieve relevant
/// context data based on the provided query.
/// </summary>
public sealed record class ContextSearchParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// Minimum similarity threshold
    /// </summary>
    public required double MinimumSimilarityThreshold
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "minimum_similarity_threshold",
                    out JsonElement element
                )
            )
                throw new AlchemystAIInvalidDataException(
                    "'minimum_similarity_threshold' cannot be null",
                    new ArgumentOutOfRangeException(
                        "minimum_similarity_threshold",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["minimum_similarity_threshold"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The search query used to search for context data
    /// </summary>
    public required string Query
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("query", out JsonElement element))
                throw new AlchemystAIInvalidDataException(
                    "'query' cannot be null",
                    new ArgumentOutOfRangeException("query", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AlchemystAIInvalidDataException(
                    "'query' cannot be null",
                    new ArgumentNullException("query")
                );
        }
        set
        {
            this.BodyProperties["query"] = JsonSerializer.SerializeToElement(
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
            if (!this.BodyProperties.TryGetValue("similarity_threshold", out JsonElement element))
                throw new AlchemystAIInvalidDataException(
                    "'similarity_threshold' cannot be null",
                    new ArgumentOutOfRangeException(
                        "similarity_threshold",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["similarity_threshold"] = JsonSerializer.SerializeToElement(
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
            if (!this.BodyProperties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Search scope
    /// </summary>
    public ApiEnum<string, Scope>? Scope
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("scope", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Scope>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["scope"] = JsonSerializer.SerializeToElement(
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
            if (!this.BodyProperties.TryGetValue("user_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["user_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IAlchemystAIClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/api/v1/context/search")
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
