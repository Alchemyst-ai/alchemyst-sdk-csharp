using System.Net.Http;

namespace Alchemystai.Exceptions;

public class AlchemystAI5xxException : AlchemystAIApiException
{
    public AlchemystAI5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
