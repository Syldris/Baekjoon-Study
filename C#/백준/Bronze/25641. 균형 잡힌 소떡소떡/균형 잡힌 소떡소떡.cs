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
        int s = 0;
        int t = 0;
        foreach (var item in text)
        {
            if (item == 's')
            {
                s++;
            }
            else
            {
                t++;
            }
        }
        int index = 0;
        while (s != t)
        {
            if (text[index] == 's')
            {
                s--;
            }
            else
            {
                t--;
            }
            index++;
        }
        sw.Write(text[index..n]);
    }
}