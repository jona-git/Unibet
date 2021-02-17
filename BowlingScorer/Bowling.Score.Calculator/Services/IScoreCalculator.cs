using Bowling.Score.Calculator.Model;

namespace Bowling.Score.Calculator.Services
{
    public interface IScoreCalculator
    {
        GameScore Calculate(int[] scores);
    }
}
