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

        int row = Math.Abs((a - 1) / 4 - (b - 1) / 4);
        int col = Math.Abs((a - 1) % 4 - (b - 1) % 4);
        sw.Write(row+col);
    }
}