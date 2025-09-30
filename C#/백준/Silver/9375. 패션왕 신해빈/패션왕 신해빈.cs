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

        int testcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < testcase; t++)
        {
            int n = int.Parse(sr.ReadLine());
            Dictionary<string,int> hash = new Dictionary<string,int>();
            for (int i = 0; i < n; i++)
            {
                string[] line = sr.ReadLine().Split();
                if (hash.ContainsKey(line[1]))
                {
                    hash[line[1]]++;
                }
                else
                {
                    hash.Add(line[1], 1);
                }
            }
            int result = 1;
            foreach (var item in hash)
            {
                result *= item.Value+1;
            }
            sw.WriteLine(result-1);
        }
    }
}
