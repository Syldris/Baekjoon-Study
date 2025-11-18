#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int result = 0;
        for (int i = 0; i < 8; i++)
        {
            int bit = (n >> i) & 1;
            result += bit;
        }
        sw.Write(result);
    }
}