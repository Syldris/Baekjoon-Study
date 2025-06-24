#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        while (true)
        {
            string[] input = sr.ReadLine().Split();
            int a = int.Parse(input[0]), b = int.Parse(input[1]);
            if(a == 0  && b == 0)
                break;
            sw.WriteLine(a + b);
        }
    }
}
