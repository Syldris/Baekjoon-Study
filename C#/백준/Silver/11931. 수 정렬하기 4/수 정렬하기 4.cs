using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
public class NewEmptyCSharpScript1
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        Array.Sort(arr);
        Array.Reverse(arr);
        StringBuilder sb = new StringBuilder();
        foreach (var item in arr)
        {
            sb.AppendLine(item.ToString());
        }
        Console.WriteLine(sb);
    }
}
