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
            for (int j = 1; j < i; j++)
            {
                for (int k = 0; k < j; k++)
                {
                    if((i - k) % 2 != 0)
                        continue;
                    if ((j - k) == (i - j))
                    {
                        if (arr[j] - arr[k] == arr[i] - arr[j])
                        {
                            result = Math.Max(result, i - k);
                        }
                    }
                }
            }
        }

        sw.Write(result);
    }
}
