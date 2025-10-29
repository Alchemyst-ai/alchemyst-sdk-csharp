using System.Net.Http;

namespace AlchemystAI.Exceptions;

public class AlchemystAIUnexpectedStatusCodeException : AlchemystAIApiException
{
    public AlchemystAIUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
