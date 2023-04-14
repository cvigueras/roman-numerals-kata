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
        var numberSplit = number.NumberValueToList();

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

    private string FormatTensRomanNumber(ArabicNumber number)
    {
        if (number.Value > 30)
        {
            number.ClosestNumber = _romanNumerals.GetClosestNumber(number.Value);
            if (number.IsTensSubtract())
            {
                return _romanNumerals.FormatUnitsSubtract(number);
            }
            if (number.IsClosestGreaterThanNumber())
            {
                number.ClosestNumber = _romanNumerals.GetPreviousClosestNumber(number.Value);
            }
            return _romanNumerals.FormatUnitsSum(number);
        }
        var tensNumber = number.Value / 10;
        var romanNumeral = _romanNumerals.SearchRomanNumeralValue(10);
        return romanNumeral.PadLeft(tensNumber, Convert.ToChar(romanNumeral));
    }

    private string FormatUnitsRomanNumber(ArabicNumber number)
    {
        number.ClosestNumber = _romanNumerals.GetClosestNumber(number.Value);
        if (number.IsSubtract())
        {
            return _romanNumerals.FormatUnitsSubtract(number);
        }
        if (number.IsClosestGreaterThanNumber())
        {
            number.ClosestNumber = _romanNumerals.GetPreviousClosestNumber(number.Value);
        }
        return _romanNumerals.FormatUnitsSum(number);
    }
}