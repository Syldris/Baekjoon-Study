#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        for (int i = 0; i < 3; i++)
        {
            string text = sr.ReadLine();
            int value = 1;
            int result = 1;
            char c = ' ';
            foreach (var item in text)
            {
                if (item == c)
                {
                    value++;
                    result = Math.Max(result, value);
                }
                else
                {
                    value = 1;
                }
                c = item;
            }
            sw.WriteLine(result);
        }
    }
}
