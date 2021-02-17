using Bowling.Score.Calculator.Model;
using Bowling.Score.Calculator.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bowling.Score.Calculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScorerController : ControllerBase
    {
        private readonly IScoreCalculator _scoreCalculator;
        
        public ScorerController(IScoreCalculator scoreCalculator)
        {
            _scoreCalculator = scoreCalculator;
        }

        [HttpPost]
        public GameScore Post([FromBody]int[] scores)
        {
            return _scoreCalculator.Calculate(scores);
        }
    }
}
