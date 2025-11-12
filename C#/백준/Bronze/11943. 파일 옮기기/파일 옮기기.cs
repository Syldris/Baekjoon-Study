#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int a = int.Parse(input[0]);
        int b = int.Parse(input[1]);
        string[] input2 = sr.ReadLine().Split();
        int c = int.Parse(input2[0]);
        int d = int.Parse(input2[1]);

        sw.Write(Math.Min((b + c), (a + d)));
    }
}