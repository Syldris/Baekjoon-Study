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

        int result = 0;
        for (int i = 0; i < n; i++)
        {
            if (text[i] == 'j' || text[i] == 'i')
            {
                result += 2;
            }
            else
            {
                result++;
            }
        }
        sw.Write(result);
    }
}