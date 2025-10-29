using AlchemystAI.Services.V1.Context;
using AlchemystAI.Services.V1.Org;

namespace AlchemystAI.Services.V1;

public interface IV1Service
{
    IContextService Context { get; }

    IOrgService Org { get; }
}
