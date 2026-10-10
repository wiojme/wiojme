using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите число: ");
        string num = Console.ReadLine();

        Console.Write("Основание исходной системы (2–36): ");
        if (!int.TryParse(Console.ReadLine(), out int fromBase) || fromBase < 2 || fromBase > 36)
        {
            Console.WriteLine("Неверное основание.");
            return;
        }

        Console.Write("Основание целевой системы (2–36): ");
        if (!int.TryParse(Console.ReadLine(), out int toBase) || toBase < 2 || toBase > 36)
        {
            Console.WriteLine("Неверное основание.");
            return;
        }

        
        long dec = 0;
        long power = 1;
        string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        for (int i = num.Length - 1; i >= 0; i--)
        {
            char c = char.ToUpper(num[i]);
            int digit = digits.IndexOf(c);

            if (digit == -1 || digit >= fromBase)
            {
                Console.WriteLine($"Недопустимый символ '{c}' для основания {fromBase}.");
                return;
            }

            dec += digit * power;

            
            if (i > 0 && power > long.MaxValue / fromBase)
            {
                Console.WriteLine("Число слишком большое.");
                return;
            }
            power *= fromBase;
        }

        
        if (dec == 0)
        {
            Console.WriteLine("Результат: 0");
            return;
        }

        string result = "";
        while (dec > 0)
        {
            int rem = (int)(dec % toBase);
            result = digits[rem] + result;
            dec /= toBase;
        }

        Console.WriteLine("Результат: " + result);
        Console.ReadKey();
    }
}
