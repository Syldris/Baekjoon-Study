using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        string[] nm = Console.ReadLine().Split();
        int n = int.Parse(nm[0]);
        int m = int.Parse(nm[1]);

        int[] arr = new int[n+m];

        int[] ints1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] ints2 = Console.ReadLine().Split().Select(int.Parse).ToArray();


        for (int i = 0; i < n; i++)
        {
            arr[i] = ints1[i];
        }

        for (int i = n; i < arr.Length; i++)
        {
            arr[i] = ints2[i - n];
        }

        Array.Sort(arr);

        StringBuilder sb = new StringBuilder();
        foreach (var item in arr)
        {
            sb.Append($"{item} ");
        }

        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        sw.WriteLine(sb);
        sw.Flush();

    }
}
