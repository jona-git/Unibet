namespace Bowling.Score.Calculator.Tests
{
    public static class ScoreTestHelper
    {


        public static class ValidOpenFrameHalfScoreOngoingGame
        {
            public static int ExpectedTotalScore = 15;
            public static bool Completed = false;
            public static int[] TestScores = new int[] { 0, 1, 2, 3, 4, 5, 6 };
        }
        public static class ValidOpenFrameWholeScoreOngoingGame
        {
            public static int ExpectedTotalScore = 22;
            public static bool Completed = false;
            public static int[] TestScores = new int[] { 0, 1, 2, 3, 4, 5, 6, 1 };
        }

        public static class ValidOpenFrameScoresGameComplete
        {
            public static bool Completed = true;
            public static int ExpectedTotalScore = 62;
            public static int[] TestScores = new int[] { 0, 1, 2, 3, 4, 5, 6, 1, 8, 0, 9, 0, 1, 5, 1, 4, 1, 7, 1, 3 };
        }

        public static int[] InvalidOpenFrameScoreGreaterThan10()
        {
            return new int[] { 0, 1, 20, 3, 4, 5, 6 };
        }

        public static int[] InvalidOpenFrameScoreLessThan0()
        {
            return new int[] { 0, 1, 2, 3, 4, -5, 6 };
        }


        public static int[] InvalidMoreThan21Elements()
        {
            return new int[] { 0, 1, 2, 3, 4, 5, 6, 1, 7, 2, 8, 1, 9, 0, 1, 1, 1, 1, 10, 10, 10, 10 };
        }

        public static class PerfectScore
        {
            public static bool Completed = true;
            public static int ExpectedTotalScore = 300;
            public static int[] TestScores = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
        }

        public static class GutterBallScores
        {
            public static bool Completed = true;
            public static int ExpectedTotalScore = 0;
            public static int[] TestScores = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }


    }
}
