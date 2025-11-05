using System;
using Alchemystai.Core;
using Alchemystai.Services.V1.Org.Context;

namespace Alchemystai.Services.V1.Org;

public sealed class OrgService : IOrgService
{
    public IOrgService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OrgService(this._client.WithOptions(modifier));
    }

    readonly IAlchemystAIClient _client;

    public OrgService(IAlchemystAIClient client)
    {
        _client = client;
        _context = new(() => new ContextService(client));
    }

    readonly Lazy<IContextService> _context;
    public IContextService Context
    {
        get { return _context.Value; }
    }
}
