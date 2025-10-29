using System.Net.Http;

namespace AlchemystAI.Exceptions;

public class AlchemystAIForbiddenException : AlchemystAI4xxException
{
    public AlchemystAIForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
