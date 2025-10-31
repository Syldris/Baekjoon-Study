#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int testcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < testcase; t++)
        {
            string line = sr.ReadLine();
            int n = (int)Math.Sqrt(line.Length);
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    sb.Append(line[j * n - i]);
                }
            }
            sw.WriteLine(sb);
        }
    }
}