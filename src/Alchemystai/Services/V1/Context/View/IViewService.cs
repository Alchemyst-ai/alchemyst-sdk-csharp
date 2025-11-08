using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Alchemystai.Core;
using Alchemystai.Models.V1.Context.View;

namespace Alchemystai.Services.V1.Context.View;

public interface IViewService
{
    IViewService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Gets the context information for the authenticated user
    /// </summary>
    Task<ViewRetrieveResponse> Retrieve(
        ViewRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fetches documents view for authenticated user with optional organization context
    /// </summary>
    Task<JsonElement> Docs(
        ViewDocsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
