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
        int value = 0;
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == 'X')
            {
                value++;
                if (value == 2)
                {
                    if (i != text.Length - 1 && text[i + 1] == 'X')
                    {
                        continue;
                    }
                    else
                    {
                        sb.Append("BB");
                        value = 0;
                    }
                }
                if (value == 4)
                {
                    sb.Append("AAAA");
                    value = 0;
                }
            }
            else if (value == 0 || value == 2 || value == 4)
            {
                value = 0;
                sb.Append('.');
            }
            else
            {
                sw.Write(-1);
                return;
            }
        }
        sw.Write(value == 0 ? sb : -1);
    }
}
