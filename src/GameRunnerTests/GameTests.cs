using FluentAssertions;
using Xunit;

namespace GameRunner.Tests
{

    public class GameTests
    {
        private ISolution solution;

        public GameTests()
        {
            solution = new Solution();
        }

        [Fact]
        public void RunTestCheckFirstMapShortestPathResult()
        {
            IGame game = new Game(solution);
            int expected = game.Run(@"TestData\map1.txt");
            expected.Should().Be(4);
        }

        [Fact]
        public void RunTestCheckSecongMapShortestPathResult()
        {
            IGame game = new Game(solution);
            int expected = game.Run(@"TestData\map2.txt");
            expected.Should().Be(13);
        }
    }
}