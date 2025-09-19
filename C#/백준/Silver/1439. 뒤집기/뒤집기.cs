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

        string text = sr.ReadLine();
        int zero = 0;
        int one = 0;
        int result = 0;

        int prev = text[0] - '0';

        if (prev == 0) zero++;
        else one++;
        for (int i = 1; i < text.Length; i++)
        {
            int value = text[i] - '0';
            if (value != prev)
            {
                prev = value;
                if (value == 0) zero++;
                else one++;
            }
        }

        sw.Write(Math.Min(zero, one));
    }
}
