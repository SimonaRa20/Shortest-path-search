using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

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
    }
}