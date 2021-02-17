using Bowling.Score.Calculator.Model;
using Microsoft.Extensions.Logging;

namespace Bowling.Score.Calculator.Services
{
    public class ScoreCalculator : IScoreCalculator
    {

        private readonly ILogger<ScoreCalculator> _logger;
        public ScoreCalculator(ILogger<ScoreCalculator> logger)
        {
            _logger = logger;
        }


        public GameScore Calculate(int[] scores)
        {
            var result = new GameScore { FrameCompleted = false, Score = 0 };
            try
            {            
                //TODO: do logic 
                                
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Unable to calculate game score for {scores}. Error encountered: {ex}");
                
            }

            return result;
        }
    }
}
