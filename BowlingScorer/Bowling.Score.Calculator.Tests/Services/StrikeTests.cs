using Bowling.Score.Calculator.Services;
using Bowling.Score.Calculator.Validation;
using NUnit.Framework;

namespace Bowling.Score.Calculator.Tests.Services
{
    [TestFixture]
    public class StrikeTests
    {

        private readonly IScoreCalculator scoreCalculator;
        private readonly IGameValidator gameValidator;
        public StrikeTests()
        {
            gameValidator = new GameValidator();
            scoreCalculator = new ScoreCalculator(gameValidator);
        }

        [Test]
        public void ScoreSingleStrikeOngoingGameTest()
        {
            var result = scoreCalculator.Calculate(StrikeTestHelper.ValidStrikeScoresWholeFrameOngoingGame.TestScores);
            Assert.AreEqual(StrikeTestHelper.ValidStrikeScoresWholeFrameOngoingGame.ExpectedTotalScore, result.Score);
            Assert.AreEqual(StrikeTestHelper.ValidStrikeScoresWholeFrameOngoingGame.Completed, result.FrameCompleted);
        }

        [Test]
        public void ScoreSingleStrikeHalfFrameOngoingGameTest()
        {
            var result = scoreCalculator.Calculate(StrikeTestHelper.ValidStrikeScoresHalfFrameOngoingGame.TestScores);
            Assert.AreEqual(StrikeTestHelper.ValidStrikeScoresHalfFrameOngoingGame.ExpectedTotalScore, result.Score);
            Assert.AreEqual(StrikeTestHelper.ValidStrikeScoresHalfFrameOngoingGame.Completed, result.FrameCompleted);
        }

        [Test]
        public void ScoreMultipleStrikeTest()
        {
            var result = scoreCalculator.Calculate(StrikeTestHelper.ValidMultipleStrikeScoresWholeFrameOngoingGame.TestScores);
            Assert.AreEqual(StrikeTestHelper.ValidMultipleStrikeScoresWholeFrameOngoingGame.ExpectedTotalScore, result.Score);
            Assert.AreEqual(StrikeTestHelper.ValidMultipleStrikeScoresWholeFrameOngoingGame.Completed, result.FrameCompleted);
        }


        [Test]
        public void ScoreLastFrameStrikeTest()
        {
            var result = scoreCalculator.Calculate(StrikeTestHelper.ValidLastFrameStrikeOngoingGame.TestScores);
            Assert.AreEqual(StrikeTestHelper.ValidLastFrameStrikeOngoingGame.ExpectedTotalScore, result.Score);
            Assert.AreEqual(StrikeTestHelper.ValidLastFrameStrikeOngoingGame.Completed, result.FrameCompleted);

            result = scoreCalculator.Calculate(StrikeTestHelper.ValidLastFrameDoubleStrikeOngoingGame.TestScores);
            Assert.AreEqual(StrikeTestHelper.ValidLastFrameDoubleStrikeOngoingGame.ExpectedTotalScore, result.Score);
            Assert.AreEqual(StrikeTestHelper.ValidLastFrameDoubleStrikeOngoingGame.Completed, result.FrameCompleted);
        }
        [Test]
        public void ScoreWithStrikeGameCompleteTest()
        {
            var result = scoreCalculator.Calculate(StrikeTestHelper.ValidWithStrikeCompleteGame.TestScores);
            Assert.AreEqual(StrikeTestHelper.ValidWithStrikeCompleteGame.ExpectedTotalScore, result.Score);
            Assert.AreEqual(StrikeTestHelper.ValidWithStrikeCompleteGame.Completed, result.FrameCompleted);
        }
        [Test]
        public void ScoreMultipleStrikeGameCompleteTest()
        {
            var result = scoreCalculator.Calculate(StrikeTestHelper.ValidMultipleStrikeCompleteGame.TestScores);
            Assert.AreEqual(StrikeTestHelper.ValidMultipleStrikeCompleteGame.ExpectedTotalScore, result.Score);
            Assert.AreEqual(StrikeTestHelper.ValidMultipleStrikeCompleteGame.Completed, result.FrameCompleted);
        }

        [Test]
        public void StrikeOn10thGameIncompleteTest()
        {
            var result = scoreCalculator.Calculate(StrikeTestHelper.Valid10thFrameStrikeIncompleteGame.TestScores);
            Assert.AreEqual(StrikeTestHelper.Valid10thFrameStrikeIncompleteGame.ExpectedTotalScore, result.Score);
            Assert.AreEqual(StrikeTestHelper.Valid10thFrameStrikeIncompleteGame.Completed, result.FrameCompleted);
        }

        [Test]
        public void StrikeOn10thGameCompleteTest()
        {
            var result = scoreCalculator.Calculate(StrikeTestHelper.Valid10thFrameStrikeCompleteGame.TestScores);
            Assert.AreEqual(StrikeTestHelper.Valid10thFrameStrikeCompleteGame.ExpectedTotalScore, result.Score);
            Assert.AreEqual(StrikeTestHelper.Valid10thFrameStrikeCompleteGame.Completed, result.FrameCompleted);
        }

    }
}
