using Bowling.Score.Calculator.Controllers;
using Bowling.Score.Calculator.Infrastructure.Exceptions;
using Bowling.Score.Calculator.Model;
using Bowling.Score.Calculator.Services;
using Moq;
using NUnit.Framework;

namespace Bowling.Score.Calculator.Tests
{
    [TestFixture]
    public class ScorerControllerTests 
    {
        
        [Test]
        public void CalculatePerfectScoreTest()
        {
            var fakeResult = new GameScore() { FrameCompleted = true, Score = 300 };
            var scoreCalculator = new Mock<IScoreCalculator>();
            scoreCalculator.Setup(c => c.Calculate(It.IsAny<int[]>())).Returns(fakeResult).Verifiable();
            var scorerController = new ScorerController(scoreCalculator.Object);
            var result = scorerController.Post(ScoreTestHelper.PerfectScore.TestScores);         

            scoreCalculator.Verify(s=>s.Calculate(It.IsAny<int[]>()), Times.Once());
            Assert.AreEqual(result.GetType(), typeof(GameScore));
            Assert.IsTrue(result.FrameCompleted);
            Assert.AreEqual(result.Score, ScoreTestHelper.PerfectScore.ExpectedTotalScore);
            
        }


        [Test]
        public void CalculateGutterBallGameScoreTest()
        {            
            var fakeResult = new GameScore() { FrameCompleted = true, Score = 0 };
            var scoreCalculator = new Mock<IScoreCalculator>();
            scoreCalculator.Setup(c => c.Calculate(It.IsAny<int[]>())).Returns(fakeResult).Verifiable();
            var scorerController = new ScorerController(scoreCalculator.Object);
            var result = scorerController.Post(ScoreTestHelper.GutterBallScores.TestScores);

            scoreCalculator.Verify(s => s.Calculate(It.IsAny<int[]>()), Times.Once());
            scoreCalculator.VerifyAll();
            Assert.AreEqual(result.GetType(), typeof(GameScore));
            Assert.IsTrue(result.FrameCompleted);
            Assert.AreEqual(result.Score, ScoreTestHelper.GutterBallScores.ExpectedTotalScore);

        }

        [Test]
        public void InvalidScoresTest()
        {
            var scoreCalculator = new Mock<IScoreCalculator>();
            scoreCalculator.Setup(c => c.Calculate(It.IsAny<int[]>()))
                .Throws(new ScorerException())
                .Verifiable();
            

            var scorerController = new ScorerController(scoreCalculator.Object);
            Assert.Throws<ScorerException>(() => scorerController.Post(ScoreTestHelper.InvalidOpenFrameScoreGreaterThan10()));
            scoreCalculator.Verify(s => s.Calculate(It.IsAny<int[]>()), Times.Once());
            
        }

      

    }
}
