using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling.Score.Calculator.Tests
{
    public static class SpareTestHelper
    {

        public static class ValidSpareScoresHalfFrameOngoingGame
        {
            public static int ExpectedTotalScore = 26;
            public static bool Completed = false;
            public static int[] TestScores = new int[] { 9, 1, 2, 3, 4, 5, 6 };
        }

        public static class ValidSpareScoresWholeFrameOngoingGame
        {
            public static int ExpectedTotalScore = 33;
            public static bool Completed = false;
            public static int[] TestScores = new int[] { 9, 1, 2, 3, 4, 5, 6, 1 };
        }

        public static class ValidMultipleSpareScoresWholeFrameOngoingGame
        {
            public static int ExpectedTotalScore = 62;
            public static bool Completed = false;
            public static int[] TestScores = new int[] { 9, 1, 2, 3, 8, 2, 4, 5, 9, 1, 5, 2 };
        }
        public static class ValidLastFrameDoubleSpareOngoingGame
        {
            public static int ExpectedTotalScore = 59;
            public static bool Completed = false;
            public static int[] TestScores = new int[] { 9, 1, 2, 3, 8, 2, 4, 5, 9, 1, 9, 1 };
        }

        public static class ValidLastFrameSpareOngoingGame
        {
            public static int ExpectedTotalScore = 40;
            public static bool Completed = false;
            public static int[] TestScores = new int[] { 9, 1, 2, 3, 8, 2, 4, 5, 9, 1 };
        }

        public static class ValidLastFrameDoubleSpareCompleteGame
        {
            public static int ExpectedTotalScore = 91;
            public static bool Completed = true;
            public static int[] TestScores = new int[] { 9, 1, 2, 3, 8, 2, 4, 5, 9, 1, 9, 1, 0, 1, 2, 3, 4, 5, 6, 1 };
        }

        public static class Valid10thFrameSpareIncompleteGame
        {
            public static int ExpectedTotalScore = 84;
            public static bool Completed = false;
            public static int[] TestScores = new int[] { 9, 1, 2, 3, 8, 2, 4, 5, 9, 1, 9, 1, 0, 1, 2, 3, 4, 5, 9, 1 };
        }

        public static class Valid10thFrameSpareCompleteGame
        {
            public static int ExpectedTotalScore = 99;
            public static bool Completed = true;
            public static int[] TestScores = new int[] { 9, 1, 2, 3, 8, 2, 4, 5, 9, 1, 9, 1, 0, 1, 2, 3, 4, 5, 9, 1, 5 };
        }
    }
}
