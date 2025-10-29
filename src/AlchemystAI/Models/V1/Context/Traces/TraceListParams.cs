using System;
using System.Net.Http;
using AlchemystAI.Core;

namespace AlchemystAI.Models.V1.Context.Traces;

/// <summary>
/// Retrieves a list of traces for the authenticated user
/// </summary>
public sealed record class TraceListParams : ParamsBase
{
    public override Uri Url(IAlchemystAIClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/api/v1/context/traces")
        {
            Query = this.QueryString(client),
        }.Uri;
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
