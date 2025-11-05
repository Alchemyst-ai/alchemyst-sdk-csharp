using System;
using Alchemystai.Core;
using Alchemystai.Services.V1.Context;
using Alchemystai.Services.V1.Org;

namespace Alchemystai.Services.V1;

public interface IV1Service
{
    IV1Service WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IContextService Context { get; }

    IOrgService Org { get; }
}
