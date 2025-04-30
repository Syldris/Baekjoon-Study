using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        int[] arr = new int[8];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        var top5 = arr.Select((value, index) => new { Value = value, Index = index }).OrderByDescending(x => x.Value).Take(5);

        int totalnum = 0;
        List<int> index = new List<int>();
        foreach (var item in top5)
        {
            totalnum += item.Value;
            index.Add(item.Index + 1);
        }
        index.Sort();
        Console.WriteLine(totalnum);
        Console.WriteLine(String.Join(" ", index));
    }
}