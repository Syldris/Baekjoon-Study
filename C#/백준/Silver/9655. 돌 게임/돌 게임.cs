#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        bool[] game = new bool[1001];

        for (int i = 1; i <= n; i += 4)
        {
            game[i] = true;
            game[i+1] = false;
            game[i+2] = true;
            game[i+3] = false;
        }
        sw.Write(game[n] ? "SK" : "CY");
    }
}
