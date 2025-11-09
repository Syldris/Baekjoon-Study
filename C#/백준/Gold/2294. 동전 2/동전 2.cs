#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        int[] arr = new int[n];
        int[] coins = new int[k + 1];
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(sr.ReadLine());
        }

        const int max = 1000000;
        Array.Fill(coins, max);

        coins[0] = 0;

        for (int i = 0; i <= k; i++)
        {
            foreach (var item in arr)
            {
                int index = i + item;
                if(index <= k)
                    coins[index] = Math.Min(coins[index], coins[i] + 1);
            }
        }
        sw.Write(coins[k] == max ? -1 : coins[k]);
    }
}