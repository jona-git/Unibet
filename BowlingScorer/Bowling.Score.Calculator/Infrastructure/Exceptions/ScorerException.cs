using System;

namespace Bowling.Score.Calculator.Infrastructure.Exceptions
{
    public class ScorerException : Exception
    {
        public ScorerException()
        { }

        public ScorerException(string message)
            : base(message)
        { }

        public ScorerException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
