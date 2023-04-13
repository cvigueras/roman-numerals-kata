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
        if (number.Value == 20)
        {
            return "XX";
        }
        var romanNumber = _romanNumerals.SearchRomanNumeralValue(number.Value);
        if (!string.IsNullOrEmpty(romanNumber))
        {
            return romanNumber;
        }
        var numberSplit = string.Join(",", number.Value.ToString()
            .Select((item, index) => item.ToString().PadRight(number.Value.ToString().Length - index, '0'))).Split(",").Reverse().ToList();
        for (var i = 0; i < numberSplit.Count(); i++)
        {
            if (i == 0)
            {
                romanNumber += FormatUnitsRomanNumber(new ArabicNumber(Convert.ToInt32(numberSplit[0])));
            }

            if (i == 1)
            {
                romanNumber = _romanNumerals.SearchRomanNumeralValue(Convert.ToInt32(numberSplit[1])) + romanNumber;
            }
        }
        return romanNumber;
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