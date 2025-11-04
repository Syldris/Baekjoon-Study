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
        for (int i = 0; i < testcase; i++)
        {
            string a = sr.ReadLine();
            string b = sr.ReadLine();

            int value = 0;
            for (int index = 0; index < a.Length; index++)
            {
                if (a[index] != b[index])
                {
                    value++;
                }
            }
            sw.WriteLine($"Hamming distance is {value}.");
        }
    }
}