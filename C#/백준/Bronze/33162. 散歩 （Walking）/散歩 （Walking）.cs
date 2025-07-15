#nullable disable
using System;
using System.Collections;
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int result = 0;
        bool advance = true;
        for (int i = 0; i < n; i++)
        {
            if (advance)
                result += 3;
            else
                result -= 2;
            advance = !advance;
        }
        sw.Write(result);
    }
}
