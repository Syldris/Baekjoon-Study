using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        sw.Write(sb);
        sw.Close(); 
    }
}
