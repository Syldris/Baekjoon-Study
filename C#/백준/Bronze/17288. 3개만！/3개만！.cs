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

        int prev = -10;
        int value = 0;
        int result = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == ++prev)
            {
                value++;
            }
            else
            {
                prev = text[i];
                if (value == 2)
                {
                    result++;
                }
                value = 0;
            }
        }
        if (value == 2)
        {
            result++;
        }

        sw.WriteLine(result);
    }
}