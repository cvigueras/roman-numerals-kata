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
        var romanNumber = _romanNumerals.SearchRomanNumeralValue(number.Value);
        if (!string.IsNullOrEmpty(romanNumber))
        {
            return romanNumber;
        }
        var numberSplit = NumberValueToList(number);

        for (var i = 0; i < numberSplit.Count(); i++)
        {
            if (i == 0)
            {
                if (numberSplit[i] == "0")
                {
                    continue;
                }
                romanNumber += FormatUnitsRomanNumber(new ArabicNumber(Convert.ToInt32(numberSplit[0])));
            }

            if (i == 1)
            {
                romanNumber = FormatTensRomanNumber(new ArabicNumber(Convert.ToInt32(numberSplit[1]))) + romanNumber;
            }
        }


        return romanNumber;
    }

    private List<string> NumberValueToList(ArabicNumber number)
    {
        return string.Join(",", number.Value.ToString()
                .Select((item, index) => item.ToString().PadRight(number.Value.ToString().Length - index, '0')))
            .Split(",").Reverse().ToList();
    }

    private string FormatTensRomanNumber(ArabicNumber number)
    {
        if (number.Value > 30)
        {
            var closestNumber = _romanNumerals.GetClosestNumber(number.Value);
            if (IsTensSubtract(number, closestNumber))
            {
                return _romanNumerals.FormatUnitsSubtract(number, closestNumber);
            }
            if (IsClosestGreaterThanNumber(number, closestNumber))
            {
                closestNumber = _romanNumerals.GetPreviousClosestNumber(number.Value);
            }
            return _romanNumerals.FormatUnitsSum(number, closestNumber);
        }
        var tensNumber = number.Value / 10;
        var romanNumeral = _romanNumerals.SearchRomanNumeralValue(10);
        return romanNumeral.PadLeft(tensNumber, Convert.ToChar(romanNumeral));
    }

    private string FormatUnitsRomanNumber(ArabicNumber number)
    {
        var closestNumber = _romanNumerals.GetClosestNumber(number.Value);
        if (IsSubtract(number, closestNumber))
        {
            return _romanNumerals.FormatUnitsSubtract(number, closestNumber);
        }
        if (IsClosestGreaterThanNumber(number, closestNumber))
        {
            closestNumber = _romanNumerals.GetPreviousClosestNumber(number.Value);
        }
        return _romanNumerals.FormatUnitsSum(number, closestNumber);
    }

    private bool IsSubtract(ArabicNumber number, int closestNumber)
    {
        return Math.Abs(number.Value - closestNumber) == 1 && closestNumber > number.Value;
    }

    private bool IsTensSubtract(ArabicNumber number, int closestNumber)
    {
        return Math.Abs(number.Value - closestNumber) == 10 && closestNumber > number.Value;
    }

    private bool IsClosestGreaterThanNumber(ArabicNumber number, int closestNumber)
    {
        return closestNumber > number.Value;
    }
}