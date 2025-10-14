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
        Dictionary<string,int> hash = new Dictionary<string,int>();
        for (int i = 0; i < 2*n-1; i++)
        {
            string line = sr.ReadLine();
            if (hash.ContainsKey(line))
            {
                hash[line]++;
            }
            else
            {
                hash.Add(line, 1);
            }
        }

        string name = hash.Where(x=>x.Value % 2 != 0).First().Key;
        sw.Write(name);
    }
}