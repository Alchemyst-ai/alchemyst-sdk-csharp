using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Alchemystai.Core;
using Alchemystai.Exceptions;
using Alchemystai.Services.V1;

namespace Alchemystai;

public sealed class AlchemystAIClient : IAlchemystAIClient
{
    readonly ClientOptions _options;

    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    public Uri BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    public TimeSpan Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    public string? APIKey
    {
        get { return this._options.APIKey; }
        init { this._options.APIKey = value; }
    }

    public IAlchemystAIClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AlchemystAIClient(modifier(this._options));
    }

    readonly Lazy<IV1Service> _v1;
    public IV1Service V1
    {
        get { return _v1.Value; }
    }

    public async Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(request.Method, request.Params.Url(this))
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this);
        using CancellationTokenSource timeoutCts = new(this.Timeout);
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            timeoutCts.Token,
            cancellationToken
        );
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(
                    requestMessage,
                    HttpCompletionOption.ResponseHeadersRead,
                    cts.Token
                )
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e1)
        {
            throw new AlchemystAIIOException("I/O exception", e1);
        }
        if (!responseMessage.IsSuccessStatusCode)
        {
            try
            {
                throw AlchemystAIExceptionFactory.CreateApiException(
                    responseMessage.StatusCode,
                    await responseMessage.Content.ReadAsStringAsync(cts.Token).ConfigureAwait(false)
                );
            }
            catch (HttpRequestException e)
            {
                throw new AlchemystAIIOException("I/O Exception", e);
            }
            finally
            {
                responseMessage.Dispose();
            }
        }
        return new() { Message = responseMessage, CancellationToken = cts.Token };
    }

    public AlchemystAIClient()
    {
        _options = new();

        _v1 = new(() => new V1Service(this));
    }

    public AlchemystAIClient(ClientOptions options)
        : this()
    {
        _options = options;
    }
}
