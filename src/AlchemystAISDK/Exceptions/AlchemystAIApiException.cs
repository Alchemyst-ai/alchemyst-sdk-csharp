using System;
using System.Net;
using System.Net.Http;

namespace AlchemystAISDK.Exceptions;

public class AlchemystAIApiException : AlchemystAIException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public AlchemystAIApiException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }

    protected AlchemystAIApiException(HttpRequestException? innerException)
        : base(innerException) { }

    public required HttpStatusCode StatusCode { get; init; }

    public required string ResponseBody { get; init; }

    public override string Message
    {
        get { return string.Format("Status Code: {0}\n{1}", StatusCode, ResponseBody); }
    }
}
