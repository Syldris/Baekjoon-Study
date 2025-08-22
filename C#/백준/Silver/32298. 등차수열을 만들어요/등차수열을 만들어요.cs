#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        const int limit = 2000000;

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        bool[] prime = new bool[limit + 1];
        for (int i = 2; i * i <= limit; i++)
        {
            if (!prime[i])
            {
                for (int j = i * i; j <= limit; j+=i)
                {
                    prime[j] = true;
                }
            }
        }
        prime[1] = true;
        int start = -1;
        for (int i = 1; i + (n - 1) * m <= limit; i++)
        {
            bool possible = true;
            for (int j = 0; j < n; j++)
            {
                int value = i + j * m;
                if (!prime[value])
                {
                    possible = false;
                    break;
                }
            }
            if (possible)
            {
                start = i;
                break;
            }
        }
        if (start == -1)
        {
            sw.Write(-1);
            return;
        }
        int[] arr = new int[n];
        arr[0] = start;
        for (int i = 1; i < n; i++)
        {
            arr[i] = start + m;
            start += m;
        }
        sw.Write(String.Join(" ", arr));
    }
}
