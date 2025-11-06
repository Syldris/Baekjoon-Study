#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        string text = sr.ReadLine();
        int value1 = 0;
        foreach (var item in text)
        {
            if (item == '2')
            {
                value1++;
            }
        }
        int value2 = n - value1;
        sw.Write(value1 > value2 ? '2' : value1 < value2 ? 'e' : "yee");
    }
}