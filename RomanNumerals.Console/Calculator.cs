namespace RomanNumerals.Console;

public class Calculator
{
    private readonly RomanNumerals _romanNumerals;

    public Calculator()
    {
        _romanNumerals = new RomanNumerals();
    }

    public string GetRomanNumber(ArabicNumber number)
    {
        return !string.IsNullOrEmpty(_romanNumerals.SearchRomanNumeralValue(number.Value))
            ? _romanNumerals.SearchRomanNumeralValue(number.Value)
            : FormatUnitRomanNumber(number);
    }

    private string FormatUnitRomanNumber(ArabicNumber value)
    {
        var closestNumber = _romanNumerals.GetClosestNumber(value.Value);
        if (closestNumber > value.Value)
        {
            if (Math.Abs(value.Value - closestNumber) > 1)
            {
                closestNumber = _romanNumerals.GetPreviousClosestNumber(value.Value);
                return _romanNumerals.SearchRomanNumeralValue(closestNumber) + _romanNumerals.SearchRomanNumeralValue(value.Value - closestNumber);
            }
            return _romanNumerals.SearchRomanNumeralValue(value.Value - closestNumber) + _romanNumerals.SearchRomanNumeralValue(closestNumber);
        }
        return _romanNumerals.SearchRomanNumeralValue(closestNumber) + _romanNumerals.SearchRomanNumeralValue(value.Value - closestNumber);
    }
}