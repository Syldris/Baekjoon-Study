#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        string[] text = new string[n];
        for (int i = 0; i < n; i++)
        {
            text[i] = sr.ReadLine();
        }

        int result = 0;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                int len = Math.Min(text[i].Length, text[j].Length);

                ReadOnlySpan<char> spanI = text[i].AsSpan();
                ReadOnlySpan<char> spanJ = text[j].AsSpan();

                for (int k = 1; k <= len; k++)
                {
                    if (spanI[^k..].SequenceEqual(spanJ[..k]))
                    {
                        result++;
                        break;
                    }
                    else if (spanI[..k].SequenceEqual(spanJ[^k..]))
                    {
                        result++;
                        break;
                    }
                }
            }
        }
        sw.Write(result);
    }
}