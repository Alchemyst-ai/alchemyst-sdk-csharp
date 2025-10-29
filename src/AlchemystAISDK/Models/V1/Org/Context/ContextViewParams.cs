using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using AlchemystAISDK.Core;
using AlchemystAISDK.Exceptions;

namespace AlchemystAISDK.Models.V1.Org.Context;

/// <summary>
/// View organization context
/// </summary>
public sealed record class ContextViewParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required List<string> UserIDs
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("userIds", out JsonElement element))
                throw new AlchemystAIInvalidDataException(
                    "'userIds' cannot be null",
                    new ArgumentOutOfRangeException("userIds", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new AlchemystAIInvalidDataException(
                    "'userIds' cannot be null",
                    new ArgumentNullException("userIds")
                );
        }
        set
        {
            this.BodyProperties["userIds"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IAlchemystAIClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/api/v1/org/context/view")
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
