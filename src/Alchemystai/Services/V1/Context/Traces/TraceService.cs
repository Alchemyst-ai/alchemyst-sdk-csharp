using System.Net.Http;
using System.Threading.Tasks;
using Alchemystai.Core;
using Alchemystai.Models.V1.Context.Traces;

namespace Alchemystai.Services.V1.Context.Traces;

public sealed class TraceService : ITraceService
{
    readonly IAlchemystAIClient _client;

    public TraceService(IAlchemystAIClient client)
    {
        _client = client;
    }

    public async Task<TraceListResponse> List(TraceListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<TraceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var traces = await response.Deserialize<TraceListResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            traces.Validate();
        }
        return traces;
    }

    public async Task<TraceDeleteResponse> Delete(TraceDeleteParams parameters)
    {
        HttpRequest<TraceDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var trace = await response.Deserialize<TraceDeleteResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            trace.Validate();
        }
        return trace;
    }
}
