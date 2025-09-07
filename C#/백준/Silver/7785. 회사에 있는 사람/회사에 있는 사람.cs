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
        Dictionary<string, bool> hash = new Dictionary<string, bool>();
        for (int i = 0; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            bool work = line[1] == "enter" ? true : false;
            hash[line[0]] = work;
        }

        string[] result = hash.Where(x => x.Value == true).Select(x => x.Key).OrderByDescending(x => x).ToArray();

        for (int i = 0; i < result.Length; i++)
        {
            sw.WriteLine(result[i]);
        }

    }
}
