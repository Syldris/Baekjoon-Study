#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();
        string[] line = sr.ReadLine().Split();
        int x = int.Parse(line[0]);
        int a = int.Parse(line[1]);

        int result1 = n * x / 100;
        int result2 = 0;
        foreach (var item in arr)
        {
            if (item >= a)
            {
                result2++;
            }
        }
        sw.WriteLine($"{result1} {result2}");
    }
}
