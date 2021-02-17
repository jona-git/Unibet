namespace Bowling.Score.Calculator.Tests
{
    public static class ScoreTestHelper
    {

        public static int[] ValidOpenFrameScoresOngoingGame()
        {
            return new int[] { 0,1,2,3,4,5,6 };
        }

        public static int[] ValidOpenFrameScoresGameComplete()
        {
            return new int[] { 0, 1, 2, 3, 4, 5, 6,1,8,0,9,0,1,5,1,4,1,7,1,3 };
        }

        public static int[] InvalidOpenFrameScoreGreaterThan10()
        {
            return new int[] { 0, 1, 20, 3, 4, 5, 6 };
        }

        public static int[] InvalidOpenFrameScoreLessThan0()
        {
            return new int[] { 0, 1, 2, 3, 4, -5, 6 };
        }
            

        public static int[] InvalidMoreThan22Elements ()
        {
            return new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,10,10,10 };
        }

        public static int[] PerfectScore()
        {
            return new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
        }

        public static int[] GutterBallScores()
        {
            return new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }

      
    }
}
