#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int s = int.Parse(sr.ReadLine());
        int[] arr = sr.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int m = 0;
        foreach (var item in arr)
        {
            m += item;
        }
        if (m >= s || s <= 240)
        {
            sw.Write("high speed rail");
        }
        else
        {
            sw.Write("flight");
        }
    }
}
