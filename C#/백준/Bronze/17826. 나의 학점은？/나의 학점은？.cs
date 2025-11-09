#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int n = int.Parse(sr.ReadLine());
        int result = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == n)
            {
                result = i + 1;
                break;
            }
        }

        string text = result switch
        {
            int x when x >= 1 && x <= 5 => "A+",
            int x when x >= 6 && x <= 15 => "A0",
            int x when x >= 16 && x <= 30 => "B+",
            int x when x >= 31 && x <= 35 => "B0",
            int x when x >= 36 && x <= 45 => "C+",
            int x when x >= 46 && x <= 48 => "C0",
            _ => "F",
        };
        sw.Write(text);
    }
}