// can add (optional) error messages and further input (range) validation
public static class UserInputHandler
{

    public static decimal GetValidDecimal(string output)
    {
        decimal? input = null;
        while (!input.HasValue)
        {
            Console.Write(output);
            input = decimal.TryParse(Console.ReadLine(), out decimal d) ? d : new decimal?();
        }
        return (decimal)input;
    }

    public static int GetValidInt(string output)
    {
        int? input = null;
        while (!input.HasValue)
        {
            Console.Write(output);
            input = int.TryParse(Console.ReadLine(), out int i) ? i : new int?();
        }
        return (int)input;
    }

    public static string GetValidString(string output)
    {
        string? input = null;
        while (String.IsNullOrWhiteSpace(input))
        {
            Console.Write(output);
            input = Console.ReadLine();
        }
        return (string)input;
    }
}