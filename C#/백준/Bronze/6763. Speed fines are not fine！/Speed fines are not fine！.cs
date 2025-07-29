#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int a = int.Parse(sr.ReadLine());
        int b = int.Parse(sr.ReadLine());

        if (b <= a)
        {
            sw.Write("Congratulations, you are within the speed limit!");
        }
        else
        {
            int result = 0;
            if (b - a > 30)
            {
                result = 500;
            }
            else if (b - a > 20)
            {
                result = 270;
            }
            else
            {
                result = 100;
            }
            sw.Write($"You are speeding and your fine is ${result}.");
        }
    }
}
