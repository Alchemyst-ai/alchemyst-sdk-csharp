using System;
using System.Net.Http;
using Alchemystai.Core;

namespace Alchemystai.Models.V1.Context.Traces;

/// <summary>
/// Deletes a data trace for the authenticated user with the specified trace ID
/// </summary>
public sealed record class TraceDeleteParams : ParamsBase
{
    public required string TraceID;

    public override Uri Url(IAlchemystAIClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/api/v1/context/traces/{0}/delete", this.TraceID)
        )
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
