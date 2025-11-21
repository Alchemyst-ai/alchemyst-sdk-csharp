using System;
using Alchemystai.Core;
using Alchemystai.Services.V1;

namespace Alchemystai.Services;

public sealed class V1Service : IV1Service
{
    public IV1Service WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new V1Service(this._client.WithOptions(modifier));
    }

    readonly IAlchemystAIClient _client;

    public V1Service(IAlchemystAIClient client)
    {
        _client = client;
        _context = new(() => new ContextService(client));
        _org = new(() => new OrgService(client));
    }

    readonly Lazy<IContextService> _context;
    public IContextService Context
    {
        get { return _context.Value; }
    }

    readonly Lazy<IOrgService> _org;
    public IOrgService Org
    {
        get { return _org.Value; }
    }
}
