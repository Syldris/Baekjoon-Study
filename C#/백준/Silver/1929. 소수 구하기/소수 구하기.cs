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
        int m = int.Parse(input[1]);

        bool[] prime = new bool[1000001];
        Array.Fill(prime, true);
        prime[1] = false;
        for (int i = 2; i <= 1000; i++)
        {
            if (prime[i])
            {
                for (int j = i; i * j <= m; j++)
                {
                    prime[i * j] = false;
                }
            }
        }
        for (int i = n; i <= m; i++)
        {
            if (prime[i])
            {
                sw.WriteLine(i);
            }
        }
    }

}