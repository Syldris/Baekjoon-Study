#nullable disable
using System;
using System.Numerics;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        List<int> list = new List<int>();
        string[] input = sr.ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int pos = 0;
        int result = 0;
        for (int i = 0; i < n; i++)
        {
            string[] line = sr.ReadLine().Split(' ');
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);
            for (int k = 0; k < a; k++)
            {
                list.Add(b);
            }
        }
        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split(' ');
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);

            for (int k = 0; k < a; k++)
            {
                result = Math.Max(result, b - list[pos]);
                pos++;
            }
        }
        sw.Write(result);
    }
}
