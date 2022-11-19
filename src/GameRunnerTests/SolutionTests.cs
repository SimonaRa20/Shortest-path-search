using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Xunit.Assert;

namespace GameRunner.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        private ISolution solution;

        public SolutionTests()
        {
            solution = new Solution();
        }

        [TestMethod()]
        [Xunit.Theory]
        [InlineData(@"TestData\map1.txt", true)]
        [InlineData(@"TestData\map2.txt", true)]
        [InlineData(@"TestData\map3.txt", true)]
        [InlineData(@"TestData\map4.txt", true)]
        [InlineData(@"TestData\map5.txt", false)]
        public void CheckMapLengthAndWidthTest(string filePath, bool expectedResult)
        {
            solution.CheckMapLengthAndWidth(filePath).Should().Be(expectedResult);
        }

        [TestMethod()]
        [Xunit.Theory]
        [InlineData(@"TestData\map1.txt", true)]
        [InlineData(@"TestData\map2.txt", true)]
        [InlineData(@"TestData\map3.txt", true)]
        [InlineData(@"TestData\map4.txt", true)]
        [InlineData(@"TestData\map6.txt", false)]
        public void CheckMapSymbolsTest(string filePath, bool expectedResult)
        {
            solution.CheckMapSymbols(filePath).Should().Be(expectedResult);
        }

        [TestMethod()]
        [Xunit.Theory]
        [InlineData(@"TestData\map1.txt", true)]
        [InlineData(@"TestData\map2.txt", true)]
        [InlineData(@"TestData\map7.txt", false)]
        public void CheckMapExitsTest(string filePath, bool expectedResult)
        {
            solution.CheckMapExits(filePath).Should().Be(expectedResult);
        }

        [TestMethod()]
        [Fact]
        public void ChangeMap1SetExitsTest()
        {
            int length = 0;
            char[,] map = solution.Map(@"TestData\map1.txt", ref length);
            solution.ChangeMapSetExits(map, length);

            Assert.Equal(map, new char[,]{
                                             { '1', '1', '1', '1', '1' },
                                             { '1', ' ', 'X', ' ', '1' },
                                             { '1', ' ', '1', ' ', '1' },
                                             { '1', ' ', ' ', ' ', '1' },
                                             { '1', '1', '1', 'E', '1' }
                                         });
        }

        [TestMethod()]
        [Fact]
        public void ChangeMap2SetExitsTest()
        {
            int length = 0;
            char[,] map = solution.Map(@"TestData\map2.txt", ref length);
            solution.ChangeMapSetExits(map, length);

            Assert.Equal(map, new char[,]{
                                             { '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1' },
                                             { '1', ' ', ' ', ' ', ' ', ' ', '1', ' ', ' ', ' ', '1' },
                                             { '1', ' ', '1', ' ', '1', ' ', '1', '1', '1', ' ', '1' },
                                             { '1', ' ', '1', ' ', '1', ' ', ' ', ' ', ' ', ' ', '1' },
                                             { '1', ' ', '1', ' ', '1', ' ', '1', '1', '1', '1', '1' },
                                             { '1', ' ', ' ', ' ', '1', 'X', ' ', ' ', ' ', ' ', '1' },
                                             { '1', ' ', '1', '1', '1', '1', '1', '1', '1', ' ', '1' },
                                             { '1', ' ', ' ', ' ', '1', ' ', ' ', ' ', ' ', ' ', '1' },
                                             { '1', '1', '1', ' ', '1', ' ', '1', '1', '1', ' ', '1' },
                                             { '1', ' ', ' ', ' ', '1', ' ', '1', ' ', ' ', ' ', '1' },
                                             { '1', 'E', '1', '1', '1', 'E', '1', '1', '1', '1', '1' }
                                         });
        }

        [TestMethod()]
        [Fact]
        public void FindShortestPathMap1Test()
        {
            int length = 0;
            char[,] map = solution.Map(@"TestData\map1.txt", ref length);
            solution.ChangeMapSetExits(map, length);
            solution.FindShortestPath(map, length).Should().Be(4);
        }

        [TestMethod()]
        [Fact]
        public void FindShortestPathMap2Test()
        {
            int length = 0;
            char[,] map = solution.Map(@"TestData\map2.txt", ref length);
            solution.ChangeMapSetExits(map, length);
            solution.FindShortestPath(map, length).Should().Be(13);
        }
    }
}