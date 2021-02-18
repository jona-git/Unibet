using Bowling.Score.Calculator.Services;
using Bowling.Score.Calculator.Validation;
using NUnit.Framework;

namespace Bowling.Score.Calculator.Tests.Services
{
    [TestFixture]
    public class SpareTests
    {
        private readonly IScoreCalculator scoreCalculator;
        private readonly IGameValidator gameValidator;
        public SpareTests()
        {
            gameValidator = new GameValidator();
            scoreCalculator = new ScoreCalculator(gameValidator);
        }

        [Test]
        public void ScoreSingleSpareOngoingGameTest()
        {
            var result = scoreCalculator.Calculate(SpareTestHelper.ValidSpareScoresWholeFrameOngoingGame.TestScores);
            Assert.AreEqual(SpareTestHelper.ValidSpareScoresWholeFrameOngoingGame.ExpectedTotalScore, result.Score);
            Assert.AreEqual(SpareTestHelper.ValidSpareScoresWholeFrameOngoingGame.Completed, result.FrameCompleted);
        }

        [Test]
        public void ScoreSingleSpareHalfFrameOngoingGameTest()
        {
            var result = scoreCalculator.Calculate(SpareTestHelper.ValidSpareScoresHalfFrameOngoingGame.TestScores);
            Assert.AreEqual(SpareTestHelper.ValidSpareScoresHalfFrameOngoingGame.ExpectedTotalScore, result.Score);
            Assert.AreEqual(SpareTestHelper.ValidSpareScoresHalfFrameOngoingGame.Completed, result.FrameCompleted);
        }

        [Test]
        public void ScoreMultipleSpareTest()
        {
            var result = scoreCalculator.Calculate(SpareTestHelper.ValidMultipleSpareScoresWholeFrameOngoingGame.TestScores);
            Assert.AreEqual(SpareTestHelper.ValidMultipleSpareScoresWholeFrameOngoingGame.ExpectedTotalScore, result.Score);
            Assert.AreEqual(SpareTestHelper.ValidMultipleSpareScoresWholeFrameOngoingGame.Completed, result.FrameCompleted);
        }

        [Test]
        public void ScoreLastFrameSpareTest()
        {
            var result = scoreCalculator.Calculate(SpareTestHelper.ValidLastFrameSpareOngoingGame.TestScores);
            Assert.AreEqual(SpareTestHelper.ValidLastFrameSpareOngoingGame.ExpectedTotalScore, result.Score);
            Assert.AreEqual(SpareTestHelper.ValidLastFrameSpareOngoingGame.Completed, result.FrameCompleted);

            result = scoreCalculator.Calculate(SpareTestHelper.ValidLastFrameDoubleSpareOngoingGame.TestScores);
            Assert.AreEqual(SpareTestHelper.ValidLastFrameDoubleSpareOngoingGame.ExpectedTotalScore, result.Score);
            Assert.AreEqual(SpareTestHelper.ValidLastFrameDoubleSpareOngoingGame.Completed, result.FrameCompleted);
        }
        [Test]
        public void ScoreWithSpareGameCompleteTest()
        {
            var result = scoreCalculator.Calculate(SpareTestHelper.ValidLastFrameDoubleSpareCompleteGame.TestScores);
            Assert.AreEqual(SpareTestHelper.ValidLastFrameDoubleSpareCompleteGame.ExpectedTotalScore, result.Score);
            Assert.AreEqual(SpareTestHelper.ValidLastFrameDoubleSpareCompleteGame.Completed, result.FrameCompleted);
        }

        [Test]
        public void SpareOn10thGameIncompleteTest()
        {
            var result = scoreCalculator.Calculate(SpareTestHelper.Valid10thFrameSpareIncompleteGame.TestScores);
            Assert.AreEqual(SpareTestHelper.Valid10thFrameSpareIncompleteGame.ExpectedTotalScore, result.Score);
            Assert.AreEqual(SpareTestHelper.Valid10thFrameSpareIncompleteGame.Completed, result.FrameCompleted);
        }

        [Test]
        public void SpareOn10thGameCompleteTest()
        {
            var result = scoreCalculator.Calculate(SpareTestHelper.Valid10thFrameSpareCompleteGame.TestScores);
            Assert.AreEqual(SpareTestHelper.Valid10thFrameSpareCompleteGame.ExpectedTotalScore, result.Score);
            Assert.AreEqual(SpareTestHelper.Valid10thFrameSpareCompleteGame.Completed, result.FrameCompleted);
        }

    }
}
