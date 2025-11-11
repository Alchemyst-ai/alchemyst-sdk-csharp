using System;
using Alchemystai.Core;
using Alchemystai.Services.V1;

namespace Alchemystai.Services;

public interface IV1Service
{
    IV1Service WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IContextService Context { get; }

    IOrgService Org { get; }
}
