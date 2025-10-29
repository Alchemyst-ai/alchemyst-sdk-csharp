using Alchemystai.Services.V1.Context;
using Alchemystai.Services.V1.Org;

namespace Alchemystai.Services.V1;

public interface IV1Service
{
    IContextService Context { get; }

    IOrgService Org { get; }
}
