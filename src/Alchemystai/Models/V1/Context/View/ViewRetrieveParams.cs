using System;
using System.Net.Http;
using Alchemystai.Core;

namespace Alchemystai.Models.V1.Context.View;

/// <summary>
/// Gets the context information for the authenticated user
/// </summary>
public sealed record class ViewRetrieveParams : ParamsBase
{
    public override Uri Url(IAlchemystAIClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/api/v1/context/view")
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
