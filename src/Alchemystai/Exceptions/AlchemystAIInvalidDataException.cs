using System;

namespace Alchemystai.Exceptions;

public class AlchemystAIInvalidDataException : AlchemystAIException
{
    public AlchemystAIInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
