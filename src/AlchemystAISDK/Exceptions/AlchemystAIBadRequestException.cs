using System.Net.Http;

namespace AlchemystAISDK.Exceptions;

public class AlchemystAIBadRequestException : AlchemystAI4xxException
{
    public AlchemystAIBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
