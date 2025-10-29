using System.Net.Http;
using System.Threading.Tasks;
using Alchemystai.Core;
using Alchemystai.Models.V1.Context.Memory;

namespace Alchemystai.Services.V1.Context.Memory;

public sealed class MemoryService : IMemoryService
{
    readonly IAlchemystAIClient _client;

    public MemoryService(IAlchemystAIClient client)
    {
        _client = client;
    }

    public async Task Update(MemoryUpdateParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<MemoryUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task Delete(MemoryDeleteParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<MemoryDeleteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task Add(MemoryAddParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<MemoryAddParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }
}
