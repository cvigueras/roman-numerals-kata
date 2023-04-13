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
        var closestNumber = GetClosestNumber(number);
        if (closestNumber > number)
        {
            if (Math.Abs(number - closestNumber) > 1)
            {
                closestNumber = GetPreviousClosestNumber(number);
                return SearchRomanNumeralValue(closestNumber) + SearchRomanNumeralValue(number - closestNumber);
            }
            return SearchRomanNumeralValue(number - closestNumber) + SearchRomanNumeralValue(closestNumber);
        }
        return SearchRomanNumeralValue(closestNumber) + SearchRomanNumeralValue(number - closestNumber);
    }

    private string SearchRomanNumeralValue(int number)
    {
        return _romanNumerals.Values.FirstOrDefault(x => x.Key == Math.Abs(number)).Value;
    }

    private int GetPreviousClosestNumber(int number)
    {
        return _romanNumerals.Values.Keys.TakeWhile(x => x != GetClosestNumber(number)).LastOrDefault();
    }

    private int GetClosestNumber(int number)
    {
        return _romanNumerals.Values.Aggregate((x,
            y) => Math.Abs(x.Key - number) < Math.Abs(y.Key - number)
            ? x
            : y).Key;
    }
}