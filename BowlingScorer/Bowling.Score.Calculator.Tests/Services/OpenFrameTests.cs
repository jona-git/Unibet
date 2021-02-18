using Bowling.Score.Calculator.Services;
using Bowling.Score.Calculator.Validation;
using NUnit.Framework;

namespace Bowling.Score.Calculator.Tests.Services
{
    [TestFixture]
    public class OpenFrameTests
    {
        private readonly IScoreCalculator scoreCalculator;
        private readonly IGameValidator gameValidator;
        public OpenFrameTests()
        {
            gameValidator = new GameValidator();
            scoreCalculator = new ScoreCalculator(gameValidator);
        }        

        [Test]
        public void OpenHalfFrameGameOngoing()
        {
            var result = scoreCalculator.Calculate(ScoreTestHelper.ValidOpenFrameHalfScoreOngoingGame.TestScores);
            Assert.AreEqual( ScoreTestHelper.ValidOpenFrameHalfScoreOngoingGame.ExpectedTotalScore, result.Score);
            Assert.AreEqual( ScoreTestHelper.ValidOpenFrameHalfScoreOngoingGame.Completed, result.FrameCompleted);
        }

        [Test]
        public void OpenWholeFrameGameOngoing()
        {
            var result = scoreCalculator.Calculate(ScoreTestHelper.ValidOpenFrameWholeScoreOngoingGame.TestScores);
            Assert.AreEqual(ScoreTestHelper.ValidOpenFrameWholeScoreOngoingGame.ExpectedTotalScore, result.Score);
            Assert.AreEqual(ScoreTestHelper.ValidOpenFrameWholeScoreOngoingGame.Completed, result.FrameCompleted);
        }

        [Test]
        public void OpenFrameGameCompleted()
        {
            var result = scoreCalculator.Calculate(ScoreTestHelper.ValidOpenFrameScoresGameComplete.TestScores);
            Assert.AreEqual( ScoreTestHelper.ValidOpenFrameScoresGameComplete.ExpectedTotalScore,result.Score);
            Assert.AreEqual( ScoreTestHelper.ValidOpenFrameScoresGameComplete.Completed, result.FrameCompleted);
        }

       


    }
}
