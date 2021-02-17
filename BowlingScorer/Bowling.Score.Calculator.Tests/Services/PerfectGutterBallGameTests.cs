using Bowling.Score.Calculator.Services;
using Bowling.Score.Calculator.Validation;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Bowling.Score.Calculator.Tests
{
    [TestFixture]
    public class PerfectGutterBallGameTests
    {
                
        private readonly IScoreCalculator scoreCalculator;
        private readonly IGameValidator gameValidator;
        public PerfectGutterBallGameTests()
        {        
            gameValidator = new GameValidator();
            scoreCalculator = new ScoreCalculator( gameValidator);
        }


        [Test]
        public void PerfectScoreTest()
        {
            var gameScore = scoreCalculator.Calculate(ScoreTestHelper.PerfectScore());

            Assert.IsTrue(gameScore.FrameCompleted);
            Assert.AreEqual(gameScore.Score, 300);
        }


        [Test]
        public void GutterBallScoreTest()
        {
            var gameScore = scoreCalculator.Calculate(ScoreTestHelper.GutterBallScores());

            Assert.IsTrue(gameScore.FrameCompleted);
            Assert.AreEqual(gameScore.Score, 0);
        }


    }
}
