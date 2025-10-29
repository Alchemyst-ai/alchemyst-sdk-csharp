using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Alchemystai.Core;
using Alchemystai.Models.V1.Context.Memory.MemoryAddParamsProperties;

namespace Alchemystai.Models.V1.Context.Memory;

/// <summary>
/// This endpoint adds memory context data, fetching chat history if needed.
/// </summary>
public sealed record class MemoryAddParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// Array of content objects with additional properties allowed
    /// </summary>
    public List<Content>? Contents
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("contents", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Content>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["contents"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The ID of the memory
    /// </summary>
    public string? MemoryID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("memoryId", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["memoryId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IAlchemystAIClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/api/v1/context/memory/add")
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
