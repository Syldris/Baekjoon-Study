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
        int k = int.Parse(input[1]);

        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int result = int.MaxValue;

        for (int i = 0; i < n; i++)
        {
            if (arr[i] <= i * k)
            {
                continue;
            }
            int value = 0;
            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] != arr[i] + (j - i) * k)
                {
                    value++;
                }
            }
            for (int j = i - 1; j >= 0; j--)
            {
                if (arr[j] != arr[i] - (i - j) * k)
                {
                    value++;
                }
            }
            result = Math.Min(result, value);

        }
        sw.Write(result);
    }
}