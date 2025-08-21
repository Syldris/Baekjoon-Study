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
        int value = 1;
        foreach (var item in text)
        {
            if (item - '0' == value)
            {
                value++;
            }
            else
            {
                sw.Write(-1);
                return;
            }
        }
        sw.Write(value-1);
    }
}
