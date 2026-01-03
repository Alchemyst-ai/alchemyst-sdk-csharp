using System;
using System.Threading;
using System.Threading.Tasks;
using Alchemystai.Core;
using Alchemystai.Models.V1.Context.View;

namespace Alchemystai.Services.V1.Context;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IViewService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IViewService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Gets the context information for the authenticated user.
    /// </summary>
    Task<ViewRetrieveResponse> Retrieve(
        ViewRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fetches documents view for authenticated user with optional organization context.
    /// </summary>
    Task<ViewDocsResponse> Docs(
        ViewDocsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
