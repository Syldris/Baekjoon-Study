using System;
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        string num = sr.ReadLine();
        long result = 0;
        foreach (char c in num)
        {
            result = (result * 10 +c - '0') % 20000303;
        }
        sw.Write(result);
    }
}