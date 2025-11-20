using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Alchemystai.Core;
using Alchemystai.Exceptions;
using Alchemystai.Models.V1.Context.Traces;

namespace Alchemystai.Services.V1.Context;

public sealed class TraceService : ITraceService
{
    public ITraceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TraceService(this._client.WithOptions(modifier));
    }

    readonly IAlchemystAIClient _client;

    public TraceService(IAlchemystAIClient client)
    {
        _client = client;
    }

    public async Task<TraceListResponse> List(
        TraceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TraceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var traces = await response
            .Deserialize<TraceListResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            traces.Validate();
        }
        return traces;
    }

    public async Task<TraceDeleteResponse> Delete(
        TraceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TraceID == null)
        {
            throw new AlchemystAIInvalidDataException("'parameters.TraceID' cannot be null");
        }

        HttpRequest<TraceDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var trace = await response
            .Deserialize<TraceDeleteResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            trace.Validate();
        }
        return trace;
    }

    public async Task<TraceDeleteResponse> Delete(
        string traceID,
        TraceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Delete(parameters with { TraceID = traceID }, cancellationToken);
    }
}
