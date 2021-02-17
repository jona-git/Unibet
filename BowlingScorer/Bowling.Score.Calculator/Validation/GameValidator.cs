using Bowling.Score.Calculator.Infrastructure.Exceptions;
using System;
using System.Linq;

namespace Bowling.Score.Calculator.Validation
{
    public class GameValidator : IGameValidator
    {       
        void IGameValidator.ValidateScores(int[] scores)
        {
            if (scores == null || scores.Length == 0) throw new ScorerException("Scores cannot be empty.");
            if (scores.Any(s => s < 0 || s > 10)) throw new ScorerException("Score values cannot be less than 0 or greater than 10.");
            if (scores.Length > 22) throw new ScorerException("Too many scores listed.");
        }
    }
}
