namespace RomanNumerals.Console;

public class Calculate
{
    private readonly RomanNumerals _romanNumerals;
    private Number _number;

    public Calculate(Number number)
    {
        _romanNumerals = new RomanNumerals();
        _number = number;
    }

    public string RomanNumber()
    {
        var romanNumber = string.Empty;
        var numberSplit = _number.NumberValueToList();
        for (var i = 0; i < numberSplit.Count(); i++)
        {
            _number = new Number(Convert.ToInt32(numberSplit[i])) { Position = i };
            _number.SetMaxValueForNumber();
            romanNumber = FormatTensRomanNumber() + romanNumber;
        }
        return romanNumber;
    }

    private string FormatTensRomanNumber()
    {
        if (_number.Value == 0) return string.Empty;
        if (_number.Value > _number.MaxValue * 3) return FormatRomanNumber();
        var tensNumber = _number.Value / _number.MaxValue;
        var romanNumeral = _romanNumerals.SearchRomanNumeralValue(_number.MaxValue);
        return romanNumeral.PadLeft(tensNumber, Convert.ToChar(romanNumeral));
    }

    private string FormatRomanNumber()
    {
        _number.ClosestNumber = _romanNumerals.GetClosestNumber(_number.Value);
        if (_number.IsSubtract()) return _number.FormatSubtract();
            if (_number.ClosestNumber <= _number.Value) return FormatSum();
        _number.ClosestNumber = _romanNumerals.GetPreviousClosestNumber(_number.Value);
        return FormatSum();
    }

    public string FormatSum()
    {
        return !string.IsNullOrEmpty(_number.FormatTensSum())
            ? _number.FormatTensSum()
            : _number.FormatUnitSum();
    }
}