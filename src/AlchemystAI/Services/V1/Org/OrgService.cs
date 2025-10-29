using System;
using AlchemystAI.Services.V1.Org.Context;

namespace AlchemystAI.Services.V1.Org;

public sealed class OrgService : IOrgService
{
    public OrgService(IAlchemystAIClient client)
    {
        _context = new(() => new ContextService(client));
    }

    readonly Lazy<IContextService> _context;
    public IContextService Context
    {
        get { return _context.Value; }
    }
}
