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

        HashSet<int> hash = new HashSet<int>();
        for (int i = 1; i <= 9; i++)
        {
            for (int j = 1; j <= 9; j++)
            {
                hash.Add(i*j);
            }
        }
        int n = int.Parse(sr.ReadLine());
        sw.WriteLine(hash.Contains(n) ? 1 : 0);
    }
}
