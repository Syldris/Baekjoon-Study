#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int testcase = int.Parse(sr.ReadLine());

        bool[] prime = new bool[318138];
        Array.Fill(prime, true);
        prime[1] = false;

        for (int i = 2; i < 566; i++)
        {
            if (!prime[i])
            {
                continue;
            }

            for (int j = i; i * j < prime.Length; j++)
            {
                prime[i * j] = false;
            }
        }

        int[] supurprime = new int[3001];
        int value = 1;
        int index = 1;
        for (int i = 2; i < prime.Length; i++)
        {
            if (prime[i] && prime[index++])
            {
                supurprime[value++] = i;
            }
        }

        for (int i = 0; i < testcase; i++)
        {
            int n = int.Parse(sr.ReadLine());
            sw.WriteLine(supurprime[n]);
        }
    }

}