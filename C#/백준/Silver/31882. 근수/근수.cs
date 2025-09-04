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
        long[] sum = new long[n+1];
        long[] score = new long[n+1];
        for (int i = 1; i <= n; i++)
        {
            sum[i] = sum[i - 1] + i;
        }
        for (int i = 1; i <= n; i++)
        {
            score[i] = score[i-1] + sum[i];
        }

        long result = 0;
        string line = sr.ReadLine();
        int cur = 0;
        foreach (var item in line)
        {
            if (item == '2')
            {
                cur++;
            }
            else
            {
                result += score[cur];
                cur = 0;
            }
        }
        result += score[cur];
        sw.Write(result);
    }
}
