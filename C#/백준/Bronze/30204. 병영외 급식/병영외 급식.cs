#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] line = sr.ReadLine().Split();
        int n = int.Parse(line[0]);
        int x = int.Parse(line[1]);
        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int result = 0;
        foreach (var item in arr)
        {
            result += item;
        }
        sw.Write(result % x == 0 ? 1 : 0);
    }
}
