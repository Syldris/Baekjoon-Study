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

        int prev = text[0] - '0';
        int up = 0;
        int down = 0;
        int diff = 0;
        if (prev < 0)
        {
            sw.WriteLine("NON ALPSOO");
            return;
        }

        for (int i = 1; i < text.Length; i++)
        {
            int cur = text[i] - '0';
            diff = cur - prev;

            if (i == 1 && diff < 0)
            {
                sw.WriteLine("NON ALPSOO");
                return;
            }

            if (diff > 0)
            {
                down = 0;
                if (up == 0)
                    up = diff;
                else if (up != diff)
                {
                    sw.WriteLine("NON ALPSOO");
                    return;
                }
            }
            else if (diff < 0)
            {
                up = 0;
                if (down == 0)
                    down = diff;
                else if (down != diff)
                {
                    sw.WriteLine("NON ALPSOO");
                    return;
                }
            }
            else
            {
                sw.WriteLine("NON ALPSOO");
                return;
            }
            prev = cur;
        }
        if (diff > 0)
        {
            sw.WriteLine("NON ALPSOO");
            return;
        }
        sw.WriteLine("ALPSOO");
    }
}
