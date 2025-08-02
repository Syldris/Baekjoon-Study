#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        while (true)
        {
            string[] line = sr.ReadLine().Split();
            int n = int.Parse(line[0]);
            int m = int.Parse(line[1]);

            if(n == 0 && m == 0)
                return;

            HashSet<int> hash = new HashSet<int>();
            int result = 0;

            for (int i = 0; i < n; i++)
            {
                hash.Add(int.Parse(sr.ReadLine()));
            }

            for (int i = 0; i < m; i++)
            {
                if (hash.Contains(int.Parse(sr.ReadLine())))
                {
                    result++;
                }
            }
            sw.WriteLine(result);
        }
    }
}
