using System.Net.Http;

namespace AlchemystAI.Exceptions;

public class AlchemystAIUnprocessableEntityException : AlchemystAI4xxException
{
    public AlchemystAIUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
