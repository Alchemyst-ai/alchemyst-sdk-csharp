using System.Net.Http;

namespace Alchemystai.Exceptions;

public class AlchemystAINotFoundException : AlchemystAI4xxException
{
    public AlchemystAINotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
