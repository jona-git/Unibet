using Bowling.Score.Calculator.Infrastructure.Exceptions;
using Bowling.Score.Calculator.Services;
using Bowling.Score.Calculator.Validation;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;

namespace Bowling.Score.Calculator.Tests
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
            Assert.DoesNotThrow(() => gameValidator.ValidateScores(ScoreTestHelper.ValidOpenFrameScoresOngoingGame()));            
        }

        [Test]
        public void ValidAndCompleteGameScore()
        {
            Assert.DoesNotThrow(() => gameValidator.ValidateScores(ScoreTestHelper.ValidOpenFrameScoresGameComplete()));
          
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
        public void InvalidEmptyScore()
        {
            Assert.Throws<ScorerException>(() => gameValidator.ValidateScores(null));
            Assert.Throws<ScorerException>(() => gameValidator.ValidateScores(new int[] { }));
        }

    }
}
