namespace RomanNumerals.Console;

public class Calculator
{
    private readonly Dictionary<int, string> _romanNumerals;

    public Calculator()
    {
        _romanNumerals = new Dictionary<int, string>
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
    public string GetRomanNumber(int number)
    {
        if (number == 4)
        {
            return "IV";
        }
        var result = _romanNumerals.FirstOrDefault(x=> x.Key == number).Value;
        return string.IsNullOrEmpty(result) ? string.Empty : result;
    }
}