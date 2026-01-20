using Xunit;
using LisApp;

namespace LisApp.Tests
{
    public class LisServiceTests
    {
        private readonly LisService _service = new LisService();

        [Fact]
        public void TestCase1()
        {
            string input = "6 1 5 9 2";
            string result = _service.FindLongestIncreasingSubsequence(input);

            Assert.Equal("1 5 9", result);
        }

        [Fact]
        public void EarliestLIS_ShouldBeReturned()
        {
            string input = "1 3 5 2 4 6";
            string result = _service.FindLongestIncreasingSubsequence(input);

            Assert.Equal("1 3 5 6", result);
        }

        [Fact]
        public void EmptyInput_ShouldReturnEmpty()
        {
            var result = _service.FindLongestIncreasingSubsequence("");
            Assert.Equal(string.Empty, result);
        }
    }
}
