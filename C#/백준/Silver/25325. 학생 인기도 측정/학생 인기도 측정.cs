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
        string[] line = sr.ReadLine().Split();
        Dictionary<string, int> hash = new Dictionary<string, int>();

        foreach (var item in line)
        {
            hash.Add(item, 0);
        }

        for (int i = 0; i < n; i++)
        {
            string[] input = sr.ReadLine().Split();
            foreach (var item in input)
            {
                hash[item]++;
            }
        }
        string[] result = hash.OrderByDescending(x => x.Value).Select(x => x.Key).ToArray();

        foreach (var item in result)
        {
            sw.WriteLine($"{item} {hash[item]}");
        }
    }
}
