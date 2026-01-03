using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Alchemystai.Core;
using Alchemystai.Models.V1.Context.Memory;

namespace Alchemystai.Services.V1.Context;

/// <inheritdoc/>
public sealed class MemoryService : IMemoryService
{
    /// <inheritdoc/>
    public IMemoryService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MemoryService(this._client.WithOptions(modifier));
    }

    readonly IAlchemystAIClient _client;

    public MemoryService(IAlchemystAIClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<MemoryUpdateResponse> Update(
        MemoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MemoryUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var memory = await response
            .Deserialize<MemoryUpdateResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            memory.Validate();
        }
        return memory;
    }

    /// <inheritdoc/>
    public async Task Delete(
        MemoryDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MemoryDeleteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MemoryAddResponse> Add(
        MemoryAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MemoryAddParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<MemoryAddResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
