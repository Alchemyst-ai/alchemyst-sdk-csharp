using System.Net.Http;

namespace AlchemystAISDK.Exceptions;

public class AlchemystAIForbiddenException : AlchemystAI4xxException
{
    public AlchemystAIForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
