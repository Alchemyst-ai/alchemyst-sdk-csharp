using System.Net.Http;

namespace AlchemystAI.Exceptions;

public class AlchemystAI4xxException : AlchemystAIApiException
{
    public AlchemystAI4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
