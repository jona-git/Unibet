using Bowling.Score.Calculator.Controllers;
using Bowling.Score.Calculator.Infrastructure.Exceptions;
using Bowling.Score.Calculator.Model;
using Bowling.Score.Calculator.Services;
using Bowling.Score.Calculator.Validation;
using NUnit.Framework;
using System.Net.Http;

namespace Bowling.Score.Calculator.Tests
{
    [TestFixture]
    public class ScorerControllerTests 
    {
        private readonly IScoreCalculator scoreCalculator;
        private readonly IGameValidator gameValidator;
        private readonly ScorerController scorerController;
        public ScorerControllerTests()
        {
            gameValidator = new GameValidator(); //used actual instance for this since this is lightweight, otherwise will mock dependencies

            scoreCalculator = new ScoreCalculator(gameValidator);
            scorerController = new ScorerController(scoreCalculator);
        }


        [Test]
        public void CalculatePerfectScoreTest()
        {            
            var result = scorerController.Post(ScoreTestHelper.PerfectScore());
            Assert.AreEqual(result.GetType(), typeof(GameScore));
            Assert.IsTrue(result.FrameCompleted);
            Assert.AreEqual(result.Score, 300);
        }


        [Test]
        public void CalculateGutterBallGameScoreTest()
        {
            var result = scorerController.Post(ScoreTestHelper.GutterBallScores());
            Assert.AreEqual(result.GetType(), typeof(GameScore));
            Assert.IsTrue(result.FrameCompleted);
            Assert.AreEqual(result.Score, 0);

        }

        [Test]
        public void InvalidScoresTest()
        {
            Assert.Throws<ScorerException>(() => scorerController.Post(ScoreTestHelper.InvalidOpenFrameScoreGreaterThan10()));
           
        }


    }
}
