#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[] arr = sr.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int result = 0;
        foreach (var item in arr)
        {
            result += item;
        }
        sw.Write(result);
    }
}
