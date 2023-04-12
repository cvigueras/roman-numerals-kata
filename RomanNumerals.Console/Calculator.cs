namespace RomanNumerals.Console;

public class Calculator
{
    private readonly Dictionary<int, string> _romanNumerals;

    public Calculator()
    {
        _romanNumerals = new Dictionary<int, string>
        {
            {1, "I"},
            {2, "II"},
            {3, "III"},
            {5, "V"},
            {10, "X"},
            {50, "L"},
            {100, "C"},
            {500, "D"},
            {1000, "M"},
        };
    }
    public string GetRomanNumber(int number)
    {
        return !string.IsNullOrEmpty(SearchRomanNumeralValue(number))
            ? SearchRomanNumeralValue(number)
            : FormatUnitRomanNumber(number);
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
        var romanNumeral = _romanNumerals.FirstOrDefault(x => x.Key == Math.Abs(number)).Value;
        return string.IsNullOrEmpty(romanNumeral) ? string.Empty : romanNumeral;
    }

    private string GetSubtractUnitRomanNumber(int number)
    {
        var closestNumber = GetClosetNumber(number);
        return SearchRomanNumeralValue(number - closestNumber) + SearchRomanNumeralValue(closestNumber);
    }

    private int GetClosetNumber(int number)
    {
        return _romanNumerals.Aggregate((x,
            y) => Math.Abs(x.Key - number) < Math.Abs(y.Key - number)
            ? x
            : y).Key;
    }
}