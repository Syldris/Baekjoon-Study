#nullable disable
using System;
using System.Text;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int value = int.Parse(sr.ReadLine());
        int n = int.Parse(sr.ReadLine());
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(sr.ReadLine());
        }

        int curValue = 0;
        int result = 0;
        Array.Sort(arr);
        foreach (var item in arr)
        {
            if (curValue + item <= value)
            {
                curValue += item;
                result++;
            }
        }
        sw.WriteLine(result);
    }
}
