using NUnit.Framework;

namespace Bowling.Score.Calculator.Tests
{
    [TestFixture]
    public class ValidationTests
    {
                
        [Test]
        public void ValidGameScore()
        {
            //TODO: test if score element count is < 0 OR > 12
        }

        [Test]
        public void InvalidGameScore()
        {
            //TODO: if score values are <0 OR >10
        }
    }
}
