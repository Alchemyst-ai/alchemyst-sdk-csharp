using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using AlchemystAI.Core;
using AlchemystAI.Models.V1.Context.ContextAddParamsProperties;

namespace AlchemystAI.Models.V1.Context;

/// <summary>
/// This endpoint accepts context data and sends it to a context processor for further
/// handling. It returns a success or error response depending on the result from
/// the context processor.
/// </summary>
public sealed record class ContextAddParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// Type of context being added
    /// </summary>
    public ApiEnum<string, ContextType>? ContextType
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("context_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, ContextType>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["context_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Array of documents with content and additional metadata
    /// </summary>
    public List<Document>? Documents
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("documents", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Document>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["documents"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Additional metadata for the context
    /// </summary>
    public Metadata? Metadata
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Metadata?>(element, ModelBase.SerializerOptions);
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
    /// Scope of the context
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
    /// The source of the context data
    /// </summary>
    public string? Source
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("source", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["source"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IAlchemystAIClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/api/v1/context/add")
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
