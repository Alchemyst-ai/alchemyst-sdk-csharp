using System.Net.Http;

namespace AlchemystAI.Exceptions;

public class AlchemystAIBadRequestException : AlchemystAI4xxException
{
    public AlchemystAIBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
