using AlchemystAISDK.Services.V1.Context;
using AlchemystAISDK.Services.V1.Org;

namespace AlchemystAISDK.Services.V1;

public interface IV1Service
{
    IContextService Context { get; }

    IOrgService Org { get; }
}
