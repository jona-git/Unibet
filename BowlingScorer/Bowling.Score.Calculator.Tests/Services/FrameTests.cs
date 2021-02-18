using Bowling.Score.Calculator.Infrastructure.Exceptions;
using Bowling.Score.Calculator.Model;
using NUnit.Framework;

namespace Bowling.Score.Calculator.Tests.Services
{
    [TestFixture]
    public class FrameTests
    {

        [Test]
        public void StrikeFrameTest()
        {
            var frame = new Frame() { FirstBall = 10 };
            Assert.AreEqual(10, frame.FirstBall);
            Assert.IsTrue(frame.IsStrike);
            Assert.IsFalse(frame.IsSpare);
            Assert.IsNull(frame.SecondBall);
        }

        [Test]
        public void SpareFrameTest()
        {
            var frame = new Frame() { FirstBall = 1, SecondBall =9 };
            Assert.AreEqual(10, frame.Score);
            Assert.IsTrue(frame.IsSpare);
            Assert.IsFalse(frame.IsStrike);            
        }

        [Test]
        public void OpenFrameTest()
        {
            var frame = new Frame() { FirstBall = 1, SecondBall = 5 };
            Assert.AreEqual(6, frame.Score);
            Assert.IsFalse(frame.IsSpare);
            Assert.IsFalse(frame.IsStrike);
        }

        [Test]
        public void InvalidSecondBallTest()
        {
            var frame = new Frame() { FirstBall = 10 };
            Assert.Throws<ScorerException>(() => frame.SecondBall = 1);            
        }
    }
}
