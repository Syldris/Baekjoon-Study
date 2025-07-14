#nullable disable
using System;
using System.Collections;
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        string line = sr.ReadLine();
        char c = line[0];
        foreach (var item in line)
        {
            if (item != c)
            {
                sw.Write("No");
                return;
            }
        }
        sw.Write("Yes");
    }
}
