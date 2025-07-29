#nullable disable
using System;
using System.Text;
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        string line = sr.ReadLine();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            if (line[i] == 'J')
            {
                sb.Append('O');
            }
            else if (line[i] == 'O')
            {
                sb.Append('I');
            }
            else
            {
                sb.Append('J');
            }
        }
        sw.Write(sb);
    }
}
