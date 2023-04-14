namespace RomanNumerals.Console;

public class Calculate
{
    private readonly RomanNumerals _romanNumerals;

    public Calculate()
    {
        _romanNumerals = new RomanNumerals();
    }

    public string RomanNumber(Number number)
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
                romanNumber += FormatRomanNumber(new Number(Convert.ToInt32(numberSplit[0])), 1);
            }

            if (i == 1)
            {
                romanNumber = FormatTensRomanNumber(new Number(Convert.ToInt32(numberSplit[1])), 10) + romanNumber;
            }

            if (i == 2)
            {
                romanNumber = FormatTensRomanNumber(new Number(Convert.ToInt32(numberSplit[2])), 100) + romanNumber;
            }
        }
        return romanNumber;
    }

    private string FormatTensRomanNumber(Number number, int value)
    {
        if (number.Value == 0)
        {
            return string.Empty;
        }
        if (number.Value > value * 3)
        {
            return FormatRomanNumber(number, value);
        }
        var tensNumber = number.Value / value;
        var romanNumeral = _romanNumerals.SearchRomanNumeralValue(value);
        return romanNumeral.PadLeft(tensNumber, Convert.ToChar(romanNumeral));
    }

    private string FormatRomanNumber(Number number, int value)
    {
        number.ClosestNumber = _romanNumerals.GetClosestNumber(number.Value);
        if (number.IsSubtract(value))
        {
            return number.FormatUnitsSubtract(number);
        }
        if (number.IsClosestGreaterThanNumber())
        {
            number.ClosestNumber = _romanNumerals.GetPreviousClosestNumber(number.Value);
        }
        return number.FormatUnitsSum(number);
    }
}