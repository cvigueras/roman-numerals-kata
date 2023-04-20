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
            romanNumber = FormatRomanNumber() + romanNumber;
        }
        return romanNumber;
    }

    private string FormatRomanNumber()
    {
        if (_number.Value == 0) return string.Empty;
        if (_number.Value > _number.MaxValue * 3) return FormatTensRomanNumber();
        var romanNumeral = _romanNumerals.SearchRomanNumeralValue(_number.MaxValue);
        return romanNumeral.PadLeft(_number.Value / _number.MaxValue, Convert.ToChar(romanNumeral));
    }

    private string FormatTensRomanNumber()
    {
        _number.ClosestNumber = _romanNumerals.GetClosestNumber(_number.Value);
        if (_number.IsSubtract()) return FormatSubtract();
            if (_number.ClosestNumber <= _number.Value) return FormatSum();
        _number.ClosestNumber = _romanNumerals.GetPreviousClosestNumber(_number.Value);
        return FormatSum();
    }

    private string FormatSum()
    {
        return !string.IsNullOrEmpty(FormatTensSum())
            ? FormatTensSum()
            : FormatUnitSum();
    }

    private string FormatTensSum()
    {
        var result = GetMinimumDivisorInRoman();
        return !string.IsNullOrEmpty(result)
            ? _romanNumerals.SearchRomanNumeralValue(_number.ClosestNumber) +
              result.PadLeft(_number.TakeFirstDigit(), Convert.ToChar(result))
            : string.Empty;
    }

    private string GetMinimumDivisorInRoman()
    {
        var unitNumber = (_number.Value - _number.ClosestNumber) / _number.TakeFirstDigit();
        return _romanNumerals.SearchRomanNumeralValue(unitNumber);
    }

    private string FormatSubtract()
    {
        return _romanNumerals.SearchRomanNumeralValue(_number.Value - _number.ClosestNumber) +
               _romanNumerals.SearchRomanNumeralValue(_number.ClosestNumber);
    }

    public string FormatUnitSum()
    {
        return _romanNumerals.SearchRomanNumeralValue(_number.ClosestNumber) +
               _romanNumerals.SearchRomanNumeralValue(_number.Value - _number.ClosestNumber);
    }
}