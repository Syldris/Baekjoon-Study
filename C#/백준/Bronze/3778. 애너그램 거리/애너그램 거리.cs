#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int testcase = int.Parse(sr.ReadLine());
        for (int t = 1; t <= testcase; t++)
        {
            int[] arr1 = new int[26];
            int[] arr2 = new int[26];
            string line1 = sr.ReadLine();
            string line2 = sr.ReadLine();
            foreach (var item in line1)
            {
                arr1[item - 'a']++;
            }
            foreach (var item in line2)
            {
                arr2[item - 'a']++;
            }

            int result = 0;
            for (int i = 0; i < 26; i++)
            {
                result += Math.Abs(arr1[i] - arr2[i]);
            }
            sw.WriteLine($"Case #{t}: {result}");
        }
    }
}
