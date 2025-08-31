#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            int value = int.Parse(sr.ReadLine());
            int result = 1;
            if (value <= 4500)
            {
                result++;
                if (value <= 1000)
                {
                    result++;
                    if (value <= 25)
                    {
                        result++;
                    }
                }
            }
            if (result <= 3)
                sw.WriteLine($"Case #{i}: Round {result}");
            else
                sw.WriteLine($"Case #{i}: World Finals");
        }
    }
}
