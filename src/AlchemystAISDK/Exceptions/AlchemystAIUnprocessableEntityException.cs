using System.Net.Http;

namespace AlchemystAISDK.Exceptions;

public class AlchemystAIUnprocessableEntityException : AlchemystAI4xxException
{
    public AlchemystAIUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
