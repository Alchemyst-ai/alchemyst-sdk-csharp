using System;
using System.Net.Http;

namespace AlchemystAI.Exceptions;

public class AlchemystAIIOException : AlchemystAIException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public AlchemystAIIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
