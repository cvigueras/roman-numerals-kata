using FluentAssertions;
using RomanNumerals.Console;

namespace RomanNumerals.Test
{
    public class RomanNumeralsShould
    {
        private Calculate _calculate;

        [SetUp]
        public void Setup()
        {
            _calculate = new Calculate();
        }

        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(3, "III")]
        [TestCase(5, "V")]
        [TestCase(10, "X")]
        [TestCase(50, "L")]
        [TestCase(100, "C")]
        [TestCase(500, "D")]
        [TestCase(1000, "M")]
        public void GetBasicsRomanNumbers(int arabicNumber, string romanNumeral)
        {
            var result = _calculate.RomanNumber(new ArabicNumber(arabicNumber));

            result.Should().Be(romanNumeral);
        }

        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(8, "VIII")]
        [TestCase(4,"IV")]
        [TestCase(9,"IX")]
        public void GetUnitsRomanNumbers(int arabicNumber,string romanNumeral)
        {
            var result = _calculate.RomanNumber(new ArabicNumber(arabicNumber));

            result.Should().Be(romanNumeral);
        }

        [Test]
        public void GetXIWhenArabicNumberIs11()
        {
            var result = _calculate.RomanNumber(new ArabicNumber(11));

            result.Should().Be("XI");
        }

        [Test]
        public void GetXIIWhenArabicNumberIs12()
        {
            var result = _calculate.RomanNumber(new ArabicNumber(12));

            result.Should().Be("XII");
        }

        [Test]
        public void GetXIIIWhenArabicNumberIs13()
        {
            var result = _calculate.RomanNumber(new ArabicNumber(13));

            result.Should().Be("XIII");
        }

        [Test]
        public void GetXIVWhenArabicNumberIs14()
        {
            var result = _calculate.RomanNumber(new ArabicNumber(14));

            result.Should().Be("XIV");
        }

        [Test]
        public void GetXVWhenArabicNumberIs15()
        {
            var result = _calculate.RomanNumber(new ArabicNumber(15));

            result.Should().Be("XV");
        }

        [Test]
        public void GetXVIWhenArabicNumberIs16()
        {
            var result = _calculate.RomanNumber(new ArabicNumber(16));

            result.Should().Be("XVI");
        }
    }
}