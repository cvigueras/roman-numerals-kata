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

    public bool IsSubtract()
    {
        return Math.Abs(Value - ClosestNumber) == MaxValue && ClosestNumber > Value;
    }

    private int TakeFirstDigit()
    {
        var total = Math.Abs(Value - ClosestNumber);
        if (total == 0)
            return 1;
        if ((int)Math.Floor(Math.Log10(total) + 1) >= 1)
            return (int)Math.Truncate((total / Math.Pow(10, (int)Math.Floor(Math.Log10(total) + 1) - 1)));
        return total;
    }

    public string FormatSum()
    {
        return !string.IsNullOrEmpty(FormatTensSum())
            ? FormatTensSum()
            : _romanNumerals.SearchRomanNumeralValue(ClosestNumber) +
              _romanNumerals.SearchRomanNumeralValue(Value - ClosestNumber);

    }

    private string FormatTensSum()
    {
        var firstDigit = TakeFirstDigit();
        var unitNumber = (Value - ClosestNumber) / firstDigit;
        var result = _romanNumerals.SearchRomanNumeralValue(unitNumber);
        if (!string.IsNullOrEmpty(result))
        {
            return _romanNumerals.SearchRomanNumeralValue(ClosestNumber) +
                   result.PadLeft(firstDigit, Convert.ToChar(result));
        }

        return string.Empty;
    }

    public string FormatSubtract()
    {
        return _romanNumerals.SearchRomanNumeralValue(Value - ClosestNumber) +
               _romanNumerals.SearchRomanNumeralValue(ClosestNumber);
    }

    public void SetMaxValueForNumber()
    {
        MaxValue = Convert.ToInt32("1".PadRight(Position + 1, '0'));
    }
}