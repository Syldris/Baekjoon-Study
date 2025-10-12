#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string a = sr.ReadLine();
        string b = sr.ReadLine();
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] >= b[i])
            {
                sb.Append(a[i] - '0');
            }
            else
            {
                sb.Append(b[i] - '0');
            }
        }
        sw.Write(sb);
    }
}