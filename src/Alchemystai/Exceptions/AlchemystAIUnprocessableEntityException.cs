using System.Net.Http;

namespace Alchemystai.Exceptions;

public class AlchemystAIUnprocessableEntityException : AlchemystAI4xxException
{
    public AlchemystAIUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
