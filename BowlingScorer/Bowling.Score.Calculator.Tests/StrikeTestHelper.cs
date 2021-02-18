using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling.Score.Calculator.Tests
{
    public static class StrikeTestHelper
    {

        public static class ValidStrikeScoresHalfFrameOngoingGame
        {
            public static int ExpectedTotalScore = 29;
            public static bool Completed = false;
            public static int[] TestScores = new int[] { 10, 2, 3, 4, 5, 6 };
        }

        public static class ValidStrikeScoresWholeFrameOngoingGame
        {
            public static int ExpectedTotalScore = 36;
            public static bool Completed = false;
            public static int[] TestScores = new int[] { 10, 2, 3, 4, 5, 6, 1 };
        }

        public static class ValidMultipleStrikeScoresWholeFrameOngoingGame
        {
            public static int ExpectedTotalScore = 72;
            public static bool Completed = false;
            public static int[] TestScores = new int[] { 10, 2, 3, 10, 4, 5, 10, 5, 2 };
        }
        public static class ValidLastFrameStrikeOngoingGame
        {
            public static int ExpectedTotalScore = 48;
            public static bool Completed = false;
            public static int[] TestScores = new int[] { 10, 2, 3, 10, 4, 5, 10 };
        }

        public static class ValidLastFrameDoubleStrikeOngoingGame
        {
            public static int ExpectedTotalScore = 48;
            public static bool Completed = false;
            public static int[] TestScores = new int[] { 10, 2, 3, 10, 4, 5, 10, 10 };
        }

        public static class ValidWithStrikeCompleteGame
        {
            public static int ExpectedTotalScore = 96;
            public static bool Completed = true;
            public static int[] TestScores = new int[] { 10, 2, 3, 8, 2, 4, 5,10,10, 0, 1, 2, 3, 4, 5, 6, 1 };
        }

        public static class ValidMultipleStrikeCompleteGame
        {
            public static int ExpectedTotalScore = 162;
            public static bool Completed = true;
            public static int[] TestScores = new int[] { 10, 2, 3, 8, 2, 4, 5, 10, 10, 10, 10, 4, 5, 6, 1 };
        }

        public static class Valid10thFrameStrikeIncompleteGame
        {
            public static int ExpectedTotalScore = 155;
            public static bool Completed = false;
            public static int[] TestScores = new int[] { 10, 2, 3, 8, 2, 4, 5, 10, 10, 10, 10, 4, 5, 10 };
        }

        public static class Valid10thFrameStrikeCompleteGame
        {
            public static int ExpectedTotalScore = 185;
            public static bool Completed = true;
            public static int[] TestScores = new int[] { 10, 2, 3, 8, 2, 4, 5, 10, 10, 10,10, 4, 5, 10,10,10 };
        }
        public static class Valid10thFrameStrike11thSpareCompleteGame
        {
            public static int ExpectedTotalScore = 109;
            public static bool Completed = true;
            public static int[] TestScores = new int[] { 10, 2, 3, 8, 2, 4, 5, 10, 10, 0, 1, 2, 3, 4, 5, 10, 9, 1 };
        }
    }
}
