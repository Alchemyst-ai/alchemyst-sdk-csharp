using System;
using Alchemystai.Core;
using Org = Alchemystai.Services.V1.Org;

namespace Alchemystai.Services.V1;

public interface IOrgService
{
    IOrgService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Org::IContextService Context { get; }
}
