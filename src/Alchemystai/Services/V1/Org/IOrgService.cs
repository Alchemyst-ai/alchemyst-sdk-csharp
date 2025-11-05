using System;
using Alchemystai.Core;
using Alchemystai.Services.V1.Org.Context;

namespace Alchemystai.Services.V1.Org;

public interface IOrgService
{
    IOrgService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IContextService Context { get; }
}
