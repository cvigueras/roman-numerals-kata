namespace RomanNumerals.Console;

public class Number
{
    public Number(int value)
    {
        Value = value;
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

    public int TakeFirstDigit()
    {
        var total = Math.Abs(Value - ClosestNumber);
        if (total == 0)
            return 1;
        if ((int)Math.Floor(Math.Log10(total) + 1) >= 1)
            return (int)Math.Truncate((total / Math.Pow(10, (int)Math.Floor(Math.Log10(total) + 1) - 1)));
        return total;
    }

    public void SetMaxValueForNumber()
    {
        MaxValue = Convert.ToInt32("1".PadRight(Position + 1, '0'));
    }
}