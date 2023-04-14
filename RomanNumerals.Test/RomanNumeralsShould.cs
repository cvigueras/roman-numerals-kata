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
            var result = _calculate.RomanNumber(new Number(arabicNumber));

            result.Should().Be(romanNumeral);
        }

        [TestCase(4, "IV")]
        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(8, "VIII")]
        [TestCase(9, "IX")]
        public void GetUnitsRomanNumbers(int arabicNumber, string romanNumeral)
        {
            var result = _calculate.RomanNumber(new Number(arabicNumber));

            result.Should().Be(romanNumeral);
        }

        [TestCase(11, "XI")]
        [TestCase(12, "XII")]
        [TestCase(13, "XIII")]
        [TestCase(14, "XIV")]
        [TestCase(15, "XV")]
        [TestCase(16, "XVI")]
        [TestCase(17, "XVII")]
        [TestCase(18, "XVIII")]
        [TestCase(19, "XIX")]
        public void GetFirstTensRomanNumbers(int arabicNumber, string romanNumeral)
        {
            var result = _calculate.RomanNumber(new Number(arabicNumber));

            result.Should().Be(romanNumeral);
        }

        [TestCase(20, "XX")]
        [TestCase(21, "XXI")]
        [TestCase(28, "XXVIII")]
        [TestCase(29, "XXIX")]
        public void GetSecondTensRomanNumbers(int arabicNumber, string romanNumeral)
        {
            var result = _calculate.RomanNumber(new Number(arabicNumber));

            result.Should().Be(romanNumeral);
        }

        [TestCase(30, "XXX")]
        [TestCase(35, "XXXV")]
        [TestCase(38, "XXXVIII")]
        [TestCase(39, "XXXIX")]
        public void GetThirdTensRomanNumbers(int arabicNumber, string romanNumeral)
        {
            var result = _calculate.RomanNumber(new Number(arabicNumber));

            result.Should().Be(romanNumeral);
        }

        [TestCase(40, "XL")]
        [TestCase(41, "XLI")]
        [TestCase(45, "XLV")]
        [TestCase(48, "XLVIII")]
        [TestCase(49, "XLIX")]
        public void GetFourthTensRomanNumbers(int arabicNumber, string romanNumeral)
        {
            var result = _calculate.RomanNumber(new Number(arabicNumber));

            result.Should().Be(romanNumeral);
        }

        [TestCase(50, "L")]
        [TestCase(51, "LI")]
        [TestCase(55, "LV")]
        [TestCase(58, "LVIII")]
        [TestCase(59, "LIX")]
        public void GetFifthTensRomanNumbers(int arabicNumber, string romanNumeral)
        {
            var result = _calculate.RomanNumber(new Number(arabicNumber));

            result.Should().Be(romanNumeral);
        }

        [TestCase(90, "XC")]
        [TestCase(91, "XCI")]
        [TestCase(95, "XCV")]
        [TestCase(98, "XCVIII")]
        [TestCase(99, "XCIX")]
        public void GetNinthTensRomanNumbers(int arabicNumber, string romanNumeral)
        {
            var result = _calculate.RomanNumber(new Number(arabicNumber));

            result.Should().Be(romanNumeral);
        }

        [TestCase(100, "C")]
        [TestCase(101, "CI")]
        [TestCase(150, "CL")]
        [TestCase(189, "CLXXXIX")]
        [TestCase(199, "CXCIX")]
        public void GetHoundredRomanNumbers(int arabicNumber, string romanNumeral)
        {
            var result = _calculate.RomanNumber(new Number(arabicNumber));

            result.Should().Be(romanNumeral);
        }
    }
}
