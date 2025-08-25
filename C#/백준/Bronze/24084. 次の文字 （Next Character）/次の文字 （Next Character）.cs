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
        for (int i = 0; i < n - 1; i++)
        {
            if (text[i + 1] == 'J')
            {
                sw.WriteLine(text[i]);
            }
        }
    }
}
