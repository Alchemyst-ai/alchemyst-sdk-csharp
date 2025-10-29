using System;
using System.Net.Http;
using AlchemystAI.Core;

namespace AlchemystAI.Models.V1.Context.View;

/// <summary>
/// Fetches documents view for authenticated user with optional organization context
/// </summary>
public sealed record class ViewDocsParams : ParamsBase
{
    public override Uri Url(IAlchemystAIClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/api/v1/context/view/docs")
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
