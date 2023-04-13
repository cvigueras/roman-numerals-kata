namespace RomanNumerals.Console;

public class Calculate
{
    private readonly RomanNumerals _romanNumerals;

    public Calculate()
    {
        _romanNumerals = new RomanNumerals();
    }

    public string RomanNumber(ArabicNumber number)
    {
        return !string.IsNullOrEmpty(_romanNumerals.SearchRomanNumeralValue(number.Value))
            ? _romanNumerals.SearchRomanNumeralValue(number.Value)
            : FormatUnitsRomanNumber(number);
    }

    private string FormatUnitsRomanNumber(ArabicNumber number)
    {
        var closestNumber = _romanNumerals.GetClosestNumber(number.Value);
        if (closestNumber > number.Value)
        {
            if (Math.Abs(number.Value - closestNumber) == 1)
            {
                return _romanNumerals.SearchRomanNumeralValue(number.Value - closestNumber) + _romanNumerals.SearchRomanNumeralValue(closestNumber);
            }
            closestNumber = _romanNumerals.GetPreviousClosestNumber(number.Value);
        }
        return _romanNumerals.SearchRomanNumeralValue(closestNumber) + _romanNumerals.SearchRomanNumeralValue(number.Value - closestNumber);
    }
}