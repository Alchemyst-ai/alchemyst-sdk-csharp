using System.Net.Http;

namespace AlchemystAI.Exceptions;

public class AlchemystAIUnauthorizedException : AlchemystAI4xxException
{
    public AlchemystAIUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
