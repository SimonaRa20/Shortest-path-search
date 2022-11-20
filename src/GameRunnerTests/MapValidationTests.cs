using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Xunit.Assert;

namespace GameRunner.Tests
{
    [TestClass()]
    public class MapValidationTests
    {
        private IMapValidation validation;
        private ISolution solution;

        public MapValidationTests()
        {
            this.validation = new MapValidation(solution);
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
            validation.CheckMapLengthAndWidth(filePath).Should().Be(expectedResult);
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
            validation.CheckMapSymbols(filePath).Should().Be(expectedResult);
        }

        [TestMethod()]
        [Xunit.Theory]
        [InlineData(@"TestData\map1.txt", true)]
        [InlineData(@"TestData\map2.txt", true)]
        [InlineData(@"TestData\map7.txt", false)]
        public void CheckMapExitsTest(string filePath, bool expectedResult)
        {
            validation.CheckMapExits(filePath).Should().Be(expectedResult);
        }

        [TestMethod()]
        [Fact]
        public void ChangeMap1SetExitsTest()
        {
            char[,] map = validation.ReadMap(@"TestData\map1.txt");
            validation.ChangeMapSetExits(map);

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
            char[,] map = validation.ReadMap(@"TestData\map2.txt");
            validation.ChangeMapSetExits(map);

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
    }
}