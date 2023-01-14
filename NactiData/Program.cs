using static NactiData.PrintUtils;

var num1 = 0.0;
var num2 = 0.0;
var num3 = 0.0;


try
{
    num1 = double.Parse(args[0]);
    num2 = double.Parse(args[1]);
    num3 = double.Parse(args[2]);
    PrintEnteredParamsOverview(num1, num2, num3);
}
catch (Exception ex)
{
    switch (ex)
    {
        case FormatException e:
        {
            PrintWrongFormatMessage(e);
            return;
        }
        case IndexOutOfRangeException:
            PrintNotEnoughEnterParamsExceptionMessage();

            while (true)
                try
                {
                    AskForFirstInput();
                    num1 = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                    AskForSecondInput();
                    num2 = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                    AskForThirdInput();
                    num3 = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                    break;
                }
                catch
                {
                    PrintWrongInputFormatMessage();
                }

            break;
    }
}

PrintFirstResult(num1, num2, num3);
PrintSecondResult(num1, num2, num3);

try
{
    PrintThirdResult(num1, num2, num3);
}
catch (DivideByZeroException)
{
    PrintZeroDivisionAttemptMessage();
}