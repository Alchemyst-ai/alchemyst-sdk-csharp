using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AlchemystAI.Core;
using AlchemystAI.Models.V1.Context.View;

namespace AlchemystAI.Services.V1.Context.View;

public sealed class ViewService : IViewService
{
    readonly IAlchemystAIClient _client;

    public ViewService(IAlchemystAIClient client)
    {
        _client = client;
    }

    public async Task<ViewRetrieveResponse> Retrieve(ViewRetrieveParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<ViewRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<ViewRetrieveResponse>().ConfigureAwait(false);
    }

    public async Task<JsonElement> Docs(ViewDocsParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<ViewDocsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<JsonElement>().ConfigureAwait(false);
    }
}
