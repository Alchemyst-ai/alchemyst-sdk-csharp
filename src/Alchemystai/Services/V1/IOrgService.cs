using System;
using Alchemystai.Core;
using Org = Alchemystai.Services.V1.Org;

namespace Alchemystai.Services.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IOrgService
{
    IOrgService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Org::IContextService Context { get; }
}
