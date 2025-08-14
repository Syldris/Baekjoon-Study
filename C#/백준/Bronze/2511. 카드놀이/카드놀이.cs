#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[] input1 = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int[] input2 = sr.ReadLine().Split().Select(int.Parse).ToArray();

        int a = 0;
        int b = 0;
        int win = 0;
        int draw = 0;
        for (int i = 0; i < 10; i++)
        {
            if (input1[i] > input2[i])
            {
                win = 1;
                a += 3;
            }
            else if (input1[i] < input2[i])
            {
                win = 2;
                b += 3;
            }
            else
            {
                a += 1;
                b += 1;
                draw += 1;
            }
        }

        sw.WriteLine($"{a} {b}");
        if (draw == 10)
        {
            sw.WriteLine('D');
        }
        else if (a == b)
        {
            sw.WriteLine(win == 1 ? 'A' : 'B');
        }
        else
        {
            sw.WriteLine(a > b ? 'A' : 'B');
        }
    }
}
