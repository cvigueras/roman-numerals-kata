using FluentAssertions;

namespace RomanNumerals.Test
{
    public class RomanNumeralsShould
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void GetIWhenArabicNumberIs1()
        {
            var result = Calculator.GetRomanNumber(1);

            result.Should().Be("I");
        }
    }

    public class Calculator
    {
        public static object GetRomanNumber(int i)
        {
            if (i == 1)
            {
                return "I";
            }

            return string.Empty;
        }
    }
}