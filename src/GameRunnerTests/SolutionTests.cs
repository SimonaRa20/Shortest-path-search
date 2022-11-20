using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace GameRunner.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        private ISolution solution;
        private IMapValidation validation;

        public SolutionTests()
        {
            solution = new Solution();
            validation = new MapValidation(solution);
        }

        [TestMethod()]
        [Fact]
        public void FindShortestPathMap1Test()
        {
            char[,] map = validation.ReadMap(@"TestData\map1.txt");
            validation.ChangeMapSetExits(map);
            solution.FindShortestPath(map).Should().Be(4);
        }

        [TestMethod()]
        [Fact]
        public void FindShortestPathMap2Test()
        {
            int length = 0;
            char[,] map = validation.ReadMap(@"TestData\map2.txt");
            validation.ChangeMapSetExits(map);
            solution.FindShortestPath(map).Should().Be(13);
        }
    }
}