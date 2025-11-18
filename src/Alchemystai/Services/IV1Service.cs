using System;
using Alchemystai.Core;
using Alchemystai.Services.V1;

namespace Alchemystai.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IV1Service
{
    IV1Service WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IContextService Context { get; }

    IOrgService Org { get; }
}
