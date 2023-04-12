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
            var result = Calculator.GetRomanNumber();

            result.Should().Be("I");
        }
    }

    public class Calculator
    {
        public static object GetRomanNumber()
        {
            throw new NotImplementedException();
        }
    }
}