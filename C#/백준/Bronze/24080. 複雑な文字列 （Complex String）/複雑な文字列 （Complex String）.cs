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
        string line = sr.ReadLine();
        HashSet<char> hash = new HashSet<char>();

        foreach (var item in line)
        {
            hash.Add(item);
        }

        sw.Write(hash.Count >= 3 ? "Yes" : "No");
    }
}
