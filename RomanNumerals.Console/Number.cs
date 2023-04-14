namespace RomanNumerals.Console;

public class Number
{
    private readonly RomanNumerals _romanNumerals;

    public Number(int value)
    {
        Value = value;
        _romanNumerals = new RomanNumerals();
    }

    public int Value { get; }
    public int ClosestNumber { get; set; }
    public int MaxValue { get; private set; }
    public int Position { get; set; }

    public List<string> NumberValueToList()
    {
        return string.Join(",", Value.ToString()
                .Select((item, index) => item.ToString().PadRight(Value.ToString().Length - index, '0')))
            .Split(",").Reverse().ToList();
    }

    public bool IsSubtract(Number number)
    {
        return Math.Abs(Value - ClosestNumber) == number.MaxValue && ClosestNumber > Value;
    }

    public bool IsClosestGreaterThanNumber()
    {
        return ClosestNumber > Value;
    }

    public string FormatSum(Number number)
    {
        var unitNumber = (number.Value - number.ClosestNumber) / 3;
        var result = _romanNumerals.SearchRomanNumeralValue(unitNumber);
        if (!string.IsNullOrEmpty(result))
        {
            return _romanNumerals.SearchRomanNumeralValue(number.ClosestNumber) +
                   result.PadLeft(3, Convert.ToChar(result));
        }

        return _romanNumerals.SearchRomanNumeralValue(number.ClosestNumber) +
               _romanNumerals.SearchRomanNumeralValue(number.Value - number.ClosestNumber);
    }

    public string FormatSubtract(Number number)
    {
        return _romanNumerals.SearchRomanNumeralValue(number.Value - number.ClosestNumber) +
               _romanNumerals.SearchRomanNumeralValue(number.ClosestNumber);
    }

    public void SetMaxValueForNumber()
    {
        MaxValue = Convert.ToInt32("1".PadRight(Position + 1, '0'));
    }
}