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
        Dictionary<string, int> hash = new Dictionary<string, int>();
        for (int i = 0; i < n; i++)
        {
            string line = sr.ReadLine();
            if (hash.ContainsKey(line))
            {
                hash[line]++;
            }
            else
            {
                hash[line] = 1;
            }
        }
        int max = hash.Values.Max();
        string words = hash.Where(x => x.Value == max).Select(x => x.Key).Min();
        sw.Write(words);

    }
}
