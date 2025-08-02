#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        StringBuilder sb = new StringBuilder();
        string[] output = sr.ReadLine().Split();
        int n = int.Parse(output[0]);
        int a = int.Parse(output[1]);
        int b = int.Parse(output[2]);
        string line = sr.ReadLine();
        for (int i = 1; i <= n; i++)
        {
            if (i >= a && i <= b)
            {
                for (int j = b; j >= a; j--)
                {
                    sb.Append(line[j-1]);
                }
                i = b;
            }
            else
                sb.Append(line[i-1]);
        }
        sw.Write(sb);
    }
}
