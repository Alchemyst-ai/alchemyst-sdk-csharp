using System.Net.Http;

namespace Alchemystai.Exceptions;

public class AlchemystAIBadRequestException : AlchemystAI4xxException
{
    public AlchemystAIBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
