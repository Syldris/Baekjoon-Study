#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string text = sr.ReadLine();
        int u = 0;
        int d = 0;
        int p = 0;
        int c = 0;
        foreach (var item in text)
        {
            switch (item)
            {
                case 'U':
                    u++; break;
                case 'D':
                    d++; break;
                case 'P':
                    p++; break;
                case 'C':
                    c++; break;
            }
        }
        if (u + c > (d+p) / 2 +(d+p) % 2 )
        {
            sw.Write('U');
        }
        if (d + p > 0 || d + p > 0)
        {
            sw.Write("DP");
        }
    }
}
