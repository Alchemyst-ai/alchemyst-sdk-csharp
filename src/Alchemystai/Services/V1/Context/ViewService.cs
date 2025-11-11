using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Alchemystai.Core;
using Alchemystai.Models.V1.Context.View;

namespace Alchemystai.Services.V1.Context;

public sealed class ViewService : IViewService
{
    public IViewService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ViewService(this._client.WithOptions(modifier));
    }

    readonly IAlchemystAIClient _client;

    public ViewService(IAlchemystAIClient client)
    {
        _client = client;
    }

    public async Task<ViewRetrieveResponse> Retrieve(
        ViewRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ViewRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var view = await response
            .Deserialize<ViewRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            view.Validate();
        }
        return view;
    }

    public async Task<JsonElement> Docs(
        ViewDocsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ViewDocsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize<JsonElement>(cancellationToken).ConfigureAwait(false);
    }
}
