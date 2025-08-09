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
            string text = line[0];
            int start = int.Parse(line[1]);
            int end = int.Parse(line[2]);
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < text.Length; j++)
            {
                if (j >= start && j < end)
                {
                    continue;
                }
                sb.Append(text[j]);
            }
            sw.WriteLine(sb);
        }
    }
}
