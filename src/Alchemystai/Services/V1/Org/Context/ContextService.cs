using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Alchemystai.Core;
using Alchemystai.Models.V1.Org.Context;

namespace Alchemystai.Services.V1.Org.Context;

public sealed class ContextService : IContextService
{
    public IContextService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ContextService(this._client.WithOptions(modifier));
    }

    readonly IAlchemystAIClient _client;

    public ContextService(IAlchemystAIClient client)
    {
        _client = client;
    }

    public async Task<ContextViewResponse> View(
        ContextViewParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ContextViewParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<ContextViewResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
