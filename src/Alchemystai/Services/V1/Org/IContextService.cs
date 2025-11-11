using System;
using System.Threading;
using System.Threading.Tasks;
using Alchemystai.Core;
using Alchemystai.Models.V1.Org.Context;

namespace Alchemystai.Services.V1.Org;

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
