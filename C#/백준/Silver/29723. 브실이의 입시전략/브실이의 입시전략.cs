#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int k = int.Parse(input[2]);

        int result = 0;
        Dictionary<string, (int value, bool use)> hash = new Dictionary<string, (int value, bool use)>();
        for (int i = 0; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            hash.Add(line[0], (int.Parse(line[1]), false));
        }
        for (int i = 0; i < k; i++)
        {
            string key = sr.ReadLine();
            int keyvalue = hash[key].value;
            result += keyvalue;
            hash[key] = (keyvalue, true);
        }
        List<int> list = hash.Where(x => x.Value.use == false).OrderBy(x => x.Value.value).Select(x => x.Value.value).ToList();
        int min = result;
        int max = result;
        for (int i = 1; i <= m - k; i++)
        {
            min += list[i-1];
            max += list[^i];
        }
        sw.WriteLine($"{min} {max}");
    }
}
