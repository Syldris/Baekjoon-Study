#nullable disable
using System;
using System.Numerics;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int m = int.Parse(sr.ReadLine());

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(),int.Parse);
        Array.Sort(arr);
        int start = 0, end = n - 1;
        int result = 0;
        while (start < end)
        {
            int value = arr[start] + arr[end];
            if (value > m)
            {
                end--;
            }
            else if (value < m)
            {
                start++;
            }
            else
            {
                start++;
                end--;
                result++;
            }
        }
        sw.Write(result);

    }
}
