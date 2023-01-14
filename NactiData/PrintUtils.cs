namespace NactiData;

public static class PrintUtils
{
    public static void PrintEnteredParamsOverview(double num1, double num2, double num3)
    {
        Console.Write("Jako vstupní parametry aplikace byla zadána čísla: ");
        Console.WriteLine($"{num1} {num2} {num3}");
    }

    public static void PrintWrongFormatMessage(FormatException e)
    {
        var eCause = ExtractExceptionCause(e.Message);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Parametr [{eCause}] je ve špatném formátu.");
        Console.ResetColor();
        Console.WriteLine("Vstupní parametry musí být celá, nebo desetinná čísla, oddělená mezerou, např.: 22 2,3 11");
    }

    private static string ExtractExceptionCause(string exceptionMessage)
    {
        var from = exceptionMessage.IndexOf("'", StringComparison.Ordinal) + 1;
        var to = exceptionMessage.LastIndexOf("'", StringComparison.Ordinal);
        var cause = exceptionMessage.Substring(from, to - from);
        return cause;
    }

    public static void PrintNotEnoughEnterParamsExceptionMessage()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Při spouštění aplikace nebyly zadány vstupní parametry.\n");
        Console.ResetColor();
        Console.WriteLine("Parametry můžete zadat nyní:");
        Console.WriteLine("============================");
    }

    public static void PrintZeroDivisionAttemptMessage()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Třetí parametr je nula. Nelze dělit nulou.");
        Console.ResetColor();
    }

    public static void PrintFirstResult(double num1, double num2, double num3)
    {
        Console.WriteLine();
        Console.WriteLine("Výsledek výpočtů:");
        Console.Write($"[{num1} + {num2} + {num3}] => ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(num1 + num2 + num3);
        Console.ResetColor();
    }

    public static void PrintSecondResult(double num1, double num2, double num3)
    {
        Console.Write($"[{num1} * {num2} * {num3}] => ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(num1 * num2 * num3);
        Console.ResetColor();
    }

    public static void PrintThirdResult(double num1, double num2, double num3)
    {
        Console.Write($"[({num1}+{num2}) / {num3}] => ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(SafeDivision(num1 + num2, num3));
        Console.ResetColor();
    }

    private static double SafeDivision(double x, double y)
    {
        if (y == 0)
            throw new DivideByZeroException();
        return Math.Round(x / y, 2);
    }

    public static void AskForFirstInput()
    {
        Console.Write("Zadejte první číslo a potvrďte klávesou Enter: ");
    }

    public static void AskForSecondInput()
    {
        Console.Write("Zadejte druhé číslo a potvrďte klávesou Enter: ");
    }

    public static void AskForThirdInput()
    {
        Console.Write("Zadejte třetí číslo a potvrďte klávesou Enter: ");
    }

    public static void PrintWrongInputFormatMessage()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(
            "Nesprávný formát, zadávejte celá, nebo desetinná čísla. Použijte čárku jako desetinný znak.\n");
        Console.ResetColor();
    }
}