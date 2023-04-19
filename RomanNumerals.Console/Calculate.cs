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
        var romanNumber = string.Empty;
        var numberSplit = number.NumberValueToList();

        for (var i = 0; i < numberSplit.Count(); i++)
        {
            number = new Number(Convert.ToInt32(numberSplit[i]))
            {
                Position = i
            };
            number.SetMaxValueForNumber();
            romanNumber = FormatTensRomanNumber(number) + romanNumber;
        }
        return romanNumber;
    }

    private string FormatTensRomanNumber(Number number)
    {
        if (number.Value == 0)
        {
            return string.Empty;
        }

        if (number.Value > number.MaxValue * 3)
        {
            return FormatRomanNumber(number);
        }

        var tensNumber = number.Value / number.MaxValue;
        var romanNumeral = _romanNumerals.SearchRomanNumeralValue(number.MaxValue);
        return romanNumeral.PadLeft(tensNumber, Convert.ToChar(romanNumeral));
    }

    private string FormatRomanNumber(Number number)
    {
        number.ClosestNumber = _romanNumerals.GetClosestNumber(number.Value);
        if (number.IsSubtract())
        {
            return number.FormatSubtract();
        }
        if (number.IsClosestGreaterThanNumber())
        {
            number.ClosestNumber = _romanNumerals.GetPreviousClosestNumber(number.Value);
        }
        return number.FormatSum();
    }
}