#nullable disable
using System;
using System.Linq;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        while (true)
        {
            HashSet<char> hash = new HashSet<char>();
            string line = sr.ReadLine().ToLower();
            if(line == "#")
                break;
            foreach (var item in line)
            {
                if (item >= 'a' && item <= 'z')
                    hash.Add(item);
            }
            sw.WriteLine(hash.Count);
        }
    }
}
