using System.Net.Http;

namespace AlchemystAISDK.Exceptions;

public class AlchemystAINotFoundException : AlchemystAI4xxException
{
    public AlchemystAINotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
