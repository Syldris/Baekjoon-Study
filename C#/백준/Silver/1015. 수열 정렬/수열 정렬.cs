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
        int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();
        (int value, int index)[] arr = new (int value, int index)[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = (input[i], i);
        }
        arr = arr.OrderBy(x => x.value).ThenBy(x=>x.index).ToArray();
        for (int i = 0; i < n; i++)
        {
            input[arr[i].index] = i;
        }
        sw.WriteLine(String.Join(" ", input));
    }
}
