using System.Net.Http;

namespace AlchemystAISDK.Exceptions;

public class AlchemystAIUnauthorizedException : AlchemystAI4xxException
{
    public AlchemystAIUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
