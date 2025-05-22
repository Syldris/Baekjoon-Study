using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput());
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int[] arrint = new int[n];

        arrint = sr.ReadLine().Split().Select(int.Parse).ToArray();
        StringBuilder sb = new StringBuilder();

        int[] arr = new int[n+1];

        for (int i = 1; i <= n; i++)
        {
            arr[i] = arr[i - 1] + arrint[i - 1];
        }

        for (int i = 0; i < m; i++)
        {
            string[] text = sr.ReadLine().Split();
            int k = int.Parse(text[0]);
            int p = int.Parse(text[1]);
            int count = arr[p] - arr[k-1];
            sb.Append(count).Append("\n");
        }
        sw.Write(sb.ToString());
    }
}
