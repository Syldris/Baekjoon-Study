#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        string text = sr.ReadLine();
        int result = 1;
        for (int i = 1; i < n; i++)
        {
            if (text[i] != '[' && text[i] == text[i - 1])
            {
                result++;
            }
            if (!(text[i] == ']'))
            {
                result++;
            }
            if (text[i - 1] == ']' && (text[i] == '2' || text[i] == '5'))
            {
                result++;
            }
        }
        sw.Write(result);
    }
}