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
        int start = int.Parse(input[1]);
        int end = int.Parse(input[2]);

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int[] sort = arr[(start - 1)..end];

        Array.Sort(sort);
        for (int i = start; i <= end; i++)
        {
            arr[i - 1] = sort[i - start];
        }

        int prev = arr[0];
        bool result = true;
        foreach (var item in arr)
        {
            if (prev > item)
            {
                result = false;
                break;
            }
            prev = item;
        }
        sw.Write(result ? 1 : 0);
    }
}