using System.Net.Http;

namespace AlchemystAI.Exceptions;

public class AlchemystAIRateLimitException : AlchemystAI4xxException
{
    public AlchemystAIRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
