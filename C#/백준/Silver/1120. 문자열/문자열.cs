#nullable disable
using System;
using System.Numerics;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        string a = input[0];
        string b = input[1];

        int result = int.MaxValue;
        for (int len = 0; len <= b.Length - a.Length; len++)
        {
            int value = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i + len])
                {
                    value++;
                }
            }
            result = Math.Min(result, value);
        }
        sw.Write(result);
    }
}
