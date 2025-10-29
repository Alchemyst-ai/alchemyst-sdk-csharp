using System.Net.Http;

namespace AlchemystAI.Exceptions;

public class AlchemystAI5xxException : AlchemystAIApiException
{
    public AlchemystAI5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
