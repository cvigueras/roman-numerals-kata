using FluentAssertions;
using RomanNumerals.Console;

namespace RomanNumerals.Test
{
    public class RomanNumeralsShould
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void GetIWhenArabicNumberIs1()
        {
            var result = _calculator.GetRomanNumber(1);

            result.Should().Be("I");
        }

        [Test]
        public void GetIIWhenArabicNumberIs2()
        {
            var result = _calculator.GetRomanNumber(2);

            result.Should().Be("II");
        }

        [Test]
        public void GetIIIWhenArabicNumberIs3()
        {
            var result = _calculator.GetRomanNumber(3);

            result.Should().Be("III");
        }
    }
}