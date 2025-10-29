using System;
using Alchemystai.Services.V1.Context;
using Alchemystai.Services.V1.Org;

namespace Alchemystai.Services.V1;

public sealed class V1Service : IV1Service
{
    public V1Service(IAlchemystAIClient client)
    {
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
