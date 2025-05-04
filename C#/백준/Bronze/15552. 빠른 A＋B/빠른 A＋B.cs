using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StringBuilder sb = new StringBuilder();
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            sb.Append(line[0] + line[1]).Append("\n");
        }
        sw.WriteLine(sb);
        sr.Close();
        sw.Close();
    }
}