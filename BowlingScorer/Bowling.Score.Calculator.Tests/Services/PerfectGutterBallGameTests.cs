using Bowling.Score.Calculator.Services;
using Bowling.Score.Calculator.Validation;
using NUnit.Framework;

namespace Bowling.Score.Calculator.Tests.Services
{
    [TestFixture]
    public class PerfectGutterBallGameTests
    {

        private readonly IScoreCalculator scoreCalculator;
        private readonly IGameValidator gameValidator;
        public PerfectGutterBallGameTests()
        {
            gameValidator = new GameValidator();
            scoreCalculator = new ScoreCalculator(gameValidator);
        }


        [Test]
        public void PerfectScoreTest()
        {
            var gameScore = scoreCalculator.Calculate(ScoreTestHelper.PerfectScore.TestScores);

            Assert.IsTrue(gameScore.FrameCompleted);
            Assert.AreEqual(gameScore.Score, ScoreTestHelper.PerfectScore.ExpectedTotalScore);
        }


        [Test]
        public void GutterBallScoreTest()
        {
            var gameScore = scoreCalculator.Calculate(ScoreTestHelper.GutterBallScores.TestScores);

            Assert.IsTrue(gameScore.FrameCompleted);
            Assert.AreEqual(gameScore.Score, ScoreTestHelper.GutterBallScores.ExpectedTotalScore);
        }


    }
}
