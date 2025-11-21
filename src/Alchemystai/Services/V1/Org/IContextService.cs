using System;
using System.Threading;
using System.Threading.Tasks;
using Alchemystai.Core;
using Alchemystai.Models.V1.Org.Context;

namespace Alchemystai.Services.V1.Org;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IContextService
{
    global::Alchemystai.Services.V1.Org.IContextService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// View organization context
    /// </summary>
    Task<ContextViewResponse> View(
        ContextViewParams parameters,
        CancellationToken cancellationToken = default
    );
}
