#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        bool[] notPrime = new bool[n + 1];

        int sqrt = (int)Math.Floor(Math.Sqrt(n));

        for (int i = 2; i <= sqrt; i++)
        {
            for (int j = i * i; j <= n; j += i)
            {
                if (!notPrime[j])
                {
                    notPrime[j] = true;
                }
            }
        }

        List<int> prime = new List<int>();
        for (int i = 2; i <= n; i++)
        {
            if (!notPrime[i])
            {
                prime.Add(i);
            }
        }

        if (prime.Count == 0)
        {
            sw.Write(0);
            return;
        }

        int start = 0, end = 1;
        int value = prime[start];
        int result = 0;

        while (start < prime.Count)
        {
            if (end < prime.Count)
            {
                if (value == n)
                {
                    result++;
                    value += prime[end++];
                }
                else if (value > n)
                {
                    value -= prime[start++];
                }
                else
                {
                    value += prime[end++];
                }
            }
            else
            {
                if (value == n)
                {
                    result++;
                    break;
                }
                else
                {
                    value -= prime[start++];
                }
            }
        }
        sw.Write(result);
    }
}