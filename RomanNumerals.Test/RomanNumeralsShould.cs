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

        [TestCase(4,"IV")]
        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(8, "VIII")]
        [TestCase(9,"IX")]
        public void GetUnitsRomanNumbers(int arabicNumber,string romanNumeral)
        {
            var result = _calculate.RomanNumber(new ArabicNumber(arabicNumber));

            result.Should().Be(romanNumeral);
        }

        [TestCase(11, "XI")]
        [TestCase(12, "XII")]
        [TestCase(13, "XIII")]
        [TestCase(14,"XIV")]
        [TestCase(15,"XV")]
        [TestCase(16,"XVI")]
        [TestCase(17,"XVII")]
        [TestCase(18,"XVIII")]
        [TestCase(19,"XIX")]
        public void GetFirstTensRomanNumbers(int arabicNumber,string romanNumeral)
        {
            var result = _calculate.RomanNumber(new ArabicNumber(arabicNumber));

            result.Should().Be(romanNumeral);
        }

        [TestCase(20, "XX")]
        [TestCase(21, "XXI")]
        [TestCase(29, "XXIX")]
        public void GetSecondTensRomanNumbers(int arabicNumber, string romanNumeral)
        {
            var result = _calculate.RomanNumber(new ArabicNumber(arabicNumber));

            result.Should().Be(romanNumeral);
        }


        [TestCase(30, "XXX")]
        [TestCase(35, "XXXV")]
        [TestCase(39, "XXXIX")]
        public void GetThirdTensRomanNumbers(int arabicNumber, string romanNumeral)
        {
            var result = _calculate.RomanNumber(new ArabicNumber(arabicNumber));

            result.Should().Be(romanNumeral);
        }
    }
}