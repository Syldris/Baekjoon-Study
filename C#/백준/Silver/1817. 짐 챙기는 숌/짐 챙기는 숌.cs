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
        int m = int.Parse(input[1]);
        int[] arr = new int[n];
        if (n != 0)
        {
            arr = sr.ReadLine().Split().Select(int.Parse).ToArray();
        }

        int box = 1;
        int curweight = 0;
        for (int i = 0; i < n; i++)
        {
            if (curweight + arr[i] <= m)
            {
                curweight += arr[i];
            }
            else
            {
                box++;
                curweight = arr[i];
            }
        }
        sw.Write(n != 0 ? box : 0);
    }
}
