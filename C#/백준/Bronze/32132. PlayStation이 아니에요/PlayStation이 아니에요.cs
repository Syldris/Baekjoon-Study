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
        StringBuilder sb = new StringBuilder();

        char[] prev = new char[2];
        for (int i = 0; i < n; i++)
        {
            if ((text[i] == '4' || text[i] == '5') && prev[0] == 'P' && prev[1] == 'S')
            {
                continue;
            }
            sb.Append(text[i]);
            prev[0] = prev[1];
            prev[1] = text[i];
        }
        sw.Write(sb);
    }
}