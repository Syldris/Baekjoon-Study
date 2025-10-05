#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        int[,] arr = new int[31, 31];

        arr[1, 1] = 1;
        for (int i = 2; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                arr[i, j] = arr[i - 1, j] + arr[i - 1, j - 1];
            }
        }
        sw.Write(arr[n, k]);
    }
}