#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int a = int.Parse(input[1]);
        int b = int.Parse(input[2]);

        int result = 0;
        while (a != b)
        {
            if (a % 2 == 1)
                a++;
            if (b % 2 == 1)
                b++;

            a /= 2;
            b /= 2;
            result++;
        }
        sw.Write(result);
    }
}
