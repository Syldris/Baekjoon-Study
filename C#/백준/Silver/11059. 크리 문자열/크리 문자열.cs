#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string input = sr.ReadLine();

        int[] arr = new int[input.Length + 1];
        for (int i = 1; i <= input.Length; i++)
        {
            arr[i] = arr[i - 1] + input[i - 1] - '0';
        }
        int result = 0;

        for (int i = 1; i <= input.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if((i - j) % 2 == 1)
                    continue;
                int mid = (i + j) / 2;
                if (arr[i] - arr[mid] == arr[mid] - arr[j])
                {
                    result = Math.Max(result, i - j);
                }
            }
        }

        sw.Write(result);
    }
}
