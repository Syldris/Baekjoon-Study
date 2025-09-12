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
        string text = sr.ReadLine();
        int result = 0;
        for (int i = 0; i < n; i++)
        {
            string line = sr.ReadLine();
            List<int>[] graph = new List<int>[text.Length];

            for (int j = 0; j < text.Length; j++)
            {
                char c = text[j];
                graph[j] = new List<int>();
                for (int k = 0; k < line.Length; k++)
                {
                    if (line[k] == c)
                    {
                        graph[j].Add(k);
                    }
                }
            }
            bool Check()
            {
                foreach (var start in graph[0])
                {
                    foreach (var next in graph[1])
                    {
                        int value = next - start;
                        bool valid = true;
                        if (value < 0)
                        {
                            continue;
                        }
                        for (int k = 2; k < text.Length; k++)
                        {
                            int cur = start + value * k;
                            if (!graph[k].Contains(cur))
                            {
                                valid = false;
                                break;
                            }
                        }
                        if (valid)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            result += Check() ? 1 : 0;
        }
        sw.Write(result);
    }
}
