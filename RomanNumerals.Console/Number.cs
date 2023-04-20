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

    public string FormatTensSum()
    {
        var result = GetMinimumDivisor();
        return !string.IsNullOrEmpty(result)
            ? _romanNumerals.SearchRomanNumeralValue(ClosestNumber) +
              result.PadLeft(TakeFirstDigit(), Convert.ToChar(result))
            : string.Empty;
    }

    private string GetMinimumDivisor()
    {
        var unitNumber = (Value - ClosestNumber) / TakeFirstDigit();
        return _romanNumerals.SearchRomanNumeralValue(unitNumber);
    }

    public string FormatSubtract()
    {
        return _romanNumerals.SearchRomanNumeralValue(Value - ClosestNumber) +
               _romanNumerals.SearchRomanNumeralValue(ClosestNumber);
    }

    public string FormatUnitSum()
    {
        return _romanNumerals.SearchRomanNumeralValue(ClosestNumber) +
               _romanNumerals.SearchRomanNumeralValue(Value - ClosestNumber);
    }

    public void SetMaxValueForNumber()
    {
        MaxValue = Convert.ToInt32("1".PadRight(Position + 1, '0'));
    }
}