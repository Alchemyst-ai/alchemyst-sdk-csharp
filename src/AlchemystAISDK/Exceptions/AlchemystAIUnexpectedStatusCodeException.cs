using System.Net.Http;

namespace AlchemystAISDK.Exceptions;

public class AlchemystAIUnexpectedStatusCodeException : AlchemystAIApiException
{
    public AlchemystAIUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
