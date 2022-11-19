﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace GameRunner.Tests
{
    [TestClass()]
    public class GameTests
    {
        private ISolution solution;

        public GameTests()
        {
            solution = new Solution();
        }

        [TestMethod()]
        [Xunit.Theory]
        [InlineData(@"TestData\map1.txt", 4)]
        [InlineData(@"TestData\map2.txt", 13)]
        [InlineData(@"TestData\map3.txt", 0)]
        [InlineData(@"TestData\map4.txt", 0)]
        public void RunTestCheckMapShortestPathResult(string filePath, int expectedResult)
        {
            IGame game = new Game(solution);
            int expected = game.Run(filePath);
            expected.Should().Be(expectedResult);
        }
    }
}