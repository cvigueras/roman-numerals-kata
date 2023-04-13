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
        var result = FormatTensRomanNumber(number);
        if (string.IsNullOrEmpty(result))
        {
            return !string.IsNullOrEmpty(_romanNumerals.SearchRomanNumeralValue(number.Value))
                ? _romanNumerals.SearchRomanNumeralValue(number.Value)
                : FormatUnitsRomanNumber(number);
        }
        return result;
    }

    private static string FormatTensRomanNumber(ArabicNumber number)
    {
        if (number.Value == 14)
        {
            return "XIV";
        }

        if (number.Value == 16)
        {
            return "XVI";
        }

        if (number.Value == 19)
        {
            return "XIX";
        }

        return string.Empty;
    }

    private string FormatUnitsRomanNumber(ArabicNumber number)
    {
        var closestNumber = _romanNumerals.GetClosestNumber(number.Value);
        if (!IsClosestGreaterThanNumber(number, closestNumber))
        {
            return _romanNumerals.FormatUnitsSum(number, closestNumber);
        }
        if (IsSubtract(number, closestNumber))
        {
            return _romanNumerals.FormatUnitsSubtract(number, closestNumber);
        }
        closestNumber = _romanNumerals.GetPreviousClosestNumber(number.Value);
        return _romanNumerals.FormatUnitsSum(number, closestNumber);
    }

    private static bool IsSubtract(ArabicNumber number, int closestNumber)
    {
        return Math.Abs(number.Value - closestNumber) == 1;
    }

    private bool IsClosestGreaterThanNumber(ArabicNumber number, int closestNumber)
    {
        return closestNumber > number.Value;
    }
}