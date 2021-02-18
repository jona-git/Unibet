using Bowling.Score.Calculator.Model;
using Bowling.Score.Calculator.Validation;
using System.Collections.Generic;
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

            //TODO: Open Frame logic
            //TODO: Strike logic
            //TODO: Spare logic
            var result = new GameScore() { FrameCompleted = true, Score = 1 };            
            var scoreCard = ConvertToFrames(scores);
            if (!scoreCard.Any(c => c.IsSpare || c.IsStrike))
            {
                result.Score = scoreCard.Sum(s => s.Score);
                result.FrameCompleted = scoreCard.Count == 10;
                return result;
            }
         

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
             
      
        private List<Frame> ConvertToFrames(int[] scores)
        {
            var frames = new List<Frame>();

            for (int i = 0; i < scores.Length-1; i+=2)
            {
                var frame = new Frame() { FirstBall = scores[i]};
                frames.Add(frame);
                if (i + 1 >= scores.Length) break;
                frame.SecondBall = scores[i + 1];
                
                if (frame.IsStrike)
                    i--;
            }

            return frames;
        }


    }
}
