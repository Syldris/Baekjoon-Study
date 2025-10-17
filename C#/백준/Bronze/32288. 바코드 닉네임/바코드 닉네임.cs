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

        for (int i = 0; i < n; i++)
        {
            if ('a' <= text[i] && text[i] <= 'z')
            {
                sb.Append(char.ToUpper(text[i]));
            }
            else
            {
                sb.Append(char.ToLower(text[i]));
            }
        }
        sw.Write(sb);
    }
}