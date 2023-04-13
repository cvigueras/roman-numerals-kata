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

    public string SearchRomanNumeralValue(int number)
    {
        return Values.FirstOrDefault(x => x.Key == Math.Abs(number)).Value;
    }

    public int GetPreviousClosestNumber(int number)
    {
        return Values.Keys.TakeWhile(x => x != GetClosestNumber(number)).LastOrDefault();
    }

    public int GetClosestNumber(int number)
    {
        return Values.Aggregate((x,
            y) => Math.Abs(x.Key - number) < Math.Abs(y.Key - number)
            ? x
            : y).Key;
    }

    public string FormatUnitsSum(ArabicNumber number, int closestNumber)
    {
        return SearchRomanNumeralValue(closestNumber) +
               SearchRomanNumeralValue(number.Value - closestNumber);
    }

    public string FormatUnitsSubtract(ArabicNumber number, int closestNumber)
    {
        return SearchRomanNumeralValue(number.Value - closestNumber) +
               SearchRomanNumeralValue(closestNumber);
    }
}