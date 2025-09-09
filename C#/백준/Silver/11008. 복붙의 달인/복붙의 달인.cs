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
        for (int i = 0; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            string s = line[0];
            string p = line[1];

            int result = 0;
            StringBuilder sb = new StringBuilder();
            foreach (var item in s)
            {
                sb.Append(item);
                if (sb.ToString().Contains(p))
                {
                    sb.Remove(0, sb.Length);
                    result -= p.Length - 1;
                }
                result++;
            }
            sw.WriteLine(result);
        }
    }
}
