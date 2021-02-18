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
                     
                      
            var scoreCard = ConvertToFrames(scores);
            if (!scoreCard.Any(c => c.IsSpare || c.IsStrike))
            {
                return new GameScore()
                {
                    Score = scoreCard.Sum(s => s.Score),
                    FrameCompleted = scoreCard.Count == 10
                };
             
            }

            var result = new GameScore() { FrameCompleted = false, Score = 1 };
            
            var totalScore = 0;
            var strikePot = 0;
            for (int i = 0; i < scoreCard.Count; i++)
            {
                var nextIndex = i + 1;
                var currentFrame = scoreCard[i];
                
                if ( nextIndex< scoreCard.Count)
                {
                    var nextFrame = scoreCard[nextIndex];

                    if (currentFrame.IsSpare)
                    {
                        totalScore += 10 + nextFrame.FirstBall.Value;
                        continue;
                    }
                    if (currentFrame.IsStrike )
                    {                       
                        if (!nextFrame.IsStrike)
                        {
                            totalScore += currentFrame.Score + nextFrame.Score + strikePot;
                            strikePot = 0;
                        }
                        else
                        {
                            var indexAfterNextAvailable = i + 2 < scoreCard.Count;
                            var indexAfterNext = i + 2;
                            strikePot += indexAfterNextAvailable && scoreCard[indexAfterNext].IsStrike ? 30 :
                                               20 + (indexAfterNextAvailable ? scoreCard[indexAfterNext].FirstBall.Value : 0);
                            if (i == 9 )
                            {
                                totalScore += strikePot;
                                break;
                            }
                        }                        
                        continue;
                    }                    
                }
               

                if (nextIndex == scoreCard.Count && (currentFrame.IsSpare || currentFrame.IsStrike))
                    break;

               
                totalScore += currentFrame.Score;                
            }

            result.Score = totalScore;
            result.FrameCompleted = (scoreCard.Count == 10 && !scoreCard[9].IsSpare && !scoreCard[9].IsStrike)
                                    || (scoreCard.Count == 11 && scoreCard[9].IsSpare)
                                    || (scoreCard.Count == 12 && scoreCard[11].IsStrike);

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

            for (int i = 0; i < scores.Length; i+=2)
            {
                var frame = new Frame() { FirstBall = scores[i]};
                frames.Add(frame);
                if (i + 1 >= scores.Length) break;
                if (frame.IsStrike)
                {
                    i--;
                    continue;
                }
                frame.SecondBall = scores[i + 1];
            }

            return frames;
        }
        

    }
}
