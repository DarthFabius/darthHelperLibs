using darthHelperLibs.StringHelper;

namespace darthHelperLibs.test.StringHelper
{
    public class StringExtensionTests
    {
        [Theory]
        [InlineData(null, "")]
        [InlineData(new string[] { }, "")]
        [InlineData(new[] { "Hello", " ", "World" }, "Hello World")]
        [InlineData(new[] { "Hello", null, "World" }, "HelloWorld")]
        [InlineData(new[] { "A", "", "B" }, "AB")]
        public void BuildString_WithVariousInputs_ReturnsExpectedString(string[]? input, string expected)
        {
            // Arrange
            IEnumerable<string>? values = input;

            // Act
            var result = values.BuildString();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void BuildString_WhenValuesContainLargeStrings_ReturnsConcatenatedString()
        {
            // Arrange
            var values = new List<string> { new('A', 1000), new('B', 1000) };

            // Act
            var result = values.BuildString();

            // Assert
            Assert.Equal(new string('A', 1000) + new string('B', 1000), result);
        }

        public class GetLeftTests
        {
            [Theory]
            [InlineData("Hello, World!", 5, "Hello")]   // Normal case
            [InlineData("Short", 10, "Short")]          // n > length
            [InlineData("", 3, "")]                     // Empty input
            [InlineData(null, 4, "")]                   // Null input
            [InlineData("Sample", 0, "")]               // n = 0
            [InlineData("Sample", -3, "")]              // n < 0
            [InlineData("Edge", 4, "Edge")]             // n == length
            public void GetLeft_ShouldReturnExpectedResult(string input, int n, string expected)
            {
                Assert.Equal(expected, input.Left(n));
            }
        }
    }

}