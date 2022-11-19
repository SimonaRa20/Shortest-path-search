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
        [Fact]
        public void ChangeMap1SetExitsTest()
        {
            int length = 0;
            char[,] map = solution.ReadFile(@"TestData\map1.txt");
            solution.ChangeMapSetExits(map);

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
            char[,] map = solution.ReadFile(@"TestData\map2.txt");
            solution.ChangeMapSetExits(map);

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
            char[,] map = solution.ReadFile(@"TestData\map1.txt");
            solution.ChangeMapSetExits(map);
            solution.FindShortestPath(map).Should().Be(4);
        }

        [TestMethod()]
        [Fact]
        public void FindShortestPathMap2Test()
        {
            int length = 0;
            char[,] map = solution.ReadFile(@"TestData\map2.txt");
            solution.ChangeMapSetExits(map);
            solution.FindShortestPath(map).Should().Be(13);
        }
    }
}