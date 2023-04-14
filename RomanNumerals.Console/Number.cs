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

    public List<string> NumberValueToList()
    {
        return string.Join(",", Value.ToString()
                .Select((item, index) => item.ToString().PadRight(Value.ToString().Length - index, '0')))
            .Split(",").Reverse().ToList();
    }

    public bool IsSubtract(int value)
    {
        return Math.Abs(Value - ClosestNumber) == value && ClosestNumber > Value;
    }

    public bool IsClosestGreaterThanNumber()
    {
        return ClosestNumber > Value;
    }

    public string FormatUnitsSum(Number number)
    {
        return _romanNumerals.SearchRomanNumeralValue(number.ClosestNumber) +
               _romanNumerals.SearchRomanNumeralValue(number.Value - number.ClosestNumber);
    }

    public string FormatUnitsSubtract(Number number)
    {
        return _romanNumerals.SearchRomanNumeralValue(number.Value - number.ClosestNumber) +
               _romanNumerals.SearchRomanNumeralValue(number.ClosestNumber);
    }
}