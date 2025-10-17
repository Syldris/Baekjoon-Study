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
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int cur = 0;
        int result = 0;
        for (int i = 0; i < n; i++)
        {
            if (arr[i] > cur)
            {
                cur = arr[i];
            }
            else
            {
                cur = arr[i];
                result++;
            }
        }

        if (arr[^1] >= arr[0])
            result++;

        sw.Write(result);
    }
}