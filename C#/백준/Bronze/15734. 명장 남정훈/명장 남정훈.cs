#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int a = int.Parse(input[0]);
        int b = int.Parse(input[1]);
        int c = int.Parse(input[2]);    
        while (c > 0)
        {
            if (a <= b)
            {
                a++;
            }
            else
            {
                b++;
            }
            c--;
        }
        sw.Write(Math.Min(a, b) * 2);
    }
}
