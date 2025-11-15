using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Caclutator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Калькулятор\n");
            while (true)
            {
                try
                {
                    Console.Write("Введите операцию(+, -, /, * , ^, sqrt): ");
                    string sign = Console.ReadLine();

                    Console.WriteLine();

                    if (sign == "sqrt")
                    {
                        Console.Write("Введите операнд с точностью до 2-х знаков после запятой: ");
                        double firstOperand = Convert.ToDouble(Console.ReadLine());

                        double secondOperand = 0;
                        Console.WriteLine();

                        if (GetDoubleDigitsCount(firstOperand) > 2 || GetDoubleDigitsCount(secondOperand) > 2)
                        {
                            Console.WriteLine("Ошибка! Вы ввели слишком большое число или число с точностью больше 2-х знаков после запятой");
                            Console.WriteLine();
                            continue;
                        }

                        Console.WriteLine($"Результат: {Calculate(firstOperand, secondOperand, sign)}");
                    }
                    else 
                    {
                        Console.Write("Введите первый операнд с точностью до 2-х знаков после запятой: ");
                        double firstOperand = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine();

                        Console.Write("Введите второй операнд с точностью до 2-х знаков после запятой: ");
                        double secondOperand = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine();

                        if (GetDoubleDigitsCount(firstOperand) > 2 || GetDoubleDigitsCount(secondOperand) > 2)
                        {
                            Console.WriteLine("Ошибка! Вы ввели слишком большое число или число с точностью больше 2-х знаков после запятой");
                            Console.WriteLine();
                            continue;
                        }

                        if (sign == "/" && secondOperand == 0)
                        {
                            Console.WriteLine("Ошибка! Деление на 0.");
                            Console.WriteLine();
                            continue;
                        }

                        Console.WriteLine($"Результат: {Calculate(firstOperand, secondOperand, sign)}\n");
                    }


                    
                }

                catch (FormatException ex)
                {
                    Console.WriteLine("Неккоректное значение в поле 'операнд'.");
                    Console.WriteLine();
                }

                catch (OverflowException ex) 
                {
                    Console.WriteLine("Ошибка! Ваше число слишком большое.");
                }
            }
        }

        static string Calculate(double firstOp, double secondOp, string operation)
        {
                switch (operation)
                {
                    case "+":
                        return $"{Math.Round(firstOp + secondOp, 2)}";
                    case "-":
                        return $"{Math.Round(firstOp - secondOp, 2)}";
                    case "*":
                        return $"{Math.Round(firstOp * secondOp, 2)}";
                    case "/":
                        return $"{Math.Round(firstOp / secondOp, 2)}";
                    case "^":
                        return $"{Math.Round(Math.Pow(firstOp, secondOp), 2)}";
                    case "sqrt":
                        return $"{Math.Round(Math.Sqrt(firstOp), 2)}";
                    default:
                        return "Неизвестная операция!";

                }
        }


        static int GetDoubleDigitsCount(double numb) 
        {
            string[] parts = numb.ToString(new System.Globalization.NumberFormatInfo() { NumberDecimalSeparator = "." }).Split('.');
            if (parts.Length == 2) 
            {
                return parts[1].Length;
            }
            return 0;
        }
    }
}
