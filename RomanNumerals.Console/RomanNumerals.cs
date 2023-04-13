namespace RomanNumerals.Console;

public class RomanNumerals
{
    public readonly Dictionary<int, string> Values;

    public RomanNumerals()
    {
        Values = new Dictionary<int, string>
        {
            {1, "I"},
            {2, "II"},
            {3, "III"},
            {5, "V"},
            {10, "X"},
            {50, "L"},
            {100, "C"},
            {500, "D"},
            {1000, "M"},
        };
    }
}