using System;
using System.Net.Http;

namespace AlchemystAI.Exceptions;

public class AlchemystAIException : Exception
{
    public AlchemystAIException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected AlchemystAIException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
