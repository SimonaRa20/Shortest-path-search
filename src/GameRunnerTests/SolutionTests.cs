using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

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

        //[Theory]
        //[TestMethod()]
        //[DataTestMethod]
        //[DynamicData(nameof(Map1DataChangedMap), DynamicDataSourceType.Method), InlineData(@"TestData\map1.txt")]
        ////[InlineData(@"TestData\map2.txt"), DynamicData(nameof(Map2DataChangedMap), DynamicDataSourceType.Method)]
        //public void ChangeMapSetExitsTest(char[,] expectedResult, string filePath)
        //{
        //    int length = 0;
        //    char[,] changedMap = solution.Map(filePath, ref length);
        //    changedMap.Should().Be(expectedResult);
        //}

        //[TestMethod()]
        //[DataTestMethod]
        //[DynamicData(nameof(Map1DataChangedMap), DynamicDataSourceType.Method), InlineData(4)]
        ////[InlineData(@"TestData\map2.txt"), DynamicData(nameof(Map2DataChangedMap), DynamicDataSourceType.Method)]
        //public void FindShortestPathTest(char[,] map, int expectedResult)
        //{
        //    int length = map.Length;
        //    solution.FindShortestPath(map, length).Should().Be(expectedResult);
        //}

        //[TestMethod()]
        //public void MapTest()
        //{
        //    Assert.Fail();
        //}

        //static string Map1DataPath = @"TestData\map1.txt";

        //static IEnumerable<object[]> Map1DataChangedMap()
        //{
        //    return new[] { new[] { new char[,]{
        //                                        { '1', '1', '1', '1', '1' },
        //                                        { '1', ' ', 'X', ' ', '1' },
        //                                        { '1', ' ', '1', ' ', '1' },
        //                                        { '1', ' ', ' ', ' ', '1' },
        //                                        { '1', '1', '1', 'E', '1' }
        //                                   } } };
        //}

        //static IEnumerable<object[]> Map2DataChangedMap()
        //{
        //    return new[] { new[] { new char[,]{
        //                                        { '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1' },
        //                                        { '1', ' ', ' ', ' ', ' ', ' ', '1', ' ', ' ', ' ', '1' },
        //                                        { '1', ' ', '1', ' ', '1', ' ', '1', '1', '1', ' ', '1' },
        //                                        { '1', ' ', '1', ' ', '1', ' ', ' ', ' ', ' ', ' ', '1' },
        //                                        { '1', ' ', '1', ' ', '1', ' ', '1', '1', '1', '1', '1' },
        //                                        { '1', ' ', ' ', ' ', '1', 'X', ' ', ' ', ' ', ' ', '1' },
        //                                        { '1', ' ', '1', '1', '1', '1', '1', '1', '1', ' ', '1' },
        //                                        { '1', ' ', ' ', ' ', '1', ' ', ' ', ' ', ' ', ' ', '1' },
        //                                        { '1', '1', '1', ' ', '1', ' ', '1', '1', '1', ' ', '1' },
        //                                        { '1', ' ', ' ', ' ', '1', ' ', '1', ' ', ' ', ' ', '1' },
        //                                        { '1', ' ', '1', '1', '1', ' ', '1', '1', '1', '1', '1' }
        //                                   } } };
        //}

    }
}