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
        string a = sr.ReadLine();
        string b = sr.ReadLine();

        int result = 0;
        for (int i = 0; i < n; i++)
        {
            if (a[i] != b[i])
                result++;
        }
        sw.Write(result);
    }
}
