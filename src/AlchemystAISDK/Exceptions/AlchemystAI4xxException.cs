using System.Net.Http;

namespace AlchemystAISDK.Exceptions;

public class AlchemystAI4xxException : AlchemystAIApiException
{
    public AlchemystAI4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
