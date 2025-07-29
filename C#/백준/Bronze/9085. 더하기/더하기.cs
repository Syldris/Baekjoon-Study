#nullable disable
using System;
using System.Text;
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int testcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < testcase; t++)
        {
            int n = int.Parse(sr.ReadLine());
            int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int result = 0;
            foreach (var item in arr)
            {
                result += item;
            }
            sw.WriteLine(result);
        }
    }
}
