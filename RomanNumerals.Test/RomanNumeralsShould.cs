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

        [Test]
        public void GetIIWhenArabicNumberIs2()
        {
            var result = Calculator.GetRomanNumber(2);

            result.Should().Be("II");
        }

        [Test]
        public void GetIIIWhenArabicNumberIs3()
        {
            var result = Calculator.GetRomanNumber(3);

            result.Should().Be("III");
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
            if (i == 2)
            {
                return "II";
            }
            if (i == 3)
            {
                return "III";
            }

            return string.Empty;
        }
    }
}