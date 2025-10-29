using System.Net.Http;

namespace Alchemystai.Exceptions;

public class AlchemystAIUnexpectedStatusCodeException : AlchemystAIApiException
{
    public AlchemystAIUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
