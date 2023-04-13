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
        if (IsClosestUpToNumber(number, closestNumber))
        {
            if (IsSubtract(number, closestNumber))
            {
                return FormatUnitsSubtract(number, closestNumber);
            }
            closestNumber = _romanNumerals.GetPreviousClosestNumber(number.Value);
        }
        return FormatUnitsSum(number, closestNumber);
    }

    private string FormatUnitsSum(ArabicNumber number, int closestNumber)
    {
        return _romanNumerals.SearchRomanNumeralValue(closestNumber) +
               _romanNumerals.SearchRomanNumeralValue(number.Value - closestNumber);
    }

    private string FormatUnitsSubtract(ArabicNumber number, int closestNumber)
    {
        return _romanNumerals.SearchRomanNumeralValue(number.Value - closestNumber) +
               _romanNumerals.SearchRomanNumeralValue(closestNumber);
    }

    private static bool IsSubtract(ArabicNumber number, int closestNumber)
    {
        return Math.Abs(number.Value - closestNumber) == 1;
    }

    private bool IsClosestUpToNumber(ArabicNumber number, int closestNumber)
    {
        return closestNumber > number.Value;
    }
}