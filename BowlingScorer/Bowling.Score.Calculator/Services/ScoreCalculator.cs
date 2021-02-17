using Bowling.Score.Calculator.Model;
using Bowling.Score.Calculator.Validation;
using System.Linq;

namespace Bowling.Score.Calculator.Services
{
    public class ScoreCalculator : IScoreCalculator
    {
        
        private readonly IGameValidator _gameValidator;
        public ScoreCalculator(IGameValidator gameValidator)
        {       
            _gameValidator = gameValidator;
        }


        public GameScore Calculate(int[] scores)
        {
                    

            _gameValidator.ValidateScores(scores);

            if (IsPerfectScore(scores)) return new GameScore { FrameCompleted = true, Score = 300 };
            if (IsGutterBallGame(scores)) return new GameScore { FrameCompleted = true, Score = 0 };

            var result = new GameScore() { FrameCompleted = true, Score = 1 };

            //TODO: Open Frame logic
            //TODO: Strike logic
            //TODO: Spare logic

            return result;
        }

        private bool IsPerfectScore(int[] scores)
        {            
            return scores.Length == 12 && !scores.Any(s => s != 10);
        }

        private bool IsGutterBallGame(int[] scores)
        {
            return scores.Length == 10 && !scores.Any(s => s != 0);
        }
             
      



    }
}
