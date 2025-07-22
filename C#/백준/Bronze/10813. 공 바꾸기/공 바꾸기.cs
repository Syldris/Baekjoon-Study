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
        int m = int.Parse(input[1]);

        int[] arr = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            arr[i] = i;
        }


        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);
            (arr[a], arr[b]) = (arr[b], arr[a]);
        }

        sw.Write(string.Join(" ", arr.Skip(1)));
    }
}
