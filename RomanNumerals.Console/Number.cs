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
        if (number.Value - number.ClosestNumber >= 30)
        {
            var unitNumber = (number.Value - number.ClosestNumber) / 3;
            var result = _romanNumerals.SearchRomanNumeralValue(unitNumber);
            return _romanNumerals.SearchRomanNumeralValue(number.ClosestNumber) +
                   result.PadLeft(3, Convert.ToChar(result));
        }
        return _romanNumerals.SearchRomanNumeralValue(number.ClosestNumber) +
               _romanNumerals.SearchRomanNumeralValue(number.Value - number.ClosestNumber);
    }

    public string FormatUnitsSubtract(Number number)
    {
        return _romanNumerals.SearchRomanNumeralValue(number.Value - number.ClosestNumber) +
               _romanNumerals.SearchRomanNumeralValue(number.ClosestNumber);
    }

    public void SetMaxValueForNumber(int i)
    {
        MaxValue = Convert.ToInt32("1".PadRight(i + 1, '0'));
    }
}