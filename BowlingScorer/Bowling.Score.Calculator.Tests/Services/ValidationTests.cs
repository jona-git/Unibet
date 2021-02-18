using Bowling.Score.Calculator.Infrastructure.Exceptions;
using Bowling.Score.Calculator.Validation;
using NUnit.Framework;

namespace Bowling.Score.Calculator.Tests.Services
{
    [TestFixture]
    public class ValidationTests
    {
        private readonly IGameValidator gameValidator;
        public ValidationTests()
        {
            gameValidator = new GameValidator();
        }

        [Test]
        public void ValidGameScore()
        {
            Assert.DoesNotThrow(() => gameValidator.ValidateScores(ScoreTestHelper.ValidOpenFrameWholeScoreOngoingGame.TestScores));
        }

        [Test]
        public void ValidAndCompleteGameScore()
        {
            Assert.DoesNotThrow(() => gameValidator.ValidateScores(ScoreTestHelper.ValidOpenFrameScoresGameComplete.TestScores));

        }

        [Test]
        public void InvalidScoreValueLessThan0()
        {
            Assert.Throws<ScorerException>(() => gameValidator.ValidateScores(ScoreTestHelper.InvalidOpenFrameScoreLessThan0()));
        }

        [Test]
        public void InvalidScoreValueGreaterThan10()
        {
            Assert.Throws<ScorerException>(() => gameValidator.ValidateScores(ScoreTestHelper.InvalidOpenFrameScoreGreaterThan10()));
        }

        [Test]
        public void InvalidScoresOverMaxThrow()
        {
            Assert.Throws<ScorerException>(() => gameValidator.ValidateScores(ScoreTestHelper.InvalidOpenFrameScoreGreaterThan10()));
        }

        [Test]
        public void InvalidEmptyScore()
        {
            Assert.Throws<ScorerException>(() => gameValidator.ValidateScores(null));
            Assert.Throws<ScorerException>(() => gameValidator.ValidateScores(new int[] { }));
        }

    }
}
