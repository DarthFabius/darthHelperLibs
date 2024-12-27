using darthHelperLibs.StringHelper;

namespace darthHelperLibs.Test.StringHelper
{
    public class StringExtensionTests
    {
        #region BuildString Tests

        [Theory]
        [InlineData(null, "")]
        [InlineData(new string[] { }, "")]
        [InlineData(new[] { "Hello", " ", "World" }, "Hello World")]
        [InlineData(new[] { "Hello", null, "World" }, "HelloWorld")]
        [InlineData(new[] { "A", "", "B" }, "AB")]
        public void BuildString_WhenCalledWithVariousInputs_ReturnsExpectedString(string[]? input, string expected)
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

        #endregion

        #region Left Method Tests

        public class LeftTests
        {
            [Theory]
            [InlineData("Hello, World!", 5, "Hello")]   // Normal case
            [InlineData("Short", 10, "Short")]          // n > length
            [InlineData("", 3, "")]                     // Empty input
            [InlineData(null, 4, "")]                   // Null input
            [InlineData("Sample", 0, "")]               // n = 0
            [InlineData("Sample", -3, "")]              // n < 0
            [InlineData("Edge", 4, "Edge")]             // n == length
            public void GetLeft_ShouldReturnExpectedResult(string? input, int n, string expected)
            {
                Assert.Equal(expected, input.Left(n));
            }
        }

        #endregion

        #region Reverse Method Tests
            [Theory]
            [InlineData("Hello, World!", "!dlroW ,olleH")]  // Normal case
            [InlineData("abc", "cba")]                      // Simple case
            [InlineData("A", "A")]                          // Single character
            [InlineData("", "")]                            // Empty string
            [InlineData(null, null)]                        // Null input
            [InlineData(" 123 ", " 321 ")]                  // String with spaces
            public void Reverse_ShouldReturnReversedString(string? input, string? expected)
            {
                // Act
                var result = input.Reverse();

                // Assert
                Assert.Equal(expected, result);
            }
        #endregion


        #region Right Method Tests

        [Theory]
        [InlineData("Hello, World!", 6, "World!")]
        [InlineData("Short", 10, "Short")]
        [InlineData("", 3, "")]
        [InlineData(null, 4, "")]
        [InlineData("Sample", -3, "")]
        [InlineData("EdgeCase", 8, "EdgeCase")] // n == length
        public void Right_ShouldReturnExpectedResult(string? input, int n, string expected)
        {
            // Act
            var result = input.Right(n);

            // Assert
            Assert.Equal(expected, result);
        }

        #endregion

        #region Base64 Tests

        [Theory]
        [InlineData("Hello, World!", "SGVsbG8sIFdvcmxkIQ==")] // Normal string
        [InlineData("", "")] // Empty string
        [InlineData(null, "")] // Null input
        [InlineData("12345", "MTIzNDU=")] // Numeric string
        [InlineData("😀", "8J+YgA==")] // Unicode emoji
        [InlineData(" ", "IA==")] // Single space
        [InlineData("Line\nBreak", "TGluZQpCcmVhaw==")] // String with line break
        public void ToBase64_WhenCalled_EncodesCorrectly(string? input, string expectedBase64)
        {
            // Act
            var result = input.ToBase64();

            // Assert
            Assert.Equal(expectedBase64, result);
        }

        [Theory]
        [InlineData("SGVsbG8sIFdvcmxkIQ==", "Hello, World!")]
        [InlineData("", "")]
        [InlineData(null, "")]
        [InlineData("8J+YgA==", "😀")]
        public void FromBase64_WhenCalled_DecodesCorrectly(string? base64Input, string expectedOutput)
        {
            // Act
            var result = base64Input.FromBase64();

            // Assert
            Assert.Equal(expectedOutput, result);
        }

        [Fact]
        public void FromBase64_InvalidBase64_ThrowsArgumentException()
        {
            // Arrange
            const string invalidBase64 = "Invalid_Base64_String";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => invalidBase64.FromBase64());
        }

        #endregion
    }
}
