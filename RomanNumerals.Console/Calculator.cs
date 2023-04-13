namespace RomanNumerals.Console;

public class Calculator
{
    private readonly RomanNumerals _romanNumerals;

    public Calculator()
    {
        _romanNumerals = new RomanNumerals();
    }

    public string GetRomanNumber(ArabicNumber num)
    {
        return !string.IsNullOrEmpty(SearchRomanNumeralValue(num.Value))
            ? SearchRomanNumeralValue(num.Value)
            : FormatUnitRomanNumber(num.Value);
    }

    private string FormatUnitRomanNumber(int number)
    {
        return number is > 5 and < 9 ? GetSumUnitRomanNumber(number) : GetSubtractUnitRomanNumber(number);
    }

    private string GetSumUnitRomanNumber(int number)
    {
        var closestNumber = 5;
        return SearchRomanNumeralValue(closestNumber) + SearchRomanNumeralValue(number - closestNumber);
    }

    private string SearchRomanNumeralValue(int number)
    {
        var romanNumeral = _romanNumerals.Values.FirstOrDefault(x => x.Key == Math.Abs(number)).Value;
        return string.IsNullOrEmpty(romanNumeral) ? string.Empty : romanNumeral;
    }

    private string GetSubtractUnitRomanNumber(int number)
    {
        var closestNumber = GetClosetNumber(number);
        return SearchRomanNumeralValue(number - closestNumber) + SearchRomanNumeralValue(closestNumber);
    }

    private int GetClosetNumber(int number)
    {
        return _romanNumerals.Values.Aggregate((x,
            y) => Math.Abs(x.Key - number) < Math.Abs(y.Key - number)
            ? x
            : y).Key;
    }
}