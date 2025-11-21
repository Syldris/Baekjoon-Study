#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int testcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < testcase; t++)
        {
            string line = sr.ReadLine();
            string[] input = sr.ReadLine().Split();

            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            int[] arr1 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] arr2 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);;

            sw.WriteLine(arr1.Max() >= arr2.Max() ? "S" : "B");
        }
    }
}