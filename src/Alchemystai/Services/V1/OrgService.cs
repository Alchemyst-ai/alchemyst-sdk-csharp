using System;
using Alchemystai.Core;
using Org = Alchemystai.Services.V1.Org;

namespace Alchemystai.Services.V1;

/// <inheritdoc/>
public sealed class OrgService : IOrgService
{
    /// <inheritdoc/>
    public IOrgService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OrgService(this._client.WithOptions(modifier));
    }

    readonly IAlchemystAIClient _client;

    public OrgService(IAlchemystAIClient client)
    {
        _client = client;
        _context = new(() => new Org::ContextService(client));
    }

    readonly Lazy<Org::IContextService> _context;
    public Org::IContextService Context
    {
        get { return _context.Value; }
    }
}
