using System;
class Calci
{
    static void Main(string[] args)
    {
        Console.Write("Enter number1:");
        string? input1 = Console.ReadLine();
        if (!double.TryParse(input1, out double num1))
        {
            Console.WriteLine("Invalid num1");
            return;
        }

        Console.Write("Enter operator:");
        string? op = Console.ReadLine();
        if (string.IsNullOrEmpty(op))
        {
            Console.WriteLine("Invalid operator");
            return;
        }

        Console.Write("Enter number2:");
        string? input2 = Console.ReadLine();
        if (!double.TryParse(input2, out double num2))
        {
            Console.WriteLine("Invalid num2");
            return;
        }

        double result = 0;

        switch (op)
        {
            case "+":
                result = num1 + num2;
                break;

            case "-":
                result = num1 - num2;
                break;

            case "*":
                result = num1 * num2;
                break;

            case "/":
                if (num2 != 0)
                {
                    result = num1 / num2;
                    break;
                }
                else
                {
                    Console.Write("Cannot be divided by zero");
                    break;
                }
        }
        Console.WriteLine("Result: " + result);
    }
}