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
        int day = int.Parse(input[1]);

        long result = 0;
        int[] input2 = sr.ReadLine().Split().Select(int.Parse).ToArray();

        int[] arr = new int[300001];

        int max = 0;
        for (int i = 0; i < n; i++)
        {
            int height = input2[i];
            arr[height]++;
            if (height > max)
            {
                max = height;
            }
        }

        for (int i = max; i > 0; i--)
        {
            result += arr[i];
            if (--day == 0)
            {
                break;
            }
            arr[i - 1] += arr[i];
        }
        sw.Write(result);
    }
}