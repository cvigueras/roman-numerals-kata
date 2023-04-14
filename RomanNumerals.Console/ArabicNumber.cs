namespace RomanNumerals.Console;

public class ArabicNumber
{
    public ArabicNumber(int value)
    {
        Value = value;
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

    public bool IsTensSubtract()
    {
        return Math.Abs(Value - ClosestNumber) == 10 && ClosestNumber > Value;
    }

    public bool IsClosestGreaterThanNumber()
    {
        return ClosestNumber > Value;
    }
}